using NSEipix.Repository;
using NSMedieval.UI;

namespace NSMedieval.Almanac
{
	public class DifficultyOptionsRepository : DynamicJsonRepository<DifficultyOptionsRepository, DifficultyOption>
	{
		protected override string JsonFile()
		{
			return "Data/DifficultyOptions.json";
		}
	}
}
