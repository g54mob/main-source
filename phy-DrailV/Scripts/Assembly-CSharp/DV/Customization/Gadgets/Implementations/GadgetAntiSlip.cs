using System;
using DV.CabControls.Spec;
using DV.HUD;
using UnityEngine;

namespace DV.Customization.Gadgets.Implementations
{
	public class GadgetAntiSlip : ExternallySwitchableGadget
	{
		public float actionIntervalSlipping = 1f / 3f;

		public float actionIntervalReturning = 0.5f;

		public float sandTime = 5f;

		public float resetTime = 2f / 3f;

		private float slippingTime;

		private float nonSlippingTime;

		private float sandExtension;

		private float cooldown;

		private int stepsMade;

		private int minimumExpectedValue = int.MaxValue;

		private float lastValue;

		private bool usedSand;

		private bool isActivated;

		public bool IsActivated
		{
			get
			{
				return isActivated;
			}
			private set
			{
				if (isActivated != value)
				{
					isActivated = value;
					this.IsActivatedChanged?.Invoke();
				}
			}
		}

		public event Action IsActivatedChanged;

		protected override void OnAfterLinked()
		{
			base.OnAfterLinked();
			slippingTime = 0f;
			nonSlippingTime = 0f;
			sandExtension = 0f;
			stepsMade = 0;
			minimumExpectedValue = int.MaxValue;
		}

		private void Update()
		{
			if (!base.PowerState || !base.IsOnTrainCar)
			{
				IsActivated = false;
			}
			else
			{
				if (!base.TrainCar.adhesionController.wheelslipController.IsSome(out var value))
				{
					return;
				}
				bool isWheelslipping = value.IsWheelslipping;
				IsActivated = isWheelslipping || stepsMade != 0;
				sandExtension -= Time.deltaTime;
				cooldown -= Time.deltaTime;
				int num = 1;
				if (TryGetControl(InteriorControlsManager.ControlType.Throttle, out var control) && control.controlImplBase.TryGetComponent<INotchedSpec>(out var component) && component.IsNotched)
				{
					num = component.NotchCount - 1;
				}
				if (!isWheelslipping)
				{
					slippingTime = 0f;
					if (stepsMade > 0)
					{
						nonSlippingTime += Time.deltaTime;
						if (nonSlippingTime > actionIntervalReturning)
						{
							nonSlippingTime -= actionIntervalReturning;
							minimumExpectedValue = Mathf.RoundToInt(base.Controls.Throttle.Value * (float)num) + 1;
							base.Controls.Throttle.Move(1f);
							stepsMade--;
							if (stepsMade == 0)
							{
								minimumExpectedValue = int.MaxValue;
							}
						}
					}
				}
				else if (cooldown <= 0f)
				{
					slippingTime += Time.deltaTime;
					if (slippingTime > 0f)
					{
						slippingTime -= actionIntervalSlipping;
						if (base.TrainCar.loadedInterior != null && base.TrainCar.loadedInterior.TryGetComponent<InteriorControlsManager>(out var component2))
						{
							component2.TryUnhandControl(InteriorControlsManager.ControlType.Throttle);
						}
						minimumExpectedValue = Mathf.RoundToInt(base.Controls.Throttle.Value * (float)num) - 1;
						base.Controls.Throttle.Move(-1f);
						stepsMade++;
						if (sandExtension < sandTime)
						{
							sandExtension = sandTime;
						}
					}
				}
				float num2 = base.Controls.Throttle.Value * (float)num;
				if (num2 < Mathf.Min(lastValue, minimumExpectedValue))
				{
					stepsMade = 0;
					minimumExpectedValue = int.MaxValue;
					cooldown = resetTime;
				}
				lastValue = num2;
				if (sandExtension > 0f)
				{
					if (base.Controls.Sander.Value < 0.5f)
					{
						usedSand = true;
						base.Controls.Sander.Set(1f);
					}
				}
				else if (usedSand)
				{
					usedSand = false;
					base.Controls.Sander.Set(0f);
				}
			}
		}

		private bool TryGetControl(InteriorControlsManager.ControlType type, out InteriorControlsManager.ControlReference control)
		{
			control = default(InteriorControlsManager.ControlReference);
			if (base.TrainCar.loadedInterior == null)
			{
				return false;
			}
			if (!base.TrainCar.loadedInterior.TryGetComponent<InteriorControlsManager>(out var component))
			{
				return false;
			}
			return component.TryGetControl(type, out control);
		}
	}
}
