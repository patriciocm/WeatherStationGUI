namespace pgp
{
    partial class VentanaProduccion
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VentanaProduccion));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disconnectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.exportDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.printSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.preferencesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configStationDateTimeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetVolumenAcumuladoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.serialPort = new System.IO.Ports.SerialPort(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timerConectado = new System.Windows.Forms.Timer(this.components);
            this.wizardPagesGraficos = new pgp.WizardPages();
            this.tabDistribucionGotas = new System.Windows.Forms.TabPage();
            this.buttonLineStyleDG = new System.Windows.Forms.Button();
            this.buttonCustomTimeSettingsDG = new System.Windows.Forms.Button();
            this.buttonDefaultTimeSettingsDG = new System.Windows.Forms.Button();
            this.buttonGoBackDG = new System.Windows.Forms.Button();
            this.buttonGoForwardDG = new System.Windows.Forms.Button();
            this.buttonZoomInDG = new System.Windows.Forms.Button();
            this.buttonZoomOutDG = new System.Windows.Forms.Button();
            this.chartDistribucion = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabVolumenAcumulado = new System.Windows.Forms.TabPage();
            this.buttonImprimirVA = new System.Windows.Forms.Button();
            this.buttonLineStyleVA = new System.Windows.Forms.Button();
            this.buttonCustomTimeSettingsVA = new System.Windows.Forms.Button();
            this.buttonDefaultTimeSettingsVA = new System.Windows.Forms.Button();
            this.buttonGoBackVA = new System.Windows.Forms.Button();
            this.buttonGoForwardVA = new System.Windows.Forms.Button();
            this.buttonZoomInVA = new System.Windows.Forms.Button();
            this.buttonZoomOutVA = new System.Windows.Forms.Button();
            this.chartVolumenAcumulado = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabIntensidad = new System.Windows.Forms.TabPage();
            this.buttonImprimirI = new System.Windows.Forms.Button();
            this.buttonLineStyleI = new System.Windows.Forms.Button();
            this.buttonCustomTimeSettingsI = new System.Windows.Forms.Button();
            this.buttonDefaultTimeSettingsI = new System.Windows.Forms.Button();
            this.buttonGoBackI = new System.Windows.Forms.Button();
            this.buttonGoForwardI = new System.Windows.Forms.Button();
            this.buttonZoomInI = new System.Windows.Forms.Button();
            this.buttonZoomOutI = new System.Windows.Forms.Button();
            this.chartIntensidad = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.wizardPagesControles = new pgp.WizardPages();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBoxUpdateTime = new System.Windows.Forms.GroupBox();
            this.comboBoxUpdateTime = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.progressBarHistorySincro = new System.Windows.Forms.ProgressBar();
            this.pictureBoxEstado = new System.Windows.Forms.PictureBox();
            this.labelEstado = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.labelTercerParametroValue = new System.Windows.Forms.Label();
            this.labelSegundoParametroValue = new System.Windows.Forms.Label();
            this.labelPrimerParametroValue = new System.Windows.Forms.Label();
            this.labelFechaFin = new System.Windows.Forms.Label();
            this.labelFechaInicio = new System.Windows.Forms.Label();
            this.labelTercerParametro = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.labelSegundoParametro = new System.Windows.Forms.Label();
            this.labelPrimerParametro = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboBoxGraficoSeleccionado = new System.Windows.Forms.ComboBox();
            this.groupBoxTimeSpan = new System.Windows.Forms.GroupBox();
            this.buttonRefreshCustomTimeSettings = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.datePickerFrom = new System.Windows.Forms.DateTimePicker();
            this.timePickerTo = new System.Windows.Forms.DateTimePicker();
            this.datePickerTo = new System.Windows.Forms.DateTimePicker();
            this.timePickerFrom = new System.Windows.Forms.DateTimePicker();
            this.menuStrip1.SuspendLayout();
            this.wizardPagesGraficos.SuspendLayout();
            this.tabDistribucionGotas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartDistribucion)).BeginInit();
            this.tabVolumenAcumulado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartVolumenAcumulado)).BeginInit();
            this.tabIntensidad.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartIntensidad)).BeginInit();
            this.wizardPagesControles.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBoxUpdateTime.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEstado)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBoxTimeSpan.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.preferencesToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(993, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectToolStripMenuItem,
            this.disconnectToolStripMenuItem,
            this.toolStripMenuItem3,
            this.exportDataToolStripMenuItem,
            this.toolStripMenuItem1,
            this.printSettingsToolStripMenuItem,
            this.printToolStripMenuItem,
            this.toolStripMenuItem2,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // connectToolStripMenuItem
            // 
            this.connectToolStripMenuItem.Name = "connectToolStripMenuItem";
            this.connectToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.connectToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.connectToolStripMenuItem.Text = "Connect";
            this.connectToolStripMenuItem.Click += new System.EventHandler(this.connectToolStripMenuItem_Click);
            // 
            // disconnectToolStripMenuItem
            // 
            this.disconnectToolStripMenuItem.Name = "disconnectToolStripMenuItem";
            this.disconnectToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.disconnectToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.disconnectToolStripMenuItem.Text = "Disconnect";
            this.disconnectToolStripMenuItem.Click += new System.EventHandler(this.disconnectToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(172, 6);
            // 
            // exportDataToolStripMenuItem
            // 
            this.exportDataToolStripMenuItem.Name = "exportDataToolStripMenuItem";
            this.exportDataToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.exportDataToolStripMenuItem.Text = "Export Data";
            this.exportDataToolStripMenuItem.Click += new System.EventHandler(this.exportDataToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(172, 6);
            // 
            // printSettingsToolStripMenuItem
            // 
            this.printSettingsToolStripMenuItem.Name = "printSettingsToolStripMenuItem";
            this.printSettingsToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.printSettingsToolStripMenuItem.Text = "Print";
            this.printSettingsToolStripMenuItem.Click += new System.EventHandler(this.printSettingsToolStripMenuItem_Click);
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            this.printToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.printToolStripMenuItem.Text = "Print Preview";
            this.printToolStripMenuItem.Click += new System.EventHandler(this.buttonImprimir_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(172, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // preferencesToolStripMenuItem
            // 
            this.preferencesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configStationDateTimeToolStripMenuItem,
            this.resetVolumenAcumuladoToolStripMenuItem,
            this.optionsToolStripMenuItem});
            this.preferencesToolStripMenuItem.Name = "preferencesToolStripMenuItem";
            this.preferencesToolStripMenuItem.Size = new System.Drawing.Size(80, 20);
            this.preferencesToolStripMenuItem.Text = "Preferences";
            // 
            // configStationDateTimeToolStripMenuItem
            // 
            this.configStationDateTimeToolStripMenuItem.Name = "configStationDateTimeToolStripMenuItem";
            this.configStationDateTimeToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.configStationDateTimeToolStripMenuItem.Text = "Config DateTime";
            this.configStationDateTimeToolStripMenuItem.Click += new System.EventHandler(this.configStationDateTimeToolStripMenuItem_Click);
            // 
            // resetVolumenAcumuladoToolStripMenuItem
            // 
            this.resetVolumenAcumuladoToolStripMenuItem.Name = "resetVolumenAcumuladoToolStripMenuItem";
            this.resetVolumenAcumuladoToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.resetVolumenAcumuladoToolStripMenuItem.Text = "Reset Volumen Acumulado";
            this.resetVolumenAcumuladoToolStripMenuItem.Click += new System.EventHandler(this.resetVolumenAcumuladoToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.optionsToolStripMenuItem.Text = "Options";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem1});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.aboutToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem1
            // 
            this.aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
            this.aboutToolStripMenuItem1.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem1.Text = "About";
            this.aboutToolStripMenuItem1.Click += new System.EventHandler(this.aboutToolStripMenuItem1_Click);
            // 
            // serialPort
            // 
            this.serialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort_DataReceived);
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timerConectado
            // 
            this.timerConectado.Interval = 10000;
            this.timerConectado.Tick += new System.EventHandler(this.timerConectado_Tick);
            // 
            // wizardPagesGraficos
            // 
            this.wizardPagesGraficos.Controls.Add(this.tabDistribucionGotas);
            this.wizardPagesGraficos.Controls.Add(this.tabVolumenAcumulado);
            this.wizardPagesGraficos.Controls.Add(this.tabIntensidad);
            this.wizardPagesGraficos.Location = new System.Drawing.Point(200, 27);
            this.wizardPagesGraficos.Name = "wizardPagesGraficos";
            this.wizardPagesGraficos.SelectedIndex = 0;
            this.wizardPagesGraficos.Size = new System.Drawing.Size(788, 553);
            this.wizardPagesGraficos.TabIndex = 2;
            // 
            // tabDistribucionGotas
            // 
            this.tabDistribucionGotas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabDistribucionGotas.Controls.Add(this.buttonLineStyleDG);
            this.tabDistribucionGotas.Controls.Add(this.buttonCustomTimeSettingsDG);
            this.tabDistribucionGotas.Controls.Add(this.buttonDefaultTimeSettingsDG);
            this.tabDistribucionGotas.Controls.Add(this.buttonGoBackDG);
            this.tabDistribucionGotas.Controls.Add(this.buttonGoForwardDG);
            this.tabDistribucionGotas.Controls.Add(this.buttonZoomInDG);
            this.tabDistribucionGotas.Controls.Add(this.buttonZoomOutDG);
            this.tabDistribucionGotas.Controls.Add(this.chartDistribucion);
            this.tabDistribucionGotas.Location = new System.Drawing.Point(4, 22);
            this.tabDistribucionGotas.Name = "tabDistribucionGotas";
            this.tabDistribucionGotas.Padding = new System.Windows.Forms.Padding(3);
            this.tabDistribucionGotas.Size = new System.Drawing.Size(780, 527);
            this.tabDistribucionGotas.TabIndex = 0;
            this.tabDistribucionGotas.Text = "Distribucion Gotas";
            this.tabDistribucionGotas.UseVisualStyleBackColor = true;
            // 
            // buttonLineStyleDG
            // 
            this.buttonLineStyleDG.BackgroundImage = global::pgp.Properties.Resources.Line_chart_icon;
            this.buttonLineStyleDG.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonLineStyleDG.FlatAppearance.BorderSize = 0;
            this.buttonLineStyleDG.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.buttonLineStyleDG.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLineStyleDG.Location = new System.Drawing.Point(391, 16);
            this.buttonLineStyleDG.Name = "buttonLineStyleDG";
            this.buttonLineStyleDG.Size = new System.Drawing.Size(41, 41);
            this.buttonLineStyleDG.TabIndex = 20;
            this.buttonLineStyleDG.UseVisualStyleBackColor = true;
            this.buttonLineStyleDG.MouseClick += new System.Windows.Forms.MouseEventHandler(this.buttonLineStyle_MouseClick);
            this.buttonLineStyleDG.MouseLeave += new System.EventHandler(this.buttonLineStyle_MouseLeave);
            this.buttonLineStyleDG.MouseHover += new System.EventHandler(this.buttonLineStyle_MouseHover);
            // 
            // buttonCustomTimeSettingsDG
            // 
            this.buttonCustomTimeSettingsDG.BackgroundImage = global::pgp.Properties.Resources._1393811025_preferences_system_time;
            this.buttonCustomTimeSettingsDG.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonCustomTimeSettingsDG.FlatAppearance.BorderSize = 0;
            this.buttonCustomTimeSettingsDG.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.buttonCustomTimeSettingsDG.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCustomTimeSettingsDG.Location = new System.Drawing.Point(130, 16);
            this.buttonCustomTimeSettingsDG.Name = "buttonCustomTimeSettingsDG";
            this.buttonCustomTimeSettingsDG.Size = new System.Drawing.Size(41, 41);
            this.buttonCustomTimeSettingsDG.TabIndex = 17;
            this.buttonCustomTimeSettingsDG.UseVisualStyleBackColor = true;
            this.buttonCustomTimeSettingsDG.MouseClick += new System.Windows.Forms.MouseEventHandler(this.buttonCustomTimeSettings_MouseClick);
            this.buttonCustomTimeSettingsDG.MouseLeave += new System.EventHandler(this.buttonCustomTimeSettings_MouseLeave);
            this.buttonCustomTimeSettingsDG.MouseHover += new System.EventHandler(this.buttonCustomTimeSettings_MouseHover);
            // 
            // buttonDefaultTimeSettingsDG
            // 
            this.buttonDefaultTimeSettingsDG.BackgroundImage = global::pgp.Properties.Resources._1393810740_Redo;
            this.buttonDefaultTimeSettingsDG.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonDefaultTimeSettingsDG.FlatAppearance.BorderSize = 0;
            this.buttonDefaultTimeSettingsDG.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.buttonDefaultTimeSettingsDG.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDefaultTimeSettingsDG.Location = new System.Drawing.Point(70, 19);
            this.buttonDefaultTimeSettingsDG.Name = "buttonDefaultTimeSettingsDG";
            this.buttonDefaultTimeSettingsDG.Size = new System.Drawing.Size(41, 41);
            this.buttonDefaultTimeSettingsDG.TabIndex = 16;
            this.buttonDefaultTimeSettingsDG.UseVisualStyleBackColor = true;
            this.buttonDefaultTimeSettingsDG.MouseClick += new System.Windows.Forms.MouseEventHandler(this.buttonDefaultTimeSettings_MouseClick);
            this.buttonDefaultTimeSettingsDG.MouseLeave += new System.EventHandler(this.buttonDefaultTimeSettings_MouseLeave);
            this.buttonDefaultTimeSettingsDG.MouseHover += new System.EventHandler(this.buttonDefaultTimeSettings_MouseHover);
            // 
            // buttonGoBackDG
            // 
            this.buttonGoBackDG.BackgroundImage = global::pgp.Properties.Resources.arrow_left_icon1;
            this.buttonGoBackDG.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonGoBackDG.FlatAppearance.BorderSize = 0;
            this.buttonGoBackDG.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.buttonGoBackDG.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGoBackDG.Location = new System.Drawing.Point(185, 16);
            this.buttonGoBackDG.Name = "buttonGoBackDG";
            this.buttonGoBackDG.Size = new System.Drawing.Size(41, 41);
            this.buttonGoBackDG.TabIndex = 15;
            this.buttonGoBackDG.UseVisualStyleBackColor = true;
            this.buttonGoBackDG.MouseClick += new System.Windows.Forms.MouseEventHandler(this.buttonGoBack_MouseClick);
            this.buttonGoBackDG.MouseLeave += new System.EventHandler(this.buttonGoBack_MouseLeave);
            this.buttonGoBackDG.MouseHover += new System.EventHandler(this.buttonGoBack_MouseHover);
            // 
            // buttonGoForwardDG
            // 
            this.buttonGoForwardDG.BackgroundImage = global::pgp.Properties.Resources.arrow_right_icon;
            this.buttonGoForwardDG.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonGoForwardDG.FlatAppearance.BorderSize = 0;
            this.buttonGoForwardDG.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.buttonGoForwardDG.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGoForwardDG.Location = new System.Drawing.Point(232, 16);
            this.buttonGoForwardDG.Name = "buttonGoForwardDG";
            this.buttonGoForwardDG.Size = new System.Drawing.Size(41, 41);
            this.buttonGoForwardDG.TabIndex = 14;
            this.buttonGoForwardDG.UseVisualStyleBackColor = true;
            this.buttonGoForwardDG.MouseClick += new System.Windows.Forms.MouseEventHandler(this.buttonGoForward_MouseClick);
            this.buttonGoForwardDG.MouseLeave += new System.EventHandler(this.buttonGoForward_MouseLeave);
            this.buttonGoForwardDG.MouseHover += new System.EventHandler(this.buttonGoForward_MouseHover);
            // 
            // buttonZoomInDG
            // 
            this.buttonZoomInDG.BackgroundImage = global::pgp.Properties.Resources.Zoom_In_icon;
            this.buttonZoomInDG.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonZoomInDG.FlatAppearance.BorderSize = 0;
            this.buttonZoomInDG.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.buttonZoomInDG.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonZoomInDG.Location = new System.Drawing.Point(285, 16);
            this.buttonZoomInDG.Name = "buttonZoomInDG";
            this.buttonZoomInDG.Size = new System.Drawing.Size(41, 41);
            this.buttonZoomInDG.TabIndex = 13;
            this.buttonZoomInDG.UseVisualStyleBackColor = true;
            this.buttonZoomInDG.MouseClick += new System.Windows.Forms.MouseEventHandler(this.buttonZoomIn_MouseClick);
            this.buttonZoomInDG.MouseLeave += new System.EventHandler(this.buttonZoomIn_MouseLeave);
            this.buttonZoomInDG.MouseHover += new System.EventHandler(this.buttonZoomIn_MouseHover);
            // 
            // buttonZoomOutDG
            // 
            this.buttonZoomOutDG.BackgroundImage = global::pgp.Properties.Resources.Zoom_Out_icon;
            this.buttonZoomOutDG.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonZoomOutDG.FlatAppearance.BorderSize = 0;
            this.buttonZoomOutDG.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.buttonZoomOutDG.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonZoomOutDG.Location = new System.Drawing.Point(332, 16);
            this.buttonZoomOutDG.Name = "buttonZoomOutDG";
            this.buttonZoomOutDG.Size = new System.Drawing.Size(41, 41);
            this.buttonZoomOutDG.TabIndex = 12;
            this.buttonZoomOutDG.UseVisualStyleBackColor = true;
            this.buttonZoomOutDG.MouseClick += new System.Windows.Forms.MouseEventHandler(this.buttonZoomOut_MouseClick);
            this.buttonZoomOutDG.MouseLeave += new System.EventHandler(this.buttonZoomOut_MouseLeave);
            this.buttonZoomOutDG.MouseHover += new System.EventHandler(this.buttonZoomOut_MouseHover);
            // 
            // chartDistribucion
            // 
            chartArea1.Name = "ChartArea1";
            this.chartDistribucion.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartDistribucion.Legends.Add(legend1);
            this.chartDistribucion.Location = new System.Drawing.Point(-22, 59);
            this.chartDistribucion.Name = "chartDistribucion";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            series1.Legend = "Legend1";
            series1.Name = "Distribucion Gotas";
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            this.chartDistribucion.Series.Add(series1);
            this.chartDistribucion.Size = new System.Drawing.Size(760, 490);
            this.chartDistribucion.TabIndex = 1;
            this.chartDistribucion.Text = "chartDistribucion";
            this.chartDistribucion.Click += new System.EventHandler(this.buttonZoomIn_MouseClick);
            this.chartDistribucion.DoubleClick += new System.EventHandler(this.buttonZoomOut_MouseClick);
            // 
            // tabVolumenAcumulado
            // 
            this.tabVolumenAcumulado.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabVolumenAcumulado.Controls.Add(this.buttonImprimirVA);
            this.tabVolumenAcumulado.Controls.Add(this.buttonLineStyleVA);
            this.tabVolumenAcumulado.Controls.Add(this.buttonCustomTimeSettingsVA);
            this.tabVolumenAcumulado.Controls.Add(this.buttonDefaultTimeSettingsVA);
            this.tabVolumenAcumulado.Controls.Add(this.buttonGoBackVA);
            this.tabVolumenAcumulado.Controls.Add(this.buttonGoForwardVA);
            this.tabVolumenAcumulado.Controls.Add(this.buttonZoomInVA);
            this.tabVolumenAcumulado.Controls.Add(this.buttonZoomOutVA);
            this.tabVolumenAcumulado.Controls.Add(this.chartVolumenAcumulado);
            this.tabVolumenAcumulado.Location = new System.Drawing.Point(4, 22);
            this.tabVolumenAcumulado.Name = "tabVolumenAcumulado";
            this.tabVolumenAcumulado.Padding = new System.Windows.Forms.Padding(3);
            this.tabVolumenAcumulado.Size = new System.Drawing.Size(780, 527);
            this.tabVolumenAcumulado.TabIndex = 1;
            this.tabVolumenAcumulado.Text = "Volumen Acumulado";
            this.tabVolumenAcumulado.UseVisualStyleBackColor = true;
            // 
            // buttonImprimirVA
            // 
            this.buttonImprimirVA.BackgroundImage = global::pgp.Properties.Resources._1404704830_document_print_preview1;
            this.buttonImprimirVA.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonImprimirVA.FlatAppearance.BorderSize = 0;
            this.buttonImprimirVA.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.buttonImprimirVA.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonImprimirVA.Location = new System.Drawing.Point(447, 13);
            this.buttonImprimirVA.Name = "buttonImprimirVA";
            this.buttonImprimirVA.Size = new System.Drawing.Size(56, 44);
            this.buttonImprimirVA.TabIndex = 22;
            this.buttonImprimirVA.UseVisualStyleBackColor = true;
            this.buttonImprimirVA.Click += new System.EventHandler(this.buttonImprimir_Click);
            this.buttonImprimirVA.MouseLeave += new System.EventHandler(this.buttonImprimir_MouseLeave);
            this.buttonImprimirVA.MouseHover += new System.EventHandler(this.buttonImprimir_MouseHover);
            // 
            // buttonLineStyleVA
            // 
            this.buttonLineStyleVA.BackgroundImage = global::pgp.Properties.Resources.Line_chart_icon;
            this.buttonLineStyleVA.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonLineStyleVA.FlatAppearance.BorderSize = 0;
            this.buttonLineStyleVA.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.buttonLineStyleVA.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLineStyleVA.Location = new System.Drawing.Point(391, 16);
            this.buttonLineStyleVA.Name = "buttonLineStyleVA";
            this.buttonLineStyleVA.Size = new System.Drawing.Size(41, 41);
            this.buttonLineStyleVA.TabIndex = 19;
            this.buttonLineStyleVA.UseVisualStyleBackColor = true;
            this.buttonLineStyleVA.MouseClick += new System.Windows.Forms.MouseEventHandler(this.buttonLineStyle_MouseClick);
            this.buttonLineStyleVA.MouseLeave += new System.EventHandler(this.buttonLineStyle_MouseLeave);
            this.buttonLineStyleVA.MouseHover += new System.EventHandler(this.buttonLineStyle_MouseHover);
            // 
            // buttonCustomTimeSettingsVA
            // 
            this.buttonCustomTimeSettingsVA.BackgroundImage = global::pgp.Properties.Resources._1393811025_preferences_system_time;
            this.buttonCustomTimeSettingsVA.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonCustomTimeSettingsVA.FlatAppearance.BorderSize = 0;
            this.buttonCustomTimeSettingsVA.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.buttonCustomTimeSettingsVA.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCustomTimeSettingsVA.Location = new System.Drawing.Point(130, 16);
            this.buttonCustomTimeSettingsVA.Name = "buttonCustomTimeSettingsVA";
            this.buttonCustomTimeSettingsVA.Size = new System.Drawing.Size(41, 41);
            this.buttonCustomTimeSettingsVA.TabIndex = 11;
            this.buttonCustomTimeSettingsVA.UseVisualStyleBackColor = true;
            this.buttonCustomTimeSettingsVA.MouseClick += new System.Windows.Forms.MouseEventHandler(this.buttonCustomTimeSettings_MouseClick);
            this.buttonCustomTimeSettingsVA.MouseLeave += new System.EventHandler(this.buttonCustomTimeSettings_MouseLeave);
            this.buttonCustomTimeSettingsVA.MouseHover += new System.EventHandler(this.buttonCustomTimeSettings_MouseHover);
            // 
            // buttonDefaultTimeSettingsVA
            // 
            this.buttonDefaultTimeSettingsVA.BackgroundImage = global::pgp.Properties.Resources._1393810740_Redo;
            this.buttonDefaultTimeSettingsVA.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonDefaultTimeSettingsVA.FlatAppearance.BorderSize = 0;
            this.buttonDefaultTimeSettingsVA.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.buttonDefaultTimeSettingsVA.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDefaultTimeSettingsVA.Location = new System.Drawing.Point(70, 19);
            this.buttonDefaultTimeSettingsVA.Name = "buttonDefaultTimeSettingsVA";
            this.buttonDefaultTimeSettingsVA.Size = new System.Drawing.Size(41, 41);
            this.buttonDefaultTimeSettingsVA.TabIndex = 10;
            this.buttonDefaultTimeSettingsVA.UseVisualStyleBackColor = true;
            this.buttonDefaultTimeSettingsVA.MouseClick += new System.Windows.Forms.MouseEventHandler(this.buttonDefaultTimeSettings_MouseClick);
            this.buttonDefaultTimeSettingsVA.MouseLeave += new System.EventHandler(this.buttonDefaultTimeSettings_MouseLeave);
            this.buttonDefaultTimeSettingsVA.MouseHover += new System.EventHandler(this.buttonDefaultTimeSettings_MouseHover);
            // 
            // buttonGoBackVA
            // 
            this.buttonGoBackVA.BackgroundImage = global::pgp.Properties.Resources.arrow_left_icon1;
            this.buttonGoBackVA.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonGoBackVA.FlatAppearance.BorderSize = 0;
            this.buttonGoBackVA.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.buttonGoBackVA.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGoBackVA.Location = new System.Drawing.Point(185, 16);
            this.buttonGoBackVA.Name = "buttonGoBackVA";
            this.buttonGoBackVA.Size = new System.Drawing.Size(41, 41);
            this.buttonGoBackVA.TabIndex = 9;
            this.buttonGoBackVA.UseVisualStyleBackColor = true;
            this.buttonGoBackVA.MouseClick += new System.Windows.Forms.MouseEventHandler(this.buttonGoBack_MouseClick);
            this.buttonGoBackVA.MouseLeave += new System.EventHandler(this.buttonGoBack_MouseLeave);
            this.buttonGoBackVA.MouseHover += new System.EventHandler(this.buttonGoBack_MouseHover);
            // 
            // buttonGoForwardVA
            // 
            this.buttonGoForwardVA.BackgroundImage = global::pgp.Properties.Resources.arrow_right_icon;
            this.buttonGoForwardVA.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonGoForwardVA.FlatAppearance.BorderSize = 0;
            this.buttonGoForwardVA.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.buttonGoForwardVA.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGoForwardVA.Location = new System.Drawing.Point(232, 16);
            this.buttonGoForwardVA.Name = "buttonGoForwardVA";
            this.buttonGoForwardVA.Size = new System.Drawing.Size(41, 41);
            this.buttonGoForwardVA.TabIndex = 8;
            this.buttonGoForwardVA.UseVisualStyleBackColor = true;
            this.buttonGoForwardVA.MouseClick += new System.Windows.Forms.MouseEventHandler(this.buttonGoForward_MouseClick);
            this.buttonGoForwardVA.MouseLeave += new System.EventHandler(this.buttonGoForward_MouseLeave);
            this.buttonGoForwardVA.MouseHover += new System.EventHandler(this.buttonGoForward_MouseHover);
            // 
            // buttonZoomInVA
            // 
            this.buttonZoomInVA.BackgroundImage = global::pgp.Properties.Resources.Zoom_In_icon;
            this.buttonZoomInVA.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonZoomInVA.FlatAppearance.BorderSize = 0;
            this.buttonZoomInVA.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.buttonZoomInVA.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonZoomInVA.Location = new System.Drawing.Point(285, 16);
            this.buttonZoomInVA.Name = "buttonZoomInVA";
            this.buttonZoomInVA.Size = new System.Drawing.Size(41, 41);
            this.buttonZoomInVA.TabIndex = 7;
            this.buttonZoomInVA.UseVisualStyleBackColor = true;
            this.buttonZoomInVA.MouseClick += new System.Windows.Forms.MouseEventHandler(this.buttonZoomIn_MouseClick);
            this.buttonZoomInVA.MouseLeave += new System.EventHandler(this.buttonZoomIn_MouseLeave);
            this.buttonZoomInVA.MouseHover += new System.EventHandler(this.buttonZoomIn_MouseHover);
            // 
            // buttonZoomOutVA
            // 
            this.buttonZoomOutVA.BackgroundImage = global::pgp.Properties.Resources.Zoom_Out_icon;
            this.buttonZoomOutVA.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonZoomOutVA.FlatAppearance.BorderSize = 0;
            this.buttonZoomOutVA.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.buttonZoomOutVA.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonZoomOutVA.Location = new System.Drawing.Point(332, 16);
            this.buttonZoomOutVA.Name = "buttonZoomOutVA";
            this.buttonZoomOutVA.Size = new System.Drawing.Size(41, 41);
            this.buttonZoomOutVA.TabIndex = 5;
            this.buttonZoomOutVA.UseVisualStyleBackColor = true;
            this.buttonZoomOutVA.MouseClick += new System.Windows.Forms.MouseEventHandler(this.buttonZoomOut_MouseClick);
            this.buttonZoomOutVA.MouseLeave += new System.EventHandler(this.buttonZoomOut_MouseLeave);
            this.buttonZoomOutVA.MouseHover += new System.EventHandler(this.buttonZoomOut_MouseHover);
            // 
            // chartVolumenAcumulado
            // 
            this.chartVolumenAcumulado.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            chartArea2.Name = "ChartArea1";
            this.chartVolumenAcumulado.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartVolumenAcumulado.Legends.Add(legend2);
            this.chartVolumenAcumulado.Location = new System.Drawing.Point(-22, 59);
            this.chartVolumenAcumulado.Name = "chartVolumenAcumulado";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            series2.Legend = "Legend1";
            series2.Name = "Volumen Acumulado";
            series2.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            this.chartVolumenAcumulado.Series.Add(series2);
            this.chartVolumenAcumulado.Size = new System.Drawing.Size(760, 490);
            this.chartVolumenAcumulado.TabIndex = 0;
            this.chartVolumenAcumulado.Text = "chartVolumenAcumulado";
            // 
            // tabIntensidad
            // 
            this.tabIntensidad.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabIntensidad.Controls.Add(this.buttonImprimirI);
            this.tabIntensidad.Controls.Add(this.buttonLineStyleI);
            this.tabIntensidad.Controls.Add(this.buttonCustomTimeSettingsI);
            this.tabIntensidad.Controls.Add(this.buttonDefaultTimeSettingsI);
            this.tabIntensidad.Controls.Add(this.buttonGoBackI);
            this.tabIntensidad.Controls.Add(this.buttonGoForwardI);
            this.tabIntensidad.Controls.Add(this.buttonZoomInI);
            this.tabIntensidad.Controls.Add(this.buttonZoomOutI);
            this.tabIntensidad.Controls.Add(this.chartIntensidad);
            this.tabIntensidad.Location = new System.Drawing.Point(4, 22);
            this.tabIntensidad.Name = "tabIntensidad";
            this.tabIntensidad.Padding = new System.Windows.Forms.Padding(3);
            this.tabIntensidad.Size = new System.Drawing.Size(780, 527);
            this.tabIntensidad.TabIndex = 2;
            this.tabIntensidad.Text = "Intensidad";
            this.tabIntensidad.UseVisualStyleBackColor = true;
            // 
            // buttonImprimirI
            // 
            this.buttonImprimirI.BackgroundImage = global::pgp.Properties.Resources._1404704830_document_print_preview2;
            this.buttonImprimirI.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonImprimirI.FlatAppearance.BorderSize = 0;
            this.buttonImprimirI.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.buttonImprimirI.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonImprimirI.Location = new System.Drawing.Point(447, 13);
            this.buttonImprimirI.Name = "buttonImprimirI";
            this.buttonImprimirI.Size = new System.Drawing.Size(56, 44);
            this.buttonImprimirI.TabIndex = 23;
            this.buttonImprimirI.UseVisualStyleBackColor = true;
            this.buttonImprimirI.Click += new System.EventHandler(this.buttonImprimir_Click);
            this.buttonImprimirI.MouseLeave += new System.EventHandler(this.buttonImprimir_MouseLeave);
            this.buttonImprimirI.MouseHover += new System.EventHandler(this.buttonImprimir_MouseHover);
            // 
            // buttonLineStyleI
            // 
            this.buttonLineStyleI.BackgroundImage = global::pgp.Properties.Resources.Line_chart_icon;
            this.buttonLineStyleI.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonLineStyleI.FlatAppearance.BorderSize = 0;
            this.buttonLineStyleI.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.buttonLineStyleI.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLineStyleI.Location = new System.Drawing.Point(391, 16);
            this.buttonLineStyleI.Name = "buttonLineStyleI";
            this.buttonLineStyleI.Size = new System.Drawing.Size(41, 41);
            this.buttonLineStyleI.TabIndex = 20;
            this.buttonLineStyleI.UseVisualStyleBackColor = true;
            this.buttonLineStyleI.MouseClick += new System.Windows.Forms.MouseEventHandler(this.buttonLineStyle_MouseClick);
            this.buttonLineStyleI.MouseLeave += new System.EventHandler(this.buttonLineStyle_MouseLeave);
            this.buttonLineStyleI.MouseHover += new System.EventHandler(this.buttonLineStyle_MouseHover);
            // 
            // buttonCustomTimeSettingsI
            // 
            this.buttonCustomTimeSettingsI.BackgroundImage = global::pgp.Properties.Resources._1393811025_preferences_system_time;
            this.buttonCustomTimeSettingsI.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonCustomTimeSettingsI.FlatAppearance.BorderSize = 0;
            this.buttonCustomTimeSettingsI.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.buttonCustomTimeSettingsI.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCustomTimeSettingsI.Location = new System.Drawing.Point(130, 16);
            this.buttonCustomTimeSettingsI.Name = "buttonCustomTimeSettingsI";
            this.buttonCustomTimeSettingsI.Size = new System.Drawing.Size(41, 41);
            this.buttonCustomTimeSettingsI.TabIndex = 17;
            this.buttonCustomTimeSettingsI.UseVisualStyleBackColor = true;
            this.buttonCustomTimeSettingsI.MouseClick += new System.Windows.Forms.MouseEventHandler(this.buttonCustomTimeSettings_MouseClick);
            this.buttonCustomTimeSettingsI.MouseLeave += new System.EventHandler(this.buttonCustomTimeSettings_MouseLeave);
            this.buttonCustomTimeSettingsI.MouseHover += new System.EventHandler(this.buttonCustomTimeSettings_MouseHover);
            // 
            // buttonDefaultTimeSettingsI
            // 
            this.buttonDefaultTimeSettingsI.BackgroundImage = global::pgp.Properties.Resources._1393810740_Redo;
            this.buttonDefaultTimeSettingsI.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonDefaultTimeSettingsI.FlatAppearance.BorderSize = 0;
            this.buttonDefaultTimeSettingsI.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.buttonDefaultTimeSettingsI.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDefaultTimeSettingsI.Location = new System.Drawing.Point(70, 19);
            this.buttonDefaultTimeSettingsI.Name = "buttonDefaultTimeSettingsI";
            this.buttonDefaultTimeSettingsI.Size = new System.Drawing.Size(41, 41);
            this.buttonDefaultTimeSettingsI.TabIndex = 16;
            this.buttonDefaultTimeSettingsI.UseVisualStyleBackColor = true;
            this.buttonDefaultTimeSettingsI.MouseClick += new System.Windows.Forms.MouseEventHandler(this.buttonDefaultTimeSettings_MouseClick);
            this.buttonDefaultTimeSettingsI.MouseLeave += new System.EventHandler(this.buttonDefaultTimeSettings_MouseLeave);
            this.buttonDefaultTimeSettingsI.MouseHover += new System.EventHandler(this.buttonDefaultTimeSettings_MouseHover);
            // 
            // buttonGoBackI
            // 
            this.buttonGoBackI.BackgroundImage = global::pgp.Properties.Resources.arrow_left_icon1;
            this.buttonGoBackI.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonGoBackI.FlatAppearance.BorderSize = 0;
            this.buttonGoBackI.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.buttonGoBackI.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGoBackI.Location = new System.Drawing.Point(185, 16);
            this.buttonGoBackI.Name = "buttonGoBackI";
            this.buttonGoBackI.Size = new System.Drawing.Size(41, 41);
            this.buttonGoBackI.TabIndex = 15;
            this.buttonGoBackI.UseVisualStyleBackColor = true;
            this.buttonGoBackI.MouseClick += new System.Windows.Forms.MouseEventHandler(this.buttonGoBack_MouseClick);
            this.buttonGoBackI.MouseLeave += new System.EventHandler(this.buttonGoBack_MouseLeave);
            this.buttonGoBackI.MouseHover += new System.EventHandler(this.buttonGoBack_MouseHover);
            // 
            // buttonGoForwardI
            // 
            this.buttonGoForwardI.BackgroundImage = global::pgp.Properties.Resources.arrow_right_icon;
            this.buttonGoForwardI.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonGoForwardI.FlatAppearance.BorderSize = 0;
            this.buttonGoForwardI.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.buttonGoForwardI.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGoForwardI.Location = new System.Drawing.Point(232, 16);
            this.buttonGoForwardI.Name = "buttonGoForwardI";
            this.buttonGoForwardI.Size = new System.Drawing.Size(41, 41);
            this.buttonGoForwardI.TabIndex = 14;
            this.buttonGoForwardI.UseVisualStyleBackColor = true;
            this.buttonGoForwardI.MouseClick += new System.Windows.Forms.MouseEventHandler(this.buttonGoForward_MouseClick);
            this.buttonGoForwardI.MouseLeave += new System.EventHandler(this.buttonGoForward_MouseLeave);
            this.buttonGoForwardI.MouseHover += new System.EventHandler(this.buttonGoForward_MouseHover);
            // 
            // buttonZoomInI
            // 
            this.buttonZoomInI.BackgroundImage = global::pgp.Properties.Resources.Zoom_In_icon;
            this.buttonZoomInI.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonZoomInI.FlatAppearance.BorderSize = 0;
            this.buttonZoomInI.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.buttonZoomInI.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonZoomInI.Location = new System.Drawing.Point(285, 16);
            this.buttonZoomInI.Name = "buttonZoomInI";
            this.buttonZoomInI.Size = new System.Drawing.Size(41, 41);
            this.buttonZoomInI.TabIndex = 13;
            this.buttonZoomInI.UseVisualStyleBackColor = true;
            this.buttonZoomInI.MouseClick += new System.Windows.Forms.MouseEventHandler(this.buttonZoomIn_MouseClick);
            this.buttonZoomInI.MouseLeave += new System.EventHandler(this.buttonZoomIn_MouseLeave);
            this.buttonZoomInI.MouseHover += new System.EventHandler(this.buttonZoomIn_MouseHover);
            // 
            // buttonZoomOutI
            // 
            this.buttonZoomOutI.BackgroundImage = global::pgp.Properties.Resources.Zoom_Out_icon;
            this.buttonZoomOutI.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonZoomOutI.FlatAppearance.BorderSize = 0;
            this.buttonZoomOutI.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.buttonZoomOutI.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonZoomOutI.Location = new System.Drawing.Point(332, 16);
            this.buttonZoomOutI.Name = "buttonZoomOutI";
            this.buttonZoomOutI.Size = new System.Drawing.Size(41, 41);
            this.buttonZoomOutI.TabIndex = 12;
            this.buttonZoomOutI.UseVisualStyleBackColor = true;
            this.buttonZoomOutI.MouseClick += new System.Windows.Forms.MouseEventHandler(this.buttonZoomOut_MouseClick);
            this.buttonZoomOutI.MouseLeave += new System.EventHandler(this.buttonZoomOut_MouseLeave);
            this.buttonZoomOutI.MouseHover += new System.EventHandler(this.buttonZoomOut_MouseHover);
            // 
            // chartIntensidad
            // 
            chartArea3.Name = "ChartArea1";
            this.chartIntensidad.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chartIntensidad.Legends.Add(legend3);
            this.chartIntensidad.Location = new System.Drawing.Point(-22, 59);
            this.chartIntensidad.Name = "chartIntensidad";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series3.Legend = "Legend1";
            series3.Name = "Intensidad";
            series3.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            this.chartIntensidad.Series.Add(series3);
            this.chartIntensidad.Size = new System.Drawing.Size(760, 490);
            this.chartIntensidad.TabIndex = 0;
            this.chartIntensidad.Text = "chartIntensidad";
            // 
            // wizardPagesControles
            // 
            this.wizardPagesControles.Controls.Add(this.tabPage1);
            this.wizardPagesControles.Location = new System.Drawing.Point(0, 27);
            this.wizardPagesControles.Name = "wizardPagesControles";
            this.wizardPagesControles.SelectedIndex = 0;
            this.wizardPagesControles.Size = new System.Drawing.Size(201, 559);
            this.wizardPagesControles.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabPage1.Controls.Add(this.groupBoxUpdateTime);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBoxTimeSpan);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(193, 533);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBoxUpdateTime
            // 
            this.groupBoxUpdateTime.Controls.Add(this.comboBoxUpdateTime);
            this.groupBoxUpdateTime.Enabled = false;
            this.groupBoxUpdateTime.Location = new System.Drawing.Point(2, 150);
            this.groupBoxUpdateTime.Name = "groupBoxUpdateTime";
            this.groupBoxUpdateTime.Size = new System.Drawing.Size(192, 68);
            this.groupBoxUpdateTime.TabIndex = 14;
            this.groupBoxUpdateTime.TabStop = false;
            this.groupBoxUpdateTime.Text = "Update Time (s)";
            // 
            // comboBoxUpdateTime
            // 
            this.comboBoxUpdateTime.DisplayMember = "sa";
            this.comboBoxUpdateTime.FormattingEnabled = true;
            this.comboBoxUpdateTime.Items.AddRange(new object[] {
            "10",
            "30",
            "60",
            "120",
            "240"});
            this.comboBoxUpdateTime.Location = new System.Drawing.Point(5, 29);
            this.comboBoxUpdateTime.Name = "comboBoxUpdateTime";
            this.comboBoxUpdateTime.Size = new System.Drawing.Size(172, 21);
            this.comboBoxUpdateTime.TabIndex = 0;
            this.comboBoxUpdateTime.SelectedIndexChanged += new System.EventHandler(this.comboBoxUpdateTime_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.progressBarHistorySincro);
            this.groupBox1.Controls.Add(this.pictureBoxEstado);
            this.groupBox1.Controls.Add(this.labelEstado);
            this.groupBox1.Location = new System.Drawing.Point(2, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(191, 58);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Estado";
            // 
            // progressBarHistorySincro
            // 
            this.progressBarHistorySincro.Location = new System.Drawing.Point(48, 42);
            this.progressBarHistorySincro.Name = "progressBarHistorySincro";
            this.progressBarHistorySincro.Size = new System.Drawing.Size(137, 8);
            this.progressBarHistorySincro.Step = 60;
            this.progressBarHistorySincro.TabIndex = 1;
            this.progressBarHistorySincro.Visible = false;
            // 
            // pictureBoxEstado
            // 
            this.pictureBoxEstado.Image = global::pgp.Properties.Resources.red_notok_icon;
            this.pictureBoxEstado.Location = new System.Drawing.Point(6, 17);
            this.pictureBoxEstado.Name = "pictureBoxEstado";
            this.pictureBoxEstado.Size = new System.Drawing.Size(32, 35);
            this.pictureBoxEstado.TabIndex = 1;
            this.pictureBoxEstado.TabStop = false;
            // 
            // labelEstado
            // 
            this.labelEstado.Location = new System.Drawing.Point(44, 26);
            this.labelEstado.Name = "labelEstado";
            this.labelEstado.Size = new System.Drawing.Size(118, 24);
            this.labelEstado.TabIndex = 0;
            this.labelEstado.Text = "DESCONECTADO";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.labelTercerParametroValue);
            this.groupBox3.Controls.Add(this.labelSegundoParametroValue);
            this.groupBox3.Controls.Add(this.labelPrimerParametroValue);
            this.groupBox3.Controls.Add(this.labelFechaFin);
            this.groupBox3.Controls.Add(this.labelFechaInicio);
            this.groupBox3.Controls.Add(this.labelTercerParametro);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.labelSegundoParametro);
            this.groupBox3.Controls.Add(this.labelPrimerParametro);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Location = new System.Drawing.Point(2, 224);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(191, 128);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Estadisticas";
            // 
            // labelTercerParametroValue
            // 
            this.labelTercerParametroValue.AutoSize = true;
            this.labelTercerParametroValue.Location = new System.Drawing.Point(72, 102);
            this.labelTercerParametroValue.Name = "labelTercerParametroValue";
            this.labelTercerParametroValue.Size = new System.Drawing.Size(41, 13);
            this.labelTercerParametroValue.TabIndex = 9;
            this.labelTercerParametroValue.Text = "label12";
            // 
            // labelSegundoParametroValue
            // 
            this.labelSegundoParametroValue.AutoSize = true;
            this.labelSegundoParametroValue.Location = new System.Drawing.Point(72, 84);
            this.labelSegundoParametroValue.Name = "labelSegundoParametroValue";
            this.labelSegundoParametroValue.Size = new System.Drawing.Size(41, 13);
            this.labelSegundoParametroValue.TabIndex = 8;
            this.labelSegundoParametroValue.Text = "label11";
            // 
            // labelPrimerParametroValue
            // 
            this.labelPrimerParametroValue.AutoSize = true;
            this.labelPrimerParametroValue.Location = new System.Drawing.Point(72, 64);
            this.labelPrimerParametroValue.Name = "labelPrimerParametroValue";
            this.labelPrimerParametroValue.Size = new System.Drawing.Size(41, 13);
            this.labelPrimerParametroValue.TabIndex = 7;
            this.labelPrimerParametroValue.Text = "label10";
            // 
            // labelFechaFin
            // 
            this.labelFechaFin.AutoSize = true;
            this.labelFechaFin.Location = new System.Drawing.Point(72, 44);
            this.labelFechaFin.Name = "labelFechaFin";
            this.labelFechaFin.Size = new System.Drawing.Size(35, 13);
            this.labelFechaFin.TabIndex = 6;
            this.labelFechaFin.Text = "label9";
            // 
            // labelFechaInicio
            // 
            this.labelFechaInicio.AutoSize = true;
            this.labelFechaInicio.Location = new System.Drawing.Point(72, 24);
            this.labelFechaInicio.Name = "labelFechaInicio";
            this.labelFechaInicio.Size = new System.Drawing.Size(35, 13);
            this.labelFechaInicio.TabIndex = 5;
            this.labelFechaInicio.Text = "label8";
            // 
            // labelTercerParametro
            // 
            this.labelTercerParametro.Location = new System.Drawing.Point(4, 104);
            this.labelTercerParametro.Name = "labelTercerParametro";
            this.labelTercerParametro.Size = new System.Drawing.Size(79, 18);
            this.labelTercerParametro.TabIndex = 4;
            this.labelTercerParametro.Text = "Promedio: ";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(4, 44);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 18);
            this.label6.TabIndex = 3;
            this.label6.Text = "Fecha Fin: ";
            // 
            // labelSegundoParametro
            // 
            this.labelSegundoParametro.Location = new System.Drawing.Point(4, 84);
            this.labelSegundoParametro.Name = "labelSegundoParametro";
            this.labelSegundoParametro.Size = new System.Drawing.Size(79, 18);
            this.labelSegundoParametro.TabIndex = 2;
            this.labelSegundoParametro.Text = "Maximo: ";
            // 
            // labelPrimerParametro
            // 
            this.labelPrimerParametro.Location = new System.Drawing.Point(4, 64);
            this.labelPrimerParametro.Name = "labelPrimerParametro";
            this.labelPrimerParametro.Size = new System.Drawing.Size(159, 18);
            this.labelPrimerParametro.TabIndex = 1;
            this.labelPrimerParametro.Text = "Minimo: ";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(4, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fecha Inicio: ";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comboBoxGraficoSeleccionado);
            this.groupBox2.Location = new System.Drawing.Point(1, 71);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(192, 68);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Graph Selection";
            // 
            // comboBoxGraficoSeleccionado
            // 
            this.comboBoxGraficoSeleccionado.FormattingEnabled = true;
            this.comboBoxGraficoSeleccionado.Items.AddRange(new object[] {
            "Volumen Acumulado",
            "Intensidad"});
            this.comboBoxGraficoSeleccionado.Location = new System.Drawing.Point(5, 29);
            this.comboBoxGraficoSeleccionado.Name = "comboBoxGraficoSeleccionado";
            this.comboBoxGraficoSeleccionado.Size = new System.Drawing.Size(172, 21);
            this.comboBoxGraficoSeleccionado.TabIndex = 0;
            this.comboBoxGraficoSeleccionado.SelectedIndexChanged += new System.EventHandler(this.comboBoxGraficoSeleccionado_SelectedIndexChanged);
            // 
            // groupBoxTimeSpan
            // 
            this.groupBoxTimeSpan.Controls.Add(this.buttonRefreshCustomTimeSettings);
            this.groupBoxTimeSpan.Controls.Add(this.label3);
            this.groupBoxTimeSpan.Controls.Add(this.label2);
            this.groupBoxTimeSpan.Controls.Add(this.datePickerFrom);
            this.groupBoxTimeSpan.Controls.Add(this.timePickerTo);
            this.groupBoxTimeSpan.Controls.Add(this.datePickerTo);
            this.groupBoxTimeSpan.Controls.Add(this.timePickerFrom);
            this.groupBoxTimeSpan.Enabled = false;
            this.groupBoxTimeSpan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBoxTimeSpan.Location = new System.Drawing.Point(2, 358);
            this.groupBoxTimeSpan.Name = "groupBoxTimeSpan";
            this.groupBoxTimeSpan.Size = new System.Drawing.Size(191, 195);
            this.groupBoxTimeSpan.TabIndex = 12;
            this.groupBoxTimeSpan.TabStop = false;
            this.groupBoxTimeSpan.Text = "Time Span";
            // 
            // buttonRefreshCustomTimeSettings
            // 
            this.buttonRefreshCustomTimeSettings.BackgroundImage = global::pgp.Properties.Resources.blue_Refresh;
            this.buttonRefreshCustomTimeSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonRefreshCustomTimeSettings.FlatAppearance.BorderSize = 0;
            this.buttonRefreshCustomTimeSettings.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.buttonRefreshCustomTimeSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRefreshCustomTimeSettings.Location = new System.Drawing.Point(126, 151);
            this.buttonRefreshCustomTimeSettings.Name = "buttonRefreshCustomTimeSettings";
            this.buttonRefreshCustomTimeSettings.Size = new System.Drawing.Size(37, 37);
            this.buttonRefreshCustomTimeSettings.TabIndex = 12;
            this.buttonRefreshCustomTimeSettings.UseVisualStyleBackColor = true;
            this.buttonRefreshCustomTimeSettings.MouseClick += new System.Windows.Forms.MouseEventHandler(this.buttonRefreshCustomTimeSettings_MouseClick);
            this.buttonRefreshCustomTimeSettings.MouseLeave += new System.EventHandler(this.buttonRefreshCustomTimeSettings_MouseLeave);
            this.buttonRefreshCustomTimeSettings.MouseHover += new System.EventHandler(this.buttonRefreshCustomTimeSettings_MouseHover);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(2, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "To";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "From";
            // 
            // datePickerFrom
            // 
            this.datePickerFrom.Location = new System.Drawing.Point(3, 43);
            this.datePickerFrom.Name = "datePickerFrom";
            this.datePickerFrom.Size = new System.Drawing.Size(182, 20);
            this.datePickerFrom.TabIndex = 2;
            // 
            // timePickerTo
            // 
            this.timePickerTo.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.timePickerTo.Location = new System.Drawing.Point(3, 142);
            this.timePickerTo.Name = "timePickerTo";
            this.timePickerTo.ShowUpDown = true;
            this.timePickerTo.Size = new System.Drawing.Size(85, 20);
            this.timePickerTo.TabIndex = 6;
            // 
            // datePickerTo
            // 
            this.datePickerTo.Location = new System.Drawing.Point(3, 118);
            this.datePickerTo.Name = "datePickerTo";
            this.datePickerTo.Size = new System.Drawing.Size(182, 20);
            this.datePickerTo.TabIndex = 5;
            // 
            // timePickerFrom
            // 
            this.timePickerFrom.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.timePickerFrom.Location = new System.Drawing.Point(3, 67);
            this.timePickerFrom.Name = "timePickerFrom";
            this.timePickerFrom.ShowUpDown = true;
            this.timePickerFrom.Size = new System.Drawing.Size(85, 20);
            this.timePickerFrom.TabIndex = 7;
            // 
            // VentanaProduccion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(993, 587);
            this.Controls.Add(this.wizardPagesGraficos);
            this.Controls.Add(this.wizardPagesControles);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "VentanaProduccion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VentanaProduccion";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.VentanaProduccion_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.wizardPagesGraficos.ResumeLayout(false);
            this.tabDistribucionGotas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartDistribucion)).EndInit();
            this.tabVolumenAcumulado.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartVolumenAcumulado)).EndInit();
            this.tabIntensidad.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartIntensidad)).EndInit();
            this.wizardPagesControles.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBoxUpdateTime.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEstado)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBoxTimeSpan.ResumeLayout(false);
            this.groupBoxTimeSpan.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem preferencesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        public System.Windows.Forms.MenuStrip menuStrip1;
        public WizardPages wizardPagesGraficos;
        public System.Windows.Forms.TabPage tabDistribucionGotas;
        private System.Windows.Forms.ToolStripMenuItem connectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem disconnectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem1;
        public System.Windows.Forms.TabPage tabVolumenAcumulado;
        public System.Windows.Forms.TabPage tabIntensidad;
        public System.Windows.Forms.DataVisualization.Charting.Chart chartIntensidad;
        private System.IO.Ports.SerialPort serialPort;
        private System.Windows.Forms.ToolStripMenuItem configStationDateTimeToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        public System.Windows.Forms.DataVisualization.Charting.Chart chartVolumenAcumulado;
        public System.Windows.Forms.DataVisualization.Charting.Chart chartDistribucion;
        public System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBoxUpdateTime;
        public System.Windows.Forms.ComboBox comboBoxUpdateTime;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ProgressBar progressBarHistorySincro;
        private System.Windows.Forms.PictureBox pictureBoxEstado;
        private System.Windows.Forms.Label labelEstado;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.ComboBox comboBoxGraficoSeleccionado;
        private System.Windows.Forms.GroupBox groupBoxTimeSpan;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker datePickerFrom;
        private System.Windows.Forms.DateTimePicker timePickerTo;
        private System.Windows.Forms.DateTimePicker datePickerTo;
        private System.Windows.Forms.DateTimePicker timePickerFrom;
        public WizardPages wizardPagesControles;
        private System.Windows.Forms.Button buttonZoomOutVA;
        private System.Windows.Forms.Button buttonGoBackVA;
        private System.Windows.Forms.Button buttonGoForwardVA;
        private System.Windows.Forms.Button buttonZoomInVA;
        private System.Windows.Forms.Button buttonDefaultTimeSettingsVA;
        private System.Windows.Forms.Button buttonCustomTimeSettingsVA;
        private System.Windows.Forms.Button buttonRefreshCustomTimeSettings;
        private System.Windows.Forms.Button buttonCustomTimeSettingsDG;
        private System.Windows.Forms.Button buttonDefaultTimeSettingsDG;
        private System.Windows.Forms.Button buttonGoBackDG;
        private System.Windows.Forms.Button buttonGoForwardDG;
        private System.Windows.Forms.Button buttonZoomInDG;
        private System.Windows.Forms.Button buttonCustomTimeSettingsI;
        private System.Windows.Forms.Button buttonDefaultTimeSettingsI;
        private System.Windows.Forms.Button buttonGoBackI;
        private System.Windows.Forms.Button buttonGoForwardI;
        private System.Windows.Forms.Button buttonZoomInI;
        private System.Windows.Forms.Button buttonZoomOutI;
        private System.Windows.Forms.Button buttonZoomOutDG;
        private System.Windows.Forms.ToolStripMenuItem resetVolumenAcumuladoToolStripMenuItem;
        private System.Windows.Forms.Button buttonLineStyleVA;
        private System.Windows.Forms.Button buttonLineStyleDG;
        private System.Windows.Forms.Button buttonLineStyleI;
        private System.Windows.Forms.Label labelTercerParametro;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labelSegundoParametro;
        private System.Windows.Forms.Label labelPrimerParametro;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelTercerParametroValue;
        private System.Windows.Forms.Label labelSegundoParametroValue;
        private System.Windows.Forms.Label labelFechaFin;
        private System.Windows.Forms.Label labelFechaInicio;
        public System.Windows.Forms.Label labelPrimerParametroValue;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportDataToolStripMenuItem;
        private System.Windows.Forms.Button buttonImprimirVA;
        private System.Windows.Forms.Button buttonImprimirI;
        private System.Windows.Forms.ToolStripMenuItem printSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.Timer timerConectado;
    }
}