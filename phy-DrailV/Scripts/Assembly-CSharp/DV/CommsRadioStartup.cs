using DV.Simulation.Controllers;
using UnityEngine;

namespace DV
{
	public class CommsRadioStartup : MonoBehaviour, ICommsRadioMode
	{
		private const float SIGNAL_RANGE = 100f;

		private static Vector3 HIGHLIGHT_BOUNDS_EXTENSION = new Vector3(0.25f, 0.8f, 0f);

		private static Color laserColor = new Color(1f, 0.5f, 0f, 1f);

		public Transform signalOrigin;

		public CommsRadioDisplay display;

		public Material validMaterial;

		[Header("Sounds")]
		public AudioClip hoverOverCar;

		public AudioClip startupSound;

		[Header("Highlighters")]
		public GameObject trainHighlighter;

		private MeshRenderer trainHighlighterRender;

		private RaycastHit hit;

		private LayerMask trainCarMask;

		private TrainCar pointedCar;

		public ButtonBehaviourType ButtonBehaviour => ButtonBehaviourType.Regular;

		private void Awake()
		{
			if (!signalOrigin)
			{
				Debug.LogError("signalOrigin on CommsRadioStartup isn't set, using this.transform!", this);
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
			if (hoverOverCar == null || startupSound == null)
			{
				Debug.LogError("Not all audio clips set, some sounds won't be played!", this);
			}
			trainCarMask = LayerMask.GetMask("Train_Big_Collider");
			trainHighlighterRender = trainHighlighter.GetComponentInChildren<MeshRenderer>(includeInactive: true);
			trainHighlighter.SetActive(value: false);
			trainHighlighter.transform.SetParent(null);
		}

		private void OnDestroy()
		{
			if (!UnloadWatcher.isUnloading && trainHighlighter != null)
			{
				Object.Destroy(trainHighlighter.gameObject);
			}
		}

		public bool ButtonACustomAction()
		{
			return false;
		}

		public bool ButtonBCustomAction()
		{
			return false;
		}

		public void Enable()
		{
		}

		public void Disable()
		{
			Reset();
		}

		public void OverrideSignalOrigin(Transform signalOrigin)
		{
			this.signalOrigin = signalOrigin;
		}

		public void OnUse()
		{
			if (pointedCar != null)
			{
				StartupHelper.Startup(pointedCar);
				CommsRadioController.PlayAudioFromRadio(startupSound, base.transform);
			}
		}

		public void OnUpdate()
		{
			if (Physics.Raycast(signalOrigin.position, signalOrigin.forward, out hit, 100f, trainCarMask))
			{
				TrainCar trainCar = TrainCar.Resolve(hit.transform.root);
				if (trainCar == null || !trainCar.IsLoco)
				{
					PointToCar(null);
				}
				else
				{
					PointToCar(trainCar);
				}
			}
			else
			{
				PointToCar(null);
			}
			UpdateDisplay();
		}

		private void UpdateDisplay()
		{
			if (pointedCar != null)
			{
				display.SetDisplay(CommsRadioLocalization.MODE_STARTUP, pointedCar.ID, CommsRadioLocalization.MODE_STARTUP_START);
			}
			else
			{
				display.SetDisplay(CommsRadioLocalization.MODE_STARTUP, CommsRadioLocalization.MODE_STARTUP_DESC);
			}
		}

		public void SetStartingDisplay()
		{
			UpdateDisplay();
		}

		public Color GetLaserBeamColor()
		{
			return laserColor;
		}

		private void PointToCar(TrainCar car)
		{
			if (pointedCar != car)
			{
				if (pointedCar != null)
				{
					pointedCar.OnDestroyCar -= OnCarToStartDestroy;
				}
				if (car != null)
				{
					pointedCar = car;
					pointedCar.OnDestroyCar += OnCarToStartDestroy;
					HighlightCar(pointedCar, validMaterial);
					CommsRadioController.PlayAudioFromRadio(hoverOverCar, base.transform);
				}
				else
				{
					pointedCar = null;
					ClearHighlightCar();
				}
				UpdateDisplay();
			}
		}

		private void HighlightCar(TrainCar car, Material highlightMaterial)
		{
			if (car == null)
			{
				Debug.LogError("Highlight car is null. Ignoring request.");
				return;
			}
			trainHighlighterRender.material = highlightMaterial;
			trainHighlighter.transform.localScale = car.Bounds.size + HIGHLIGHT_BOUNDS_EXTENSION;
			Vector3 vector = car.transform.up * (trainHighlighter.transform.localScale.y / 2f);
			Vector3 vector2 = car.transform.forward * car.Bounds.center.z;
			Vector3 position = car.transform.position + vector + vector2;
			trainHighlighter.transform.SetPositionAndRotation(position, car.transform.rotation);
			trainHighlighter.SetActive(value: true);
			trainHighlighter.transform.SetParent(car.transform, worldPositionStays: true);
		}

		private void ClearHighlightCar()
		{
			trainHighlighter.SetActive(value: false);
			trainHighlighter.transform.SetParent(null);
		}

		private void OnCarToStartDestroy(TrainCar destroyedCar)
		{
			if (destroyedCar != null)
			{
				destroyedCar.OnDestroyCar -= OnCarToStartDestroy;
			}
			Reset();
		}

		private void Reset()
		{
			if (pointedCar != null)
			{
				pointedCar.OnDestroyCar -= OnCarToStartDestroy;
			}
			pointedCar = null;
			ClearHighlightCar();
			UpdateDisplay();
		}
	}
}
