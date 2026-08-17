using System;
using Cpp2ILInjected;

namespace VampireSurvivors.Builds.Game;

public static class Extensions
{
	public static DesktopPlatforms BuildPlatformToDesktopPlatform(BuildPlatform platform)
	{
		//IL_002a: Expected O, but got I8
		//IL_0044: Expected O, but got I8
		if (platform <= BuildPlatform.EGS_MAC)
		{
			object obj = 6442450944L;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ r8_v3+6BB9F58+platform @ rcx (VampireSurvivors.Builds.Game.BuildPlatform)*4]");
			object obj2 = 0 + 6442450944L;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v17 @ rdx_v6 (should have been resolved before IL gen)");
		}
		BuildPlatform buildPlatform = default(BuildPlatform);
		object obj3 = buildPlatform;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182AD6810");
		string message = default(string);
		Exception ex = new Exception(message);
		throw ex;
	}
}
