using System;
using I2.Loc;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class SubGoalMachineExplode : LevelObjectiveSubGoal
	{
		[DontSave]
		private SubGoalDefinitionMachineExplode _definition;

		private int _numExploded;

		public SubGoalMachineExplode(Objective owner, SubGoalDefinitionMachineExplode definition)
			: base(owner, definition)
		{
			_definition = definition;
		}

		public override bool IsDefinitionValid()
		{
			return base.Definition is SubGoalDefinitionMachineExplode;
		}

		public override void RestoreFromSave()
		{
			base.RestoreFromSave();
			_definition = (SubGoalDefinitionMachineExplode)base.Definition;
			if (Owner.State == Objective.ObjectiveState.Active)
			{
				BuildEvents buildEvents = Level.BuildEvents;
				buildEvents.OnRoomItemExploded = (Action<RoomItem, RoomItemFlammableComponent>)Delegate.Combine(buildEvents.OnRoomItemExploded, new Action<RoomItem, RoomItemFlammableComponent>(OnRoomItemExploded));
			}
		}

		protected override void OnStart()
		{
			BuildEvents buildEvents = Level.BuildEvents;
			buildEvents.OnRoomItemExploded = (Action<RoomItem, RoomItemFlammableComponent>)Delegate.Combine(buildEvents.OnRoomItemExploded, new Action<RoomItem, RoomItemFlammableComponent>(OnRoomItemExploded));
			base.OnStart();
		}

		protected override void OnEnd()
		{
			BuildEvents buildEvents = Level.BuildEvents;
			buildEvents.OnRoomItemExploded = (Action<RoomItem, RoomItemFlammableComponent>)Delegate.Remove(buildEvents.OnRoomItemExploded, new Action<RoomItem, RoomItemFlammableComponent>(OnRoomItemExploded));
			base.OnEnd();
		}

		private void OnRoomItemExploded(RoomItem roomItem, RoomItemFlammableComponent flammableComponent)
		{
			if (_definition.RoomItemDefinition == null || roomItem.Definition == _definition.RoomItemDefinition.Instance)
			{
				_numExploded++;
				UpdateProgress();
			}
		}

		protected override bool HasCompleted()
		{
			return _numExploded >= _definition.NumToExplode;
		}

		public override float PercentComplete()
		{
			return (float)_numExploded / (float)_definition.NumToExplode;
		}

		public override int Score()
		{
			return _numExploded;
		}

		public override string ProgressText()
		{
			if (!Completed())
			{
				return $"{_numExploded} / {_definition.NumToExplode}";
			}
			return ScriptLocalization.Challenges_SubGoals.Done_CS;
		}
	}
}
