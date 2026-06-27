using Restory.Gameplay.RandomBallsPoolSystems.RandomNumbers;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.SceneInstallers.GameServices
{
	public class RandomNumbersServiceInstaller : MonoInstaller
	{
		[SerializeField]
		private RandomNumbersService prefab;

		public override void InstallBindings()
		{
			GameObject gameObject = base.Container.InstantiateAndQueueForInject(prefab.gameObject);
			base.Container.Bind<RandomNumbersService>().FromComponentOn(gameObject).AsSingle();
		}
	}
}
