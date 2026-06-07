namespace AwesomeTechnologies.Vegetation.PersistentStorage
{
	public class PersistentVegetationStorageTools
	{
		public static string GetSourceName(byte vegetationSourceID)
		{
			switch (vegetationSourceID)
			{
			case 0:
				return "Vegetation Studio - Baked vegetation";
			case 1:
				return "Vegetation Studio - Manual edited";
			case 2:
				return "Terrain tree importer";
			case 3:
				return "Scene object importer";
			case 4:
				return "Terrain detail importer";
			case 5:
				return "Vegetation Studio - Painted";
			case 10:
				return "Gaia";
			case 11:
				return "GeNa";
			case 12:
				return "Sentieri";
			case 13:
				return "TC2 Node Painter";
			case 14:
				return "TC2";
			case 15:
				return "MapMagic";
			case 16:
				return "Origami";
			case 17:
				return "Landscape Builder";
			case 18:
				return "Voxeland";
			case 19:
				return "YAPP";
			case 20:
				return "Polaris";
			default:
				return "Source_" + vegetationSourceID;
			}
		}
	}
}
