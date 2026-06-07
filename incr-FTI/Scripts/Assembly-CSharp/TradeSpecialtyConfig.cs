public class TradeSpecialtyConfig : AssignableState
{
	public Specialty specialty;

	public Town parentTown;

	public void ConfigureFromStorageValue(int value)
	{
		tradingConfig.InitializeValue((TradeMode)value);
	}

	public int GetStorageValue()
	{
		return (int)tradingConfig.value;
	}
}
