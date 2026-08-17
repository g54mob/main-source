using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.App.Scripts.Framework.Platforms.Backend.Util;

namespace VampireSurvivors.App.Scripts.Framework.Platforms.Backend.Service;

public class RememberEmailService
{
	private readonly string key;

	public void RememberEmail(string email)
	{
		string userSpecificKey = PlatformUserPlayerPrefs.GetUserSpecificKey(key);
		PlayerPrefs.SetString(userSpecificKey, email);
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: Type: Il2CppMethodInfo (should have been resolved before IL gen)");
		Cpp2ILHelpers.NoteDecompilerIssue("Warning: Method ends with non empty stack (-28), the output could be wrong!");
		/*Error: End of method reached without returning.*/;
	}

	public string GetEmail()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A3033]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		string userSpecificKey = PlatformUserPlayerPrefs.GetUserSpecificKey(key);
		return PlayerPrefs.GetString(userSpecificKey, "");
	}

	public RememberEmailService()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A3034]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		key = "login_email";
	}
}
