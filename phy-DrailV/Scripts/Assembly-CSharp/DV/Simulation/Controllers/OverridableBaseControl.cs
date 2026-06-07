using System;
using DV.CabControls.Spec;
using DV.HUD;
using LocoSim.Attributes;
using LocoSim.Definitions;
using LocoSim.Implementations;
using UnityEngine;

namespace DV.Simulation.Controllers
{
	public abstract class OverridableBaseControl : MonoBehaviour
	{
		private const float SMOOTH_SPEED_MODIFIER = 0.5f;

		[PortId(PortType.EXTERNAL_IN, PortValueType.CONTROL, false, local = true)]
		public string portId;

		[Header("optional")]
		public ControlBlocker controlBlocker;

		protected TrainCar car;

		protected InteriorControlsManager interiorControlsManager;

		protected bool muOverrideInProgress;

		protected bool forceFurtherPropagationOfMuOverride;

		protected float defaultValue;

		private Port controlPort;

		public abstract InteriorControlsManager.ControlType ControlType { get; }

		public float Value => controlPort?.Value ?? defaultValue;

		public float NotchCount { get; private set; } = 1f;

		public bool IsNotched { get; private set; }

		public bool IsControlBlocked
		{
			get
			{
				if (controlBlocker != null && controlBlocker.isBlocked)
				{
					return !muOverrideInProgress;
				}
				return false;
			}
		}

		public event Action<float> ControlUpdated;

		public virtual void Init(TrainCar car, SimulationFlow simFlow, ControlSpec spec)
		{
			if (!simFlow.TryGetPort(portId, out controlPort))
			{
				Debug.LogError("[" + base.gameObject.GetPath() + "]: OverridableBaseControl isn't initialized properly! Destroying self.", base.gameObject);
				UnityEngine.Object.Destroy(this);
				return;
			}
			this.car = car;
			if (spec is INotchedSpec notchedSpec)
			{
				IsNotched = notchedSpec.IsNotched;
				NotchCount = notchedSpec.NotchCount;
			}
			controlPort.ValueUpdatedInternally += OnControlUpdated;
		}

		protected virtual void OnControlUpdated(float value)
		{
			if (!muOverrideInProgress || forceFurtherPropagationOfMuOverride)
			{
				this.ControlUpdated?.Invoke(value);
			}
		}

		public void SetInteriorControlsManager(InteriorControlsManager interiorControlsManager)
		{
			this.interiorControlsManager = interiorControlsManager;
		}

		public virtual void Set(float value)
		{
			if (!IsControlBlocked)
			{
				controlPort.ExternalValueUpdate(Mathf.Clamp01(value));
			}
		}

		public void Move(float notches)
		{
			if ((!(controlBlocker != null) || !controlBlocker.isBlocked) && (interiorControlsManager == null || !interiorControlsManager.MoveScrollable(ControlType, (int)notches)))
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

		public void MUOverride(float value, bool forceFurtherPropagationOfMuOverride = false)
		{
			this.forceFurtherPropagationOfMuOverride = forceFurtherPropagationOfMuOverride;
			muOverrideInProgress = true;
			Set(value);
			muOverrideInProgress = false;
			this.forceFurtherPropagationOfMuOverride = false;
		}
	}
}
