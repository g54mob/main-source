using DV.ThingTypes;

public class CarGuidsPerCargo
{
	public CargoType cargo;

	public string[] carGuids;

	public float totalCargoAmount;

	public CarGuidsPerCargo(CargoType cargo, string[] carGuids, float totalCargoAmount)
	{
		this.cargo = cargo;
		this.carGuids = carGuids;
		this.totalCargoAmount = totalCargoAmount;
	}
}
