using Restory.Gameplay.InventoryNotification;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.SceneInstallers.GameMechanics
{
	public class InventoryNotificationInstaller : MonoInstaller
	{
		[SerializeField]
		private GameObject inventoryNotificationServicePrefab;

		public override void InstallBindings()
		{
			GameObject gameObject = base.Container.InstantiateAndQueueForInject(inventoryNotificationServicePrefab);
			base.Container.BindInterfacesAndSelfTo<InventoryNotificationService>().FromComponentOn(gameObject).AsSingle();
		}
	}
}
