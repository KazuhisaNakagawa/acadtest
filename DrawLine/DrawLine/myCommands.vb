' (C) Copyright 2011 by  
'
Imports System
Imports Autodesk.AutoCAD.Runtime
Imports Autodesk.AutoCAD.ApplicationServices
Imports Autodesk.AutoCAD.DatabaseServices
Imports Autodesk.AutoCAD.Geometry
Imports Autodesk.AutoCAD.EditorInput

' This line is not mandatory, but improves loading performances
<Assembly: CommandClass(GetType(DrawLine.MyCommands))> 
Namespace DrawLine

    ' This class is instantiated by AutoCAD for each document when
    ' a command is called by the user the first time in the context
    ' of a given document. In other words, non static data in this class
    ' is implicitly per-document!
    Public Class MyCommands

        <CommandMethod("DrawLine", "DrawLine", "DrawLine", CommandFlags.Modal)> _
        Public Sub DrawLine()
            Dim doc As Document = Application.DocumentManager.MdiActiveDocument
            Dim db As Database = doc.Database

            Using trans As Transaction = db.TransactionManager.StartTransaction
                Try
                    Dim bt As BlockTable = trans.GetObject(db.BlockTableId, OpenMode.ForRead)
                    Dim btRec As BlockTableRecord = trans.GetObject(bt(BlockTableRecord.ModelSpace), OpenMode.ForRead)

                    Dim lin As New Line(New Point3d(100, 100, 0), New Point3d(200, 100, 0))
                    lin.SetDatabaseDefaults()

                    btRec.AppendEntity(lin)
                    trans.AddNewlyCreatedDBObject(lin, True)

                    trans.Commit()

                Catch ex As System.Exception
                    MsgBox(ex.Message)

                End Try
            End Using
        End Sub

        

    End Class

End Namespace