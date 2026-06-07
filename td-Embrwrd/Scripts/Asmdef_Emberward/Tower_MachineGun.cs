using UnityEngine;

public class Tower_MachineGun : ABaseCannon
{
	[Header("初始發射速度")]
	[SerializeField]
	private float shootInterval_Start;

	[SerializeField]
	[Header("最高發射速度")]
	private float shootInterval_Full;

	[SerializeField]
	[Header("換目標後發射速度到最高速需要多久")]
	private float chargeTime;

	[SerializeField]
	private AnimationCurve curve_ShootInterval;

	protected float shootInterval;

	private Vector3 headModelForward;

	private float lockTargetTime;

	private void Start()
	{
	}

	private void Update()
	{
	}

	protected override void ShootProc()
	{
	}
}
