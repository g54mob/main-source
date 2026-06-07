using UnityEngine;

public class CombatAnimationComponent : AnimationComponent
{
	public delegate void OnAnimationEvent();

	[SerializeField]
	private ParticleSystem walkStepPS;

	private StatsComponent statsComponent;

	private float currentAttackSpeed;

	public event OnAnimationEvent onAnimationDoDamage;

	public event OnAnimationEvent onAnimationEnd;

	public event OnAnimationEvent onAnimationSpawnProjectile;

	protected override void Awake()
	{
		base.Awake();
		statsComponent = GetComponent<StatsComponent>();
	}

	private void Start()
	{
		currentAttackSpeed = statsComponent.GetStat(EStats.AttackSpeed);
		statsComponent.onStatChanged += OnAttackSpeedChanged;
	}

	protected override void CheckIsMoving()
	{
		if (movementComp.IsMoving() && !animator.GetBool("IsMoving"))
		{
			animator?.SetFloat("WalkCycleOffset", Random.value);
		}
		base.CheckIsMoving();
	}

	public void PlayAutoAttackAnimation()
	{
		int num = Random.Range(0, 2);
		float length = ((AnimatorOverrideController)animator.runtimeAnimatorController)["AutoAttack_" + num].length;
		float num2 = 1f;
		num2 = length * (1f / currentAttackSpeed);
		animator.SetFloat("AutoAttackSpeedMultiplier", num2);
		animator.Play("AutoAttack_" + num);
	}

	public void PlayAbilityAnimation(int idx)
	{
		animator.Play("Ability_" + idx);
	}

	public void StopAnimation()
	{
		animator.Play("Idle", -1, 0f);
	}

	private void OnAttackSpeedChanged(EStats stat, float newValue, float oldValue)
	{
		if (stat == EStats.AttackSpeed)
		{
			currentAttackSpeed = newValue;
		}
	}

	public void AnimationEventWalkStep()
	{
		if ((bool)walkStepPS)
		{
			walkStepPS.Play();
		}
	}

	public void AnimationEventDoDamage()
	{
		this.onAnimationDoDamage?.Invoke();
	}

	public void AnimationEventEnd()
	{
		this.onAnimationEnd?.Invoke();
	}

	public void AnimationEventSpawnProjectile()
	{
		this.onAnimationSpawnProjectile?.Invoke();
	}
}
