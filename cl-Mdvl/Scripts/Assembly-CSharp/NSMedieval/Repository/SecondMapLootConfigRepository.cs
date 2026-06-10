using NSEipix;
using NSEipix.Repository;
using NSMedieval.Model.SecondMap;

namespace NSMedieval.Repository
{
	public class SecondMapLootConfigRepository : DynamicJsonRepository<SecondMapLootConfigRepository, SecondMapLootConfig>
	{
		protected override string JsonFile()
		{
			return "SecondMap/SecondMapLootConfigs.json";
		}

		public SecondMapLootConfig GetRandom()
		{
			return base.AllItems.PickRandom();
		}
	}
}
