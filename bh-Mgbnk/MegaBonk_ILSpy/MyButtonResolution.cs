using System;
using System.Reflection;
using Assets.Scripts.Settings___Saves.SaveFiles;
using Assets.Scripts.Settings___Saves.SaveFiles.ConfigSaves;
using Cpp2ILInjected;
using TMPro;
using UnityEngine;

public class MyButtonResolution : MyButton
{
	public TextMeshProUGUI t_resolution;

	public GameObject selected;

	private int value;

	private new void Awake()
	{
		//IL_00b2: Expected I, but got O
		//IL_008a: Expected I, but got O
		base.Awake();
		Action<int> b = OnResolutionChanged;
		Delegate obj = Delegate.Combine(CurrentSettings.A_ResolutionChanged, b);
		if ((object)obj == null)
		{
			CurrentSettings.A_ResolutionChanged = (Action<int>)obj;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<int> action = default(Action<int>);
		if (action != null)
		{
			CurrentSettings.A_ResolutionChanged = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj2 = default(object);
			bool flag = obj2 == null;
			nint num = (nint)typeof(Action<int>);
			if (!flag)
			{
				return;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			nint num = (nint)typeof(Action<int>);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	private void OnDestroy()
	{
		//IL_00b2: Expected I, but got O
		//IL_008a: Expected I, but got O
		Action<int> action = OnResolutionChanged;
		Delegate obj = Delegate.Remove(CurrentSettings.A_ResolutionChanged, action);
		if ((object)obj == null)
		{
			CurrentSettings.A_ResolutionChanged = (Action<int>)obj;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<int> action2 = default(Action<int>);
		if (action2 != null)
		{
			CurrentSettings.A_ResolutionChanged = action2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj2 = default(object);
			bool flag = obj2 == null;
			nint num = (nint)typeof(Action<int>);
			if (!flag)
			{
				return;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			nint num = (nint)typeof(Action<int>);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	public unsafe void SetResolution(Resolution resolution, bool isSelected, int value)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18317305B]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		this.value = value;
		int width = ((Resolution*)resolution)->width;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
		int height = ((Resolution*)resolution)->height;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
		object arg = default(object);
		object arg2 = default(object);
		string text = $"{arg}x{arg2}";
		t_resolution.text = text;
		selected.SetActive(isSelected);
	}

	public void ClickButton()
	{
		Type typeFromHandle = Type.GetTypeFromHandle((RuntimeTypeHandle)typeof(CFVideoSettings));
		FieldInfo field = typeFromHandle.GetField("resolution");
		string settingName = field.Name;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_value_box\"");
		SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
		ConfigSaveFile config = saveManager.config;
		object obj = default(object);
		CurrentSettings.Instance.BetterUpdateCfSettings(settingName, obj, config.cfVideoSettings);
	}

	public void Select()
	{
		GameObject gameObject = selected.gameObject;
		gameObject.SetActive(value: true);
	}

	public void Deselect()
	{
		GameObject gameObject = selected.gameObject;
		gameObject.SetActive(value: false);
	}

	private void OnResolutionChanged(int resIndex)
	{
		if (resIndex != value)
		{
			GameObject gameObject = selected.gameObject;
			gameObject.SetActive(value: false);
		}
		else
		{
			GameObject gameObject2 = selected.gameObject;
			gameObject2.SetActive(value: true);
		}
	}

	public override void StartHover()
	{
	}

	public override void StopHover()
	{
	}

	protected override void OnClick()
	{
	}

	public MyButtonResolution()
	{
		hoverScale = 1.05f;
		((MonoBehaviour)this)._002Ector();
	}
}
