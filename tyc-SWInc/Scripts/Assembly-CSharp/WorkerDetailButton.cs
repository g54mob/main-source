using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorkerDetailButton : MonoBehaviour
{
	public GUIToolTipper Tip;

	public RawImage Portrait;

	[NonSerialized]
	private Actor _act;

	public void SetActor(Actor a)
	{
		_act = a;
		KeyValuePair<Texture2D, Rect> keyValuePair = a.Snapshot();
		Portrait.texture = keyValuePair.Key;
		Portrait.uvRect = keyValuePair.Value;
		Tip.ToolTipValue = a.employee.FullName;
	}

	public void Click()
	{
		HUD.Instance.DetailWindow.Show(_act);
	}
}
