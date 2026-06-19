public enum ChargeAttackInternalState
{
	ChargeAnticipation = 0,
	StartCharging = 1,
	Charging = 2,
	EndOfChargeAnticipation = 3,
	EndOfChargeAttack = 4,
	PendingCollided = 5,
	End = 6,
	LeaveState = 7
}
