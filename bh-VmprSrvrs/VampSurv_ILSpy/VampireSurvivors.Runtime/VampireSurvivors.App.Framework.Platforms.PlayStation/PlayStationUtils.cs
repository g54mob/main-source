using System;
using Cpp2ILInjected;

namespace VampireSurvivors.App.Framework.Platforms.PlayStation;

public static class PlayStationUtils
{
	public static string ConvertAndPadDlcVersion(string dlcVersion)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A2E36]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		if (dlcVersion != null)
		{
			string text = dlcVersion.Replace(".", "");
			if (text != null)
			{
				if (text._stringLength < 32)
				{
					text = text.PadRight(32, 'A');
				}
				return text;
			}
		}
		return (string)(object)new NullReferenceException();
	}
}
