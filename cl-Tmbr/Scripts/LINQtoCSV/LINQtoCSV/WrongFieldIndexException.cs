namespace LINQtoCSV
{
	public class WrongFieldIndexException : LINQtoCSVException
	{
		public WrongFieldIndexException(string typeName, int lineNbr, string fileName)
			: base(string.Format("Line {0} has less fields then the FieldIndex value is indicating in type \"{1}\" ." + LINQtoCSVException.FileNameMessage(fileName), lineNbr, typeName))
		{
			Data["TypeName"] = typeName;
			Data["LineNbr"] = lineNbr;
			Data["FileName"] = fileName;
		}
	}
}
