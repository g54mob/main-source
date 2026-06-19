using System;
using I2.Loc;
using UnityEngine;

namespace TH20
{
	public class MetagameSubGoalUpgradeItem : MetagameObjectiveSubGoal
	{
		[SerializeField]
		private readonly MetagameSubGoalDefinitionUpgradeItem _definition;

		[SerializeField]
		private int _currentCount;

		public MetagameSubGoalUpgradeItem(Objective owner, MetagameSubGoalDefinitionUpgradeItem definition)
			: base(owner, definition)
		{
			_definition = definition;
		}

		protected override void OnStart()
		{
			if (Metagame != null)
			{
				LevelEventsIntermediary levelEventsIntermediary = Metagame.LevelEventsIntermediary;
				levelEventsIntermediary.OnRoomItemUpgradeComplete = (Action<RoomItem, Staff>)Delegate.Combine(levelEventsIntermediary.OnRoomItemUpgradeComplete, new Action<RoomItem, Staff>(OnItemUpgradeComplete));
			}
			base.OnStart();
		}

		protected override void OnMetagameChanged(Metagame oldMetagame, Metagame newMetagame)
		{
			if (oldMetagame != null)
			{
				LevelEventsIntermediary levelEventsIntermediary = oldMetagame.LevelEventsIntermediary;
				levelEventsIntermediary.OnRoomItemUpgradeComplete = (Action<RoomItem, Staff>)Delegate.Remove(levelEventsIntermediary.OnRoomItemUpgradeComplete, new Action<RoomItem, Staff>(OnItemUpgradeComplete));
			}
			if (newMetagame != null)
			{
				LevelEventsIntermediary levelEventsIntermediary2 = newMetagame.LevelEventsIntermediary;
				levelEventsIntermediary2.OnRoomItemUpgradeComplete = (Action<RoomItem, Staff>)Delegate.Combine(levelEventsIntermediary2.OnRoomItemUpgradeComplete, new Action<RoomItem, Staff>(OnItemUpgradeComplete));
			}
		}

		public override void Destroy()
		{
			if (Metagame != null)
			{
				LevelEventsIntermediary levelEventsIntermediary = Metagame.LevelEventsIntermediary;
				levelEventsIntermediary.OnRoomItemUpgradeComplete = (Action<RoomItem, Staff>)Delegate.Remove(levelEventsIntermediary.OnRoomItemUpgradeComplete, new Action<RoomItem, Staff>(OnItemUpgradeComplete));
			}
			base.Destroy();
		}

		private void OnItemUpgradeComplete(RoomItem roomItem, Staff staff)
		{
			_currentCount++;
			UpdateProgress();
			PlatformStatsAndAchievements.SetStatValue(Stat.MachinesUpgraded, _currentCount);
		}

		protected override bool HasCompleted()
		{
			return _currentCount >= _definition.Count;
		}

		public override float PercentComplete()
		{
			return (float)_currentCount / (float)_definition.Count;
		}

		public override int Score()
		{
			return _currentCount;
		}

		public override string ProgressText()
		{
			if (!Completed())
			{
				return $"{_currentCount} / {_definition.Count}";
			}
			return ScriptLocalization.Challenges_SubGoals.Done_CS;
		}
	}
}
