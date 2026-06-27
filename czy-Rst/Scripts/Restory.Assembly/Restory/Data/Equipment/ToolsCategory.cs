using Restory.Data.Base;
using Restory.Data.Devices;
using Restory.Data.Shops;
using UnityEngine;

namespace Restory.Data.Equipment
{
	[CreateAssetMenu(menuName = "Restory/Equipment/ToolsCategory", fileName = "Name - ToolsCategory")]
	public class ToolsCategory : RestoryEntityInfoBase, IDeviceCategory, IShopCategory
	{
		[SerializeField]
		private Sprite browserIcon;

		[SerializeField]
		private string nameLocalizationKey;

		public Sprite BrowserIcon => browserIcon;

		public string NameLocalizationKey => nameLocalizationKey;
	}
}
