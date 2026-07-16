using System;
using UnityEngine;

[Serializable]
public class InteractionDisplayConfig
{
	public enum InfoType
	{
		BasicInteraction = 0,
		Ingredient = 1,
		Product = 2,
		Dirt = 3,
		Customer = 4
	}

	public enum ControlType
	{
		None = -1,
		LeftMouseClick = 0,
		RightMouseClick = 1,
		MouseScroll = 2,
		LeftAndRight = 3
	}

	public LocalizationDataTable.Tables overrideKeyTable;

	public string overrideMsgKey;

	[Header("InteractSelf")]
	public bool useCustomControlTable;

	public LocalizationDataTable.Tables customControlKeyTable;

	public string overrideLeftClickMsgKey;

	public string overrideRightClickMsgKey;

	public InfoType infoType;

	public ControlType controlType = ControlType.None;
}
