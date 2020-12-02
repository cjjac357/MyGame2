Public Class Form1
    Dim xdir As Integer
    Dim ydir As Integer
    Dim score As Integer
    Dim r As New Random
    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        'chase(PictureBox2)
        'Label2.Text = score
    End Sub
    Function Collision(p As String, t As String, Optional ByRef other As Object = vbNull)
        For Each c In Controls
            If c.name.toupper = p.ToUpper Then
                Return Collision(c, t, other)
            End If
        Next
        Return False
    End Function
    Function Collision(p As PictureBox, t As String, Optional ByRef other As Object = vbNull)
        Dim col As Boolean

        For Each c In Controls
            Dim obj As Control
            obj = c
            If obj.Visible AndAlso p.Bounds.IntersectsWith(obj.Bounds) And obj.Name.ToUpper.Contains(t.ToUpper) Then
                col = True
                other = obj
            End If
        Next
        Return col
    End Function
    'Return true or false if moving to the new location is clear of objects ending with t
    Function IsClear(p As PictureBox, distx As Integer, disty As Integer, t As String) As Boolean
        Dim b As Boolean

        p.Location += New Point(distx, disty)
        b = Not Collision(p, t)
        p.Location -= New Point(distx, disty)
        Return b
    End Function
    'Moves and object (won't move onto objects containing  "wall" and shows green if object ends with "win"
    Sub MoveTo(p As PictureBox, distx As Integer, disty As Integer)
        If IsClear(p, distx, disty, "WALL") Then
            p.Location += New Point(distx, disty)
        End If
        Dim other As Object = Nothing
        'If Collision("Bullet", "Patrick", other) Then
        '    'other.visible = False
        '    Return
        'End If
        If Collision("Burger", "Patrick") Then
            Burger.Visible = False
            score = +1
            Return
        End If
        If Collision("Burger1", "Patrick") Then
            score = +1
            Burger1.Visible = False
            Return
        End If
        If Collision("Burger2", "Patrick") Then
            Burger2.Visible = False
            score += 1
            Return
        End If
        If Collision("Burger3", "Patrick") Then
            Burger3.Visible = False
            score += 1
            Return
        End If
        If Collision("Burger4", "Patrick") Then
            Burger4.Visible = False
            score += 1
            Return
        End If
        If Collision("Burger5", "Patrick") Then
            Burger5.Visible = False
            score += 1
            Return
        End If
        If Collision("Burger6", "Patrick") Then
            Burger6.Visible = False
            score += 1
            Return
        End If
        If Collision("Burger7", "Patrick") Then
            Burger7.Visible = False
            score += 1
            Return
        End If
        If Collision("Burger8", "Patrick") Then
            Burger8.Visible = False
            score += 1
            Return
        End If
        If Collision("Burger9", "Patrick") Then
            Burger9.Visible = False
            score += 1
            Return
        End If
        If p.Name = "Patrick1" And Collision(p, "Jelly", other) Then
            'Jelly.Visible = False
            'Jelly2.Visible = False
            'Jelly3.Visible = False
            Label3.Visible = True
            Me.BackColor = Color.Red
        End If
        If p.Name = "Patrick1" And Collision(p, "Bob", other) Then
            Jelly.Visible = False
            Jelly2.Visible = False
            Jelly3.Visible = False
            Label1.Visible = True
            Me.BackColor = Color.Green
        End If
    End Sub
    Sub MoveTo(p As String, distx As Integer, disty As Integer)
        For Each c In Controls
            If c.name.toupper = p.ToUpper Then
                MoveTo(c, distx, disty)
            End If
        Next
    End Sub
    Sub CreateNew(name As String, pic As PictureBox, location As Point)
        Dim p As New PictureBox
        p.Location = location
        p.Image = pic.Image
        p.Name = name
        p.Width = pic.Width
        p.Height = pic.Height
        p.SizeMode = PictureBoxSizeMode.StretchImage
        Controls.Add(p)

    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        MoveTo("bullet", 15, 0)
    End Sub

    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.Up
                MoveTo("Patrick1", 0, -5)
            Case Keys.Down
                MoveTo("Patrick1", 0, 5)
            Case Keys.Left
                MoveTo("Patrick1", -5, 0)
            Case Keys.Right
                MoveTo("Patrick1", 5, 0)
                'Case Keys.Space
                '    CreateNew("Bullet", PictureBox3, PictureBox2.Location)
            Case Else

        End Select
    End Sub
    'Public Sub chase(p As PictureBox)
    '    Dim x, y As Integer
    '    If p.Location.X > Patrick1.Location.X Then
    '        x = -5
    '    Else
    '        x = 5
    '    End If
    '    MoveTo(p, x, 0)
    '    If p.Location.Y < Patrick1.Location.Y Then
    '        y = 5
    '    Else
    '        y = -5
    '    End If
    '    MoveTo(p, x, y)
    'End Sub
    Sub RandomMove(p As PictureBox)
        Dim xdir As Integer = r.Next(-20, 21)
        Dim ydir As Integer = r.Next(-20, 21)
        MoveTo(p, xdir, ydir)
    End Sub

    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles Timer3.Tick
        RandomMove(Jelly)
        RandomMove(Jelly3)
        RandomMove(Jelly2)
    End Sub


End Class
