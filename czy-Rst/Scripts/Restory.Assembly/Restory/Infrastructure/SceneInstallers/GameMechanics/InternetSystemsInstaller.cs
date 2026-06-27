using Restory.Gameplay.Internet;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.SceneInstallers.GameMechanics
{
	public class InternetSystemsInstaller : MonoInstaller
	{
		[SerializeField]
		private GameObject prefab;

		public override void InstallBindings()
		{
			GameObject gameObject = base.Container.InstantiateAndQueueForInject(prefab);
			base.Container.Bind<InternetStatusService>().FromComponentOn(gameObject).AsSingle();
		}
	}
}
