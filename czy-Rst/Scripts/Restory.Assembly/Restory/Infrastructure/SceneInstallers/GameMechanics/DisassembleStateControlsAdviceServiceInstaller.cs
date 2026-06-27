using Restory.Gameplay.Workplace;
using Zenject;

namespace Restory.Infrastructure.SceneInstallers.GameMechanics
{
	public class DisassembleStateControlsAdviceServiceInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			base.Container.BindInterfacesAndSelfTo<DisassembleStateControlsAdviceService>().FromNew().AsSingle();
		}
	}
}
