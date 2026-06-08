namespace LINQtoCSV
{
	public class RequiredButMissingFieldIndexException : LINQtoCSVException
	{
		public RequiredButMissingFieldIndexException(string typeName, string fieldName)
			: base($"Field or property \"{fieldName}\" of type \"{typeName}\" is required, but does not have a FieldIndex. This exception only happens for files without column names in the first record.")
		{
			Data["TypeName"] = typeName;
			Data["FieldName"] = fieldName;
		}
	}
}
