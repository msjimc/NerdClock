Public Class block
    Private sqaure As Rectangle
    Private count As Integer = 0

    Public Enum interval
        minute = 1
        hour = 2
    End Enum

    Public Sub New(left As Integer, top As Integer, width As Integer, height As Integer)
        sqaure = New Rectangle(left, top, width, height)
        count = 0
    End Sub

    Public Sub IncrementCount(value As interval)
        count += CInt(value)
    End Sub

    Public Sub ResetCount()
        count = 0
    End Sub

    Public ReadOnly Property Colour() As Color
        Get

            Dim theColour As Color = Color.White
            Select Case count
                Case 0 ' now minute or hour
                    theColour = Color.White
                Case 1 'minute
                    theColour = Color.Red
                Case 2 'hour
                    theColour = Color.Blue
                Case 3 'minute and hour
                    theColour = Color.Green
                Case Else 'error
                    theColour = Color.Black
            End Select

            Return theColour

        End Get
    End Property

    Public Sub FillMe(g As Graphics)
        g.FillRectangle(New SolidBrush(Colour), sqaure)
    End Sub

    Public Sub DrawMe(g As Graphics)
        g.DrawRectangle(New Pen(Color.Black, 2), sqaure)
    End Sub


End Class
