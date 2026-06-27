using System;
using Restory.ObjectPools;
using Restory.UI.Pools;
using Restory.UI.Pools.Shops.Competitions;
using Restory.UI.Pools.Shops.Decors;
using Restory.UI.Pools.Shops.Devices;
using Restory.UI.Pools.Shops.Elements;
using Restory.UI.Pools.WorkshopRatingsApplication;
using Restory.UI.Presenters;
using Restory.UI.Presenters.Shops.Devices;
using Restory.UserInterface.GameplayOverlay;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.SceneInstallers.GameOverlay
{
	[Serializable]
	public sealed class PcScreenWindowInstaller : Installer
	{
		[Header("PC Screen")]
		[SerializeField]
		private GameObject windowsXpScreenPrefab;

		[Header("Browser")]
		[SerializeField]
		private GameObject elementsShopToggleButtonPrefab;

		[SerializeField]
		private GameObject deviceShopToggleButtonPrefab;

		[SerializeField]
		private GameObject decorShopToggleButtonPrefab;

		[Space]
		[Header("ElementsShop")]
		[SerializeField]
		private GameObject gui_LicenseShopItemPrefab;

		[SerializeField]
		private GameObject shopProductCardPrefab;

		[SerializeField]
		private GameObject shoppingCartProductCardPrefab;

		[Space]
		[Header("DeviceShop")]
		[SerializeField]
		private GUI_DeviceShopItem deviceShopItemPrefab;

		[Space]
		[Header("HomeDepotShop")]
		[SerializeField]
		private GameObject decorShopItemPrefab;

		[SerializeField]
		private GameObject cleaningToolShopItemPrefab;

		[SerializeField]
		private GameObject toolMultipleUnitShopItemPrefab;

		[SerializeField]
		private GameObject paintingPaletteShopItemPrefab;

		[SerializeField]
		private GameObject pcAppShopItemPrefab;

		[SerializeField]
		private GameObject decorShopCartPanelItemPrefab;

		[SerializeField]
		private GameObject cleaningToolShopCartPanelItemPrefab;

		[SerializeField]
		private GameObject toolMultipleUnitShopCartPanelItemPrefab;

		[SerializeField]
		private GameObject paintingPaletteShopCartPanelItemPrefab;

		[SerializeField]
		private GameObject pcAppShopCartPanelItemPrefab;

		[SerializeField]
		private GameObject typingLinePrefab;

		[Header("Mail Client")]
		[SerializeField]
		private GameObject mailMessageButtonPrefab;

		[Header("Competitions Application")]
		[SerializeField]
		private GameObject competitionsDeviceProcurementItemPrefab;

		[Header("Workshop Ratings Application")]
		[SerializeField]
		private GameObject workshopRatingsAppReviewItemPrefab;

		public override void InstallBindings()
		{
			InstallWindowsXP();
			InstallBrowser();
			InstallElementsShopPage();
			InstallDeviceShopPage();
			InstallDecorShopPage();
			InstallMailClient();
			InstallCompetitionsApplication();
			InstallWorkshopRatingsApplication();
			InstallTypingLinePool();
		}

		private void InstallWindowsXP()
		{
			base.Container.BindInterfacesAndSelfTo<GUI_PcWindowsXpScreen>().FromComponentInNewPrefab(windowsXpScreenPrefab).UnderTransform(GetCanvas)
				.AsSingle()
				.OnInstantiated(delegate(InjectContext c, GUI_PcWindowsXpScreen i)
				{
					i.Hide();
				});
		}

		private void InstallBrowser()
		{
			base.Container.Bind<ToggleButtonsUiPool>().WithId("ElementsShop").AsTransient()
				.WithArguments(elementsShopToggleButtonPrefab);
			base.Container.Bind<ToggleButtonsUiPool>().WithId("DeviceShop").AsTransient()
				.WithArguments(deviceShopToggleButtonPrefab);
			base.Container.Bind<ToggleButtonsUiPool>().WithId("DecorsShop").AsTransient()
				.WithArguments(decorShopToggleButtonPrefab);
		}

		private void InstallElementsShopPage()
		{
			base.Container.Bind<GUI_ElementsShopElementPool>().AsSingle().WithArguments(shopProductCardPrefab);
			base.Container.BindInterfacesAndSelfTo<GUI_LicenseShopElementCustomPool>().AsSingle();
			base.Container.Bind<ElementsShopCartPanelElementsUiPool>().AsSingle().WithArguments(shoppingCartProductCardPrefab);
		}

		private void InstallDeviceShopPage()
		{
			base.Container.Bind<DeviceShopItemsUiPool>().AsSingle().WithArguments(deviceShopItemPrefab.gameObject);
		}

		private void InstallDecorShopPage()
		{
			base.Container.Bind<GUI_HomeDepotShopDecorItemsPool>().AsSingle().WithArguments(decorShopItemPrefab);
			base.Container.Bind<GUI_HomeDepotShopToolSingleUnitItemsPool>().AsSingle().WithArguments(cleaningToolShopItemPrefab);
			base.Container.Bind<GUI_HomeDepotShopToolMultipleUnitItemsPool>().AsSingle().WithArguments(toolMultipleUnitShopItemPrefab);
			base.Container.Bind<GUI_HomeDepotShopPaintingPaletteItemsPool>().AsSingle().WithArguments(paintingPaletteShopItemPrefab);
			base.Container.Bind<GUI_HomeDepotShopPcAppItemsPool>().AsSingle().WithArguments(pcAppShopItemPrefab);
			base.Container.Bind<GUI_HomeDepotShopCartPanelDecorItemPool>().AsSingle().WithArguments(decorShopCartPanelItemPrefab);
			base.Container.Bind<GUI_HomeDepotShopCartPanelToolSingleUnitItemPool>().AsSingle().WithArguments(cleaningToolShopCartPanelItemPrefab);
			base.Container.Bind<GUI_HomeDepotShopCartPanelToolMultipleUnitItemPool>().AsSingle().WithArguments(toolMultipleUnitShopCartPanelItemPrefab);
			base.Container.Bind<GUI_HomeDepotShopCartPanelPaintingPaletteItemsPool>().AsSingle().WithArguments(paintingPaletteShopCartPanelItemPrefab);
			base.Container.Bind<GUI_HomeDepotShopCartPanelPcAppItemsPool>().AsSingle().WithArguments(pcAppShopCartPanelItemPrefab);
		}

		private void InstallMailClient()
		{
			base.Container.Bind<ConcreteGameObjectPool>().FromNew().AsCached()
				.WithArguments(mailMessageButtonPrefab)
				.WhenInjectedInto<GUI_MailClientEmailButtonsInFolderPanel>();
		}

		private void InstallCompetitionsApplication()
		{
			base.Container.Bind<CompetitionDeviceProcurementItemsUiPool>().FromNew().AsSingle()
				.WithArguments(competitionsDeviceProcurementItemPrefab);
		}

		private void InstallWorkshopRatingsApplication()
		{
			base.Container.Bind<GUI_WorkshopRatingsAppReviewItemsPool>().FromNew().AsSingle()
				.WithArguments(workshopRatingsAppReviewItemPrefab);
		}

		private void InstallTypingLinePool()
		{
			base.Container.Bind<GUI_TypingLinePool>().AsSingle().WithArguments(typingLinePrefab);
		}

		private Transform GetCanvas(InjectContext c)
		{
			return c.Container.Resolve<GUI_GameplayOverlayCanvas>().transform;
		}
	}
}
