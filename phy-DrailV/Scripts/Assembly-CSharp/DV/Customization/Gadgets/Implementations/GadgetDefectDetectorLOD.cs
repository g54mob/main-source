using DV.CabControls;
using UnityEngine;

namespace DV.Customization.Gadgets.Implementations
{
	public class GadgetDefectDetectorLOD : CustomizerLODObject<GadgetBase>
	{
		public GameObject buttonSnooze;

		public LampControl indicatorPower;

		public LampControl indicatorDefect;

		private bool hasDefect;

		private bool isSnoozed;

		private void Start()
		{
			buttonSnooze.GetComponent<ButtonBase>().Used += Snooze;
			base.Base.AfterLinked += Linked;
			base.Base.BeforeUnlinked += Unlinked;
			if (base.Base.IsLinked)
			{
				Linked();
			}
		}

		private void Linked(object _ = null, object __ = null)
		{
			if (base.Base.IsOnTrainCar)
			{
				base.Base.TrainCar.TrainsetAboutToBeChanged += BeforeTrainSetChange;
				base.Base.TrainCar.TrainsetChanged += AfterTrainSetChange;
				AfterTrainSetChange();
			}
			UpdateOverlay();
		}

		private void Unlinked(object _ = null, object __ = null)
		{
			if (base.Base.IsOnTrainCar)
			{
				BeforeTrainSetChange();
				base.Base.TrainCar.TrainsetAboutToBeChanged -= BeforeTrainSetChange;
				base.Base.TrainCar.TrainsetChanged -= AfterTrainSetChange;
			}
		}

		private void AfterTrainSetChange(object _ = null)
		{
			foreach (TrainCar car in base.Base.TrainCar.trainset.cars)
			{
				car.OnDerailed += Derailed;
				car.OnRerailed += Rerailed;
				car.brakeSystem.heatController.OverheatingActiveStateChanged += OverheatingChanged;
			}
		}

		private void BeforeTrainSetChange(object _ = null)
		{
			if (UnloadWatcher.isUnloading)
			{
				return;
			}
			foreach (TrainCar car in base.Base.TrainCar.trainset.cars)
			{
				car.OnDerailed -= Derailed;
				car.OnRerailed -= Rerailed;
				car.brakeSystem.heatController.OverheatingActiveStateChanged -= OverheatingChanged;
			}
		}

		private void Derailed(object _ = null)
		{
			Alert();
		}

		private void Rerailed()
		{
			CheckDefect();
		}

		private void PowerStateChanged(object _ = null)
		{
			CheckDefect();
		}

		private void OverheatingChanged(bool newState)
		{
			if (newState)
			{
				Alert();
			}
			else
			{
				CheckDefect();
			}
		}

		protected internal override void OnPowerStateChanged(bool newValue)
		{
			CheckDefect();
		}

		private void CheckDefect()
		{
			hasDefect = false;
			if (!base.IsOnTrainCar || !base.Base.PowerState)
			{
				UpdateOverlay();
				return;
			}
			foreach (TrainCar car in base.Base.TrainCar.trainset.cars)
			{
				if (car.derailed)
				{
					hasDefect = true;
				}
				if (car.brakeSystem.heatController.overheatPercentage > 0f)
				{
					hasDefect = true;
				}
				if (hasDefect)
				{
					break;
				}
			}
			UpdateOverlay();
		}

		private void UpdateOverlay()
		{
			bool powerState = base.Base.PowerState;
			if (!hasDefect || !powerState)
			{
				isSnoozed = false;
			}
			indicatorPower.SetLampState(powerState ? LampControl.LampState.On : LampControl.LampState.Off);
			indicatorDefect.SetLampState((powerState && hasDefect) ? (isSnoozed ? LampControl.LampState.On : LampControl.LampState.Blinking) : LampControl.LampState.Off);
		}

		private void Alert()
		{
			hasDefect = true;
			isSnoozed = false;
			UpdateOverlay();
		}

		private void Snooze()
		{
			isSnoozed = hasDefect;
			UpdateOverlay();
		}
	}
}
