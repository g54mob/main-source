using Services.Save.SceneItems;
using Services.Save.SpawnedItems;
using Zenject;

namespace Infrastructure.Installers
{
	public class ConsumablesSaveRegistriesInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			base.Container.BindInterfacesAndSelfTo<SpawnedConsumablesRegistry>().AsSingle();
			base.Container.BindInterfacesAndSelfTo<SceneConsumablesRegistry>().AsSingle();
		}
	}
}
