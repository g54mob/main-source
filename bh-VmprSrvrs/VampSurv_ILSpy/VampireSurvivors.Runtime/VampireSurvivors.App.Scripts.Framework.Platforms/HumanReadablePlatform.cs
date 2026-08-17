using System;
using System.Collections.Generic;
using I2.Loc;
using UnityEngine;
using VampireSurvivors.App.Scripts.Framework.Platforms.Backend.Authentication;

namespace VampireSurvivors.App.Scripts.Framework.Platforms;

public static class HumanReadablePlatform
{
	private static readonly Dictionary<PlatformType, string> _platformTypeToString;

	private static readonly Dictionary<AccountDetailsType, string> _accountTypeToString;

	public unsafe static string Get(PlatformType platform)
	{
		//IL_0032: Expected O, but got Ref
		if (_platformTypeToString != null)
		{
			object obj = default(object);
			if (!((Dictionary<System.Int32Enum, object>)(object)_platformTypeToString).TryGetValue((System.Int32Enum)platform, out object value))
			{
				return ((Enum)(&obj)).ToString();
			}
			bool applyParameters = default(bool);
			GameObject localParametersRoot = default(GameObject);
			string overrideLanguage = default(string);
			bool allowLocalizedParameters = default(bool);
			return LocalizationManager.GetTranslation((string)value, FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
		}
		return (string)(object)new NullReferenceException();
	}

	public unsafe static string Get(AccountDetailsType platform)
	{
		//IL_0032: Expected O, but got Ref
		if (_accountTypeToString != null)
		{
			object obj = default(object);
			if (!((Dictionary<System.Int32Enum, object>)(object)_accountTypeToString).TryGetValue((System.Int32Enum)platform, out object value))
			{
				return ((Enum)(&obj)).ToString();
			}
			bool applyParameters = default(bool);
			GameObject localParametersRoot = default(GameObject);
			string overrideLanguage = default(string);
			bool allowLocalizedParameters = default(bool);
			return LocalizationManager.GetTranslation((string)value, FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
		}
		return (string)(object)new NullReferenceException();
	}

	static HumanReadablePlatform()
	{
		Dictionary<PlatformType, string> dictionary = new Dictionary<PlatformType, string>();
		bool flag = ((Dictionary<System.Int32Enum, object>)(object)dictionary).TryInsert((System.Int32Enum)0, (object)"Standalone", System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag2 = ((Dictionary<System.Int32Enum, object>)(object)dictionary).TryInsert((System.Int32Enum)1, (object)"Steam", System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag3 = ((Dictionary<System.Int32Enum, object>)(object)dictionary).TryInsert((System.Int32Enum)2, (object)"Xbox", System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag4 = ((Dictionary<System.Int32Enum, object>)(object)dictionary).TryInsert((System.Int32Enum)3, (object)"lang/options_tab_account", System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag5 = ((Dictionary<System.Int32Enum, object>)(object)dictionary).TryInsert((System.Int32Enum)4, (object)"Android", System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag6 = ((Dictionary<System.Int32Enum, object>)(object)dictionary).TryInsert((System.Int32Enum)5, (object)"Apple", System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag7 = ((Dictionary<System.Int32Enum, object>)(object)dictionary).TryInsert((System.Int32Enum)6, (object)"PSN™", System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		_platformTypeToString = dictionary;
		Dictionary<AccountDetailsType, string> dictionary2 = new Dictionary<AccountDetailsType, string>();
		bool flag8 = ((Dictionary<System.Int32Enum, object>)(object)dictionary2).TryInsert((System.Int32Enum)0, (object)"Email", System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag9 = ((Dictionary<System.Int32Enum, object>)(object)dictionary2).TryInsert((System.Int32Enum)5, (object)"Steam", System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag10 = ((Dictionary<System.Int32Enum, object>)(object)dictionary2).TryInsert((System.Int32Enum)6, (object)"Xbox", System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag11 = ((Dictionary<System.Int32Enum, object>)(object)dictionary2).TryInsert((System.Int32Enum)4, (object)"lang/options_tab_account", System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag12 = ((Dictionary<System.Int32Enum, object>)(object)dictionary2).TryInsert((System.Int32Enum)3, (object)"Android", System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag13 = ((Dictionary<System.Int32Enum, object>)(object)dictionary2).TryInsert((System.Int32Enum)1, (object)"Apple", System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag14 = ((Dictionary<System.Int32Enum, object>)(object)dictionary2).TryInsert((System.Int32Enum)2, (object)"Game Center", System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag15 = ((Dictionary<System.Int32Enum, object>)(object)dictionary2).TryInsert((System.Int32Enum)7, (object)"PSN™", System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag16 = ((Dictionary<System.Int32Enum, object>)(object)dictionary2).TryInsert((System.Int32Enum)8, (object)"PSN™", System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		_accountTypeToString = dictionary2;
	}
}
