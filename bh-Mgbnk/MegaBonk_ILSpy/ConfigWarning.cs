using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Assets.Scripts.Saves___Serialization.SaveFiles;
using Assets.Scripts.Settings___Saves.SaveFiles.ConfigSaves;
using Assets.Scripts.UI;
using Assets.Scripts.UI.Localization;
using Cpp2ILInjected;
using TMPro;
using UnityEngine;

public class ConfigWarning : MonoBehaviour
{
	private sealed class _003CShowWarningCoroutine_003Ed__12 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public ConfigWarning _003C_003E4__this;

		public string filepath;

		public string e;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		public _003CShowWarningCoroutine_003Ed__12(int _003C_003E1__state)
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
			//IL_0067: Expected I4, but got I8
			//IL_02fb: Expected I4, but got O
			//IL_00c6: Expected O, but got I
			//IL_01ee: Expected O, but got I
			//IL_0235: Expected O, but got I
			//IL_02a2: Expected O, but got I
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				_003C_003E2__current = null;
				_003C_003E1__state = 1;
				return true;
			}
			if (_003C_003E1__state == 1)
			{
				Component component = _003C_003E4__this;
				_003C_003E1__state = -1;
				LanguageStartup.SetSystemLanguage();
				if ((object)_003C_003E4__this != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rsi_v1 (UnityEngine.Component)+20]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rsi_v1 (UnityEngine.Component)+20]");
						((GameObject)0).SetActive(value: true);
						_ = filepath;
						Dictionary<string, string> dictionary = new Dictionary<string, string>();
						string[] array = new string[5];
						if (array != null)
						{
							array[0] = "\n\n<color=red><size=85%>";
							array[1] = e;
							array[2] = "\n";
							array[3] = filepath;
							array[4] = "</size></color>";
							string value = string.Concat(array);
							if (dictionary != null)
							{
								((Dictionary<object, object>)(object)dictionary).Add((object)"error", (object)value);
								string localizedString = LocalizationUtility.GetLocalizedString("MainMenuOther", "CONFIG_ERROR_MSG", dictionary);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rsi_v1 (UnityEngine.Component)+28]");
								object obj = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rsi_v1 (UnityEngine.Component)+28]");
								if ((nint)0 != 0)
								{
									object obj2 = obj;
									Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v73 @ r9_v4+558] (should have been resolved before IL gen)");
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rsi_v1 (UnityEngine.Component)+30]");
									object obj3 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rsi_v1 (UnityEngine.Component)+30]");
									if ((nint)0 != 0)
									{
										object obj4 = obj3;
										Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v334 @ rax_v23+1C8] (should have been resolved before IL gen)");
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rsi_v1 (UnityEngine.Component)+30]");
										if ((nint)0 != 0)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rsi_v1 (UnityEngine.Component)+30]");
											((TextSizer)0).Recalculate();
											Transform transform = _003C_003E4__this.transform;
											UiUtility.RebuildUi(transform);
											return false;
										}
									}
								}
							}
						}
					}
				}
				NullReferenceException ex = new NullReferenceException();
				return (byte)(int)ex != 0;
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

	public GameObject overlay;

	public TextMeshProUGUI t_warning;

	public TextSizer textSizer;

	private string configFilePath;

	public static ConfigWarning Instance;

	private void Awake()
	{
		if (!(Instance != null))
		{
			Instance = this;
			return;
		}
		GameObject obj = base.gameObject;
		UnityEngine.Object.Destroy(obj);
	}

	public void OpenFile()
	{
		ExplorerUtility.OpenInFileExplorer(configFilePath);
	}

	public void RefreshFile()
	{
		overlay.SetActive(value: false);
		SaveManager._003CInstance_003Ek__BackingField.Load(loadBackup: false);
	}

	public void LoadBackup()
	{
		overlay.SetActive(value: false);
		SaveManager._003CInstance_003Ek__BackingField.Load(loadBackup: true);
	}

	public void ResetFile()
	{
		AlwaysUi instance = AlwaysUi.Instance;
		string localizedString = LocalizationUtility.GetLocalizedString("MainMenuOther", "WARNING");
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		string fileName = Path.GetFileName(configFilePath);
		((Dictionary<object, object>)(object)dictionary).Add((object)"file", (object)fileName);
		string localizedString2 = LocalizationUtility.GetLocalizedString("MainMenuOther", "CONFIG_ERROR_RESET_WARNING", dictionary);
		Action a_Accept = delegate
		{
			if (File.Exists(configFilePath))
			{
				File.Delete(configFilePath);
			}
			overlay.SetActive(value: false);
			SaveManager._003CInstance_003Ek__BackingField.Load(loadBackup: false);
		};
		instance.dynamicWindows.NewWindowPrompt(localizedString, localizedString2, a_Accept);
	}

	public void IgnoreWarning()
	{
		AlwaysUi instance = AlwaysUi.Instance;
		string localizedString = LocalizationUtility.GetLocalizedString("MainMenuOther", "WARNING");
		string localizedString2 = LocalizationUtility.GetLocalizedString("MainMenuOther", "CONFIG_ERROR_IGNORE_WARNING");
		Action a_Accept = delegate
		{
			overlay.SetActive(value: false);
			SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
			ConfigSaveFile config = new ConfigSaveFile();
			saveManager.config = config;
			ProgressionSaveFile progression = new ProgressionSaveFile();
			saveManager.progression = progression;
			StatsSaveFile stats = new StatsSaveFile();
			saveManager.stats = stats;
			saveManager.config.Init();
			saveManager.progression.Init();
			saveManager.stats.Init();
			SaveManager.loaded = true;
			Action a_SavesLoaded = SaveManager.A_SavesLoaded;
			if (SaveManager.A_SavesLoaded != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v250.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
			saveManager.usingNoSave = true;
		};
		instance.dynamicWindows.NewWindowPrompt(localizedString, localizedString2, a_Accept);
	}

	public void ShowWarning(string e, string filePath)
	{
		_003CShowWarningCoroutine_003Ed__12 obj = new _003CShowWarningCoroutine_003Ed__12(0);
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		obj.e = e;
		obj.filepath = filePath;
		Coroutine coroutine = StartCoroutine(obj);
	}

	private IEnumerator ShowWarningCoroutine(string e, string filepath)
	{
		_003CShowWarningCoroutine_003Ed__12 obj = new _003CShowWarningCoroutine_003Ed__12(0);
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		obj.e = e;
		obj.filepath = filepath;
		return obj;
	}

	public void HideWarning()
	{
		overlay.SetActive(value: false);
	}

	private void _003CResetFile_003Eb__9_0()
	{
		if (File.Exists(configFilePath))
		{
			File.Delete(configFilePath);
		}
		overlay.SetActive(value: false);
		SaveManager._003CInstance_003Ek__BackingField.Load(loadBackup: false);
	}

	private void _003CIgnoreWarning_003Eb__10_0()
	{
		overlay.SetActive(value: false);
		SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
		ConfigSaveFile config = new ConfigSaveFile();
		saveManager.config = config;
		ProgressionSaveFile progression = new ProgressionSaveFile();
		saveManager.progression = progression;
		StatsSaveFile stats = new StatsSaveFile();
		saveManager.stats = stats;
		saveManager.config.Init();
		saveManager.progression.Init();
		saveManager.stats.Init();
		SaveManager.loaded = true;
		Action a_SavesLoaded = SaveManager.A_SavesLoaded;
		if (SaveManager.A_SavesLoaded != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v250.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
		saveManager.usingNoSave = true;
	}
}
