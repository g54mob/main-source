using DV.Simulation.Cars;
using LocoSim.Implementations.Wheels;
using UnityEngine;

namespace DV.Wheels
{
	public abstract class PoweredWheelRotationBase : WheelRotationBase
	{
		protected PoweredWheelsManager poweredWheelsManager;

		protected SimController simController;

		protected override void Awake()
		{
			base.Awake();
			simController = trainCar.SimController;
			poweredWheelsManager = simController?.poweredWheels;
			if (poweredWheelsManager == null || simController == null)
			{
				Debug.LogError("Unexpected state: PoweredWheelRotationBase is missing references. Rotation will not work properly!");
			}
		}

		protected override float GetRPS()
		{
			return simController.tractionPortsFeeder.wheelRpm / 60f;
		}

		protected float GetRollingRPS()
		{
			return base.GetRPS();
		}
	}
}
