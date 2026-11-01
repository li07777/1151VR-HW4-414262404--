
using UnityEngine;

public class StarCollectible : MonoBehaviour
{
    [Header("遊戲導演")]
    public GameDirector gameDirector;

    [Header("收集分數")]
    public int scoreValue = 10;

    private bool collected = false;

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
            Debug.LogError("StarCollectible 沒有指定 GameDirector！");
            return;
        }

        if (gameDirector.IsGameFinished())
            return;

        collected = true;

        // 增加分數
        gameDirector.AddScore(scoreValue);

        // 播放收集音效
        gameDirector.PlayStarCollectSound();

        Debug.Log("收集星星！+" + scoreValue + " 分");

        // 消除星星
        Destroy(gameObject);
    }
}
