using DV.Simulation.Controllers;
using LocoSim.Attributes;
using LocoSim.Implementations;
using UnityEngine;

namespace DV.Simulation.Ports
{
	public class WaterDetectorPortFeeder : ASimInitializedController
	{
		[PortId(null, null, true)]
		public string statePortId;

		private Port statePort;

		private TrainBuoyancyController buoyancy;

		public override void Init(TrainCar car, SimulationFlow simFlow)
		{
			buoyancy = car.GetComponent<TrainBuoyancyController>();
			if (!simFlow.TryGetPort(statePortId, out statePort))
			{
				Debug.LogError("[" + base.gameObject.GetPath() + "]: WaterDetectorPortFeeder isn't initialized properly! Destroying self", this);
				Object.Destroy(this);
			}
			else
			{
				buoyancy.OnEnterWater += OnWaterEnter;
				buoyancy.OnExitWater += OnWaterExit;
			}
		}

		private void OnWaterEnter()
		{
			statePort.ExternalValueUpdate(1f);
		}

		private void OnWaterExit()
		{
			statePort.ExternalValueUpdate(0f);
		}
	}
}
