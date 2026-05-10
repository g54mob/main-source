using UnityEngine;

public abstract class EnemyAbility : ActiveAbility
{
	[SerializeField]
	protected AnimationClip abilityAnimation;

	[SerializeField]
	private bool doEffectOnActivate;

	[SerializeField]
	private float startCooldown;

	private float ogCooldown;

	private EnemyAnimationComponent enemyAnimationComponent;

	protected override void Awake()
	{
		base.Awake();
		enemyAnimationComponent = abilityManager.gameObject.GetComponent<EnemyAnimationComponent>();
	}

	protected override void Start()
	{
		base.Start();
		if (!doEffectOnActivate)
		{
			abilityManager.gameObject.GetComponent<EnemyAnimationComponent>().onAnimationDoAbilityEffect += OnAnimationDoAbilityEffect;
		}
		if ((bool)abilityAnimation)
		{
			abilityManager.gameObject.GetComponent<EnemyAnimationComponent>().onAnimationEnd += OnAnimationEnd;
		}
		if (startCooldown > 0f)
		{
			ogCooldown = base.Cooldown;
			base.Cooldown = startCooldown;
			ApplyCooldown();
		}
	}

	protected override void OnActivate(FActiveAbilityInputData inputData)
	{
		if (doEffectOnActivate || !abilityAnimation)
		{
			DoAbilityEffect(inputData);
		}
		if ((bool)abilityAnimation)
		{
			PlayAbilityAnimation();
		}
		else
		{
			OnAnimationEnd();
		}
	}

	protected void PlayAbilityAnimation()
	{
		if ((bool)abilityAnimation)
		{
			enemyAnimationComponent.PlayAbilityAnimation(abilityAnimation);
		}
	}

	protected void OnAnimationEnd()
	{
		if (base.IsActive)
		{
			ApplyCooldown();
			EndAbility();
		}
	}

	private void OnAnimationDoAbilityEffect()
	{
		if (base.IsActive)
		{
			DoAbilityEffect(currentInputData);
		}
	}

	protected override void OnCooldownEnd()
	{
		if (base.Cooldown != ogCooldown)
		{
			base.Cooldown = ogCooldown;
		}
	}

	protected abstract void DoAbilityEffect(FActiveAbilityInputData inputData);
}
