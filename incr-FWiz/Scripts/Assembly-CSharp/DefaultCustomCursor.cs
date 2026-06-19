using System;
using UnityEngine;

[Serializable]
public class DefaultCustomCursor : CustomCursor
{
	[SerializeField]
	private Sprite _defaultIcon;

	[SerializeField]
	private Sprite _pressIcon;

	public DefaultCustomCursor(Sprite defaultIcon, Sprite pressIcon, int priority)
		: base(0)
	{
	}

	protected override void Apply()
	{
	}

	private void OnPress()
	{
	}

	private void OnEndPress()
	{
	}

	protected override void Unapply()
	{
	}
}
