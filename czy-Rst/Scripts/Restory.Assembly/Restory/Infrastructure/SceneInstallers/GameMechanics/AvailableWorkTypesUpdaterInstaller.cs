using Restory.Gameplay.WorkOrders.EmailOrders;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.SceneInstallers.GameMechanics
{
	public class AvailableWorkTypesUpdaterInstaller : MonoInstaller
	{
		[SerializeField]
		private GameObject availableWorkTypesFromToolsUpdaterPrefab;

		public override void InstallBindings()
		{
			GameObject gameObject = base.Container.InstantiateAndQueueForInject(availableWorkTypesFromToolsUpdaterPrefab);
			base.Container.BindInterfacesAndSelfTo<AvailableWorkTypesUpdater>().FromComponentOn(gameObject).AsSingle();
		}
	}
}
