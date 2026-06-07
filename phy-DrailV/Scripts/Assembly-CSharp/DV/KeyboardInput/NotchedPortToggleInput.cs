using System;
using DV.HUD;
using DV.Interaction.Inputs;
using DV.RailDriver;
using LocoSim.Attributes;
using LocoSim.Implementations;
using UnityEngine;

namespace DV.KeyboardInput
{
	public class NotchedPortToggleInput : AKeyboardInput
	{
		[PortId(null, null, false)]
		public string portId;

		public ActionReference applyAction;

		[NonSerialized]
		public Port port;

		public override bool FixedUpdateTick => false;

		private void Start()
		{
			TrainCar trainCar = TrainCar.Resolve(base.transform);
			SimulationFlow simulationFlow = ((!(trainCar != null)) ? null : trainCar.SimController?.simFlow);
			if (simulationFlow == null)
			{
				Debug.LogError("Couldn't find simFlow, ignoring NotchedPortToggleInput initialization!");
			}
			else if (!simulationFlow.TryGetPort(portId, out port))
			{
				Debug.LogError("[" + base.gameObject.GetPath() + "]: NotchedPortToggleInput isn't initialized properly");
			}
		}

		public override void SetupActions(InteriorControlsManager interiorControlsManager)
		{
			applyAction.Initialize(interiorControlsManager);
		}

		public override void Tick(float deltaTime)
		{
			if (port != null && InputManager.NewPlayer.GetButtonDown(applyAction.id) && PlayerCanReach())
			{
				float num = Mathf.Clamp01(1f - Mathf.Round(port.Value));
				port.ExternalValueUpdate(num);
				RailDriverDisplayDV.DisplayNotification((num > 0.5f) ? DV.RailDriver.RailDriver.DisplayBuffer.ON : DV.RailDriver.RailDriver.DisplayBuffer.OFF);
			}
		}
	}
}
