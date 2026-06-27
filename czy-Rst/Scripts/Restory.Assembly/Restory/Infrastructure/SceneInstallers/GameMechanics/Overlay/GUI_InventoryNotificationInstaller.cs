using System;
using Restory.ObjectPools;
using Restory.UI.Presenters.InventoryNotification;
using Restory.UserInterface.GameplayOverlay;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.SceneInstallers.GameMechanics.Overlay
{
	[Serializable]
	public class GUI_InventoryNotificationInstaller : Installer
	{
		[SerializeField]
		private GameObject inventoryNotificationCanvasPrefab;

		[SerializeField]
		private GameObject inventoryNotificationPrefab;

		public override void InstallBindings()
		{
			base.Container.Bind<ConcreteGameObjectPool>().FromNew().WithArguments(inventoryNotificationPrefab)
				.WhenInjectedInto<GUI_InventoryNotificationCanvas>();
			base.Container.Bind<GUI_InventoryNotificationCanvas>().FromComponentInNewPrefab(inventoryNotificationCanvasPrefab).UnderTransform(GetCanvas)
				.AsSingle();
		}

		private Transform GetCanvas(InjectContext c)
		{
			return c.Container.Resolve<GUI_GameplayOverlayCanvas>().transform;
		}
	}
}
