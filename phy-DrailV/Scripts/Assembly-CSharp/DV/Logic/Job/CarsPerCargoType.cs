using System.Collections.Generic;
using DV.ThingTypes;

namespace DV.Logic.Job
{
	public class CarsPerCargoType
	{
		public readonly CargoType cargoType;

		public readonly List<Car> cars;

		public readonly float totalCargoAmount;

		public CarsPerCargoType(CargoType cargoType, List<Car> cars, float totalCargoAmount)
		{
			this.cargoType = cargoType;
			this.cars = cars;
			this.totalCargoAmount = totalCargoAmount;
		}
	}
}
