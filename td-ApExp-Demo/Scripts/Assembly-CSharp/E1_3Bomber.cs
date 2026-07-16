using UnityEngine;

public class E1_3Bomber : EnemyBase
{
	[SerializeField]
	[Range(0f, 5f)]
	private float movementSpeedBoostOnHack = 3f;

	private float preHackMoveSpeed;

	protected new void Awake()
	{
		base.Awake();
		Aim();
		sm = new StateMachine();
		StateMachine stateMachine = sm;
		StateBase[] newStates = new StateBaseEnemy[2]
		{
			new E1_3MoveIntoTrain(sm, this),
			new BEMPState(sm, this, "E3MoveIntoTrain")
		};
		stateMachine.BuildStateDictionary(newStates);
		FaceTargetOnSpawn();
	}

	private void FaceTargetOnSpawn()
	{
		Vector3 normalized = (Vector3.zero - base.transform.position).normalized;
		base.transform.rotation = Quaternion.LookRotation(Vector3.forward, normalized);
	}

	private new void Update()
	{
		base.Update();
		CheckTarget();
	}

	private new void FixedUpdate()
	{
		base.FixedUpdate();
		RaycastCollide();
	}

	public override void Aim()
	{
		Vector3 upwards = Vector3.zero;
		if (base.TargetUnit != null)
		{
			upwards = (base.TargetUnit.transform.position - base.transform.position).normalized;
		}
		Quaternion b = Quaternion.LookRotation(Vector3.forward, upwards);
		base.transform.rotation = Quaternion.Lerp(base.transform.rotation, b, Time.deltaTime);
	}

	protected override void OnDeath(HealthChangeInfo info)
	{
		base.OnDeath(info);
		deathExplosion.Initialize(this, explosionScale, damage);
	}

	public void ReachedTrainExplosion()
	{
		Object.Instantiate(explosionPrefab, base.transform.position, base.transform.rotation).GetComponent<Explosion>().Initialize(this, explosionScale, 0f, trainDamage);
		DataTrackingManager.Instance.AddDamageByEnemy(GetType().Name, trainDamage);
		KillSelf();
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
}
