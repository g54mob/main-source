namespace LINQtoCSV
{
	public class MissingCsvColumnAttributeException : LINQtoCSVException
	{
		public MissingCsvColumnAttributeException(string typeName, string fieldName, string fileName)
			: base(string.Format("Field \"{0}\" in type \"{1}\" does not have the CsvColumn attribute." + LINQtoCSVException.FileNameMessage(fileName), fieldName, typeName))
		{
			Data["TypeName"] = typeName;
			Data["FieldName"] = fieldName;
			Data["FileName"] = fileName;
		}
	}
}
