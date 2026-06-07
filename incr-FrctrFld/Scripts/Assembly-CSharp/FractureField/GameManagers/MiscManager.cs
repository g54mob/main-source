using Reactivity;

namespace FractureField.GameManagers
{
	public class MiscManager : MiscManagerSaveData, ISaveData<MiscManager, MiscManagerSaveData>
	{
		public bool DisableTutorial;

		public bool ForceTutorial;

		private long _lastSecondChanged;

		private long _lastMinuteChanged;

		private long _lastTimeInGame;

		private long _lastPlayerOnline;

		public RBool IsDeveloperMode { get; set; }

		public RLong Timestamp { get; private set; }

		public RLong SecondTimestamp { get; private set; }

		public RTrigger SecondChanged { get; private set; }

		public RLong MinuteTimestamp { get; private set; }

		public RTrigger MinuteChanged { get; private set; }

		public RTrigger CurrentDayChanged { get; }

		private RDateTime CurrentDay { get; }

		public bool PromotionShownThisSession { get; set; }

		public MiscManager Load()
		{
			return null;
		}

		public MiscManagerSaveData Save()
		{
			return null;
		}

		public void Init()
		{
		}

		public void UpdateTick()
		{
		}

		private void CheckTimestamp()
		{
		}

		private void CheckSecondChanged()
		{
		}

		private void CheckMinuteChanged()
		{
		}

		private void CheckCurrentDayChanged()
		{
		}

		private void UpdateTimeInGame()
		{
		}

		private void CheckPlayerOnline()
		{
		}
	}
}
