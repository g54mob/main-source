using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class TileUnlock
{
	public string ach_key;

	public string ach_name;

	public string ach_description;

	public List<GridObject> tilesToUnlock;

	public AchievementInstanceController ach_instance;

	[Header("Localization")]
	public string ach_name_loc;

	public string ach_desc_loc;
}
