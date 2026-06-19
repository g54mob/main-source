using Services.Save.Boxes;
using Zenject;

namespace Infrastructure.Installers
{
	public class BoxesSaveRegistryInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			base.Container.BindInterfacesAndSelfTo<BoxesSaveRegistry>().FromNew().AsSingle();
		}
	}
}
