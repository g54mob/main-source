using System;
using OUSystems.Basics.UI;
using UnityEngine;

public class OnPressOutsideListener : HoverListener
{
	public Action AnnouncePressOutside;

	[SerializeField]
	private bool TriggerOnPressEnd;

	public override void OnEnable()
	{
	}

	public override void OnDisable()
	{
	}

	public void OnPress()
	{
	}
}
