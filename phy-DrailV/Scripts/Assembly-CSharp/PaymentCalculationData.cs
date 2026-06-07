using System.Collections.Generic;
using DV.ThingTypes;

public class PaymentCalculationData
{
	public Dictionary<TrainCarLivery, int> carsData;

	public Dictionary<CargoType, int> cargoData;

	public PaymentCalculationData(Dictionary<TrainCarLivery, int> carsData, Dictionary<CargoType, int> cargoData)
	{
		this.carsData = carsData;
		this.cargoData = cargoData;
	}
}
