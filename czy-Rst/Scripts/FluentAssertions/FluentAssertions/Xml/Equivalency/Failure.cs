namespace FluentAssertions.Xml.Equivalency
{
	internal class Failure
	{
		public string FormatString { get; }

		public object[] FormatParams { get; }

		public Failure(string formatString, params object[] formatParams)
		{
			FormatString = formatString;
			FormatParams = formatParams;
		}
	}
}
