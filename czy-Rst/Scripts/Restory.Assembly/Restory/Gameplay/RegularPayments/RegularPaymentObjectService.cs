using Restory.Data.RegularPayments;
using Restory.Data.SaveLoad;
using Restory.Gameplay.InteractiveObjects;
using UnityEngine;

namespace Restory.Gameplay.RegularPayments
{
	public class RegularPaymentObjectService
	{
		private readonly InteractiveObjectFactory factory;

		private readonly InteractiveObjectRegistry interactiveObjectRegistry;

		private readonly RegularPaymentObjectRegistry registry;

		private readonly IDService idService;

		public RegularPaymentObjectService(InteractiveObjectFactory factory, InteractiveObjectRegistry interactiveObjectRegistry, RegularPaymentObjectRegistry registry, IDService idService)
		{
			this.factory = factory;
			this.interactiveObjectRegistry = interactiveObjectRegistry;
			this.registry = registry;
			this.idService = idService;
		}

		public RegularPaymentObject Create(RegularPaymentInfo regularPaymentInfo, Transform parent, params InteractiveObjectAdditionalProperty[] additionalRegularPaymentProperties)
		{
			InteractiveObject interactiveObject = factory.CreateInteractiveObject(regularPaymentInfo, parent);
			if (!interactiveObject.TryGetComponent<RegularPaymentObject>(out var component))
			{
				factory.DestroyInteractiveObject(interactiveObject);
				Debug.LogError("[RegularPaymentObjectService] tried to create Regular Payment item, but its prefab has no required [RegularPaymentObject] component!", regularPaymentInfo.Prefab);
				return null;
			}
			component.SetUp(regularPaymentInfo);
			interactiveObject.Init(InteractiveObjectState.Stored, idService.GenerateNew(), hasChanged: false, additionalRegularPaymentProperties);
			interactiveObjectRegistry.Register(interactiveObject, regularPaymentInfo);
			registry.Register(component);
			return component;
		}

		public void Destroy(RegularPaymentObject regularPaymentObject)
		{
			interactiveObjectRegistry.Unregister(regularPaymentObject.InteractiveObject);
			registry.Unregister(regularPaymentObject);
			factory.DestroyInteractiveObject(regularPaymentObject.InteractiveObject);
		}
	}
}
