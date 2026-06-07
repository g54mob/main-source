using System;
using System.Collections;
using DV;
using DV.Interaction.Inputs;
using DV.Utils;
using UnityEngine;

public class ChainCouplerCouplerAdapter : MonoBehaviour
{
	public ChainCouplerInteraction chainScript;

	[NonSerialized]
	public Coupler coupler;

	private void Start()
	{
		SingletonBehaviour<CoroutineManager>.Instance.Run(Init());
	}

	private IEnumerator Init()
	{
		int safety = 100;
		while (coupler == null)
		{
			int num = safety - 1;
			safety = num;
			if (num <= 0)
			{
				Debug.LogError("ChainCouplerCouplerAdapter didn't get its Coupler assigned", base.gameObject);
				yield break;
			}
			yield return null;
		}
		coupler.Coupled += OnCoupled;
		coupler.Uncoupled += OnUncoupled;
	}

	private void OnDestroy()
	{
		if ((bool)coupler)
		{
			coupler.Coupled -= OnCoupled;
			coupler.Uncoupled -= OnUncoupled;
		}
	}

	private void OnCoupled(object _, CoupleEventArgs e)
	{
		if (!e.viaChainInteraction)
		{
			chainScript.CoupledExternally(e.otherCoupler);
		}
	}

	private void OnUncoupled(object _, UncoupleEventArgs e)
	{
		if (e.dueToBrokenCouple)
		{
			chainScript.CoupleBrokenExternally();
		}
		else if (!e.viaChainInteraction)
		{
			chainScript.UncoupledExternally();
		}
	}

	public bool IsCoupled()
	{
		if (coupler == null)
		{
			return false;
		}
		return coupler.IsCoupled();
	}

	public void TryCouple()
	{
		if (coupler == null)
		{
			Debug.LogWarning("No actual Coupler was found on '" + base.transform.root.name + "'", this);
			return;
		}
		bool releaseHandbrakesOnCoupledCars = Globals.G.GameParams.AutoHandbrakeViaManualCouplingAllowed && !InputManager.NewPlayer.GetButton(InputManager.Actions.Run);
		CouplerLogic.CoupleFirstInRange(coupler, 1.5f, releaseHandbrakesOnCoupledCars, viaChainInteraction: true, playAudio: false);
	}

	public void TryUncouple()
	{
		if (coupler == null)
		{
			Debug.LogWarning("No actual Coupler was found on '" + base.transform.root.name + "'", this);
			return;
		}
		bool applyHandbrakeToUncoupledCar = Globals.G.GameParams.AutoHandbrakeViaManualCouplingAllowed && !InputManager.NewPlayer.GetButton(InputManager.Actions.Run);
		CouplerLogic.Uncouple(coupler, applyHandbrakeToUncoupledCar, viaChainInteraction: true, playAudio: false);
	}
}
