namespace Restory.Gameplay.Shredders
{
	public readonly struct ShredderRewardResult
	{
		public int AwardedAmount { get; }

		public bool IsCriticalSuccess { get; }

		public bool IsZeroedOut { get; }

		public ShredderRewardResult(int awardedAmount, bool isCriticalSuccess, bool isZeroedOut)
		{
			AwardedAmount = awardedAmount;
			IsCriticalSuccess = isCriticalSuccess;
			IsZeroedOut = isZeroedOut;
		}
	}
}
