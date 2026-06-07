using System.Collections.Generic;
using UnityEngine;

public class AirbrushTipsBox : MonoBehaviour
{
	private Dictionary<BrushGestaltEnum, AirbrushTip> tips;

	private bool init;

	public bool isChangingTip => false;

	private void Init()
	{
	}

	public void SetBrush(Airbrush airbrush, BrushGestaltEnum brushEnum, bool immediate = false)
	{
	}
}
