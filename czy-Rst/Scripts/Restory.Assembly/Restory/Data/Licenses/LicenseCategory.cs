using Restory.Data.Base;
using UnityEngine;

namespace Restory.Data.Licenses
{
	[CreateAssetMenu(menuName = "Restory/Licenses/LicenseCategory", fileName = "Name - LicenseCategory")]
	public class LicenseCategory : RestoryEntityInfoBase
	{
		[SerializeField]
		private Sprite browserIcon;

		[SerializeField]
		private string nameLocalizationKey;

		public Sprite BrowserIcon => browserIcon;

		public string NameLocalizationKey => nameLocalizationKey;
	}
}
