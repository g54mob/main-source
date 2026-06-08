namespace LINQtoCSV
{
	public class DuplicateFieldIndexException : LINQtoCSVException
	{
		public DuplicateFieldIndexException(string typeName, string fieldName, string fieldName2, int duplicateIndex)
			: base($"Fields or properties \"{fieldName}\" and \"{fieldName2}\" of type \"{typeName}\" have duplicate FieldIndex {duplicateIndex}.")
		{
			Data["TypeName"] = typeName;
			Data["FieldName"] = fieldName;
			Data["FieldName2"] = fieldName2;
			Data["Index"] = duplicateIndex;
		}
	}
}
