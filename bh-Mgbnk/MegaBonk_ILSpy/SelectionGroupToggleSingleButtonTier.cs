using System;
using System.Collections.Generic;
using Assets.Scripts.Game.Other;
using Assets.Scripts.Saves___Serialization.Progression;
using Assets.Scripts.Saves___Serialization.SaveFiles;
using Cpp2ILInjected;
using UnityEngine;

public class SelectionGroupToggleSingleButtonTier : SelectionGroupToggleSingleButton
{
	public GameObject completedIcon;

	public GameObject alert;

	private RunConfig runConfig;

	private void Start()
	{
	}

	public void SetCompleted(bool completed, RunConfig runConfig)
	{
		//IL_013a: Expected O, but got I
		this.runConfig = runConfig;
		completedIcon.SetActive(completed);
		SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
		ProgressionSaveFile progression = saveManager.progression;
		MenuMeta menuMeta = progression.menuMeta;
		MapData mapData = runConfig.mapData;
		GameObject gameObject;
		bool active;
		if (((Dictionary<System.Int32Enum, object>)(object)menuMeta.mapsProgress).ContainsKey((System.Int32Enum)mapData.eMap))
		{
			SaveManager saveManager2 = SaveManager._003CInstance_003Ek__BackingField;
			ProgressionSaveFile progression2 = saveManager2.progression;
			MenuMeta menuMeta2 = progression2.menuMeta;
			MapData mapData2 = runConfig.mapData;
			object obj = ((Dictionary<System.Int32Enum, object>)(object)menuMeta2.mapsProgress).get_Item((System.Int32Enum)mapData2.eMap);
			Transform transform = base.transform;
			int siblingIndex = transform.GetSiblingIndex();
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ rax_v22 (System.Object)+10]");
			bool flag = ((HashSet<int>)0).Contains(siblingIndex);
			gameObject = alert;
			if (flag)
			{
				active = true;
				goto IL_01b2;
			}
		}
		else
		{
			gameObject = alert;
		}
		active = false;
		goto IL_01b2;
		IL_01b2:
		gameObject.SetActive(active);
	}

	protected override void OnClick()
	{
		//IL_00e0: Expected O, but got I
		if (alert.activeSelf)
		{
			SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
			ProgressionSaveFile progression = saveManager.progression;
			MenuMeta menuMeta = progression.menuMeta;
			RunConfig runConfig = this.runConfig;
			MapData mapData = runConfig.mapData;
			object obj = ((Dictionary<System.Int32Enum, object>)(object)menuMeta.mapsProgress).get_Item((System.Int32Enum)mapData.eMap);
			Transform transform = base.transform;
			int siblingIndex = transform.GetSiblingIndex();
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ rax_v13 (System.Object)+10]");
			bool flag = ((HashSet<int>)0).Remove(siblingIndex);
			alert.SetActive(value: false);
		}
	}

	public SelectionGroupToggleSingleButtonTier()
	{
		base._003CcanSelect_003Ek__BackingField = true;
		((MyButton)this)._002Ector();
	}
}
