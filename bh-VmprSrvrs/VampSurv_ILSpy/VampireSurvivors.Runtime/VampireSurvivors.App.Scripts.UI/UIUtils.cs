using Cpp2ILInjected;

namespace VampireSurvivors.App.Scripts.UI;

public static class UIUtils
{
	public static int PrepareCoinsForDisplay(float coins)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @185003EA0");
		if (coins < 2.1474836E+09f && -2.1474836E+09f < coins)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si eax,xmm0\"");
			int num = default(int);
			if (num <= 9999999)
			{
				if (num < 0)
				{
					return 9999999;
				}
				return num;
			}
		}
		return 9999999;
	}
}
