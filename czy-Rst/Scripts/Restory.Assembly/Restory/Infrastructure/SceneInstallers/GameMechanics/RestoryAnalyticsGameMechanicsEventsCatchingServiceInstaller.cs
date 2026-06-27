using Restory.Data.Analytics;
using Restory.Data.GameConfigs;
using Zenject;

namespace Restory.Infrastructure.SceneInstallers.GameMechanics
{
	public class RestoryAnalyticsGameMechanicsEventsCatchingServiceInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			if (base.Container.Resolve<GameConfig>().AnalyticsSupportedPlatforms.GetSupportedStatus())
			{
				base.Container.BindInterfacesAndSelfTo<RestoryAnalyticsGameMechanicsEventsCatchingService>().FromNew().AsSingle();
			}
		}
	}
}
