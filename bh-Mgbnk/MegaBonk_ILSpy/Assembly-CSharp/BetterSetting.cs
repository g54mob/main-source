using System;
using System.Collections.Generic;
using System.Reflection;
using Assets.Scripts.Settings___Saves.SaveFiles;
using Assets.Scripts.Settings___Saves.SaveFiles.ConfigSaves;
using Cpp2ILInjected;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

public abstract class BetterSetting : MonoBehaviour
{
	protected int value;

	protected int settingType;

	protected string[] options;

	public TextMeshProUGUI settingName;

	private string description;

	private Settings settings;

	public GameObject disabledOverlay;

	public TextMeshProUGUI t_disabledText;

	private bool hasSubscribed;

	private RectTransform rectTransform;

	private bool subscribed;

	private Action<string, object, CFSettings> saveAction;

	protected string _settingName;

	protected object _settingValue;

	private CFSettings cfSettings;

	private HashSet<string> hiddenSettings;

	private HashSet<string> advancedSettings;

	private bool mouseOver;

	protected void Awake()
	{
		//IL_0089: Expected I, but got O
		//IL_009a: Expected O, but got I4
		//IL_00a3: Expected O, but got I4
		//IL_00e1: Expected I, but got O
		//IL_00f2: Expected O, but got I4
		//IL_00fb: Expected O, but got I4
		//IL_0112: Expected O, but got I4
		//IL_011b: Expected O, but got I4
		RectTransform component = GetComponent<RectTransform>();
		rectTransform = component;
		nint num;
		Delegate obj2;
		if (!subscribed)
		{
			subscribed = true;
			Action<Locale> action = OnLocaleChanged;
			LocalizationSettings.SelectedLocaleChanged += action;
			Action<string, object, object> b = OnSettingUpdated;
			Delegate obj = Delegate.Combine(CurrentSettings.A_SettingUpdated, b);
			object obj3;
			object obj4;
			if ((object)obj == null)
			{
				CurrentSettings.A_SettingUpdated = (Action<string, object, object>)obj;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
				Action<string, object, object> action2 = default(Action<string, object, object>);
				bool flag = action2 == null;
				num = (nint)typeof(Action<string, object, object>);
				obj2 = obj;
				obj3 = 0;
				obj4 = 0;
				if (flag)
				{
					goto IL_01a2;
				}
				CurrentSettings.A_SettingUpdated = action2;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
				object obj5 = default(object);
				bool flag2 = obj5 == null;
				num = (nint)typeof(Action<string, object, object>);
				obj2 = obj;
				obj3 = 0;
				obj4 = 0;
				if (flag2)
				{
					goto IL_01b2;
				}
			}
			obj3 = 0;
			obj4 = 0;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 168 Invalid \"Jump target not found in method: 0x180364230\"");
		IntPtr intPtr = default(IntPtr);
		num = intPtr;
		Delegate obj6 = default(Delegate);
		obj2 = obj6;
		goto IL_01a2;
		IL_01b2:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_01a2:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_01b2;
	}

	private void TrySubscribe()
	{
		//IL_00e0: Expected I, but got O
		//IL_00b9: Expected I, but got O
		if (subscribed)
		{
			return;
		}
		subscribed = true;
		Action<Locale> action = OnLocaleChanged;
		LocalizationSettings.SelectedLocaleChanged += action;
		Action<string, object, object> b = OnSettingUpdated;
		Delegate obj = Delegate.Combine(CurrentSettings.A_SettingUpdated, b);
		if ((object)obj == null)
		{
			CurrentSettings.A_SettingUpdated = (Action<string, object, object>)obj;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<string, object, object> action2 = default(Action<string, object, object>);
		if (action2 != null)
		{
			CurrentSettings.A_SettingUpdated = action2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj2 = default(object);
			bool flag = obj2 == null;
			nint num = (nint)typeof(Action<string, object, object>);
			if (!flag)
			{
				return;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			nint num = (nint)typeof(Action<string, object, object>);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	private void Start()
	{
		Locale selectedLocale = LocalizationSettings.SelectedLocale;
		string text = ConfigSettingsUtility.SettingNameToReadable(_settingName, cfSettings);
		settingName.text = text;
		ShowValue();
		CheckVisibility();
	}

	protected void OnDestroy()
	{
		//IL_00b7: Expected I, but got O
		//IL_008f: Expected I, but got O
		Action<Locale> action = OnLocaleChanged;
		LocalizationSettings.SelectedLocaleChanged -= action;
		Action<string, object, object> action2 = OnSettingUpdated;
		Delegate obj = Delegate.Remove(CurrentSettings.A_SettingUpdated, action2);
		if ((object)obj == null)
		{
			CurrentSettings.A_SettingUpdated = (Action<string, object, object>)obj;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<string, object, object> action3 = default(Action<string, object, object>);
		if (action3 != null)
		{
			CurrentSettings.A_SettingUpdated = action3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj2 = default(object);
			bool flag = obj2 == null;
			nint num = (nint)typeof(Action<string, object, object>);
			if (!flag)
			{
				return;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			nint num = (nint)typeof(Action<string, object, object>);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	private void OnSettingUpdated(string settingName, object oldValue, object newValue)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18317209D]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		if (settingName == "show_advanced_settings")
		{
			CheckVisibility();
		}
	}

	private unsafe void Update()
	{
		//IL_002c: Expected O, but got Ref
		//IL_010c: Invalid comparison between F4 and I4
		//IL_0135: Expected O, but got I4
		Rect rect = rectTransform.rect;
		Vector3 mousePosition = Input.mousePosition;
		object obj = default(object);
		Vector3 vector = rectTransform.InverseTransformPoint((Vector3)(&obj));
		bool flag;
		if (!(vector.x < rect.m_XMin))
		{
			float num = rect.m_Width + rect.m_XMin;
			if (num > vector.x && !(vector.y < rect.m_YMin))
			{
				flag = mouseOver;
				float num2 = rect.m_Height + rect.m_YMin;
				bool flag2 = num2 < vector.y;
				float num3 = num2 - vector.y;
				bool flag3 = num3 == 0f;
				bool flag4 = !flag2;
				bool flag5 = !flag3;
				object obj2 = flag5 & flag4;
				if (obj2 != null)
				{
					if (!mouseOver)
					{
						mouseOver = true;
					}
					return;
				}
				goto IL_0191;
			}
		}
		flag = mouseOver;
		goto IL_0191;
		IL_0191:
		if (flag)
		{
			mouseOver = false;
		}
	}

	public virtual void SetSetting(Action<string, object, CFSettings> saveAction, string settingName, object currentValue, Settings settings, CFSettings cfSettings)
	{
		this.saveAction = saveAction;
		_settingName = settingName;
		_settingValue = currentValue;
		Settings settings2 = default(Settings);
		this.settings = settings2;
		CFSettings cFSettings = default(CFSettings);
		this.cfSettings = cFSettings;
		string[] settingValues = ConfigSettingsUtility.GetSettingValues(settingName);
		options = settingValues;
		string settingDescription = ConfigSettingsUtility.GetSettingDescription(settingName);
		description = settingDescription;
		string text = ConfigSettingsUtility.SettingNameToReadable(settingName, cFSettings);
		this.settingName.text = text;
		OnSetting();
		ShowValue();
		if (_settingName == "fps_limit")
		{
			GameObject gameObject = base.gameObject;
			FpsLimitSetting fpsLimitSetting = gameObject.AddComponent<FpsLimitSetting>();
		}
		if (!(_settingName != "inverted_horizontal_axis") || _settingName == "inverted_vertical_axis")
		{
			GameObject gameObject2 = base.gameObject;
			InvertedSettingTroll invertedSettingTroll = gameObject2.AddComponent<InvertedSettingTroll>();
		}
	}

	private void CheckVisibility()
	{
		//IL_0110: Unknown result type (might be due to invalid IL or missing references)
		//IL_0115: Expected O, but got Unknown
		//IL_0131: Unknown result type (might be due to invalid IL or missing references)
		//IL_0136: Expected I4, but got Unknown
		if (!((HashSet<object>)(object)hiddenSettings).Contains((object)_settingName))
		{
			if (!((HashSet<object>)(object)advancedSettings).Contains((object)_settingName))
			{
				return;
			}
			GameObject gameObject = base.gameObject;
			SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
			bool active;
			if ((object)SaveManager._003CInstance_003Ek__BackingField != null)
			{
				ConfigSaveFile config = saveManager.config;
				if (saveManager.config != null)
				{
					CFGameSettings cfGameSettings = config.cfGameSettings;
					int? num = cfGameSettings.show_advanced_settings;
					active = false;
				}
				else
				{
					object obj = (object)saveManager.config >> 32;
					object obj2 = obj - 1;
					bool flag = obj2 == null;
					active = (byte)((flag & saveManager.config) ? 1 : 0) != 0;
				}
			}
			else
			{
				active = false;
			}
			gameObject.SetActive(active);
		}
		else
		{
			GameObject gameObject2 = base.gameObject;
			gameObject2.SetActive(value: false);
		}
	}

	private void OnLocaleChanged(Locale locale)
	{
		string text = ConfigSettingsUtility.SettingNameToReadable(_settingName, cfSettings);
		settingName.text = text;
		ShowValue();
	}

	private void RefreshLanguage()
	{
		string text = ConfigSettingsUtility.SettingNameToReadable(_settingName, cfSettings);
		settingName.text = text;
		ShowValue();
	}

	public void UpdateValue()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_is_inst\"");
		Type type = default(Type);
		FieldInfo field = type.GetField(_settingName);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1813EC3D0");
		object obj = default(object);
		if (obj != null)
		{
			object settingValue = field.GetValue(cfSettings);
			_settingValue = settingValue;
			string[] settingValues = ConfigSettingsUtility.GetSettingValues(_settingName);
			options = settingValues;
			OnSetting();
			ShowValue();
		}
	}

	public abstract void ControllerInputDir(int dir, float multiplier);

	protected void SaveValue()
	{
		Action<string, object, CFSettings> action = saveAction;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v0 @ r10_v1 (System.Action`3<System.String, System.Object, Assets.Scripts.Settings___Saves.SaveFiles.CFSettings>)+18] (should have been resolved before IL gen)");
	}

	protected virtual void OnSetting()
	{
	}

	protected abstract void ShowValue();

	private void OnMouseEnter()
	{
		mouseOver = true;
	}

	private unsafe void CustomPointerHandler()
	{
		//IL_002c: Expected O, but got Ref
		//IL_010c: Invalid comparison between F4 and I4
		//IL_0135: Expected O, but got I4
		Rect rect = rectTransform.rect;
		Vector3 mousePosition = Input.mousePosition;
		object obj = default(object);
		Vector3 vector = rectTransform.InverseTransformPoint((Vector3)(&obj));
		bool flag;
		if (!(vector.x < rect.m_XMin))
		{
			float num = rect.m_Width + rect.m_XMin;
			if (num > vector.x && !(vector.y < rect.m_YMin))
			{
				flag = mouseOver;
				float num2 = rect.m_Height + rect.m_YMin;
				bool flag2 = num2 < vector.y;
				float num3 = num2 - vector.y;
				bool flag3 = num3 == 0f;
				bool flag4 = !flag2;
				bool flag5 = !flag3;
				object obj2 = flag5 & flag4;
				if (obj2 != null)
				{
					if (!mouseOver)
					{
						mouseOver = true;
					}
					return;
				}
				goto IL_0191;
			}
		}
		flag = mouseOver;
		goto IL_0191;
		IL_0191:
		if (flag)
		{
			mouseOver = false;
		}
	}

	private void CheckExtraScripts()
	{
		if (_settingName == "fps_limit")
		{
			GameObject gameObject = base.gameObject;
			FpsLimitSetting fpsLimitSetting = gameObject.AddComponent<FpsLimitSetting>();
		}
		if (!(_settingName != "inverted_horizontal_axis") || _settingName == "inverted_vertical_axis")
		{
			GameObject gameObject2 = base.gameObject;
			InvertedSettingTroll invertedSettingTroll = gameObject2.AddComponent<InvertedSettingTroll>();
		}
	}

	public void Disable(string disableText)
	{
		disabledOverlay.SetActive(value: true);
		t_disabledText.text = disableText;
	}

	public void Enable()
	{
		disabledOverlay.SetActive(value: false);
	}

	public bool IsDisabled()
	{
		//IL_006a: Expected I4, but got O
		if (disabledOverlay != null)
		{
			if ((object)disabledOverlay != null)
			{
				return disabledOverlay.activeSelf;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
		return false;
	}

	protected BetterSetting()
	{
		HashSet<string> hashSet = (HashSet<string>)(object)new HashSet<object>();
		bool flag = hashSet.Add("pege_mode");
		bool flag2 = hashSet.Add("unlock_all");
		bool flag3 = hashSet.Add("debug_enemy_scaling");
		bool flag4 = hashSet.Add("quick_reset_time");
		hiddenSettings = hashSet;
		HashSet<string> hashSet2 = (HashSet<string>)(object)new HashSet<object>();
		bool flag5 = hashSet2.Add("keyboard_jump_ignore_extra_jumps");
		bool flag6 = hashSet2.Add("space_navigation");
		bool flag7 = hashSet2.Add("show_hud");
		bool flag8 = hashSet2.Add("skip_chest_animation");
		bool flag9 = hashSet2.Add("skip_portal_animation");
		bool flag10 = hashSet2.Add("enable_silver_pots");
		bool flag11 = hashSet2.Add("show_item_feed");
		bool flag12 = hashSet2.Add("super_quick_resets");
		bool flag13 = hashSet2.Add("keyboard_hold_to_wallrun");
		bool flag14 = hashSet2.Add("xp_gold_hud");
		advancedSettings = hashSet2;
		base._002Ector();
	}
}
