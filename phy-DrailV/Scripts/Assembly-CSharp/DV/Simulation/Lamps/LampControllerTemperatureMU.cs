using DV.Simulation.Cars;
using LocoSim.Attributes;
using LocoSim.Implementations;
using UnityEngine;

namespace DV.Simulation.Lamps
{
	public class LampControllerTemperatureMU : MonoBehaviour
	{
		[FuseId]
		[SerializeField]
		private string fuseId;

		private LampControl lamp;

		private Fuse fuse;

		private MultipleUnitStateObserver multipleUnitStateObserver;

		private void Awake()
		{
			lamp = GetComponent<LampControl>();
			if (lamp == null)
			{
				Debug.LogError("Unexpected state: LampControl not found. LampControllerTemperatureMU is useless. Destroying self!", base.gameObject);
				Object.Destroy(this);
				return;
			}
			TrainCar trainCar = TrainCar.Resolve(base.gameObject);
			multipleUnitStateObserver = trainCar.GetComponent<MultipleUnitStateObserver>();
			if (multipleUnitStateObserver == null)
			{
				Debug.LogError("Unexpected state: multipleUnitStateObserver missing. Destroying self!", base.gameObject);
				Object.Destroy(this);
				return;
			}
			if (string.IsNullOrEmpty(fuseId))
			{
				SimulationFlow simulationFlow = trainCar?.SimController?.simFlow;
				if (simulationFlow != null)
				{
					if (!simulationFlow.TryGetFuse(fuseId, out fuse))
					{
						Debug.LogError("[" + base.gameObject.GetPath() + "]: LampControllerTemperatureMU isn't initialized properly, fuse wont' be set");
					}
				}
				else
				{
					Debug.LogError("simFlow not found, fuse will not be set!");
				}
			}
			UpdateLampState(multipleUnitStateObserver.MUChainTemperatureState, muteAudio: true);
			if (multipleUnitStateObserver != null)
			{
				multipleUnitStateObserver.MUChainTemperatureChanged += OnTemperatureChanged;
			}
			if (fuse != null)
			{
				fuse.StateUpdated += OnFuseStateUpdated;
			}
		}

		private void OnDestroy()
		{
			if (multipleUnitStateObserver != null)
			{
				multipleUnitStateObserver.MUChainTemperatureChanged -= OnTemperatureChanged;
			}
			if (fuse != null)
			{
				fuse.StateUpdated -= OnFuseStateUpdated;
			}
		}

		private void OnFuseStateUpdated(bool on)
		{
			UpdateLampState(multipleUnitStateObserver.MUChainTemperatureState);
		}

		private void OnTemperatureChanged(MultipleUnitStateObserver.TemperatureState prevTempStateUnused, MultipleUnitStateObserver.TemperatureState currentTemperatureState)
		{
			UpdateLampState(currentTemperatureState);
		}

		private void UpdateLampState(MultipleUnitStateObserver.TemperatureState tempState, bool muteAudio = false)
		{
			if (fuse != null && !fuse.State)
			{
				lamp.SetLampState(LampControl.LampState.Off);
				return;
			}
			LampControl.LampState state = LampControl.LampState.Off;
			bool flag = false;
			if ((tempState & MultipleUnitStateObserver.TemperatureState.Critical) == MultipleUnitStateObserver.TemperatureState.Critical)
			{
				flag = true;
				state = LampControl.LampState.Blinking;
			}
			else if ((tempState & MultipleUnitStateObserver.TemperatureState.Warning) == MultipleUnitStateObserver.TemperatureState.Warning)
			{
				flag = lamp.lampState == LampControl.LampState.Off || lamp.lampState == LampControl.LampState.None;
				state = LampControl.LampState.On;
			}
			lamp.SetLampState(state, flag && !muteAudio);
		}
	}
}
