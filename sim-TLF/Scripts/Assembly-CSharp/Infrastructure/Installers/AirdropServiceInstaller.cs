using Items.AirDrop.Services;
using Zenject;

namespace Infrastructure.Installers
{
	public class AirdropServiceInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			base.Container.BindInterfacesAndSelfTo<AirDropService>().FromNew().AsSingle();
		}
	}
}
