using Restory.Gameplay.Equipment.Ultrasonic;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.SceneInstallers.GameMechanics
{
	public class UltrasonicServiceInstaller : MonoInstaller
	{
		[SerializeField]
		private UltrasonicService ultrasonicServicePrefab;

		public override void InstallBindings()
		{
			InstallSonicBathService();
		}

		private void InstallSonicBathService()
		{
			GameObject gameObject = base.Container.InstantiateAndQueueForInject(ultrasonicServicePrefab.gameObject);
			base.Container.BindInterfacesAndSelfTo<UltrasonicService>().FromComponentOn(gameObject).AsSingle();
		}
	}
}
