using System;

namespace TH20
{
	public class ChallengeEco : Challenge
	{
		private readonly ChallengeEcoConfig _config;

		private float _currentEcoRating;

		public float GetCurrentEcoRating()
		{
			return (float)MathUtils.Clamp(_currentEcoRating, _config.EcoRatingMinValue, _config.EcoRatingMaxValue);
		}

		public ChallengeEco(ChallengeConfig definition, Level level)
			: base(definition, level)
		{
			_config = GetConfig<ChallengeEcoConfig>();
			foreach (Room allRoom in level.WorldState.AllRooms)
			{
				if (allRoom.Definition.IsHospitalUnbuilt)
				{
					continue;
				}
				foreach (RoomItem item in allRoom.FloorPlan.Items)
				{
					OnRoomItemAdded(item, allRoom.FloorPlan);
				}
			}
		}

		public override void RestoreFromSave()
		{
			base.RestoreFromSave();
			if (base.ChallengeStatus == ChallengeState.InProgress)
			{
				RegisterEvents();
			}
		}

		protected override void OnChallengeStarted()
		{
			base.OnChallengeStarted();
			RegisterEvents();
		}

		protected override void OnChallengeFinished()
		{
			UnregisterEvents();
			base.OnChallengeFinished();
		}

		private void RegisterEvents()
		{
			BuildEvents buildEvents = base.Level.BuildEvents;
			buildEvents.OnRoomItemAdded = (Action<RoomItem, FloorPlan>)Delegate.Combine(buildEvents.OnRoomItemAdded, new Action<RoomItem, FloorPlan>(OnRoomItemAdded));
			BuildEvents buildEvents2 = base.Level.BuildEvents;
			buildEvents2.OnRoomItemRemoved = (Action<RoomItem, FloorPlan>)Delegate.Combine(buildEvents2.OnRoomItemRemoved, new Action<RoomItem, FloorPlan>(OnRoomItemRemoved));
		}

		private void UnregisterEvents()
		{
			BuildEvents buildEvents = base.Level.BuildEvents;
			buildEvents.OnRoomItemAdded = (Action<RoomItem, FloorPlan>)Delegate.Remove(buildEvents.OnRoomItemAdded, new Action<RoomItem, FloorPlan>(OnRoomItemAdded));
			BuildEvents buildEvents2 = base.Level.BuildEvents;
			buildEvents2.OnRoomItemRemoved = (Action<RoomItem, FloorPlan>)Delegate.Remove(buildEvents2.OnRoomItemRemoved, new Action<RoomItem, FloorPlan>(OnRoomItemRemoved));
		}

		private void OnRoomItemAdded(RoomItem item, FloorPlan floorPlan)
		{
			_currentEcoRating += item.Definition.EcoRatingModifier;
		}

		private void OnRoomItemRemoved(RoomItem item, FloorPlan floorPlan)
		{
			_currentEcoRating -= item.Definition.EcoRatingModifier;
		}

		protected override int CalculateChallengeScore()
		{
			return 0;
		}

		public override void Destroy()
		{
			UnregisterEvents();
			base.Destroy();
		}
	}
}
