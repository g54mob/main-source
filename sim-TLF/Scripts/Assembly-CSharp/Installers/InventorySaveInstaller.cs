using Services.Save.Inventory;
using UnityEngine;
using Zenject;

namespace Installers
{
	public class InventorySaveInstaller : MonoInstaller
	{
		[SerializeField]
		private Transform _playerTransform;

		public override void InstallBindings()
		{
			base.Container.Bind<InventorySaveService>().AsSingle().WithArguments(_playerTransform);
			base.Container.BindInterfacesTo<InventorySaveService>().FromResolve();
		}
	}
}
