using UnityEngine;

public class ProjectileMovement_ToTarget : ProjectileMovement
{
	[SerializeField]
	private bool lookAtTarget = true;

	private bool targetFoundAtLeastOnce;

	private Vector3 positionToReach;

	protected override void OnEnable()
	{
		base.OnEnable();
		targetFoundAtLeastOnce = false;
	}

	protected override void Move()
	{
		if ((bool)projectile.Target)
		{
			positionToReach = projectile.Target.transform.position;
			targetFoundAtLeastOnce = true;
		}
		else if (!targetFoundAtLeastOnce)
		{
			projectile.DestroyProjectile();
		}
		base.transform.position = base.transform.position + (positionToReach - base.transform.position).normalized * speed * Time.deltaTime;
		if (lookAtTarget)
		{
			base.transform.rotation = Quaternion.LookRotation((positionToReach - base.transform.position).normalized);
		}
	}

	protected override bool CheckTargetReached()
	{
		return (base.transform.position - positionToReach).sqrMagnitude <= Mathf.Pow(speed * Time.deltaTime + 0.01f, 2f);
	}
}
