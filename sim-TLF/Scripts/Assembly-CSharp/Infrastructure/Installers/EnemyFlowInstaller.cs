using Services.Enemy;
using Zenject;

namespace Infrastructure.Installers
{
	public class EnemyFlowInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			base.Container.BindInterfacesAndSelfTo<EnemyFlowHandler>().FromNew().AsSingle()
				.NonLazy();
		}
	}
}
