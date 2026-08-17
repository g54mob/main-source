using System;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.App.Scripts.Framework.Platforms.Backend.Util;

namespace VampireSurvivors.App.Scripts.Framework.Platforms.Backend.Service;

public class AgeGateService
{
	private readonly string _key;

	private readonly int _ageLimit;

	public unsafe bool IsOldEnough()
	{
		//IL_0062: Expected O, but got Ref
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A3028]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		string userSpecificKey = PlatformUserPlayerPrefs.GetUserSpecificKey(_key);
		string text = PlayerPrefs.GetString(userSpecificKey, "false");
		object obj = default(object);
		if (text != null && bool.TryParse((ReadOnlySpan<char>)(&obj), out var result))
		{
			return result;
		}
		return false;
	}

	public bool IsOldEnough(int year, int month, int day)
	{
		//IL_0067: Expected O, but got I8
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Expected I8, but got Unknown
		//IL_00bd: Expected O, but got I4
		//IL_00ed: Expected O, but got I8
		//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ff: Expected O, but got Unknown
		//IL_017e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0183: Expected O, but got Unknown
		//IL_018d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0192: Expected I4, but got Unknown
		//IL_01a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ac: Expected I4, but got Unknown
		long num = DateTime.DateToTicks(year, month, day);
		long num2 = num & 0x3FFFFFFFFFFFFFFFL;
		long num3 = num & -4611686018427387904L;
		long num4 = num2 % 864000000000L;
		object obj = num2 - num4;
		long num5 = obj | num3;
		DateTime today = DateTime.Today;
		DateTime dateTime = default(DateTime);
		int datePart = dateTime.GetDatePart(0);
		DateTime dateTime2 = default(DateTime);
		int datePart2 = dateTime2.GetDatePart(0);
		object obj2 = datePart - datePart2;
		int value = datePart2 - datePart;
		DateTime dateTime3 = dateTime.AddYears(value);
		bool flag = (DateTime)num5 > dateTime3;
		object obj3 = obj2 - 1;
		if (!flag)
		{
			obj3 = obj2;
		}
		object obj4 = obj3 - _ageLimit;
		int num6 = obj3 ^ _ageLimit;
		object obj5 = obj3 ^ obj4;
		int num7 = num6 & obj5;
		bool flag2 = num7 < 0;
		bool flag3 = (nint)obj4 < 0;
		bool result = flag3 == flag2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18998A2F7]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		bool flag4 = (nint)obj3 < _ageLimit;
		string value2 = "False";
		if (!flag4)
		{
			value2 = "True";
		}
		string userSpecificKey = PlatformUserPlayerPrefs.GetUserSpecificKey(_key);
		PlayerPrefs.SetString(userSpecificKey, value2);
		PlayerPrefs.Save();
		return result;
	}

	public AgeGateService()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A302A]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		_key = "age_gate_old_enough";
		_ageLimit = 13;
	}
}
