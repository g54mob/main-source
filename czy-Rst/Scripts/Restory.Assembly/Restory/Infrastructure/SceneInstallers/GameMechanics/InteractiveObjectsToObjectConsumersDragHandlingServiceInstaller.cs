using Restory.Gameplay.Inventory;
using Zenject;

namespace Restory.Infrastructure.SceneInstallers.GameMechanics
{
	public class InteractiveObjectsToObjectConsumersDragHandlingServiceInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			base.Container.Bind<InteractiveObjectsToObjectConsumersDragHandlingService>().FromNew().AsSingle();
		}
	}
}
