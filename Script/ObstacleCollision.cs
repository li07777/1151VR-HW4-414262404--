
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class ObstacleCollision : MonoBehaviour
{
    [Header("遊戲導演")]
    public GameDirector gameDirector;

    private bool hasTriggered = false;

    void Awake()
    {
        Collider col = GetComponent<Collider>();
        col.isTrigger = true;
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(
            "碰撞偵測到：" + other.name +
            "，障礙物：" + gameObject.name
        );

        if (hasTriggered)
            return;

        // 確認碰到的是飛機
        AircraftController player =
            other.GetComponentInParent<AircraftController>();

        if (player == null)
        {
            Debug.Log("碰到的不是玩家飛機");
            return;
        }

        if (gameDirector == null)
        {
            Debug.LogError(
                "ObstacleCollision 沒有指定 GameDirector！");
            return;
        }

        if (player != gameDirector.aircraft)
        {
            Debug.LogWarning(
                "碰到的飛機與 GameDirector 指定的不相同");
            return;
        }

        if (gameDirector.IsGameFinished())
            return;

        hasTriggered = true;

        Debug.Log("飛機撞到障礙物！");

        // 通知遊戲導演
        gameDirector.GameOver();
    }
}
