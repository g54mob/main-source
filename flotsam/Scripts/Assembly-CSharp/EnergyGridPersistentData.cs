using System;

[Serializable]
public class EnergyGridPersistentData : PersistentReference<EnergyGrid>
{
	public EnergyGridPersistentData(EnergyGrid grid)
		: base(grid)
	{
	}

	public bool TryRestore(out EnergyGrid grid)
	{
		base.Restore();
		base.Instance = new EnergyGrid(this);
		grid = base.Instance;
		return true;
	}
}
