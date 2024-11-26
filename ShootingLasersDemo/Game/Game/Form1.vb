Public Class Form1
    Dim frame As Bitmap
    Dim g, gFinal As Graphics
    Dim playerY As Integer
    Dim up, down As Boolean

    Dim shots As List(Of Point) 'Holds all the shots (like an array)

    Private Sub GameTimer_Tick(sender As Object, e As EventArgs) Handles GameTimer.Tick
        'DRAW STUFF HERE
        '---------------

        'Draw your background first!
        g.Clear(Color.SkyBlue)

        If up = True Then
            playerY -= 10
        End If
        If down = True Then
            playerY += 10
        End If

        'Draw Player
        g.FillRectangle(Brushes.Red, 0, playerY, 75, 75)


        'Traverse all shots
        For i = shots.Count - 1 To 0 Step -1
            'Move a shot
            shots(i) = New Point(shots(i).X + 10, shots(i).Y)
            'Draw the shot
            g.FillRectangle(Brushes.Black, shots(i).X, shots(i).Y, 10, 10)

            'Remove shots when they leave the screen
            If shots(i).X > getWidth() Then
                shots.RemoveAt(i)
            End If
        Next


        'Do not alter this line
        gFinal.DrawImage(frame, 0, 0)
        'Check for collisions below

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Do not alter this code
        frame = New Bitmap(getWidth(), getHeight())
        gFinal = Me.CreateGraphics
        g = Graphics.FromImage(frame)

        gFinal.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic
        gFinal.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality
        gFinal.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality
        gFinal.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality

        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality
        g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality
        g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality

        shots = New List(Of Point)

        GameTimer.Start()
    End Sub


    Private Sub Form1_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
        If e.KeyValue = Keys.Up Then
            up = False
        End If
        If e.KeyValue = Keys.Down Then
            down = False
        End If

        'Add a shot to the array when space is hit
        If e.KeyValue = Keys.Space Then
            shots.Add(New Point(50, playerY))
        End If
    End Sub

    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyValue = Keys.Up Then
            up = True
        End If
        If e.KeyValue = Keys.Down Then
            down = True
        End If


    End Sub

    Function getWidth() As Integer
        'Returns the usable width of the form
        Return Me.ClientSize.Width
    End Function
    Function getHeight() As Integer
        'Returns the usable height of the form
        Return Me.ClientSize.Height
    End Function
End Class
