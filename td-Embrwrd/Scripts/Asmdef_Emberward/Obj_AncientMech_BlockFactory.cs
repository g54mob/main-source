using System.Collections.Generic;
using UnityEngine;

public class Obj_AncientMech_BlockFactory : Obj_AncientMech_Base
{
	[SerializeField]
	private Animator animator;

	[SerializeField]
	private List<Spin> list_spin;

	[SerializeField]
	private List<ParticleSystem> list_Particle_Smoke;

	private bool isFirstConnected;

	protected override void OnEnableProc()
	{
	}

	protected override void OnDisableProc()
	{
	}

	private void OnRoundStart(int arg1, int arg2)
	{
	}

	private void GiveBlockCard()
	{
	}

	protected override void OnEffectActivateProc()
	{
	}

	protected override void OnEffectDeactivateProc()
	{
	}
}
