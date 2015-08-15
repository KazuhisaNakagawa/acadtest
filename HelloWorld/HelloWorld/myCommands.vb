' (C) Copyright 2011 by  
'
Imports System
Imports Autodesk.AutoCAD.Runtime
Imports Autodesk.AutoCAD.ApplicationServices
Imports Autodesk.AutoCAD.DatabaseServices
Imports Autodesk.AutoCAD.Geometry
Imports Autodesk.AutoCAD.EditorInput

' This line is not mandatory, but improves loading performances
<Assembly: CommandClass(GetType(HelloWorld.MyCommands))> 
Namespace HelloWorld

    ' This class is instantiated by AutoCAD for each document when
    ' a command is called by the user the first time in the context
    ' of a given document. In other words, non static data in this class
    ' is implicitly per-document!
    Public Class MyCommands


        <CommandMethod("HelloWorld", "HelloWorld", "HelloWorld", CommandFlags.Modal)> _
        Public Sub HelloWorld()
            MsgBox("HelloWorld!!")
        End Sub



    End Class

End Namespace