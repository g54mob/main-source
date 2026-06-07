using System;
using DV.HUD;
using DV.Interaction.Inputs;
using DV.RailDriver;
using LocoSim.Attributes;
using LocoSim.Implementations;
using UnityEngine;

namespace DV.KeyboardInput
{
	public class NotchedPortAnalogInput : AKeyboardInput
	{
		[PortId(null, null, false)]
		public string portId;

		public int notchCount;

		public ActionReference applyAction;

		public bool compressZeroToOne;

		[NonSerialized]
		public Port port;

		private float lastValue;

		private bool inputActive;

		private bool updatingValueOurselves;

		public override bool FixedUpdateTick => false;

		private void Start()
		{
			TrainCar trainCar = TrainCar.Resolve(base.transform);
			SimulationFlow simulationFlow = ((!(trainCar != null)) ? null : trainCar.SimController?.simFlow);
			if (simulationFlow == null)
			{
				Debug.LogError("Couldn't find simFlow, ignoring NotchedPortAnalogInput initialization!");
				return;
			}
			if (!simulationFlow.TryGetPort(portId, out port))
			{
				Debug.LogError("[" + base.gameObject.GetPath() + "]: NotchedPortAnalogInput isn't initialized properly");
			}
			port.ValueUpdatedInternally += OnValueInternal;
		}

		public override void SetupActions(InteriorControlsManager interiorControlsManager)
		{
			applyAction.Initialize(interiorControlsManager);
			lastValue = InputManager.NewPlayer.GetAxis(applyAction.id);
			if (compressZeroToOne)
			{
				lastValue = lastValue * 0.5f + 0.5f;
			}
		}

		private void OnValueInternal(float value)
		{
			if (!updatingValueOurselves)
			{
				inputActive = false;
			}
		}

		public override void Tick(float deltaTime)
		{
			if (port == null || !PlayerCanReach() || !applyAction.CanMoveOverridableBaseControl)
			{
				return;
			}
			float num;
			if (InputManager.Actions.pausedInBackground)
			{
				num = lastValue;
			}
			else
			{
				num = InputManager.NewPlayer.GetAxis(applyAction.id);
				if (compressZeroToOne)
				{
					num = num * 0.5f + 0.5f;
				}
			}
			if (Mathf.Abs(num - lastValue) > 0.1f || inputActive)
			{
				lastValue = num;
				float num2 = Mathf.Round(num * (float)(notchCount - 1));
				num2 /= (float)(notchCount - 1);
				if (!Mathf.Approximately(port.Value, num2))
				{
					inputActive = true;
					updatingValueOurselves = true;
					port.ExternalValueUpdate(num2);
					updatingValueOurselves = false;
					RailDriverDisplayDV.DisplayNotification(new DV.RailDriver.RailDriver.DisplayBuffer(Mathf.RoundToInt(num2 * 100f)));
				}
			}
		}
	}
}
