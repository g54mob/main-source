using System.Collections;
using DV.Simulation.Controllers;
using UnityEngine;

namespace DV.Simulation.Brake
{
	public class HandbrakeFeedersController : ARefreshableChildrenController<HandbrakeFeeder>
	{
		private BrakeSystem bs;

		private bool handbrakeControlPropagationStopped;

		private IEnumerator Start()
		{
			bs = TrainCar.Resolve(base.transform)?.brakeSystem;
			if (bs == null)
			{
				Debug.LogError("Unexpected state: Couldn't extract BrakeSystem from HandbrakeFeedersController. Destroying self", base.gameObject);
				Object.Destroy(this);
				yield break;
			}
			if (entries.Length == 0)
			{
				Debug.LogError("Unexpected state: There are no HandbrakeFeeder entries . Destroying self", base.gameObject);
				Object.Destroy(this);
				yield break;
			}
			yield return null;
			yield return null;
			HandbrakeFeeder[] array = entries;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].Init(bs.handbrakePosition, OnHandbrakeControlChange);
			}
			bs.HandbrakePositionChanged += OnHandbrakeValueChange;
			yield return null;
			array = entries;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].SetupControlChangedListeners();
			}
		}

		private void OnDestroy()
		{
			if (bs != null)
			{
				bs.HandbrakePositionChanged -= OnHandbrakeValueChange;
			}
			HandbrakeFeeder[] array = entries;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].Deinit();
			}
		}

		private void OnHandbrakeControlChange(float newValue)
		{
			if (!handbrakeControlPropagationStopped)
			{
				handbrakeControlPropagationStopped = true;
				bs.SetHandbrakePosition(newValue, forced: false);
				handbrakeControlPropagationStopped = false;
			}
		}

		private void OnHandbrakeValueChange((float value, bool forced) args)
		{
			if (args.forced)
			{
				handbrakeControlPropagationStopped = true;
			}
			HandbrakeFeeder[] array = entries;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].PropagateValue(args.value, args.forced);
			}
			if (args.forced)
			{
				handbrakeControlPropagationStopped = false;
			}
		}
	}
}
