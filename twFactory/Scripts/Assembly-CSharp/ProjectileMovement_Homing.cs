using UnityEngine;

public class ProjectileMovement_Homing : ProjectileMovement
{
	[SerializeField]
	private float startSpeed = 1f;

	[SerializeField]
	private float acceleration = 1f;

	[SerializeField]
	private float startAngularSpeed = 180f;

	[SerializeField]
	private float maxAngularSpeed = 180f;

	[SerializeField]
	private float angularSpeedAccelleration = 100f;

	[SerializeField]
	private float angularSpeedAccellerationStartDelay;

	[SerializeField]
	private float checkDistanceTreshold = 0.01f;

	private bool targetFoundAtLeastOnce;

	private float currentVelocity;

	private float currentAngularSpeed;

	private float lifetime;

	private Vector3 positionToReach;

	protected override void OnEnable()
	{
		base.OnEnable();
		currentVelocity = startSpeed;
		currentAngularSpeed = startAngularSpeed;
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
			positionToReach = projectile.TargetPosition;
		}
		lifetime += Time.deltaTime;
		if (lifetime >= angularSpeedAccellerationStartDelay)
		{
			currentAngularSpeed = Mathf.Min(currentAngularSpeed + angularSpeedAccelleration * Time.deltaTime, maxAngularSpeed);
		}
		currentVelocity = Mathf.Min(currentVelocity + acceleration * Time.deltaTime, speed);
		base.transform.rotation = Quaternion.RotateTowards(base.transform.rotation, Quaternion.LookRotation(positionToReach - base.transform.position), Mathf.Lerp(0f, currentAngularSpeed, currentVelocity / speed) * Time.deltaTime);
		base.transform.position = base.transform.position + base.transform.forward * currentVelocity * Time.deltaTime;
	}

	protected override bool CheckTargetReached()
	{
		return (base.transform.position - positionToReach).sqrMagnitude <= Mathf.Pow(speed * Time.deltaTime + checkDistanceTreshold, 2f);
	}
}
