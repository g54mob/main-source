using Services.Enemy;
using Zenject;

namespace Infrastructure.Installers
{
	public class EnemyMailHandlerInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			base.Container.Bind<EnemyMailHandler>().AsSingle().NonLazy();
		}
	}
}
