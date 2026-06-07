using System;
using DV.CabControls.Spec;
using DV.HUD;
using UnityEngine;

namespace DV.Simulation.Controllers
{
	public class HandbrakeControl
	{
		private const float SMOOTH_SPEED_MODIFIER = 0.5f;

		private InteriorControlsManager interiorControlsManager;

		protected TrainCar car;

		public virtual float Value => car.brakeSystem.handbrakePosition;

		public float NotchCount { get; protected set; } = 1f;

		public bool IsNotched { get; protected set; }

		private InteriorControlsManager.ControlType ControlType => InteriorControlsManager.ControlType.Handbrake;

		protected virtual bool canExistWithoutHandbrake => false;

		public event Action<float> ControlUpdated;

		public HandbrakeControl(TrainCar car, ControlSpec spec)
		{
			if (!canExistWithoutHandbrake && !car.brakeSystem.hasHandbrake)
			{
				Debug.LogError("Unexpected state: hasHandbrake is false. HandbrakeControl shouldn't exist");
			}
			this.car = car;
			if (spec is INotchedSpec notchedSpec)
			{
				IsNotched = notchedSpec.IsNotched;
				NotchCount = notchedSpec.NotchCount;
			}
			car.brakeSystem.HandbrakePositionChanged += OnControlUpdated;
		}

		protected void OnControlUpdated((float value, bool forced) args)
		{
			this.ControlUpdated?.Invoke(args.value);
		}

		public void SetInteriorControlsManager(InteriorControlsManager interiorControlsManager)
		{
			this.interiorControlsManager = interiorControlsManager;
		}

		public virtual void Set(float value)
		{
			car.brakeSystem.SetHandbrakePosition(value);
		}

		public void Move(float notches)
		{
			if (interiorControlsManager != null && !interiorControlsManager.MoveScrollable(ControlType, (int)notches))
			{
				if (!IsNotched)
				{
					Set(Value + notches);
				}
				else
				{
					Set(Value + notches / NotchCount);
				}
			}
		}
	}
}
