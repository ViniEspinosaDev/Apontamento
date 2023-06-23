namespace Apontamento
{
    partial class ApontamentoForm
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ApontamentoForm));
            DatePickerDataApontamento = new DateTimePicker();
            GroupBoxPreview = new GroupBox();
            btnCopiar = new Button();
            labelPreview = new Label();
            groupBoxSalvar = new GroupBox();
            btnSalvar = new Button();
            labelTempoExemplo = new Label();
            maskedTextBoxHoras = new MaskedTextBox();
            labelTempo = new Label();
            comboBoxAcao = new ComboBox();
            labelAcao = new Label();
            labelTarefaExemplo = new Label();
            textBoxTarefa = new TextBox();
            labelTarefa = new Label();
            comboBoxLinha = new ComboBox();
            labelLinha = new Label();
            labelMensagemLog = new Label();
            timerMensagemLog = new System.Windows.Forms.Timer(components);
            GroupBoxPreview.SuspendLayout();
            groupBoxSalvar.SuspendLayout();
            SuspendLayout();
            // 
            // DatePickerDataApontamento
            // 
            DatePickerDataApontamento.Location = new Point(14, 16);
            DatePickerDataApontamento.Margin = new Padding(3, 4, 3, 4);
            DatePickerDataApontamento.Name = "DatePickerDataApontamento";
            DatePickerDataApontamento.Size = new Size(386, 27);
            DatePickerDataApontamento.TabIndex = 0;
            DatePickerDataApontamento.ValueChanged += DatePickerDataApontamento_ValueChanged;
            // 
            // GroupBoxPreview
            // 
            GroupBoxPreview.Controls.Add(btnCopiar);
            GroupBoxPreview.Controls.Add(labelPreview);
            GroupBoxPreview.Location = new Point(475, 9);
            GroupBoxPreview.Margin = new Padding(3, 4, 3, 4);
            GroupBoxPreview.Name = "GroupBoxPreview";
            GroupBoxPreview.Padding = new Padding(3, 4, 3, 4);
            GroupBoxPreview.Size = new Size(425, 571);
            GroupBoxPreview.TabIndex = 1;
            GroupBoxPreview.TabStop = false;
            GroupBoxPreview.Text = "Preview";
            // 
            // btnCopiar
            // 
            btnCopiar.Location = new Point(332, 532);
            btnCopiar.Margin = new Padding(3, 4, 3, 4);
            btnCopiar.Name = "btnCopiar";
            btnCopiar.Size = new Size(86, 31);
            btnCopiar.TabIndex = 4;
            btnCopiar.Text = "Copiar";
            btnCopiar.UseVisualStyleBackColor = true;
            btnCopiar.Click += btnCopiar_Click;
            // 
            // labelPreview
            // 
            labelPreview.AutoSize = true;
            labelPreview.Location = new Point(7, 25);
            labelPreview.MaximumSize = new Size(411, 535);
            labelPreview.MinimumSize = new Size(411, 535);
            labelPreview.Name = "labelPreview";
            labelPreview.Size = new Size(411, 535);
            labelPreview.TabIndex = 0;
            // 
            // groupBoxSalvar
            // 
            groupBoxSalvar.Controls.Add(btnSalvar);
            groupBoxSalvar.Controls.Add(labelTempoExemplo);
            groupBoxSalvar.Controls.Add(maskedTextBoxHoras);
            groupBoxSalvar.Controls.Add(labelTempo);
            groupBoxSalvar.Controls.Add(comboBoxAcao);
            groupBoxSalvar.Controls.Add(labelAcao);
            groupBoxSalvar.Controls.Add(labelTarefaExemplo);
            groupBoxSalvar.Controls.Add(textBoxTarefa);
            groupBoxSalvar.Controls.Add(labelTarefa);
            groupBoxSalvar.Controls.Add(comboBoxLinha);
            groupBoxSalvar.Controls.Add(labelLinha);
            groupBoxSalvar.Location = new Point(12, 51);
            groupBoxSalvar.Margin = new Padding(3, 4, 3, 4);
            groupBoxSalvar.Name = "groupBoxSalvar";
            groupBoxSalvar.Padding = new Padding(3, 4, 3, 4);
            groupBoxSalvar.Size = new Size(455, 207);
            groupBoxSalvar.TabIndex = 3;
            groupBoxSalvar.TabStop = false;
            groupBoxSalvar.Text = "Editar horas";
            // 
            // btnSalvar
            // 
            btnSalvar.Location = new Point(362, 168);
            btnSalvar.Margin = new Padding(3, 4, 3, 4);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(86, 31);
            btnSalvar.TabIndex = 11;
            btnSalvar.Text = "Salvar";
            btnSalvar.UseVisualStyleBackColor = true;
            btnSalvar.Click += btnSalvar_Click;
            // 
            // labelTempoExemplo
            // 
            labelTempoExemplo.AutoSize = true;
            labelTempoExemplo.Location = new Point(232, 156);
            labelTempoExemplo.Name = "labelTempoExemplo";
            labelTempoExemplo.Size = new Size(66, 20);
            labelTempoExemplo.TabIndex = 10;
            labelTempoExemplo.Text = "Ex. 06:30";
            // 
            // maskedTextBoxHoras
            // 
            maskedTextBoxHoras.Location = new Point(70, 145);
            maskedTextBoxHoras.Margin = new Padding(3, 4, 3, 4);
            maskedTextBoxHoras.Mask = "00:00";
            maskedTextBoxHoras.Name = "maskedTextBoxHoras";
            maskedTextBoxHoras.Size = new Size(155, 27);
            maskedTextBoxHoras.TabIndex = 9;
            maskedTextBoxHoras.ValidatingType = typeof(DateTime);
            // 
            // labelTempo
            // 
            labelTempo.AutoSize = true;
            labelTempo.Location = new Point(7, 156);
            labelTempo.Name = "labelTempo";
            labelTempo.Size = new Size(58, 20);
            labelTempo.TabIndex = 7;
            labelTempo.Text = "Tempo:";
            // 
            // comboBoxAcao
            // 
            comboBoxAcao.FormattingEnabled = true;
            comboBoxAcao.Location = new Point(69, 107);
            comboBoxAcao.Margin = new Padding(3, 4, 3, 4);
            comboBoxAcao.Name = "comboBoxAcao";
            comboBoxAcao.Size = new Size(156, 28);
            comboBoxAcao.TabIndex = 6;
            // 
            // labelAcao
            // 
            labelAcao.AutoSize = true;
            labelAcao.Location = new Point(7, 117);
            labelAcao.Name = "labelAcao";
            labelAcao.Size = new Size(46, 20);
            labelAcao.TabIndex = 5;
            labelAcao.Text = "Ação:";
            // 
            // labelTarefaExemplo
            // 
            labelTarefaExemplo.AutoSize = true;
            labelTarefaExemplo.Location = new Point(232, 79);
            labelTarefaExemplo.Name = "labelTarefaExemplo";
            labelTarefaExemplo.Size = new Size(71, 20);
            labelTarefaExemplo.TabIndex = 4;
            labelTarefaExemplo.Text = "Ex. 22650";
            // 
            // textBoxTarefa
            // 
            textBoxTarefa.Location = new Point(69, 68);
            textBoxTarefa.Margin = new Padding(3, 4, 3, 4);
            textBoxTarefa.Name = "textBoxTarefa";
            textBoxTarefa.Size = new Size(156, 27);
            textBoxTarefa.TabIndex = 3;
            // 
            // labelTarefa
            // 
            labelTarefa.AutoSize = true;
            labelTarefa.Location = new Point(7, 79);
            labelTarefa.Name = "labelTarefa";
            labelTarefa.Size = new Size(52, 20);
            labelTarefa.TabIndex = 2;
            labelTarefa.Text = "Tarefa:";
            // 
            // comboBoxLinha
            // 
            comboBoxLinha.FormattingEnabled = true;
            comboBoxLinha.Location = new Point(69, 29);
            comboBoxLinha.Margin = new Padding(3, 4, 3, 4);
            comboBoxLinha.Name = "comboBoxLinha";
            comboBoxLinha.Size = new Size(156, 28);
            comboBoxLinha.TabIndex = 1;
            comboBoxLinha.SelectedIndexChanged += comboBoxLinha_SelectedIndexChanged;
            comboBoxLinha.KeyDown += comboBoxLinha_KeyDown;
            // 
            // labelLinha
            // 
            labelLinha.AutoSize = true;
            labelLinha.Location = new Point(7, 40);
            labelLinha.Name = "labelLinha";
            labelLinha.Size = new Size(47, 20);
            labelLinha.TabIndex = 0;
            labelLinha.Text = "Linha:";
            // 
            // labelMensagemLog
            // 
            labelMensagemLog.AutoSize = true;
            labelMensagemLog.Location = new Point(14, 560);
            labelMensagemLog.Name = "labelMensagemLog";
            labelMensagemLog.Size = new Size(0, 20);
            labelMensagemLog.TabIndex = 4;
            // 
            // timerMensagemLog
            // 
            timerMensagemLog.Enabled = true;
            timerMensagemLog.Interval = 1000;
            timerMensagemLog.Tick += timerMensagemLog_Tick;
            // 
            // ApontamentoForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(912, 589);
            Controls.Add(labelMensagemLog);
            Controls.Add(GroupBoxPreview);
            Controls.Add(DatePickerDataApontamento);
            Controls.Add(groupBoxSalvar);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 4, 3, 4);
            MaximumSize = new Size(930, 636);
            MinimumSize = new Size(930, 636);
            Name = "ApontamentoForm";
            Text = "Apontamento de horas";
            Activated += ApontamentoForm_Activated;
            Load += ApontamentoForm_Load;
            GroupBoxPreview.ResumeLayout(false);
            GroupBoxPreview.PerformLayout();
            groupBoxSalvar.ResumeLayout(false);
            groupBoxSalvar.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DateTimePicker DatePickerDataApontamento;
        private GroupBox GroupBoxPreview;
        private Label labelPreview;
        private GroupBox groupBoxSalvar;
        private Label labelTarefaExemplo;
        private TextBox textBoxTarefa;
        private Label labelTarefa;
        private ComboBox comboBoxLinha;
        private Label labelLinha;
        private Button btnSalvar;
        private Label labelTempoExemplo;
        private MaskedTextBox maskedTextBoxHoras;
        private Label labelTempo;
        private ComboBox comboBoxAcao;
        private Label labelAcao;
        private Button btnCopiar;
        private Label labelMensagemLog;
        public System.Windows.Forms.Timer timerMensagemLog;
    }
}