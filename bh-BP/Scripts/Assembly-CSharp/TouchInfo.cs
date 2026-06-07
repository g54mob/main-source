using System;
using UnityEngine;

[Serializable]
public class TouchInfo
{
	public Touch PressTouch;

	public Touch PrevTouch;

	public Touch CurTouch;

	public bool IsDrag;

	public bool SawLastFrame;

	public bool ClickedOnUI;

	public TouchInfo(Touch t)
	{
	}
}
