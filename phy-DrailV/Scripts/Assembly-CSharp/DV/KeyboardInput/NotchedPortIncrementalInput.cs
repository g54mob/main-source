using System;
using DV.HUD;
using DV.Interaction.Inputs;
using DV.RailDriver;
using LocoSim.Attributes;
using LocoSim.Implementations;
using UnityEngine;

namespace DV.KeyboardInput
{
	public class NotchedPortIncrementalInput : AKeyboardInput
	{
		[PortId(null, null, false)]
		public string portId;

		public int notchCount;

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
				Debug.LogError("Couldn't find simFlow, ignoring NotchedPortIncrementalInput initialization!");
			}
			else if (!simulationFlow.TryGetPort(portId, out port))
			{
				Debug.LogError("[" + base.gameObject.GetPath() + "]: NotchedPortIncrementalInput isn't initialized properly");
			}
		}

		public override void SetupActions(InteriorControlsManager interiorControlsManager)
		{
			applyAction.Initialize(interiorControlsManager);
		}

		public override void Tick(float deltaTime)
		{
			if (port != null && InputManager.NewPlayer.GetAnyDirButtonDown(applyAction.id) && PlayerCanReach())
			{
				bool flag = InputManager.NewPlayer.GetButtonDown(applyAction.id);
				if (applyAction.flip)
				{
					flag = !flag;
				}
				float value = port.Value;
				float num = 1f / (float)(notchCount - 1);
				value += (flag ? num : (0f - num));
				value = Mathf.Clamp01(value);
				port.ExternalValueUpdate(value);
				RailDriverDisplayDV.DisplayNotification(new DV.RailDriver.RailDriver.DisplayBuffer(Mathf.RoundToInt(value * 100f)));
			}
		}
	}
}
