using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Assets.Scripts.Saves___Serialization.Progression.Stats;
using Assets.Scripts.Saves___Serialization.Progression.Unlocks;
using Assets.Scripts.Settings___Saves.SaveFiles;
using Assets.Scripts.Settings___Saves.SaveFiles.ConfigSaves;
using Assets.Scripts.UI;
using Assets.Scripts.UI.Localization;
using Assets.Scripts.UI.Menu.Windows;
using Cpp2ILInjected;
using Rewired;
using Rewired.Interfaces;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Components;
using UnityEngine.Localization.Tables;

public class Settings : MonoBehaviour
{
	private sealed class _003C_003Ec__DisplayClass30_0
	{
		public int index;

		public Predicate<SettingHeader> _003C_003E9__0;

		internal bool _003CCreateGenericSettings_003Eb__0(SettingHeader h)
		{
			//IL_0053: Expected I4, but got O
			//IL_0031: Expected O, but got I4
			if (h != null)
			{
				object obj = h.index - index;
				return obj == null;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	public GameObject enumPrefab;

	public GameObject sliderPrefab;

	public GameObject resolutionPrefab;

	public GameObject controlPrefab;

	public GameObject controlPrefabNew;

	public GameObject controllerDisplayPrefab;

	public GameObject headerPrefab;

	public GameObject languagePrefab;

	public Transform videoContent;

	public Transform gameContent;

	public Transform audioContent;

	public Transform controlContent;

	public Transform visualsContent;

	public Transform otherContent;

	public List<BetterSetting> settings;

	public GameObject resolutionWindow;

	public Window settingsWindow;

	public GameObject btn_resetSettings;

	public GameObject b_resetControls;

	public TabsExplicitNavigation gameContentNav;

	public TabsExplicitNavigation settingsNav;

	public static Action A_ResetRewiredControls;

	public static Settings Instance;

	public LocalizedString localizedSyncAchievementsHeader;

	public LocalizedString localizedSyncAchievementsPrompt;

	private void Awake()
	{
		//IL_01ea: Expected O, but got I4
		//IL_0200: Expected I, but got O
		//IL_0226: Expected O, but got I4
		//IL_023c: Expected I, but got O
		//IL_0157: Expected I, but got O
		//IL_0286: Expected O, but got I4
		//IL_01c8: Expected I, but got O
		if (!Instance)
		{
			Instance = this;
			Action b = OnResButtonClicked;
			Delegate obj = Delegate.Combine(MyButtonSettingRes.A_Clicked, b);
			object obj3;
			Delegate obj4;
			if ((object)obj == null)
			{
				MyButtonSettingRes.A_Clicked = null;
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
				obj3 = 0;
				obj4 = obj;
				nint num = (nint)typeof(Action);
				if (flag2)
				{
					goto IL_0290;
				}
				MyButtonSettingRes.A_Clicked = (Action)obj2;
				bool flag3 = (object)obj.GetType() != typeof(Action);
				Delegate obj5 = null;
				if (!flag3)
				{
					obj5 = obj;
				}
				bool flag4 = (object)obj5 == null;
				obj3 = 0;
				obj4 = obj;
				nint num2 = (nint)typeof(Action);
				if (flag4)
				{
					goto IL_029b;
				}
			}
			Action<int> b2 = OnResChanged;
			Delegate obj6 = Delegate.Combine(CurrentSettings.A_ResolutionChanged, b2);
			if ((object)obj6 == null)
			{
				CurrentSettings.A_ResolutionChanged = null;
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<int> action = default(Action<int>);
			bool flag5 = action == null;
			nint num3 = (nint)typeof(Action<int>);
			if (!flag5)
			{
				CurrentSettings.A_ResolutionChanged = action;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
				object obj7 = default(object);
				if (obj7 != null)
				{
					return;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				num3 = (nint)typeof(Action<int>);
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			obj3 = 0;
			obj4 = null;
			goto IL_029b;
		}
		GameObject obj8 = base.gameObject;
		UnityEngine.Object.Destroy(obj8);
		return;
		IL_029b:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0290;
		IL_0290:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	private void Start()
	{
		if (Instance == this)
		{
			UpdateSettings();
		}
		settingsWindow.FindAllButtonsInWindow();
	}

	private void OnEnable()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18317208C]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		Invoke("Rebuild", 0.01f);
	}

	private void Rebuild()
	{
		Transform root = base.transform;
		UiUtility.RebuildUi(root);
	}

	private void OnDisable()
	{
		SaveManager._003CInstance_003Ek__BackingField.SaveConfig();
		if (KeyListener.hasChangedKey)
		{
			KeyListener.hasChangedKey = false;
			if (ReInput.iDoaxepFyYCUwmDGjxXRIVvgLboF)
			{
				IUserDataStore userDataStore = ReInput.userDataStore;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002530");
			}
		}
	}

	private void OnDestroy()
	{
		//IL_019d: Expected O, but got I4
		//IL_0210: Expected O, but got I4
		//IL_0226: Expected I, but got O
		//IL_0119: Expected O, but got I4
		//IL_016d: Expected O, but got I4
		Delegate a_Clicked = MyButtonSettingRes.A_Clicked;
		Action action = OnResButtonClicked;
		Delegate obj = Delegate.Remove(MyButtonSettingRes.A_Clicked, action);
		Action action2;
		object obj3;
		Delegate obj4;
		if ((object)obj == null)
		{
			MyButtonSettingRes.A_Clicked = null;
		}
		else
		{
			bool flag = (object)obj.GetType() != typeof(Action);
			Delegate obj2 = null;
			if (!flag)
			{
				obj2 = obj;
			}
			if ((object)obj2 == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				action2 = action;
				obj3 = 0;
				obj4 = obj;
				goto IL_026c;
			}
			MyButtonSettingRes.A_Clicked = (Action)obj2;
			bool flag2 = (object)obj.GetType() != typeof(Action);
			Delegate obj5 = null;
			if (!flag2)
			{
				obj5 = obj;
			}
			bool flag3 = (object)obj5 == null;
			obj3 = 0;
			obj4 = obj;
			nint num = (nint)typeof(Action);
			if (flag3)
			{
				goto IL_027c;
			}
		}
		Action<int> value = OnResChanged;
		Delegate obj6 = Delegate.Remove(CurrentSettings.A_ResolutionChanged, value);
		if ((object)obj6 == null)
		{
			CurrentSettings.A_ResolutionChanged = null;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<int> action3 = default(Action<int>);
		bool flag4 = action3 == null;
		a_Clicked = (Delegate)(object)typeof(Action<int>);
		action2 = (Action)obj6;
		obj3 = 0;
		obj4 = null;
		if (flag4)
		{
			goto IL_025c;
		}
		CurrentSettings.A_ResolutionChanged = action3;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		object obj7 = default(object);
		bool flag5 = obj7 == null;
		a_Clicked = (Delegate)(object)typeof(Action<int>);
		action2 = (Action)obj6;
		obj3 = 0;
		obj4 = null;
		if (!flag5)
		{
			return;
		}
		goto IL_026c;
		IL_026c:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_025c;
		IL_027c:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_025c:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_027c;
	}

	private void UpdateSettings()
	{
		Action<string, object, CFSettings> saveAction = CurrentSettings.Instance.BetterUpdateCfSettings;
		SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
		ConfigSaveFile config = saveManager.config;
		CreateGenericSettings(saveAction, gameContent, config.cfGameSettings);
		Action<string, object, CFSettings> saveAction2 = CurrentSettings.Instance.BetterUpdateCfSettings;
		SaveManager saveManager2 = SaveManager._003CInstance_003Ek__BackingField;
		ConfigSaveFile config2 = saveManager2.config;
		CreateGenericSettings(saveAction2, videoContent, config2.cfVideoSettings);
		Action<string, object, CFSettings> saveAction3 = CurrentSettings.Instance.BetterUpdateCfSettings;
		SaveManager saveManager3 = SaveManager._003CInstance_003Ek__BackingField;
		ConfigSaveFile config3 = saveManager3.config;
		CreateGenericSettings(saveAction3, controlContent, config3.cfControlSettings);
		Action<string, object, CFSettings> saveAction4 = CurrentSettings.Instance.BetterUpdateCfSettings;
		SaveManager saveManager4 = SaveManager._003CInstance_003Ek__BackingField;
		ConfigSaveFile config4 = saveManager4.config;
		CreateGenericSettings(saveAction4, audioContent, config4.cfAudioSettings);
		Action<string, object, CFSettings> saveAction5 = CurrentSettings.Instance.BetterUpdateCfSettings;
		SaveManager saveManager5 = SaveManager._003CInstance_003Ek__BackingField;
		ConfigSaveFile config5 = saveManager5.config;
		CreateGenericSettings(saveAction5, visualsContent, config5.cfVisualsSettings);
		Action<string, object, CFSettings> saveAction6 = CurrentSettings.Instance.BetterUpdateCfSettings;
		SaveManager saveManager6 = SaveManager._003CInstance_003Ek__BackingField;
		ConfigSaveFile config6 = saveManager6.config;
		CreateGenericSettings(saveAction6, otherContent, config6.cfOtherSettings);
		Transform transform = btn_resetSettings.transform;
		int childCount = gameContent.childCount;
		int siblingIndex = childCount - 1;
		transform.SetSiblingIndex(siblingIndex);
		Transform transform2 = b_resetControls.transform;
		int childCount2 = controlContent.childCount;
		int siblingIndex2 = childCount2 - 1;
		transform2.SetSiblingIndex(siblingIndex2);
		gameContentNav.Refresh();
		settingsNav.Refresh();
	}

	private unsafe void CreateGenericSettings(Action<string, object, CFSettings> saveAction, Transform contentParent, CFSettings cfSettings)
	{
		//IL_0054: Expected O, but got I4
		//IL_0065: Expected O, but got I4
		//IL_0252: Expected I, but got O
		//IL_0378: Unknown result type (might be due to invalid IL or missing references)
		//IL_037d: Expected O, but got Unknown
		//IL_032d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0332: Expected O, but got Unknown
		//IL_01c9: Expected O, but got Ref
		//IL_01ed: Expected O, but got Ref
		_003C_003Ec__DisplayClass30_0 CS_0024_003C_003E8__locals9 = new _003C_003Ec__DisplayClass30_0();
		List<SettingHeader> headers = cfSettings.GetHeaders();
		CS_0024_003C_003E8__locals9.index = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_is_inst\"");
		Type type = default(Type);
		FieldInfo[] fields = type.GetFields();
		object obj = 0;
		List<SettingHeader> list = headers;
		object obj2 = 0;
		CFSettings cFSettings = cfSettings;
		string tableCollectionName = default(string);
		long keyId = default(long);
		while ((nint)obj2 < fields.Length)
		{
			Predicate<SettingHeader> match = CS_0024_003C_003E8__locals9._003C_003E9__0;
			FieldInfo fieldInfo = fields[obj];
			if (CS_0024_003C_003E8__locals9._003C_003E9__0 == null)
			{
				match = (CS_0024_003C_003E8__locals9._003C_003E9__0 = (Predicate<object>)delegate(SettingHeader h)
				{
					//IL_0053: Expected I4, but got O
					//IL_0031: Expected O, but got I4
					if (h == null)
					{
						NullReferenceException ex = new NullReferenceException();
						return (byte)(int)ex != 0;
					}
					object obj3 = h.index - CS_0024_003C_003E8__locals9.index;
					return obj3 == null;
				});
			}
			SettingHeader settingHeader = list.Find(match);
			if (settingHeader != null)
			{
				GameObject gameObject = UnityEngine.Object.Instantiate(headerPrefab, contentParent);
				SettingsHeaderMonoObject component = gameObject.GetComponent<SettingsHeaderMonoObject>();
				component.settingHeader = settingHeader;
				LocalizeStringEvent componentInChildren = gameObject.GetComponentInChildren<LocalizeStringEvent>();
				if (!(componentInChildren != null))
				{
					Debug.LogWarning("No LocalizeStringEvent found on prefab.");
				}
				else
				{
					LocalizedString localizedString = new LocalizedString();
					TableReference tableReference = "SettingsHeaders";
					localizedString.TableReference = (TableReference)(&tableCollectionName);
					TableEntryReference tableEntryReference = settingHeader.header;
					localizedString.TableEntryReference = (TableEntryReference)(&keyId);
					componentInChildren.StringReference = localizedString;
					componentInChildren.RefreshString();
					keyId = tableEntryReference.m_KeyId;
					tableCollectionName = tableReference.m_TableCollectionName;
				}
				cFSettings = cfSettings;
			}
			string text = fields[obj].Name;
			nint num = (nint)fieldInfo;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v160 @ r9_v6 (Il2CppClass<Assets.Scripts.Settings___Saves.SaveFiles.CFSettings>)+2D8] (should have been resolved before IL gen)");
			SettingType settingType = ConfigSettingsUtility.GetSettingType(fields[obj]);
			GameObject settingPrefab = GetSettingPrefab(settingType);
			GameObject gameObject2 = UnityEngine.Object.Instantiate(settingPrefab, contentParent);
			BetterSetting component2 = gameObject2.GetComponent<BetterSetting>();
			settings.Add(component2);
			BetterSetting component3 = gameObject2.GetComponent<BetterSetting>();
			if (component3 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002B10");
				int index = CS_0024_003C_003E8__locals9.index + 1;
				CS_0024_003C_003E8__locals9.index = index;
				obj++;
				list = headers;
				obj2 = obj;
				cFSettings = cfSettings;
			}
			else
			{
				int index2 = CS_0024_003C_003E8__locals9.index + 1;
				CS_0024_003C_003E8__locals9.index = index2;
				obj++;
				list = headers;
				obj2 = obj;
				cFSettings = cfSettings;
			}
		}
		TabsExplicitNavigation component4 = contentParent.GetComponent<TabsExplicitNavigation>();
		component4.Refresh();
	}

	private GameObject GetSettingPrefab(SettingType settingType)
	{
		//IL_002a: Expected O, but got I8
		//IL_0044: Expected O, but got I8
		if (settingType <= SettingType.ControllerDisplay)
		{
			object obj = 6442450944L;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v15 @ r8_v2+373E24+settingType @ rdx (Assets.Scripts.Settings___Saves.SaveFiles.SettingType)*4]");
			object obj2 = 0 + 6442450944L;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v17 @ rdx_v4 (should have been resolved before IL gen)");
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
		Exception ex = new Exception("OK MAN");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
		throw ex;
	}

	public void TryResetSaveFile()
	{
		AlwaysUi instance = AlwaysUi.Instance;
		string localizedString = LocalizationUtility.GetLocalizedString("MainMenuOther", "WARNING");
		string localizedString2 = LocalizationUtility.GetLocalizedString("DynamicWindows", "RESET_SAVE_FILE");
		Action a_Accept = ResetSaveFile;
		instance.dynamicWindows.NewWindowPrompt(localizedString, localizedString2, a_Accept);
	}

	public unsafe void ResetControls()
	{
		//IL_0064: Expected O, but got Ref
		//IL_006c: Expected O, but got Ref
		//IL_043d: Expected I, but got O
		//IL_046e: Expected I, but got O
		//IL_0476: Expected O, but got I
		//IL_0312: Expected I, but got O
		//IL_00f7: Expected I, but got O
		//IL_00ff: Expected I, but got O
		//IL_012e: Expected I, but got O
		//IL_013c: Expected I, but got O
		//IL_0187: Expected I, but got O
		//IL_0195: Expected I, but got O
		//IL_01ce: Expected I, but got O
		//IL_01dc: Expected I, but got O
		//IL_0218: Expected I, but got O
		//IL_0226: Expected I, but got O
		//IL_0262: Expected I, but got O
		//IL_0270: Expected I, but got O
		//IL_0290: Expected I4, but got O
		//IL_029e: Expected I, but got O
		Type typeFromHandle = Type.GetTypeFromHandle((RuntimeTypeHandle)typeof(ControllerType));
		Array values = Enum.GetValues(typeFromHandle);
		bool flag = values == null;
		Type type = typeFromHandle;
		Player.ControllerHelper.MapHelper maps;
		if (!flag)
		{
			IEnumerator enumerator = values.GetEnumerator();
			IEnumerator enumerator2 = default(IEnumerator);
			object obj = (object)(&enumerator2);
			object obj3 = default(object);
			object obj2 = (object)(&obj3);
			object obj4 = default(object);
			object obj5 = default(object);
			nint num4;
			while (true)
			{
				if (enumerator2 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002470");
					if (obj4 == null)
					{
						break;
					}
					bool flag2 = enumerator2 == null;
					Array array = null;
					if (!flag2)
					{
						object current = enumerator2.Current;
						if (current != null)
						{
							nint num = (nint)typeof(ControllerType);
							nint num2 = (nint)current;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v382 @ rdx_v25 (Il2CppClass<System.Object>)+40]");
							nint num3 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v371 @ r8_v15 (Il2CppClass<Rewired.ControllerType>)+40]");
							bool flag3 = num3 != 0;
							num4 = (nint)typeof(ControllerType);
							nint num5 = (nint)typeof(IEnumerator);
							ReInput.PlayerHelper playerHelper = (ReInput.PlayerHelper)current;
							if (!flag3)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_object_unbox\"");
								ReInput.PlayerHelper players = ReInput.players;
								bool flag4 = players == null;
								num4 = (nint)typeof(ControllerType);
								num5 = (nint)typeof(IEnumerator);
								playerHelper = null;
								if (!flag4)
								{
									Player player = players.GetPlayer(0);
									bool flag5 = player == null;
									num4 = unchecked((nint)null);
									num5 = (nint)typeof(IEnumerator);
									playerHelper = players;
									if (!flag5)
									{
										Player.ControllerHelper controllers = player.controllers;
										bool flag6 = player.controllers == null;
										num4 = unchecked((nint)null);
										num5 = (nint)typeof(IEnumerator);
										playerHelper = players;
										if (!flag6)
										{
											maps = controllers.maps;
											bool flag7 = controllers.maps == null;
											num4 = unchecked((nint)null);
											num5 = (nint)typeof(IEnumerator);
											if (!flag7)
											{
												controllers.maps.LoadDefaultMaps((ControllerType)obj5);
												num5 = (nint)typeof(IEnumerator);
												continue;
											}
											playerHelper = (ReInput.PlayerHelper)(object)maps;
											throw new NullReferenceException();
										}
										throw new NullReferenceException();
									}
									throw new NullReferenceException();
								}
								throw new NullReferenceException();
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
						}
						throw new NullReferenceException();
					}
					throw new NullReferenceException();
				}
				throw new NullReferenceException();
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			IEnumerator enumerator3 = default(IEnumerator);
			obj2 = enumerator3;
			bool flag8 = enumerator3 == null;
			IEnumerator enumerator4 = enumerator2;
			if (!flag8)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002530");
				enumerator4 = enumerator3;
			}
			nint num6 = (nint)typeof(AudioManager);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v650 @ rax_v30 (Il2CppClass<AudioManager>)+B8]");
			nint num7 = 0;
			AudioManager instance = AudioManager.Instance;
			bool flag9 = (object)AudioManager.Instance == null;
			num4 = (nint)enumerator4;
			type = (Type)num7;
			if (!flag9)
			{
				bool flag10 = (object)instance.uiAbort == null;
				num4 = (nint)enumerator4;
				type = (Type)(object)instance.uiAbort;
				if (!flag10)
				{
					instance.uiAbort.Play();
					RefreshSettings();
					KeyListener.hasChangedKey = true;
					Action a_ResetRewiredControls = A_ResetRewiredControls;
					if (A_ResetRewiredControls != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v679.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
					}
					return;
				}
			}
		}
		maps = (Player.ControllerHelper.MapHelper)(object)type;
		throw new NullReferenceException();
	}

	private void ResetSaveFile()
	{
		SaveManager._003CInstance_003Ek__BackingField.NewSaveConfig();
		CurrentSettings.Instance.UpdateSave();
		RefreshSettings();
		AudioManager instance = AudioManager.Instance;
		instance.uiAbort.Play();
	}

	public unsafe void RefreshSettings()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126F30");
		List<object>.Enumerator enumerator = default(List<object>.Enumerator);
		UnityEngine.Object obj = default(UnityEngine.Object);
		while (true)
		{
			if (enumerator.MoveNext())
			{
				if (obj != null)
				{
					if ((object)obj == null)
					{
						break;
					}
					((BetterSetting)obj).UpdateValue();
				}
				continue;
			}
			((List<BetterSetting>.Enumerator*)(&enumerator))->Dispose();
			return;
		}
		throw new NullReferenceException();
	}

	public void SyncSteamAchievements()
	{
		AlwaysUi instance = AlwaysUi.Instance;
		string localizedString = localizedSyncAchievementsHeader.GetLocalizedString();
		string localizedString2 = localizedSyncAchievementsPrompt.GetLocalizedString();
		Action a_Accept = SyncAchievements;
		instance.dynamicWindows.NewWindowPrompt(localizedString, localizedString2, a_Accept);
	}

	private void SyncAchievements()
	{
		MyAchievements.SyncToSteamAchievements();
		MyStats.SynToSteamStats();
	}

	private void OnResButtonClicked()
	{
		AlwaysUi instance = AlwaysUi.Instance;
		instance.resolutionWindow.SetActive(value: true);
	}

	private void OnResChanged(int resIndex)
	{
		RefreshSettings();
	}

	public Settings()
	{
		List<BetterSetting> list = new List<BetterSetting>();
		settings = list;
		base._002Ector();
	}
}
