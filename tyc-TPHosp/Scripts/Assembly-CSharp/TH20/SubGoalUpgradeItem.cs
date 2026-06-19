using System;
using I2.Loc;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.WithMembers)]
	public class SubGoalUpgradeItem : LevelObjectiveSubGoal
	{
		[DontSave]
		private SubGoalUpgradeItemDefinition _definition;

		private int _upgradeCount;

		public SubGoalUpgradeItem(Objective owner, SubGoalUpgradeItemDefinition definition)
			: base(owner, definition)
		{
			_definition = definition;
		}

		public override bool IsDefinitionValid()
		{
			return base.Definition is SubGoalUpgradeItemDefinition;
		}

		public override void RestoreFromSave()
		{
			base.RestoreFromSave();
			_definition = (SubGoalUpgradeItemDefinition)base.Definition;
			if (Owner.State == Objective.ObjectiveState.Active)
			{
				BuildEvents buildEvents = Level.BuildEvents;
				buildEvents.OnRoomItemUpgradeComplete = (Action<RoomItem, Staff>)Delegate.Combine(buildEvents.OnRoomItemUpgradeComplete, new Action<RoomItem, Staff>(OnItemUpgradeComplete));
			}
		}

		protected override void OnStart()
		{
			base.OnStart();
			BuildEvents buildEvents = Level.BuildEvents;
			buildEvents.OnRoomItemUpgradeComplete = (Action<RoomItem, Staff>)Delegate.Combine(buildEvents.OnRoomItemUpgradeComplete, new Action<RoomItem, Staff>(OnItemUpgradeComplete));
		}

		protected override void OnEnd()
		{
			BuildEvents buildEvents = Level.BuildEvents;
			buildEvents.OnRoomItemUpgradeComplete = (Action<RoomItem, Staff>)Delegate.Remove(buildEvents.OnRoomItemUpgradeComplete, new Action<RoomItem, Staff>(OnItemUpgradeComplete));
			base.OnEnd();
		}

		private void OnItemUpgradeComplete(RoomItem roomItem, Staff staff)
		{
			_upgradeCount++;
			UpdateProgress();
		}

		protected override bool HasCompleted()
		{
			return _upgradeCount >= _definition.NumOfUpgrades;
		}

		public override float PercentComplete()
		{
			return (float)_upgradeCount / (float)_definition.NumOfUpgrades;
		}

		public override int Score()
		{
			return _upgradeCount;
		}

		public override string ProgressText()
		{
			if (!Completed())
			{
				return $"{_upgradeCount} / {_definition.NumOfUpgrades}";
			}
			return ScriptLocalization.Challenges_SubGoals.Done_CS;
		}
	}
}
