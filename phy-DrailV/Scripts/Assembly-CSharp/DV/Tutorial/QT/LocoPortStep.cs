using DV.HUD;
using DV.Simulation.Cars;
using LocoSim.Implementations;
using UnityEngine;

namespace DV.Tutorial.QT
{
	public class LocoPortStep : ALocoControlStep
	{
		private SimController sim;

		private Port port;

		public string PortID { get; private set; }

		public float MinValue { get; private set; }

		public float MaxValue { get; private set; }

		public LocoPortStep(string portID, float min, float max, TrainCar loco, InteriorControlsManager.ControlType controlType, ControlIconQuickTutorialMessage message, QTSemantic semantic, Transform attentionPoint = null, Vector3 attentionOffset = default(Vector3), bool shouldRecheck = true)
			: base(loco, controlType, message, semantic, attentionPoint, attentionOffset, shouldRecheck)
		{
			PortID = portID;
			MinValue = min;
			MaxValue = max;
			sim = loco.GetComponentInChildren<SimController>();
			if (!sim.simFlow.TryGetPort(portID, out port, canBeNullOrEmpty: true))
			{
				port = null;
			}
		}

		protected override bool InternalCheck()
		{
			if (port == null)
			{
				return true;
			}
			float value = port.Value;
			if (value >= MinValue)
			{
				return value <= MaxValue;
			}
			return false;
		}
	}
}
