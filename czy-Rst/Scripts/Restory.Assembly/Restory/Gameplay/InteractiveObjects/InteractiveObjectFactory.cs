using Restory.Data.InteractiveObjects;
using Restory.Data.Licenses;
using Restory.Data.RegularPayments;
using Restory.Gameplay.RegularPayments;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.InteractiveObjects
{
	public class InteractiveObjectFactory
	{
		private readonly DiContainer diContainer;

		[Inject]
		private InteractiveObjectFactory(DiContainer diContainer)
		{
			this.diContainer = diContainer;
		}

		public InteractiveObject CreateInteractiveObject(InteractiveObjectInfo interactiveObjectInfo, Transform parentTransform)
		{
			InteractiveObject interactiveObject = diContainer.InstantiatePrefabForComponent<InteractiveObject>(interactiveObjectInfo.Prefab.gameObject, parentTransform);
			if (interactiveObjectInfo is LicenseInfo licenseInfo)
			{
				InitLicenseObject(interactiveObject, licenseInfo);
			}
			else if (interactiveObjectInfo is RegularPaymentInfo regularPaymentInfo)
			{
				InitPaymentBillObject(interactiveObject, regularPaymentInfo);
			}
			return interactiveObject;
		}

		public void DestroyInteractiveObject(InteractiveObject interactiveObject)
		{
			Object.Destroy(interactiveObject.gameObject);
		}

		private void InitLicenseObject(InteractiveObject interactiveObject, LicenseInfo licenseInfo)
		{
			if (!interactiveObject.TryGetComponent<LicenseObject>(out var component))
			{
				Debug.LogError("Failed to find LicenseObject component on interactiveObject");
			}
			else
			{
				component.Init(licenseInfo);
			}
		}

		private void InitPaymentBillObject(InteractiveObject interactiveObject, RegularPaymentInfo regularPaymentInfo)
		{
			if (!interactiveObject.TryGetComponent<RegularPaymentObject>(out var component))
			{
				Debug.LogError("Failed to find RegularPaymentObject component on interactiveObject");
			}
			else
			{
				component.SetUp(regularPaymentInfo);
			}
		}
	}
}
