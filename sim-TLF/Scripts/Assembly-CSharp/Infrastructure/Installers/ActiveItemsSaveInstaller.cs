using Services.Save.ActiveItems;
using Zenject;

namespace Infrastructure.Installers
{
	public class ActiveItemsSaveInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			base.Container.BindInterfacesAndSelfTo<ActiveItemsSaveRegistry>().AsSingle();
		}
	}
}
