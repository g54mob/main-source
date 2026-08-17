using Cpp2ILInjected;

namespace Assets.Scripts.Saves___Serialization.SaveFiles.Configs;

public class ConfigSettingsExtra
{
	public bool hideCompletedQuests;

	public bool hasAcceptedPhotoSensitivity;

	public string lastSteamLanguage;

	public ConfigSettingsExtra()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1831725EE]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		lastSteamLanguage = "en";
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
	}
}
