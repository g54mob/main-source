using DG.Tweening;
using Restory.Data.GameConfigs;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.ProjectInstallers
{
	public class GameConfigsInstaller : MonoInstaller
	{
		[SerializeField]
		private GameConfig gameConfig;

		public override void InstallBindings()
		{
			InstallGameConfig();
		}

		private void InstallGameConfig()
		{
			DOTween.SetTweensCapacity(gameConfig.TweenersCapacity, gameConfig.SequencesCapacity);
			base.Container.Bind<GameConfig>().FromInstance(gameConfig).AsSingle();
			Debug.unityLogger.logEnabled = gameConfig.LogConsoleSupportedPlatforms.GetSupportedStatus();
		}
	}
}
