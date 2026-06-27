using Restory.Gameplay.DetectableObjects;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.SceneInstallers.GameMechanics
{
	public class DetectableObjectServicesInstaller : MonoInstaller
	{
		[SerializeField]
		private DetectableObjectService detectableObjectServicePrefab;

		public override void InstallBindings()
		{
			InstallDetectableObjectService();
		}

		private void InstallDetectableObjectService()
		{
			GameObject gameObject = base.Container.InstantiateAndQueueForInject(detectableObjectServicePrefab.gameObject);
			base.Container.BindInterfacesAndSelfTo<DetectableObjectService>().FromComponentOn(gameObject).AsSingle();
		}
	}
}
