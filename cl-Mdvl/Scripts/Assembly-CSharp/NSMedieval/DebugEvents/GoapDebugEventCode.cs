namespace NSMedieval.DebugEvents
{
	public enum GoapDebugEventCode
	{
		NONE = 0,
		GoTo_Fail_TargetNotCreature = 1,
		GoTo_Success_TargetCloseEnough = 2,
		GoTo_Fail_TargetNullOrDisposed = 3,
		GoTo_Fail_PathfindingError = 4,
		GoTo_Init = 5,
		TradeGoal_OnSettlerTalkTo = 6,
		ActionNonSuccess = 7,
		ActionSuccess = 8,
		TradeGoal_ShouldFailTrue_MerchantStallInvalid = 9,
		TradeGoal_ShouldFailTrue_TargetInvalid = 10,
		TradeGoal_InitSuccess = 11,
		TradeGoal_InitFail_MerchantStallUnderwater = 12,
		TradeGoal_InitFail_TargetNotTrader = 13,
		TradeGoal_InitFail_NoPreferredReservable = 14,
		DriverQuickUnstuck_Teleport_0 = 15,
		DriverQuickUnstuck_Teleport_1 = 16,
		DriverQuickUnstuck_Teleport_2 = 17,
		DriverQuickUnstuck_Teleport_3 = 18,
		DriverQuickUnstuck_Teleport_4 = 19,
		DriverQuickUnstuck_Teleport_5 = 20,
		DriverQuickUnstuck_Teleport_6 = 21,
		DriverQuickUnstuck_Agent_IsSwimming_True = 22,
		UpdateWaterPosition_0 = 23,
		UpdateWaterPosition_1 = 24
	}
}
