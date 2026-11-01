
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class FinishTrigger : MonoBehaviour
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
            "終點偵測到：" + other.name
        );

        if (hasTriggered)
            return;

        AircraftController player =
            other.GetComponentInParent<AircraftController>();

        if (player == null)
            return;

        if (gameDirector == null)
        {
            Debug.LogError(
                "FinishTrigger 沒有指定 GameDirector！");
            return;
        }

        if (player != gameDirector.aircraft)
            return;

        if (gameDirector.IsGameFinished())
            return;

        hasTriggered = true;

        Debug.Log("飛機成功進入終點！");

        gameDirector.WinGame();
    }
}
