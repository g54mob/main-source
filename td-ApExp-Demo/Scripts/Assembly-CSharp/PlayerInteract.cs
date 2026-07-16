using UnityEngine;

public class PlayerInteract : StatePlayerBase
{
	private Interactor interactor;

	private Interactable currentInteractable;

	public override string Key => "Interact";

	public PlayerInteract(StateMachine sm, PlayerController player)
		: base(sm, player)
	{
		transitionStates = new string[3] { "RepairDamage", "Idle", "Walk" };
	}

	public PlayerInteract(StateMachine sm, PlayerController player, string[] transitionStates)
		: base(sm, player, transitionStates)
	{
	}

	public override void Initialize()
	{
		interactor = player.interactor;
	}

	public override bool CanEnter()
	{
		if ((bool)interactor.ActiveInteractable && interactor.ActiveInteractable.CanInteract())
		{
			return player.GetInteractNoConsume();
		}
		return false;
	}

	public override void EnterState()
	{
		currentInteractable = interactor.ActiveInteractable;
		if (currentInteractable.isAimable)
		{
			UIManager.Instance.MouseCursor.SetCursorAiming(isAiming: true);
			player.isAiming = true;
		}
		player.rb2d.velocity = Vector2.zero;
		switch (currentInteractable.interactAnim)
		{
		case Interactable.InteractAnims.Idle:
			player.animator.Play("Idle");
			break;
		case Interactable.InteractAnims.Shovel:
			player.animator.Play("Shovel");
			break;
		case Interactable.InteractAnims.Interact:
			player.animator.Play("Interact");
			break;
		}
		currentInteractable?.InteractStart(interactor);
		if (currentInteractable.startOnly)
		{
			sm.ForceState("Idle");
		}
		if (player.RawInput != Vector2.zero && currentInteractable != null && !currentInteractable.startOnly)
		{
			player.LockMoveDirection(player.RawInput);
		}
	}

	public override void UpdateState()
	{
		if ((bool)currentInteractable)
		{
			if (currentInteractable.positionDuringInteract != null)
			{
				player.transform.position = currentInteractable.positionDuringInteract.position;
			}
			if (currentInteractable.aimTargetDuringInteract != null)
			{
				player.AimTarget(currentInteractable.aimTargetDuringInteract);
			}
			currentInteractable.InteractUpdate(interactor);
		}
	}

	public override bool CanExit()
	{
		if (interactor.InteractorState == InteractorStates.Forced)
		{
			return false;
		}
		if (!currentInteractable.CanInteract())
		{
			return true;
		}
		bool num = (player.IsGamepad ? currentInteractable.movementInterruptsGamepad : currentInteractable.movementInterrupts) && player.RawInput != Vector2.zero;
		Health component = currentInteractable.GetComponent<Health>();
		bool flag = false;
		if ((bool)component)
		{
			flag = component.HealthCurrent < component.HealthMax;
		}
		bool flag2 = false;
		flag2 = !currentInteractable.gameObject.GetComponent<ModuleFurnace>() && player.GetInteractNoConsume();
		bool flag3 = flag2 || (player.Repair && flag);
		return num || flag3;
	}

	public override void ExitState()
	{
		player.LockMoveDirection(Vector2Int.zero);
		if (currentInteractable.isAimable)
		{
			UIManager.Instance.MouseCursor.SetCursorAiming(isAiming: false);
			player.isAiming = false;
		}
		currentInteractable.InteractEnd(interactor);
		currentInteractable = null;
		player.CheckRoofsAfterDelay();
	}
}
