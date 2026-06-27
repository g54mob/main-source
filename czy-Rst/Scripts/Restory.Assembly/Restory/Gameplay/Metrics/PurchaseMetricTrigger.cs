using Restory.Gameplay.Delivery;
using Restory.Gameplay.Devices;
using Restory.Gameplay.InteractiveObjects;
using Restory.Utils;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.Metrics
{
	public class PurchaseMetricTrigger : MetricTrigger
	{
		[SerializeField]
		[Min(0f)]
		private int pointsPerPurchase = 1;

		private DeliveryService deliveryService;

		private InteractiveObjectBoxContainer deliveryBox;

		[Inject]
		private void Construct(DeliveryService deliveryService)
		{
			this.deliveryService = deliveryService;
		}

		public override void Initialize()
		{
			deliveryService.OnDeliveryBoxCreated += ResolveOnDeliveryBoxCreated;
		}

		public override void Dispose()
		{
			deliveryService.OnDeliveryBoxCreated -= ResolveOnDeliveryBoxCreated;
			if (deliveryBox.MonoShellExists())
			{
				deliveryBox.OnInteractiveObjectTakenOutCompleted -= ResolveOnInteractiveObjectTakenOutCompleted;
				deliveryBox = null;
			}
		}

		private void ResolveOnDeliveryBoxCreated(DeliveryService service)
		{
			if (deliveryBox.MonoShellExists())
			{
				deliveryBox.OnInteractiveObjectTakenOutCompleted -= ResolveOnInteractiveObjectTakenOutCompleted;
			}
			deliveryBox = service.DeliveryBox;
			if (deliveryBox.MonoShellExists())
			{
				deliveryBox.OnInteractiveObjectTakenOutCompleted += ResolveOnInteractiveObjectTakenOutCompleted;
			}
		}

		private void ResolveOnInteractiveObjectTakenOutCompleted(InteractiveObject obj)
		{
			if (obj is DeviceContainer && !obj.AdditionalProperties.ContainsProperty<GeneratedDeviceProperty>())
			{
				AddPoints(pointsPerPurchase);
			}
		}
	}
}
