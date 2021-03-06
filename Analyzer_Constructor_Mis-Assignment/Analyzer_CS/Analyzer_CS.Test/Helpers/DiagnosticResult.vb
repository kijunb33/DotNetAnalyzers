Imports Microsoft.CodeAnalysis

Namespace TestHelper

  ''' <summary>
  ''' Location where the diagnostic appears, as determined by path, line number, And column number.
  ''' </summary>
  Public Structure DiagnosticResultLocation

    Public Sub New(path As String, line As Integer, column As Integer)

      If line < 0 AndAlso column < 0 Then
        Throw New ArgumentOutOfRangeException("At least one of line and column must be > 0")
      End If

      If line < -1 OrElse column < -1 Then
        Throw New ArgumentOutOfRangeException("Both line and column must be >= -1")
      End If

      Me.Path = path
      Me.Line = line
      Me.Column = column

    End Sub


    Public Property Path As String
    Public Property Line As Integer
    Public Property Column As Integer

  End Structure


  ''' <summary>
  ''' Struct that stores information about a Diagnostic appearing in a source
  ''' </summary>
  Public Structure DiagnosticResult

    Private innerlocations As DiagnosticResultLocation()

    Public Property Locations As DiagnosticResultLocation()
      Get

        If Me.innerlocations Is Nothing Then
          Me.innerlocations = {}
        End If

        Return Me.innerlocations
      End Get

      Set

        Me.innerlocations = Value
      End Set
    End Property

    Public Property Severity As DiagnosticSeverity

    Public Property Id As String

    Public Property Message As String

    Public ReadOnly Property Path As String
      Get
        Return If(Me.Locations.Length > 0, Me.Locations(0).Path, "")
      End Get
    End Property

    Public ReadOnly Property Line As Integer
      Get
        Return If(Me.Locations.Length > 0, Me.Locations(0).Line, -1)
      End Get
    End Property

    Public ReadOnly Property Column As Integer
      Get
        Return If(Me.Locations.Length > 0, Me.Locations(0).Column, -1)
      End Get
    End Property

  End Structure

End Namespace

