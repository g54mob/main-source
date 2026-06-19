using Services.Save.Delivery;
using Zenject;

namespace Infrastructure.Installers
{
	public class DeliverySaverInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			base.Container.BindInterfacesAndSelfTo<DeliverySaveService>().AsSingle();
		}
	}
}
