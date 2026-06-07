using LocoSim.Attributes;
using LocoSim.Implementations;
using UnityEngine;

namespace DV.Simulation.Brake
{
	public class LampBrakeWarningReader : MonoBehaviour
	{
		[FuseId]
		public string lampPowerFuseId;

		private Fuse lampPowerFuse;

		private LampControl brakeWarningLamp;

		private BrakeWarningChecker checker;

		private void Awake()
		{
			brakeWarningLamp = GetComponent<LampControl>();
			if (brakeWarningLamp == null)
			{
				Debug.LogError("Unexpected state: brakeWarningLamp is null. LampBrakeWarningReader is useless. Destroying self!", base.gameObject);
				Object.Destroy(this);
				return;
			}
			TrainCar trainCar = TrainCar.Resolve(base.gameObject);
			if (trainCar == null)
			{
				Debug.LogError("Unexpected state: Couldn't find attached TrainCar for LampBrakeWarningReader. Destroying self!", base.gameObject);
				Object.Destroy(this);
				return;
			}
			if (!string.IsNullOrEmpty(lampPowerFuseId))
			{
				SimulationFlow simulationFlow = trainCar.SimController?.simFlow;
				if (simulationFlow == null)
				{
					Debug.LogError("Couldn't find simFlow, ignoring lampPowerFuseId won't be functional!");
					return;
				}
				if (!simulationFlow.TryGetFuse(lampPowerFuseId, out lampPowerFuse))
				{
					Debug.LogError("[" + base.gameObject.GetPath() + "]: LampBrakeWarningReader isn't initialized properly!");
					return;
				}
				lampPowerFuse.StateUpdated += OnFuseUpdated;
			}
			checker = new BrakeWarningChecker();
			checker.SetTrainCar(trainCar);
			checker.BrakeWarningChanged += BrakeWarningChanged;
			UpdateLampAndAudioState(playAudioOnWarning: false);
		}

		private void OnDestroy()
		{
			if (lampPowerFuse != null)
			{
				lampPowerFuse.StateUpdated -= OnFuseUpdated;
			}
			checker.BrakeWarningChanged -= BrakeWarningChanged;
			checker.SetTrainCar(null);
			checker = null;
		}

		private void BrakeWarningChanged(bool newState)
		{
			UpdateLampAndAudioState(playAudioOnWarning: true);
		}

		private void OnFuseUpdated(bool _)
		{
			UpdateLampAndAudioState(playAudioOnWarning: true);
		}

		private void UpdateLampAndAudioState(bool playAudioOnWarning)
		{
			if (!(brakeWarningLamp == null))
			{
				bool flag = (lampPowerFuse == null || lampPowerFuse.State) && checker.BrakeWarningState;
				LampControl.LampState state = (flag ? LampControl.LampState.Blinking : LampControl.LampState.Off);
				bool playWarningAudio = playAudioOnWarning && flag;
				brakeWarningLamp.SetLampState(state, playWarningAudio);
			}
		}
	}
}
