using Services.Markers;
using Zenject;

namespace Infrastructure.Installers
{
	public class MarkersSpawnerInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			base.Container.BindInterfacesAndSelfTo<WorldReachMarkerService>().FromNew().AsSingle();
		}
	}
}
