using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameDirector : MonoBehaviour
{
    [Header("玩家飛機")]
    public AircraftController aircraft;

    [Header("遊戲 UI")]
    public GameObject winPanel;
    public GameObject gameOverPanel;

    [Header("分數系統")]
    public TMP_Text scoreText;
    public int score = 0;

    [Header("音效播放器")]
    public AudioSource flyingAudioSource;
    public AudioSource effectAudioSource;

    [Header("遊戲音效")]
    public AudioClip flyingClip;
    public AudioClip crashClip;
    public AudioClip successClip;
    public AudioClip starCollectClip;
    public AudioClip rainbowCollectClip;

    private bool gameFinished = false;

    // =========================
    // 初始化
    // =========================
    void Awake()
    {
        Time.timeScale = 1f;
        gameFinished = false;
        score = 0;

        if (winPanel != null)
            winPanel.SetActive(false);

        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);
    }

    void Start()
    {
        UpdateScoreUI();
        PlayFlyingSound();
    }

    // =========================
    // 飛行音效
    // =========================
    void PlayFlyingSound()
    {
        if (flyingAudioSource == null || flyingClip == null)
        {
            Debug.LogWarning("飛行音效尚未設定！");
            return;
        }

        flyingAudioSource.clip = flyingClip;
        flyingAudioSource.loop = true;
        flyingAudioSource.playOnAwake = false;
        flyingAudioSource.volume = 0.35f;
        flyingAudioSource.spatialBlend = 0f;

        flyingAudioSource.Play();

        Debug.Log("開始播放飛行音效");
    }

    void StopFlyingSound()
    {
        if (flyingAudioSource != null)
            flyingAudioSource.Stop();
    }

    // =========================
    // 播放一般音效
    // =========================
    void PlayEffect(AudioClip clip)
    {
        if (effectAudioSource == null || clip == null)
        {
            Debug.LogWarning("音效或 AudioSource 尚未設定！");
            return;
        }

        effectAudioSource.PlayOneShot(clip, 1f);
    }

    // =========================
    // 星星收集音效
    // =========================
    public void PlayStarCollectSound()
    {
        if (effectAudioSource == null)
        {
            Debug.LogError("Effect Audio Source 尚未設定！");
            return;
        }

        if (starCollectClip == null)
        {
            Debug.LogError("Star Collect Clip 尚未設定！");
            return;
        }

        effectAudioSource.PlayOneShot(starCollectClip, 1f);

        Debug.Log("STAR COLLECT SOUND!");
    }

    // =========================
    // 彩虹收集音效
    // =========================
    public void PlayRainbowCollectSound()
    {
        if (effectAudioSource == null)
        {
            Debug.LogError("Effect Audio Source 尚未設定！");
            return;
        }

        if (rainbowCollectClip == null)
        {
            Debug.LogError("Rainbow Collect Clip 尚未設定！");
            return;
        }

        effectAudioSource.PlayOneShot(rainbowCollectClip, 1f);

        Debug.Log("RAINBOW COLLECT SOUND!");
    }

    // =========================
    // 增加分數
    // =========================
    public void AddScore(int amount)
    {
        if (gameFinished)
            return;

        score += amount;
        UpdateScoreUI();

        Debug.Log("目前分數：" + score);
    }

    // =========================
    // 更新分數 UI
    // =========================
    void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "SCORE: " + score;
        }
    }

    // =========================
    // GAME OVER
    // =========================
    public void GameOver()
    {
        if (gameFinished)
            return;

        gameFinished = true;

        Debug.Log("GAME OVER!");

        if (aircraft != null)
            aircraft.StopFlying();

        StopFlyingSound();
        PlayEffect(crashClip);

        if (winPanel != null)
            winPanel.SetActive(false);

        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
            gameOverPanel.transform.SetAsLastSibling();
        }
        else
        {
            Debug.LogWarning("GameOverPanel 尚未指定！");
        }
    }

    // =========================
    // YOU WIN
    // =========================
    public void WinGame()
    {
        if (gameFinished)
            return;

        gameFinished = true;

        Debug.Log("YOU WIN!");

        if (aircraft != null)
            aircraft.StopFlying();

        StopFlyingSound();
        PlayEffect(successClip);

        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);

        if (winPanel != null)
        {
            winPanel.SetActive(true);
            winPanel.transform.SetAsLastSibling();
        }
        else
        {
            Debug.LogWarning("WinPanel 尚未指定！");
        }
    }

    // =========================
    // RETRY
    // =========================
    public void RetryGame()
    {
        Debug.Log("RETRY BUTTON CLICKED!");

        Time.timeScale = 1f;

        SceneManager.LoadScene(
            SceneManager.GetActiveScene().name
        );
    }

    // =========================
    // 查詢遊戲是否結束
    // =========================
    public bool IsGameFinished()
    {
        return gameFinished;
    }
}