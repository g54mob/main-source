using System;
using System.Collections.Generic;
using I2.Loc;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.WithMembers)]
	public class SubGoalBuildRoom : LevelObjectiveSubGoal
	{
		[DontSave]
		private SubGoalDefinitionBuildRoom _definition;

		private readonly List<Room> _roomList = new List<Room>();

		public SubGoalBuildRoom(Objective owner, SubGoalDefinitionBuildRoom definition)
			: base(owner, definition)
		{
			_definition = definition;
		}

		public override bool IsDefinitionValid()
		{
			return base.Definition is SubGoalDefinitionBuildRoom;
		}

		public override void RestoreFromSave()
		{
			base.RestoreFromSave();
			_definition = (SubGoalDefinitionBuildRoom)base.Definition;
			if (Owner.State == Objective.ObjectiveState.Active)
			{
				BuildEvents buildEvents = Level.BuildEvents;
				buildEvents.OnRoomDeleted = (Action<Room>)Delegate.Combine(buildEvents.OnRoomDeleted, new Action<Room>(OnRoomDeleted));
				BuildEvents buildEvents2 = Level.BuildEvents;
				buildEvents2.OnRoomBuiltEvent = (Action<Room, int>)Delegate.Combine(buildEvents2.OnRoomBuiltEvent, new Action<Room, int>(OnRoomBuiltEvent));
			}
		}

		protected override void OnStart()
		{
			BuildEvents buildEvents = Level.BuildEvents;
			buildEvents.OnRoomDeleted = (Action<Room>)Delegate.Combine(buildEvents.OnRoomDeleted, new Action<Room>(OnRoomDeleted));
			BuildEvents buildEvents2 = Level.BuildEvents;
			buildEvents2.OnRoomBuiltEvent = (Action<Room, int>)Delegate.Combine(buildEvents2.OnRoomBuiltEvent, new Action<Room, int>(OnRoomBuiltEvent));
			if (_definition.IncludeExisting)
			{
				Level.WorldState.IterateRoomsOfType(_definition.RoomDefinition.Instance, includeClosed: true, delegate(Room room)
				{
					_roomList.Add(room);
				});
			}
			base.OnStart();
		}

		protected override void OnEnd()
		{
			BuildEvents buildEvents = Level.BuildEvents;
			buildEvents.OnRoomBuiltEvent = (Action<Room, int>)Delegate.Remove(buildEvents.OnRoomBuiltEvent, new Action<Room, int>(OnRoomBuiltEvent));
			BuildEvents buildEvents2 = Level.BuildEvents;
			buildEvents2.OnRoomDeleted = (Action<Room>)Delegate.Remove(buildEvents2.OnRoomDeleted, new Action<Room>(OnRoomDeleted));
			base.OnEnd();
		}

		protected override bool HasCompleted()
		{
			return _roomList.Count >= _definition.RequiredCount;
		}

		public override float PercentComplete()
		{
			return (float)_roomList.Count / (float)_definition.RequiredCount;
		}

		public override int Score()
		{
			return _roomList.Count;
		}

		public override string ProgressText()
		{
			if (!Completed())
			{
				return $"{_roomList.Count} / {_definition.RequiredCount}";
			}
			return ScriptLocalization.Challenges_SubGoals.Done_CS;
		}

		private void OnRoomBuiltEvent(Room room, int cost)
		{
			if (room.Definition._type == _definition.RoomDefinition.Instance._type)
			{
				_roomList.AddUnique(room);
				UpdateProgress();
			}
		}

		private void OnRoomDeleted(Room room)
		{
			if (room.Definition._type == _definition.RoomDefinition.Instance._type)
			{
				_roomList.Remove(room);
				UpdateProgress();
			}
		}
	}
}
