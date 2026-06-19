using OUSystems.Basics.UI;
using UnityEngine;

public class HoverDefaultCursorProvider : HoverListener
{
	[SerializeField]
	private DefaultCustomCursor _cursor;

	public override void OnHover()
	{
	}

	public override void OnHoverEnd()
	{
	}
}
