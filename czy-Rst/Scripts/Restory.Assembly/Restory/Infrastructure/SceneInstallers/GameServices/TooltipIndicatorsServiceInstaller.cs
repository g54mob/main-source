using Restory.Gameplay.Tooltips;
using Zenject;

namespace Restory.Infrastructure.SceneInstallers.GameServices
{
	public class TooltipIndicatorsServiceInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			base.Container.BindInterfacesAndSelfTo<TooltipIndicatorsService>().FromNew().AsSingle();
		}
	}
}
