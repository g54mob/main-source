using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class IndexCustomCursor : CustomCursor
{
	[SerializeField]
	private List<Sprite> _icons;

	[SerializeField]
	private int _index;

	[SerializeField]
	private CursorGraphic.CursorGraphicPositions _position;

	public int Index => 0;

	public IndexCustomCursor(List<Sprite> icons, int priority)
		: base(0)
	{
	}

	protected override void Apply()
	{
	}

	public void SetIndex(int index)
	{
	}

	public void SetIndexByScalerPoint(float point)
	{
	}

	public void TrySetImage()
	{
	}

	protected override void Unapply()
	{
	}
}
