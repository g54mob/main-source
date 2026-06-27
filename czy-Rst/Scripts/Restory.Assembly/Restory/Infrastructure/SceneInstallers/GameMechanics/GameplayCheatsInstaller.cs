using Restory.Data.GameConfigs;
using Restory.Gameplay.Cheats;
using SRDebugger.Services.Implementation;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.SceneInstallers.GameMechanics
{
	public class GameplayCheatsInstaller : MonoInstaller
	{
		private GameConfig gameConfig;

		[Inject]
		private void Construct(GameConfig gameConfig)
		{
			this.gameConfig = gameConfig;
		}

		public override void InstallBindings()
		{
			if (gameConfig.CheatConsoleSupportedPlatforms.GetSupportedStatus())
			{
				DebugPanelServiceImpl debugPanelService = Object.FindAnyObjectByType<DebugPanelServiceImpl>();
				InstallCheatConsole(debugPanelService);
				InstallDebugPanelObserver(debugPanelService);
			}
		}

		private void InstallCheatConsole(DebugPanelServiceImpl debugPanelService)
		{
			base.Container.BindInterfacesAndSelfTo<WebBrowserCheats>().AsCached();
			base.Container.BindInterfacesAndSelfTo<DeviceCheats>().AsCached();
			base.Container.BindInterfacesAndSelfTo<LicensesCheats>().AsCached();
			base.Container.BindInterfacesAndSelfTo<MoneyCheats>().AsCached();
			base.Container.BindInterfacesAndSelfTo<DisassembleCheats>().AsCached();
			base.Container.BindInterfacesAndSelfTo<SaveGameCheats>().AsCached();
			base.Container.BindInterfacesAndSelfTo<InterfaceCheats>().AsCached();
			base.Container.BindInterfacesAndSelfTo<TimeCheats>().AsCached();
			base.Container.BindInterfacesAndSelfTo<DirtTestingCheats>().AsCached().WithArguments(debugPanelService);
			base.Container.BindInterfacesAndSelfTo<ExceptionAndErrorTestCheats>().AsCached();
			base.Container.BindInterfacesAndSelfTo<OrdersCheats>().AsCached();
			base.Container.BindInterfacesAndSelfTo<RegularPaymentsCheats>().AsCached();
			base.Container.BindInterfacesAndSelfTo<GameVersionCheats>().AsCached();
			base.Container.BindInterfacesAndSelfTo<WorkshopRatingsCheats>().AsCached();
			base.Container.BindInterfacesAndSelfTo<PcAppsCheats>().AsCached();
			base.Container.BindInterfacesAndSelfTo<MetricsCheats>().AsCached();
			base.Container.BindInterfacesAndSelfTo<WorkshopStatusCheats>().AsCached();
		}

		private void InstallDebugPanelObserver(DebugPanelServiceImpl debugPanelService)
		{
			if ((bool)debugPanelService)
			{
				base.Container.BindInterfacesAndSelfTo<DebugPanelObserver>().AsCached().WithArguments(debugPanelService);
			}
		}
	}
}
