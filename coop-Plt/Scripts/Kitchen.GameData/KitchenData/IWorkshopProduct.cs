using System.Collections.Generic;

namespace KitchenData
{
	public interface IWorkshopProduct
	{
		bool GetResult(List<Appliance> inputs, out Appliance result);
	}
}
