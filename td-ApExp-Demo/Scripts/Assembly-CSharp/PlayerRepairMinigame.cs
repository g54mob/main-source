using UnityEngine;

public class PlayerRepairMinigame : StatePlayerBase
{
	private Interactor interactor;

	private Interactable currentInteractable;

	public override string Key => "RepairMinigame";

	public PlayerRepairMinigame(StateMachine sm, PlayerController player)
		: base(sm, player)
	{
		transitionStates = new string[3] { "RepairDamage", "Idle", "Walk" };
	}

	public PlayerRepairMinigame(StateMachine sm, PlayerController player, string[] transitionStates)
		: base(sm, player, transitionStates)
	{
	}

	public override void Initialize()
	{
		interactor = player.interactor;
	}

	public override bool CanEnter()
	{
		if (!player.Repair && !(sm.CurrentState.Key == "RepairDamage"))
		{
			return false;
		}
		if (!player.interactor.ActiveInteractable || !player.interactor.ActiveInteractable.TryGetComponent<Health>(out var component))
		{
			return false;
		}
		return component.HealthCurrent <= 0f;
	}

	public override void EnterState()
	{
		currentInteractable = interactor.ActiveInteractable;
		int num = Random.Range(0, GameManager.Instance.RepairMinigames.Length);
		RepairMinigame repairMinigame = GameManager.Instance.RepairMinigames[num];
		player.interactor.repairMinigame = repairMinigame;
		repairMinigame.gameObject.SetActive(value: true);
		repairMinigame.ResetMinigame(interactor);
		player.animator.Play("Repair");
		player.audioSource.clip = player.sounds[1];
		player.audioSource.Play();
		if (player.RawInput != Vector2.zero)
		{
			player.LockMoveDirection(player.RawInput);
		}
	}

	public override void UpdateState()
	{
		player.rb2d.velocity = Vector2.zero;
		player.AimTarget(currentInteractable.transform);
	}

	public override void ExitState()
	{
		interactor.repairMinigame.gameObject.SetActive(value: false);
		player.interactor.repairMinigame = null;
		player.audioSource.Stop();
		player.LockMoveDirection(Vector2.zero);
	}

	public override bool CanExit()
	{
		if (!player.Repair)
		{
			return !player.interactor.repairMinigame.gameObject.activeSelf;
		}
		return true;
	}
}
