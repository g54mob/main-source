using System;
using System.Collections.Generic;
using I2.Loc;
using JetBrains.Annotations;
using TH20.BT_Types;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class VIPComponent : EntityComponent
	{
		[SerializeField]
		private VIPDefinition _definition;

		private List<Room> _roomsVisited;

		private int _roomsVisitedCount;

		private int _numRoomsVIPWantsToVisit;

		private VIPTourRouteConfig _routeConfig;

		private Level _level;

		private float _cachedAppraisalScore;

		public VIPDefinition Definition => _definition;

		public VIPAppraisal Appraisal { get; private set; }

		public Room TargetRoom { get; private set; }

		public bool CanInspectCorridor { get; set; }

		public int RoomsLeftToVisit
		{
			get
			{
				if (_numRoomsVIPWantsToVisit > 0)
				{
					return _roomsVisitedCount / _numRoomsVIPWantsToVisit;
				}
				return 0;
			}
		}

		public int RoomsVisited => _roomsVisitedCount;

		public int RoomsWantsToVisit => _numRoomsVIPWantsToVisit;

		protected override Type ValidEntityType()
		{
			return typeof(Visitor);
		}

		public void Initialise(Level level, VIPTourRouteConfig routeConfig, VIPAppraisalCriteriaRangesConfig appraisalRangesConfig, VIPAppraisalCriteriaInterest appraisalCriteriaInterest)
		{
			_level = level;
			_routeConfig = routeConfig;
			_roomsVisited = new List<Room>();
			_numRoomsVIPWantsToVisit = (int)RandomUtils.GlobalRandomInstance.NextDouble(_routeConfig.MinRoomsInTour, _routeConfig.MaxRoomsInTour);
			TargetRoom = null;
			CanInspectCorridor = false;
			Appraisal = new VIPAppraisal(GetOwner<Visitor>(), _level, appraisalRangesConfig, appraisalCriteriaInterest);
			RegisterEvents();
		}

		internal override void RestoreComponentFromSave()
		{
			base.RestoreComponentFromSave();
			RegisterEvents();
			if (_roomsVisitedCount == 0 && _roomsVisited.Count != 0)
			{
				_roomsVisitedCount = _roomsVisited.Count;
			}
		}

		private void RegisterEvents()
		{
			BuildEvents buildEvents = _level.BuildEvents;
			buildEvents.OnRoomDeleted = (Action<Room>)Delegate.Combine(buildEvents.OnRoomDeleted, new Action<Room>(OnRoomDeleted));
			CharacterEvents characterEvents = _level.CharacterEvents;
			characterEvents.OnPlanToEnterRoom = (Action<Character, Room>)Delegate.Combine(characterEvents.OnPlanToEnterRoom, new Action<Character, Room>(OnPlanToEnterRoom));
			BuildEvents buildEvents2 = _level.BuildEvents;
			buildEvents2.OnEnterEditFloorPlanState = (Action<Room, BlueprintFloorPlan, BlueprintFloorPlanVisual>)Delegate.Combine(buildEvents2.OnEnterEditFloorPlanState, new Action<Room, BlueprintFloorPlan, BlueprintFloorPlanVisual>(OnEnterEditFloorPlanState));
		}

		public override void Destroy()
		{
			BuildEvents buildEvents = _level.BuildEvents;
			buildEvents.OnRoomDeleted = (Action<Room>)Delegate.Remove(buildEvents.OnRoomDeleted, new Action<Room>(OnRoomDeleted));
			CharacterEvents characterEvents = _level.CharacterEvents;
			characterEvents.OnPlanToEnterRoom = (Action<Character, Room>)Delegate.Remove(characterEvents.OnPlanToEnterRoom, new Action<Character, Room>(OnPlanToEnterRoom));
			BuildEvents buildEvents2 = _level.BuildEvents;
			buildEvents2.OnEnterEditFloorPlanState = (Action<Room, BlueprintFloorPlan, BlueprintFloorPlanVisual>)Delegate.Remove(buildEvents2.OnEnterEditFloorPlanState, new Action<Room, BlueprintFloorPlan, BlueprintFloorPlanVisual>(OnEnterEditFloorPlanState));
			base.Destroy();
		}

		private void OnPlanToEnterRoom(Character character, Room room)
		{
			if (GetOwner() == character && room == TargetRoom)
			{
				TargetRoom = null;
			}
		}

		private void OnRoomDeleted(Room room)
		{
			if (room == TargetRoom)
			{
				TargetRoom = null;
			}
			_roomsVisited.Remove(room);
		}

		private void OnEnterEditFloorPlanState(Room room, BlueprintFloorPlan floorPlan, BlueprintFloorPlanVisual floorPlanVisual)
		{
			OnRoomDeleted(room);
		}

		public void AppraiseEcoRating()
		{
			List<ChallengeEco> activeChallengesOfType = _level.ChallengeManager.GetActiveChallengesOfType<ChallengeEco>();
			float num = 0f;
			if (activeChallengesOfType.Count <= 0)
			{
				return;
			}
			using List<ChallengeEco>.Enumerator enumerator = activeChallengesOfType.GetEnumerator();
			if (enumerator.MoveNext())
			{
				num = enumerator.Current.GetCurrentEcoRating();
				Appraisal.SubmitAppraiseValue(VIPAppraisal.Criteria.HospitalEcoRating, inRoom: true, num);
			}
		}

		public Room GetNextRoomInTour()
		{
			if (TargetRoom != null)
			{
				return TargetRoom;
			}
			if (_numRoomsVIPWantsToVisit < _roomsVisitedCount)
			{
				return null;
			}
			List<Room> list = new List<Room>();
			List<Room> list2 = new List<Room>();
			for (int i = 0; i < _level.WorldState.AllRooms.Count; i++)
			{
				Room room = _level.WorldState.AllRooms[i];
				if (room.IsOpen && (!_routeConfig.VisitRoomOnlyOnce || !_roomsVisited.Contains(room)) && !_routeConfig.ExcludedRoomList.Contains(room.Definition._type) && !room.Definition.IsHospitalOrBay && !room.Definition.IsHospitalUnbuilt)
				{
					if (_routeConfig.PreferredRoomList.Contains(room.Definition._type))
					{
						list.Add(room);
					}
					else
					{
						list2.Add(room);
					}
				}
			}
			if (list.Count + list2.Count <= 0)
			{
				SubmitShortTourAppraisal();
				TargetRoom = null;
				return null;
			}
			Room room2 = null;
			if ((RandomUtils.GlobalRandomInstance.NextDouble(0.0, 1.0) <= (double)_routeConfig.ProbabiltiyPreferredRoom || list2.Count <= 0) && list.Count > 0)
			{
				int index = (int)(RandomUtils.GlobalRandomInstance.NextFloat() * (float)list.Count);
				room2 = list[index];
			}
			if (!_routeConfig.OnlyVisitPreferredRooms && room2 == null && list2.Count > 0)
			{
				int index2 = (int)(RandomUtils.GlobalRandomInstance.NextFloat() * (float)list2.Count);
				room2 = list2[index2];
			}
			TargetRoom = room2;
			return room2;
		}

		public bool InspectArea()
		{
			Room room = GetOwner<Visitor>().RoomUsing;
			if (room == null)
			{
				return true;
			}
			if (TargetRoom != null && (TargetRoom.Definition._type == RoomDefinition.Type.Toilets || TargetRoom.Definition._type == RoomDefinition.Type.Cafe))
			{
				room = TargetRoom;
			}
			if (!room.Definition.IsHospitalOrBay)
			{
				_roomsVisited.Add(room);
				_roomsVisitedCount++;
			}
			Appraisal.AppraiseRoom(room);
			float num = Appraisal.CalculateCurrentScore();
			bool result = _cachedAppraisalScore <= num;
			_cachedAppraisalScore = num;
			return result;
		}

		public string GetGUIActionText()
		{
			Visitor owner = GetOwner<Visitor>();
			if (owner != null)
			{
				if (TargetRoom != null)
				{
					return ScriptLocalization.HospitalEvent.VIPVisitingRoom_CS.Replace("{[ROOM]}", TargetRoom.GetRoomName());
				}
				if (owner.CurrentMode == Visitor.Mode.LeavingHospital)
				{
					return ScriptLocalization.HospitalEvent.VIPLeaving_CS;
				}
				if (owner.GetComponent<CharacterCheckInComponent>() != null)
				{
					return ScriptLocalization.HospitalEvent.VIPArriving_CS;
				}
				return ScriptLocalization.HospitalEvent.VIPTouring_CS;
			}
			return string.Empty;
		}

		public Sprite GetStatusSprite()
		{
			Visitor owner = GetOwner<Visitor>();
			if (owner != null)
			{
				if (TargetRoom != null)
				{
					return TargetRoom.Definition._icon;
				}
				if (owner.CurrentMode == Visitor.Mode.LeavingHospital)
				{
					return owner.Definition.LeavingSprite;
				}
				return owner.Definition.ArrivalSprite;
			}
			return null;
		}

		public void OnVisitorHasNoBehaviour()
		{
			Visitor owner = GetOwner<Visitor>();
			owner.SetBehaviour(Definition.VIPTourBehavior);
			owner.BehaviorTree.SetVariableValue("MinTimeCorridorObservationDelay", Definition.MinDelayUntilCorridorInspection);
			owner.BehaviorTree.SetVariableValue("MaxTimeCorridorObservationDelay", Definition.MaxDelayUntilCorridorInspection);
			if (Definition.ActionOnEnteringRoom.Instance != null)
			{
				owner.BehaviorTree.SetVariableValue("ActionOnEnteringRoom", new CharacterActionRef(Definition.ActionOnEnteringRoom.Instance));
			}
			if (Definition.ActionOnCorridorInspection.Instance != null)
			{
				owner.BehaviorTree.SetVariableValue("ActionOnCorridorInspection", new CharacterActionRef(Definition.ActionOnCorridorInspection.Instance));
			}
		}

		public void SubmitShortTourAppraisal()
		{
			Appraisal.SubmitAppraiseValue(VIPAppraisal.Criteria.TourTooShort, inRoom: true, _numRoomsVIPWantsToVisit - _roomsVisitedCount);
		}
	}
}
