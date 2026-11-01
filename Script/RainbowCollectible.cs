
using UnityEngine;

public class RainbowCollectible : MonoBehaviour
{
    [Header("遊戲導演")]
    public GameDirector gameDirector;

    [Header("加分設定")]
    public int scoreValue = 30;

    [Header("大型閃光特效")]
    public GameObject collectEffectPrefab;
    public float effectLifetime = 5f;
    public float effectScale = 3f;

    [Header("特效位置")]
    public Vector3 effectOffset = new Vector3(0, 0, 0);

    private bool collected = false;

    private Renderer[] rainbowRenderers;
    private Collider[] rainbowColliders;

    void Awake()
    {
        rainbowRenderers =
            GetComponentsInChildren<Renderer>();

        rainbowColliders =
            GetComponentsInChildren<Collider>();

        Debug.Log("RainbowCollectible 已啟動");
    }

    // =========================
    // 碰撞收集
    // =========================

    void OnTriggerEnter(Collider other)
    {
        if (collected)
            return;

        AircraftController player =
            other.GetComponentInParent<AircraftController>();

        if (player == null)
            return;

        if (gameDirector == null)
        {
            Debug.LogError("GameDirector 沒有指定！");
            return;
        }

        if (gameDirector.IsGameFinished())
            return;

        collected = true;

        Debug.Log("RAINBOW COLLECTED!");

        // 增加 30 分
        gameDirector.AddScore(scoreValue);

        // 播放彩虹音效
        gameDirector.PlayRainbowCollectSound();

        // 播放大型閃光
        SpawnCollectEffect();

        // 隱藏彩虹
        foreach (Renderer r in rainbowRenderers)
            r.enabled = false;

        // 關閉碰撞
        foreach (Collider c in rainbowColliders)
            c.enabled = false;

        Debug.Log("彩虹收集完成！");

        Destroy(gameObject);
    }

    // =========================
    // 大型閃光特效
    // =========================

    void SpawnCollectEffect()
    {
        if (collectEffectPrefab == null)
        {
            Debug.LogError("RainbowBurstFX 沒有指定！");
            return;
        }

        Vector3 spawnPosition =
            transform.position + effectOffset;

        GameObject fx = Instantiate(
            collectEffectPrefab,
            spawnPosition,
            Quaternion.identity
        );

        fx.SetActive(true);

        fx.transform.localScale =
            Vector3.one * effectScale;

        ParticleSystem[] particles =
            fx.GetComponentsInChildren<ParticleSystem>(true);

        if (particles.Length == 0)
        {
            Debug.LogError("找不到 Particle System！");
            Destroy(fx);
            return;
        }

        foreach (ParticleSystem ps in particles)
        {
            ps.gameObject.SetActive(true);

            ps.Stop(
                true,
                ParticleSystemStopBehavior.StopEmittingAndClear
            );

            ps.Play(true);

            Debug.Log(
                "粒子開始播放：" + ps.name
            );
        }

        Debug.Log(
            "大型閃光特效已產生，位置：" + spawnPosition
        );

        Destroy(fx, effectLifetime);
    }
}
