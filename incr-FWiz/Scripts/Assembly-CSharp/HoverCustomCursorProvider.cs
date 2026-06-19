using OUSystems.Basics.UI;
using UnityEngine;

public class HoverCustomCursorProvider : HoverListener
{
	[SerializeField]
	private StaticCustomCursor _cursor;

	public override void OnHover()
	{
	}

	public override void OnHoverEnd()
	{
	}
}
