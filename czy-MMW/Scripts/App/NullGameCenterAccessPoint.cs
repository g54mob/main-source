using UnityEngine;

public class NullGameCenterAccessPoint : IGameCenterAccessPoint
{
	public bool IsAvailable()
	{
		return false;
	}

	public void Show()
	{
	}

	public void Hide()
	{
	}

	public Rect GetRect()
	{
		return Rect.zero;
	}

	public void Select()
	{
	}
}
