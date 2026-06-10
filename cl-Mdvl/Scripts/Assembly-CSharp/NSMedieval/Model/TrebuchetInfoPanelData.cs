using NSMedieval.BuildingComponents;
using NSMedieval.UI;

namespace NSMedieval.Model
{
	public class TrebuchetInfoPanelData : InfoPanelData
	{
		private SiegeWeaponComponentInstance siegeWeaponComponentInstance;

		public SiegeWeaponComponentInstance SiegeWeaponComponentInstance => siegeWeaponComponentInstance;

		public TrebuchetInfoPanelData(SiegeWeaponComponentInstance siegeWeaponComponentInstance, InfoPanelHeader header, InfoPanelBody body, InfoPanelFooter footer, SelectionExtraView extraPanelView = null)
			: base(InfoPanelDataType.General, header, body, footer, extraPanelView)
		{
			this.siegeWeaponComponentInstance = siegeWeaponComponentInstance;
		}
	}
}
