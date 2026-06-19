using Services.Preload;
using Zenject;

namespace Infrastructure.Installers
{
	public class PreloaderInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			base.Container.BindInterfacesAndSelfTo<AddressablePreloader>().AsSingle().NonLazy();
		}
	}
}
