using Restory.Gameplay;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.SceneInstallers.GameMechanics
{
	public class LightTimeInstaller : MonoInstaller
	{
		[SerializeField]
		private GameObject lightTimeServicePrefab;

		public override void InstallBindings()
		{
			GameObject gameObject = base.Container.InstantiateAndQueueForInject(lightTimeServicePrefab);
			base.Container.BindInterfacesAndSelfTo<LightTimeService>().FromComponentOn(gameObject).AsSingle();
			base.Container.BindInterfacesAndSelfTo<LightEffectsService>().FromComponentOn(gameObject).AsSingle();
		}
	}
}
