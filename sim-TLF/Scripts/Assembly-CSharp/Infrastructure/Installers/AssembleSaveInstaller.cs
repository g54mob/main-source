using Services.Save.Assemble;
using Zenject;

namespace Infrastructure.Installers
{
	public class AssembleSaveInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			base.Container.BindInterfacesAndSelfTo<AssembleSaveRegistry>().AsSingle();
		}
	}
}
