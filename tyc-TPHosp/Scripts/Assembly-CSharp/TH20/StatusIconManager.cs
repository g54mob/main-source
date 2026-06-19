#define LOG_LEVEL_VERBOSE
using System;
using System.Collections.Generic;
using System.Linq;
using FullInspector;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[DontSave]
	public class StatusIconManager : MustCallDestroy
	{
		[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
		public class Config
		{
			[SerializeField]
			[FullInspector.InspectorName("Icons: First entry is highest priority")]
			private StatusIcon[] _icons;

			public StatusIcon[] Icons => _icons;

			public StatusIcon FindIconPrefab(StatusIcon.Type type, out int priority)
			{
				for (int i = 0; i < _icons.Length; i++)
				{
					if (_icons[i].IconType == type)
					{
						priority = i;
						return _icons[i];
					}
				}
				priority = 0;
				return null;
			}
		}

		private readonly Config _config;

		private readonly Level _level;

		private readonly BuildEvents _buildEvents;

		private readonly CharacterEvents _characterEvents;

		[DontSave]
		private readonly DataViewManager _dataViewManager;

		private readonly Dictionary<IStatusIconEmitter, StatusIcon> _activeIcons;

		private readonly Dictionary<StatusIcon.Type, PrefabPool> _prefabPools;

		private List<IStatusIconEmitter> _toDestroyCachedList = new List<IStatusIconEmitter>();

		public StatusIconManager(Config config, Level level, DataViewManager dataViewManager, BuildEvents buildEvents, CharacterEvents characterEvents)
		{
			_config = config;
			_level = level;
			_buildEvents = buildEvents;
			_characterEvents = characterEvents;
			_dataViewManager = dataViewManager;
			_activeIcons = new Dictionary<IStatusIconEmitter, StatusIcon>();
			CharacterEvents characterEvents2 = _characterEvents;
			characterEvents2.OnCharacterUrgentNeed = (Action<Character, CharacterAttributes.Type>)Delegate.Combine(characterEvents2.OnCharacterUrgentNeed, new Action<Character, CharacterAttributes.Type>(OnCharacterUrgentNeed));
			CharacterEvents characterEvents3 = _characterEvents;
			characterEvents3.OnFatalTreatment = (Action<Patient, List<Staff>>)Delegate.Combine(characterEvents3.OnFatalTreatment, new Action<Patient, List<Staff>>(OnFatalTreatment));
			CharacterEvents characterEvents4 = _characterEvents;
			characterEvents4.OnIneffectiveTreatment = (Action<Patient, List<Staff>>)Delegate.Combine(characterEvents4.OnIneffectiveTreatment, new Action<Patient, List<Staff>>(OnIneffectiveTreatment));
			CharacterEvents characterEvents5 = _characterEvents;
			characterEvents5.OnPatientCured = (Action<Patient, List<Staff>>)Delegate.Combine(characterEvents5.OnPatientCured, new Action<Patient, List<Staff>>(OnPatientCured));
			CharacterEvents characterEvents6 = _characterEvents;
			characterEvents6.OnPatientSentHome = (Action<Patient>)Delegate.Combine(characterEvents6.OnPatientSentHome, new Action<Patient>(OnPatientSentHome));
			CharacterEvents characterEvents7 = _characterEvents;
			characterEvents7.OnPatientRageQuit = (Action<Patient>)Delegate.Combine(characterEvents7.OnPatientRageQuit, new Action<Patient>(OnPatientRageQuit));
			CharacterEvents characterEvents8 = _characterEvents;
			characterEvents8.OnPatientDiagnosisExhausted = (Action<Patient>)Delegate.Combine(characterEvents8.OnPatientDiagnosisExhausted, new Action<Patient>(OnPatientDiagnosisExhausted));
			CharacterEvents characterEvents9 = _characterEvents;
			characterEvents9.OnStaffIdle = (Action<Staff>)Delegate.Combine(characterEvents9.OnStaffIdle, new Action<Staff>(OnStaffIdle));
			CharacterEvents characterEvents10 = _characterEvents;
			characterEvents10.OnStaffFired = (Action<Staff>)Delegate.Combine(characterEvents10.OnStaffFired, new Action<Staff>(OnStaffFired));
			CharacterEvents characterEvents11 = _characterEvents;
			characterEvents11.OnStaffPromoted = (Action<Staff>)Delegate.Combine(characterEvents11.OnStaffPromoted, new Action<Staff>(OnStaffPromoted));
			CharacterEvents characterEvents12 = _characterEvents;
			characterEvents12.OnStaffReadyForPromotion = (Action<Staff>)Delegate.Combine(characterEvents12.OnStaffReadyForPromotion, new Action<Staff>(OnStaffReadyForPromotion));
			CharacterEvents characterEvents13 = _characterEvents;
			characterEvents13.OnStaffTakeBreak = (Action<Staff>)Delegate.Combine(characterEvents13.OnStaffTakeBreak, new Action<Staff>(OnStaffTakeBreak));
			CharacterEvents characterEvents14 = _characterEvents;
			characterEvents14.OnStaffReadyToStartTraining = (Action<Staff, Room>)Delegate.Combine(characterEvents14.OnStaffReadyToStartTraining, new Action<Staff, Room>(OnStaffReadyToStartTraining));
			CharacterEvents characterEvents15 = _characterEvents;
			characterEvents15.OnStaffStartLearning = (Action<Staff, RoomLogicTrainingRoom>)Delegate.Combine(characterEvents15.OnStaffStartLearning, new Action<Staff, RoomLogicTrainingRoom>(OnStaffStartLearning));
			BuildEvents buildEvents2 = _buildEvents;
			buildEvents2.OnRoomItemRemoved = (Action<RoomItem, FloorPlan>)Delegate.Combine(buildEvents2.OnRoomItemRemoved, new Action<RoomItem, FloorPlan>(OnRoomItemRemoved));
			BuildEvents buildEvents3 = _buildEvents;
			buildEvents3.OnRoomItemBrokenDown = (Action<RoomItem>)Delegate.Combine(buildEvents3.OnRoomItemBrokenDown, new Action<RoomItem>(OnRoomItemBrokenDown));
			BuildEvents buildEvents4 = _buildEvents;
			buildEvents4.OnRoomItemMaintained = (Action<RoomItem>)Delegate.Combine(buildEvents4.OnRoomItemMaintained, new Action<RoomItem>(OnRoomItemMaintenanceComplete));
			BuildEvents buildEvents5 = _buildEvents;
			buildEvents5.OnRoomItemMaintenanceRequired = (Action<RoomItem>)Delegate.Combine(buildEvents5.OnRoomItemMaintenanceRequired, new Action<RoomItem>(OnRoomItemNeedsMaintenance));
			BuildEvents buildEvents6 = _buildEvents;
			buildEvents6.OnRoomItemDestroyed = (Action<RoomItem>)Delegate.Combine(buildEvents6.OnRoomItemDestroyed, new Action<RoomItem>(DestroyStatusIcon));
			BuildEvents buildEvents7 = _buildEvents;
			buildEvents7.OnRoomMissingRequiredItem = (Action<Room>)Delegate.Combine(buildEvents7.OnRoomMissingRequiredItem, new Action<Room>(OnRoomMissingRequiredItem));
			DataViewManager dataViewManager2 = _dataViewManager;
			dataViewManager2.OnEnterMode = (Action<DataViewManager.Mode>)Delegate.Combine(dataViewManager2.OnEnterMode, new Action<DataViewManager.Mode>(OnEnterDataViewMode));
			_prefabPools = new Dictionary<StatusIcon.Type, PrefabPool>();
			Transform transform = new GameObject("Status Icon Prefab Pools").transform;
			StatusIcon[] icons = _config.Icons;
			foreach (StatusIcon statusIcon in icons)
			{
				Transform transform2 = new GameObject().transform;
				transform2.parent = transform;
				_prefabPools.Add(statusIcon.IconType, new PrefabPool(statusIcon.gameObject, 16, transform2));
			}
		}

		public override void Destroy()
		{
			foreach (IStatusIconEmitter item in _activeIcons.Keys.ToList())
			{
				DestroyStatusIcon(item);
			}
			CharacterEvents characterEvents = _characterEvents;
			characterEvents.OnCharacterUrgentNeed = (Action<Character, CharacterAttributes.Type>)Delegate.Remove(characterEvents.OnCharacterUrgentNeed, new Action<Character, CharacterAttributes.Type>(OnCharacterUrgentNeed));
			CharacterEvents characterEvents2 = _characterEvents;
			characterEvents2.OnFatalTreatment = (Action<Patient, List<Staff>>)Delegate.Remove(characterEvents2.OnFatalTreatment, new Action<Patient, List<Staff>>(OnFatalTreatment));
			CharacterEvents characterEvents3 = _characterEvents;
			characterEvents3.OnIneffectiveTreatment = (Action<Patient, List<Staff>>)Delegate.Remove(characterEvents3.OnIneffectiveTreatment, new Action<Patient, List<Staff>>(OnIneffectiveTreatment));
			CharacterEvents characterEvents4 = _characterEvents;
			characterEvents4.OnPatientCured = (Action<Patient, List<Staff>>)Delegate.Remove(characterEvents4.OnPatientCured, new Action<Patient, List<Staff>>(OnPatientCured));
			CharacterEvents characterEvents5 = _characterEvents;
			characterEvents5.OnPatientSentHome = (Action<Patient>)Delegate.Remove(characterEvents5.OnPatientSentHome, new Action<Patient>(OnPatientSentHome));
			CharacterEvents characterEvents6 = _characterEvents;
			characterEvents6.OnPatientRageQuit = (Action<Patient>)Delegate.Remove(characterEvents6.OnPatientRageQuit, new Action<Patient>(OnPatientRageQuit));
			CharacterEvents characterEvents7 = _characterEvents;
			characterEvents7.OnPatientDiagnosisExhausted = (Action<Patient>)Delegate.Remove(characterEvents7.OnPatientDiagnosisExhausted, new Action<Patient>(OnPatientDiagnosisExhausted));
			CharacterEvents characterEvents8 = _characterEvents;
			characterEvents8.OnStaffIdle = (Action<Staff>)Delegate.Remove(characterEvents8.OnStaffIdle, new Action<Staff>(OnStaffIdle));
			CharacterEvents characterEvents9 = _characterEvents;
			characterEvents9.OnStaffFired = (Action<Staff>)Delegate.Remove(characterEvents9.OnStaffFired, new Action<Staff>(OnStaffFired));
			CharacterEvents characterEvents10 = _characterEvents;
			characterEvents10.OnStaffPromoted = (Action<Staff>)Delegate.Remove(characterEvents10.OnStaffPromoted, new Action<Staff>(OnStaffPromoted));
			CharacterEvents characterEvents11 = _characterEvents;
			characterEvents11.OnStaffReadyForPromotion = (Action<Staff>)Delegate.Remove(characterEvents11.OnStaffReadyForPromotion, new Action<Staff>(OnStaffReadyForPromotion));
			CharacterEvents characterEvents12 = _characterEvents;
			characterEvents12.OnStaffTakeBreak = (Action<Staff>)Delegate.Remove(characterEvents12.OnStaffTakeBreak, new Action<Staff>(OnStaffTakeBreak));
			CharacterEvents characterEvents13 = _characterEvents;
			characterEvents13.OnStaffReadyToStartTraining = (Action<Staff, Room>)Delegate.Remove(characterEvents13.OnStaffReadyToStartTraining, new Action<Staff, Room>(OnStaffReadyToStartTraining));
			CharacterEvents characterEvents14 = _characterEvents;
			characterEvents14.OnStaffStartLearning = (Action<Staff, RoomLogicTrainingRoom>)Delegate.Remove(characterEvents14.OnStaffStartLearning, new Action<Staff, RoomLogicTrainingRoom>(OnStaffStartLearning));
			BuildEvents buildEvents = _buildEvents;
			buildEvents.OnRoomItemRemoved = (Action<RoomItem, FloorPlan>)Delegate.Remove(buildEvents.OnRoomItemRemoved, new Action<RoomItem, FloorPlan>(OnRoomItemRemoved));
			BuildEvents buildEvents2 = _buildEvents;
			buildEvents2.OnRoomItemBrokenDown = (Action<RoomItem>)Delegate.Remove(buildEvents2.OnRoomItemBrokenDown, new Action<RoomItem>(OnRoomItemBrokenDown));
			BuildEvents buildEvents3 = _buildEvents;
			buildEvents3.OnRoomItemMaintained = (Action<RoomItem>)Delegate.Remove(buildEvents3.OnRoomItemMaintained, new Action<RoomItem>(OnRoomItemMaintenanceComplete));
			BuildEvents buildEvents4 = _buildEvents;
			buildEvents4.OnRoomItemMaintenanceRequired = (Action<RoomItem>)Delegate.Remove(buildEvents4.OnRoomItemMaintenanceRequired, new Action<RoomItem>(OnRoomItemNeedsMaintenance));
			BuildEvents buildEvents5 = _buildEvents;
			buildEvents5.OnRoomItemDestroyed = (Action<RoomItem>)Delegate.Remove(buildEvents5.OnRoomItemDestroyed, new Action<RoomItem>(DestroyStatusIcon));
			BuildEvents buildEvents6 = _buildEvents;
			buildEvents6.OnRoomMissingRequiredItem = (Action<Room>)Delegate.Remove(buildEvents6.OnRoomMissingRequiredItem, new Action<Room>(OnRoomMissingRequiredItem));
			DataViewManager dataViewManager = _dataViewManager;
			dataViewManager.OnEnterMode = (Action<DataViewManager.Mode>)Delegate.Remove(dataViewManager.OnEnterMode, new Action<DataViewManager.Mode>(OnEnterDataViewMode));
			foreach (KeyValuePair<StatusIcon.Type, PrefabPool> prefabPool in _prefabPools)
			{
				prefabPool.Value.Destroy();
			}
			base.Destroy();
		}

		public bool HasActiveStatusIcon(IStatusIconEmitter emitter)
		{
			return GetActiveStatusIconType(emitter) != StatusIcon.Type.Invalid;
		}

		public StatusIcon GetActiveStatusIcon(IStatusIconEmitter emitter)
		{
			if (!_activeIcons.TryGetValue(emitter, out var value))
			{
				return null;
			}
			return value;
		}

		public StatusIcon.Type GetActiveStatusIconType(IStatusIconEmitter emitter)
		{
			if (!_activeIcons.TryGetValue(emitter, out var value))
			{
				return StatusIcon.Type.Invalid;
			}
			return value.IconType;
		}

		public StatusIcon GetStatusIcon(StatusIcon.Type type)
		{
			int priority;
			return _config.FindIconPrefab(type, out priority);
		}

		public void ShowStatusIcon(IStatusIconEmitter emitter, StatusIcon.Type type)
		{
			if (!DebugVars.ShowStatusIcons.Value)
			{
				return;
			}
			if (_config.FindIconPrefab(type, out var priority) != null)
			{
				if (_activeIcons.ContainsKey(emitter))
				{
					StatusIcon statusIcon = _activeIcons[emitter];
					if (statusIcon.IconType == type)
					{
						statusIcon.ExtendTime();
						return;
					}
					if (statusIcon.Priority <= priority)
					{
						return;
					}
					statusIcon.Destroy();
					_prefabPools[statusIcon.IconType].ReturnInstance(statusIcon.gameObject);
				}
				StatusIcon component = _prefabPools[type].GetInstance().GetComponent<StatusIcon>();
				component.Initialise(emitter, _level, priority);
				_activeIcons[emitter] = component;
			}
			else
			{
				Logging.Error(LogChannels.GUI, "Missing status icon prefab for '{0}'", type);
			}
		}

		public void HideStatusIcon(IStatusIconEmitter emitter, StatusIcon.Type type)
		{
			if (emitter != null && _activeIcons.ContainsKey(emitter))
			{
				StatusIcon statusIcon = _activeIcons[emitter];
				if (statusIcon.IconType == type)
				{
					statusIcon.Destroy();
					_prefabPools[statusIcon.IconType].ReturnInstance(statusIcon.gameObject);
					_activeIcons.Remove(emitter);
				}
			}
		}

		public void DestroyStatusIcon(IStatusIconEmitter emitter)
		{
			if (emitter != null && _activeIcons.ContainsKey(emitter))
			{
				StatusIcon statusIcon = _activeIcons[emitter];
				statusIcon.Destroy();
				_prefabPools[statusIcon.IconType].ReturnInstance(statusIcon.gameObject);
				_activeIcons.Remove(emitter);
			}
		}

		public void Update()
		{
			_toDestroyCachedList.Clear();
			foreach (KeyValuePair<IStatusIconEmitter, StatusIcon> activeIcon in _activeIcons)
			{
				StatusIcon value = activeIcon.Value;
				IStatusIconEmitter key = activeIcon.Key;
				if (value.HasTimedOut() || !DebugVars.ShowStatusIcons.Value)
				{
					_toDestroyCachedList.Add(key);
					continue;
				}
				value.UpdatePosition();
				bool flag = !key.IsStatusIconEmitterVisible();
				if (key is ICursorSelectable cursorSelectable)
				{
					flag |= cursorSelectable.GetActiveMenu() != null;
					flag |= !_dataViewManager.CanShowStatusIcon(cursorSelectable);
				}
				SetEmitterVisible(key, !flag);
			}
			foreach (IStatusIconEmitter toDestroyCached in _toDestroyCachedList)
			{
				DestroyStatusIcon(toDestroyCached);
			}
			_toDestroyCachedList.Clear();
		}

		private void SetEmitterVisible(IStatusIconEmitter emitter, bool visible)
		{
			if (emitter != null && _activeIcons.ContainsKey(emitter))
			{
				GameObjectUtils.SetActive(_activeIcons[emitter].gameObject, visible);
			}
		}

		private void OnStaffIdle(Staff staff)
		{
			ShowStatusIcon(staff, StatusIcon.Type.StaffIdle);
		}

		private void OnStaffTakeBreak(Staff staff)
		{
			ShowStatusIcon(staff, StatusIcon.Type.StaffBreak);
		}

		private void OnStaffPromoted(Staff staff)
		{
			ShowStatusIcon(staff, StatusIcon.Type.Promoted);
		}

		private void OnStaffReadyForPromotion(Staff staff)
		{
			ShowStatusIcon(staff, StatusIcon.Type.PromotionReady);
		}

		private void OnStaffFired(Staff staff)
		{
			ShowStatusIcon(staff, StatusIcon.Type.StaffFired);
		}

		private void OnStaffReadyToStartTraining(Staff staff, Room room)
		{
			ShowStatusIcon(staff, StatusIcon.Type.StaffTraining);
		}

		private void OnStaffStartLearning(Staff staff, RoomLogicTrainingRoom roomLogicTrainingRoom)
		{
			ShowStatusIcon(staff, StatusIcon.Type.StaffTraining);
		}

		private void OnPatientCured(Patient patient, List<Staff> involvedStaff)
		{
			DestroyStatusIcon(patient);
			ShowStatusIcon(patient, StatusIcon.Type.Cured);
		}

		private void OnPatientSentHome(Patient patient)
		{
			if (!patient.IsSendHomeAnachronistic())
			{
				DestroyStatusIcon(patient);
				ShowStatusIcon(patient, StatusIcon.Type.SentHome);
			}
		}

		private void OnPatientRageQuit(Patient patient)
		{
			DestroyStatusIcon(patient);
			ShowStatusIcon(patient, StatusIcon.Type.RageQuitting);
		}

		private void OnPatientDiagnosisExhausted(Patient patient)
		{
			ShowStatusIcon(patient, StatusIcon.Type.DiagnosisExhausted);
		}

		private void OnIneffectiveTreatment(Patient patient, List<Staff> involvedStaff)
		{
			DestroyStatusIcon(patient);
			ShowStatusIcon(patient, StatusIcon.Type.TreatmentIneffective);
		}

		private void OnFatalTreatment(Patient patient, List<Staff> involvedStaff)
		{
			DestroyStatusIcon(patient);
			ShowStatusIcon(patient, StatusIcon.Type.Dying);
		}

		private void OnRoomItemBrokenDown(RoomItem roomItem)
		{
			if (roomItem.Definition.ShowStatusIcon)
			{
				ShowStatusIcon(roomItem, StatusIcon.Type.MaintenanceRequired);
			}
		}

		private void OnRoomItemNeedsMaintenance(RoomItem roomItem)
		{
			if (roomItem.Definition.ShowStatusIcon)
			{
				ShowStatusIcon(roomItem, StatusIcon.Type.MaintenanceWarning);
			}
		}

		private void OnRoomItemMaintenanceComplete(RoomItem roomItem)
		{
			DestroyStatusIcon(roomItem);
		}

		private void OnRoomItemRemoved(RoomItem roomItem, FloorPlan floorPlan)
		{
			DestroyStatusIcon(roomItem);
		}

		private void OnRoomMissingRequiredItem(Room room)
		{
			ShowStatusIcon(room, StatusIcon.Type.StaffRequired);
		}

		private void OnCharacterUrgentNeed(Character character, CharacterAttributes.Type need)
		{
			switch (need)
			{
			case CharacterAttributes.Type.Hunger:
				ShowStatusIcon(character, StatusIcon.Type.Hunger);
				break;
			case CharacterAttributes.Type.Thirst:
				ShowStatusIcon(character, StatusIcon.Type.Thirst);
				break;
			case CharacterAttributes.Type.Toilet:
				ShowStatusIcon(character, StatusIcon.Type.Toilet);
				break;
			case CharacterAttributes.Type.Boredom:
				ShowStatusIcon(character, StatusIcon.Type.Boredom);
				break;
			case CharacterAttributes.Type.Litter:
				ShowStatusIcon(character, StatusIcon.Type.DropLitter);
				break;
			}
		}

		private void OnEnterDataViewMode(DataViewManager.Mode mode)
		{
			if (mode != DataViewManager.Mode.StaffQualifications)
			{
				return;
			}
			foreach (Staff staffMember in _level.CharacterManager.StaffMembers)
			{
				ShowStatusIcon(staffMember, StatusIcon.Type.StaffQualifications);
			}
		}
	}
}
