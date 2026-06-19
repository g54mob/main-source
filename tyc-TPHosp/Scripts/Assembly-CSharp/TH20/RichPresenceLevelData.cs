namespace TH20
{
	public readonly struct RichPresenceLevelData
	{
		public readonly string CurrentLevelID;

		public readonly int CurrentMoneyInLevel;

		public readonly float CurrentReputationInLevel;

		public readonly float CurrentStaffMoraleInLevel;

		public RichPresenceLevelData(string currentLevelID, int currentMoneyInLevel, float currentReputationInLevel, float currentStaffMoraleInLevel)
		{
			CurrentLevelID = currentLevelID;
			CurrentMoneyInLevel = currentMoneyInLevel;
			CurrentReputationInLevel = currentReputationInLevel;
			CurrentStaffMoraleInLevel = currentStaffMoraleInLevel;
		}
	}
}
