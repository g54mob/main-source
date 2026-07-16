using System;
using UnityEngine;

[Serializable]
public class InteractionDisplayInfo
{
	public enum InfoType
	{
		Interaction = 0,
		Control = 1,
		Product = 2
	}

	public enum ControlType
	{
		None = -1,
		LeftMouseClick = 0,
		RightMouseClick = 1,
		MouseScroll = 2,
		LeftAndRight = 3
	}

	public enum InteractorType
	{
		ItemGeneral = 0,
		Ingredient = 1,
		Workstation = 2,
		Tool = 3,
		NPC = 4,
		Dirt = 5
	}

	[Header("InteractSelf")]
	public string msg;

	public string overrideRightClick;

	public InteractorType interactorType;

	public InfoType infoType;

	public ControlType controlType = ControlType.None;
}
