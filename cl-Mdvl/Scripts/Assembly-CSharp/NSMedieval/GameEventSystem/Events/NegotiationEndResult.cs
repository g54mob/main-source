namespace NSMedieval.GameEventSystem.Events
{
	public enum NegotiationEndResult
	{
		None = 0,
		FailTimedOut = 1,
		FailPlayerRejected = 2,
		FailNegotiatorAttacked = 3,
		FailNegotiatorKilled = 4,
		Cancelled = 5,
		Success = 6,
		SuccessTraded = 7
	}
}
