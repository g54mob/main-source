using Restory.Gameplay.Shops.Devices;
using Zenject;

namespace Restory.Infrastructure.SceneInstallers.GameMechanics
{
	public class DeviceLotsRemovalBlockerFromPcVisibilityInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			base.Container.BindInterfacesAndSelfTo<DeviceLotsRemovalBlockerFromPcVisibility>().FromNew().AsSingle();
		}
	}
}
