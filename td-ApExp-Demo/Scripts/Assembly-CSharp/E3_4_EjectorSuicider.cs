using UnityEngine;

public class E3_4_EjectorSuicider : EnemyBase
{
	[Header("Additional Components")]
	[SerializeField]
	private Rotator Rotator;

	[Header("Ejector Suicider Fields")]
	[SerializeField]
	private float xVariation = 1f;

	[SerializeField]
	private float yVariation = 0.5f;

	[SerializeField]
	[Range(0f, 5f)]
	private float movementSpeedBoostOnHack = 3f;

	[SerializeField]
	private float spawnSpeed;

	private float spawnTimer = 1f;

	private bool momentumLost;

	private float tempSpeed;

	private float preHackMoveSpeed;

	private new void Awake()
	{
		base.Awake();
		previousPos = base.transform.position;
		noiseSeed = Random.Range(0, 100000);
		Target();
		if (base.TargetUnit != null)
		{
			FaceTargetOnSpawn();
		}
		tempSpeed = base.MoveSpeed;
		base.MoveSpeed = spawnSpeed;
		base.HealthComponent.ApplyImmunityBuff(0.5f);
		sm = new StateMachine();
		StateMachine stateMachine = sm;
		StateBase[] newStates = new StateBaseEnemy[2]
		{
			new E1_3MoveIntoTrain(sm, this),
			new BEMPState(sm, this, "E3MoveIntoTrain")
		};
		stateMachine.BuildStateDictionary(newStates);
	}

	private new void Update()
	{
		base.Update();
		CheckTarget();
		spawnTimer -= Time.deltaTime;
		if (spawnTimer < 0f && !momentumLost)
		{
			momentumLost = true;
			base.MoveSpeed = tempSpeed;
		}
	}

	public override void OnEMPEnd()
	{
		base.OnEMPEnd();
		base.HealthComponent.IsImmune = false;
	}

	private new void FixedUpdate()
	{
		base.FixedUpdate();
		if (!(base.TargetUnit == null) && !base.IsEMPd)
		{
			RaycastCollide();
		}
	}

	private void FaceTargetOnSpawn()
	{
		Vector3 normalized = (base.TargetUnit.transform.position - base.transform.position).normalized;
		Quaternion rotation = Quaternion.LookRotation(Vector3.forward, normalized);
		rotation *= Quaternion.Euler(0f, 0f, 90f);
		base.transform.rotation = rotation;
	}

	private void RaycastCollide()
	{
		RaycastHit2D[] array = Physics2D.RaycastAll(base.transform.position, base.transform.up, 0.02f, LayerMask.GetMask("Unit", "Enemy"));
		foreach (RaycastHit2D raycastHit2D in array)
		{
			if (raycastHit2D.collider.TryGetComponent<Unit>(out var component) && component.isShieldPlate)
			{
				HealthChangeInfo info = new HealthChangeInfo(this, component.HealthComponent, trainDamage, isPercent: false, null, canRes: false, ignoreArmor: false, ignoreImmunity: false, isBurn: false, ignoreGrace: false, isCrit: false, isDamageReduced: false, isImmune: false, removeHitEffect: false, showDamageNumbers: true, DamageType.AoE);
				component.HealthComponent.ChangeHealthWithInfo(info);
				trainDamage = 0f;
				ReachedTrainExplosion();
			}
		}
	}

	public void ReachedTrainExplosion()
	{
		Object.Instantiate(explosionPrefab, base.transform.position, base.transform.rotation).GetComponent<Explosion>().Initialize(this, explosionScale, 0f, trainDamage);
		DataTrackingManager.Instance.AddDamageByEnemy(GetType().Name, trainDamage);
		KillSelf();
	}

	public override void Aim()
	{
		Vector3 upwards = Vector3.zero;
		if (base.TargetUnit != null)
		{
			upwards = (base.TargetUnit.transform.position - base.transform.position).normalized;
		}
		Quaternion rotation = Quaternion.LookRotation(Vector3.forward, upwards);
		rotation *= Quaternion.Euler(0f, 0f, 90f);
		base.transform.rotation = rotation;
	}

	protected override void OnFactionChanged()
	{
		base.OnFactionChanged();
		Target();
		if (IsHacked)
		{
			preHackMoveSpeed = base.MoveSpeed;
			base.MoveSpeed += base.MoveSpeed * movementSpeedBoostOnHack;
		}
		else
		{
			base.MoveSpeed = preHackMoveSpeed;
		}
	}

	protected override void OnDeath(HealthChangeInfo info)
	{
		base.OnDeath(info);
	}
}
