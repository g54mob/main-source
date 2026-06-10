using System.Linq;
using NSEipix.Repository;
using NSMedieval.GameEventSystem;

namespace NSMedieval.Weather
{
	public class DaysFromStartMultipliersRepository : DynamicJsonRepository<DaysFromStartMultipliersRepository, DaysFromStartMultipliers>
	{
		public DaysFromStartMultipliers GetByIndex(int index)
		{
			if (index >= base.AllItems.Count())
			{
				index = base.AllItems.Count() - 1;
			}
			return base.AllItems.ToArray()[index];
		}

		protected override string JsonFile()
		{
			return "Data/DaysFromStartMultipliers.json";
		}
	}
}
