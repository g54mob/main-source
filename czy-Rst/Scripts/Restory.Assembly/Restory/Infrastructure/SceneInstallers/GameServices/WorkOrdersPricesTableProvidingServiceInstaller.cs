using Restory.Data.Money;
using Restory.Gameplay.WorkOrders;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.SceneInstallers.GameServices
{
	public class WorkOrdersPricesTableProvidingServiceInstaller : MonoInstaller
	{
		[SerializeField]
		private WorkOrdersPricesTable table;

		public override void InstallBindings()
		{
			base.Container.Bind<WorkOrdersPricesTableProvidingService>().FromNew().AsSingle()
				.WithArguments(table);
		}
	}
}
