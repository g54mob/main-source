using System;
using System.Collections.Generic;

namespace TH20
{
	public class GameplayStatsTracker : MustCallDestroy, IGameEventsBase
	{
		private readonly BuildEvents _buildEvents;

		private readonly CharacterEvents _characterEvents;

		private readonly Dictionary<IllnessDefinition, int> _illnessesCured = new Dictionary<IllnessDefinition, int>();

		private readonly Dictionary<IllnessDefinition, int> _illnessesDiagnosed = new Dictionary<IllnessDefinition, int>();

		private readonly Dictionary<IllnessDefinition, int> _illnessesFatal = new Dictionary<IllnessDefinition, int>();

		private readonly Dictionary<IllnessDefinition, int> _illnessesIneffective = new Dictionary<IllnessDefinition, int>();

		private readonly Dictionary<IllnessDefinition, int> _illnessesRageQuits = new Dictionary<IllnessDefinition, int>();

		private Dictionary<IllnessDefinition, int> _illnessesAnachronistic = new Dictionary<IllnessDefinition, int>();

		private Dictionary<IllnessDefinition, int> _illnessesTimeTunnel = new Dictionary<IllnessDefinition, int>();

		private int _illnessesAnachronisticCount;

		private int _illnessesTimeTunnelCount;

		private readonly Dictionary<RoomDefinition, int> _roomsInHospital = new Dictionary<RoomDefinition, int>();

		private readonly Dictionary<IRoomItemDefinition, int> _roomItemsInHospital = new Dictionary<IRoomItemDefinition, int>();

		public Action<IllnessDefinition> OnNewDiscoveredIllnessesStat;

		public List<IllnessDefinition> DiscoveredIllnesses => new List<IllnessDefinition>(_illnessesDiagnosed.Keys);

		public GameplayStatsTracker(BuildEvents buildEvents, CharacterEvents characterEvents)
		{
			GameEventsRegistry.RegisterLevelEvent(this);
			_buildEvents = buildEvents;
			_characterEvents = characterEvents;
			RegisterEvents();
		}

		public override void RestoreFromSave()
		{
			base.RestoreFromSave();
			if (_illnessesAnachronistic == null)
			{
				_illnessesAnachronistic = new Dictionary<IllnessDefinition, int>();
			}
			if (_illnessesTimeTunnel == null)
			{
				_illnessesTimeTunnel = new Dictionary<IllnessDefinition, int>();
			}
			RegisterEvents();
		}

		private void RegisterEvents()
		{
			CharacterEvents characterEvents = _characterEvents;
			characterEvents.OnPatientSpawned = (Action<Patient>)Delegate.Combine(characterEvents.OnPatientSpawned, new Action<Patient>(OnPatientSpawned));
			CharacterEvents characterEvents2 = _characterEvents;
			characterEvents2.OnPatientCured = (Action<Patient, List<Staff>>)Delegate.Combine(characterEvents2.OnPatientCured, new Action<Patient, List<Staff>>(OnPatientCured));
			CharacterEvents characterEvents3 = _characterEvents;
			characterEvents3.OnIllnessDiagnosed = (Action<Patient, IllnessDefinition>)Delegate.Combine(characterEvents3.OnIllnessDiagnosed, new Action<Patient, IllnessDefinition>(OnIllnessDiagnosed));
			CharacterEvents characterEvents4 = _characterEvents;
			characterEvents4.OnFatalTreatment = (Action<Patient, List<Staff>>)Delegate.Combine(characterEvents4.OnFatalTreatment, new Action<Patient, List<Staff>>(OnFatalTreatment));
			CharacterEvents characterEvents5 = _characterEvents;
			characterEvents5.OnIneffectiveTreatment = (Action<Patient, List<Staff>>)Delegate.Combine(characterEvents5.OnIneffectiveTreatment, new Action<Patient, List<Staff>>(OnIneffectiveTreatment));
			CharacterEvents characterEvents6 = _characterEvents;
			characterEvents6.OnPatientRageQuit = (Action<Patient>)Delegate.Combine(characterEvents6.OnPatientRageQuit, new Action<Patient>(OnPatientRageQuit));
			CharacterEvents characterEvents7 = _characterEvents;
			characterEvents7.OnPatientDied = (Action<Patient>)Delegate.Combine(characterEvents7.OnPatientDied, new Action<Patient>(OnPatientDied));
			CharacterEvents characterEvents8 = _characterEvents;
			characterEvents8.OnPatientTimeTunnel = (Action<Patient>)Delegate.Combine(characterEvents8.OnPatientTimeTunnel, new Action<Patient>(OnPatientTimeTunnel));
			BuildEvents buildEvents = _buildEvents;
			buildEvents.OnNewRoomBuiltEvent = (Action<Room>)Delegate.Combine(buildEvents.OnNewRoomBuiltEvent, new Action<Room>(OnNewRoomBuiltEvent));
			BuildEvents buildEvents2 = _buildEvents;
			buildEvents2.OnRoomDeleted = (Action<Room>)Delegate.Combine(buildEvents2.OnRoomDeleted, new Action<Room>(OnRoomDeleted));
			BuildEvents buildEvents3 = _buildEvents;
			buildEvents3.OnRoomItemAdded = (Action<RoomItem, FloorPlan>)Delegate.Combine(buildEvents3.OnRoomItemAdded, new Action<RoomItem, FloorPlan>(OnRoomItemAdded));
			BuildEvents buildEvents4 = _buildEvents;
			buildEvents4.OnRoomItemRemoved = (Action<RoomItem, FloorPlan>)Delegate.Combine(buildEvents4.OnRoomItemRemoved, new Action<RoomItem, FloorPlan>(OnRoomItemRemoved));
		}

		public override void Destroy()
		{
			CharacterEvents characterEvents = _characterEvents;
			characterEvents.OnPatientSpawned = (Action<Patient>)Delegate.Remove(characterEvents.OnPatientSpawned, new Action<Patient>(OnPatientSpawned));
			CharacterEvents characterEvents2 = _characterEvents;
			characterEvents2.OnPatientCured = (Action<Patient, List<Staff>>)Delegate.Remove(characterEvents2.OnPatientCured, new Action<Patient, List<Staff>>(OnPatientCured));
			CharacterEvents characterEvents3 = _characterEvents;
			characterEvents3.OnIllnessDiagnosed = (Action<Patient, IllnessDefinition>)Delegate.Remove(characterEvents3.OnIllnessDiagnosed, new Action<Patient, IllnessDefinition>(OnIllnessDiagnosed));
			CharacterEvents characterEvents4 = _characterEvents;
			characterEvents4.OnFatalTreatment = (Action<Patient, List<Staff>>)Delegate.Remove(characterEvents4.OnFatalTreatment, new Action<Patient, List<Staff>>(OnFatalTreatment));
			CharacterEvents characterEvents5 = _characterEvents;
			characterEvents5.OnIneffectiveTreatment = (Action<Patient, List<Staff>>)Delegate.Remove(characterEvents5.OnIneffectiveTreatment, new Action<Patient, List<Staff>>(OnIneffectiveTreatment));
			CharacterEvents characterEvents6 = _characterEvents;
			characterEvents6.OnPatientRageQuit = (Action<Patient>)Delegate.Remove(characterEvents6.OnPatientRageQuit, new Action<Patient>(OnPatientRageQuit));
			CharacterEvents characterEvents7 = _characterEvents;
			characterEvents7.OnPatientDied = (Action<Patient>)Delegate.Remove(characterEvents7.OnPatientDied, new Action<Patient>(OnPatientDied));
			CharacterEvents characterEvents8 = _characterEvents;
			characterEvents8.OnPatientTimeTunnel = (Action<Patient>)Delegate.Remove(characterEvents8.OnPatientTimeTunnel, new Action<Patient>(OnPatientTimeTunnel));
			BuildEvents buildEvents = _buildEvents;
			buildEvents.OnNewRoomBuiltEvent = (Action<Room>)Delegate.Remove(buildEvents.OnNewRoomBuiltEvent, new Action<Room>(OnNewRoomBuiltEvent));
			BuildEvents buildEvents2 = _buildEvents;
			buildEvents2.OnRoomDeleted = (Action<Room>)Delegate.Remove(buildEvents2.OnRoomDeleted, new Action<Room>(OnRoomDeleted));
			BuildEvents buildEvents3 = _buildEvents;
			buildEvents3.OnRoomItemAdded = (Action<RoomItem, FloorPlan>)Delegate.Remove(buildEvents3.OnRoomItemAdded, new Action<RoomItem, FloorPlan>(OnRoomItemAdded));
			BuildEvents buildEvents4 = _buildEvents;
			buildEvents4.OnRoomItemRemoved = (Action<RoomItem, FloorPlan>)Delegate.Remove(buildEvents4.OnRoomItemRemoved, new Action<RoomItem, FloorPlan>(OnRoomItemRemoved));
			base.Destroy();
		}

		public void VerifyEvents()
		{
			OnNewDiscoveredIllnessesStat.VerifyIsNull();
		}

		private void OnPatientSpawned(Patient patient)
		{
			if (patient.GetComponent<AnachronisticTreatmentComponent>() != null)
			{
				if (!_illnessesAnachronistic.ContainsKey(patient.Illness))
				{
					_illnessesAnachronistic.Add(patient.Illness, 1);
				}
				else
				{
					_illnessesAnachronistic[patient.Illness]++;
				}
				_illnessesAnachronisticCount++;
			}
		}

		private void OnPatientCured(Patient patient, List<Staff> involvedStaff)
		{
			if (!_illnessesCured.ContainsKey(patient.Illness))
			{
				_illnessesCured.Add(patient.Illness, 1);
			}
			else
			{
				_illnessesCured[patient.Illness]++;
			}
		}

		private void OnIllnessDiagnosed(Patient patient, IllnessDefinition illness)
		{
			if (!_illnessesDiagnosed.ContainsKey(illness))
			{
				_illnessesDiagnosed.Add(illness, 1);
				OnNewDiscoveredIllnessesStat.InvokeSafe(illness);
			}
			else
			{
				_illnessesDiagnosed[illness]++;
			}
		}

		private void OnFatalTreatment(Patient patient, List<Staff> involvedStaff)
		{
			if (!_illnessesFatal.ContainsKey(patient.Illness))
			{
				_illnessesFatal.Add(patient.Illness, 1);
			}
			else
			{
				_illnessesFatal[patient.Illness]++;
			}
		}

		private void OnIneffectiveTreatment(Patient patient, List<Staff> involvedStaff)
		{
			if (!_illnessesIneffective.ContainsKey(patient.Illness))
			{
				_illnessesIneffective.Add(patient.Illness, 1);
			}
			else
			{
				_illnessesIneffective[patient.Illness]++;
			}
		}

		private void OnPatientRageQuit(Patient patient)
		{
			if (!_illnessesRageQuits.ContainsKey(patient.Illness))
			{
				_illnessesRageQuits.Add(patient.Illness, 1);
			}
			else
			{
				_illnessesRageQuits[patient.Illness]++;
			}
		}

		private void OnPatientDied(Patient patient)
		{
			if (patient.TreatmentOutcome == Treatment.Outcome.Unknown)
			{
				if (!_illnessesFatal.ContainsKey(patient.Illness))
				{
					_illnessesFatal.Add(patient.Illness, 1);
				}
				else
				{
					_illnessesFatal[patient.Illness]++;
				}
			}
		}

		private void OnPatientTimeTunnel(Patient patient)
		{
			if (!_illnessesTimeTunnel.ContainsKey(patient.Illness))
			{
				_illnessesTimeTunnel.Add(patient.Illness, 1);
			}
			else
			{
				_illnessesTimeTunnel[patient.Illness]++;
			}
			_illnessesTimeTunnelCount++;
		}

		public bool HasIllnessBeenDiagnosedBefore(IllnessDefinition illness)
		{
			return _illnessesDiagnosed.ContainsKey(illness);
		}

		public int GetNumberOfCures(IllnessDefinition illnessDefinition)
		{
			if (!_illnessesCured.TryGetValue(illnessDefinition, out var value))
			{
				return 0;
			}
			return value;
		}

		public int GetNumberOfFatalTreatments(IllnessDefinition illnessDefinition)
		{
			if (!_illnessesFatal.TryGetValue(illnessDefinition, out var value))
			{
				return 0;
			}
			return value;
		}

		public int GetNumberOfIneffectiveTreatments(IllnessDefinition illnessDefinition)
		{
			if (!_illnessesIneffective.TryGetValue(illnessDefinition, out var value))
			{
				return 0;
			}
			return value;
		}

		public int GetNumberOfRageQuits(IllnessDefinition illnessDefinition)
		{
			if (!_illnessesRageQuits.TryGetValue(illnessDefinition, out var value))
			{
				return 0;
			}
			return value;
		}

		public int GetNumberOfPatientsAnachronistic(IllnessDefinition illnessDefinition = null)
		{
			if (illnessDefinition == null)
			{
				return _illnessesAnachronisticCount;
			}
			int value = 0;
			if (!_illnessesAnachronistic.TryGetValue(illnessDefinition, out value))
			{
				return 0;
			}
			return value;
		}

		public int GetNumberOfTimeTunnels(IllnessDefinition illnessDefinition = null)
		{
			if (illnessDefinition == null)
			{
				return _illnessesTimeTunnelCount;
			}
			int value = 0;
			if (!_illnessesTimeTunnel.TryGetValue(illnessDefinition, out value))
			{
				return 0;
			}
			return value;
		}

		private void OnNewRoomBuiltEvent(Room room)
		{
			if (!_roomsInHospital.ContainsKey(room.Definition))
			{
				_roomsInHospital.Add(room.Definition, 1);
			}
			else
			{
				_roomsInHospital[room.Definition]++;
			}
		}

		private void OnRoomDeleted(Room room)
		{
			if (_roomsInHospital.ContainsKey(room.Definition))
			{
				_roomsInHospital[room.Definition]--;
			}
		}

		public int GetNumberOfRooms(RoomDefinition definition)
		{
			if (!_roomsInHospital.ContainsKey(definition))
			{
				return 0;
			}
			return _roomsInHospital[definition];
		}

		private void OnRoomItemAdded(RoomItem roomItem, FloorPlan floorPlan)
		{
			if (!_roomItemsInHospital.ContainsKey(roomItem.Definition))
			{
				_roomItemsInHospital.Add(roomItem.Definition, 1);
			}
			else
			{
				_roomItemsInHospital[roomItem.Definition]++;
			}
		}

		private void OnRoomItemRemoved(RoomItem roomItem, FloorPlan floorPlan)
		{
			if (_roomItemsInHospital.ContainsKey(roomItem.Definition))
			{
				_roomItemsInHospital[roomItem.Definition]--;
			}
		}

		public int GetNumberOfRoomItems(IRoomItemDefinition definition)
		{
			if (!_roomItemsInHospital.ContainsKey(definition))
			{
				return 0;
			}
			return _roomItemsInHospital[definition];
		}
	}
}
