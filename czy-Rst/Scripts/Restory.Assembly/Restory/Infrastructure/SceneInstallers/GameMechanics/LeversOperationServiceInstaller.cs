using Restory.Gameplay.Equipment.Levers;
using Zenject;

namespace Restory.Infrastructure.SceneInstallers.GameMechanics
{
	public class LeversOperationServiceInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			base.Container.BindInterfacesAndSelfTo<LeversOperationService>().FromNew().AsSingle();
		}
	}
}
