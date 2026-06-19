using Services;
using Services.Save.SceneItems;
using Zenject;

namespace Infrastructure.Installers
{
	public class SceneItemsSaveServiceInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			base.Container.Bind<ISceneItemIdGenerator>().To<SceneItemIdGenerator>().FromNew()
				.AsSingle();
			base.Container.BindInterfacesAndSelfTo<SceneItemsRegistry>().FromNew().AsSingle();
		}
	}
}
