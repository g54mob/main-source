namespace LINQtoCSV
{
	public class TooManyDataFieldsException : LINQtoCSVException
	{
		public TooManyDataFieldsException(string typeName, int lineNbr, string fileName)
			: base(string.Format("Line {0} has more fields then are available in type \"{1}\"." + LINQtoCSVException.FileNameMessage(fileName), lineNbr, typeName))
		{
			Data["TypeName"] = typeName;
			Data["LineNbr"] = lineNbr;
			Data["FileName"] = fileName;
		}
	}
}
