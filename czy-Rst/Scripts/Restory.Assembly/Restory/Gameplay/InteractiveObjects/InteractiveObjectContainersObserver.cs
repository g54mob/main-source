using System;
using Restory.Data.InteractiveObjects;
using Restory.Gameplay.Delivery;
using Restory.Utils;
using Zenject;

namespace Restory.Gameplay.InteractiveObjects
{
	public class InteractiveObjectContainersObserver : IInitializable, IDisposable
	{
		private InteractiveObjectRegistry interactiveObjectRegistry;

		private DeliveryService deliveryService;

		private PersonalBoxService personalBoxService;

		private InteractiveObjectBoxContainer deliveryBox;

		private InteractiveObjectBoxContainer personalBox;

		public event Action<InteractiveObjectInfo> OnInteractiveObjectTakenOutComplete;

		[Inject]
		private void Construct(InteractiveObjectRegistry interactiveObjectRegistry, DeliveryService deliveryService, PersonalBoxService personalBoxService)
		{
			this.interactiveObjectRegistry = interactiveObjectRegistry;
			this.deliveryService = deliveryService;
			this.personalBoxService = personalBoxService;
		}

		public void Initialize()
		{
			deliveryService.OnDeliveryBoxCreated += ResolveOnDeliveryBoxCreated;
			personalBoxService.OnPersonalBoxCreated += ResolveOnPersonalBoxCreated;
			deliveryBox = deliveryService.DeliveryBox;
			if ((bool)deliveryBox)
			{
				deliveryBox.OnInteractiveObjectTakenOutCompleted += ResolveOnInteractiveObjectTakenOutCompleted;
			}
			personalBox = personalBoxService.PersonalBox;
			if ((bool)personalBox)
			{
				personalBox.OnInteractiveObjectTakenOutCompleted += ResolveOnInteractiveObjectTakenOutCompleted;
			}
		}

		public void Dispose()
		{
			deliveryService.OnDeliveryBoxCreated -= ResolveOnDeliveryBoxCreated;
			personalBoxService.OnPersonalBoxCreated -= ResolveOnPersonalBoxCreated;
			if (deliveryBox.MonoShellExists())
			{
				deliveryBox.OnInteractiveObjectTakenOutCompleted -= ResolveOnInteractiveObjectTakenOutCompleted;
				deliveryBox = null;
			}
			if (personalBox.MonoShellExists())
			{
				personalBox.OnInteractiveObjectTakenOutCompleted -= ResolveOnInteractiveObjectTakenOutCompleted;
				personalBox = null;
			}
		}

		private void ResolveOnPersonalBoxCreated(PersonalBoxService service)
		{
			if (personalBox.MonoShellExists())
			{
				personalBox.OnInteractiveObjectTakenOutCompleted -= ResolveOnInteractiveObjectTakenOutCompleted;
			}
			personalBox = service.PersonalBox;
			if (personalBox.MonoShellExists())
			{
				personalBox.OnInteractiveObjectTakenOutCompleted += ResolveOnInteractiveObjectTakenOutCompleted;
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
			if (interactiveObjectRegistry.All.TryGetValue(obj, out var value))
			{
				this.OnInteractiveObjectTakenOutComplete?.Invoke(value);
			}
		}
	}
}
