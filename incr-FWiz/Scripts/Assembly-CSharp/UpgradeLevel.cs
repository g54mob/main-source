using System;
using System.Collections.Generic;

[Serializable]
public class UpgradeLevel
{
	public List<CostStack> Costs;

	public bool DemoLocked => false;

	public bool IngredientsDiscovered => false;
}
