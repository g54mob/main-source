using System;
using System.Collections.Generic;
using I2.Loc;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.WithMembers)]
	public class SubGoalRoomCount : LevelObjectiveSubGoal
	{
		[DontSave]
		private SubGoalDefinitionRoomCount _definition;

		private List<Room> _allRoomsList = new List<Room>();

		public SubGoalRoomCount(Objective owner, SubGoalDefinitionRoomCount definition)
			: base(owner, definition)
		{
			_definition = definition;
		}

		public override bool IsDefinitionValid()
		{
			return base.Definition is SubGoalDefinitionRoomCount;
		}

		public override void RestoreFromSave()
		{
			base.RestoreFromSave();
			_definition = (SubGoalDefinitionRoomCount)base.Definition;
			if (Owner.State == Objective.ObjectiveState.Active)
			{
				RegisterCallbacks();
			}
		}

		protected override void OnStart()
		{
			foreach (Room allRoom in Level.WorldState.AllRooms)
			{
				if (!allRoom.Definition.IsHospitalOrBay && !allRoom.Definition.IsHospitalUnbuilt)
				{
					_allRoomsList.AddUnique(allRoom);
				}
			}
			RegisterCallbacks();
			base.OnStart();
		}

		protected override void OnEnd()
		{
			UnregisterCallbacks();
			base.OnEnd();
		}

		private void RegisterCallbacks()
		{
			BuildEvents buildEvents = Level.BuildEvents;
			buildEvents.OnRoomAdded = (Action<Room>)Delegate.Combine(buildEvents.OnRoomAdded, new Action<Room>(OnRoomAdded));
			BuildEvents buildEvents2 = Level.BuildEvents;
			buildEvents2.OnRoomRemoved = (Action<Room>)Delegate.Combine(buildEvents2.OnRoomRemoved, new Action<Room>(OnRoomRemoved));
		}

		private void UnregisterCallbacks()
		{
			BuildEvents buildEvents = Level.BuildEvents;
			buildEvents.OnRoomAdded = (Action<Room>)Delegate.Remove(buildEvents.OnRoomAdded, new Action<Room>(OnRoomAdded));
			BuildEvents buildEvents2 = Level.BuildEvents;
			buildEvents2.OnRoomRemoved = (Action<Room>)Delegate.Remove(buildEvents2.OnRoomRemoved, new Action<Room>(OnRoomRemoved));
		}

		private void OnRoomAdded(Room room)
		{
			_allRoomsList.AddUnique(room);
			Level.ObjectiveEvents.OnSubGoalUpdated(this);
		}

		private void OnRoomRemoved(Room room)
		{
			_allRoomsList.Remove(room);
			Level.ObjectiveEvents.OnSubGoalUpdated(this);
		}

		protected override bool HasCompleted()
		{
			return _allRoomsList.Count >= _definition.TargetAmount;
		}

		public override float PercentComplete()
		{
			return (float)_allRoomsList.Count / (float)_definition.TargetAmount;
		}

		public override int Score()
		{
			return _allRoomsList.Count;
		}

		public override string ProgressText()
		{
			if (Completed())
			{
				return ScriptLocalization.Challenges_SubGoals.Done_CS;
			}
			return ScriptLocalization.Challenges_SubGoals.RoomCount_Progress_CS.Replace("{[COUNT]}", StringUtils.FormatNumber(_definition.TargetAmount - _allRoomsList.Count));
		}
	}
}
