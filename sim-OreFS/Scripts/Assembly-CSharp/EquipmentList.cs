using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class EquipmentList
{
	public ItemType itemType;

	public Sprite itemIcon;

	public bool isLevelActive;

	public List<GameObject> inputList = new List<GameObject>();
}
