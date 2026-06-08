namespace LINQtoCSV
{
	public class MissingRequiredFieldException : LINQtoCSVException
	{
		public MissingRequiredFieldException(string typeName, string fieldName, int lineNbr, string fileName)
			: base(string.Format("In line {0}, no value provided for required field or property \"{1}\" in type \"{2}\"." + LINQtoCSVException.FileNameMessage(fileName), lineNbr, fieldName, typeName))
		{
			Data["TypeName"] = typeName;
			Data["LineNbr"] = lineNbr;
			Data["FileName"] = fileName;
			Data["FieldName"] = fieldName;
		}
	}
}
