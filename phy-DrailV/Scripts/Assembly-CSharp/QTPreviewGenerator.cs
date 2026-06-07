using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using UnityEngine;

public class QTPreviewGenerator : MonoBehaviour
{
	[InspectorNote("Warning", "Make sure your localization asset is up to date, as it's referenced for the generation process!")]
	public string subtreePath;

	public int maxTitlesInColumn = 25;

	private static readonly Regex StringLiteralRegex = new Regex("@\"([^\"]|\"\")*\"|\"([^\"\\\\]*(\\\\.[^\"\\\\]*)*)\"", RegexOptions.Compiled);

	private static HashSet<string> ExtractAllUniqueStringLiterals(string folderPath)
	{
		HashSet<string> hashSet = new HashSet<string>();
		if (!Directory.Exists(folderPath))
		{
			throw new DirectoryNotFoundException("Directory not found: " + folderPath);
		}
		string[] files = Directory.GetFiles(folderPath, "*.cs", SearchOption.AllDirectories);
		for (int i = 0; i < files.Length; i++)
		{
			string input = File.ReadAllText(files[i]);
			foreach (Match item in StringLiteralRegex.Matches(input))
			{
				string value = item.Value;
				value = ((!value.StartsWith("@\"")) ? Regex.Unescape(value.Substring(1, value.Length - 2)) : value.Substring(2, value.Length - 3).Replace("\"\"", "\""));
				hashSet.Add(value);
			}
		}
		return hashSet;
	}
}
