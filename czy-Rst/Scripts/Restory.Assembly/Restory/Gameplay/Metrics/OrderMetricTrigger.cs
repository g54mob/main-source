using Restory.Gameplay.WorkOrders;
using Restory.Gameplay.WorkOrders.EmailOrders;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.Metrics
{
	public class OrderMetricTrigger : MetricTrigger
	{
		[SerializeField]
		[Min(0f)]
		private int pointsPerOrder = 1;

		private WorkOrdersService workOrdersService;

		private EmailOrdersService emailOrdersService;

		[Inject]
		private void Construct(WorkOrdersService workOrdersService, EmailOrdersService emailOrdersService)
		{
			this.workOrdersService = workOrdersService;
			this.emailOrdersService = emailOrdersService;
		}

		public override void Initialize()
		{
			workOrdersService.OnOrderCompleted += ResolveOnOrderCompleted;
			emailOrdersService.OnOrdersShipped += ResolveOnOrdersShipped;
		}

		public override void Dispose()
		{
			workOrdersService.OnOrderCompleted -= ResolveOnOrderCompleted;
			emailOrdersService.OnOrdersShipped -= ResolveOnOrdersShipped;
		}

		private void ResolveOnOrderCompleted(WorkOrdersService service, WorkOrderBase order)
		{
			AddPoints(pointsPerOrder);
		}

		private void ResolveOnOrdersShipped()
		{
			AddPoints(pointsPerOrder * emailOrdersService.LastTimeShippedOrders.Count);
		}
	}
}
