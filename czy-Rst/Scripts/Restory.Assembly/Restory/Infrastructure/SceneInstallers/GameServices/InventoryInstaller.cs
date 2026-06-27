using Restory.Gameplay.Inventory;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.SceneInstallers.GameServices
{
	public sealed class InventoryInstaller : MonoInstaller
	{
		[SerializeField]
		private Inventory inventoryPrefab;

		public override void InstallBindings()
		{
			InstallInventory();
		}

		private void InstallInventory()
		{
			GameObject gameObject = base.Container.InstantiateAndQueueForInject(inventoryPrefab.gameObject);
			base.Container.BindInterfacesAndSelfTo<Inventory>().FromComponentOn(gameObject).AsSingle();
		}
	}
}
