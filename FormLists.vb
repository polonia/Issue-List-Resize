Public Class FormLists

#Region "Panel UX resize"

    ''' <summary>
    ''' Panel1_MouseLeave - Small Panel area for resize - MouseLeave event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Panel1_MouseLeave(sender As Object, e As EventArgs) Handles Panel1.MouseLeave
        ' mouse feedback on leave
        Cursor.Current = System.Windows.Forms.Cursors.Default
    End Sub

    ''' <summary>
    ''' Panel1_MouseMove - Small Panel area for resize - MouseMove event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Panel1_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel1.MouseMove
        If e.Button.Equals(MouseButtons.Left) Then
            MovePanel(CInt(PosX - MousePosition.X))
        Else
            ' reset position and cursor
            PosX = 0
            Cursor.Current = System.Windows.Forms.Cursors.Default
        End If
    End Sub

    ''' <summary>
    ''' Last mouse X position
    ''' </summary>
    Private PosX As Double

    ''' <summary>
    ''' MinGroupSize - Low Group Size limit (always large than this value)
    ''' </summary>
    Const MinGroupSize As Integer = 100

    ''' <summary>
    ''' MovePanel - Move horizontaly the panels by DeltaX
    ''' </summary>
    ''' <param name="DeltaX">Delta X</param>
    Private Sub MovePanel(ByVal DeltaX As Integer)
        Cursor.Current = System.Windows.Forms.Cursors.SizeWE

        ' Initial Pos
        If PosX.Equals(0) Then
            ' initial status
            PosX = MousePosition.X '+ Panel1.Left
            DeltaX = 0
        End If
        ' Min size
        If (GroupBox1.Width <= MinGroupSize) And (DeltaX > 0) Then
            DeltaX = 0
        End If
        If (GroupBox2.Width <= MinGroupSize) And (DeltaX < 0) Then
            DeltaX = 0
        End If

        ' Move
        If Not DeltaX.Equals(0) Then
            GroupBox1.Width -= DeltaX
            Panel1.Left -= DeltaX
            GroupBox2.Left -= DeltaX
            GroupBox2.Width += DeltaX

            ' update new position
            PosX = MousePosition.X
        End If
    End Sub

    ''' <summary>
    ''' ResetPanel - Resize the panels positions, with half of total size for each
    ''' </summary>
    Private Sub ResetPanel()
        Dim TotalGroupSize As Integer

        TotalGroupSize = GroupBox1.Width + GroupBox2.Width

        GroupBox1.Width = CInt(TotalGroupSize / 2)
        GroupBox2.Width = CInt(TotalGroupSize / 2)
        Panel1.Left = GroupBox1.Left + GroupBox1.Width + 10
        GroupBox2.Left = Panel1.Left + Panel1.Width + 10
        PosX = 0
    End Sub

#End Region

    Private Sub ButtonReset_Click(sender As Object, e As EventArgs) Handles ButtonReset.Click
        ResetPanel()
    End Sub


End Class
