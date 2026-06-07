using UnityEngine;

public class ProjectileMovement_Forward : ProjectileMovement
{
	protected override void Move()
	{
		base.transform.position = base.transform.position + base.transform.forward.normalized * speed * Time.deltaTime;
	}

	protected override bool CheckTargetReached()
	{
		return false;
	}
}
