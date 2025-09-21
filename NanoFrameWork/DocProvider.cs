using HostMgd.ApplicationServices;
using HostMgd.EditorInput;
using Teigha.DatabaseServices;

namespace NanoFrameWork
{
    public static class DocProvider
    {
        public static Document Document
        {
            get => Application.DocumentManager.MdiActiveDocument;
        }

        public static Database Db
        {
            get => Application.DocumentManager.MdiActiveDocument.Database;
        }

        public static Editor Editor
        {
            get => Application.DocumentManager.MdiActiveDocument.Editor;
        }


        public static Transaction StartTransaction()
        {
            return Db.TransactionManager.StartTransaction();
        }

        public static Object GetSystemVariable(string variableName)
        {
            return Application.GetSystemVariable(variableName);
        }

        public static void SetSystemVariable(string variableName, object value)
        {
            Application.SetSystemVariable(variableName, value);
        }
    }
}
