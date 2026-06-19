using System;
using I2.Loc;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.WithMembers)]
	public class SubGoalBuildReception : LevelObjectiveSubGoal
	{
		private bool _validReception;

		public SubGoalBuildReception(Objective owner, SubGoalDefinition definition)
			: base(owner, definition)
		{
		}

		public override void RestoreFromSave()
		{
			if (Owner.State == Objective.ObjectiveState.Active)
			{
				BuildEvents buildEvents = Level.BuildEvents;
				buildEvents.OnRoomItemAdded = (Action<RoomItem, FloorPlan>)Delegate.Combine(buildEvents.OnRoomItemAdded, new Action<RoomItem, FloorPlan>(OnItemBuilt));
				BuildEvents buildEvents2 = Level.BuildEvents;
				buildEvents2.OnRoomBuiltEvent = (Action<Room, int>)Delegate.Combine(buildEvents2.OnRoomBuiltEvent, new Action<Room, int>(OnRoomBuiltEvent));
			}
		}

		protected override void OnStart()
		{
			BuildEvents buildEvents = Level.BuildEvents;
			buildEvents.OnRoomItemAdded = (Action<RoomItem, FloorPlan>)Delegate.Combine(buildEvents.OnRoomItemAdded, new Action<RoomItem, FloorPlan>(OnItemBuilt));
			BuildEvents buildEvents2 = Level.BuildEvents;
			buildEvents2.OnRoomBuiltEvent = (Action<Room, int>)Delegate.Combine(buildEvents2.OnRoomBuiltEvent, new Action<Room, int>(OnRoomBuiltEvent));
			_validReception = Level.ReceptionManager.IsReceptionValid(out var _);
			if (_validReception)
			{
				UpdateProgress();
			}
			base.OnStart();
		}

		protected override void OnEnd()
		{
			BuildEvents buildEvents = Level.BuildEvents;
			buildEvents.OnRoomItemAdded = (Action<RoomItem, FloorPlan>)Delegate.Remove(buildEvents.OnRoomItemAdded, new Action<RoomItem, FloorPlan>(OnItemBuilt));
			BuildEvents buildEvents2 = Level.BuildEvents;
			buildEvents2.OnRoomBuiltEvent = (Action<Room, int>)Delegate.Remove(buildEvents2.OnRoomBuiltEvent, new Action<Room, int>(OnRoomBuiltEvent));
			base.OnEnd();
		}

		protected override bool HasCompleted()
		{
			return _validReception;
		}

		public override float PercentComplete()
		{
			return _validReception ? 1 : 0;
		}

		public override int Score()
		{
			if (!_validReception)
			{
				return 0;
			}
			return 1;
		}

		public override string ProgressText()
		{
			if (!Completed())
			{
				return string.Empty;
			}
			return ScriptLocalization.Challenges_SubGoals.Done_CS;
		}

		private void OnItemBuilt(RoomItem item, FloorPlan floorPlan)
		{
			Level.ReceptionManager.OnRoomItemAdded(item, floorPlan);
			_validReception = Level.ReceptionManager.IsReceptionValid(out var _);
			if (_validReception)
			{
				UpdateProgress();
			}
		}

		private void OnRoomBuiltEvent(Room room, int cost)
		{
			Level.ReceptionManager.OnRoomBuiltEvent(room, cost);
			_validReception = Level.ReceptionManager.IsReceptionValid(out var _);
			if (_validReception)
			{
				UpdateProgress();
			}
		}
	}
}
