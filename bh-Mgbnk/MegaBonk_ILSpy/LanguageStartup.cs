using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Saves___Serialization.SaveFiles.Configs;
using Assets.Scripts.Settings___Saves.SaveFiles;
using Assets.Scripts.Settings___Saves.SaveFiles.ConfigSaves;
using Cpp2ILInjected;
using Steamworks;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.ResourceManagement.AsyncOperations;

public class LanguageStartup : MonoBehaviour
{
	private sealed class _003C_003Ec__DisplayClass6_0
	{
		public string loc;

		internal bool _003CSetLocale_003Eb__0(Locale l)
		{
			//IL_0048: Expected I4, but got O
			if ((object)l != null)
			{
				return (string)l.m_Identifier == loc;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	private sealed class _003CSetLanguageCoroutine_003Ed__3 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		public _003CSetLanguageCoroutine_003Ed__3(int _003C_003E1__state)
		{
			((IDisposable)this).Dispose();
			this._003C_003E1__state = _003C_003E1__state;
		}

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0014: Expected I4, but got I8
			//IL_007d: Expected I4, but got I8
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				AsyncOperationHandle<LocalizationSettings> initializationOperation = LocalizationSettings.InitializationOperation;
				object obj2 = default(object);
				object obj = (AsyncOperationHandle<LocalizationSettings>)obj2;
				_003C_003E2__current = obj;
				_003C_003E1__state = 1;
				return true;
			}
			if (_003C_003E1__state == 1)
			{
				_003C_003E1__state = -1;
				SetSystemLanguage();
			}
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		void IEnumerator.Reset()
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
			NotSupportedException ex = new NotSupportedException();
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
			throw ex;
		}
	}

	private void Awake()
	{
		//IL_01fc: Expected I, but got O
		//IL_010d: Expected I, but got O
		Action b = OnSavesLoaded;
		Delegate obj = Delegate.Combine(SaveManager.A_SavesLoaded, b);
		NullReferenceException typeFromHandle;
		if ((object)obj == null)
		{
			SaveManager.A_SavesLoaded = null;
		}
		else
		{
			bool flag = (object)obj.GetType() != typeof(Action);
			Delegate obj2 = null;
			if (!flag)
			{
				obj2 = obj;
			}
			bool flag2 = (object)obj2 == null;
			nint num = (nint)typeof(Action);
			if (flag2)
			{
				goto IL_02ab;
			}
			SaveManager.A_SavesLoaded = (Action)obj2;
			bool flag3 = (object)obj.GetType() != typeof(Action);
			Delegate obj3 = null;
			if (!flag3)
			{
				obj3 = obj;
			}
			bool flag4 = (object)obj3 == null;
			typeFromHandle = (NullReferenceException)(object)typeof(Action);
			if (flag4)
			{
				goto IL_02bb;
			}
		}
		if (!SaveManager.loaded)
		{
			return;
		}
		SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
		if ((object)SaveManager._003CInstance_003Ek__BackingField != null)
		{
			nint num = (nint)saveManager.config;
			if (saveManager.config != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v164 @ rax_v10 (Il2CppClass<System.Action>)+14]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 349 Invalid \"Jump target not found in method: 0x180569990\"");
					goto IL_02ab;
				}
				SaveManager saveManager2 = SaveManager._003CInstance_003Ek__BackingField;
				if ((object)SaveManager._003CInstance_003Ek__BackingField != null)
				{
					ConfigSaveFile config = saveManager2.config;
					if (saveManager2.config != null)
					{
						config.hasSelectedLanguage = true;
						_003CSetLanguageCoroutine_003Ed__3 obj4 = new _003CSetLanguageCoroutine_003Ed__3(0);
						obj4._003C_003E1__state = 0;
						Coroutine coroutine = StartCoroutine(obj4);
						return;
					}
				}
			}
		}
		goto IL_023f;
		IL_02ab:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_023f;
		IL_023f:
		typeFromHandle = new NullReferenceException();
		goto IL_02bb;
		IL_02bb:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	private void OnDestroy()
	{
		//IL_0101: Expected I, but got O
		Action value = OnSavesLoaded;
		Delegate obj = Delegate.Remove(SaveManager.A_SavesLoaded, value);
		if ((object)obj == null)
		{
			SaveManager.A_SavesLoaded = null;
			return;
		}
		bool flag = (object)obj.GetType() != typeof(Action);
		Delegate obj2 = null;
		if (!flag)
		{
			obj2 = obj;
		}
		if ((object)obj2 != null)
		{
			SaveManager.A_SavesLoaded = (Action)obj2;
			bool flag2 = (object)obj.GetType() != typeof(Action);
			Delegate obj3 = null;
			if (!flag2)
			{
				obj3 = obj;
			}
			bool flag3 = (object)obj3 == null;
			nint num = (nint)typeof(Action);
			if (!flag3)
			{
				return;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	private void OnSavesLoaded()
	{
		SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
		ConfigSaveFile config = saveManager.config;
		if (!config.hasSelectedLanguage)
		{
			SaveManager saveManager2 = SaveManager._003CInstance_003Ek__BackingField;
			ConfigSaveFile config2 = saveManager2.config;
			config2.hasSelectedLanguage = true;
			_003CSetLanguageCoroutine_003Ed__3 obj = new _003CSetLanguageCoroutine_003Ed__3(0);
			obj._003C_003E1__state = 0;
			Coroutine coroutine = StartCoroutine(obj);
		}
		else
		{
			CheckSteamLanguage();
		}
	}

	private IEnumerator SetLanguageCoroutine()
	{
		_003CSetLanguageCoroutine_003Ed__3 obj = new _003CSetLanguageCoroutine_003Ed__3(0);
		obj._003C_003E1__state = 0;
		return obj;
	}

	private static void CheckSteamLanguage()
	{
		if (!SteamManager.initialized)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
			return;
		}
		string currentGameLanguage = SteamApps.GetCurrentGameLanguage();
		string steamLang = currentGameLanguage.ToLowerInvariant();
		string text = MapSteamLangToLocale(steamLang);
		if (string.IsNullOrEmpty(text))
		{
			string currentGameLanguage2 = SteamApps.GetCurrentGameLanguage();
			string text2 = "ERROR. Steam Language " + currentGameLanguage2 + " has no mapping";
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
		}
		SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
		ConfigSaveFile config = saveManager.config;
		ConfigSettingsExtra otherSettings = config.otherSettings;
		if (otherSettings.lastSteamLanguage != text)
		{
			SetLocale(text);
			SaveManager saveManager2 = SaveManager._003CInstance_003Ek__BackingField;
			ConfigSaveFile config2 = saveManager2.config;
			ConfigSettingsExtra otherSettings2 = config2.otherSettings;
			otherSettings2.lastSteamLanguage = text;
		}
	}

	public static void SetSystemLanguage()
	{
		//IL_00bc: Expected O, but got I4
		//IL_01f1: Expected O, but got I4
		//IL_021c: Expected O, but got I4
		//IL_0229: Expected O, but got I8
		//IL_0243: Expected O, but got I8
		bool flag = !SteamManager.initialized;
		string text = null;
		if (!flag)
		{
			string currentGameLanguage = SteamApps.GetCurrentGameLanguage();
			string steamLang = currentGameLanguage.ToLowerInvariant();
			string text2 = MapSteamLangToLocale(steamLang);
			if (string.IsNullOrEmpty(text2))
			{
				string currentGameLanguage2 = SteamApps.GetCurrentGameLanguage();
				string message = "ERROR. Steam Language " + currentGameLanguage2 + " has no mapping";
				Debug.LogError(message);
				object obj = 0;
				string text3 = " has no mapping";
			}
			SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
			ConfigSaveFile config = saveManager.config;
			ConfigSettingsExtra otherSettings = config.otherSettings;
			otherSettings.lastSteamLanguage = text2;
			text = text2;
		}
		if (!string.IsNullOrEmpty(text))
		{
			goto IL_02b9;
		}
		SystemLanguage systemLanguage = Application.systemLanguage;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1831730BF]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		if (systemLanguage <= SystemLanguage.English)
		{
			goto IL_024d;
		}
		if (systemLanguage == SystemLanguage.French)
		{
			text = "fr";
		}
		else
		{
			if (systemLanguage != SystemLanguage.German)
			{
				object obj2 = systemLanguage - 21;
				if ((nint)obj2 <= 20)
				{
					object obj3 = systemLanguage - 21;
					object obj4 = 6442450944L;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v298 @ rdx_v10+56AE08+v523 @ rax_v24*4]");
					object obj5 = 0 + 6442450944L;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v301 @ rax_v26 (should have been resolved before IL gen)");
					goto IL_024d;
				}
				goto IL_0273;
			}
			text = "de";
		}
		goto IL_0312;
		IL_02b9:
		if (!string.IsNullOrEmpty(text))
		{
			SetLocale(text);
		}
		return;
		IL_024d:
		bool flag2 = systemLanguage == SystemLanguage.Czech;
		text = "cs";
		if (!flag2)
		{
			goto IL_0273;
		}
		goto IL_0312;
		IL_0312:
		if (string.IsNullOrEmpty(text))
		{
			string currentGameLanguage3 = SteamApps.GetCurrentGameLanguage();
			string message2 = "ERROR. OS Language " + currentGameLanguage3 + " has no mapping";
			Debug.LogError(message2);
		}
		goto IL_02b9;
		IL_0273:
		text = "en";
		goto IL_0312;
	}

	private unsafe static void SetLocale(string loc)
	{
		//IL_0049: Expected O, but got Ref
		_003C_003Ec__DisplayClass6_0 CS_0024_003C_003E8__locals4 = new _003C_003Ec__DisplayClass6_0();
		CS_0024_003C_003E8__locals4.loc = loc;
		ILocalesProvider availableLocales = LocalizationSettings.AvailableLocales;
		LocaleIdentifier localeIdentifier = CS_0024_003C_003E8__locals4.loc;
		object obj = default(object);
		Locale locale = availableLocales.GetLocale((LocaleIdentifier)(&obj));
		if (!(locale != null))
		{
			string message = "Locale not found for code '" + CS_0024_003C_003E8__locals4.loc + "'";
			Debug.LogError(message);
			return;
		}
		LocalizationSettings.SelectedLocale = locale;
		ILocalesProvider availableLocales2 = LocalizationSettings.AvailableLocales;
		List<Locale> locales = availableLocales2.Locales;
		Predicate<Locale> match = (Predicate<object>)delegate(Locale l)
		{
			//IL_0048: Expected I4, but got O
			if ((object)l == null)
			{
				NullReferenceException ex = new NullReferenceException();
				return (byte)(int)ex != 0;
			}
			return (string)l.m_Identifier == CS_0024_003C_003E8__locals4.loc;
		};
		int language = locales.FindIndex(match);
		SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
		ConfigSaveFile config = saveManager.config;
		CFGameSettings cfGameSettings = config.cfGameSettings;
		cfGameSettings.language = language;
	}

	private static string MapSteamLangToLocale(string steamLang)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1831730BE]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1804BF510");
		object obj = default(object);
		string text;
		if ((long)obj > 2499415067L)
		{
			if ((long)obj > 3222531841L)
			{
				if ((long)obj > 3405445907L)
				{
					if ((long)obj == 3719199419L)
					{
						if (steamLang == "spanish")
						{
							return "es";
						}
					}
					else if ((long)obj == 3739448251L)
					{
						if (steamLang == "turkish")
						{
							return "tr";
						}
					}
					else if ((long)obj == 3759690811L && steamLang == "thai")
					{
						return "th";
					}
				}
				else if ((long)obj == 3264533134L)
				{
					if (steamLang == "tchinese")
					{
						return "zh-Hant";
					}
				}
				else if ((long)obj == 3405445907L && steamLang == "german")
				{
					return "de";
				}
			}
			else if ((long)obj > 2805355685L)
			{
				if ((long)obj != 3180870988L)
				{
					if ((long)obj == 3210859552L)
					{
						if (!(steamLang == "koreana"))
						{
							goto IL_02e1;
						}
					}
					else if ((long)obj != 3222531841L || !(steamLang == "korean"))
					{
						goto IL_02e1;
					}
					return "ko";
				}
				if (steamLang == "polish")
				{
					return "pl";
				}
			}
			else if ((long)obj == 2798875500L)
			{
				if (steamLang == "czech")
				{
					return "cs";
				}
			}
			else if ((long)obj == 2805355685L && steamLang == "schinese")
			{
				return "zh-Hans";
			}
		}
		else if ((nint)obj > 683056061)
		{
			if ((nint)obj > 1580935484)
			{
				if ((nint)obj == 1901528810)
				{
					if (steamLang == "japanese")
					{
						return "ja";
					}
				}
				else if ((long)obj == 2471602315L)
				{
					if (steamLang == "italian")
					{
						return "it";
					}
				}
				else if ((long)obj == 2499415067L && steamLang == "english")
				{
					return "en";
				}
			}
			else if ((nint)obj == 1262725376)
			{
				if (steamLang == "latam")
				{
					return "es-419";
				}
			}
			else if ((nint)obj == 1580935484)
			{
				text = "portuguese";
				goto IL_0711;
			}
		}
		else if ((nint)obj > 505713757)
		{
			if ((nint)obj == 599131013)
			{
				if (steamLang == "french")
				{
					return "fr";
				}
			}
			else if ((nint)obj == 683056061 && steamLang == "ukrainian")
			{
				return "uk";
			}
		}
		else if ((nint)obj == 380651494)
		{
			if (steamLang == "russian")
			{
				return "ru";
			}
		}
		else if ((nint)obj == 505713757)
		{
			text = "brazilian";
			goto IL_0711;
		}
		goto IL_02e1;
		IL_0711:
		if (steamLang == text)
		{
			return "pt";
		}
		goto IL_02e1;
		IL_02e1:
		return null;
	}

	private static string MapSystemLangToLocale(SystemLanguage lang)
	{
		//IL_008d: Expected O, but got I4
		//IL_00b8: Expected O, but got I4
		//IL_00c5: Expected O, but got I8
		//IL_00df: Expected O, but got I8
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1831730BF]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		if (lang > SystemLanguage.English)
		{
			if (lang == SystemLanguage.French)
			{
				return "fr";
			}
			if (lang == SystemLanguage.German)
			{
				return "de";
			}
			object obj = lang - 21;
			if ((nint)obj > 20)
			{
				goto IL_010f;
			}
			object obj2 = lang - 21;
			object obj3 = 6442450944L;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ rdx_v1+56A334+v145 @ rax_v7*4]");
			object obj4 = 0 + 6442450944L;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v125 @ rax_v9 (should have been resolved before IL gen)");
		}
		bool flag = lang == SystemLanguage.Czech;
		string result = "cs";
		if (!flag)
		{
			goto IL_010f;
		}
		goto IL_013d;
		IL_010f:
		result = "en";
		goto IL_013d;
		IL_013d:
		return result;
	}
}
