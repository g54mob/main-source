using UnityEngine;

public class RocketWing : RocketAttachment
{
	[SerializeField]
	private GameObject wingGO;

	protected override float liftMultiplier => 1.5f;

	protected override float dragMultiplier => 0.05f;

	protected override float momentMultiplier => 1f;

	private void Awake()
	{
		OnAwake();
	}

	private void Start()
	{
		OnStart();
		partType = 2;
		if (rocket != null)
		{
			rocket.rocketWing.Add(wingGO);
			rocket.wings.Add(this);
		}
	}

	public void Disassemble()
	{
		rocketRb.mass -= mass;
	}
}
