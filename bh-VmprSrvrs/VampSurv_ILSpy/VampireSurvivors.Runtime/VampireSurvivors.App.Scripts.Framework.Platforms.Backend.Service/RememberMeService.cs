using System;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.App.Scripts.Framework.Platforms.Backend.Util;

namespace VampireSurvivors.App.Scripts.Framework.Platforms.Backend.Service;

public class RememberMeService
{
	private readonly string key;

	public void StayLoggedIn()
	{
		Debug.Log("SetRememberMe");
		string userSpecificKey = PlatformUserPlayerPrefs.GetUserSpecificKey(key);
		PlayerPrefs.SetString(userSpecificKey, "yes");
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: Type: Il2CppMethodInfo (should have been resolved before IL gen)");
		Cpp2ILHelpers.NoteDecompilerIssue("Warning: Method ends with non empty stack (-28), the output could be wrong!");
		/*Error: End of method reached without returning.*/;
	}

	public void ForgetRememberMe()
	{
		string userSpecificKey = PlatformUserPlayerPrefs.GetUserSpecificKey(key);
		PlayerPrefs.DeleteKey(userSpecificKey);
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: Type: Il2CppMethodInfo (should have been resolved before IL gen)");
		Cpp2ILHelpers.NoteDecompilerIssue("Warning: Method ends with non empty stack (-28), the output could be wrong!");
		/*Error: End of method reached without returning.*/;
	}

	public unsafe bool ShouldAutoLogin()
	{
		//IL_010b: Expected I4, but got O
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Expected Ref, but got Unknown
		//IL_00c8: Expected I8, but got I4
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d7: Expected Ref, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A3036]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		string userSpecificKey = PlatformUserPlayerPrefs.GetUserSpecificKey(key);
		string text = PlayerPrefs.GetString(userSpecificKey, "");
		if (text != null)
		{
			object obj = "yes";
			if ((object)text != "yes")
			{
				if ("yes" != null)
				{
					int stringLength = text._stringLength;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ rdx_v3+10]");
					if ((nint)stringLength == 0)
					{
						ref byte first = ref *(byte*)(text + 20);
						ulong length = (ulong)(text._stringLength + text._stringLength);
						return System.SpanHelpers.SequenceEqual(ref first, ref *(byte*)("yes" + 20), length);
					}
				}
				return false;
			}
			return true;
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public RememberMeService()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A3037]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		key = "account_remember_me";
	}
}
