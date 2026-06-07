using DV.Utils;
using UnityEngine;

namespace DV
{
	public class CommsRadioDamage : MonoBehaviour, ICommsRadioMode
	{
		private enum OperationMode : byte
		{
			Activation = 0,
			Derail = 1,
			Damage = 2
		}

		private const float SIGNAL_RANGE = 100f;

		private static Vector3 HIGHLIGHT_BOUNDS_EXTENSION = new Vector3(0.25f, 0.8f, 0f);

		private static Color laserColor = new Color(0.1f, 0.1f, 0.1f, 1f);

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

		private TrainCar pointedCar;

		private OperationMode opMode;

		private int damageLevel = 1;

		public ButtonBehaviourType ButtonBehaviour { get; private set; }

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
			Reset();
		}

		public void OverrideSignalOrigin(Transform signalOrigin)
		{
			this.signalOrigin = signalOrigin;
		}

		public void OnUse()
		{
			if (opMode == OperationMode.Activation)
			{
				opMode = OperationMode.Damage;
				ButtonBehaviour = ButtonBehaviourType.Override;
				CommsRadioController.PlayAudioFromRadio(confirmSound, base.transform);
				UpdateDisplay();
			}
			else if (opMode == OperationMode.Derail)
			{
				if (pointedCar != null)
				{
					pointedCar.Derail();
					PointToCar(pointedCar);
					UpdateDisplay();
				}
				else
				{
					CommsRadioController.PlayAudioFromRadio(cancelSound, base.transform);
					Reset();
				}
			}
			else if (pointedCar != null)
			{
				_ = pointedCar.logicCar;
				pointedCar.GetComponent<TrainCarCollisions>().CarDamaged?.Invoke(pointedCar.CarDamage.maxHealth * ((float)damageLevel / 10f), Vector3.zero);
				if (SingletonBehaviour<AudioManager>.Instance != null && SingletonBehaviour<AudioManager>.Instance.derailHitClip != null)
				{
					SingletonBehaviour<AudioManager>.Instance.derailHitClip.Play(pointedCar.transform.position, 1f, 1f, 0f, 10f, 500f, default(AudioSourceCurves), null, pointedCar.transform);
				}
				CommsRadioController.PlayAudioFromRadio(confirmSound, base.transform);
				PointToCar(pointedCar);
				UpdateDisplay();
			}
			else
			{
				CommsRadioController.PlayAudioFromRadio(cancelSound, base.transform);
				Reset();
			}
		}

		public void OnUpdate()
		{
			if (opMode == OperationMode.Activation)
			{
				return;
			}
			if (Physics.Raycast(signalOrigin.position, signalOrigin.forward, out hit, 100f, trainCarMask))
			{
				TrainCar trainCar = TrainCar.Resolve(hit.transform.root);
				if (trainCar == null)
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
			if (opMode == OperationMode.Activation)
			{
				display.SetDisplay(CommsRadioLocalization.MODE_DAMAGE, CommsRadioLocalization.MODE_DAMAGE_ENABLE);
			}
			else if (opMode == OperationMode.Derail)
			{
				if (pointedCar != null)
				{
					display.SetDisplay(CommsRadioLocalization.MODE_DAMAGE, CommsRadioLocalization.MODE_DERAIL_QUESTION, CommsRadioLocalization.MODE_DERAIL);
				}
				else
				{
					display.SetDisplay(CommsRadioLocalization.MODE_DAMAGE, CommsRadioLocalization.MODE_DERAIL_AIM, CommsRadioLocalization.CANCEL);
				}
			}
			else if (pointedCar != null)
			{
				display.SetDisplay(CommsRadioLocalization.MODE_DAMAGE, CommsRadioLocalization.MODE_DAMAGE_STATS((int)pointedCar.CarDamage.currentHealth, (int)pointedCar.CarDamage.maxHealth, damageLevel * 10), CommsRadioLocalization.MODE_DAMAGE);
			}
			else
			{
				display.SetDisplay(CommsRadioLocalization.MODE_DAMAGE, CommsRadioLocalization.MODE_DAMAGE_DESC(damageLevel * 10), CommsRadioLocalization.CANCEL);
			}
		}

		public bool ButtonACustomAction()
		{
			if (opMode == OperationMode.Damage)
			{
				if (damageLevel > 1)
				{
					damageLevel--;
				}
				else
				{
					opMode = OperationMode.Derail;
				}
				UpdateDisplay();
				return true;
			}
			return false;
		}

		public bool ButtonBCustomAction()
		{
			if (opMode == OperationMode.Derail)
			{
				opMode = OperationMode.Damage;
				damageLevel = 1;
				UpdateDisplay();
				return true;
			}
			if (opMode == OperationMode.Damage && damageLevel < 10)
			{
				damageLevel++;
				UpdateDisplay();
				return true;
			}
			return false;
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
			if (car != null)
			{
				if (opMode == OperationMode.Activation)
				{
					car = null;
				}
				else if (opMode == OperationMode.Derail && car.derailed)
				{
					car = null;
				}
			}
			if (pointedCar != car)
			{
				if (pointedCar != null)
				{
					pointedCar.OnDestroyCar -= OnCarToDamageDestroy;
				}
				if (car != null)
				{
					pointedCar = car;
					pointedCar.OnDestroyCar += OnCarToDamageDestroy;
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

		private void OnCarToDamageDestroy(TrainCar destroyedCar)
		{
			if (destroyedCar != null)
			{
				destroyedCar.OnDestroyCar -= OnCarToDamageDestroy;
			}
			Reset();
		}

		private void Reset()
		{
			if (pointedCar != null)
			{
				pointedCar.OnDestroyCar -= OnCarToDamageDestroy;
			}
			pointedCar = null;
			opMode = OperationMode.Activation;
			damageLevel = 1;
			ButtonBehaviour = ButtonBehaviourType.Regular;
			ClearHighlightCar();
			UpdateDisplay();
		}
	}
}
