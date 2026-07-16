using System.Collections;
using UnityEngine;

public class E3_B_Phase1Plane_Attacker : E3_B_Phase1Plane
{
	[Header("Attacker Fields")]
	public int shotCount = 5;

	public int missileCount = 2;

	public Animator turretAnim;

	private Vector3 targetPos = Vector3.zero;

	public new void Start()
	{
		base.Start();
		sm = new StateMachine();
		sm.BuildStateDictionary(new StateBase[3]
		{
			new E3_B_Attacker_Idle(sm, this),
			new E3_B_Attacker_Attack(sm, this),
			new E3_B_AttackerBombardment(sm, this)
		});
		targetPos = Train.Instance.GetRandomVisiblePosition();
	}

	public override void Move()
	{
		if (Vector2.Distance(base.transform.position, Train.Instance.Wagons[0].transform.position) > 2.5f)
		{
			base.MoveSpeed = startingMoveSpeed * 3f;
		}
		else
		{
			base.MoveSpeed = startingMoveSpeed;
		}
		float t = Mathf.PerlinNoise(Time.time, noiseSeed);
		float t2 = Mathf.PerlinNoise(Time.time, noiseSeed);
		float b = Mathf.Lerp(targetPos.x - xVariation, targetPos.x + xVariation, t2);
		float b2 = Mathf.Lerp(targetPos.y - yVariation, targetPos.y + yVariation, t);
		Vector3 position = base.transform.position;
		float t3 = Time.deltaTime * base.MoveSpeed;
		position.x = Mathf.Lerp(position.x, b, t3);
		float t4 = Time.deltaTime * base.MoveSpeed;
		position.y = Mathf.Lerp(position.y, b2, t4);
		base.transform.position = position + (Vector3)GetNeighborAvoidanceVector();
		IsInPosition = Mathf.Abs(position.x - targetPos.x) < xVariation && Mathf.Abs(position.y - targetPos.y) < yVariation;
		if (IsInPosition)
		{
			targetPos = Train.Instance.GetRandomVisiblePosition();
		}
		rateOfChangeY = (position.y - previousPos.y) / Time.deltaTime;
		previousPos = position;
		TiltPlane(rateOfChangeY);
	}

	public override void Aim()
	{
		if (!(base.TargetUnit == null))
		{
			rotator.RotateComponentTowardsPosition(turret1TF, base.TargetUnit.transform.position, 160f);
		}
	}

	public override void Shoot()
	{
		int shotCounter;
		if (!(base.TargetUnit == null))
		{
			shotCounter = 0;
			StartCoroutine(ShootCoroutine());
		}
		IEnumerator ShootCoroutine()
		{
			while (shotCounter < shotCount)
			{
				turretAnim.Play("AttackerBossCannonShoot");
				shotTimer = timeBetweenShots;
				Projectile component = Object.Instantiate(bullet, muzzle1TF.position, muzzle1TF.rotation).GetComponent<Projectile>();
				component.ProjectileHit += base.OnTargetDamaged;
				component.sourceUnit = this;
				component.speed = projSpeed;
				component.damage = damage;
				component.GetComponent<TrailRenderer>().widthCurve = new AnimationCurve(new Keyframe(0f, 0.005f), new Keyframe(0.5f, 0f));
				component.transform.Find("Outline").GetComponent<TrailRenderer>().widthCurve = new AnimationCurve(new Keyframe(0f, 0.02f), new Keyframe(0.5f, 0f));
				soundBuilder.Play(shootSound);
				shotCounter++;
				yield return new WaitForSeconds(0.1f);
				Projectile component2 = Object.Instantiate(bullet, muzzle1TF.position, muzzle1TF.rotation).GetComponent<Projectile>();
				component2.ProjectileHit += base.OnTargetDamaged;
				component2.sourceUnit = this;
				component2.speed = projSpeed;
				component2.damage = damage;
				component2.GetComponent<TrailRenderer>().widthCurve = new AnimationCurve(new Keyframe(0f, 0.005f), new Keyframe(0.5f, 0f));
				component2.transform.Find("Outline").GetComponent<TrailRenderer>().widthCurve = new AnimationCurve(new Keyframe(0f, 0.02f), new Keyframe(0.5f, 0f));
				soundBuilder.Play(shootSound);
				shotCounter++;
				yield return new WaitForSeconds(timeBetweenShots);
			}
			AttackCompleted = true;
		}
	}
}
