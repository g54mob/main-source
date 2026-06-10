using NSEipix.Repository;

namespace NSMedieval.Crops
{
	public class CropfieldRepository : DynamicJsonRepository<CropfieldRepository, Cropfield>
	{
		protected override string JsonFile()
		{
			return "Cropfields/Cropfields.json";
		}
	}
}
