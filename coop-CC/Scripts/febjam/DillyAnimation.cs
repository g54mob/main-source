using Aggro.Core;
using UnityEngine;

public class DillyAnimation : EntityBehaviourBase
{
	private static readonly int Yay = Animator.StringToHash("yay");

	public Animator dillyAnimator;

	protected override void OnEntityCreated()
	{
		base.eventManager.AddGlobalListener<ShiftManager.EvMoneyTransaction>(OnTransaction);
	}

	protected override void OnEntityDestroyed()
	{
		base.eventManager.RemoveGlobalListener<ShiftManager.EvMoneyTransaction>(OnTransaction);
	}

	private void OnTransaction(ShiftManager.EvMoneyTransaction ev)
	{
		dillyAnimator.SetTrigger(Yay);
	}
}
