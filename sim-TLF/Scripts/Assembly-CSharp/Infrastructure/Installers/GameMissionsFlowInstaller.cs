using Services.Missions.Flow;
using Zenject;

namespace Infrastructure.Installers
{
	public class GameMissionsFlowInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			base.Container.BindInterfacesAndSelfTo<MissionsFlowHandler>().FromNew().AsSingle();
		}
	}
}
