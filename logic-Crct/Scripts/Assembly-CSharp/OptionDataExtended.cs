using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class OptionDataExtended : Dropdown.OptionData
{
	public int prefabID;

	public int mainID;

	public int subID;

	public Sprite pinImageSprite;

	public string description;

	public string datasheetLink;
}
