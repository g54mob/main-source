using System.Collections;
using System.Linq;
using UnityEngine;

public class E3_B_Phase1Plane_Disruptor : E3_B_Phase1Plane
{
	[Header("Primary Fields")]
	public int shotCount = 2;

	public GameObject empProjectilePrefab;

	public Transform empLauncherTF;

	public Animator turretAnim;

	private float angle = 179f;

	[Header("Rotation Movement")]
	[SerializeField]
	private float rotationRadius;

	private float startingRotationRadius;

	private Transform rotationCenter;

	public new void Start()
	{
		base.Start();
		sm = new StateMachine();
		sm.BuildStateDictionary(new StateBase[2]
		{
			new E3_B_Disruptor_Idle(sm, this),
			new E3_B_DisruptorBombardment(sm, this)
		});
		shotTimer = FirstIdleTime;
		base.TargetUnit = GetRandomModule();
		rotationCenter = Train.Instance.GetCannonModuleSlot().transform;
		startingRotationRadius = rotationRadius;
		rotationRadius = 3f;
	}

	public override void Move()
	{
		if (Mathf.Abs(base.transform.position.x) >= 2.5f || Mathf.Abs(base.transform.position.y) >= 2.5f)
		{
			base.MoveSpeed = startingMoveSpeed * 5f;
		}
		else
		{
			base.MoveSpeed = startingMoveSpeed;
		}
		if (rotationRadius > startingRotationRadius)
		{
			float num = rotationRadius - startingRotationRadius;
			float num2 = 2f;
			float num3 = Mathf.Lerp(0.02f, 0.3f, Mathf.Clamp01(num / num2));
			rotationRadius -= num3 * Time.deltaTime;
		}
		float x = rotationCenter.position.x + Mathf.Cos(angle) * rotationRadius;
		float y = rotationCenter.position.y + Mathf.Sin(angle) * rotationRadius;
		base.transform.position = new Vector2(x, y);
		angle += base.MoveSpeed * Time.fixedDeltaTime;
		float x2 = 0f - Mathf.Sin(angle);
		float num4 = Mathf.Atan2(Mathf.Cos(angle), x2) * 57.29578f;
		rotator.RotateToAngle(base.transform, num4);
		if (angle >= 360f)
		{
			angle = 0f;
		}
	}

	public override void Retreat(float moveSpeedMultiplier)
	{
		if (Mathf.Abs(base.transform.position.x) >= 4f || Mathf.Abs(base.transform.position.y) >= 4f)
		{
			base.MoveSpeed = 0f;
			return;
		}
		rotationRadius += moveSpeedMultiplier * Time.deltaTime;
		if (fixingSecondaryCoroutine != null)
		{
			StopCoroutine(fixingSecondaryCoroutine);
			base.secondary.Repair();
			fixingSecondaryCoroutine = null;
		}
		float x = rotationCenter.position.x + Mathf.Cos(angle) * rotationRadius;
		float y = rotationCenter.position.y + Mathf.Sin(angle) * rotationRadius;
		base.transform.position = new Vector2(x, y);
		angle += base.MoveSpeed * Time.fixedDeltaTime;
		float x2 = 0f - Mathf.Sin(angle);
		float num = Mathf.Atan2(Mathf.Cos(angle), x2) * 57.29578f;
		rotator.RotateToAngle(base.transform, num);
		if (angle >= 360f)
		{
			angle = 0f;
		}
	}

	public void ResetRotationRadius()
	{
		rotationRadius = startingRotationRadius;
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
			shotTimer = IdleTime;
		}
		IEnumerator ShootCoroutine()
		{
			while (shotCounter < shotCount)
			{
				turretAnim.Play("CrowBossGunFire");
				SpawnProjectile();
				shotCounter++;
				yield return new WaitForSeconds(timeBetweenShots);
			}
			AttackCompleted = true;
		}
	}

	private void SpawnProjectile()
	{
		EMPProjectile component = Object.Instantiate(empProjectilePrefab, empLauncherTF.position, empLauncherTF.rotation).GetComponent<EMPProjectile>();
		component.SourceUnit = this;
		component.IsEnemy = base.IsEnemy;
		component.SetTarget(base.TargetUnit);
		soundBuilder.Play(shootSound);
		base.TargetUnit = GetRandomModule();
	}

	private Module GetRandomModule()
	{
		Module[] array = Train.Instance.Modules.Where((Module m) => (bool)m && !(m is ModuleCannon) && m != base.TargetUnit).ToArray();
		if (array != null)
		{
			return array[Random.Range(0, array.Length)];
		}
		return null;
	}

	protected override void OnDeath(HealthChangeInfo info)
	{
		if (!base.secondary.IsDead)
		{
			base.secondary.Deactivate();
		}
		base.OnDeath(info);
	}

	public override void OnSecondaryDestroyed()
	{
		base.secondary.Deactivate();
		base.OnSecondaryDestroyed();
	}
}
