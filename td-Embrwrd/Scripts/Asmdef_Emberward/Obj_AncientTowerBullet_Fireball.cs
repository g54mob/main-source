using UnityEngine;

public class Obj_AncientTowerBullet_Fireball : Obj_AncientTowerBullet_Base
{
	[SerializeField]
	private int bounceCount;

	[SerializeField]
	private float bounceRange;

	[SerializeField]
	private float explosionRadius;

	[SerializeField]
	private float maxFlightHeightSetting;

	private float totalFlyTime;

	private float curflyTime;

	private float curBounceCount;

	private Vector3 startPosition;

	private Vector3 targetPosition;

	private float t;

	protected override void SetupProc()
	{
	}

	private void Update()
	{
	}

	protected virtual ABaseTower GetTargetTower()
	{
		return null;
	}

	private void Explode()
	{
	}
}
