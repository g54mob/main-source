using Restory.Infrastructure.ProjectServices;
using Zenject;

namespace Restory.Infrastructure.ProjectInstallers
{
	public class CleanupBeforeSceneUnloadServiceInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			base.Container.Bind<CleanupBeforeSceneUnloadService>().FromNew().AsSingle();
		}
	}
}
