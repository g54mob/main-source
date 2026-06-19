#define LOG_LEVEL_VERBOSE
using System;
using UnityEngine;
using UnityEngine.UI;

namespace TH20.UI
{
	public class EmergencyPin : UIMapPin
	{
		[SerializeField]
		private Image _pinImage;

		[SerializeField]
		private GameObject _pinSelectPrefab;

		[SerializeField]
		private GameObject _TutorialCircle;

		private EmergencyDispatchMenu _emergencyDispatchMenu;

		private ChallengeAmbulanceEmergency _ambulanceEmergency;

		private UIPinSelectMenu _selectMenu;

		public ChallengeAmbulanceEmergency AmbulanceEmergency => _ambulanceEmergency;

		public UIPinSelectMenu SelectMenu => _selectMenu;

		public void Setup(EmergencyDispatchMap dispatchMap, ChallengeAmbulanceEmergency ambulanceEmergency, EmergencyDispatchMenu emergencyDispatchMenu)
		{
			_ambulanceEmergency = ambulanceEmergency;
			_emergencyDispatchMenu = emergencyDispatchMenu;
			_mapLayer = MapLayerParent.EMapLayer.StaticPins;
			if (_ambulanceEmergency == null)
			{
				Logging.Error("Ambulance Emergency was null when passed into Map Pin.");
				return;
			}
			Setup(dispatchMap, _ambulanceEmergency.Definition.Location.Instance.EmergencyLocation);
			SetupEmergencySeverity();
		}

		protected override void OnDestroy()
		{
			if (_selectMenu != null)
			{
				_selectMenu.CloseMenu();
			}
			base.OnDestroy();
		}

		protected override void ResetPin()
		{
			_ambulanceEmergency = null;
			_pinImage.overrideSprite = null;
			base.ResetPin();
		}

		private void SetupEmergencySeverity()
		{
			_pinImage.sprite = GetSeveritySprite();
		}

		private Sprite GetSeveritySprite()
		{
			int severityDisplayValue = _ambulanceEmergency.Definition.SeverityDisplayValue;
			Sprite[] array = (_ambulanceEmergency.Definition.IsRescue ? GetRescueSprites(_ambulanceEmergency.Definition.ValidAmbulanceType) : GetEmergencySprites(_ambulanceEmergency.Definition.ValidAmbulanceType));
			if (array.Length < severityDisplayValue)
			{
				return null;
			}
			return array[severityDisplayValue - 1];
		}

		private Sprite[] GetRescueSprites(AmbulanceConfig.Type definitionValidAmbulanceType)
		{
			switch (definitionValidAmbulanceType)
			{
			case AmbulanceConfig.Type.All:
				if (_ambulanceEmergency.Definition.SeverityType != ChallengeAmbulanceEmergencyConfig.EmergencySeverityType.Minor)
				{
					return _emergencyDispatchMenu.Definition.MajorRescueSeveritySprites;
				}
				return _emergencyDispatchMenu.Definition.MinorRescueSeveritySprites;
			case AmbulanceConfig.Type.Air:
				if (_ambulanceEmergency.Definition.SeverityType != ChallengeAmbulanceEmergencyConfig.EmergencySeverityType.Minor)
				{
					return _emergencyDispatchMenu.Definition.MajorAirRescueSeveritySprites;
				}
				return _emergencyDispatchMenu.Definition.MinorAirRescueSeveritySprites;
			case AmbulanceConfig.Type.Road:
				if (_ambulanceEmergency.Definition.SeverityType != ChallengeAmbulanceEmergencyConfig.EmergencySeverityType.Minor)
				{
					return _emergencyDispatchMenu.Definition.MajorRoadRescueSeveritySprites;
				}
				return _emergencyDispatchMenu.Definition.MinorRoadRescueSeveritySprites;
			default:
				return null;
			}
		}

		private Sprite[] GetEmergencySprites(AmbulanceConfig.Type definitionValidAmbulanceType)
		{
			switch (definitionValidAmbulanceType)
			{
			case AmbulanceConfig.Type.All:
				if (_ambulanceEmergency.Definition.SeverityType != ChallengeAmbulanceEmergencyConfig.EmergencySeverityType.Minor)
				{
					return _emergencyDispatchMenu.Definition.MajorEmergencySeveritySprites;
				}
				return _emergencyDispatchMenu.Definition.MinorEmergencySeveritySprites;
			case AmbulanceConfig.Type.Air:
				if (_ambulanceEmergency.Definition.SeverityType != ChallengeAmbulanceEmergencyConfig.EmergencySeverityType.Minor)
				{
					return _emergencyDispatchMenu.Definition.MajorAirEmergencySeveritySprites;
				}
				return _emergencyDispatchMenu.Definition.MinorAirEmergencySeveritySprites;
			case AmbulanceConfig.Type.Road:
				if (_ambulanceEmergency.Definition.SeverityType != ChallengeAmbulanceEmergencyConfig.EmergencySeverityType.Minor)
				{
					return _emergencyDispatchMenu.Definition.MajorRoadEmergencySeveritySprites;
				}
				return _emergencyDispatchMenu.Definition.MinorRoadEmergencySeveritySprites;
			default:
				return null;
			}
		}

		public override void Select()
		{
			base.Select();
			if (_selectMenu == null)
			{
				_emergencyDispatchMenu.PeekSelectionMenu(_ambulanceEmergency);
				Transform parentTransformFromLayer = DispatchMap.GetParentTransformFromLayer(MapLayerParent.EMapLayer.Overlay);
				_selectMenu = UnityEngine.Object.Instantiate(_pinSelectPrefab, parentTransformFromLayer).GetComponent<UIPinSelectMenu>();
				_selectMenu.Setup(_emergencyDispatchMenu, _ambulanceEmergency, this);
				_ambulanceEmergency.Level.ChallengeManager.OnAlertSatNav.InvokeSafe(param: true);
				UIPinSelectMenu selectMenu = _selectMenu;
				selectMenu.OnSelectMenuClosed = (Action)Delegate.Combine(selectMenu.OnSelectMenuClosed, new Action(OnSelectMenuClosed));
			}
		}

		private void OnSelectMenuClosed()
		{
			UIPinSelectMenu selectMenu = _selectMenu;
			selectMenu.OnSelectMenuClosed = (Action)Delegate.Remove(selectMenu.OnSelectMenuClosed, new Action(OnSelectMenuClosed));
		}

		public void CircleTutorialPin(bool active)
		{
			GameObjectUtils.SetActive(_TutorialCircle, active);
		}
	}
}
