# 1151VR-HW4-414262404-李姍霓

## ✈️ SkyRunner3D｜3D 飛機飛行與收集遊戲

### 一、作業基本資訊

| 項目 | 內容 |
|---|---|
| 課程 | 1151 虛擬實境遊戲設計 |
| 作業 | HW4 |
| 學生 | 資工二乙　李姍霓 |
| 學號 | 414262404 |
| 遊戲名稱 | SkyRunner3D |
| 開發工具 | Unity 6、C#、Visual Studio、GitHub |
| 遊戲類型 | 3D 飛行、障礙閃避與道具收集 |

### 二、製作動機與作業目的

本次作業以 3D 飛行遊戲為主題，使用 Unity 6 製作一款可以控制飛機向前飛行、閃避障礙物、收集道具並抵達終點的遊戲。希望藉由實作熟悉 Unity 的 3D 場景建置、物件移動、碰撞偵測、UI 介面、音效、粒子特效與遊戲流程控制。

### 三、遊戲內容與玩法

玩家操作飛機在空中持續向前飛行，利用鍵盤控制左右方向與飛行高度，避開雲朵等障礙物，並在途中收集星星和彩虹道具取得分數。碰到障礙物後遊戲失敗；成功飛抵終點的彩色氣球拱門則過關。

**操作方式（電腦版）：**

| 按鍵 | 功能 |
|---|---|
| `W` / `↑` | 向上飛行 |
| `S` / `↓` | 向下飛行 |
| `A` / `←` | 向左飛行 |
| `D` / `→` | 向右飛行 |
| `Retry` 按鈕 | 重新開始遊戲 |

飛機會自動向前移動，玩家主要負責調整方向與高度。

### 四、主要遊戲功能

#### 1. 飛機自動飛行與攝影機跟隨
- 使用 `AircraftController.cs` 控制飛機持續向前飛行。
- 透過 Unity Input System 接收鍵盤方向控制。
- 使用 `CameraFollow.cs` 讓第三人稱攝影機跟隨飛機，保持穩定視角。

#### 2. 障礙物與失敗判定
- 場景設置雲朵等 3D 障礙物。
- 使用 Collider 的 Trigger 偵測碰撞。
- 飛機撞到障礙時停止飛行，顯示 `GAME OVER` 面板並播放碰撞音效。

#### 3. 道具收集與分數系統

| 道具 | 得分 | 收集效果 |
|---|---:|---|
| ⭐ 星星 | +10 | 增加分數、播放收集音效並移除道具 |
| 🌈 彩虹 | +30 | 增加分數、播放音效，觸發大型彩色粒子爆發特效並移除道具 |

分數會即時顯示在畫面的 `SCORE` UI。

#### 4. 彩虹粒子特效
- 使用 Unity 內建 `Particle System` 製作 `RainbowBurstFX` Prefab。
- 利用彩色粒子 Burst 營造大型閃光效果。
- 特效只會在收集彩虹時播放，不會於遊戲開始時自動出現。
- 特效短暫跟隨飛機顯示，播放結束後自動刪除。

#### 5. 終點與勝利判定
- 使用彩色氣球拱門作為終點標誌。
- 飛機通過終點 Trigger 後停止飛行，顯示 `YOU WIN!` 面板並播放勝利音效。

#### 6. 重新開始與音效
- 勝利與失敗畫面都提供 `Retry` 按鈕，可以重新載入場景。
- 遊戲整合飛行背景聲、撞擊聲、勝利聲及道具收集音效。

### 五、Unity 專案製作流程

1. 建立 Unity 6 的 3D 專案，規劃天空、飛行路線與裝飾場景。
2. 匯入飛機、雲朵、浮空島、氣球拱門等 3D 模型並調整位置、比例與材質。
3. 製作 `AircraftController.cs`，實現自動前進及鍵盤方向控制。
4. 製作 `CameraFollow.cs`，讓攝影機從後方跟隨飛機。
5. 為障礙物設定 Trigger Collider，搭配 `ObstacleCollision.cs` 處理失敗判定。
6. 使用 `GameDirector.cs` 管理遊戲狀態、分數、音效、勝利及失敗介面。
7. 製作星星與彩虹收集道具，設定不同分數。
8. 使用 Particle System 製作彩虹收集時的大型閃光特效，並修正特效顯示位置。
9. 設定終點 `FinishTrigger.cs`，測試過關及重新開始功能。
10. 在 Unity Editor 中完整測試遊戲流程與介面。

### 六、使用的主要 C# 腳本

| 腳本 | 功能 |
|---|---|
| `AircraftController.cs` | 飛機自動前進與方向移動控制 |
| `CameraFollow.cs` | 攝影機跟隨飛機 |
| `GameDirector.cs` | 分數、音效、勝負判定與重新開始 |
| `ObstacleCollision.cs` | 障礙物碰撞、觸發 Game Over |
| `FinishTrigger.cs` | 終點碰撞、觸發 You Win |
| `StarCollectible.cs` | 星星收集 +10 分 |
| `RainbowCollectible.cs` | 彩虹收集 +30 分與大型粒子特效 |

### 七、成果截圖

> 請將實際遊戲截圖上傳至儲存庫 `Screenshots/`，再把下列檔名替換成實際圖片名稱。

**1. 遊戲場景與飛機飛行**

<!-- ![遊戲場景](Screenshots/gameplay.png) -->

**2. 星星與彩虹道具收集**

<!-- ![道具收集](Screenshots/collectibles.png) -->

**3. 彩虹大型閃光特效**

<!-- ![彩虹特效](Screenshots/rainbow-effect.png) -->

**4. Game Over 畫面**

<!-- ![Game Over](Screenshots/game-over.png) -->

**5. You Win 畫面**

<!-- ![You Win](Screenshots/you-win.png) -->

### 八、手機平台測試說明

本專案曾嘗試透過 Windows 電腦搭配 iPhone 的 **Unity Remote 5** 進行手機畫面預覽與連線測試。Windows 的 iTunes 可以辨識 iPhone，但 Unity Remote 5 的畫面連線仍遇到問題。

另外也了解 Unity Device Simulator 可以在 Unity Editor 中模擬手機畫面比例與介面配置，但這不等於將遊戲實際安裝到 iPhone。

**目前未完成 iPhone 實機安裝，因此不將 Unity Remote／Device Simulator 視為正式 iOS Build 成果。**

### 九、GitHub 與示範影片

- **GitHub 專案：** `[請貼上 HW4 Repository 連結]`
- **YouTube 遊戲操作影片：** `[請貼上影片連結]`

影片建議展示飛機移動、閃避障礙、星星 +10、彩虹 +30 與閃光特效、GAME OVER、YOU WIN 及 Retry。

### 十、製作心得

這次製作 SkyRunner3D 的過程，除了練習 Unity 3D 物件與攝影機操作，也學習如何整合 C# 程式、碰撞偵測、UI、計分及音效。製作彩虹粒子特效時，曾遇到特效一開始就播放、收集後看不到效果，以及特效出現在飛機後方等問題。透過調整 Particle System 的播放設定與特效生成位置，最後成功讓彩虹在收集時顯示大型閃光效果。

整體而言，這次作業讓我更熟悉 Unity 遊戲從場景建置到互動功能整合的完整流程，也體會到反覆測試與排除問題的重要性。
