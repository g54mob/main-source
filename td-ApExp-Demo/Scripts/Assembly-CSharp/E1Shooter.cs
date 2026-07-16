using UnityEngine;

public class E1Shooter : EnemyBase
{
	[Header("Shooter Settings")]
	[SerializeField]
	private Transform muzzleTF;

	[SerializeField]
	private Transform turretTF;

	private new void Awake()
	{
		base.Awake();
		sm = new StateMachine();
		StateMachine stateMachine = sm;
		StateBase[] newStates = new StateBaseEnemy[3]
		{
			new E1Idle(sm, this),
			new BMoveState(sm, this),
			new BEMPState(sm, this)
		};
		stateMachine.BuildStateDictionary(newStates);
	}

	private new void Start()
	{
		base.Start();
		Target();
	}

	public override void Aim()
	{
		if (base.TargetUnit == null)
		{
			turretTF.transform.rotation = Quaternion.RotateTowards(turretTF.transform.rotation, Quaternion.Euler(0f, 0f, 270f), Time.deltaTime * 60f);
			return;
		}
		Vector3 position = base.TargetUnit.transform.position;
		Vector3 upwards = new Vector3(base.TargetUnit.transform.position.x, position.y) - base.transform.position;
		Quaternion to = Quaternion.LookRotation(Vector3.forward, upwards);
		turretTF.transform.rotation = Quaternion.RotateTowards(turretTF.transform.rotation, to, Time.deltaTime * 60f);
	}

	public override void Shoot()
	{
		if (!(base.TargetUnit == null) && !(shotTimer > 0f))
		{
			shotTimer = timeBetweenShots;
			Projectile component = Object.Instantiate(bullet, muzzleTF.position, muzzleTF.rotation).GetComponent<Projectile>();
			component.ProjectileHit += base.OnTargetDamaged;
			component.sourceUnit = this;
			component.speed = projSpeed;
			component.damage = damage;
			component.GetComponent<TrailRenderer>().widthCurve = new AnimationCurve(new Keyframe(0f, 0.005f), new Keyframe(0.5f, 0f));
			component.transform.Find("Outline").GetComponent<TrailRenderer>().widthCurve = new AnimationCurve(new Keyframe(0f, 0.02f), new Keyframe(0.5f, 0f));
			base.Anim.Play("Shoot", 1, 0f);
		}
	}
}
