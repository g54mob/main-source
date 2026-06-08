using System;

namespace LINQtoCSV
{
	public class WrongDataFormatException : LINQtoCSVException
	{
		public WrongDataFormatException(string typeName, string fieldName, string fieldValue, int lineNbr, string fileName, Exception innerExc)
			: base(string.Format("Value \"{0}\" in line {1} has the wrong format for field or property \"{2}\" in type \"{3}\"." + LINQtoCSVException.FileNameMessage(fileName), fieldValue, lineNbr, fieldName, typeName), innerExc)
		{
			Data["TypeName"] = typeName;
			Data["LineNbr"] = lineNbr;
			Data["FileName"] = fileName;
			Data["FieldValue"] = fieldValue;
			Data["FieldName"] = fieldName;
		}
	}
}
