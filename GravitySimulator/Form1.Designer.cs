namespace GravitySimulator
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.arquivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.novoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salvarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.criarNovoCorpoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.asdasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ColorTB = new System.Windows.Forms.ToolStripTextBox();
            this.RadiusTB = new System.Windows.Forms.ToolStripTextBox();
            this.MassTB = new System.Windows.Forms.ToolStripTextBox();
            this.SpeedxTB = new System.Windows.Forms.ToolStripTextBox();
            this.SpeedyTB = new System.Windows.Forms.ToolStripTextBox();
            this.ConfirmButton = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ColorMod = new System.Windows.Forms.ToolStripTextBox();
            this.RadiusMod = new System.Windows.Forms.ToolStripTextBox();
            this.MassMod = new System.Windows.Forms.ToolStripTextBox();
            this.SpeedxMod = new System.Windows.Forms.ToolStripTextBox();
            this.SpeedyMod = new System.Windows.Forms.ToolStripTextBox();
            this.ConfirmMod = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.arquivoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // arquivoToolStripMenuItem
            // 
            this.arquivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abrirToolStripMenuItem,
            this.novoToolStripMenuItem,
            this.salvarToolStripMenuItem});
            this.arquivoToolStripMenuItem.Name = "arquivoToolStripMenuItem";
            this.arquivoToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.arquivoToolStripMenuItem.Text = "Arquivo";
            // 
            // abrirToolStripMenuItem
            // 
            this.abrirToolStripMenuItem.Name = "abrirToolStripMenuItem";
            this.abrirToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
            this.abrirToolStripMenuItem.Text = "Abrir";
            this.abrirToolStripMenuItem.Click += new System.EventHandler(this.abrirToolStripMenuItem_Click);
            // 
            // novoToolStripMenuItem
            // 
            this.novoToolStripMenuItem.Name = "novoToolStripMenuItem";
            this.novoToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
            this.novoToolStripMenuItem.Text = "Novo";
            this.novoToolStripMenuItem.Click += new System.EventHandler(this.novoToolStripMenuItem_Click);
            // 
            // salvarToolStripMenuItem
            // 
            this.salvarToolStripMenuItem.Name = "salvarToolStripMenuItem";
            this.salvarToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
            this.salvarToolStripMenuItem.Text = "Salvar";
            this.salvarToolStripMenuItem.Click += new System.EventHandler(this.salvarToolStripMenuItem_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.criarNovoCorpoToolStripMenuItem,
            this.modificarToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(166, 48);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // criarNovoCorpoToolStripMenuItem
            // 
            this.criarNovoCorpoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.asdasToolStripMenuItem,
            this.ColorTB,
            this.RadiusTB,
            this.MassTB,
            this.SpeedxTB,
            this.SpeedyTB,
            this.ConfirmButton});
            this.criarNovoCorpoToolStripMenuItem.Name = "criarNovoCorpoToolStripMenuItem";
            this.criarNovoCorpoToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.criarNovoCorpoToolStripMenuItem.Text = "Criar novo Corpo";
            this.criarNovoCorpoToolStripMenuItem.Click += new System.EventHandler(this.criarNovoCorpoToolStripMenuItem_Click);
            // 
            // asdasToolStripMenuItem
            // 
            this.asdasToolStripMenuItem.Name = "asdasToolStripMenuItem";
            this.asdasToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.asdasToolStripMenuItem.Text = "Caracteristicas do corpo";
            // 
            // ColorTB
            // 
            this.ColorTB.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ColorTB.Name = "ColorTB";
            this.ColorTB.Size = new System.Drawing.Size(100, 23);
            this.ColorTB.ToolTipText = "Color";
            // 
            // RadiusTB
            // 
            this.RadiusTB.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.RadiusTB.Name = "RadiusTB";
            this.RadiusTB.Size = new System.Drawing.Size(100, 23);
            this.RadiusTB.ToolTipText = "Radius";
            // 
            // MassTB
            // 
            this.MassTB.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MassTB.Name = "MassTB";
            this.MassTB.Size = new System.Drawing.Size(100, 23);
            this.MassTB.ToolTipText = "Mass";
            // 
            // SpeedxTB
            // 
            this.SpeedxTB.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.SpeedxTB.Name = "SpeedxTB";
            this.SpeedxTB.Size = new System.Drawing.Size(100, 23);
            this.SpeedxTB.ToolTipText = "Speed X";
            // 
            // SpeedyTB
            // 
            this.SpeedyTB.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.SpeedyTB.Name = "SpeedyTB";
            this.SpeedyTB.Size = new System.Drawing.Size(100, 23);
            this.SpeedyTB.ToolTipText = "Speed y";
            // 
            // ConfirmButton
            // 
            this.ConfirmButton.Name = "ConfirmButton";
            this.ConfirmButton.Size = new System.Drawing.Size(201, 22);
            this.ConfirmButton.Text = "Confirmar";
            this.ConfirmButton.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // modificarToolStripMenuItem
            // 
            this.modificarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.ColorMod,
            this.RadiusMod,
            this.MassMod,
            this.SpeedxMod,
            this.SpeedyMod,
            this.ConfirmMod});
            this.modificarToolStripMenuItem.Name = "modificarToolStripMenuItem";
            this.modificarToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.modificarToolStripMenuItem.Text = "Modificar";
            this.modificarToolStripMenuItem.Click += new System.EventHandler(this.modificarToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(201, 22);
            this.toolStripMenuItem1.Text = "Caracteristicas do corpo";
            // 
            // ColorMod
            // 
            this.ColorMod.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ColorMod.Name = "ColorMod";
            this.ColorMod.Size = new System.Drawing.Size(100, 23);
            // 
            // RadiusMod
            // 
            this.RadiusMod.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.RadiusMod.Name = "RadiusMod";
            this.RadiusMod.Size = new System.Drawing.Size(100, 23);
            // 
            // MassMod
            // 
            this.MassMod.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MassMod.Name = "MassMod";
            this.MassMod.Size = new System.Drawing.Size(100, 23);
            // 
            // SpeedxMod
            // 
            this.SpeedxMod.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.SpeedxMod.Name = "SpeedxMod";
            this.SpeedxMod.Size = new System.Drawing.Size(100, 23);
            // 
            // SpeedyMod
            // 
            this.SpeedyMod.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.SpeedyMod.Name = "SpeedyMod";
            this.SpeedyMod.Size = new System.Drawing.Size(100, 23);
            // 
            // ConfirmMod
            // 
            this.ConfirmMod.Name = "ConfirmMod";
            this.ConfirmMod.Size = new System.Drawing.Size(201, 22);
            this.ConfirmMod.Text = "Confirm";
            this.ConfirmMod.Click += new System.EventHandler(this.ConfirmMod_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem arquivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abrirToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem criarNovoCorpoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem asdasToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox ColorTB;
        private System.Windows.Forms.ToolStripTextBox RadiusTB;
        private System.Windows.Forms.ToolStripTextBox MassTB;
        private System.Windows.Forms.ToolStripTextBox SpeedxTB;
        private System.Windows.Forms.ToolStripTextBox SpeedyTB;
        private System.Windows.Forms.ToolStripMenuItem ConfirmButton;
        private System.Windows.Forms.ToolStripMenuItem novoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salvarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modificarToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox ColorMod;
        private System.Windows.Forms.ToolStripTextBox RadiusMod;
        private System.Windows.Forms.ToolStripTextBox MassMod;
        private System.Windows.Forms.ToolStripTextBox SpeedxMod;
        private System.Windows.Forms.ToolStripTextBox SpeedyMod;
        private System.Windows.Forms.ToolStripMenuItem ConfirmMod;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
    }
}

