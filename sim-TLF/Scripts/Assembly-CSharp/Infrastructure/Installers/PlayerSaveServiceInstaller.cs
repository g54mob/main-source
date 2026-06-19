using Services.Save.Player;
using Zenject;

namespace Infrastructure.Installers
{
	public class PlayerSaveServiceInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			base.Container.BindInterfacesAndSelfTo<PlayerSaveService>().FromNew().AsSingle();
		}
	}
}
