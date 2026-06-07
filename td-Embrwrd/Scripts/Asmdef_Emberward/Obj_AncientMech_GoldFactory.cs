using UnityEngine;

public class Obj_AncientMech_GoldFactory : Obj_AncientMech_Base
{
	[SerializeField]
	private Animator animator;

	[SerializeField]
	private ParticleSystem particle_ForgeFlame;

	[SerializeField]
	private ParticleSystem particle_Coin;

	private bool isFirstConnected;

	private int goldOnFirstConnect;

	private int goldPerRound;

	protected override void OnEnableProc()
	{
	}

	protected override void OnDisableProc()
	{
	}

	private void OnRoundStart(int arg1, int arg2)
	{
	}

	protected override void OnEffectActivateProc()
	{
	}

	protected override void OnEffectDeactivateProc()
	{
	}
}
