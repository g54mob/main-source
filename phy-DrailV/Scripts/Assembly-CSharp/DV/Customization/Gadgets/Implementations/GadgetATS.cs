using System;
using DV.HUD;
using DV.JObjectExtstensions;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace DV.Customization.Gadgets.Implementations
{
	public sealed class GadgetATS : ExternallySwitchableGadget
	{
		private const string KEY_MODE = "mode";

		public const float SPEED_THRESHOLD_KMH = 1f;

		public float warningTime = 5f;

		public float[] regimeTimes = new float[6] { 0f, 30f, 60f, 90f, 120f, 240f };

		public float controlImpulseInterval = 0.2f;

		public float currentTimer;

		private float controlImpulseTimer;

		private ILocomotiveRemoteControl remoteControl;

		public int Regime { get; private set; }

		public int RegimesCount => regimeTimes.Length;

		public bool IsOn
		{
			get
			{
				if (base.PowerState)
				{
					return CurrentRegimeTimerLength > 0f;
				}
				return false;
			}
		}

		public bool IsActive
		{
			get
			{
				if (IsOn && !IsLocoConsideredStopped)
				{
					if (remoteControl != null)
					{
						return !remoteControl.IsActivelyControlled;
					}
					return true;
				}
				return false;
			}
		}

		public bool DoWarning => currentTimer < 0f;

		public bool IsStopping => currentTimer < 0f - warningTime;

		public bool IsLocoConsideredStopped
		{
			get
			{
				if (TryReadPort(STDSimPort.WheelSpeedKMH, out var value))
				{
					return Mathf.Abs(value) < 1f;
				}
				return false;
			}
		}

		public float CurrentRegimeTimerLength
		{
			get
			{
				if (!base.PowerState)
				{
					return 0f;
				}
				return regimeTimes[Regime];
			}
		}

		public float CurrentRegimeTimerLengthIgnorePower => regimeTimes[Regime];

		public event Action OnRegimeChanged;

		protected override void OnAfterLinked()
		{
			base.OnAfterLinked();
			remoteControl = (base.IsOnTrainCar ? base.TrainCar.GetComponent<ILocomotiveRemoteControl>() : null);
		}

		protected override void OnBeforeUnlinked()
		{
			remoteControl = null;
			base.OnBeforeUnlinked();
		}

		private void Update()
		{
			if (!IsActive)
			{
				currentTimer = CurrentRegimeTimerLength;
				return;
			}
			currentTimer -= Time.deltaTime;
			if (IsStopping && base.IsOnTrainCar)
			{
				controlImpulseTimer += Time.deltaTime;
				if (controlImpulseTimer > controlImpulseInterval)
				{
					controlImpulseTimer -= controlImpulseInterval;
					UnhandControl(InteriorControlsManager.ControlType.Throttle);
					UnhandControl(InteriorControlsManager.ControlType.TrainBrake);
					base.Controls.Throttle.Move(-1f);
					base.Controls.Brake.Move(1f);
				}
			}
		}

		private void UnhandControl(InteriorControlsManager.ControlType type)
		{
			if (!(base.TrainCar.loadedInterior == null) && base.TrainCar.loadedInterior.TryGetComponent<InteriorControlsManager>(out var component) && component.TryGetControl(type, out var reference) && reference.controlImplBase.IsGrabbed())
			{
				reference.controlImplBase.ForceEndInteraction();
			}
		}

		protected override void OnPowerStateChanged(bool newState)
		{
			this.OnRegimeChanged?.Invoke();
		}

		public void SetRegime(int regime)
		{
			regime = Mathf.Clamp(regime, 0, regimeTimes.Length - 1);
			if (Regime != regime)
			{
				Regime = regime;
				this.OnRegimeChanged?.Invoke();
			}
		}

		public override void SaveDataRequested(JObject dst)
		{
			dst.SetInt("mode", Regime);
			base.SaveDataRequested(dst);
		}

		public override void SaveDataLoaded(JObject src)
		{
			base.SaveDataLoaded(src);
			SetRegime(src.GetInt("mode") ?? 0);
		}
	}
}
