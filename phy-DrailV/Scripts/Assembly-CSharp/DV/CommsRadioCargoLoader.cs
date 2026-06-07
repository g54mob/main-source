using System.Collections.Generic;
using System.Globalization;
using DV.Localization;
using DV.ThingTypes;
using DV.Utils;
using UnityEngine;

namespace DV
{
	public class CommsRadioCargoLoader : MonoBehaviour, ICommsRadioMode
	{
		private enum State
		{
			EnterLoadMode = 0,
			PickCargoAndLoad = 1
		}

		private const float SIGNAL_RANGE = 100f;

		private static Vector3 HIGHLIGHT_BOUNDS_EXTENSION = new Vector3(0.25f, 0.8f, 0f);

		private static Color laserColor = new Color(0f, 1f, 1f, 1f);

		public Transform signalOrigin;

		public CommsRadioDisplay display;

		public Material validMaterial;

		[Header("Sounds")]
		public AudioClip hoverOverCar;

		public AudioClip confirmSound;

		public AudioClip cancelSound;

		[Header("Highlighters")]
		public GameObject trainHighlighter;

		private MeshRenderer trainHighlighterRender;

		private RaycastHit hit;

		private LayerMask trainCarMask;

		private CargoType_v2 selectedCargoType;

		private List<CargoType_v2> cargoChoices;

		private TrainCar pointedCar;

		private bool isActionPossible;

		private State state;

		public ButtonBehaviourType ButtonBehaviour { get; private set; }

		private void SetState(State newState)
		{
			if (state != newState)
			{
				state = newState;
				switch (state)
				{
				case State.EnterLoadMode:
					SetStartingDisplay();
					ButtonBehaviour = ButtonBehaviourType.Regular;
					break;
				case State.PickCargoAndLoad:
					ButtonBehaviour = ButtonBehaviourType.Override;
					CommsRadioController.PlayAudioFromRadio(confirmSound, base.transform);
					break;
				}
			}
		}

		private void Awake()
		{
			if (!signalOrigin)
			{
				Debug.LogError("signalOrigin on CommsRadioCrewVehicle isn't set, using this.transform!", this);
				signalOrigin = base.transform;
			}
			if (display == null)
			{
				Debug.LogError("display not set, can't function properly!", this);
			}
			if (validMaterial == null)
			{
				Debug.LogError("Some of the required materials isn't set. Visuals won't be correct.", this);
			}
			if (trainHighlighter == null)
			{
				Debug.LogError("trainHighlighter not set, can't function properly!!", this);
			}
			if (hoverOverCar == null || confirmSound == null || cancelSound == null)
			{
				Debug.LogError("Not all audio clips set, some sounds won't be played!", this);
			}
			trainCarMask = LayerMask.GetMask("Train_Big_Collider");
			trainHighlighterRender = trainHighlighter.GetComponentInChildren<MeshRenderer>(includeInactive: true);
			trainHighlighter.SetActive(value: false);
			trainHighlighter.transform.SetParent(null);
			SetCargoChoices();
		}

		private void OnDestroy()
		{
			if (!UnloadWatcher.isUnloading && trainHighlighter != null)
			{
				Object.Destroy(trainHighlighter.gameObject);
			}
		}

		public void Enable()
		{
		}

		public void Disable()
		{
			ClearState();
		}

		public void OverrideSignalOrigin(Transform signalOrigin)
		{
			this.signalOrigin = signalOrigin;
		}

		public void OnUse()
		{
			switch (state)
			{
			case State.EnterLoadMode:
				SetCargoToLoad(selectedCargoType);
				SetState(State.PickCargoAndLoad);
				break;
			case State.PickCargoAndLoad:
				if (isActionPossible)
				{
					if (selectedCargoType == null)
					{
						UnloadPointedCar();
					}
					else
					{
						LoadPointedCar();
					}
				}
				else
				{
					ClearState();
					CommsRadioController.PlayAudioFromRadio(cancelSound, base.transform);
				}
				break;
			}
		}

		public void OnUpdate()
		{
			State state = this.state;
			if (state == State.PickCargoAndLoad)
			{
				TrainCar car = (Physics.Raycast(signalOrigin.position, signalOrigin.forward, out hit, 100f, trainCarMask) ? TrainCar.Resolve(hit.transform) : null);
				isActionPossible = PointToCar(car);
				display.SetAction(isActionPossible ? CommsRadioLocalization.CONFIRM : CommsRadioLocalization.CANCEL);
			}
		}

		public bool ButtonACustomAction()
		{
			State state = this.state;
			if (state == State.PickCargoAndLoad)
			{
				if (selectedCargoType == null && cargoChoices.Count > 0)
				{
					SetCargoToLoad(cargoChoices[cargoChoices.Count - 1]);
				}
				else
				{
					int num = cargoChoices.IndexOf(selectedCargoType);
					if (num <= 0)
					{
						SetCargoToLoad(null);
					}
					else
					{
						SetCargoToLoad(cargoChoices[num - 1]);
					}
				}
				return true;
			}
			Debug.LogError($"Unexpected state {this.state}!", this);
			return false;
		}

		public bool ButtonBCustomAction()
		{
			State state = this.state;
			if (state == State.PickCargoAndLoad)
			{
				if (selectedCargoType == null && cargoChoices.Count > 0)
				{
					SetCargoToLoad(cargoChoices[0]);
				}
				else
				{
					int num = cargoChoices.IndexOf(selectedCargoType);
					if (num < 0 || num + 1 == cargoChoices.Count)
					{
						SetCargoToLoad(null);
					}
					else
					{
						SetCargoToLoad(cargoChoices[(num + 1) % cargoChoices.Count]);
					}
				}
				return true;
			}
			Debug.LogError($"Unexpected state {this.state}!", this);
			return false;
		}

		public void SetStartingDisplay()
		{
			display.SetDisplay(CommsRadioLocalization.MODE_CARGO_LOADER, CommsRadioLocalization.ENABLE_CARGO_LOADER);
		}

		public Color GetLaserBeamColor()
		{
			return laserColor;
		}

		private void UnloadPointedCar()
		{
			pointedCar.logicCar.UnloadCargo(pointedCar.LoadedCargoAmount, pointedCar.LoadedCargo);
			PlayLoadUnloadSound();
			CommsRadioController.PlayAudioFromRadio(confirmSound, base.transform);
		}

		private void LoadPointedCar()
		{
			if (pointedCar.LoadedCargo != CargoType.None)
			{
				pointedCar.logicCar.UnloadCargo(pointedCar.LoadedCargoAmount, pointedCar.LoadedCargo);
			}
			pointedCar.logicCar.LoadCargo(pointedCar.cargoCapacity, selectedCargoType.v1);
			PlayLoadUnloadSound();
			CommsRadioController.PlayAudioFromRadio(confirmSound, base.transform);
		}

		private bool PointToCar(TrainCar car)
		{
			if (pointedCar != car)
			{
				if (pointedCar != null)
				{
					pointedCar.OnDestroyCar -= OnCarToLoadDestroy;
				}
				pointedCar = car;
				if (pointedCar != null)
				{
					pointedCar.OnDestroyCar += OnCarToLoadDestroy;
				}
				SetCargoChoices();
				CommsRadioController.PlayAudioFromRadio(hoverOverCar, base.transform);
			}
			if (car != null && car.playerSpawnedCar)
			{
				bool num = selectedCargoType == null && car.LoadedCargo != CargoType.None;
				bool flag = selectedCargoType != null && selectedCargoType.IsLoadableOnCarType(car.carLivery.parentType) && selectedCargoType.v1 != car.LoadedCargo;
				if (num || flag)
				{
					HighlightCar(car, validMaterial);
					return true;
				}
			}
			ClearHighlightCar();
			return false;
		}

		private void SetCargoChoices()
		{
			cargoChoices = ((pointedCar == null) ? Globals.G.Types.cargos : Globals.G.Types.CarTypeToLoadableCargo[pointedCar.carLivery.parentType]);
			cargoChoices.Sort((CargoType_v2 a, CargoType_v2 b) => string.Compare(LocalizationAPI.L(a.localizationKeyShort), LocalizationAPI.L(b.localizationKeyShort), LocalizationAPI.CC, CompareOptions.IgnoreCase));
		}

		private void SetCargoToLoad(CargoType_v2 cargoType)
		{
			selectedCargoType = cargoType;
			string content = ((cargoType == null) ? CommsRadioLocalization.CARGO_UNLOAD : LocalizationAPI.L(cargoType.localizationKeyShort));
			display.SetContent(content);
		}

		private void HighlightCar(TrainCar car, Material highlightMaterial)
		{
			if (car == null)
			{
				Debug.LogError("Highlight car is null. Ignoring request.");
			}
			else if (!(trainHighlighter.transform.parent == car.transform))
			{
				trainHighlighterRender.material = highlightMaterial;
				trainHighlighter.transform.localScale = car.Bounds.size + HIGHLIGHT_BOUNDS_EXTENSION;
				Vector3 vector = car.transform.up * (trainHighlighter.transform.localScale.y / 2f);
				Vector3 vector2 = car.transform.forward * car.Bounds.center.z;
				Vector3 position = car.transform.position + vector + vector2;
				trainHighlighter.transform.SetPositionAndRotation(position, car.transform.rotation);
				trainHighlighter.SetActive(value: true);
				trainHighlighter.transform.SetParent(car.transform, worldPositionStays: true);
			}
		}

		private void ClearHighlightCar()
		{
			trainHighlighter.SetActive(value: false);
			trainHighlighter.transform.SetParent(null);
		}

		private void PlayLoadUnloadSound()
		{
			if (SingletonBehaviour<AudioManager>.Instance != null && SingletonBehaviour<AudioManager>.Instance.cargoLoadUnload != null)
			{
				SingletonBehaviour<AudioManager>.Instance.cargoLoadUnload.Play(pointedCar.transform.position, 1f, 1f, 0f, 10f, 500f, default(AudioSourceCurves), null, pointedCar.transform);
			}
		}

		private void OnCarToLoadDestroy(TrainCar destroyedCar)
		{
			PointToCar(null);
		}

		private void ClearState()
		{
			PointToCar(null);
			SetState(State.EnterLoadMode);
		}
	}
}
