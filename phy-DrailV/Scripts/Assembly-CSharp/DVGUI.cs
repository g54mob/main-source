using DV;
using UnityEngine;

public static class DVGUI
{
	private static Option<GUISkin> _skin;

	public static GUISkin skin
	{
		get
		{
			if (_skin.IsNone())
			{
				_skin = Option<GUISkin>.Some(Resources.Load<GUISkin>("DebugGUISkin"));
			}
			return _skin.UnwrapOrDefault();
		}
	}
}
