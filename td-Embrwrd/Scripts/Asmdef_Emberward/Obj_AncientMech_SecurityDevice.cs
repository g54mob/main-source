using System.Collections.Generic;
using UnityEngine;

public class Obj_AncientMech_SecurityDevice : Obj_AncientMech_Base
{
	[SerializeField]
	private Animator animator;

	[SerializeField]
	private Transform node_RangeRing;

	[SerializeField]
	private ParticleSystem particle_Signal;

	[SerializeField]
	private ParticleSystem particle_Signal_OnActivate;

	[SerializeField]
	private List<Obj_AncientTower_Base> list_AncientTowers;

	[SerializeField]
	private float effectRange;

	protected override void OnEnableProc()
	{
	}

	protected override void OnDisableProc()
	{
	}

	protected override void OnEffectActivateProc()
	{
	}

	protected override void OnEffectDeactivateProc()
	{
	}

	private void OnMouseOver()
	{
	}

	private void OnMouseExit()
	{
	}
}
