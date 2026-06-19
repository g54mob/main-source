using Services.Missions.Flow;
using Zenject;

namespace Infrastructure.Installers
{
	public class MissionPresetServiceInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			base.Container.Bind<MissionsPresetsService>().FromNew().AsSingle();
		}
	}
}
