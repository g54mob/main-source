namespace LINQtoCSV
{
	public class ToBeWrittenButMissingFieldIndexException : LINQtoCSVException
	{
		public ToBeWrittenButMissingFieldIndexException(string typeName, string fieldName)
			: base($"Field or property \"{fieldName}\" of type \"{typeName}\" will be written to a file, but does not have a FieldIndex. This exception only happens for input files without column names in the first record.")
		{
			Data["TypeName"] = typeName;
			Data["FieldName"] = fieldName;
		}
	}
}
