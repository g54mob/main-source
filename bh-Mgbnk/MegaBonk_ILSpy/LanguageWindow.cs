using System;
using System.Collections.Generic;
using System.Reflection;
using Assets.Scripts.Managers;
using Assets.Scripts.Settings___Saves.SaveFiles;
using Assets.Scripts.Settings___Saves.SaveFiles.ConfigSaves;
using Assets.Scripts.UI;
using Assets.Scripts.UI.Localization;
using Cpp2ILInjected;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;

public class LanguageWindow : Window
{
	public GameObject languageButtonPrefab;

	public SelectionGroupToggleSingle selectionGroup;

	private List<SelectionGroupToggleSingleButton> buttons;

	private new void Awake()
	{
		//IL_0237: Expected I, but got O
		//IL_0248: Expected O, but got I4
		//IL_0251: Expected O, but got I4
		//IL_0037: Expected I, but got O
		//IL_0093: Expected I, but got O
		//IL_00a1: Expected I, but got O
		//IL_00b2: Expected O, but got I4
		//IL_00bb: Expected O, but got I4
		//IL_00f5: Expected O, but got I4
		//IL_00fe: Expected O, but got I4
		//IL_0191: Expected I, but got O
		//IL_01a2: Expected O, but got I4
		//IL_01ab: Expected O, but got I4
		//IL_01f5: Expected I, but got O
		//IL_0206: Expected O, but got I4
		//IL_020f: Expected O, but got I4
		Action<MyButton> b = base.OnButtonHover;
		Delegate obj = Delegate.Combine(ButtonManager.A_ButtonHover, b);
		nint num2;
		Delegate obj2;
		object obj3;
		object obj4;
		nint num;
		if ((object)obj == null)
		{
			ButtonManager.A_ButtonHover = (Action<MyButton>)obj;
			num = (nint)ButtonManager.A_ButtonHover;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<MyButton> action = default(Action<MyButton>);
			if (action == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				num2 = (nint)typeof(Action<MyButton>);
				obj2 = obj;
				obj3 = 0;
				obj4 = 0;
				goto IL_02b2;
			}
			ButtonManager.A_ButtonHover = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj5 = default(object);
			bool flag = obj5 == null;
			num = (nint)typeof(Action<MyButton>);
			nint num3 = (nint)typeof(Action<MyButton>);
			obj2 = obj;
			obj3 = 0;
			obj4 = 0;
			if (flag)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				return;
			}
		}
		SelectionGroupToggleSingle selectionGroupToggleSingle = selectionGroup;
		bool flag2 = (object)selectionGroup == null;
		obj2 = obj;
		obj3 = 0;
		obj4 = 0;
		if (flag2)
		{
			goto IL_028e;
		}
		Action<SelectionGroupToggleSingleButton> b2 = OnLanguageSelected;
		Delegate obj6 = Delegate.Combine(selectionGroupToggleSingle.A_ButtonSelected, b2);
		if ((object)obj6 == null)
		{
			selectionGroupToggleSingle.A_ButtonSelected = (Action<SelectionGroupToggleSingleButton>)obj6;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<SelectionGroupToggleSingleButton> action2 = default(Action<SelectionGroupToggleSingleButton>);
		bool flag3 = action2 == null;
		num = (nint)typeof(Action<SelectionGroupToggleSingleButton>);
		obj2 = obj6;
		obj3 = 0;
		obj4 = 0;
		Delegate obj7 = obj6;
		if (flag3)
		{
			goto IL_02a2;
		}
		selectionGroupToggleSingle.A_ButtonSelected = action2;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		object obj8 = default(object);
		bool flag4 = obj8 == null;
		num2 = (nint)typeof(Action<SelectionGroupToggleSingleButton>);
		obj2 = obj6;
		obj3 = 0;
		obj4 = 0;
		if (!flag4)
		{
			return;
		}
		goto IL_02b2;
		IL_02a2:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_028e;
		IL_028e:
		throw new NullReferenceException();
		IL_02b2:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		num = num2;
		obj7 = obj2;
		goto IL_02a2;
	}

	private new void Start()
	{
		FindAllButtonsInWindow();
		Transform root = base.transform;
		UiUtility.RebuildUi(root);
		Action a_WindowOpenedFirstTime = Window.A_WindowOpenedFirstTime;
		if (Window.A_WindowOpenedFirstTime != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v53.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
		SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
		ConfigSaveFile config = saveManager.config;
		CFGameSettings cfGameSettings = config.cfGameSettings;
		selectionGroup.ForceSelect(cfGameSettings.language);
		SelectionGroupToggleSingleButton button = selectionGroup.GetButton(cfGameSettings.language);
		startBtn = button;
		ButtonManager.ForceHoverButton(startBtn);
	}

	private new void OnDestroy()
	{
		//IL_0237: Expected I, but got O
		//IL_0248: Expected O, but got I4
		//IL_0251: Expected O, but got I4
		//IL_0037: Expected I, but got O
		//IL_0093: Expected I, but got O
		//IL_00a1: Expected I, but got O
		//IL_00b2: Expected O, but got I4
		//IL_00bb: Expected O, but got I4
		//IL_00f5: Expected O, but got I4
		//IL_00fe: Expected O, but got I4
		//IL_0191: Expected I, but got O
		//IL_01a2: Expected O, but got I4
		//IL_01ab: Expected O, but got I4
		//IL_01f5: Expected I, but got O
		//IL_0206: Expected O, but got I4
		//IL_020f: Expected O, but got I4
		Action<MyButton> value = base.OnButtonHover;
		Delegate obj = Delegate.Remove(ButtonManager.A_ButtonHover, value);
		nint num2;
		Delegate obj2;
		object obj3;
		object obj4;
		nint num;
		if ((object)obj == null)
		{
			ButtonManager.A_ButtonHover = (Action<MyButton>)obj;
			num = (nint)ButtonManager.A_ButtonHover;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<MyButton> action = default(Action<MyButton>);
			if (action == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				num2 = (nint)typeof(Action<MyButton>);
				obj2 = obj;
				obj3 = 0;
				obj4 = 0;
				goto IL_02b2;
			}
			ButtonManager.A_ButtonHover = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj5 = default(object);
			bool flag = obj5 == null;
			num = (nint)typeof(Action<MyButton>);
			nint num3 = (nint)typeof(Action<MyButton>);
			obj2 = obj;
			obj3 = 0;
			obj4 = 0;
			if (flag)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				return;
			}
		}
		SelectionGroupToggleSingle selectionGroupToggleSingle = selectionGroup;
		bool flag2 = (object)selectionGroup == null;
		obj2 = obj;
		obj3 = 0;
		obj4 = 0;
		if (flag2)
		{
			goto IL_028e;
		}
		Action<SelectionGroupToggleSingleButton> value2 = OnLanguageSelected;
		Delegate obj6 = Delegate.Remove(selectionGroupToggleSingle.A_ButtonSelected, value2);
		if ((object)obj6 == null)
		{
			selectionGroupToggleSingle.A_ButtonSelected = (Action<SelectionGroupToggleSingleButton>)obj6;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<SelectionGroupToggleSingleButton> action2 = default(Action<SelectionGroupToggleSingleButton>);
		bool flag3 = action2 == null;
		num = (nint)typeof(Action<SelectionGroupToggleSingleButton>);
		obj2 = obj6;
		obj3 = 0;
		obj4 = 0;
		Delegate obj7 = obj6;
		if (flag3)
		{
			goto IL_02a2;
		}
		selectionGroupToggleSingle.A_ButtonSelected = action2;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		object obj8 = default(object);
		bool flag4 = obj8 == null;
		num2 = (nint)typeof(Action<SelectionGroupToggleSingleButton>);
		obj2 = obj6;
		obj3 = 0;
		obj4 = 0;
		if (!flag4)
		{
			return;
		}
		goto IL_02b2;
		IL_02a2:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_028e;
		IL_028e:
		throw new NullReferenceException();
		IL_02b2:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		num = num2;
		obj7 = obj2;
		goto IL_02a2;
	}

	private new void OnEnable()
	{
		WindowManager.WindowOpened(this);
		Refresh();
	}

	private unsafe void Refresh()
	{
		//IL_0206: Expected O, but got Ref
		//IL_0254: Expected O, but got I
		//IL_02c8: Expected O, but got Ref
		if (buttons == null)
		{
			List<SelectionGroupToggleSingleButton> list = new List<SelectionGroupToggleSingleButton>();
			buttons = list;
			SelectionGroupToggleSingleButton component = languageButtonPrefab.GetComponent<SelectionGroupToggleSingleButton>();
			buttons.Add(component);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126F30");
		List<object>.Enumerator enumerator = default(List<object>.Enumerator);
		Component component2 = default(Component);
		List<Locale> list2 = default(List<Locale>);
		Navigation navigation = default(Navigation);
		int num3 = default(int);
		while (true)
		{
			if (enumerator.MoveNext())
			{
				if ((object)component2 == null)
				{
					break;
				}
				GameObject gameObject = component2.gameObject;
				gameObject.SetActive(value: false);
				continue;
			}
			((List<SelectionGroupToggleSingleButton>.Enumerator*)(&enumerator))->Dispose();
			ILocalesProvider availableLocales = LocalizationSettings.AvailableLocales;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002470");
			int num = 0;
			for (int num2 = 0; num2 < list2._size; num2 = num)
			{
				List<SelectionGroupToggleSingleButton> list3 = buttons;
				if (num >= list3._size)
				{
					Transform transform = languageButtonPrefab.transform;
					Transform parent = transform.parent;
					GameObject gameObject2 = UnityEngine.Object.Instantiate(languageButtonPrefab, parent);
					SelectionGroupToggleSingleButton component3 = gameObject2.GetComponent<SelectionGroupToggleSingleButton>();
					list3.Add(component3);
					SelectionGroupToggleSingleButton selectionGroupToggleSingleButton = buttons.get_Item(num);
					Button button = selectionGroupToggleSingleButton.GetButton();
					int index = num - 1;
					SelectionGroupToggleSingleButton selectionGroupToggleSingleButton2 = buttons.get_Item(index);
					Button button2 = selectionGroupToggleSingleButton2.GetButton();
					SelectionGroupToggleSingleButton selectionGroupToggleSingleButton3 = buttons.get_Item(num);
					Button button3 = selectionGroupToggleSingleButton3.GetButton();
					button3.navigation = (Navigation)(&navigation);
					int index2 = num - 1;
					SelectionGroupToggleSingleButton selectionGroupToggleSingleButton4 = buttons.get_Item(index2);
					Button button4 = selectionGroupToggleSingleButton4.GetButton();
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v281 @ rax_v39 (UnityEngine.UI.Button)+48]");
					List<object>.Enumerator enumerator2 = (List<object>.Enumerator)0;
					SelectionGroupToggleSingleButton selectionGroupToggleSingleButton5 = buttons.get_Item(num);
					Button button5 = selectionGroupToggleSingleButton5.GetButton();
					int index3 = num - 1;
					SelectionGroupToggleSingleButton selectionGroupToggleSingleButton6 = buttons.get_Item(index3);
					Button button6 = selectionGroupToggleSingleButton6.GetButton();
					button6.navigation = (Navigation)(&num3);
				}
				SelectionGroupToggleSingleButton selectionGroupToggleSingleButton7 = buttons.get_Item(num);
				GameObject gameObject3 = selectionGroupToggleSingleButton7.gameObject;
				gameObject3.SetActive(value: true);
				SelectionGroupToggleSingleButton selectionGroupToggleSingleButton8 = buttons.get_Item(num);
				TextMeshProUGUI componentInChildren = selectionGroupToggleSingleButton8.GetComponentInChildren<TextMeshProUGUI>();
				Locale locale = list2.get_Item(num);
				string languageName = LocalizationUtility.GetLanguageName(locale);
				componentInChildren.text = languageName;
				num++;
			}
			return;
		}
		throw new NullReferenceException();
	}

	private void OnLanguageSelected(SelectionGroupToggleSingleButton btn)
	{
		Type typeFromHandle = Type.GetTypeFromHandle((RuntimeTypeHandle)typeof(CFGameSettings));
		FieldInfo field = typeFromHandle.GetField("language");
		string settingName = field.Name;
		Transform transform = btn.transform;
		int siblingIndex = transform.GetSiblingIndex();
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
		SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
		ConfigSaveFile config = saveManager.config;
		object value = default(object);
		CurrentSettings.Instance.BetterUpdateCfSettings(settingName, value, config.cfGameSettings);
		startBtn = btn;
	}
}
