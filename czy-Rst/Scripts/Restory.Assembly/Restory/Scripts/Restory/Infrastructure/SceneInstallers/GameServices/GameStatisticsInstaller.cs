using Restory.Gameplay.Statistics;
using Restory.Infrastructure;
using UnityEngine;
using Zenject;

namespace Restory.Scripts.Restory.Infrastructure.SceneInstallers.GameServices
{
	public class GameStatisticsInstaller : MonoInstaller
	{
		[SerializeField]
		private GameStatisticsService prefab;

		public override void InstallBindings()
		{
			GameObject gameObject = base.Container.InstantiateAndQueueForInject(prefab.gameObject);
			base.Container.Bind<GameStatisticsService>().FromComponentOn(gameObject).AsSingle();
		}
	}
}
