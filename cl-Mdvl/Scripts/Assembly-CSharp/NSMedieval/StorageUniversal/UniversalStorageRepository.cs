using NSEipix.Repository;

namespace NSMedieval.StorageUniversal
{
	public class UniversalStorageRepository : DynamicJsonRepository<UniversalStorageRepository, UniversalStorageBlueprint>
	{
		protected override string JsonFile()
		{
			return "Constructables/UniversalStorage.json";
		}
	}
}
