Public Class Form1

    Private five As block = Nothing
    Private three As block = Nothing
    Private two As block = Nothing
    Private oneA As block = Nothing
    Private oneB As block = Nothing

    Private oneM() As Single = {1, 3, 3, 3, 3}
    Private twoM() As Single = {1, 1, 3, 3, 3}
    Private threeM() As Single = {1, 1, 1, 3, 3}
    Private fourM() As Single = {1, 1, 1, 1, 3}
    Private fiveM() As Single = {1, 1, 1, 1, 1}
    Private sixM() As Single = {3, 1, 1, 1, 1}
    Private sevenM() As Single = {3, 3, 1, 1, 1}
    Private eightM() As Single = {3, 3, 3, 1, 1}
    Private nineM() As Single = {3, 3, 3, 3, 1}
    Private zeroM() As Single = {3, 3, 3, 3, 3}

    Private btm As Bitmap = Nothing
    Private g As Graphics = Nothing

    Private isReSizing As Boolean

    Private clockType As Integer = 1
    Private multipler As Single
    ' Private isLoading As Boolean = True

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        oneA = New block(118, 0, 73, 59)
        oneB = New block(118, 59, 73, 59)
        two = New block(0, 0, 118, 118)
        three = New block(0, 118, 191, 191)
        five = New block(191, 0, 309, 309)

        btm = New Bitmap(p1.Width, p1.Height, Imaging.PixelFormat.Format32bppArgb)
        g = Graphics.FromImage(btm)

        Timer1.Enabled = True

        Timer1.Interval = 60000 - (Now.Second * 1000)
        multipler = getMultipler()
    End Sub


    Private Sub drawTime()
        If clockType = 1 Then
            Fibonacci()
        ElseIf clockType = 2 Then
            Morsecode()
        ElseIf clockType = 3 Then
            Hexadecimal()
        ElseIf clockType = 4 Then
            Binary()
        End If
    End Sub

    Private Sub Hexadecimal()
        Timer1.Interval = 1000
        g.Clear(Color.White)
        Dim currenttime As Date = Now
        Dim hour As Integer = currenttime.Hour
        Dim minutes As Integer = currenttime.Minute
        Dim seconds As Integer = currenttime.Second

        Dim hourHexi As String = hour.ToString("X").PadLeft(2, "0")
        Dim minutesHexi As String = minutes.ToString("X").PadLeft(2, "0")
        Dim secondHexi As String = seconds.ToString("X").PadLeft(2, "0")
        Dim answer As String = hourHexi & " : " & minutesHexi + " : " + secondHexi

        Dim f As Font = New Font(FontFamily.GenericSansSerif, 200)
        Dim length As SizeF = g.MeasureString(answer, f)
        Dim fontSize As Integer = 200

        While length.Width > p1.Width - 10 AndAlso fontSize > 4.9
            fontSize -= 1
            f = New Font(FontFamily.GenericSansSerif, fontSize)
            length = g.MeasureString(answer, f)
        End While

        Dim startPoint As Single = (p1.Width / 2) - (length.Width / 2)
        g.DrawString(answer, f, Brushes.Black, startPoint, (p1.Height / 2) - (length.Height / 2))

        p1.Image = btm
        Text = Now.ToLongTimeString
    End Sub

    Private Sub Binary()
        Timer1.Interval = 1000
        g.Clear(Color.White)
        Dim currenttime As Date = Now
        Dim hour As Integer = currenttime.Hour
        Dim minutes As Integer = currenttime.Minute
        Dim seconds As Integer = currenttime.Second

        Dim hourBinary As String = Convert.ToString(hour, 2).PadLeft(5, "0")
        Dim minutesBinary As String = Convert.ToString(minutes, 2).PadLeft(6, "0")
        Dim secondBinary As String = Convert.ToString(seconds, 2).PadLeft(6, "0")
        Dim answer As String = hourBinary & " : " & minutesBinary + " : " + secondBinary

        Dim f As Font = New Font(FontFamily.GenericSansSerif, 100)
        Dim length As SizeF = g.MeasureString(answer, f)
        Dim fontSize As Integer = 100

        While length.Width > p1.Width - 10 AndAlso fontSize > 4.9
            fontSize -= 1
            f = New Font(FontFamily.GenericSansSerif, fontSize)
            length = g.MeasureString(answer, f)
        End While

        Dim startPoint As Single = (p1.Width / 2) - (length.Width / 2)
        g.DrawString(answer, f, Brushes.Black, startPoint, (p1.Height / 2) - (length.Height / 2))

        p1.Image = btm
        Text = Now.ToLongTimeString
    End Sub

    Private Sub Morsecode()
        Timer1.Interval = 1000
        g.Clear(Color.White)
        Dim currenttime As Date = Now
        Dim hour As Integer = currenttime.Hour
        Dim minutes As Integer = currenttime.Minute
        Dim seconds As Integer = currenttime.Second

        Dim firstHour As Integer = Tens(hour)
        Dim secondHour As Integer = hour - (10 * firstHour)
        Dim firstMinute As Integer = Tens(minutes)
        Dim secondMiute As Integer = minutes - (10 * firstMinute)
        Dim firstSecond As Integer = Tens(seconds)
        Dim secondSecond As Integer = seconds - (10 * firstSecond)

        Dim code As New List(Of Single)

        code.AddRange(GetMorseCode(firstHour))
        code.AddRange(GetMorseCode(secondHour))

        code.AddRange(GetMorseCode(firstMinute))
        code.AddRange(GetMorseCode(secondMiute))

        code.AddRange(GetMorseCode(firstSecond))
        code.AddRange(GetMorseCode(secondSecond))

        Dim length As Integer = Integer.MaxValue
        Dim todraw((code.Count * 2) - 1) As Single

        length = 0
        For index As Integer = 0 To todraw.Count - 1 Step 2
            todraw(index) = (code(index / 2) * multipler)
            todraw(index + 1) = multipler
        Next

        For index As Integer = 0 To todraw.Count - 1 Step 10
            If index > 0 Then
                todraw(index - 1) = 3 * multipler
            End If
        Next

        For index As Integer = 0 To todraw.Count - 1 Step 20
            If index > 0 Then
                todraw(index - 1) = 6 * multipler
            End If
        Next

        For index As Integer = 0 To todraw.Count - 1
            length += todraw(index)
        Next

        Dim startPoint = 10 '(p1.Width / 2) - (length / 2)
        For index As Integer = 0 To todraw.Count - 1 Step 2
            DrawRectangle(todraw(index), startPoint, (p1.Height - 10) / 2, 3 * multipler)
            startPoint += (todraw(index) + todraw(index + 1))
        Next

        p1.Image = btm
        Text = Now.ToLongTimeString
    End Sub

    Private Function getMultipler() As Single
        multipler = 20
        Dim code As New List(Of Single)

        code.AddRange(zeroM)
        code.AddRange(zeroM)
        code.AddRange(zeroM)
        code.AddRange(zeroM)
        code.AddRange(zeroM)
        code.AddRange(zeroM)
        Dim todraw((code.Count * 2) - 1) As Single

        Dim length As Integer = Integer.MaxValue

        Do Until length < p1.Width - 20 OrElse multipler < 1.1
            length = 0
            For index As Integer = 0 To todraw.Count - 1 Step 2
                todraw(index) = (code(index / 2) * multipler)
                todraw(index + 1) = multipler
            Next

            For index As Integer = 0 To todraw.Count - 1 Step 10
                If index > 0 Then
                    todraw(index - 1) = 3 * multipler
                End If
            Next

            For index As Integer = 0 To todraw.Count - 1 Step 20
                If index > 0 Then
                    todraw(index - 1) = 6 * multipler
                End If
            Next

            For index As Integer = 0 To todraw.Count - 1
                length += todraw(index)
            Next
            multipler -= 0.1
        Loop

        Return multipler

    End Function

    Private Sub DrawRectangle(length As Single, startX As Single, startY As Single, height As Single)

        Dim rect As New Rectangle(startX, startY, length, height)
        Dim cornerRadius As Integer = 2
        Using path As New Drawing2D.GraphicsPath()
            path.AddArc(rect.X, rect.Y, cornerRadius, cornerRadius, 180, 90)
            path.AddArc(rect.X + rect.Width - cornerRadius, rect.Y, cornerRadius, cornerRadius, 270, 90)
            path.AddArc(rect.X + rect.Width - cornerRadius, rect.Y + rect.Height - cornerRadius, cornerRadius, cornerRadius, 0, 90)
            path.AddArc(rect.X, rect.Y + rect.Height - cornerRadius, cornerRadius, cornerRadius, 90, 90)
            path.CloseFigure()
            g.DrawPath(Pens.Black, path)
            g.FillPath(Brushes.Black, path)
        End Using

    End Sub

    Private Function GetMorseCode(value As Integer) As Single()
        Dim answer() As Single = {1, 1}

        Select Case value
            Case 0
                answer = zeroM
            Case 1
                answer = oneM
            Case 2
                answer = twoM
            Case 3
                answer = threeM
            Case 4
                answer = fourM
            Case 5
                answer = fiveM
            Case 6
                answer = sixM
            Case 7
                answer = sevenM
            Case 8
                answer = eightM
            Case 9
                answer = nineM
        End Select

        Return answer
    End Function

    Private Function Tens(value As Integer) As Integer
        Dim answer = 0
        If value > 49 Then
            answer = 5
        ElseIf value > 39 Then
            answer = 4
        ElseIf value > 29 Then
            answer = 3
        ElseIf value > 19 Then
            answer = 2
        ElseIf value > 9 Then
            answer = 1
        ElseIf value > 0 Then
            answer = 0
        Else
            answer = 0
        End If

        Return answer

    End Function

    Private Sub Fibonacci()
        Timer1.Interval = 60000
        Text = Now.ToShortTimeString
        g.Clear(Color.White)

        Dim currenttime As Date = Now
        Dim hour As Integer = currenttime.Hour
        If hour > 12 Then hour -= 12

        five.ResetCount()
        three.ResetCount()
        two.ResetCount()
        oneA.ResetCount()
        oneB.ResetCount()

        If hour >= 5 Then
            five.IncrementCount(block.interval.hour)
            hour -= 5
        End If

        If hour >= 3 Then
            three.IncrementCount(block.interval.hour)
            hour -= 3
        End If

        If hour >= 2 Then
            two.IncrementCount(block.interval.hour)
            hour -= 2
        End If

        If hour >= 1 Then
            oneA.IncrementCount(block.interval.hour)
            hour -= 1
        End If

        If hour >= 1 Then
            oneB.IncrementCount(block.interval.hour)
        End If

        Dim minutes As Integer = currenttime.Minute
        minutes = minutes \ 5

        If minutes >= 5 Then
            five.IncrementCount(block.interval.minute)
            minutes -= 5
        End If

        If minutes >= 3 Then
            three.IncrementCount(block.interval.minute)
            minutes -= 3
        End If

        If minutes >= 2 Then
            two.IncrementCount(block.interval.minute)
            minutes -= 2
        End If

        If minutes >= 1 Then
            oneB.IncrementCount(block.interval.minute)
            minutes -= 1
        End If

        If minutes >= 1 Then
            oneA.IncrementCount(block.interval.minute)
        End If

        five.FillMe(g)
        three.FillMe(g)
        two.FillMe(g)
        oneA.FillMe(g)
        oneB.FillMe(g)

        five.DrawMe(g)
        three.DrawMe(g)
        two.DrawMe(g)
        oneA.DrawMe(g)
        oneB.DrawMe(g)

        p1.Image = btm

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        drawTime()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Text = Now.ToShortTimeString
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        If isReSizing = True Then
            isReSizing = False
        Else
            multipler = getMultipler()
            ResizeBlocks()
            Timer2.Enabled = False
            drawTime()
        End If
    End Sub

    Private Sub ResizeBlocks()
        Dim widthScale As Double = p1.Width / 500
        Dim heightScale As Double = p1.Height / 309

        oneA = New block(CInt(widthScale * 118), 0, CInt(widthScale * 73), CInt(heightScale * 59))
        oneB = New block(CInt(widthScale * 118), CInt(heightScale * 59), CInt(widthScale * 73), CInt(heightScale * 59))
        two = New block(0, 0, CInt(widthScale * 118), CInt(heightScale * 118))
        three = New block(0, CInt(heightScale * 118), CInt(widthScale * 191), CInt(heightScale * 191))
        five = New block(CInt(widthScale * 191), 0, CInt(widthScale * 309), CInt(heightScale * 309))

        btm = New Bitmap(p1.Width, p1.Height, Imaging.PixelFormat.Format32bppArgb)
        g = Graphics.FromImage(btm)

    End Sub

    Private Sub Form1_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        isReSizing = True
        Timer2.Enabled = True
    End Sub

    Private Sub p1_MouseHover(sender As Object, e As EventArgs) Handles p1.MouseHover
        If clockType = 1 Then
            ToolTip1.SetToolTip(p1, "Blue = for hours, Red for minutes and Green for both")
        End If
    End Sub

    Private Sub RemoveCheck()
        MorseCodeToolStripMenuItem.Checked = False
        FibonacciToolStripMenuItem.Checked = False
        HexadecimalToolStripMenuItem.Checked = False
        BinaryToolStripMenuItem.Checked = False
    End Sub
    Private Sub FibonacciToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FibonacciToolStripMenuItem.Click
        clockType = 1
        drawTime()
        RemoveCheck()
        FibonacciToolStripMenuItem.Checked = True
    End Sub

    Private Sub MorseCodeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MorseCodeToolStripMenuItem.Click
        clockType = 2
        drawTime()
        RemoveCheck()
        MorseCodeToolStripMenuItem.Checked = True
    End Sub

    Private Sub HexadecimalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HexadecimalToolStripMenuItem.Click
        clockType = 3
        drawTime()
        RemoveCheck()
        HexadecimalToolStripMenuItem.Checked = True
    End Sub

    Private Sub BinaryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BinaryToolStripMenuItem.Click
        clockType = 4
        drawTime()
        RemoveCheck()
        BinaryToolStripMenuItem.Checked = True
    End Sub
End Class
