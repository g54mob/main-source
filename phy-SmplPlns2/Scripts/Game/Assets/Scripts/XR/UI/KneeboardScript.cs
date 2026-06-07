using System.Collections.Generic;
using Assets.Scripts.Craft;
using Assets.Scripts.Craft.Parts.Modifiers.XR;
using Assets.Scripts.Flight;
using Assets.Scripts.Flight.Events;
using Assets.Scripts.Input.XR;
using Assets.Scripts.Levels;
using Assets.Scripts.Tutorials;
using Assets.Scripts.XR.HandPoses;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.XR.UI
{
	public class KneeboardScript : MonoBehaviour, IGripTarget
	{
		[SerializeField]
		private Collider _gripCollider;

		private FlightHand _grippingHand;

		[SerializeField]
		private GripPose _gripPose;

		[SerializeField]
		private Transform _gripTarget;

		[SerializeField]
		private TextMeshProUGUI _instructionsText;

		private Material _mapMaterial;

		[SerializeField]
		private MeshRenderer _mapRenderer;

		private Quaternion _rotationOffset;

		[SerializeField]
		private Toggle _showOnStartToggle;

		private List<GameObject> _tutorialObjects;

		[SerializeField]
		private GameObject _tutorialsHeader;

		[SerializeField]
		private GameObject _tutorialTemplate;

		public XRControlGripType GripType => XRControlGripType.Default;

		public bool IsVisible
		{
			get
			{
				return base.gameObject.activeSelf;
			}
			set
			{
				base.gameObject.SetActive(value);
			}
		}

		public GripPose Pose { get; private set; }

		public bool SnapHandPositionToTarget => false;

		public bool SnapHandRotationToTarget => false;

		public Transform TargetTransform => _gripTarget;

		public string GetOverrideControlBinding(string controlId)
		{
			return null;
		}

		void IGripTarget.OnGripAttached(FlightHand hand)
		{
			if (_grippingHand == null)
			{
				_grippingHand = hand;
				_gripTarget.transform.position = _grippingHand.transform.position;
				_rotationOffset = Quaternion.Inverse(hand.transform.rotation) * _gripTarget.transform.rotation;
			}
		}

		void IGripTarget.OnGripDetached(FlightHand hand)
		{
			if (_grippingHand != null)
			{
				_grippingHand = null;
			}
		}

		void IGripTarget.OnGripUpdate(FlightHand hand)
		{
			if (hand == _grippingHand)
			{
				Vector3 vector = _gripTarget.transform.position - base.transform.position;
				base.transform.SetPositionAndRotation(hand.transform.position - vector, hand.transform.rotation * _rotationOffset);
			}
		}

		public void OnHideButtonClicked()
		{
			IsVisible = false;
		}

		public void OnShowOnStartToggled(bool value)
		{
			PlayerPrefs.SetInt("CraftInstructionsVisible", _showOnStartToggle.isOn ? 1 : 0);
		}

		public void Toggle()
		{
			IsVisible = !IsVisible;
		}

		protected virtual void OnDestroy()
		{
			PosedGripScript.ColliderLookup.Remove(_gripCollider);
			FlightSceneScript instance = FlightSceneScript.Instance;
			if (instance != null)
			{
				instance.PlayerEnteredAircraft -= OnPlayerEnteredAircraft;
				instance.PlayerExitedAircraft -= OnPlayerExitedAircraft;
			}
			if (_mapMaterial != null)
			{
				Object.Destroy(_mapMaterial);
				_mapMaterial = null;
			}
		}

		protected virtual void Start()
		{
			Pose = _gripPose;
			PosedGripScript.ColliderLookup.Add(_gripCollider, this);
			if (!PlayerPrefs.HasKey("CraftInstructionsVisible"))
			{
				PlayerPrefs.SetInt("CraftInstructionsVisible", 1);
			}
			bool flag = PlayerPrefs.GetInt("CraftInstructionsVisible") == 1;
			_showOnStartToggle.isOn = flag;
			_tutorialObjects = new List<GameObject>();
			FlightSceneScript instance = FlightSceneScript.Instance;
			if (instance != null)
			{
				instance.PlayerEnteredAircraft += OnPlayerEnteredAircraft;
				instance.PlayerExitedAircraft += OnPlayerExitedAircraft;
				instance.RaisePlayerEnteredAircraft(OnPlayerEnteredAircraft);
			}
			if (!Game.Instance.Device.IsAndroidVRBuild)
			{
				Texture mainTexture = Resources.Load<Texture>("XR/UI/Kneeboard/Maps/SPMapMaywar");
				_mapMaterial = _mapRenderer.material;
				_mapMaterial.mainTexture = mainTexture;
			}
			flag &= !(LevelBase.CurrentLevel?.HideKneeboardOnStart ?? false);
			IsVisible = flag;
		}

		private void OnPlayerEnteredAircraft(object sender, FlightScenePlayerAircraftEventArgs e)
		{
			bool isVisible = _showOnStartToggle.isOn;
			AircraftData aircraft = e.Aircraft.Aircraft;
			string text = aircraft.Instructions;
			if (string.IsNullOrWhiteSpace(text))
			{
				text = "This craft has no instructions";
				isVisible = false;
			}
			_instructionsText.text = text;
			if (Game.Instance.CurrentLevel.IsSandbox)
			{
				bool active = aircraft.Tutorials.Count > 0;
				_tutorialsHeader.SetActive(active);
				_tutorialTemplate.SetActive(value: false);
				foreach (TutorialInfo tutorial in aircraft.Tutorials)
				{
					GameObject obj = Object.Instantiate(_tutorialTemplate, _tutorialTemplate.transform.parent);
					obj.transform.Find("TutorialName").GetComponent<TextMeshProUGUI>().text = tutorial.Name;
					obj.GetComponentInChildren<Button>().onClick.AddListener(delegate
					{
						OnStartTutorialButtonClicked(tutorial);
					});
					obj.SetActive(value: true);
				}
			}
			IsVisible = isVisible;
		}

		private void OnPlayerExitedAircraft(object sender, FlightScenePlayerAircraftEventArgs e)
		{
			foreach (GameObject tutorialObject in _tutorialObjects)
			{
				Object.Destroy(tutorialObject);
			}
			_tutorialObjects.Clear();
			_instructionsText.text = string.Empty;
			IsVisible = false;
		}

		private void OnStartTutorialButtonClicked(TutorialInfo tutorial)
		{
			AircraftScript aircraftScript = FlightSceneScript.Instance.LocalPlayer?.Aircraft;
			if (aircraftScript == null)
			{
				Debug.LogError("Unable to start the tutorial because there is no active aircraft.");
				return;
			}
			Debug.Log("Starting Tutorial: " + tutorial.Name);
			TutorialScript.LoadFromXml(tutorial.Xml).StartTutorial(aircraftScript);
		}
	}
}
