using System.Collections;
using DV.ThingTypes;
using UnityEngine;

namespace DV
{
	public class SteamTenderAutoCoupleMechanism : MonoBehaviour
	{
		private const float STEAM_TENDER_AUTOCOUPLE_RANGE = 2.5f;

		private const float START_CHECKING_WAIT_TIME_LONG = 4f;

		private const float START_CHECKING_WAIT_TIME_SHORT = 1f;

		private const float CHECK_PERIOD = 2f;

		private Coupler rearCoupler;

		private Coroutine checkAutoCoupleCoro;

		private IEnumerator Start()
		{
			rearCoupler = GetComponent<TrainCar>().rearCoupler;
			if (!rearCoupler)
			{
				Debug.LogError("TenderCouplerJointEnstronger couldn't find Coupler component during init", this);
				yield break;
			}
			yield return WaitFor.Seconds(1.5f);
			StartAutoCoupleCoroIfConditionsFulfilled(longStartWait: true);
			SetupListeners(on: true);
		}

		private void OnDisable()
		{
			if (!UnloadWatcher.isUnloading)
			{
				KillAutoCoupleCoro();
			}
		}

		private void SetupListeners(bool on)
		{
			if (on)
			{
				rearCoupler.Coupled += OnCoupled;
				rearCoupler.Uncoupled += OnUncouple;
				rearCoupler.train.OnRerailed += OnRerailed;
				rearCoupler.train.OnDerailed += OnDerailed;
			}
			else
			{
				rearCoupler.Coupled -= OnCoupled;
				rearCoupler.Uncoupled -= OnUncouple;
				rearCoupler.train.OnRerailed -= OnRerailed;
				rearCoupler.train.OnDerailed -= OnDerailed;
			}
		}

		private IEnumerator CheckTenderAutoCouple(bool longStartWait)
		{
			yield return WaitFor.Seconds(longStartWait ? 4f : 1f);
			while (true)
			{
				yield return WaitFor.Seconds(2f);
				if (rearCoupler.IsCoupled())
				{
					Debug.LogError("Unexpected state, coro shouldn't run if rearCoupler is coupled!", this);
					checkAutoCoupleCoro = null;
					yield break;
				}
				Coupler firstCouplerInRange = rearCoupler.GetFirstCouplerInRange(2.5f);
				if (!(firstCouplerInRange != null) || firstCouplerInRange.IsCoupled())
				{
					continue;
				}
				TrainCar train = firstCouplerInRange.train;
				if (!train.derailed && CarTypes.IsTender(train.carLivery) && !(train.frontCoupler != firstCouplerInRange))
				{
					rearCoupler.TryCouple(playAudio: true, viaChainInteraction: false, 2.5f);
					if (rearCoupler.IsCoupled())
					{
						break;
					}
					Debug.LogError("Unexpected state, failed couple attempt!", this);
				}
			}
			checkAutoCoupleCoro = null;
		}

		private void OnRerailed()
		{
			StartAutoCoupleCoroIfConditionsFulfilled(longStartWait: false);
		}

		private void OnUncouple(object sender, UncoupleEventArgs e)
		{
			StartAutoCoupleCoroIfConditionsFulfilled(longStartWait: true);
		}

		private void OnCoupled(object sender, CoupleEventArgs e)
		{
			KillAutoCoupleCoro();
		}

		private void OnDerailed(TrainCar _)
		{
			KillAutoCoupleCoro();
		}

		private void StartAutoCoupleCoroIfConditionsFulfilled(bool longStartWait)
		{
			KillAutoCoupleCoro();
			if (!rearCoupler.train.derailed && !rearCoupler.IsCoupled())
			{
				checkAutoCoupleCoro = StartCoroutine(CheckTenderAutoCouple(longStartWait));
			}
		}

		private void KillAutoCoupleCoro()
		{
			if (checkAutoCoupleCoro != null)
			{
				StopCoroutine(checkAutoCoupleCoro);
				checkAutoCoupleCoro = null;
			}
		}
	}
}
