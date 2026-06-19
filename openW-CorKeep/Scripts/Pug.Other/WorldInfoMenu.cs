using System.Collections.Generic;
using UnityEngine;

public class WorldInfoMenu : WorldSettingsSubMenu
{
	public RadicalMenuOptionTextInput nameInput;

	public GameObject seedSection;

	public RadicalMenuOptionTextInput seedInput;

	public SelectWorldIconOption iconOption;

	public SelectWorldModeOption worldMode;

	public bool readOnly;

	public List<GameObject> disableWhenReadOnly = new List<GameObject>();

	private WorldInfo _worldInfo;

	public override void Activate(WorldInfo worldInfo)
	{
		_worldInfo = worldInfo;
		nameInput.SetInputText(worldInfo.name);
		seedInput.SetInputText(worldInfo.seedString);
		iconOption.activeIconIndex = worldInfo.iconIndex;
		iconOption.UpdateIcon();
		worldMode.SetActiveDifficulty(worldInfo.mode);
		seedInput.readOnly = readOnly;
		worldMode.readOnly = readOnly;
		seedSection.SetActive(worldInfo.worldGenerationType == WorldGenerationType.FullRelease);
		foreach (GameObject item in disableWhenReadOnly)
		{
			item.SetActive(!readOnly);
		}
	}

	public override void Deactivate()
	{
		Manager.saves.WriteWorldInfo();
	}

	public void Update()
	{
		_worldInfo.name = nameInput.GetInputText();
		_worldInfo.iconIndex = iconOption.activeIconIndex;
		_worldInfo.mode = worldMode.GetActiveDifficulty();
		_worldInfo.seedString = seedInput.GetInputText();
		WorldInfo worldInfo = _worldInfo;
		WorldGenerationType worldGenerationType = ((_worldInfo.mode != WorldMode.Creative) ? WorldGenerationType.FullRelease : WorldGenerationType.Creative);
		worldInfo.worldGenerationType = worldGenerationType;
	}

	public override void Reset()
	{
	}
}
