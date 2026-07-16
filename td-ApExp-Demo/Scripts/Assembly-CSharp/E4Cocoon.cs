using System;
using UnityEngine;

public class E4Cocoon : EnemyBase
{
	[Header("Cocoon Settings")]
	public float openShieldCd = 6f;

	public Transform muzzleLeft;

	public Transform muzzleRight;

	[NonSerialized]
	[HideInInspector]
	public float openShieldCdElapsed;

	private new void Awake()
	{
		base.Awake();
		sm = new StateMachine();
		StateMachine stateMachine = sm;
		StateBase[] newStates = new StateBaseEnemy[6]
		{
			new BIdleState(sm, this, "Move", "OpenShield"),
			new BMoveState(sm, this),
			new E4OpenShield(sm, this),
			new E4ShootLRLR(sm, this),
			new E4CloseShield(sm, this),
			new E4EMP(sm, this)
		};
		stateMachine.BuildStateDictionary(newStates);
		base.HealthComponent.IsImmune = true;
	}

	private new void Start()
	{
		base.Start();
		Target();
	}

	private new void Update()
	{
		base.Update();
		if (base.TargetUnit == null)
		{
			Target();
		}
	}

	public override void Aim()
	{
		if ((bool)base.TargetUnit)
		{
			RotateTowardsTransform(base.TargetUnit.transform);
		}
	}

	public override void Target()
	{
		base.TargetUnit = null;
		base.TargetUnit = UnitHelper.GetRandomLiveEnemyUnit(this);
	}

	public void Shoot(int shotsFired)
	{
		if (!(base.TargetUnit == null))
		{
			GameObject gameObject;
			if (shotsFired % 2 == 0)
			{
				gameObject = UnityEngine.Object.Instantiate(bullet, muzzleLeft.position, base.transform.rotation);
				shotsFired++;
				base.Anim.Play("Shoot Left", 1);
			}
			else
			{
				gameObject = UnityEngine.Object.Instantiate(bullet, muzzleRight.position, base.transform.rotation);
				shotsFired++;
				base.Anim.Play("Shoot Right", 1);
			}
			Projectile component = gameObject.GetComponent<Projectile>();
			component.sourceUnit = this;
			component.speed = projSpeed;
			component.damage = damage;
			component.GetComponent<TrailRenderer>().widthCurve = new AnimationCurve(new Keyframe(0f, 0.005f), new Keyframe(0.5f, 0f));
			component.transform.Find("Outline").GetComponent<TrailRenderer>().widthCurve = new AnimationCurve(new Keyframe(0f, 0.02f), new Keyframe(0.5f, 0f));
		}
	}
}
