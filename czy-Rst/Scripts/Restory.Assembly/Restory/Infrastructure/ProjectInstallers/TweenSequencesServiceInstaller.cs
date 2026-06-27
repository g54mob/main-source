using Restory.Utils;
using Zenject;

namespace Restory.Infrastructure.ProjectInstallers
{
	public class TweenSequencesServiceInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			base.Container.BindInterfacesAndSelfTo<TweenSequencesService>().AsSingle().CopyIntoAllSubContainers();
		}
	}
}
