using System.Collections.Generic;
using System.Linq;
using NSMedieval.BuildingComponents;

namespace NSMedieval.UI
{
	public class InfoPanelFuelConsumer : SelectionExtraView
	{
		public List<FuelConsumerComponentInstance> FuelConsumerComponentInstances { get; }

		public bool AnyHasDisposed => FuelConsumerComponentInstances.Any((FuelConsumerComponentInstance fci) => fci.HasDisposed);

		public InfoPanelFuelConsumer(FuelConsumerComponentInstance fuelConsumerComponentInstance)
		{
			FuelConsumerComponentInstances = new List<FuelConsumerComponentInstance> { fuelConsumerComponentInstance };
		}

		public InfoPanelFuelConsumer(List<FuelConsumerComponentInstance> fuelConsumerComponentInstances)
		{
			FuelConsumerComponentInstances = fuelConsumerComponentInstances;
		}
	}
}
