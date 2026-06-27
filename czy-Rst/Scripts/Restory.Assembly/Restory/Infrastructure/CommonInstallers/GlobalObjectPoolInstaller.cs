using Restory.ObjectPools;
using Zenject;

namespace Restory.Infrastructure.CommonInstallers
{
	public class GlobalObjectPoolInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			base.Container.BindInterfacesAndSelfTo<GlobalObjectPool>().AsSingle().Lazy();
			base.Container.BindInterfacesAndSelfTo<ConcreteGameObjectPoolFactory>().FromNew().AsSingle();
			base.Container.BindInterfacesAndSelfTo<GameObjectPoolFactory>().FromNew().AsSingle();
			base.Container.BindInterfacesAndSelfTo<UIGameObjectPoolFactory>().FromNew().AsSingle();
		}
	}
}
