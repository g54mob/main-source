using System;
using System.Collections.Generic;
using I2.Loc;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.WithMembers)]
	public class SubGoalOpenRoom : LevelObjectiveSubGoal
	{
		[DontSave]
		private SubGoalDefinitionOpenRoom _definition;

		private readonly List<Room> _roomList = new List<Room>();

		public SubGoalOpenRoom(Objective owner, SubGoalDefinitionOpenRoom definition)
			: base(owner, definition)
		{
			_definition = definition;
		}

		public override bool IsDefinitionValid()
		{
			return base.Definition is SubGoalDefinitionOpenRoom;
		}

		public override void RestoreFromSave()
		{
			base.RestoreFromSave();
			_definition = (SubGoalDefinitionOpenRoom)base.Definition;
			if (Owner.State == Objective.ObjectiveState.Active)
			{
				BuildEvents buildEvents = Level.BuildEvents;
				buildEvents.OnRoomOpened = (Action<Room>)Delegate.Combine(buildEvents.OnRoomOpened, new Action<Room>(OnRoomOpened));
				BuildEvents buildEvents2 = Level.BuildEvents;
				buildEvents2.OnRoomDeleted = (Action<Room>)Delegate.Combine(buildEvents2.OnRoomDeleted, new Action<Room>(OnRoomDeleted));
			}
			List<Room> list = new List<Room>();
			foreach (Room room in _roomList)
			{
				if (room != null && !room.HasBeenRestored)
				{
					list.Add(room);
				}
			}
			foreach (Room item in list)
			{
				_roomList.Remove(item);
			}
		}

		protected override void OnStart()
		{
			BuildEvents buildEvents = Level.BuildEvents;
			buildEvents.OnRoomOpened = (Action<Room>)Delegate.Combine(buildEvents.OnRoomOpened, new Action<Room>(OnRoomOpened));
			BuildEvents buildEvents2 = Level.BuildEvents;
			buildEvents2.OnRoomDeleted = (Action<Room>)Delegate.Combine(buildEvents2.OnRoomDeleted, new Action<Room>(OnRoomDeleted));
			base.OnStart();
		}

		protected override void OnEnd()
		{
			BuildEvents buildEvents = Level.BuildEvents;
			buildEvents.OnRoomOpened = (Action<Room>)Delegate.Remove(buildEvents.OnRoomOpened, new Action<Room>(OnRoomOpened));
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

		private void OnRoomOpened(Room room)
		{
			_roomList.AddUnique(room);
			UpdateProgress();
		}

		private void OnRoomDeleted(Room room)
		{
			_roomList.Remove(room);
		}
	}
}
