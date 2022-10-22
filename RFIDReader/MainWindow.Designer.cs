
namespace RFIDReader
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.idListView = new System.Windows.Forms.DataGridView();
            this.col_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_credit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_rate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_file = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_function = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_sound = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.start_btn = new System.Windows.Forms.Button();
            this.stop_btn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.idListView)).BeginInit();
            this.SuspendLayout();
            // 
            // idListView
            // 
            this.idListView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.idListView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_id,
            this.col_credit,
            this.col_rate,
            this.col_file,
            this.col_function,
            this.col_sound});
            this.idListView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.idListView.Location = new System.Drawing.Point(12, 12);
            this.idListView.Name = "idListView";
            this.idListView.RowHeadersVisible = false;
            this.idListView.Size = new System.Drawing.Size(1303, 421);
            this.idListView.TabIndex = 0;
            // 
            // col_id
            // 
            this.col_id.DataPropertyName = "ID";
            this.col_id.HeaderText = "ID";
            this.col_id.Name = "col_id";
            this.col_id.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.col_id.Width = 150;
            // 
            // col_credit
            // 
            this.col_credit.DataPropertyName = "Credit";
            this.col_credit.HeaderText = "Credit ($)";
            this.col_credit.Name = "col_credit";
            // 
            // col_rate
            // 
            this.col_rate.DataPropertyName = "Rate";
            this.col_rate.HeaderText = "Rate ($)";
            this.col_rate.Name = "col_rate";
            // 
            // col_file
            // 
            this.col_file.DataPropertyName = "ProcessFile";
            this.col_file.HeaderText = "File";
            this.col_file.Name = "col_file";
            this.col_file.Width = 400;
            // 
            // col_function
            // 
            this.col_function.DataPropertyName = "Key";
            this.col_function.HeaderText = "Function";
            this.col_function.Name = "col_function";
            this.col_function.Width = 150;
            // 
            // col_sound
            // 
            this.col_sound.DataPropertyName = "SoundFile";
            this.col_sound.HeaderText = "Sound";
            this.col_sound.Name = "col_sound";
            this.col_sound.Width = 400;
            // 
            // start_btn
            // 
            this.start_btn.Location = new System.Drawing.Point(142, 439);
            this.start_btn.Name = "start_btn";
            this.start_btn.Size = new System.Drawing.Size(75, 23);
            this.start_btn.TabIndex = 1;
            this.start_btn.Text = "Start";
            this.start_btn.UseVisualStyleBackColor = true;
            this.start_btn.Click += new System.EventHandler(this.start_btn_Click);
            // 
            // stop_btn
            // 
            this.stop_btn.Enabled = false;
            this.stop_btn.Location = new System.Drawing.Point(1068, 439);
            this.stop_btn.Name = "stop_btn";
            this.stop_btn.Size = new System.Drawing.Size(75, 23);
            this.stop_btn.TabIndex = 2;
            this.stop_btn.Text = "Stop";
            this.stop_btn.UseVisualStyleBackColor = true;
            this.stop_btn.Click += new System.EventHandler(this.stop_btn_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1327, 474);
            this.Controls.Add(this.stop_btn);
            this.Controls.Add(this.start_btn);
            this.Controls.Add(this.idListView);
            this.Name = "MainWindow";
            this.Text = "RFID Credit System";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_Closing);
            this.Load += new System.EventHandler(this.MainWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.idListView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView idListView;
        private System.Windows.Forms.Button start_btn;
        private System.Windows.Forms.Button stop_btn;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_credit;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_rate;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_file;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_function;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_sound;
    }
}

