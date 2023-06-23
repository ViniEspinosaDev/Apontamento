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
            DatePickerDataApontamento = new DateTimePicker();
            GroupBoxPreview = new GroupBox();
            btnCopiar = new Button();
            labelPreview = new Label();
            groupBoxSalvar = new GroupBox();
            label1 = new Label();
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
            DatePickerDataApontamento.Location = new Point(12, 12);
            DatePickerDataApontamento.Name = "DatePickerDataApontamento";
            DatePickerDataApontamento.Size = new Size(338, 23);
            DatePickerDataApontamento.TabIndex = 0;
            DatePickerDataApontamento.ValueChanged += DatePickerDataApontamento_ValueChanged;
            // 
            // GroupBoxPreview
            // 
            GroupBoxPreview.Controls.Add(btnCopiar);
            GroupBoxPreview.Controls.Add(labelPreview);
            GroupBoxPreview.Location = new Point(416, 7);
            GroupBoxPreview.Name = "GroupBoxPreview";
            GroupBoxPreview.Size = new Size(372, 414);
            GroupBoxPreview.TabIndex = 1;
            GroupBoxPreview.TabStop = false;
            GroupBoxPreview.Text = "Preview";
            // 
            // btnCopiar
            // 
            btnCopiar.Location = new Point(291, 386);
            btnCopiar.Name = "btnCopiar";
            btnCopiar.Size = new Size(75, 23);
            btnCopiar.TabIndex = 4;
            btnCopiar.Text = "Copiar";
            btnCopiar.UseVisualStyleBackColor = true;
            btnCopiar.Click += btnCopiar_Click;
            // 
            // labelPreview
            // 
            labelPreview.AutoSize = true;
            labelPreview.Location = new Point(6, 19);
            labelPreview.MaximumSize = new Size(360, 390);
            labelPreview.MinimumSize = new Size(360, 390);
            labelPreview.Name = "labelPreview";
            labelPreview.Size = new Size(360, 390);
            labelPreview.TabIndex = 0;
            // 
            // groupBoxSalvar
            // 
            groupBoxSalvar.Controls.Add(label1);
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
            groupBoxSalvar.Location = new Point(12, 266);
            groupBoxSalvar.Name = "groupBoxSalvar";
            groupBoxSalvar.Size = new Size(398, 155);
            groupBoxSalvar.TabIndex = 3;
            groupBoxSalvar.TabStop = false;
            groupBoxSalvar.Text = "Editar horas";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 154);
            label1.Name = "label1";
            label1.Size = new Size(215, 15);
            label1.TabIndex = 12;
            label1.Text = "Insira todas as informações necessárias.";
            // 
            // btnSalvar
            // 
            btnSalvar.Location = new Point(317, 126);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(75, 23);
            btnSalvar.TabIndex = 11;
            btnSalvar.Text = "Salvar";
            btnSalvar.UseVisualStyleBackColor = true;
            btnSalvar.Click += btnSalvar_Click;
            // 
            // labelTempoExemplo
            // 
            labelTempoExemplo.AutoSize = true;
            labelTempoExemplo.Location = new Point(203, 117);
            labelTempoExemplo.Name = "labelTempoExemplo";
            labelTempoExemplo.Size = new Size(52, 15);
            labelTempoExemplo.TabIndex = 10;
            labelTempoExemplo.Text = "Ex. 06:30";
            // 
            // maskedTextBoxHoras
            // 
            maskedTextBoxHoras.Location = new Point(61, 109);
            maskedTextBoxHoras.Mask = "00:00";
            maskedTextBoxHoras.Name = "maskedTextBoxHoras";
            maskedTextBoxHoras.Size = new Size(136, 23);
            maskedTextBoxHoras.TabIndex = 9;
            maskedTextBoxHoras.ValidatingType = typeof(DateTime);
            // 
            // labelTempo
            // 
            labelTempo.AutoSize = true;
            labelTempo.Location = new Point(6, 117);
            labelTempo.Name = "labelTempo";
            labelTempo.Size = new Size(46, 15);
            labelTempo.TabIndex = 7;
            labelTempo.Text = "Tempo:";
            // 
            // comboBoxAcao
            // 
            comboBoxAcao.FormattingEnabled = true;
            comboBoxAcao.Location = new Point(60, 80);
            comboBoxAcao.Name = "comboBoxAcao";
            comboBoxAcao.Size = new Size(137, 23);
            comboBoxAcao.TabIndex = 6;
            // 
            // labelAcao
            // 
            labelAcao.AutoSize = true;
            labelAcao.Location = new Point(6, 88);
            labelAcao.Name = "labelAcao";
            labelAcao.Size = new Size(37, 15);
            labelAcao.TabIndex = 5;
            labelAcao.Text = "Ação:";
            // 
            // labelTarefaExemplo
            // 
            labelTarefaExemplo.AutoSize = true;
            labelTarefaExemplo.Location = new Point(203, 59);
            labelTarefaExemplo.Name = "labelTarefaExemplo";
            labelTarefaExemplo.Size = new Size(55, 15);
            labelTarefaExemplo.TabIndex = 4;
            labelTarefaExemplo.Text = "Ex. 22650";
            // 
            // textBoxTarefa
            // 
            textBoxTarefa.Location = new Point(60, 51);
            textBoxTarefa.Name = "textBoxTarefa";
            textBoxTarefa.Size = new Size(137, 23);
            textBoxTarefa.TabIndex = 3;
            // 
            // labelTarefa
            // 
            labelTarefa.AutoSize = true;
            labelTarefa.Location = new Point(6, 59);
            labelTarefa.Name = "labelTarefa";
            labelTarefa.Size = new Size(41, 15);
            labelTarefa.TabIndex = 2;
            labelTarefa.Text = "Tarefa:";
            // 
            // comboBoxLinha
            // 
            comboBoxLinha.FormattingEnabled = true;
            comboBoxLinha.Location = new Point(60, 22);
            comboBoxLinha.Name = "comboBoxLinha";
            comboBoxLinha.Size = new Size(137, 23);
            comboBoxLinha.TabIndex = 1;
            comboBoxLinha.SelectedIndexChanged += comboBoxLinha_SelectedIndexChanged;
            comboBoxLinha.KeyDown += comboBoxLinha_KeyDown;
            // 
            // labelLinha
            // 
            labelLinha.AutoSize = true;
            labelLinha.Location = new Point(6, 30);
            labelLinha.Name = "labelLinha";
            labelLinha.Size = new Size(39, 15);
            labelLinha.TabIndex = 0;
            labelLinha.Text = "Linha:";
            // 
            // labelMensagemLog
            // 
            labelMensagemLog.AutoSize = true;
            labelMensagemLog.Location = new Point(12, 426);
            labelMensagemLog.Name = "labelMensagemLog";
            labelMensagemLog.Size = new Size(0, 15);
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
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(labelMensagemLog);
            Controls.Add(groupBoxSalvar);
            Controls.Add(GroupBoxPreview);
            Controls.Add(DatePickerDataApontamento);
            MaximumSize = new Size(816, 489);
            MinimumSize = new Size(816, 489);
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
        private Label label1;
        private Label labelMensagemLog;
        public System.Windows.Forms.Timer timerMensagemLog;
    }
}