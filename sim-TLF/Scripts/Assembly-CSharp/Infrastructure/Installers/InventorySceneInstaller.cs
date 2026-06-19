using UI.Inventory;
using UnityEngine;
using Zenject;

namespace Infrastructure.Installers
{
	public class InventorySceneInstaller : MonoInstaller
	{
		[SerializeField]
		private InventoryUIService _inventoryUIService;

		public override void InstallBindings()
		{
			BindInventoryService();
		}

		private void BindInventoryService()
		{
			base.Container.BindInterfacesAndSelfTo<InventoryUIService>().FromInstance(_inventoryUIService).AsSingle();
		}
	}
}
