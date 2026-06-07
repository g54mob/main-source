using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActiveAbility : Ability, ISavable
{
	public delegate void OnCooldownChanged();

	[SerializeField]
	private float cooldown = 1f;

	[SerializeField]
	protected bool useAttackSpeedAsCooldown;

	[SerializeField]
	private bool checkRange = true;

	[SerializeField]
	private bool useBaseRange = true;

	[SerializeField]
	private float range;

	[SerializeField]
	private bool canMove;

	[SerializeField]
	private bool canBeCanceled = true;

	[SerializeField]
	protected bool canBeQueued = true;

	protected FActiveAbilityInputData currentInputData;

	private float cooldownTimeEnd;

	private bool isDisabled;

	[Savable("savedRemainingCooldown", true, false)]
	private float savedRemainingCooldown;

	private bool hasLoadedData;

	private Coroutine waitCooldownCoroutine;

	public bool IsDisabled
	{
		get
		{
			return isDisabled;
		}
		set
		{
			isDisabled = value;
			if (isDisabled)
			{
				CancelAbility();
			}
		}
	}

	public override bool IsLocked
	{
		get
		{
			return base.IsLocked;
		}
		set
		{
			base.IsLocked = value;
			if (base.IsLocked)
			{
				CancelAbility();
			}
		}
	}

	public bool CanMove
	{
		get
		{
			return canMove;
		}
		protected set
		{
			canMove = value;
		}
	}

	public bool CanBeQueued => canBeQueued;

	protected float Cooldown
	{
		get
		{
			return cooldown;
		}
		set
		{
			float num = cooldown;
			cooldown = value;
			if (IsInCooldown())
			{
				cooldownTimeEnd -= num - cooldown;
				if (Time.time < cooldownTimeEnd && waitCooldownCoroutine != null)
				{
					this.StartCoroutineCheckingVar(WaitCooldown(cooldownTimeEnd - Time.time), ref waitCooldownCoroutine, stopCoroutineIfRunning: true);
				}
			}
		}
	}

	public event OnCooldownChanged onColdoownStart;

	public event OnCooldownChanged onColdoownEnd;

	protected override void Start()
	{
		base.Start();
		if (useAttackSpeedAsCooldown && (bool)base.AbilityManager.StatsComponent)
		{
			SetAttackSpeedAsCooldown(base.AbilityManager.StatsComponent.GetStat(EStats.AttackSpeed));
			base.AbilityManager.StatsComponent.onStatChanged += OnStatChanged;
		}
		if (hasLoadedData)
		{
			this.StartCoroutineCheckingVar(WaitCooldown(savedRemainingCooldown), ref waitCooldownCoroutine, stopCoroutineIfRunning: true);
		}
	}

	public virtual bool CanActivate(FActiveAbilityInputData inputData)
	{
		if (!CanActivate_Internal())
		{
			return false;
		}
		if (IsDisabled || IsInCooldown())
		{
			return false;
		}
		if (checkRange)
		{
			bool flag = false;
			if ((bool)inputData.target)
			{
				return GetRange() * GetRange() >= FunctionLibrary.SqrDistanceBetweenObjects(abilityManager.gameObject, inputData.target.gameObject);
			}
			return GetRange() * GetRange() >= FunctionLibrary.SqrDistanceBetweenObjectAndPosition(abilityManager.gameObject, inputData.position);
		}
		return true;
	}

	public virtual bool CanQueue()
	{
		return CanBeQueued;
	}

	public float GetRange()
	{
		if (!useBaseRange)
		{
			return range;
		}
		return abilityManager.StatsComponent.GetStat(EStats.Range);
	}

	public float GetCooldownRemaining()
	{
		return Mathf.Max(cooldownTimeEnd - Time.time, 0f);
	}

	public bool IsInCooldown()
	{
		return GetCooldownRemaining() != 0f;
	}

	public bool StartAbility(FActiveAbilityInputData inputData)
	{
		if (!CanActivate(inputData) || !StartAbility_Internal())
		{
			return false;
		}
		if (!CanMove && base.AbilityManager.Character?.movementComponent?.MovementEnabled == true)
		{
			base.AbilityManager.Character.movementComponent.StopMovement();
			base.AbilityManager.Character.movementComponent.MovementEnabled = false;
		}
		currentInputData = inputData;
		OnActivate(inputData);
		return true;
	}

	public virtual bool CancelAbility()
	{
		if (canBeCanceled)
		{
			base.AbilityManager.AnimationComponent?.StopAnimation();
			OnCancelAbility();
			EndAbility(canceled: true);
			return true;
		}
		return false;
	}

	protected void EndAbility(bool canceled = false)
	{
		if (!CanMove && ((!(base.AbilityManager.Character?.movementComponent?.MovementEnabled)) ?? false))
		{
			base.AbilityManager.Character.movementComponent.MovementEnabled = true;
		}
		OnEndAbility(canceled);
		EndAbility_Internal(canceled);
	}

	protected void ApplyCooldown()
	{
		if (Cooldown > 0f)
		{
			cooldownTimeEnd = Time.time + Cooldown;
			this.onColdoownStart?.Invoke();
			if (base.gameObject.activeSelf)
			{
				this.StartCoroutineCheckingVar(WaitCooldown(Cooldown), ref waitCooldownCoroutine, stopCoroutineIfRunning: true);
			}
		}
	}

	private IEnumerator WaitCooldown(float cooldown)
	{
		if (cooldown > 0f)
		{
			yield return new WaitForSeconds(cooldown);
			OnCooldownEnd();
			this.onColdoownEnd?.Invoke();
		}
		waitCooldownCoroutine = null;
	}

	protected virtual void PlayAnimation()
	{
		if ((bool)base.AbilityManager.AnimationComponent && base.AbilityManager.GetAutoAttackAbility().gameObject == base.gameObject)
		{
			base.AbilityManager.AnimationComponent.PlayAutoAttackAnimation();
		}
	}

	protected abstract void OnActivate(FActiveAbilityInputData inputData);

	protected virtual void OnEndAbility(bool canceled)
	{
	}

	public virtual void OnQueue()
	{
	}

	public virtual void OnDequeue()
	{
	}

	protected virtual void OnCancelAbility()
	{
	}

	protected virtual void OnCooldownEnd()
	{
	}

	protected virtual void OnAnimationDoDamage()
	{
	}

	protected virtual void OnAnimationEnds()
	{
	}

	private void SetAttackSpeedAsCooldown(float attackSpeed)
	{
		Cooldown = 1f / ((attackSpeed > 0f) ? attackSpeed : 0.0001f);
	}

	private void OnStatChanged(EStats stat, float newValue, float oldValue)
	{
		if (stat == EStats.AttackSpeed)
		{
			SetAttackSpeedAsCooldown(newValue);
		}
	}

	public override void OnSave()
	{
		savedRemainingCooldown = cooldownTimeEnd - Time.time;
	}

	public override void OnPreLoad()
	{
	}

	public override void OnLoad(Dictionary<string, object> data, bool hasLoadedSomething)
	{
		hasLoadedData = hasLoadedSomething;
	}
}
