using Restory.Data.GameConfigs;
using SRF;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.ProjectInstallers
{
	public class CheatConsoleInstaller : MonoInstaller
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
				SRDebug.Init();
				return;
			}
			Transform transform = Hierarchy.Get("SRDebugger");
			if (transform != null)
			{
				Object.DontDestroyOnLoad(transform);
				transform.gameObject.SetActive(value: false);
			}
		}
	}
}
