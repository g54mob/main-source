public class LineOfCreditInstance : OperationInstance
{
	public LineOfCreditInstance(OperationData operation)
		: base(operation)
	{
		Time = 0f;
		Duration = ModifierType.OperationLineOfCreditLoan.Float() * ModifierType.OperationLineOfCreditInterest.Float();
		Database.Commands.Resource.ReceiveMoney(ModifierType.OperationLineOfCreditLoan.Float());
	}

	public LineOfCreditInstance(OperationData operation, float time, float duration)
		: base(operation, time, duration)
	{
	}

	public override void AdvanceTime(float deltaTime)
	{
	}
}
