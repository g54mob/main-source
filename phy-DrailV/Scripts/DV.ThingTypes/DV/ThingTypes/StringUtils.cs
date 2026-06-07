using System.Text.RegularExpressions;

namespace DV.ThingTypes
{
	public static class StringUtils
	{
		public static string BreakCamelCaseToSeparateWords(string stringToProcess)
		{
			while (true)
			{
				Match match = Regex.Match(stringToProcess, "[a-z][A-Z0-9]");
				if (!match.Success)
				{
					break;
				}
				stringToProcess = stringToProcess.Insert(match.Index + 1, " ");
			}
			return stringToProcess;
		}
	}
}
