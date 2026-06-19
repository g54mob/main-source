using Services.Save.SpawnedItems;
using Zenject;

namespace Infrastructure.Installers
{
	public class SpawnedItemsSaveServiceInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			base.Container.BindInterfacesAndSelfTo<SpawnedItemsRegistry>().FromNew().AsSingle();
		}
	}
}
