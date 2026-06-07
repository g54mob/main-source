using LocoSim.Attributes;
using LocoSim.Definitions;
using LocoSim.Implementations;
using UnityEngine;

namespace DV.Simulation.Controllers
{
	public class BoilerSimController : ASimInitializedController
	{
		[PortId(PortValueType.GENERIC, true)]
		public string anglePortId;

		private Port anglePort;

		public override bool ExternalTick => true;

		public override void Init(TrainCar car, SimulationFlow simFlow)
		{
			if (!simFlow.TryGetPort(anglePortId, out anglePort))
			{
				Debug.LogError("[" + base.gameObject.GetPath() + "]: BoilerSimController isn't initialized properly!", this);
				Object.Destroy(this);
			}
		}

		public override void Tick(float deltaTime)
		{
			anglePort.Value = base.transform.eulerAngles.x;
		}
	}
}
