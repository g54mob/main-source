using NSMedieval.Crops;

namespace NSMedieval.UI
{
	public class InfoPanelCropfield : SelectionExtraView
	{
		private CropfieldInstance cropfieldInstance;

		public CropfieldInstance CropfieldInstance => cropfieldInstance;

		public InfoPanelCropfield(CropfieldInstance cropfield)
		{
			cropfieldInstance = cropfield;
		}
	}
}
