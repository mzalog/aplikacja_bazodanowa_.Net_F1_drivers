namespace F1_standings
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            listBoxDrivers = new ListBox();
            txtYear = new TextBox();
            btnGetData = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            label1 = new Label();
            txtGivenName = new TextBox();
            txtFamilyName = new TextBox();
            txtDateOfBirth = new TextBox();
            txtNationality = new TextBox();
            btnAddDriver = new Button();
            txtDriverId = new TextBox();
            btnRemoveDriver = new Button();
            btnClearDatabase = new Button();
            txtSearch = new TextBox();
            btnFilter = new Button();
            cmbSort = new ComboBox();
            driverBindingSource = new BindingSource(components);
            Filtrowanie = new Label();
            ((System.ComponentModel.ISupportInitialize)driverBindingSource).BeginInit();
            SuspendLayout();
            // 
            // listBoxDrivers
            // 
            listBoxDrivers.FormattingEnabled = true;
            listBoxDrivers.ItemHeight = 15;
            listBoxDrivers.Location = new Point(35, 119);
            listBoxDrivers.Margin = new Padding(3, 2, 3, 2);
            listBoxDrivers.Name = "listBoxDrivers";
            listBoxDrivers.SelectionMode = SelectionMode.MultiExtended;
            listBoxDrivers.Size = new Size(651, 214);
            listBoxDrivers.TabIndex = 0;
            // 
            // txtYear
            // 
            txtYear.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 238);
            txtYear.Location = new Point(37, 42);
            txtYear.Margin = new Padding(3, 2, 3, 2);
            txtYear.Multiline = true;
            txtYear.Name = "txtYear";
            txtYear.Size = new Size(109, 30);
            txtYear.TabIndex = 1;
            // 
            // btnGetData
            // 
            btnGetData.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            btnGetData.Location = new Point(154, 39);
            btnGetData.Margin = new Padding(3, 2, 3, 2);
            btnGetData.Name = "btnGetData";
            btnGetData.Size = new Size(157, 33);
            btnGetData.TabIndex = 2;
            btnGetData.Text = "Pobierz dane";
            btnGetData.UseVisualStyleBackColor = true;
            btnGetData.Click += btnGetData_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label1.Location = new Point(35, 9);
            label1.Name = "label1";
            label1.Size = new Size(540, 25);
            label1.TabIndex = 3;
            label1.Text = "Wpisz rok z którego chcesz wyświetlić kierowców (1950 - 2023)";
            // 
            // txtGivenName
            // 
            txtGivenName.Location = new Point(37, 456);
            txtGivenName.Multiline = true;
            txtGivenName.Name = "txtGivenName";
            txtGivenName.Size = new Size(111, 23);
            txtGivenName.TabIndex = 4;
            txtGivenName.Text = "Imie";
            // 
            // txtFamilyName
            // 
            txtFamilyName.Location = new Point(154, 455);
            txtFamilyName.Multiline = true;
            txtFamilyName.Name = "txtFamilyName";
            txtFamilyName.Size = new Size(100, 23);
            txtFamilyName.TabIndex = 5;
            txtFamilyName.Text = "Nazwisko";
            // 
            // txtDateOfBirth
            // 
            txtDateOfBirth.Location = new Point(260, 455);
            txtDateOfBirth.Multiline = true;
            txtDateOfBirth.Name = "txtDateOfBirth";
            txtDateOfBirth.Size = new Size(100, 23);
            txtDateOfBirth.TabIndex = 6;
            txtDateOfBirth.Text = "Data urodzenia";
            // 
            // txtNationality
            // 
            txtNationality.Location = new Point(366, 455);
            txtNationality.Multiline = true;
            txtNationality.Name = "txtNationality";
            txtNationality.Size = new Size(100, 23);
            txtNationality.TabIndex = 7;
            txtNationality.Text = "Narodowość";
            // 
            // btnAddDriver
            // 
            btnAddDriver.Location = new Point(578, 454);
            btnAddDriver.Name = "btnAddDriver";
            btnAddDriver.Size = new Size(110, 24);
            btnAddDriver.TabIndex = 8;
            btnAddDriver.Text = "Dodaj kierowce";
            btnAddDriver.UseVisualStyleBackColor = true;
            btnAddDriver.Click += btnAddDriver_Click;
            // 
            // txtDriverId
            // 
            txtDriverId.Location = new Point(472, 455);
            txtDriverId.Multiline = true;
            txtDriverId.Name = "txtDriverId";
            txtDriverId.Size = new Size(100, 23);
            txtDriverId.TabIndex = 9;
            txtDriverId.Text = "driver Id";
            // 
            // btnRemoveDriver
            // 
            btnRemoveDriver.Location = new Point(498, 338);
            btnRemoveDriver.Name = "btnRemoveDriver";
            btnRemoveDriver.Size = new Size(186, 23);
            btnRemoveDriver.TabIndex = 10;
            btnRemoveDriver.Text = "Usuń zaznaczonego kierowce";
            btnRemoveDriver.UseVisualStyleBackColor = true;
            btnRemoveDriver.Click += btnRemoveDriver_Click;
            // 
            // btnClearDatabase
            // 
            btnClearDatabase.Location = new Point(502, 484);
            btnClearDatabase.Name = "btnClearDatabase";
            btnClearDatabase.Size = new Size(186, 23);
            btnClearDatabase.TabIndex = 11;
            btnClearDatabase.Text = "Wyczyść bazę danych kierowców";
            btnClearDatabase.UseVisualStyleBackColor = true;
            btnClearDatabase.Click += btnClearDatabase_Click;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(37, 394);
            txtSearch.Multiline = true;
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(124, 24);
            txtSearch.TabIndex = 12;
            // 
            // btnFilter
            // 
            btnFilter.Location = new Point(179, 395);
            btnFilter.Name = "btnFilter";
            btnFilter.Size = new Size(106, 23);
            btnFilter.TabIndex = 13;
            btnFilter.Text = "Filtruj";
            btnFilter.UseVisualStyleBackColor = true;
            btnFilter.Click += btnFilter_Click;
            // 
            // cmbSort
            // 
            cmbSort.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSort.FormattingEnabled = true;
            cmbSort.Items.AddRange(new object[] { "ID", "Imię", "Nazwisko", "Data urodzenia", "Narodowość" });
            cmbSort.Location = new Point(540, 91);
            cmbSort.Name = "cmbSort";
            cmbSort.Size = new Size(146, 23);
            cmbSort.TabIndex = 14;
            cmbSort.SelectedIndexChanged += cmbSort_SelectedIndexChanged;
            // 
            // driverBindingSource
            // 
            driverBindingSource.DataSource = typeof(Driver);
            // 
            // Filtrowanie
            // 
            Filtrowanie.AutoSize = true;
            Filtrowanie.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 238);
            Filtrowanie.ImageAlign = ContentAlignment.TopCenter;
            Filtrowanie.Location = new Point(35, 365);
            Filtrowanie.Name = "Filtrowanie";
            Filtrowanie.Size = new Size(324, 25);
            Filtrowanie.TabIndex = 15;
            Filtrowanie.Text = "Wpisz parametr jaki chcesz wyszukać";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(720, 595);
            Controls.Add(Filtrowanie);
            Controls.Add(cmbSort);
            Controls.Add(btnFilter);
            Controls.Add(txtSearch);
            Controls.Add(btnClearDatabase);
            Controls.Add(btnRemoveDriver);
            Controls.Add(txtDriverId);
            Controls.Add(btnAddDriver);
            Controls.Add(txtNationality);
            Controls.Add(txtDateOfBirth);
            Controls.Add(txtFamilyName);
            Controls.Add(txtGivenName);
            Controls.Add(label1);
            Controls.Add(btnGetData);
            Controls.Add(txtYear);
            Controls.Add(listBoxDrivers);
            Margin = new Padding(3, 2, 3, 2);
            Name = "MainForm";
            Text = "F1 Drivers";
            ((System.ComponentModel.ISupportInitialize)driverBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox listBoxDrivers;
        private TextBox txtYear;
        private Button btnGetData;
        private System.Windows.Forms.Timer timer1;
        private Label label1;
        private TextBox txtGivenName;
        private TextBox txtFamilyName;
        private TextBox txtDateOfBirth;
        private TextBox txtNationality;
        private Button btnAddDriver;
        private TextBox txtDriverId;
        private Button btnRemoveDriver;
        private Button btnClearDatabase;
        private TextBox txtSearch;
        private Button btnFilter;
        private ComboBox cmbSort;
        private Label Filtrowanie;
        private BindingSource driverBindingSource;
    }
}
