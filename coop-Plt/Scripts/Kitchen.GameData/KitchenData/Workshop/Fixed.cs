using System.Collections.Generic;
using Sirenix.Utilities;

namespace KitchenData.Workshop
{
	public class Fixed : IWorkshopProduct
	{
		public List<Appliance> Results = new List<Appliance>();

		public bool GetResult(List<Appliance> inputs, out Appliance result)
		{
			result = null;
			if (Results.IsNullOrEmpty())
			{
				return false;
			}
			List<Appliance> list = new List<Appliance>(Results);
			list.RemoveAll(inputs.Contains);
			if (list.Count == 0)
			{
				return false;
			}
			result = list.Random();
			return true;
		}
	}
}
