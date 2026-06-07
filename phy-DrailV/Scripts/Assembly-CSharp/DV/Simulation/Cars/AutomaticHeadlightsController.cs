using DV.MultipleUnit;
using DV.Utils;
using DV.WeatherSystem;
using LocoSim.Implementations;
using UnityEngine;

namespace DV.Simulation.Cars
{
	public class AutomaticHeadlightsController : MonoBehaviour
	{
		private enum HeadlightState
		{
			Off = 0,
			Dim = 1,
			Mid = 2,
			Long = 3
		}

		private enum ReverserState
		{
			Neutral = 0,
			Forward = 1,
			Reversed = 2
		}

		private const float DAYTIME_START = 7f / 24f;

		private const float DAYTIME_END = 5f / 6f;

		private BaseControlsOverrider baseControlsOverrider;

		private HeadlightsMainController headlightsMainController;

		private ILocomotiveRemoteControl remoteControl;

		private GameParams gameParams;

		protected TrainCar trainCar;

		private bool isPlayerTrainSet;

		private bool userOverride;

		private ReverserState currentReverserState;

		private bool PairingOverride
		{
			get
			{
				if (remoteControl != null)
				{
					return remoteControl.IsActivelyControlled;
				}
				return false;
			}
		}

		private void Start()
		{
			trainCar = GetComponentInParent<TrainCar>();
			SimController simController = trainCar.SimController;
			headlightsMainController = simController?.headlightsController;
			baseControlsOverrider = simController?.controlsOverrider;
			gameParams = Globals.G.GameParams;
			remoteControl = trainCar.GetComponent<ILocomotiveRemoteControl>();
			TrainsetUpdateHeadlightsCheck();
			SetupListeners(on: true);
		}

		private void OnDestroy()
		{
			SetupListeners(on: false);
		}

		private void SetupListeners(bool on)
		{
			if (on)
			{
				trainCar.InteriorLoaded += InteriorLoaded;
				if (trainCar.frontCoupler != null)
				{
					trainCar.frontCoupler.HoseConnectionChanged += OnHoseConnectionChanged;
				}
				if (trainCar.rearCoupler != null)
				{
					trainCar.rearCoupler.HoseConnectionChanged += OnHoseConnectionChanged;
				}
				if (trainCar.muModule != null)
				{
					MultipleUnitCable.AnyConnectionChanged += OnMultipleUnitConnectionChanged;
				}
				if ((bool)baseControlsOverrider.Reverser)
				{
					baseControlsOverrider.Reverser.ControlUpdated += OnReverserUpdated;
				}
				if ((bool)baseControlsOverrider.HeadlightsFront)
				{
					baseControlsOverrider.HeadlightsFront.ControlUpdated += OnHeadlightsFrontUpdated;
				}
				if ((bool)baseControlsOverrider.HeadlightsRear)
				{
					baseControlsOverrider.HeadlightsRear.ControlUpdated += OnHeadlightsRearUpdated;
				}
				SingletonBehaviour<WeatherDriver>.Instance.manager.MinuteChanged += OnMinuteChanged;
				Fuse powerFuse = headlightsMainController.PowerFuse;
				if (powerFuse != null)
				{
					powerFuse.StateUpdated += PowerFuseChanged;
				}
				if (remoteControl != null)
				{
					remoteControl.PairingChanged += OnPairingChanged;
				}
				PlayerManager.CarChanged += OnPlayerCarChanged;
				trainCar.TrainsetChanged += OnTrainsetsChanged;
				return;
			}
			if (trainCar != null)
			{
				trainCar.InteriorLoaded -= InteriorLoaded;
				if (trainCar.frontCoupler != null)
				{
					trainCar.frontCoupler.HoseConnectionChanged -= OnHoseConnectionChanged;
				}
				if (trainCar.rearCoupler != null)
				{
					trainCar.rearCoupler.HoseConnectionChanged -= OnHoseConnectionChanged;
				}
				trainCar.TrainsetChanged -= OnTrainsetsChanged;
			}
			MultipleUnitCable.AnyConnectionChanged -= OnMultipleUnitConnectionChanged;
			if (baseControlsOverrider != null)
			{
				if ((bool)baseControlsOverrider.Reverser)
				{
					baseControlsOverrider.Reverser.ControlUpdated -= OnReverserUpdated;
				}
				if ((bool)baseControlsOverrider.HeadlightsFront)
				{
					baseControlsOverrider.HeadlightsFront.ControlUpdated -= OnHeadlightsFrontUpdated;
				}
				if ((bool)baseControlsOverrider.HeadlightsRear)
				{
					baseControlsOverrider.HeadlightsRear.ControlUpdated -= OnHeadlightsRearUpdated;
				}
			}
			if (SingletonBehaviour<WeatherDriver>.Instance != null)
			{
				SingletonBehaviour<WeatherDriver>.Instance.manager.MinuteChanged -= OnMinuteChanged;
			}
			Fuse fuse = ((headlightsMainController != null) ? headlightsMainController.PowerFuse : null);
			if (fuse != null)
			{
				fuse.StateUpdated -= PowerFuseChanged;
			}
			if (remoteControl != null)
			{
				remoteControl.PairingChanged -= OnPairingChanged;
			}
			PlayerManager.CarChanged -= OnPlayerCarChanged;
		}

		private void OnTrainsetsChanged(Trainset _)
		{
			TrainsetUpdateHeadlightsCheck();
		}

		private void OnPlayerCarChanged(TrainCar _)
		{
			TrainsetUpdateHeadlightsCheck();
		}

		private void TrainsetUpdateHeadlightsCheck()
		{
			TrainCar car = PlayerManager.Car;
			Trainset trainset = ((car != null) ? car.trainset : null);
			bool flag = isPlayerTrainSet;
			isPlayerTrainSet = trainset == trainCar.trainset;
			if (isPlayerTrainSet && flag != isPlayerTrainSet)
			{
				UpdateHeadlights();
			}
		}

		private void OnMinuteChanged()
		{
			UpdateHeadlights();
		}

		private void OnMultipleUnitConnectionChanged(bool _, MultipleUnitCable a, MultipleUnitCable b)
		{
			MultipleUnitModule muModule = trainCar.muModule;
			if (!(muModule == null))
			{
				if (a.muModule == muModule)
				{
					UpdateHeadlights();
				}
				else if (b.muModule == muModule)
				{
					UpdateHeadlights();
				}
			}
		}

		private void OnHoseConnectionChanged(bool _, bool __, bool ___)
		{
			UpdateHeadlights();
		}

		private void OnPairingChanged(bool _)
		{
			UpdateHeadlights();
		}

		private void PowerFuseChanged(bool _)
		{
			userOverride = false;
			UpdateHeadlights();
		}

		private void InteriorLoaded(GameObject obj)
		{
			if (!(obj == null))
			{
				userOverride = false;
				UpdateHeadlights();
			}
		}

		private void OnReverserUpdated(float value)
		{
			if (Mathf.Approximately(value, 0.5f))
			{
				currentReverserState = ReverserState.Neutral;
			}
			else if (value > 0.5f)
			{
				currentReverserState = ReverserState.Forward;
			}
			else
			{
				currentReverserState = ReverserState.Reversed;
			}
			if (currentReverserState != ReverserState.Neutral)
			{
				UpdateHeadlights();
			}
		}

		private void OnHeadlightsFrontUpdated(float value)
		{
			OnHeadlightsUpdated(value, front: true);
		}

		private void OnHeadlightsRearUpdated(float value)
		{
			OnHeadlightsUpdated(value, front: false);
		}

		private void OnHeadlightsUpdated(float value, bool front)
		{
			bool flag = currentReverserState == ReverserState.Reversed;
			if (!front)
			{
				flag = !flag;
			}
			int num = headlightsMainController.GetSetupCount(front) - 1;
			int num2 = Mathf.RoundToInt(value * (float)num);
			int num3 = Mathf.RoundToInt(headlightsMainController.GetNeutralPortValue(front) * (float)num);
			float headlightControlValueFromIntensity = GetHeadlightControlValueFromIntensity(GetDesiredHeadlightIntensity(flag, front), flag, front);
			if (gameParams.AutoHeadlightsOnOffAllowed && !Mathf.Approximately(headlightControlValueFromIntensity, value))
			{
				userOverride = true;
			}
			else if (gameParams.AutoHeadlightsDirectionAllowed && num2 != num3 && currentReverserState != ReverserState.Neutral && !(flag ? (num2 < num3) : (num2 >= num3)))
			{
				userOverride = true;
			}
		}

		private void UpdateHeadlights()
		{
			if (currentReverserState == ReverserState.Neutral || (!PairingOverride && !isPlayerTrainSet))
			{
				return;
			}
			if (gameParams.AutoHeadlightsOnOffAllowed && !userOverride)
			{
				bool flag = currentReverserState == ReverserState.Reversed;
				float headlightControlValueFromIntensity = GetHeadlightControlValueFromIntensity(GetDesiredHeadlightIntensity(flag, front: true), flag, front: true);
				baseControlsOverrider.HeadlightsFront?.Set(headlightControlValueFromIntensity);
				float headlightControlValueFromIntensity2 = GetHeadlightControlValueFromIntensity(GetDesiredHeadlightIntensity(!flag, front: false), !flag, front: false);
				baseControlsOverrider.HeadlightsRear?.Set(headlightControlValueFromIntensity2);
			}
			else
			{
				if (!gameParams.AutoHeadlightsDirectionAllowed && !PairingOverride)
				{
					return;
				}
				float num = baseControlsOverrider.HeadlightsFront?.Value ?? 0.4f;
				float num2 = baseControlsOverrider.HeadlightsRear?.Value ?? 0.4f;
				float num3 = num;
				float num4 = num2;
				if (Mathf.Approximately(num3, num4))
				{
					return;
				}
				bool flag2 = num > num2;
				if (currentReverserState == ReverserState.Reversed)
				{
					if (flag2)
					{
						float num5 = num4;
						float num6 = num3;
						num3 = num5;
						num4 = num6;
					}
				}
				else if (!flag2)
				{
					float num7 = num4;
					float num6 = num3;
					num3 = num7;
					num4 = num6;
				}
				baseControlsOverrider.HeadlightsFront?.Set(num3);
				baseControlsOverrider.HeadlightsRear?.Set(num4);
			}
		}

		private float GetHeadlightControlValueFromIntensity(HeadlightState state, bool reversed, bool front)
		{
			int setupCount = headlightsMainController.GetSetupCount(front);
			float num = ((setupCount > 1) ? (1f / (float)(setupCount - 1)) : 0f);
			int num2 = headlightsMainController.GetOffIndex(front);
			switch (state)
			{
			case HeadlightState.Dim:
				num2 += ((!reversed) ? 1 : (-1));
				break;
			case HeadlightState.Mid:
				num2 += (reversed ? (-2) : 2);
				break;
			case HeadlightState.Long:
				num2 += (reversed ? (-2) : 3);
				break;
			default:
				Debug.LogError("Switch case unhandled!");
				break;
			case HeadlightState.Off:
				break;
			}
			return Mathf.Clamp01((float)num2 * num);
		}

		private HeadlightState GetDesiredHeadlightIntensity(bool reversed, bool front)
		{
			Fuse powerFuse = headlightsMainController.PowerFuse;
			if (powerFuse != null && !powerFuse.State)
			{
				return HeadlightState.Off;
			}
			bool flag = HoseConnected(front);
			MultipleUnitModule muModule = trainCar.muModule;
			if ((!(muModule != null) || (!muModule.ConnectedFront && !muModule.ConnectedRear)) && flag)
			{
				return HeadlightState.Off;
			}
			if (!SingletonBehaviour<WeatherDriver>.Instance)
			{
				return HeadlightState.Off;
			}
			float timeOfDay = SingletonBehaviour<WeatherDriver>.Instance.manager.timeOfDay;
			if (timeOfDay > 7f / 24f && timeOfDay < 5f / 6f)
			{
				return HeadlightState.Dim;
			}
			if ((double)SingletonBehaviour<WeatherDriver>.Instance.GetFogDensity(base.transform.position) > 0.5)
			{
				return HeadlightState.Mid;
			}
			if (!reversed)
			{
				return HeadlightState.Long;
			}
			return HeadlightState.Mid;
		}

		protected virtual bool HoseConnected(bool front)
		{
			Coupler coupler = (front ? trainCar.frontCoupler : trainCar.rearCoupler);
			if (coupler != null && coupler.hoseAndCock != null)
			{
				return coupler.hoseAndCock.IsHoseConnected;
			}
			return false;
		}
	}
}
