using System;
using Restory.UI.Presenters.Inventory;
using Restory.UI.Presenters.Inventory.StorageSlotElements;
using Restory.UI.Views.Tooltips;
using Restory.UserInterface.GameplayOverlay;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.SceneInstallers.GameMechanics.Overlay
{
	[Serializable]
	public sealed class InventoryPanelInstaller : Installer
	{
		[SerializeField]
		private GameObject panelPrefab;

		[SerializeField]
		private GameObject slotPrefab;

		[SerializeField]
		private GameObject slotTooltipPrefab;

		public override void InstallBindings()
		{
			base.Container.Bind<InventoryPanel>().FromSubContainerResolve().ByMethod(delegate(DiContainer subContainer)
			{
				subContainer.Bind<InventoryPanel>().FromComponentInNewPrefab(panelPrefab).UnderTransform(GetCanvas)
					.AsSingle()
					.OnInstantiated(delegate(InjectContext c, InventoryPanel i)
					{
						i.Hide();
					});
				subContainer.Bind<StorageSlotElementPool>().FromNew().AsSingle()
					.WithArguments(slotPrefab);
				subContainer.Bind<InventoryItemTooltipViewPool>().FromNew().AsSingle()
					.WithArguments(slotTooltipPrefab);
				subContainer.BindExecutionOrder<InventoryItemTooltipViewPool>(100);
			})
				.AsSingle();
		}

		private Transform GetCanvas(InjectContext c)
		{
			return c.Container.Resolve<GUI_GameplayOverlayCanvas>().transform;
		}
	}
}
