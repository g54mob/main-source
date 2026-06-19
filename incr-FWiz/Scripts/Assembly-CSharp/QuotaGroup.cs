using System;
using System.Collections.Generic;
using OUSystems.Basics.DataStructures;

[Serializable]
public class QuotaGroup : ItemInputGroup<QuotaItemStack>
{
	public IntContainer Multiples { get; private set; }

	public QuotaGroup(List<CostStack> costStacks, int maximum)
	{
	}

	public void Prepare(int capacity)
	{
	}

	public override void Prepare()
	{
	}

	public void SpendDemand()
	{
	}

	public void SetCapacity(int capacity)
	{
	}

	protected override void Evaluate()
	{
	}
}
