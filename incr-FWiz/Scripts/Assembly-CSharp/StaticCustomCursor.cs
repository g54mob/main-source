using System;
using UnityEngine;

[Serializable]
public class StaticCustomCursor : CustomCursor
{
	[SerializeField]
	private Sprite _icon;

	[SerializeField]
	private CursorGraphic.CursorGraphicPositions _position;

	public StaticCustomCursor(Sprite icon, int priority)
		: base(0)
	{
	}

	protected override void Apply()
	{
	}

	protected override void Unapply()
	{
	}
}
