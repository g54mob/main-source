using System.Collections.Generic;

public class AsciiLoader
{
	private static bool VERBOSE;

	public static AsciiData Load(string text, List<AsciiData.StringReplacement> replacements = null, int pageStartIndex = 0, int pageCount = -1)
	{
		string text2 = null;
		int num = text.IndexOf("{");
		if (num == 0)
		{
			int num2 = text.IndexOf("}");
			if (num2 > num)
			{
				text2 = text.Substring(0, num2 + 1);
				num = text.IndexOf('\n', num2) + 1;
				if (num > text.Length)
				{
					return null;
				}
				text = text.Substring(num);
			}
		}
		if (VERBOSE)
		{
			Utils.Log("Header:\n" + text2);
		}
		if (text2 == null || SlimJson.ParseInt(text2, "v") > 1)
		{
			return LoadV2(text, replacements, pageStartIndex, pageCount);
		}
		return LoadV1(text, replacements, pageStartIndex, pageCount);
	}

	private static AsciiData LoadV2(string text, List<AsciiData.StringReplacement> replacements = null, int pageStartIndex = 0, int pageCount = -1)
	{
		AsciiData asciiData = new AsciiData();
		asciiData.loadingVersion = 2;
		asciiData.stringReplacements = replacements;
		asciiData.FromText(text, pageStartIndex, pageCount);
		return asciiData;
	}

	private static AsciiData LoadV1(string text, List<AsciiData.StringReplacement> replacements = null, int pageStartIndex = 0, int pageCount = -1)
	{
		int num = text.IndexOf("%");
		if (num < 0)
		{
			Utils.LogError("Bad Format. Expected % to open body.");
			Utils.Log("Asset: \n" + text);
			return null;
		}
		int num2 = text.LastIndexOf("%%");
		if (num2 < 0)
		{
			Utils.LogError("Bad Format. Expected %% to close body.");
			Utils.Log("Asset: \n" + text);
			return null;
		}
		int num3 = num2 - num - 2;
		if (num3 < 0)
		{
			Utils.LogError("Bad Format. Opening and closing body tags % and %% don't follow the correct syntax.");
			Utils.Log("Asset: \n" + text);
			return null;
		}
		if (num3 == 0)
		{
			Utils.LogError("Invalid content. Content cannot be empty.");
		}
		string text2 = text.Substring(num + 2, num3);
		if (VERBOSE)
		{
			Utils.Log("Body:\n" + text2);
		}
		AsciiData asciiData = new AsciiData();
		asciiData.stringReplacements = replacements;
		asciiData.FromText(text2, pageStartIndex, pageCount);
		return asciiData;
	}
}
