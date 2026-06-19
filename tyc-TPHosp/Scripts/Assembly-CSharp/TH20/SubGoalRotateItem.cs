using System;
using I2.Loc;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.WithMembers)]
	public class SubGoalRotateItem : LevelObjectiveSubGoal
	{
		[DontSave]
		private SubGoalDefinitionRotateItem _definition;

		private int _rotationsMade;

		public SubGoalRotateItem(Objective owner, SubGoalDefinitionRotateItem definition)
			: base(owner, definition)
		{
			_definition = definition;
		}

		public override bool IsDefinitionValid()
		{
			return base.Definition is SubGoalDefinitionRotateItem;
		}

		public override void RestoreFromSave()
		{
			base.RestoreFromSave();
			_definition = (SubGoalDefinitionRotateItem)base.Definition;
			if (Owner.State == Objective.ObjectiveState.Active)
			{
				BuildEvents buildEvents = Level.BuildEvents;
				buildEvents.OnRoomItemRotated = (Action<RoomItem>)Delegate.Combine(buildEvents.OnRoomItemRotated, new Action<RoomItem>(OnItemRotated));
			}
		}

		protected override void OnStart()
		{
			base.OnStart();
			BuildEvents buildEvents = Level.BuildEvents;
			buildEvents.OnRoomItemRotated = (Action<RoomItem>)Delegate.Combine(buildEvents.OnRoomItemRotated, new Action<RoomItem>(OnItemRotated));
		}

		protected override void OnEnd()
		{
			BuildEvents buildEvents = Level.BuildEvents;
			buildEvents.OnRoomItemRotated = (Action<RoomItem>)Delegate.Remove(buildEvents.OnRoomItemRotated, new Action<RoomItem>(OnItemRotated));
			base.OnEnd();
		}

		private void OnItemRotated(RoomItem item)
		{
			_rotationsMade++;
			UpdateProgress();
		}

		protected override bool HasCompleted()
		{
			return _rotationsMade >= _definition.RotationsRequired;
		}

		public override float PercentComplete()
		{
			return (float)_rotationsMade / (float)_definition.RotationsRequired;
		}

		public override int Score()
		{
			return _rotationsMade;
		}

		public override string ProgressText()
		{
			if (!Completed())
			{
				return $"{_rotationsMade} / {_definition.RotationsRequired}";
			}
			return ScriptLocalization.Challenges_SubGoals.Done_CS;
		}
	}
}
