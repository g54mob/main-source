using System;
using System.Collections.Generic;

namespace TH20
{
	public class MaintenanceChallengeManager : MustCallDestroy
	{
		private Level _level;

		private ChallengeManager _challengeManager;

		private ChallengeManager.Config _challengeConfig;

		private readonly Dictionary<ChallengeSchedule, List<RoomItemMaintenanceChallengeComponent>> _challengeLookup = new Dictionary<ChallengeSchedule, List<RoomItemMaintenanceChallengeComponent>>();

		public MaintenanceChallengeManager(Level level, ChallengeManager challengeManager, ChallengeManager.Config config)
		{
			_level = level;
			_challengeManager = challengeManager;
			_challengeConfig = config;
			BuildEvents buildEvents = _level.BuildEvents;
			buildEvents.OnRoomItemMaintenanceChallengeThresholdEntered = (Action<RoomItemMaintenanceChallengeComponent>)Delegate.Combine(buildEvents.OnRoomItemMaintenanceChallengeThresholdEntered, new Action<RoomItemMaintenanceChallengeComponent>(OnItemChallengeThresholdEntered));
			BuildEvents buildEvents2 = _level.BuildEvents;
			buildEvents2.OnRoomItemMaintenanceChallengeThresholdExited = (Action<RoomItemMaintenanceChallengeComponent>)Delegate.Combine(buildEvents2.OnRoomItemMaintenanceChallengeThresholdExited, new Action<RoomItemMaintenanceChallengeComponent>(OnItemChallengeThresholdExited));
		}

		public override void RestoreFromSave()
		{
			base.RestoreFromSave();
			BuildEvents buildEvents = _level.BuildEvents;
			buildEvents.OnRoomItemMaintenanceChallengeThresholdEntered = (Action<RoomItemMaintenanceChallengeComponent>)Delegate.Combine(buildEvents.OnRoomItemMaintenanceChallengeThresholdEntered, new Action<RoomItemMaintenanceChallengeComponent>(OnItemChallengeThresholdEntered));
			BuildEvents buildEvents2 = _level.BuildEvents;
			buildEvents2.OnRoomItemMaintenanceChallengeThresholdExited = (Action<RoomItemMaintenanceChallengeComponent>)Delegate.Combine(buildEvents2.OnRoomItemMaintenanceChallengeThresholdExited, new Action<RoomItemMaintenanceChallengeComponent>(OnItemChallengeThresholdExited));
		}

		public override void Destroy()
		{
			base.Destroy();
			BuildEvents buildEvents = _level.BuildEvents;
			buildEvents.OnRoomItemMaintenanceChallengeThresholdEntered = (Action<RoomItemMaintenanceChallengeComponent>)Delegate.Remove(buildEvents.OnRoomItemMaintenanceChallengeThresholdEntered, new Action<RoomItemMaintenanceChallengeComponent>(OnItemChallengeThresholdEntered));
			BuildEvents buildEvents2 = _level.BuildEvents;
			buildEvents2.OnRoomItemMaintenanceChallengeThresholdExited = (Action<RoomItemMaintenanceChallengeComponent>)Delegate.Remove(buildEvents2.OnRoomItemMaintenanceChallengeThresholdExited, new Action<RoomItemMaintenanceChallengeComponent>(OnItemChallengeThresholdExited));
		}

		private void OnItemChallengeThresholdEntered(RoomItemMaintenanceChallengeComponent challengeComponent)
		{
			RegisterComponent(challengeComponent);
		}

		private void OnItemChallengeThresholdExited(RoomItemMaintenanceChallengeComponent challengeComponent)
		{
			UnregisterComponent(challengeComponent);
		}

		private void RegisterComponent(RoomItemMaintenanceChallengeComponent challengeComponent)
		{
			if (!_challengeLookup.TryGetValue(challengeComponent.Schedule, out var value))
			{
				value = new List<RoomItemMaintenanceChallengeComponent>();
				_challengeLookup.Add(challengeComponent.Schedule, value);
			}
			if (value.Count <= 0)
			{
				challengeComponent.Schedule.ResetSchedule();
				challengeComponent.Schedule.IsEnabled = true;
			}
			value.AddUnique(challengeComponent);
		}

		private void UnregisterComponent(RoomItemMaintenanceChallengeComponent challengeComponent)
		{
			if (_challengeLookup.TryGetValue(challengeComponent.Schedule, out var value))
			{
				value.Remove(challengeComponent);
				if (value.Count <= 0)
				{
					challengeComponent.Schedule.IsEnabled = false;
				}
			}
		}
	}
}
