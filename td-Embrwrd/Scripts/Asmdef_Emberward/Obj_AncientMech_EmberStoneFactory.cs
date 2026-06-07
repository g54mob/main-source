using UnityEngine;

public class Obj_AncientMech_EmberStoneFactory : Obj_AncientMech_Base, IInteractable
{
	[SerializeField]
	private Animator animator;

	[SerializeField]
	private ParticleSystem particle_ForgeFlame;

	private int rewardPerRound;

	private int activatedRoundCount;

	protected override void OnEnableProc()
	{
	}

	protected override void OnDisableProc()
	{
	}

	private void OnRoundEnd()
	{
	}

	private void OnPlayerVictory()
	{
	}

	protected override void OnEffectActivateProc()
	{
	}

	protected override void OnEffectDeactivateProc()
	{
	}

	private int GetTotalReward()
	{
		return 0;
	}

	protected void OnMouseEnter()
	{
	}

	protected void OnMouseExit()
	{
	}

	public void OnRayEnter()
	{
	}

	public void OnRayExit()
	{
	}
}
