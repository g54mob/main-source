using Services.Save.Missions;
using Zenject;

namespace Infrastructure.Installers
{
	public class MissionSaveInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			base.Container.BindInterfacesAndSelfTo<MissionSaveService>().AsSingle().NonLazy();
		}
	}
}
