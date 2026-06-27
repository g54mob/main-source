using Restory.Data.Tooltips;
using Restory.Gameplay.Tooltips;
using Restory.Infrastructure.SceneInstallers.GameOverlay;
using Restory.UI.Views.Tooltips;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.SceneInstallers.GameMechanics.Overlay
{
	public sealed class OverlayInstaller : MonoInstaller
	{
		[SerializeField]
		private TooltipContainerInstaller tooltipContainerInstaller;

		[SerializeField]
		private InventoryPanelInstaller inventoryPanelInstaller;

		[SerializeField]
		private NotepadWindowInstaller notepadWindowInstaller;

		[SerializeField]
		private PcScreenWindowInstaller pcScreenWindowInstaller;

		[SerializeField]
		private DialogueCanvasInstaller dialogueCanvasInstaller;

		[SerializeField]
		private DaySwitchFadeScreensInstaller daySwitchFadeScreensInstaller;

		[SerializeField]
		private GUI_ToDoListWindowInstaller toDoListWindowInstaller;

		[SerializeField]
		private CleaningToolsSelectionWindowInstaller cleaningToolsSelectionWindowInstaller;

		[SerializeField]
		private DevicePainterPanelInstaller devicePainterPanelInstaller;

		[SerializeField]
		private DeliveryPackTooltipsSettings deliveryPackTooltipsSettings;

		[SerializeField]
		private WarningTooltipsSettings warningTooltipsSettings;

		[SerializeField]
		private RegularPaymentObjectTooltipsSettings regularPaymentObjectTooltipsSettings;

		[SerializeField]
		private GUI_WarningTooltip uniqueDeviceTooltipPrefab;

		[SerializeField]
		private GUI_AnotherDeviceFromSameOrderIsPackedForShipmentTooltip anotherDeviceFromSameOrderInShipmentTooltipPrefab;

		[SerializeField]
		private GUI_CashMoneyObjectTooltip cashMoneyObjectTooltipPrefab;

		[SerializeField]
		private GUI_RegularPaymentObjectTooltip regularPaymentObjectTooltipPrefab;

		[SerializeField]
		private GUI_MetricsInstaller ratingsInstaller;

		[SerializeField]
		private GUI_InventoryNotificationInstaller inventoryNotificationInstaller;

		[SerializeField]
		private RegularPaymentInstaller regularPaymentInstaller;

		public override void InstallBindings()
		{
			base.Container.Inject(tooltipContainerInstaller);
			tooltipContainerInstaller.InstallBindings();
			base.Container.Inject(inventoryPanelInstaller);
			inventoryPanelInstaller.InstallBindings();
			base.Container.Inject(notepadWindowInstaller);
			notepadWindowInstaller.InstallBindings();
			base.Container.Inject(pcScreenWindowInstaller);
			pcScreenWindowInstaller.InstallBindings();
			base.Container.Inject(dialogueCanvasInstaller);
			dialogueCanvasInstaller.InstallBindings();
			base.Container.Inject(daySwitchFadeScreensInstaller);
			daySwitchFadeScreensInstaller.InstallBindings();
			base.Container.Inject(cleaningToolsSelectionWindowInstaller);
			cleaningToolsSelectionWindowInstaller.InstallBindings();
			base.Container.Inject(devicePainterPanelInstaller);
			devicePainterPanelInstaller.InstallBindings();
			base.Container.Inject(toDoListWindowInstaller);
			toDoListWindowInstaller.InstallBindings();
			base.Container.Inject(ratingsInstaller);
			ratingsInstaller.InstallBindings();
			base.Container.Inject(inventoryNotificationInstaller);
			inventoryNotificationInstaller.InstallBindings();
			base.Container.Inject(regularPaymentInstaller);
			regularPaymentInstaller.InstallBindings();
			base.Container.Bind<DeliveryBoxMainTooltipViewPool>().FromNew().AsSingle()
				.WithArguments(deliveryPackTooltipsSettings.DeliveryBoxMainTooltipPrefab)
				.WhenInjectedInto<InteractiveObjectsTooltipsService>();
			base.Container.Bind<DeliveryBoxInitialTooltipViewPool>().FromNew().AsSingle()
				.WithArguments(deliveryPackTooltipsSettings.DeliveryBoxInitialTooltipPrefab)
				.WhenInjectedInto<InteractiveObjectsTooltipsService>();
			base.Container.Bind<WarningTooltipViewPool>().FromNew().AsSingle()
				.WithArguments(uniqueDeviceTooltipPrefab.gameObject)
				.WhenInjectedInto<InteractiveObjectsTooltipsService>();
			base.Container.Bind<AnotherDeviceFromSameOrderInShipmentTooltipViewPool>().FromNew().AsSingle()
				.WithArguments(anotherDeviceFromSameOrderInShipmentTooltipPrefab.gameObject)
				.WhenInjectedInto<InteractiveObjectsTooltipsService>();
			base.Container.Bind<MoneyObjectTooltipViewPool>().FromNew().AsSingle()
				.WithArguments(cashMoneyObjectTooltipPrefab.gameObject)
				.WhenInjectedInto<InteractiveObjectsTooltipsService>();
			base.Container.Bind<RegularPaymentObjectTooltipViewPool>().FromNew().AsSingle()
				.WithArguments(regularPaymentObjectTooltipPrefab.gameObject)
				.WhenInjectedInto<InteractiveObjectsTooltipsService>();
			base.Container.Bind<RegularPaymentObjectTooltipsSettings>().FromInstance(regularPaymentObjectTooltipsSettings).AsSingle()
				.WhenInjectedInto<InteractiveObjectsTooltipsService>();
			base.Container.Bind<InteractiveObjectsTooltipsService>().FromNew().AsSingle()
				.WithArguments(deliveryPackTooltipsSettings, warningTooltipsSettings);
		}
	}
}
