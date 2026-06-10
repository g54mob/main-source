using NSEipix.Repository;

namespace NSMedieval.Almanac
{
	public class AlmanacRepository : DynamicJsonRepository<AlmanacRepository, Almanac>
	{
		protected override string JsonFile()
		{
			return "Almanac/Almanac.json";
		}
	}
}
