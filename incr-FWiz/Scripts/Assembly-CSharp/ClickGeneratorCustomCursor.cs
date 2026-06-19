using System;
using UnityEngine;

[Serializable]
public class ClickGeneratorCustomCursor : CustomCursor
{
	public Sprite DefaultIcon;

	public Sprite HitIcon;

	public float DefaultRecoveryTime;

	private float _defaultTimer;

	public ClickGeneratorCustomCursor(Sprite defaultIcon, Sprite hitIcon, int priority)
		: base(0)
	{
	}

	protected override void Apply()
	{
	}

	protected override void Unapply()
	{
	}

	public void OnHit()
	{
	}

	public override void Update()
	{
	}
}
