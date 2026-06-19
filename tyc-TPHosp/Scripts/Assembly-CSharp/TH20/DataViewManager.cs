using System;
using System.Collections.Generic;
using FullInspector;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[DontSave]
	public class DataViewManager : MustCallDestroy
	{
		[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
		public class Config
		{
			[Serializable]
			public class CharAttributeVisualisation
			{
				public float MaxValue = 100f;

				public Gradient Gradient = new Gradient();
			}

			[Serializable]
			public class ObjectAttributeVisualisation
			{
				public List<RoomItemDefinition> Definitions = new List<RoomItemDefinition>();

				public float MaxValue = 100f;

				public Gradient Gradient = new Gradient();
			}

			public Material ValueMaterial;

			public SharedInstance<HospitalMapAttributesVisualisation.Config> MapAttributesVisualisationConfig;

			public Dictionary<CharacterAttributes.Type, CharAttributeVisualisation> CharAttributeVisualisations = new Dictionary<CharacterAttributes.Type, CharAttributeVisualisation>();

			public Dictionary<ObjectAttributes.Type, ObjectAttributeVisualisation> ObjectAttributeVisualisations = new Dictionary<ObjectAttributes.Type, ObjectAttributeVisualisation>();

			public float TransitionSpeedOn = 4f;

			public float TransitionSpeedOff = 4f;

			[InspectorMargin(8)]
			[InspectorHeader("Temperature Item Colors")]
			public Color ColdItemColor;

			public Color HotItemColor;

			[InspectorMargin(8)]
			[InspectorHeader("Attractive Item Colors")]
			public Color AttractiveItemColor = Color.green;

			public Color UglyItemColor = Color.red;

			[InspectorMargin(8)]
			[InspectorHeader("Hygiene Item Colors")]
			public Color HygienicItemColor = Color.green;

			public Color UnhygienicItemColor = Color.red;

			[InspectorMargin(8)]
			[InspectorHeader("Staff Type")]
			public Gradient DoctorTypeGradient;

			public Gradient NurseTypeGradient;

			public Gradient AssistantTypeGradient;

			public Gradient JanitorTypeGradient;

			[InspectorMargin(8)]
			[InspectorHeader("Queue Management")]
			public GameObject QueueInfoPrefab;

			public Color QueueHighlightColor = Color.cyan;
		}

		public enum Mode
		{
			None = 0,
			HospitalTemperature = 100,
			HospitalAttractiveness = 101,
			HospitalHygiene = 102,
			CharacterHunger = 200,
			CharacterThirst = 201,
			CharacterToilet = 202,
			CharacterBoredom = 203,
			CharacterLitter = 204,
			CharacterHappiness = 205,
			PatientHealth = 300,
			PatientHappiness = 301,
			StaffEnergy = 400,
			StaffXp = 401,
			StaffType = 402,
			StaffQualifications = 403,
			StaffHappiness = 404,
			ObjectMaintenance = 500
		}

		public Action<Mode> OnEnterMode;

		public Action OnOverlayDisabled;

		private Mode _mode;

		private Mode _lastMode;

		private bool _modeSetByPlayer;

		private Level _level;

		private HospitalMapAttributesVisualisation _mapAttributesVisualisation;

		private Material _valueMaterial;

		private HospitalTemperatureDataView _hospitalTemperatureDataView;

		private HospitalAttractivenessDataView _hospitalAttractivenessDataView;

		private HospitalHygieneDataView _hospitalHygieneDataView;

		private CharacterDataView _characterDataView;

		private MaintenanceDataView _maintenanceDataView;

		private StaffEnergyDataView _staffEnergyDataView;

		private StaffXpDataView _staffXpDataView;

		private StaffTypeDataView _staffTypeDataView;

		private StaffQualificationsDataView _staffQualificationsDataView;

		private StaffHappinessDataView _staffHappinessDataView;

		private PatientHappinessDataView _patientHappinessDataView;

		private IDataViewMode _currentDataViewMode;

		private IDataViewMode _nextDataViewMode;

		private float _dataOpacity;

		private float _transitionSpeedOn;

		private float _transitionSpeedOff;

		private RoomItem _hoverOverItem;

		private Mode _hoverOverItemMode;

		private float _hoverOverItemTime;

		public Mode CurrentMode => _mode;

		public Material ValueMaterial => _valueMaterial;

		public bool CanShowRoomHoverMenu => true;

		public bool CanShowStaffHoverMenu => _mode != Mode.StaffQualifications;

		public bool ModeSetByPlayer => _modeSetByPlayer;

		public bool CanShowStatusIcon(ICursorSelectable selectable)
		{
			if (!(_currentDataViewMode is IDataViewStatusFilter dataViewStatusFilter))
			{
				return true;
			}
			return dataViewStatusFilter.CanShowStatus(selectable);
		}

		public DataViewManager(Config config, Level level, WorldState worldState, VisualManager visualManager)
		{
			_valueMaterial = config.ValueMaterial;
			_level = level;
			_transitionSpeedOn = config.TransitionSpeedOn;
			_transitionSpeedOff = config.TransitionSpeedOff;
			_mapAttributesVisualisation = new HospitalMapAttributesVisualisation(config.MapAttributesVisualisationConfig.Instance, visualManager, worldState);
			_hospitalTemperatureDataView = new HospitalTemperatureDataView(config, _mapAttributesVisualisation, worldState, level.BuildEvents);
			_hospitalAttractivenessDataView = new HospitalAttractivenessDataView(config, _mapAttributesVisualisation, worldState, level.BuildEvents);
			_hospitalHygieneDataView = new HospitalHygieneDataView(config, level, _mapAttributesVisualisation, worldState, level.BuildEvents);
			_characterDataView = new CharacterDataView(config, visualManager, _level);
			_maintenanceDataView = new MaintenanceDataView(config, visualManager, worldState, level.BuildEvents);
			_staffEnergyDataView = new StaffEnergyDataView(config, visualManager, _level);
			_staffXpDataView = new StaffXpDataView(config, visualManager, _level);
			_staffTypeDataView = new StaffTypeDataView(config, visualManager, _level);
			_staffQualificationsDataView = new StaffQualificationsDataView(config, visualManager, _level);
			_staffHappinessDataView = new StaffHappinessDataView(config, visualManager, _level);
			_patientHappinessDataView = new PatientHappinessDataView(config, visualManager, _level);
			BuildEvents buildEvents = _level.BuildEvents;
			buildEvents.OnCursorHoverStart = (Action<ICursorSelectable>)Delegate.Combine(buildEvents.OnCursorHoverStart, new Action<ICursorSelectable>(OnCursorHoverStart));
			BuildEvents buildEvents2 = _level.BuildEvents;
			buildEvents2.OnCursorHoverOut = (Action<ICursorSelectable>)Delegate.Combine(buildEvents2.OnCursorHoverOut, new Action<ICursorSelectable>(OnCursorHoverOut));
			BuildEvents buildEvents3 = _level.BuildEvents;
			buildEvents3.OnRoomItemSold = (Action<RoomItem>)Delegate.Combine(buildEvents3.OnRoomItemSold, new Action<RoomItem>(OnRoomItemSold));
		}

		private void OnCursorHoverStart(ICursorSelectable cursorSelectable)
		{
			if (cursorSelectable is RoomItem roomItem && roomItem.Definition.DataViewMode != Mode.None)
			{
				_hoverOverItemTime = 0f;
				_hoverOverItem = roomItem;
				_hoverOverItemMode = _hoverOverItem.Definition.DataViewMode;
			}
		}

		private void OnRoomItemSold(RoomItem roomItem)
		{
			OnCursorHoverOut(roomItem);
		}

		private void OnCursorHoverOut(ICursorSelectable cursorSelectable)
		{
			if (cursorSelectable == _hoverOverItem)
			{
				_hoverOverItem = null;
				_hoverOverItemMode = Mode.None;
				DisableOverlay(setByPlayer: false);
			}
		}

		public void ToggleMode(Mode mode, bool setByPlayer)
		{
			if (_mode == mode)
			{
				DisableOverlay(setByPlayer);
			}
			else
			{
				EnableMode(mode, setByPlayer);
			}
		}

		public void EnableMode(Mode mode, bool setByPlayer)
		{
			if (_mode != mode && (!_modeSetByPlayer || setByPlayer))
			{
				DisableOverlay(setByPlayer);
				_mode = mode;
				_modeSetByPlayer = setByPlayer;
				switch (mode)
				{
				case Mode.HospitalAttractiveness:
					_nextDataViewMode = _hospitalAttractivenessDataView;
					break;
				case Mode.HospitalTemperature:
					_nextDataViewMode = _hospitalTemperatureDataView;
					break;
				case Mode.HospitalHygiene:
					_nextDataViewMode = _hospitalHygieneDataView;
					break;
				case Mode.CharacterHunger:
				case Mode.CharacterThirst:
				case Mode.CharacterToilet:
				case Mode.CharacterBoredom:
				case Mode.CharacterLitter:
				case Mode.CharacterHappiness:
					_nextDataViewMode = _characterDataView;
					break;
				case Mode.PatientHealth:
					_nextDataViewMode = _characterDataView;
					break;
				case Mode.PatientHappiness:
					_nextDataViewMode = _patientHappinessDataView;
					break;
				case Mode.StaffEnergy:
					_nextDataViewMode = _staffEnergyDataView;
					break;
				case Mode.StaffType:
					_nextDataViewMode = _staffTypeDataView;
					break;
				case Mode.StaffXp:
					_nextDataViewMode = _staffXpDataView;
					break;
				case Mode.StaffQualifications:
					_nextDataViewMode = _staffQualificationsDataView;
					break;
				case Mode.StaffHappiness:
					_nextDataViewMode = _staffHappinessDataView;
					break;
				case Mode.ObjectMaintenance:
					_nextDataViewMode = _maintenanceDataView;
					break;
				}
				if (_mode == _lastMode)
				{
					SetCurrentMode();
				}
				OnEnterMode.InvokeSafe(mode);
			}
		}

		public void DisableOverlay(bool setByPlayer)
		{
			if (_mode != Mode.None && (!_modeSetByPlayer || setByPlayer))
			{
				if (_currentDataViewMode != null)
				{
					_currentDataViewMode.Disable();
					_currentDataViewMode = null;
				}
				_lastMode = _mode;
				_mode = Mode.None;
				_modeSetByPlayer = false;
				_nextDataViewMode = null;
				OnOverlayDisabled.InvokeSafe();
			}
		}

		public void Update()
		{
			if (_hoverOverItemMode != Mode.None)
			{
				_hoverOverItemTime += GameTime.unscaledDeltaTime;
				if (_hoverOverItemTime >= GameAlgorithms.Config.CursorHoverVisualisationStartTime)
				{
					EnableMode(_hoverOverItemMode, setByPlayer: false);
					_hoverOverItemMode = Mode.None;
				}
			}
			if (_currentDataViewMode != null)
			{
				_currentDataViewMode.Update();
				_dataOpacity = Mathf.Clamp01(_dataOpacity + GameTime.unscaledDeltaTime * _transitionSpeedOn);
			}
			else
			{
				float dataOpacity = _dataOpacity;
				_dataOpacity = Mathf.Clamp01(_dataOpacity - GameTime.unscaledDeltaTime * _transitionSpeedOff);
				if (dataOpacity > 0f && _dataOpacity <= 0f)
				{
					_mapAttributesVisualisation.HideAttributeMap();
					_level.VisualManager.RoomLightingManager.DisableHospitalEffects();
					_level.WorldState.CalculateLighting();
				}
				if (_nextDataViewMode != null && _dataOpacity <= 0f)
				{
					SetCurrentMode();
				}
			}
			_level.VisualManager.RoomLightingManager.SetDataMapOpacity(_dataOpacity);
		}

		private void SetCurrentMode()
		{
			if (_nextDataViewMode != null)
			{
				_currentDataViewMode = _nextDataViewMode;
				_currentDataViewMode.Enable(_mode);
				_nextDataViewMode = null;
				_level.WorldState.CalculateLighting();
			}
		}

		public override void Destroy()
		{
			if (_currentDataViewMode != null)
			{
				_currentDataViewMode.Disable();
				_currentDataViewMode = null;
			}
			BuildEvents buildEvents = _level.BuildEvents;
			buildEvents.OnCursorHoverStart = (Action<ICursorSelectable>)Delegate.Remove(buildEvents.OnCursorHoverStart, new Action<ICursorSelectable>(OnCursorHoverStart));
			BuildEvents buildEvents2 = _level.BuildEvents;
			buildEvents2.OnCursorHoverOut = (Action<ICursorSelectable>)Delegate.Remove(buildEvents2.OnCursorHoverOut, new Action<ICursorSelectable>(OnCursorHoverOut));
			BuildEvents buildEvents3 = _level.BuildEvents;
			buildEvents3.OnRoomItemSold = (Action<RoomItem>)Delegate.Remove(buildEvents3.OnRoomItemSold, new Action<RoomItem>(OnRoomItemSold));
			_mapAttributesVisualisation.Destroy();
			base.Destroy();
		}

		public static void EnableValueMaterialOnObjectsWithMapModifier(HospitalAttributeMap.Attribute attribute, WorldState worldState)
		{
			foreach (Room allRoom in worldState.AllRooms)
			{
				if (allRoom.Definition.IsNoDataRoom)
				{
					break;
				}
				foreach (RoomItem item in allRoom.FloorPlan.Items)
				{
					if (TryGetRoomItemMapModifierValue(item, attribute, out var _))
					{
						item.Visual.EnableValueMaterial();
					}
				}
			}
		}

		public static bool TryGetRoomItemMapModifierValue(RoomItem roomItem, HospitalAttributeMap.Attribute attribute, out float value)
		{
			RoomModifier[] roomModifiers = roomItem.Definition.RoomModifiers;
			if (roomItem.OwningRoom.Definition.IsNoDataRoom)
			{
				value = 0f;
				return false;
			}
			if (roomModifiers != null)
			{
				for (int i = 0; i < roomModifiers.Length; i++)
				{
					if (roomModifiers[i] is RoomModifierMapAttribute roomModifierMapAttribute && roomModifierMapAttribute.Attribute == attribute)
					{
						value = roomModifierMapAttribute.GetAttributeValue(roomItem);
						return true;
					}
				}
			}
			value = 0f;
			return false;
		}

		public static CharacterAttributes.Type ModeToCharAttribute(Mode mode)
		{
			return mode switch
			{
				Mode.CharacterHunger => CharacterAttributes.Type.Hunger, 
				Mode.CharacterThirst => CharacterAttributes.Type.Thirst, 
				Mode.CharacterToilet => CharacterAttributes.Type.Toilet, 
				Mode.CharacterBoredom => CharacterAttributes.Type.Boredom, 
				Mode.CharacterLitter => CharacterAttributes.Type.Litter, 
				Mode.CharacterHappiness => CharacterAttributes.Type.Happiness, 
				Mode.HospitalHygiene => CharacterAttributes.Type.Hygiene, 
				Mode.PatientHealth => CharacterAttributes.Type.Health, 
				Mode.PatientHappiness => CharacterAttributes.Type.Happiness, 
				Mode.StaffEnergy => CharacterAttributes.Type.Energy, 
				Mode.StaffXp => CharacterAttributes.Type.XP, 
				_ => CharacterAttributes.Type.None, 
			};
		}

		public static void EnableValueMaterialOnObjectsWithObjectAttribute(ObjectAttributes.Type attributeType, WorldState worldState)
		{
			foreach (Room allRoom in worldState.AllRooms)
			{
				if (allRoom.Definition.IsNoDataRoom)
				{
					continue;
				}
				foreach (RoomItem item in allRoom.FloorPlan.Items)
				{
					if (item.GetAttributes() != null && item.GetAttributes().GetAttribute((int)attributeType) != null)
					{
						item.Visual.EnableValueMaterial();
					}
				}
			}
		}

		public static void DisableValueMaterialOnObjects(WorldState worldState)
		{
			foreach (Room allRoom in worldState.AllRooms)
			{
				if (allRoom.Definition.IsNoDataRoom)
				{
					continue;
				}
				foreach (RoomItem item in allRoom.FloorPlan.Items)
				{
					item.Visual.DisableValueMaterial();
				}
			}
		}
	}
}
