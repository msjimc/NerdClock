Public Class Form1

    Private five As block = Nothing
    Private three As block = Nothing
    Private two As block = Nothing
    Private oneA As block = Nothing
    Private oneB As block = Nothing

    Private btm As Bitmap = Nothing
    Private g As Graphics = Nothing

    Private isReSizing As Boolean
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

        'Dim aDate As Date = Now
        'Dim intervalMinute As Integer = aDate.Minute
        'Dim interval As Integer = (intervalMinute \ 5) * 5
        'Timer1.Interval = 301000 - (((intervalMinute - interval) * 60 * 1000) + (aDate.Second * 1000))

        Timer1.Interval = 60000 - (Now.Second * 1000)

    End Sub

    Private Sub drawTime()
        g.Clear(Color.White)

        Dim currenttime As Date = Now
        Dim hour As Integer = currenttime.Hour
        If hour > 12 Then hour -= 12

        five.resetCount()
        three.resetCount()
        two.resetCount()
        oneA.resetCount()
        oneB.resetCount()

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
        Text = Now.ToShortTimeString
        drawTime()
        Timer1.Interval = 60000
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Text = Now.ToShortTimeString
        'isLoading = False
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        If isReSizing = True Then
            isReSizing = False
        Else
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
        ToolTip1.SetToolTip(p1, "Blue = for hours, Red for minutes and Green for both")
    End Sub

End Class
