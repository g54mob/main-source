using System;
using DG.Tweening;
using UnityEngine;

public class EnemyAnimationComponent : AnimationComponent
{
	[Header("Enemy animation")]
	[SerializeField]
	private float walkAnimationSpeed;

	[SerializeField]
	private bool playSpawnAnimation;

	private float startWalkAnimationSpeed;

	private bool isPlayingAbilityAnimation;

	private FActiveAbilityInputData currentInputData;

	private StatsComponent statsComponent;

	public float WalkAnimationSpeed
	{
		get
		{
			return walkAnimationSpeed;
		}
		set
		{
			walkAnimationSpeed = value;
			if (!isPlayingAbilityAnimation)
			{
				animator.speed = walkAnimationSpeed;
			}
		}
	}

	public event Action onAnimationDoAbilityEffect;

	public event Action onAnimationEnd;

	protected override void Awake()
	{
		animator = GetComponentInChildren<Animator>();
		statsComponent = GetComponent<StatsComponent>();
		startWalkAnimationSpeed = walkAnimationSpeed;
		if (playSpawnAnimation)
		{
			base.transform.localScale = Vector3.zero;
		}
	}

	private void Start()
	{
		animator.speed = WalkAnimationSpeed;
		statsComponent.onStatChanged += OnStatChanged;
		if (playSpawnAnimation)
		{
			animator.Play("Spawn");
			base.transform.DOScale(1f, 0f).SetDelay(0.05f);
		}
	}

	public void PlayAbilityAnimation(AnimationClip animation, int abilityIdx = 0)
	{
		(animator.runtimeAnimatorController as AnimatorOverrideController)["EnemyAbilityAniamtion_" + abilityIdx + "_empty"] = animation;
		isPlayingAbilityAnimation = true;
		animator.speed = 1f;
		animator.CrossFade("Ability_" + abilityIdx, 0.05f);
	}

	private void OnStatChanged(EStats stat, float newValue, float oldValue)
	{
		if (stat == EStats.MovementSpeed)
		{
			WalkAnimationSpeed = newValue / statsComponent.GetConfigStat(EStats.MovementSpeed) * startWalkAnimationSpeed;
		}
	}

	public void AnimationEventDoAbilityEffect()
	{
		this.onAnimationDoAbilityEffect?.Invoke();
	}

	public void AnimationEventEnd()
	{
		isPlayingAbilityAnimation = false;
		animator.speed = WalkAnimationSpeed;
		this.onAnimationEnd?.Invoke();
	}
}
