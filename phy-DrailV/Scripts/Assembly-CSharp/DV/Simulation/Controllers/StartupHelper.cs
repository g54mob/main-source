using System.Collections;
using DV.Simulation.Brake;
using DV.Simulation.Cars;
using DV.ThingTypes;
using DV.Utils;
using LocoSim.Implementations;

namespace DV.Simulation.Controllers
{
	public static class StartupHelper
	{
		public static void Startup(TrainCar loco)
		{
			SimController simController = loco?.SimController;
			SimulationFlow simulationFlow = simController?.SimulationFlow;
			BaseControlsOverrider baseControlsOverrider = simController?.controlsOverrider;
			if (simController == null || simulationFlow == null || baseControlsOverrider == null)
			{
				return;
			}
			baseControlsOverrider.BrakeCutout?.Set(1f);
			baseControlsOverrider.Handbrake?.Set(0f);
			baseControlsOverrider.IndependentBrake?.Set(1f);
			BrakeSystem brakeSystem = loco.brakeSystem;
			if (brakeSystem != null && brakeSystem.hasCompressor)
			{
				brakeSystem.SetMainReservoirPressure(9f);
			}
			if (CarTypes.IsSteamLocomotive(loco.carLivery))
			{
				FireboxSimController firebox = simController.firebox;
				if (firebox != null)
				{
					firebox.TransferCoal(9999999f);
					firebox.Ignite();
				}
				baseControlsOverrider.Dynamo?.Set(1f);
				baseControlsOverrider.AirPump?.Set(1f);
				BasePortsOverrider basePortsOverrider = simController?.portsOverrider;
				if (basePortsOverrider != null)
				{
					basePortsOverrider.BoilerSpecialRequest(3f);
					basePortsOverrider.OilingPointsSpecialRequest(1f);
					basePortsOverrider.LubricatorSpecialRequest(1f);
				}
			}
			else
			{
				for (int i = 0; i < simulationFlow.AllFuses.Count; i++)
				{
					simulationFlow.AllFuses[i].ChangeState(newState: true);
				}
				if (baseControlsOverrider.Starter != null)
				{
					SingletonBehaviour<CoroutineManager>.Instance.Run(DieselStarterCoro(baseControlsOverrider));
				}
			}
		}

		private static IEnumerator DieselStarterCoro(BaseControlsOverrider overrider)
		{
			overrider.Starter.Set(1f);
			float safety = 5f;
			while (safety >= 0f && !overrider.EngineOnReader.IsOn)
			{
				yield return WaitFor.Seconds(1f);
				safety -= 1f;
			}
			overrider.Starter.Set(0f);
		}
	}
}
