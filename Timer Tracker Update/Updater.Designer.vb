<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Updater
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Updater))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.uptodate = New System.Windows.Forms.Panel()
        Me.closebuttonuptodate = New System.Windows.Forms.Button()
        Me.updatingpanel = New System.Windows.Forms.Panel()
        Me.updatinglabel = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.uptodate.SuspendLayout()
        Me.updatingpanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(-2, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(494, 26)
        Me.Panel1.TabIndex = 17
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label10.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(475, 8)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(14, 14)
        Me.Label10.TabIndex = 17
        Me.Label10.Text = "X"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label9.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(456, 6)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(13, 14)
        Me.Label9.TabIndex = 16
        Me.Label9.Text = "_"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(3, 4)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(96, 18)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "AutoUpdater"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(85, 70)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(324, 15)
        Me.ProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.ProgressBar1.TabIndex = 19
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 20.0!)
        Me.Label2.ForeColor = System.Drawing.Color.DeepSkyBlue
        Me.Label2.Location = New System.Drawing.Point(116, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(262, 32)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "You are Up-To-Date!"
        '
        'uptodate
        '
        Me.uptodate.Controls.Add(Me.closebuttonuptodate)
        Me.uptodate.Controls.Add(Me.Label2)
        Me.uptodate.Location = New System.Drawing.Point(-2, 23)
        Me.uptodate.Name = "uptodate"
        Me.uptodate.Size = New System.Drawing.Size(494, 110)
        Me.uptodate.TabIndex = 21
        '
        'closebuttonuptodate
        '
        Me.closebuttonuptodate.Location = New System.Drawing.Point(195, 82)
        Me.closebuttonuptodate.Name = "closebuttonuptodate"
        Me.closebuttonuptodate.Size = New System.Drawing.Size(105, 23)
        Me.closebuttonuptodate.TabIndex = 21
        Me.closebuttonuptodate.Text = "Start Time Tracker"
        Me.closebuttonuptodate.UseVisualStyleBackColor = True
        '
        'updatingpanel
        '
        Me.updatingpanel.Controls.Add(Me.ProgressBar1)
        Me.updatingpanel.Controls.Add(Me.updatinglabel)
        Me.updatingpanel.Location = New System.Drawing.Point(-2, 24)
        Me.updatingpanel.Name = "updatingpanel"
        Me.updatingpanel.Size = New System.Drawing.Size(494, 110)
        Me.updatingpanel.TabIndex = 22
        '
        'updatinglabel
        '
        Me.updatinglabel.AutoSize = True
        Me.updatinglabel.Font = New System.Drawing.Font("Arial", 20.0!)
        Me.updatinglabel.ForeColor = System.Drawing.Color.DeepSkyBlue
        Me.updatinglabel.Location = New System.Drawing.Point(174, 14)
        Me.updatinglabel.Name = "updatinglabel"
        Me.updatinglabel.Size = New System.Drawing.Size(147, 32)
        Me.updatinglabel.TabIndex = 20
        Me.updatinglabel.Text = "Updating..."
        '
        'Updater
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(491, 132)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.uptodate)
        Me.Controls.Add(Me.updatingpanel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Updater"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.uptodate.ResumeLayout(False)
        Me.uptodate.PerformLayout()
        Me.updatingpanel.ResumeLayout(False)
        Me.updatingpanel.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label9 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents Label2 As Label
    Friend WithEvents uptodate As Panel
    Friend WithEvents closebuttonuptodate As Button
    Friend WithEvents updatingpanel As Panel
    Friend WithEvents updatinglabel As Label
End Class
