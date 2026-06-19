using System;
using I2.Loc;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.WithMembers)]
	public class SubGoalRoomPrestige : LevelObjectiveSubGoal
	{
		[DontSave]
		private SubGoalDefinitionRoomPrestige _definition;

		private int _currentLevel;

		private float _currentPoints;

		private int _RequiredPoints;

		public SubGoalRoomPrestige(Objective owner, SubGoalDefinitionRoomPrestige definition)
			: base(owner, definition)
		{
			_definition = definition;
			foreach (Room allRoom in Level.WorldState.AllRooms)
			{
				CheckPrestigeLevel(allRoom.FloorPlan);
			}
			_RequiredPoints = GameAlgorithms.Config.RoomPrestigeLevels[_definition.TargetLevel - 1].Points;
		}

		public override bool IsDefinitionValid()
		{
			return base.Definition is SubGoalDefinitionRoomPrestige;
		}

		public override void RestoreFromSave()
		{
			base.RestoreFromSave();
			_definition = (SubGoalDefinitionRoomPrestige)base.Definition;
			if (Owner.State == Objective.ObjectiveState.Active)
			{
				BuildEvents buildEvents = Level.BuildEvents;
				buildEvents.OnRoomBuiltEvent = (Action<Room, int>)Delegate.Combine(buildEvents.OnRoomBuiltEvent, new Action<Room, int>(OnRoomBuiltEvent));
				BuildEvents buildEvents2 = Level.BuildEvents;
				buildEvents2.OnRoomItemAdded = (Action<RoomItem, FloorPlan>)Delegate.Combine(buildEvents2.OnRoomItemAdded, new Action<RoomItem, FloorPlan>(OnRoomItemAdded));
			}
		}

		protected override void OnStart()
		{
			BuildEvents buildEvents = Level.BuildEvents;
			buildEvents.OnRoomBuiltEvent = (Action<Room, int>)Delegate.Combine(buildEvents.OnRoomBuiltEvent, new Action<Room, int>(OnRoomBuiltEvent));
			BuildEvents buildEvents2 = Level.BuildEvents;
			buildEvents2.OnRoomItemAdded = (Action<RoomItem, FloorPlan>)Delegate.Combine(buildEvents2.OnRoomItemAdded, new Action<RoomItem, FloorPlan>(OnRoomItemAdded));
			base.OnStart();
		}

		protected override void OnEnd()
		{
			BuildEvents buildEvents = Level.BuildEvents;
			buildEvents.OnRoomBuiltEvent = (Action<Room, int>)Delegate.Remove(buildEvents.OnRoomBuiltEvent, new Action<Room, int>(OnRoomBuiltEvent));
			BuildEvents buildEvents2 = Level.BuildEvents;
			buildEvents2.OnRoomItemAdded = (Action<RoomItem, FloorPlan>)Delegate.Remove(buildEvents2.OnRoomItemAdded, new Action<RoomItem, FloorPlan>(OnRoomItemAdded));
			base.OnEnd();
		}

		protected override bool HasCompleted()
		{
			return _currentPoints >= (float)_RequiredPoints;
		}

		public override float PercentComplete()
		{
			return _currentPoints / (float)_RequiredPoints;
		}

		public override int Score()
		{
			return (int)_currentPoints;
		}

		public override string ProgressText()
		{
			if (Completed())
			{
				return ScriptLocalization.Challenges_SubGoals.Done_CS;
			}
			return ScriptLocalization.Challenges_SubGoals.HospitalPrestige_Progress_CS.Replace("{[SCORE]}", _currentLevel.ToString());
		}

		private void OnRoomBuiltEvent(Room room, int cost)
		{
			CheckPrestigeLevel(room.FloorPlan);
		}

		private void OnRoomItemAdded(RoomItem roomItem, FloorPlan floorPlan)
		{
			CheckPrestigeLevel(floorPlan);
		}

		private void CheckPrestigeLevel(FloorPlan floorPlan)
		{
			if (ShouldUpdate() && _definition.IsValidRoom(floorPlan))
			{
				RoomPrestige roomPrestige = GameAlgorithms.CalculateRoomPrestige(floorPlan);
				if (roomPrestige.Points > _currentPoints)
				{
					_currentLevel = roomPrestige.Level;
					_currentPoints = roomPrestige.Points;
					UpdateProgress();
				}
			}
		}
	}
}
