namespace LINQtoCSV
{
	public class TooManyNonCsvColumnDataFieldsException : LINQtoCSVException
	{
		public TooManyNonCsvColumnDataFieldsException(string typeName, int lineNbr, string fileName)
			: base(string.Format("Line {0} has more fields then there are fields or properties in type \"{1}\" with the CsvColumn attribute set." + LINQtoCSVException.FileNameMessage(fileName), lineNbr, typeName))
		{
			Data["TypeName"] = typeName;
			Data["LineNbr"] = lineNbr;
			Data["FileName"] = fileName;
		}
	}
}
