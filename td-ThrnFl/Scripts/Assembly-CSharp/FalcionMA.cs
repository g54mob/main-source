using UnityEngine;

public class FalcionMA : ManualAttack
{
	[SerializeField]
	private float shortCooldownTime = 0.2f;

	[SerializeField]
	private int consecutiveBursts = 5;

	private int attackNr;

	public override void Start()
	{
		base.Start();
	}

	public override void Attack()
	{
		base.Attack();
		if (attackNr % consecutiveBursts == consecutiveBursts - 1)
		{
			cooldown = cooldownTime;
		}
		else
		{
			cooldown = shortCooldownTime;
		}
		attackNr++;
	}

	public override void Update()
	{
		base.Update();
		if (attackNr % consecutiveBursts != 0)
		{
			inputBuffer = shortCooldownTime;
		}
	}
}
