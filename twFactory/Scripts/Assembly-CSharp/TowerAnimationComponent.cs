using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animation))]
public class TowerAnimationComponent : AnimationComponent, ISavable
{
	public delegate void OnAnimationEvent();

	[SerializeField]
	private AnimationClip autoAttackAnimation;

	private Tower tower;

	private StatsComponent statsComponent;

	private Animation animationComponent;

	private float baseAttackSpeed;

	private float currentAttackSpeed;

	private bool isPaused;

	[Savable("savedAnimationTime", true, false)]
	private float savedAnimationTime;

	public event OnAnimationEvent onAnimationShoot;

	public event OnAnimationEvent onAnimationDoDamage;

	public event OnAnimationEvent onAnimationAllowTargetChange;

	public event OnAnimationEvent onAnimationPreventTargetChange;

	protected override void Awake()
	{
		base.Awake();
		tower = GetComponent<Tower>();
		statsComponent = GetComponent<StatsComponent>();
		animationComponent = GetComponent<Animation>();
	}

	private void Start()
	{
		baseAttackSpeed = statsComponent.GetConfigStat(EStats.AttackSpeed);
		currentAttackSpeed = statsComponent.GetStat(EStats.AttackSpeed);
		statsComponent.onStatChanged += OnAttackSpeedChanged;
		if ((bool)autoAttackAnimation)
		{
			animationComponent.AddClip(autoAttackAnimation, "autoAttack");
		}
		tower.onTowerEnabledChanged += OnTowerEnabledChanged;
		PauseAnimation(!tower.IsEnabled);
		UpdateAttackSpeed();
		if (savedAnimationTime > 0f)
		{
			PlayAutoAttackAnimation(savedAnimationTime);
			savedAnimationTime = 0f;
		}
	}

	public void PlayAutoAttackAnimation()
	{
		if ((bool)autoAttackAnimation)
		{
			animationComponent.Stop();
			animationComponent.Play("autoAttack");
		}
	}

	private void PlayAutoAttackAnimation(float time)
	{
		PlayAutoAttackAnimation();
		IEnumerator enumerator = animationComponent.GetEnumerator();
		try
		{
			if (enumerator.MoveNext())
			{
				((AnimationState)enumerator.Current).time = time;
			}
		}
		finally
		{
			IDisposable disposable = enumerator as IDisposable;
			if (disposable != null)
			{
				disposable.Dispose();
			}
		}
	}

	public bool IsPlayingAutoAttackAnimation()
	{
		return animationComponent["autoAttack"].time > 0f;
	}

	public void PauseAnimation(bool pause)
	{
		if (pause)
		{
			isPaused = true;
			animationComponent["autoAttack"].speed = 0f;
		}
		else
		{
			isPaused = false;
			UpdateAttackSpeed();
		}
	}

	public void StopAnimation()
	{
		animationComponent.Stop();
	}

	private void UpdateAttackSpeed()
	{
		OnAttackSpeedChanged(EStats.AttackSpeed, statsComponent.GetStat(EStats.AttackSpeed), 0f);
	}

	private void OnTowerEnabledChanged(bool enabled)
	{
		PauseAnimation(!enabled);
	}

	private void OnAttackSpeedChanged(EStats stat, float newValue, float oldValue)
	{
		if (stat == EStats.AttackSpeed)
		{
			currentAttackSpeed = newValue;
		}
		if (!isPaused && (bool)animationComponent && (bool)animationComponent["autoAttack"])
		{
			animationComponent["autoAttack"].speed = currentAttackSpeed / baseAttackSpeed;
		}
	}

	public void AnimationEventShoot()
	{
		this.onAnimationShoot?.Invoke();
	}

	public void AnimationEventDoDamage()
	{
		this.onAnimationDoDamage?.Invoke();
	}

	public void AnimationEventAllowTargetChange()
	{
		this.onAnimationAllowTargetChange?.Invoke();
	}

	public void AnimationEventPreventTargetChange()
	{
		this.onAnimationPreventTargetChange?.Invoke();
	}

	public void OnSave()
	{
		if (animationComponent.isPlaying)
		{
			savedAnimationTime = animationComponent["autoAttack"].time;
		}
	}

	public void OnPreLoad()
	{
	}

	public void OnLoad(Dictionary<string, object> data, bool hasLoadedSomething)
	{
	}
}
