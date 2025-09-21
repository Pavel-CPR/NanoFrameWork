using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teigha.DatabaseServices;

namespace NanoFrameWork
{
    public static class TRExtension
    {
        public static BlockTable GetBlockTable(this Transaction transaction)
        {
            return transaction.GetObject(DocProvider.Db.BlockTableId, OpenMode.ForWrite) as BlockTable;
        }

        public static BlockTableRecord GetModelSpaceBtr(this Transaction transaction)
        {
            var bt = transaction.GetObject(DocProvider.Db.BlockTableId, OpenMode.ForWrite) as BlockTable;
            if (bt == null) return null;

            return transaction.GetObject(bt[BlockTableRecord.ModelSpace], OpenMode.ForWrite) as BlockTableRecord;
        }
    }
}
