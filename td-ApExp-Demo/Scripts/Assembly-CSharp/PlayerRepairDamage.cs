using System.Collections.Generic;
using UnityEngine;

public class PlayerRepairDamage : StatePlayerBase
{
	private Interactor interactor;

	private Interactable currentInteractable;

	private Health healthComponent;

	private Interactable lastInteractedWith;

	private Health previous;

	private Health next;

	private List<MilestoneDamageFixed> milestones;

	private float coopSpeedModifier = 1f;

	private GameObject timingBar;

	public override string Key => "RepairDamage";

	public PlayerRepairDamage(StateMachine sm, PlayerController player)
		: base(sm, player)
	{
		transitionStates = new string[4] { "Interact", "RepairMinigame", "Walk", "Idle" };
	}

	public PlayerRepairDamage(StateMachine sm, PlayerController player, string[] transitionStates)
		: base(sm, player, transitionStates)
	{
	}

	public override void Initialize()
	{
		interactor = player.interactor;
		milestones = MilestoneManager.Instance.DamageFixedMilestones;
	}

	public override bool CanEnter()
	{
		currentInteractable = interactor.ActiveInteractable;
		if (currentInteractable == null)
		{
			return false;
		}
		if (!currentInteractable.TryGetComponent<Health>(out healthComponent))
		{
			return false;
		}
		if ((player.Repair || sm.CurrentState.Key == "RepairMinigame") && healthComponent.HealthCurrent > 0f)
		{
			return healthComponent.HealthCurrent < healthComponent.HealthMax;
		}
		return false;
	}

	public override void EnterState()
	{
		player.animator.Play("Repair");
		player.audioSource.clip = player.sounds[1];
		player.audioSource.Play();
		if (player.RawInput != Vector2.zero)
		{
			player.LockMoveDirection(player.RawInput);
		}
		coopSpeedModifier = (PlayerManager.Instance.IsCoop ? DifficultyManager.Instance.CoopRepairSpeedMultiplier : 1f);
	}

	public override void UpdateState()
	{
		if (currentInteractable != lastInteractedWith)
		{
			FindAdjacentModules();
		}
		lastInteractedWith = currentInteractable;
		player.rb2d.velocity = Vector2.zero;
		player.AimTarget(currentInteractable.transform);
		if (player.pauseRepairing)
		{
			return;
		}
		float num = player.RepairSpeed * player.speedModifierRepair * coopSpeedModifier * Time.deltaTime;
		HealthChangeInfo healthChangeInfo = new HealthChangeInfo(this, healthComponent, num, isPercent: false, null, canRes: false, ignoreArmor: false, ignoreImmunity: false, isBurn: false, ignoreGrace: false, isCrit: false, isDamageReduced: false, isImmune: false, removeHitEffect: false, showDamageNumbers: true, DamageType.Healing);
		healthComponent.Heal(healthChangeInfo.HealthChange, healthChangeInfo.source);
		healthComponent.StopBurn();
		DataTrackingManager.Instance.AddDamageRepaired(num);
		if (player.canRepairAdjacentModules)
		{
			RepairAdjacentModules(num);
		}
		foreach (MilestoneDamageFixed milestone in milestones)
		{
			if (!milestone.Completed)
			{
				milestone.AddProgress(num);
			}
		}
	}

	public override void ExitState()
	{
		player.audioSource.Stop();
		player.LockMoveDirection(Vector2.zero);
	}

	public override bool CanExit()
	{
		bool flag = player.RawInput != Vector2.zero;
		return player.GetInteractNoConsume() || healthComponent.HealthCurrent <= 0f || healthComponent.HealthCurrent >= healthComponent.HealthMax || flag;
	}

	private void FindAdjacentModules()
	{
		if (player.canRepairAdjacentModules)
		{
			Module[] array = Train.Instance.FindAdjacentModules(currentInteractable.gameObject.GetComponent<Module>());
			if (array[0] != null)
			{
				previous = array[0].HealthComponent;
			}
			else
			{
				previous = null;
			}
			if (array[1] != null)
			{
				next = array[1].HealthComponent;
			}
			else
			{
				next = null;
			}
		}
	}

	private void RepairAdjacentModules(float healAmount)
	{
		if (previous != null)
		{
			previous.ChangeHealthWithInfo(new HealthChangeInfo(this, previous, healAmount * player.repairAmount, isPercent: false, null, canRes: false, ignoreArmor: false, ignoreImmunity: false, isBurn: false, ignoreGrace: false, isCrit: false, isDamageReduced: false, isImmune: false, removeHitEffect: false, showDamageNumbers: true, DamageType.Healing));
			DataTrackingManager.Instance.AddDamageRepaired(healAmount * player.repairAmount);
		}
		if (next != null)
		{
			next.ChangeHealthWithInfo(new HealthChangeInfo(this, next, healAmount * player.repairAmount, isPercent: false, null, canRes: false, ignoreArmor: false, ignoreImmunity: false, isBurn: false, ignoreGrace: false, isCrit: false, isDamageReduced: false, isImmune: false, removeHitEffect: false, showDamageNumbers: true, DamageType.Healing));
			DataTrackingManager.Instance.AddDamageRepaired(healAmount * player.repairAmount);
		}
	}
}
