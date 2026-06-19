using Zenject;

namespace Services.Missions
{
	public class MissionInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			base.Container.Bind<MissionEventBus>().AsSingle();
			base.Container.BindInterfacesTo<MissionService>().AsSingle();
			base.Container.Bind<MissionFactory>().AsSingle();
		}
	}
}
