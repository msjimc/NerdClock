<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.p1 = New System.Windows.Forms.PictureBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ClockTypeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FibonacciToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MorseCodeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.p1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'p1
        '
        Me.p1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.p1.Location = New System.Drawing.Point(0, 27)
        Me.p1.Name = "p1"
        Me.p1.Size = New System.Drawing.Size(500, 282)
        Me.p1.TabIndex = 0
        Me.p1.TabStop = False
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'Timer2
        '
        Me.Timer2.Interval = 50
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ClockTypeToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(500, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ClockTypeToolStripMenuItem
        '
        Me.ClockTypeToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FibonacciToolStripMenuItem, Me.MorseCodeToolStripMenuItem})
        Me.ClockTypeToolStripMenuItem.Name = "ClockTypeToolStripMenuItem"
        Me.ClockTypeToolStripMenuItem.Size = New System.Drawing.Size(75, 20)
        Me.ClockTypeToolStripMenuItem.Text = "Clock type"
        '
        'FibonacciToolStripMenuItem
        '
        Me.FibonacciToolStripMenuItem.Checked = True
        Me.FibonacciToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.FibonacciToolStripMenuItem.Name = "FibonacciToolStripMenuItem"
        Me.FibonacciToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.FibonacciToolStripMenuItem.Text = "Fibonacci"
        '
        'MorseCodeToolStripMenuItem
        '
        Me.MorseCodeToolStripMenuItem.Name = "MorseCodeToolStripMenuItem"
        Me.MorseCodeToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.MorseCodeToolStripMenuItem.Text = "Morse code"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(500, 309)
        Me.Controls.Add(Me.p1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MinimumSize = New System.Drawing.Size(50, 39)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.p1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents p1 As System.Windows.Forms.PictureBox
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents Timer2 As System.Windows.Forms.Timer
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents ClockTypeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FibonacciToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MorseCodeToolStripMenuItem As ToolStripMenuItem
End Class
