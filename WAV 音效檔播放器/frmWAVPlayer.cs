using System;
using System.Drawing;
using System.IO;
using System.Media;
using System.Windows.Forms;

namespace WAVPlayer
{
    public partial class frmWAVPlayer : Form
    {
        // 建立全域播放器物件
        private SoundPlayer player = new SoundPlayer();

        public frmWAVPlayer()
        {
            InitializeComponent();

            // 版面配置
            SetupLayout();

            // 事件綁定
            BindEvents();

            // OpenFileDialog 基本設定
            ofdWAVFile.Filter = "WAV Files (*.wav)|*.wav";
            ofdWAVFile.DefaultExt = "wav";
            ofdWAVFile.FileName = "";
            ofdWAVFile.Title = "請選擇 WAV 音效檔";
        }

        // -------------------------
        // 版面配置
        // -------------------------
        private void SetupLayout()
        {
            // 表單設定
            this.Text = "WAV 音效檔播放器";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new Size(650, 260);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            // 背景顏色，改成比較明顯的淡藍色
            this.BackColor = Color.LightBlue;

            // 音效位置 GroupBox
            grpPath.Text = "音效位置";
            grpPath.Location = new Point(20, 20);
            grpPath.Size = new Size(590, 75);
            grpPath.Font = new Font("微軟正黑體", 11);
            grpPath.BackColor = Color.LightBlue;

            // 路徑文字框
            txtPath.Location = new Point(20, 30);
            txtPath.Size = new Size(450, 30);
            txtPath.Font = new Font("Consolas", 11);
            txtPath.ReadOnly = true;
            txtPath.BackColor = Color.White;

            // 瀏覽按鈕
            btnBrowse.Text = "瀏覽";
            btnBrowse.Location = new Point(485, 28);
            btnBrowse.Size = new Size(80, 32);
            btnBrowse.Font = new Font("微軟正黑體", 11);
            btnBrowse.BackColor = Color.LightYellow;
            btnBrowse.UseVisualStyleBackColor = false;

            // 播放按鈕 GroupBox
            grpButton.Text = "播放按鈕";
            grpButton.Location = new Point(20, 110);
            grpButton.Size = new Size(590, 85);
            grpButton.Font = new Font("微軟正黑體", 11);
            grpButton.BackColor = Color.LightBlue;

            // 播放一次
            btnPlay.Text = "播放一次";
            btnPlay.Location = new Point(25, 35);
            btnPlay.Size = new Size(110, 35);
            btnPlay.Font = new Font("微軟正黑體", 11);
            btnPlay.BackColor = Color.LightGreen;
            btnPlay.UseVisualStyleBackColor = false;

            // 重複播放
            btnLoop.Text = "重複播放";
            btnLoop.Location = new Point(155, 35);
            btnLoop.Size = new Size(110, 35);
            btnLoop.Font = new Font("微軟正黑體", 11);
            btnLoop.BackColor = Color.LightYellow;
            btnLoop.UseVisualStyleBackColor = false;

            // 停止播放
            btnStop.Text = "停止播放";
            btnStop.Location = new Point(285, 35);
            btnStop.Size = new Size(110, 35);
            btnStop.Font = new Font("微軟正黑體", 11);
            btnStop.BackColor = Color.LightCoral;
            btnStop.UseVisualStyleBackColor = false;

            // 結束程式
            btnEnd.Text = "結束程式";
            btnEnd.Location = new Point(415, 35);
            btnEnd.Size = new Size(110, 35);
            btnEnd.Font = new Font("微軟正黑體", 11);
            btnEnd.BackColor = Color.LightGray;
            btnEnd.UseVisualStyleBackColor = false;

            // 確保控制項在正確的 GroupBox 裡面
            grpPath.Controls.Add(txtPath);
            grpPath.Controls.Add(btnBrowse);

            grpButton.Controls.Add(btnPlay);
            grpButton.Controls.Add(btnLoop);
            grpButton.Controls.Add(btnStop);
            grpButton.Controls.Add(btnEnd);
        }

        // -------------------------
        // 綁定事件
        // -------------------------
        private void BindEvents()
        {
            btnBrowse.Click -= btnBrowse_Click;
            btnBrowse.Click += btnBrowse_Click;

            btnPlay.Click -= btnPlay_Click;
            btnPlay.Click += btnPlay_Click;

            btnLoop.Click -= btnLoop_Click;
            btnLoop.Click += btnLoop_Click;

            btnStop.Click -= btnStop_Click;
            btnStop.Click += btnStop_Click;

            btnEnd.Click -= btnEnd_Click;
            btnEnd.Click += btnEnd_Click;

            this.FormClosing -= frmWAVPlayer_FormClosing;
            this.FormClosing += frmWAVPlayer_FormClosing;
        }

        // -------------------------
        // 檢查路徑是否正確
        // -------------------------
        private bool CheckWAVFile()
        {
            if (txtPath.Text == "")
            {
                MessageBox.Show("請先選擇 WAV 檔案", "提醒",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!File.Exists(txtPath.Text))
            {
                MessageBox.Show("檔案不存在，請重新選擇", "錯誤",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        // -------------------------
        // 瀏覽檔案
        // -------------------------
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            ofdWAVFile.Filter = "WAV Files (*.wav)|*.wav";

            if (ofdWAVFile.ShowDialog() == DialogResult.OK)
            {
                txtPath.Text = ofdWAVFile.FileName;
            }
        }

        // -------------------------
        // 播放一次
        // -------------------------
        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (!CheckWAVFile())
                return;

            try
            {
                player.Stop();

                player.SoundLocation = txtPath.Text;
                player.Load();
                player.Play();
            }
            catch (Exception ex)
            {
                MessageBox.Show("播放失敗：" + ex.Message, "錯誤",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // -------------------------
        // 重複播放
        // -------------------------
        private void btnLoop_Click(object sender, EventArgs e)
        {
            if (!CheckWAVFile())
                return;

            try
            {
                player.Stop();

                player.SoundLocation = txtPath.Text;
                player.Load();
                player.PlayLooping();
            }
            catch (Exception ex)
            {
                MessageBox.Show("播放失敗：" + ex.Message, "錯誤",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // -------------------------
        // 停止播放
        // -------------------------
        private void btnStop_Click(object sender, EventArgs e)
        {
            player.Stop();
        }

        // -------------------------
        // 結束程式
        // -------------------------
        private void btnEnd_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // -------------------------
        // 關閉表單前確認
        // -------------------------
        private void frmWAVPlayer_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "確定要關閉應用程式嗎？",
                "關閉確認",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                player.Stop();
            }
        }
    }
}