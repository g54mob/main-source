using Restory.Utils;
using Zenject;

namespace Restory.Infrastructure.ProjectInstallers
{
	public class PromisesErrorHandlerInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			base.Container.BindInterfacesTo<PromisesErrorHandler>().FromNew().AsSingle();
		}
	}
}
