using System.Collections.Generic;

public class TermWriter
{
	private const string targetFile = "SokTerms.cs";

	public static void WriteTerms(List<SokTerm> terms)
	{
	}

	private static string FormatTerm(string termName, string termText)
	{
		termText = termText.Replace("\n", "#");
		return "    /// <summary>\"" + termText + "\"</summary>\r\n    public const string " + termName + " = \"" + termName + "\";\r\n\r\n";
	}
}
