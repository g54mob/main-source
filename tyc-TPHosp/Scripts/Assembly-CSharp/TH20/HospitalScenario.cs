#define LOG_LEVEL_VERBOSE
using System.Collections.Generic;
using FullInspector;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class HospitalScenario
	{
		public class ItemRecord
		{
			public SharedInstance<RoomItemDefinition> Definition;

			public float Maintenance;

			[HideInInspector]
			public Vector3 LocalPosition;

			[HideInInspector]
			public float LocalRotation;
		}

		public class RoomRecord
		{
			public SharedInstance<RoomDefinition> Definition;

			public List<ItemRecord> Items = new List<ItemRecord>();

			[HideInInspector]
			public int HospitalPlot;

			[HideInInspector]
			public SharedInstance<HospitalPlotDefinition> HospitalPlotInstance;

			[HideInInspector]
			public GridCoord Anchor;

			[HideInInspector]
			public bool[,] Tiles;
		}

		public class StaffRecord
		{
			public SharedInstance<StaffDefinition> Definition;

			public int Rank;

			public List<SharedInstance<QualificationDefinition>> Qualifications = new List<SharedInstance<QualificationDefinition>>();
		}

		[UsedImplicitly(ImplicitUseTargetFlags.Members)]
		public class PatientRecord
		{
			public int SpawnCount = 1;

			public float DiagnosisMin;

			public float DiagnosisMax;

			[InspectorTooltip("None is random illness")]
			public SharedInstance<IllnessDefinition> Illness;
		}

		[UsedImplicitly(ImplicitUseTargetFlags.Members)]
		public class HospitalRecord
		{
			[FullInspector.InspectorName("Reputation")]
			public float Reputaion;

			public List<RoomRecord> Rooms = new List<RoomRecord>();

			public List<StaffRecord> Staff = new List<StaffRecord>();

			public List<PatientRecord> Patients = new List<PatientRecord>();
		}

		[SerializeField]
		private HospitalRecord _record;

		public void SaveSnapshot(Level level)
		{
			_record.Reputaion = level.ReputationTracker.TotalSpecialReputation;
			_record.Rooms.Clear();
			foreach (Room allRoom in level.WorldState.AllRooms)
			{
				HospitalPlot plot = allRoom.FloorPlan.HospitalMap.Plot;
				if (!plot.Built)
				{
					continue;
				}
				RoomRecord roomRecord = new RoomRecord
				{
					HospitalPlot = 0,
					HospitalPlotInstance = SharedInstanceUtils.GetSharedInstance(plot.Definition),
					Anchor = allRoom.FloorPlan.Anchor,
					Definition = SharedInstanceUtils.GetSharedInstance(allRoom.Definition)
				};
				if (allRoom.Definition.IsHospitalOrBay)
				{
					foreach (RoomItem item in allRoom.FloorPlan.Items)
					{
						RoomItemDefinition.Type itemType = item.Definition.ItemType;
						if (itemType != RoomItemDefinition.Type.Door && itemType != RoomItemDefinition.Type.SideDoor && itemType != RoomItemDefinition.Type.Window && itemType != RoomItemDefinition.Type.Landscape)
						{
							SaveItem(roomRecord, item);
						}
					}
				}
				else
				{
					roomRecord.Tiles = allRoom.FloorPlan.Tiles;
					foreach (RoomItem item2 in allRoom.FloorPlan.Items)
					{
						if (!item2.IsHospitalWindow)
						{
							SaveItem(roomRecord, item2);
						}
					}
				}
				_record.Rooms.Add(roomRecord);
			}
			_record.Staff.Clear();
			foreach (Staff staffMember in level.CharacterManager.StaffMembers)
			{
				StaffRecord staffRecord = new StaffRecord
				{
					Rank = staffMember.Rank,
					Definition = SharedInstanceUtils.GetSharedInstance(staffMember.Definition)
				};
				staffMember.IterateCompleteQualifications(delegate(QualificationSlot slot)
				{
					staffRecord.Qualifications.Add(SharedInstanceUtils.GetSharedInstance(slot.Definition));
				});
				_record.Staff.Add(staffRecord);
			}
		}

		private static void SaveItem(RoomRecord roomRecord, RoomItem item)
		{
			RoomItemDefinition instance = item.Definition as RoomItemDefinition;
			roomRecord.Items.Add(new ItemRecord
			{
				Definition = SharedInstanceUtils.GetSharedInstance(instance),
				LocalPosition = item.LocalPosition,
				LocalRotation = item.Rotation,
				Maintenance = ((item.MaintenanceLevel != null) ? item.MaintenanceLevel.Value() : 0f)
			});
		}

		public void ApplyToLevel(Level level)
		{
			WorldState worldState = level.WorldState;
			level.ReputationTracker.TotalSpecialReputation = _record.Reputaion;
			foreach (RoomRecord room in _record.Rooms)
			{
				BuildRoom(level, room);
			}
			foreach (Room allRoom in worldState.AllRooms)
			{
				foreach (RoomItem item in allRoom.FloorPlan.Items)
				{
					RoomItemAlgorithms.Validate(ItemValidateMode.Set, fullTest: true, item, worldState, null, null);
					if (allRoom.Definition.IsHospitalOrBay)
					{
						worldState.AddNeedSatisfyingRoomItem(item);
					}
				}
				if (allRoom.Definition.IsHospitalOrBay)
				{
					allRoom.FloorPlanVisual.CreateRoomItems();
					allRoom.FloorPlan.AddItemsToWorld();
				}
				RoomAlgorithms.UpdateNeighbouringWindows(allRoom.FloorPlan, worldState);
			}
			foreach (StaffRecord item2 in _record.Staff)
			{
				SpawnStaff(level, item2);
			}
			foreach (PatientRecord patient in _record.Patients)
			{
				SpawnPatient(level, patient);
			}
		}

		private void BuildRoom(Level level, RoomRecord record)
		{
			WorldState worldState = level.WorldState;
			RoomDefinition instance = record.Definition.Instance;
			HospitalMap hospitalMap = ((record.HospitalPlotInstance == null) ? worldState.HospitalPlots[record.HospitalPlot] : worldState.GetHospitalPlot(record.HospitalPlotInstance.Instance)).HospitalMap;
			if (hospitalMap == null)
			{
				return;
			}
			if (record.Definition.Instance.IsHospitalOrBay)
			{
				BuildRoomItems(level, record.Items, hospitalMap.FloorPlan);
				RoomAlgorithms.IterateRoomItemsWithComponent(hospitalMap.Room, delegate(DebrisEffectComponent component)
				{
					component.Destroy();
				});
				return;
			}
			if (record.Tiles == null || record.Tiles.Length == 0)
			{
				Logging.Error(LogChannels.Building, "Looks like you've manually added a room to this levels scenario config\n\nUse the console command SaveScenario to save room layouts");
				return;
			}
			Room room = new Room(instance, level);
			FloorPlan floorPlan = new FloorPlan(instance, level, hospitalMap)
			{
				Anchor = record.Anchor,
				Tiles = record.Tiles
			};
			RoomFloorPlanVisual roomFloorPlanVisual = new RoomFloorPlanVisual(worldState, level.VisualManager, instance.ToString(), instance.GetFloorTile(worldState), level.DataViewManager.ValueMaterial, level.Config.GetBuildingLogicConfig().RoomItemEditConfig, instance._wallsInterior, level.BuildEvents);
			room.Initialise(floorPlan, roomFloorPlanVisual);
			BuildRoomItems(level, record.Items, floorPlan);
			floorPlan.RecalculateWalls();
			foreach (RoomItem item in floorPlan.Items)
			{
				RoomItemAlgorithms.Validate(ItemValidateMode.Set, fullTest: true, item, worldState, null, null);
			}
			roomFloorPlanVisual.UpdateFromRoom(floorPlan);
			room.FloorPlan.AddItemsToWorld();
			worldState.AddRoom(room, animateWalls: false);
			level.BuildEvents.OnNewRoomBuiltEvent.InvokeSafe(room);
			worldState.BuildRoom(room, 0);
			room.Open();
			RoomAlgorithms.IterateRoomItemsWithComponent(room, delegate(DebrisEffectComponent component)
			{
				component.Destroy();
			});
		}

		private void BuildRoomItems(Level level, List<ItemRecord> items, FloorPlan floorPlan)
		{
			if (items == null)
			{
				return;
			}
			foreach (ItemRecord item in items)
			{
				if (item.Definition.Instance.ItemType != RoomItemDefinition.Type.SideDoor)
				{
					RoomItem roomItem = new RoomItem(item.Definition.Instance, floorPlan, level)
					{
						LocalPosition = item.LocalPosition,
						Rotation = item.LocalRotation,
						HasBeenPurchased = true
					};
					if (roomItem.MaintenanceLevel != null)
					{
						roomItem.MaintenanceLevel.SetValue(item.Maintenance, callCallbacks: true);
					}
					floorPlan.AddItem(roomItem);
				}
			}
		}

		private void SpawnStaff(Level level, StaffRecord record)
		{
			Room room = level.WorldState.AllRooms[0];
			WeightedList<QualificationDefinition> weightedList = new WeightedList<QualificationDefinition>();
			foreach (SharedInstance<QualificationDefinition> qualification in record.Qualifications)
			{
				weightedList.Add(qualification.Instance, 100);
			}
			Vector3 randomSpawnPositionForCharacter = RoomAlgorithms.GetRandomSpawnPositionForCharacter(room.FloorPlan);
			JobApplicant jobApplicant = new JobApplicant(record.Definition.Instance, level.CharacterNameGenerator, 0f, 50, record.Rank, weightedList, level.CharacterTraitsManager, level.Metagame, level);
			Staff staff = level.CharacterManager.SpawnStaff(jobApplicant, randomSpawnPositionForCharacter, navDisabled: false);
			foreach (KeyValuePair<QualificationDefinition, int> item in weightedList.List)
			{
				staff.Debug_AssignQualification(item.Key);
			}
			level.CharacterEvents.OnStaffDrop.InvokeSafe(staff, room, param3: true);
			level.CharacterEvents.OnStaffHired.InvokeSafe(staff, jobApplicant, jobApplicant.RecruitmentFee);
		}

		private void SpawnPatient(Level level, PatientRecord record)
		{
			List<HospitalMap> hospitalMaps = level.WorldState.HospitalMaps;
			for (int i = 0; i < record.SpawnCount; i++)
			{
				Vector3 randomSpawnPositionForCharacter = RoomAlgorithms.GetRandomSpawnPositionForCharacter(hospitalMaps.RandomItem().CorridorFloorPlan);
				IllnessDefinition illnessDefinition = (record.Illness.NotNull() ? record.Illness.Instance : level.CharacterManager.RandomIllness());
				Patient patient = level.CharacterManager.CreatePatient(illnessDefinition, randomSpawnPositionForCharacter);
				float amount = ((record.DiagnosisMax > 0f) ? RandomUtils.GlobalRandomInstance.NextFloat(record.DiagnosisMin, record.DiagnosisMax + 1f) : 0f);
				patient.Position = randomSpawnPositionForCharacter;
				patient.NavPath.Warp(randomSpawnPositionForCharacter);
				patient.ModifyDiagnosisCertainty(amount);
				if (patient.DiagnosisCertainty >= 100f)
				{
					patient.SendToTreatmentRoom(patient.Illness.GetTreatmentRoom(patient, level.ResearchManager), immediately: true);
				}
			}
		}
	}
}
