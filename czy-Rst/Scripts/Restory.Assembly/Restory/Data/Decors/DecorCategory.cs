using Restory.Data.Base;
using Restory.Data.Shops;
using UnityEngine;

namespace Restory.Data.Decors
{
	[CreateAssetMenu(menuName = "Restory/Decors/DecorCategory", fileName = "Name - DecorCategory")]
	public class DecorCategory : RestoryEntityInfoBase, IShopCategory
	{
		[SerializeField]
		private Sprite browserIcon;

		[SerializeField]
		private string nameLocalizationKey;

		public Sprite BrowserIcon => browserIcon;

		public string NameLocalizationKey => nameLocalizationKey;
	}
}
