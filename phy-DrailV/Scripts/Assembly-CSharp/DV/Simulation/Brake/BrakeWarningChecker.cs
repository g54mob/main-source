using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DV.Utils;
using UnityEngine;

namespace DV.Simulation.Brake
{
	public class BrakeWarningChecker
	{
		private TrainCar trainCar;

		private BrakeSystem brakeSystem;

		private Brakeset brakeset;

		private Coroutine coro;

		public bool BrakeWarningState { get; private set; }

		public event Action<bool> BrakeWarningChanged;

		public void SetTrainCar(TrainCar trainCar)
		{
			if (trainCar != null)
			{
				this.trainCar = trainCar;
				brakeSystem = trainCar.brakeSystem;
				Brakeset.BrakesetsChanged += AnyBrakesetChanged;
				SetBrakeset(brakeSystem.brakeset);
				coro = SingletonBehaviour<CoroutineManager>.Instance.Run(Coro());
			}
			else
			{
				SetWarningState(newState: false);
				SingletonBehaviour<CoroutineManager>.Instance.Stop(coro);
				coro = null;
				Brakeset.BrakesetsChanged -= AnyBrakesetChanged;
				SetBrakeset(null);
				brakeSystem = null;
				this.trainCar = null;
			}
		}

		protected void OnBrakeWarningChanged(bool newState)
		{
			this.BrakeWarningChanged?.Invoke(newState);
		}

		private void SetWarningState(bool newState)
		{
			if (newState != BrakeWarningState)
			{
				BrakeWarningState = newState;
				OnBrakeWarningChanged(newState);
			}
		}

		private void CheckBrakeState()
		{
			SetWarningState(CheckWarningConditions());
		}

		private IEnumerator Coro()
		{
			while (true)
			{
				CheckBrakeState();
				yield return WaitFor.Seconds(2f);
			}
		}

		private bool CheckWarningConditions()
		{
			if (!Globals.G.GameParams.BrakeWarningsAllowed)
			{
				return false;
			}
			if (!brakeset.isLeaking && !brakeset.anyHandbrakeApplied && brakeset.numEnabledTrainBrakeValves == 1)
			{
				return CheckConnectivityMismatchCondition();
			}
			return true;
		}

		private bool CheckConnectivityMismatchCondition()
		{
			List<BrakeSystem> cars = brakeset.cars;
			List<BrakeSystem> list = (from c in GetFullyCoupledCars(trainCar)
				select c.brakeSystem).ToList();
			if (list.Count != cars.Count)
			{
				return true;
			}
			if (list[0] != cars[0])
			{
				list.Reverse();
			}
			return !cars.SequenceEqual(list);
		}

		private static IEnumerable<TrainCar> GetFullyCoupledCars(TrainCar train)
		{
			foreach (TrainCar item in CouplerLogic.GetCoupledCars(train.frontCoupler, requireTightened: true).Reverse())
			{
				yield return item;
			}
			yield return train;
			foreach (TrainCar coupledCar in CouplerLogic.GetCoupledCars(train.rearCoupler, requireTightened: true))
			{
				yield return coupledCar;
			}
		}

		private void AnyBrakesetChanged(bool _)
		{
			SetBrakeset(brakeSystem.brakeset);
		}

		private void BrakesetStateChanged(bool _)
		{
			CheckBrakeState();
		}

		private void SetBrakeset(Brakeset newBrakeset)
		{
			if (brakeset != newBrakeset)
			{
				if (brakeset != null)
				{
					brakeset.LeakStateChanged -= BrakesetStateChanged;
					brakeset.HandbrakesStateChanged -= BrakesetStateChanged;
					brakeset.TrainBrakeCutoutStateChanged -= BrakesetStateChanged;
				}
				brakeset = newBrakeset;
				if (brakeset != null)
				{
					brakeset.LeakStateChanged += BrakesetStateChanged;
					brakeset.HandbrakesStateChanged += BrakesetStateChanged;
					brakeset.TrainBrakeCutoutStateChanged += BrakesetStateChanged;
				}
			}
		}
	}
}
