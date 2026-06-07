using DV.Simulation.Cars;
using LocoSim.Implementations;
using UnityEngine;

namespace DV.Rain
{
	public class WipersSimControlInput : APoweredControlHandler
	{
		public WiperController wiperController;

		public override void Init(TrainCar car, SimulationFlow simFlow)
		{
			base.Init(car, simFlow);
			if (wiperController == null)
			{
				Debug.LogError("Unexpected  state: wiperController is not set. Destroying self");
				Object.Destroy(this);
			}
			else if (wiperController.speeds.Length <= 1)
			{
				Debug.LogError("Unexpected  state: wiperController has only one speed. Destroying self");
				Object.Destroy(this);
			}
		}

		protected override void OnControlChanged(float controlValue)
		{
			UpdateWipersState();
		}

		protected override void OnFuseChanged(bool state)
		{
			UpdateWipersState();
		}

		private void UpdateWipersState()
		{
			if (powerFuse != null && !powerFuse.State)
			{
				wiperController.SetSpeed(0);
			}
			else
			{
				wiperController.SetSpeed(Mathf.RoundToInt(controlPort.Value * (float)(wiperController.speeds.Length - 1)));
			}
		}
	}
}
