using System;
using System.Collections.Generic;
using Assets.Scripts.Saves___Serialization.Progression.Achievements;
using Assets.Scripts.Saves___Serialization.SaveFiles;
using Cpp2ILInjected;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;

public class MapEntry : MonoBehaviour
{
	public RawImage mapIcon;

	public GameObject locked;

	public GameObject notificationIcon;

	public SelectionGroupToggleSingleButton buttonScript;

	public TextMeshProUGUI t_description;

	public TextMeshProUGUI t_name;

	private MapData _003CmapData_003Ek__BackingField;

	public MapData mapData
	{
		get
		{
			return _003CmapData_003Ek__BackingField;
		}
		private set
		{
			_003CmapData_003Ek__BackingField = value;
		}
	}

	private void Awake()
	{
		//IL_00d6: Expected I, but got O
		//IL_008a: Expected I, but got O
		Action<SelectionGroupToggleSingleButton, MapData> b = OnMapSelected;
		Delegate obj = Delegate.Combine(MapSelectionUi.A_MapSelected, b);
		if ((object)obj == null)
		{
			MapSelectionUi.A_MapSelected = (Action<SelectionGroupToggleSingleButton, MapData>)obj;
			goto IL_0098;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<SelectionGroupToggleSingleButton, MapData> action = default(Action<SelectionGroupToggleSingleButton, MapData>);
		if (action != null)
		{
			MapSelectionUi.A_MapSelected = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj2 = default(object);
			bool flag = obj2 == null;
			nint num = (nint)typeof(Action<SelectionGroupToggleSingleButton, MapData>);
			if (!flag)
			{
				goto IL_0098;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			nint num = (nint)typeof(Action<SelectionGroupToggleSingleButton, MapData>);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_0098:
		Action<Locale> value = OnLocaleChanged;
		LocalizationSettings.SelectedLocaleChanged += value;
	}

	private void OnDestroy()
	{
		//IL_00d6: Expected I, but got O
		//IL_008a: Expected I, but got O
		Action<SelectionGroupToggleSingleButton, MapData> value = OnMapSelected;
		Delegate obj = Delegate.Remove(MapSelectionUi.A_MapSelected, value);
		if ((object)obj == null)
		{
			MapSelectionUi.A_MapSelected = (Action<SelectionGroupToggleSingleButton, MapData>)obj;
			goto IL_0098;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<SelectionGroupToggleSingleButton, MapData> action = default(Action<SelectionGroupToggleSingleButton, MapData>);
		if (action != null)
		{
			MapSelectionUi.A_MapSelected = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj2 = default(object);
			bool flag = obj2 == null;
			nint num = (nint)typeof(Action<SelectionGroupToggleSingleButton, MapData>);
			if (!flag)
			{
				goto IL_0098;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			nint num = (nint)typeof(Action<SelectionGroupToggleSingleButton, MapData>);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_0098:
		Action<Locale> value2 = OnLocaleChanged;
		LocalizationSettings.SelectedLocaleChanged -= value2;
	}

	private void OnLocaleChanged(Locale obj)
	{
		Set(_003CmapData_003Ek__BackingField);
	}

	private void OnMapSelected(SelectionGroupToggleSingleButton arg1, MapData arg2)
	{
		MapData mapData = _003CmapData_003Ek__BackingField;
		if (mapData.eMap == arg2.eMap && notificationIcon.activeSelf)
		{
			SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
			ProgressionSaveFile progression = saveManager.progression;
			object internalName = _003CmapData_003Ek__BackingField.GetInternalName();
			bool flag = ((HashSet<object>)(object)progression.newMaps).Remove(internalName);
			notificationIcon.SetActive(value: false);
		}
	}

	public void Set(MapData mapData)
	{
		_003CmapData_003Ek__BackingField = mapData;
		mapIcon.texture = mapData.mapIconBig;
		t_name.text = "??";
		MyAchievement unlockRequirement = mapData.GetUnlockRequirement();
		GameObject gameObject;
		bool active;
		if (unlockRequirement != null)
		{
			MyAchievement unlockRequirement2 = mapData.GetUnlockRequirement();
			if (!unlockRequirement2.IsCompleted())
			{
				MyAchievement unlockRequirement3 = mapData.GetUnlockRequirement();
				string unlockRequirement4 = unlockRequirement3.GetUnlockRequirement();
				string text = "Unlock requirement:<size=85%>\n" + unlockRequirement4;
				t_description.text = text;
				gameObject = locked;
				active = true;
				goto IL_01ae;
			}
		}
		string text2 = mapData.GetName();
		t_name.text = text2;
		string description = mapData.GetDescription();
		t_description.text = description;
		locked.SetActive(value: false);
		gameObject = notificationIcon;
		SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
		ProgressionSaveFile progression = saveManager.progression;
		object internalName = mapData.GetInternalName();
		active = ((HashSet<object>)(object)progression.newMaps).Contains(internalName);
		goto IL_01ae;
		IL_01ae:
		gameObject.SetActive(active);
		bool activeSelf = locked.activeSelf;
		bool b = (byte)((activeSelf ? 1u : 0u) ^ 1u) != 0;
		buttonScript.CanSelect(b);
	}
}
