using DV.Customization.Paint;
using UnityEngine;

namespace DV
{
	public class CommsRadioPaintjob : MonoBehaviour, ICommsRadioMode
	{
		private enum OperationMode : byte
		{
			Activation = 0,
			ThemeSelect = 1,
			AreaAndPaint = 2
		}

		private const float SIGNAL_RANGE = 100f;

		private static Vector3 HIGHLIGHT_BOUNDS_EXTENSION = new Vector3(0.25f, 0.8f, 0f);

		private static Color laserColor = new Color(1f, 1f, 1f, 1f);

		public Transform signalOrigin;

		public CommsRadioDisplay display;

		public Material validMaterial;

		[Header("Paint Themes")]
		public PaintTheme[] themes;

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

		private int selectedTheme;

		private int selectedAreas;

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
				opMode = OperationMode.ThemeSelect;
				ButtonBehaviour = ButtonBehaviourType.Override;
				CommsRadioController.PlayAudioFromRadio(confirmSound, base.transform);
				UpdateDisplay();
			}
			else if (opMode == OperationMode.ThemeSelect)
			{
				opMode = OperationMode.AreaAndPaint;
				CommsRadioController.PlayAudioFromRadio(confirmSound, base.transform);
			}
			else if (pointedCar != null)
			{
				bool num = selectedAreas == 0 || selectedAreas == 1;
				bool flag = selectedAreas == 0 || selectedAreas == 2;
				PaintTheme paintTheme = themes[selectedTheme];
				bool flag2 = false;
				if (num && pointedCar.PaintInterior != null && pointedCar.PaintInterior.IsSupported(paintTheme))
				{
					pointedCar.PaintInterior.CurrentTheme = paintTheme;
					flag2 = true;
				}
				if (flag && pointedCar.PaintExterior != null && pointedCar.PaintExterior.IsSupported(paintTheme))
				{
					pointedCar.PaintExterior.CurrentTheme = paintTheme;
					flag2 = true;
				}
				if (flag2)
				{
					opMode = OperationMode.ThemeSelect;
				}
				CommsRadioController.PlayAudioFromRadio(flag2 ? confirmSound : cancelSound, base.transform);
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
				display.SetDisplay(CommsRadioLocalization.MODE_PAINTJOB, CommsRadioLocalization.MODE_PAINTJOB_ENABLE);
				return;
			}
			if (opMode == OperationMode.ThemeSelect)
			{
				display.SetDisplay(CommsRadioLocalization.MODE_PAINTJOB, themes[selectedTheme].LocalizedName, CommsRadioLocalization.SELECT);
				return;
			}
			PaintTheme theme = themes[selectedTheme];
			bool flag = pointedCar != null;
			bool flag2 = flag && pointedCar.PaintInterior != null && pointedCar.PaintInterior.IsSupported(theme);
			bool flag3 = flag && pointedCar.PaintExterior != null && pointedCar.PaintExterior.IsSupported(theme);
			bool flag4 = false;
			string content = string.Empty;
			switch (selectedAreas)
			{
			case 0:
				content = CommsRadioLocalization.MODE_PAINTJOB_ALL;
				flag4 = flag2 || flag3;
				break;
			case 1:
				content = CommsRadioLocalization.MODE_PAINTJOB_INTERIOR;
				flag4 = flag2;
				break;
			case 2:
				content = CommsRadioLocalization.MODE_PAINTJOB_EXTERIOR;
				flag4 = flag3;
				break;
			}
			display.SetDisplay(CommsRadioLocalization.MODE_PAINTJOB, content, (!flag) ? CommsRadioLocalization.CANCEL : (flag4 ? CommsRadioLocalization.CONFIRM : CommsRadioLocalization.MODE_PAINTJOB_NOT_COMPATIBLE));
		}

		public bool ButtonACustomAction()
		{
			if (opMode == OperationMode.ThemeSelect)
			{
				selectedTheme--;
				if (selectedTheme < 0)
				{
					selectedTheme = themes.Length - 1;
				}
				UpdateDisplay();
				return true;
			}
			if (opMode == OperationMode.AreaAndPaint)
			{
				selectedAreas--;
				if (selectedAreas < 0)
				{
					selectedAreas = 2;
				}
				UpdateDisplay();
				return true;
			}
			return false;
		}

		public bool ButtonBCustomAction()
		{
			if (opMode == OperationMode.ThemeSelect)
			{
				selectedTheme++;
				if (selectedTheme >= themes.Length)
				{
					selectedTheme = 0;
				}
				UpdateDisplay();
				return true;
			}
			if (opMode == OperationMode.AreaAndPaint)
			{
				selectedAreas++;
				if (selectedAreas > 2)
				{
					selectedAreas = 0;
				}
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
			if (car != null && (opMode == OperationMode.Activation || opMode == OperationMode.ThemeSelect))
			{
				car = null;
			}
			if (pointedCar != car)
			{
				if (pointedCar != null)
				{
					pointedCar.OnDestroyCar -= OnPointedCarDestroy;
				}
				if (car != null)
				{
					pointedCar = car;
					pointedCar.OnDestroyCar += OnPointedCarDestroy;
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

		private void OnPointedCarDestroy(TrainCar destroyedCar)
		{
			if (destroyedCar != null)
			{
				destroyedCar.OnDestroyCar -= OnPointedCarDestroy;
			}
			Reset();
		}

		private void Reset()
		{
			if (pointedCar != null)
			{
				pointedCar.OnDestroyCar -= OnPointedCarDestroy;
			}
			pointedCar = null;
			opMode = OperationMode.Activation;
			selectedAreas = 0;
			selectedTheme = 0;
			ButtonBehaviour = ButtonBehaviourType.Regular;
			ClearHighlightCar();
			UpdateDisplay();
		}
	}
}
