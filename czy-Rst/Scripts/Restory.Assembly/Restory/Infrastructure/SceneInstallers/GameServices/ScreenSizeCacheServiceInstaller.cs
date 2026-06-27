using Restory.Gameplay.Common;
using Zenject;

namespace Restory.Infrastructure.SceneInstallers.GameServices
{
	public class ScreenSizeCacheServiceInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			base.Container.BindInterfacesAndSelfTo<ScreenSizeCacheService>().AsSingle();
		}
	}
}
