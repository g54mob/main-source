using System.Collections;
using UnityEngine;

public class E4_2HeavyBomber : EnemyBase
{
	[SerializeField]
	[Range(0f, 5f)]
	private float movementSpeedBoostOnHack = 3f;

	[Header("Heavy Bomber Fields")]
	[SerializeField]
	private float knockbackStrength;

	[SerializeField]
	[Range(0f, 1f)]
	private float knockbackDuration;

	[SerializeField]
	private float knockbackInvulnerabilityDuration;

	private float knockbackTimer;

	private float preHackMoveSpeed;

	private Vector3 pushBackValue;

	private Coroutine pushBackCoroutine;

	protected new void Awake()
	{
		base.Awake();
		Aim();
		sm = new StateMachine();
		StateMachine stateMachine = sm;
		StateBase[] newStates = new StateBaseEnemy[2]
		{
			new E4_2MoveIntoTrain(sm, this),
			new BEMPState(sm, this, "E4MoveIntoTrain")
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
		knockbackTimer -= Time.deltaTime;
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
		deathExplosion.Initialize(this, explosionScale, base.EnemyDamage, base.TrainDamage);
	}

	public void ReachedTrainExplosion()
	{
		Object.Instantiate(explosionPrefab, base.transform.position, base.transform.rotation).GetComponent<Explosion>().Initialize(this, explosionScale, 0f);
		if ((bool)base.TargetUnit)
		{
			base.TargetUnit.HealthComponent.ChangeHealthWithInfo(new HealthChangeInfo(this, base.TargetUnit.HealthComponent, 0f - base.TrainDamage, isPercent: false, null, canRes: false, ignoreArmor: false, ignoreImmunity: false, isBurn: false, ignoreGrace: true, isCrit: false, isDamageReduced: false, isImmune: false, removeHitEffect: false, showDamageNumbers: true, DamageType.AoE));
		}
		DataTrackingManager.Instance.AddDamageByEnemy(GetType().Name, base.TrainDamage);
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
				HealthChangeInfo info = new HealthChangeInfo(this, component.HealthComponent, 0f - base.TrainDamage, isPercent: false, null, canRes: false, ignoreArmor: false, ignoreImmunity: false, isBurn: false, ignoreGrace: false, isCrit: false, isDamageReduced: false, isImmune: false, removeHitEffect: false, showDamageNumbers: true, DamageType.AoE);
				component.HealthComponent.ChangeHealthWithInfo(info);
				trainDamage = 0f;
				ReachedTrainExplosion();
			}
		}
	}

	protected override void OnHealthChanged(HealthChangeInfo info)
	{
		base.OnHealthChanged(info);
		if (!(knockbackTimer > 0f) && info.HealthChange < 0f && !info.IsBurn)
		{
			if (pushBackCoroutine == null)
			{
				pushBackCoroutine = StartCoroutine(PushBack());
				return;
			}
			StopCoroutine(pushBackCoroutine);
			pushBackCoroutine = StartCoroutine(PushBack());
		}
	}

	public Vector3 PushBackOffset()
	{
		return pushBackValue;
	}

	private IEnumerator PushBack()
	{
		knockbackTimer = knockbackInvulnerabilityDuration;
		base.Anim.Play("HeavyBomberStagger");
		float ms = base.MoveSpeed;
		pushBackValue = base.transform.position + -base.transform.up;
		base.MoveSpeed *= knockbackStrength;
		yield return new WaitForSeconds(knockbackDuration);
		pushBackValue = Vector3.zero;
		pushBackCoroutine = null;
		base.MoveSpeed = ms;
	}
}
