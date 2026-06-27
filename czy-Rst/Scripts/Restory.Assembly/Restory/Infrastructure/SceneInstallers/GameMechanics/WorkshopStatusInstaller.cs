using Restory.Gameplay.WorkshopStatus;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.SceneInstallers.GameMechanics
{
	public class WorkshopStatusInstaller : MonoInstaller
	{
		[SerializeField]
		private GameObject workshopStatusServicePrefab;

		public override void InstallBindings()
		{
			GameObject gameObject = base.Container.InstantiateAndQueueForInject(workshopStatusServicePrefab);
			base.Container.BindInterfacesAndSelfTo<WorkshopStatusService>().FromComponentOn(gameObject).AsSingle();
			base.Container.BindInterfacesAndSelfTo<WorkshopStatusNotificationService>().FromComponentOn(gameObject).AsSingle();
			WorkshopStatusEvaluatorBase[] componentsInChildren = gameObject.GetComponentsInChildren<WorkshopStatusEvaluatorBase>();
			foreach (WorkshopStatusEvaluatorBase workshopStatusEvaluatorBase in componentsInChildren)
			{
				base.Container.BindInterfacesTo(workshopStatusEvaluatorBase.GetType()).FromInstance(workshopStatusEvaluatorBase).AsSingle();
			}
		}
	}
}
