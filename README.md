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

**操作方式：**

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

**製作過程中的問題與解決方式**

製作彩虹收集道具時，原本嘗試加入旋轉、漂浮及發光效果，但因為模型的座標與旋轉中心設定問題，造成彩虹在場景中繞圈移動，因此最後改成固定位置的收集道具。

此外，粒子特效曾經出現遊戲開始就自動播放、碰撞後沒有顯示，以及特效出現在飛機後方等問題。後來透過調整 Particle System 的 Play On Awake、特效生成位置與跟隨方式，成功讓彩虹在被收集時才觸發大型閃光效果。

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


**1. 遊戲場景與飛機飛行**
<img width="2880" height="1710" alt="螢幕擷取畫面 2026-11-01 184647" src="https://github.com/user-attachments/assets/2d844770-89b2-4d2a-8100-eb0f6058dc3f" />


**2. 星星與彩虹道具收集**

<img width="2880" height="1704" alt="image" src="https://github.com/user-attachments/assets/fdc43aa1-4aa2-4a49-9362-6263464f4806" />


**3. 彩虹大型閃光特效**
<img width="1568" height="884" alt="image" src="https://github.com/user-attachments/assets/8d5ac358-03f3-44c8-8640-800615c1ded4" />

<img width="1570" height="888" alt="image" src="https://github.com/user-attachments/assets/d0f1b6e2-7061-4f20-93f0-9afd8b3f865c" />


**4. Game Over 畫面**

<img width="2880" height="1266" alt="image" src="https://github.com/user-attachments/assets/e4133805-f559-4c31-98d3-70a159716696" />) 

**5. You Win 畫面**
<img width="1584" height="880" alt="image" src="https://github.com/user-attachments/assets/716d2489-dacd-4f93-a97c-fb1e182ed94b" />


### 八、GitHub 與示範影片

- **GitHub 專案：** [https://github.com/li07777/1151VR-HW4-414262404--]
- **YouTube 遊戲操作影片：** [https://youtu.be/wVxIA1nC5YY]


### 九、製作心得

這次作業使用 Unity 6 製作 SkyRunner3D 3D 飛行遊戲，從一開始建立場景、匯入飛機與障礙物模型，到後來加入飛行控制、碰撞偵測、計分系統及音效，讓我更熟悉 Unity 的操作方式，也學習到如何將不同功能整合成一個完整的遊戲。

製作過程中遇到不少問題，尤其是在設計彩虹收集道具時，原本希望加入旋轉、漂浮及發光效果，但實際執行後卻出現模型繞圈、特效提前播放，以及收集後看不到粒子效果等情況。後來透過反覆調整程式與 Particle System 設定，才成功讓飛機收集彩虹時顯示大型閃光特效，也讓我更了解物件座標、Prefab 和粒子系統之間的關係。

整體來說，這次作業雖然花了不少時間修改與測試，但看到飛機能夠順利飛行、收集道具、累積分數，並完成勝利與失敗的遊戲流程時，還是很有成就感。透過這次實作，我不只學會了更多 Unity 功能，也更了解遊戲開發需要不斷測試、找出問題並逐步改善的過程。
