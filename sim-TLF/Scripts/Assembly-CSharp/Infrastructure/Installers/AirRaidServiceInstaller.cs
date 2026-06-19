using Services.Enemy;
using Zenject;

namespace Infrastructure.Installers
{
	public class AirRaidServiceInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			base.Container.Bind<IAirRaidService>().To<AirRaidService>().FromNew()
				.AsSingle();
		}
	}
}
