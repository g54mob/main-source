using Restory.Gameplay.Tooltips;
using Zenject;

namespace Restory.Infrastructure.SceneInstallers.GameMechanics
{
	public class CommonTooltipServiceInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			InstallCommonTooltipPool();
			InstallCommonTooltipService();
		}

		private void InstallCommonTooltipPool()
		{
			base.Container.BindInterfacesAndSelfTo<CommonTooltipCustomPool>().FromNew().AsSingle();
		}

		private void InstallCommonTooltipService()
		{
			base.Container.BindInterfacesAndSelfTo<CommonTooltipService>().FromNew().AsSingle();
		}
	}
}
