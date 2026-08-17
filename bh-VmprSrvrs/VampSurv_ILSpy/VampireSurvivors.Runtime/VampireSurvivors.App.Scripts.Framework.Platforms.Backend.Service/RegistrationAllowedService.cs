using System;
using System.Globalization;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.App.Scripts.Framework.Platforms.Backend.Util;

namespace VampireSurvivors.App.Scripts.Framework.Platforms.Backend.Service;

public class RegistrationAllowedService
{
	private readonly string key;

	public bool CanRegister()
	{
		string userSpecificKey = PlatformUserPlayerPrefs.GetUserSpecificKey(key);
		string text = PlayerPrefs.GetString(userSpecificKey, "");
		ref DateTime result = default(ref DateTime);
		if (text != null && text._stringLength > 0 && DateTime.TryParseExact(text, "O", null, DateTimeStyles.None, out result))
		{
			DateTime now = DateTime.Now;
			DateTime dateTime = default(DateTime);
			return dateTime < now;
		}
		return true;
	}

	public unsafe void DisableRegistrationUntil(DateTime dob)
	{
		//IL_003c: Expected O, but got Ref
		object obj = default(object);
		object arg = (DateTime)obj;
		System.ParamsArray paramsArray = new System.ParamsArray(arg);
		object obj2 = default(object);
		string value = string.FormatHelper((IFormatProvider)CultureInfo.invariant_culture_info, "{0:O}", (System.ParamsArray)(&obj2));
		string userSpecificKey = PlatformUserPlayerPrefs.GetUserSpecificKey(key);
		PlayerPrefs.SetString(userSpecificKey, value);
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: Type: Il2CppMethodInfo (should have been resolved before IL gen)");
		Cpp2ILHelpers.NoteDecompilerIssue("Warning: Method ends with non empty stack (-68), the output could be wrong!");
		/*Error: End of method reached without returning.*/;
	}

	public RegistrationAllowedService()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A3032]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		key = "registration_blocked_until";
	}
}
