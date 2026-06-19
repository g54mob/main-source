using System;

[Serializable]
public class PaymentItemStack : ItemInputStack
{
	public override int Maximum => 0;

	public PaymentItemStack(ItemType type, int desiredCount, int count = 0)
		: base(null, 0)
	{
	}

	public PaymentItemStack(CostStack costStack)
		: base(null, 0)
	{
	}
}
