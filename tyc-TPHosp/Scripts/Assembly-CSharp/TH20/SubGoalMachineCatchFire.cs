using System;
using I2.Loc;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class SubGoalMachineCatchFire : LevelObjectiveSubGoal
	{
		[DontSave]
		private SubGoalDefinitionMachineCatchFire _definition;

		private int _numCaughtFire;

		public SubGoalMachineCatchFire(Objective owner, SubGoalDefinitionMachineCatchFire definition)
			: base(owner, definition)
		{
			_definition = definition;
		}

		public override bool IsDefinitionValid()
		{
			return base.Definition is SubGoalDefinitionMachineCatchFire;
		}

		public override void RestoreFromSave()
		{
			base.RestoreFromSave();
			_definition = (SubGoalDefinitionMachineCatchFire)base.Definition;
			if (Owner.State == Objective.ObjectiveState.Active)
			{
				BuildEvents buildEvents = Level.BuildEvents;
				buildEvents.OnRoomItemOnFire = (Action<RoomItem, RoomItemFlammableComponent>)Delegate.Combine(buildEvents.OnRoomItemOnFire, new Action<RoomItem, RoomItemFlammableComponent>(OnRoomItemOnFire));
			}
		}

		protected override void OnStart()
		{
			BuildEvents buildEvents = Level.BuildEvents;
			buildEvents.OnRoomItemOnFire = (Action<RoomItem, RoomItemFlammableComponent>)Delegate.Combine(buildEvents.OnRoomItemOnFire, new Action<RoomItem, RoomItemFlammableComponent>(OnRoomItemOnFire));
			base.OnStart();
		}

		protected override void OnEnd()
		{
			BuildEvents buildEvents = Level.BuildEvents;
			buildEvents.OnRoomItemOnFire = (Action<RoomItem, RoomItemFlammableComponent>)Delegate.Remove(buildEvents.OnRoomItemOnFire, new Action<RoomItem, RoomItemFlammableComponent>(OnRoomItemOnFire));
			base.OnEnd();
		}

		private void OnRoomItemOnFire(RoomItem roomItem, RoomItemFlammableComponent flammableComponent)
		{
			if (_definition.RoomItemDefinition == null || roomItem.Definition == _definition.RoomItemDefinition.Instance)
			{
				_numCaughtFire++;
				UpdateProgress();
			}
		}

		protected override bool HasCompleted()
		{
			return _numCaughtFire >= _definition.NumToCatchFire;
		}

		public override float PercentComplete()
		{
			return (float)_numCaughtFire / (float)_definition.NumToCatchFire;
		}

		public override int Score()
		{
			return _numCaughtFire;
		}

		public override string ProgressText()
		{
			if (!Completed())
			{
				return $"{_numCaughtFire} / {_definition.NumToCatchFire}";
			}
			return ScriptLocalization.Challenges_SubGoals.Done_CS;
		}
	}
}
