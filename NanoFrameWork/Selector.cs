using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HostMgd.EditorInput;
using Teigha.DatabaseServices;

namespace NanoFrameWork
{
    public class Selector
    {
        /// <summary>
        /// Возвращает набор примитивов
        /// </summary>
        /// <param name="message">Сообщение для пользователя</param>
        /// <param name="dxfCodes">Список dxf кодов, по которым будут отфильтрованы примитивы</param>
        /// <returns></returns>
        public static SelectionSet GetSelection(string message, List<string> dxfCodes)
        {
            var editor = DocProvider.Editor;

            PromptSelectionOptions options = new PromptSelectionOptions();
            options.MessageForAdding = message;


            if (dxfCodes != null && dxfCodes.Count > 0)
            {
                TypedValue[] typValAr = new TypedValue[dxfCodes.Count + 2];
                typValAr.SetValue(new TypedValue((int)DxfCode.Operator, "<or"), 0);

                for (int i = 0; i < dxfCodes.Count; i++)
                {
                    typValAr.SetValue(new TypedValue((int)DxfCode.Start, dxfCodes[i]), i + 1);
                }

                typValAr.SetValue(new TypedValue((int)DxfCode.Operator, "or>"), dxfCodes.Count + 1);

                SelectionFilter sf = new SelectionFilter(typValAr);
                PromptSelectionResult ptsRes = editor.GetSelection(options, sf);

                if (ptsRes.Status == PromptStatus.OK)
                {
                    if (ptsRes.Value != null)
                    {
                        return ptsRes.Value;
                    }
                }
            }

            return null;
        }

        public static ObjectId GetEntity(string message)
        {
            ObjectId result = ObjectId.Null;
            PromptEntityResult promptEntityResult = DocProvider.Editor.GetEntity(new PromptEntityOptions(message));

            if (promptEntityResult != null)
            {
                result = promptEntityResult.ObjectId;
            }

            return result;
        }

        public static ObjectId GetEntity(string message, string dxfName)
        {
            ObjectId result = ObjectId.Null;
            PromptEntityResult promptEntityResult = DocProvider.Editor.GetEntity(new PromptEntityOptions(message));

            if (promptEntityResult != null && promptEntityResult.ObjectId.ObjectClass.DxfName == dxfName)
            {
                result = promptEntityResult.ObjectId;
            }

            return result;
        }

        public static double GetDouble(string message)
        {
            PromptDoubleOptions options = new PromptDoubleOptions(message);
            PromptDoubleResult result = DocProvider.Editor.GetDouble(options);
            if (result.Status == PromptStatus.OK)
            {
                return result.Value;
            }

            return double.NaN;
        }
    }
}

