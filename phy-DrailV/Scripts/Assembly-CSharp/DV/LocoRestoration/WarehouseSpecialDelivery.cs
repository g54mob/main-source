using System;
using System.Collections.Generic;
using DV.Logic.Job;
using DV.ThingTypes;

namespace DV.LocoRestoration
{
	public class WarehouseSpecialDelivery
	{
		public string id;

		public List<CargoType_v2> cargoToProcess;

		public WarehouseTaskType deliveryType;

		[NonSerialized]
		public List<Car> reservedCarsOnTrack;

		public event Action<List<Car>> Processed;

		public WarehouseSpecialDelivery(string id, List<CargoType_v2> cargoToProcess, WarehouseTaskType deliveryType)
		{
			this.id = id;
			this.cargoToProcess = cargoToProcess;
			this.deliveryType = deliveryType;
		}

		public void FireProcessed()
		{
			this.Processed?.Invoke(reservedCarsOnTrack);
		}
	}
}
