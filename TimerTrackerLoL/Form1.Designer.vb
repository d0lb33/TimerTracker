<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class InGameTracker
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.hint = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.SummSpell1 = New System.Windows.Forms.Label()
        Me.SummSpell2 = New System.Windows.Forms.Label()
        Me.SummSpell3 = New System.Windows.Forms.Label()
        Me.SummSpell4 = New System.Windows.Forms.Label()
        Me.SummSpell5 = New System.Windows.Forms.Label()
        Me.SummSpell6 = New System.Windows.Forms.Label()
        Me.Summ1SpellCounter = New System.Windows.Forms.Timer(Me.components)
        Me.Summ2SpellCounter = New System.Windows.Forms.Timer(Me.components)
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Summ3SpellCounter = New System.Windows.Forms.Timer(Me.components)
        Me.Summ4SpellCounter = New System.Windows.Forms.Timer(Me.components)
        Me.Summ5SpellCounter = New System.Windows.Forms.Timer(Me.components)
        Me.Summ6SpellCounter = New System.Windows.Forms.Timer(Me.components)
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Franklin Gothic Medium", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(111, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "League Timer Tracker"
        '
        'hint
        '
        Me.hint.AutoSize = True
        Me.hint.Font = New System.Drawing.Font("Franklin Gothic Medium", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.hint.Location = New System.Drawing.Point(0, 14)
        Me.hint.Name = "hint"
        Me.hint.Size = New System.Drawing.Size(297, 15)
        Me.hint.TabIndex = 1
        Me.hint.Text = "Say ""/n <ChampName> <Summoner Spell>"" To Start A Timer" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 500
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Controls.Add(Me.SummSpell1)
        Me.FlowLayoutPanel1.Controls.Add(Me.SummSpell2)
        Me.FlowLayoutPanel1.Controls.Add(Me.SummSpell3)
        Me.FlowLayoutPanel1.Controls.Add(Me.SummSpell4)
        Me.FlowLayoutPanel1.Controls.Add(Me.SummSpell5)
        Me.FlowLayoutPanel1.Controls.Add(Me.SummSpell6)
        Me.FlowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(1, 15)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(394, 115)
        Me.FlowLayoutPanel1.TabIndex = 2
        '
        'SummSpell1
        '
        Me.SummSpell1.AutoSize = True
        Me.SummSpell1.Font = New System.Drawing.Font("Franklin Gothic Medium", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SummSpell1.Location = New System.Drawing.Point(3, 0)
        Me.SummSpell1.Name = "SummSpell1"
        Me.SummSpell1.Size = New System.Drawing.Size(0, 15)
        Me.SummSpell1.TabIndex = 0
        '
        'SummSpell2
        '
        Me.SummSpell2.AutoSize = True
        Me.SummSpell2.Font = New System.Drawing.Font("Franklin Gothic Medium", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SummSpell2.Location = New System.Drawing.Point(3, 15)
        Me.SummSpell2.Name = "SummSpell2"
        Me.SummSpell2.Size = New System.Drawing.Size(0, 15)
        Me.SummSpell2.TabIndex = 1
        '
        'SummSpell3
        '
        Me.SummSpell3.AutoSize = True
        Me.SummSpell3.Font = New System.Drawing.Font("Franklin Gothic Medium", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SummSpell3.Location = New System.Drawing.Point(3, 30)
        Me.SummSpell3.Name = "SummSpell3"
        Me.SummSpell3.Size = New System.Drawing.Size(0, 15)
        Me.SummSpell3.TabIndex = 2
        '
        'SummSpell4
        '
        Me.SummSpell4.AutoSize = True
        Me.SummSpell4.Font = New System.Drawing.Font("Franklin Gothic Medium", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SummSpell4.Location = New System.Drawing.Point(3, 45)
        Me.SummSpell4.Name = "SummSpell4"
        Me.SummSpell4.Size = New System.Drawing.Size(0, 15)
        Me.SummSpell4.TabIndex = 3
        '
        'SummSpell5
        '
        Me.SummSpell5.AutoSize = True
        Me.SummSpell5.Font = New System.Drawing.Font("Franklin Gothic Medium", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SummSpell5.Location = New System.Drawing.Point(3, 60)
        Me.SummSpell5.Name = "SummSpell5"
        Me.SummSpell5.Size = New System.Drawing.Size(0, 15)
        Me.SummSpell5.TabIndex = 4
        '
        'SummSpell6
        '
        Me.SummSpell6.AutoSize = True
        Me.SummSpell6.Font = New System.Drawing.Font("Franklin Gothic Medium", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SummSpell6.Location = New System.Drawing.Point(3, 75)
        Me.SummSpell6.Name = "SummSpell6"
        Me.SummSpell6.Size = New System.Drawing.Size(0, 15)
        Me.SummSpell6.TabIndex = 5
        '
        'Summ1SpellCounter
        '
        Me.Summ1SpellCounter.Interval = 1000
        '
        'Summ2SpellCounter
        '
        Me.Summ2SpellCounter.Interval = 1000
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 148)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(0, 13)
        Me.Label3.TabIndex = 3
        '
        'Summ3SpellCounter
        '
        Me.Summ3SpellCounter.Interval = 1000
        '
        'Summ4SpellCounter
        '
        Me.Summ4SpellCounter.Interval = 1000
        '
        'Summ5SpellCounter
        '
        Me.Summ5SpellCounter.Interval = 1000
        '
        'Summ6SpellCounter
        '
        Me.Summ6SpellCounter.Interval = 1000
        '
        'InGameTracker
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(398, 139)
        Me.Controls.Add(Me.hint)
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label3)
        Me.ForeColor = System.Drawing.Color.White
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "InGameTracker"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "League Timer Tracker"
        Me.TransparencyKey = System.Drawing.Color.Black
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.FlowLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents hint As Label
    Friend WithEvents Timer1 As Timer
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents SummSpell1 As Label
    Friend WithEvents Summ1SpellCounter As Timer
    Friend WithEvents SummSpell2 As Label
    Friend WithEvents SummSpell3 As Label
    Friend WithEvents Summ2SpellCounter As Timer
    Friend WithEvents Label3 As Label
    Friend WithEvents Summ3SpellCounter As Timer
    Friend WithEvents Summ4SpellCounter As Timer
    Friend WithEvents Summ5SpellCounter As Timer
    Friend WithEvents SummSpell4 As Label
    Friend WithEvents Summ6SpellCounter As Timer
    Friend WithEvents SummSpell5 As Label
    Friend WithEvents SummSpell6 As Label
End Class
