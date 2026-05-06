# WAV 音效檔播放器

這是一個使用 C# Windows Forms 製作的簡易 WAV 音效檔播放器。  
使用者可以透過圖形化介面選擇 `.wav` 音效檔，並進行播放一次、重複播放、停止播放與結束程式等操作。

## 功能介紹

- 選擇本機 WAV 音效檔
- 顯示目前選擇的音效檔路徑
- 播放音效一次
- 重複播放音效
- 停止播放音效
- 關閉程式前跳出確認視窗
- 使用淡藍色背景與不同顏色按鈕提升介面辨識度

## 開發環境

- 程式語言：C#
- 開發框架：.NET Framework / Windows Forms
- 開發工具：Visual Studio
- 使用類別：
  - `System.Windows.Forms`
  - `System.Media.SoundPlayer`
  - `System.Drawing`
  - `System.IO`



<img width="473" height="188" alt="螢幕擷取畫面 2026-05-06 230158" src="https://github.com/user-attachments/assets/f85fb3fd-9b30-406f-904c-ab4c10dd3ad6" />


## 專案結構

```text
WAVPlayer/
│
├── frmWAVPlayer.cs          # 主要表單程式邏輯
├── frmWAVPlayer.Designer.cs # 表單元件設計檔
├── Program.cs               # 程式進入點
└── README.md                # 專案說明文件
