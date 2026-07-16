using System;
using UnityEngine;

public class CentipedeSpawn : EnemyBase
{
	[SerializeField]
	private GameObject projectilePrefab;

	private Transform cannonTf;

	private Transform muzzleTf;

	private Transform trainTf;

	private float randomNormalize;

	private Action centipedeDestroyedHandler;

	private new void Awake()
	{
		base.Awake();
		randomNormalize = ((UnityEngine.Random.Range(0, 2) != 0) ? 1 : (-1));
		cannonTf = base.transform.Find("Cannon");
		muzzleTf = cannonTf.Find("Muzzle");
		centipedeDestroyedHandler = (Action)Delegate.Combine(centipedeDestroyedHandler, (Action)delegate
		{
			KillSelf();
		});
		EnemyManager.Instance.CentipedeDestroyed += centipedeDestroyedHandler;
	}

	private new void Start()
	{
		base.Start();
		soundBuilder.Play(engineSound);
		sm = new StateMachine();
		StateMachine stateMachine = sm;
		StateBase[] newStates = new StateBaseEnemy[2]
		{
			new E6Move(sm, this),
			new BEMPState(sm, this, "Move")
		};
		stateMachine.BuildStateDictionary(newStates);
	}

	private new void Update()
	{
		if (Time.timeScale != 0f && Time.deltaTime != 0f)
		{
			base.Update();
			CheckTarget();
		}
	}

	public override void Aim()
	{
		if (!(base.TargetUnit == null))
		{
			Vector3 upwards = base.TargetUnit.transform.position - muzzleTf.position;
			cannonTf.rotation = Quaternion.LookRotation(Vector3.forward, upwards);
		}
	}

	public override void Shoot()
	{
		shotTimer -= Time.deltaTime;
		if (shotTimer <= 0f)
		{
			shotTimer = timeBetweenShots;
			base.Anim.Play("CannonFire", 1, 0f);
			Projectile component = UnityEngine.Object.Instantiate(projectilePrefab, muzzleTf.position, cannonTf.rotation, null).GetComponent<Projectile>();
			component.sourceUnit = this;
			component.speed = projSpeed;
			component.damage = damage;
			soundBuilder.Play(shootSound);
		}
	}

	protected override void OnDeath(HealthChangeInfo info)
	{
		EnemyManager.Instance.CentipedeDestroyed -= centipedeDestroyedHandler;
		base.OnDeath(info);
	}
}
