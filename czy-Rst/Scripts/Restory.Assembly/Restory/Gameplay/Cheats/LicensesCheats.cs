using System.ComponentModel;
using Restory.Data.Shops.Elements;
using Restory.Gameplay.Licenses;
using Restory.Gameplay.Shops.Elements;
using UnityEngine;
using UnityEngine.Scripting;
using Zenject;

namespace Restory.Gameplay.Cheats
{
	[Preserve]
	public class LicensesCheats : SRDebugCheatBase
	{
		private readonly LicensesService licensesService;

		private readonly ElementsShopService elementsShopService;

		private const string COMMON_CATEGORY = "Licenses Cheats";

		[Category("Licenses Cheats")]
		[DisplayName("Get All Licenses")]
		public void GetAllLicenses()
		{
			foreach (LicenseShopItemData licenseItem in elementsShopService.LicenseItems)
			{
				licensesService.Add(licenseItem.License);
			}
			Debug.Log("Cheat command: GetAllLicenses success");
		}

		[Inject]
		public LicensesCheats(LicensesService licensesService, ElementsShopService elementsShopService)
		{
			this.licensesService = licensesService;
			this.elementsShopService = elementsShopService;
		}
	}
}
