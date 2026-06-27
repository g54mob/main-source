using System;
using System.Collections.Generic;
using System.Linq;
using Restory.Data.Devices;
using Restory.Data.Elements;
using Restory.Data.SaveLoad;
using Restory.Data.SaveLoad.Containers;
using Restory.Data.SaveLoad.DataMigration;
using Restory.Data.Shops.Elements;
using Restory.Data.WorkshopStatus;
using Restory.Gameplay.Licenses;
using Restory.Gameplay.SaveLoad.Exceptions;
using Restory.Gameplay.WorkshopStatus;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.Shops.Elements
{
	public class ElementsShopService : MonoBehaviour, IInitializable, ISaveableComponent, ISaveableComponentReader, ISaveableComponentWriter
	{
		[SerializeField]
		private ElementsShopInfo elementsShop;

		[SerializeField]
		private StatusInfo[] statusesForLicenseMultiplier = Array.Empty<StatusInfo>();

		[SerializeField]
		[Min(0f)]
		private float licenseMultiplier = 0.9f;

		private readonly Dictionary<ElementInfo, ElementsShopItemData> elementItems = new Dictionary<ElementInfo, ElementsShopItemData>();

		private readonly List<LicenseShopItemData> licenseItems = new List<LicenseShopItemData>();

		private DeviceInfoDatabase deviceDatabase;

		private LicensesService licensesService;

		private WorkshopStatusService workshopStatusService;

		public IReadOnlyCollection<ElementsShopItemData> ElementItems => elementItems.Values;

		public IReadOnlyList<LicenseShopItemData> LicenseItems => licenseItems;

		[Inject]
		private void Construct(DeviceInfoDatabase deviceDatabase, LicensesService licensesService, WorkshopStatusService workshopStatusService)
		{
			this.deviceDatabase = deviceDatabase;
			this.licensesService = licensesService;
			this.workshopStatusService = workshopStatusService;
		}

		public void Initialize()
		{
			ElementsShopItemData[] productsList = elementsShop.ProductsList;
			for (int i = 0; i < productsList.Length; i++)
			{
				ElementsShopItemData elementsShopItemData = productsList[i].Clone();
				elementItems[elementsShopItemData.Element] = elementsShopItemData;
			}
			licenseItems.AddRange(elementsShop.Licenses.Select((LicenseShopItemData p) => p.Clone()));
		}

		public IEnumerable<ElementsShopItemData> GetAllowedElementItems()
		{
			foreach (ElementsShopItemData value in elementItems.Values)
			{
				IElementInfo element = value.Element;
				if (element != null && deviceDatabase.TryGetDeviceInfo(element, out var deviceInfo) && (deviceInfo.License == null || licensesService.Contains(deviceInfo.License)))
				{
					yield return value;
				}
			}
		}

		public IEnumerable<LicenseShopItemData> GetAllowedLicenses()
		{
			foreach (LicenseShopItemData licenseItem in licenseItems)
			{
				if (!licensesService.Contains(licenseItem.License))
				{
					yield return licenseItem;
				}
			}
		}

		public int CalculatePrice(LicenseShopItemData licenseItem)
		{
			float num = licenseItem.Price;
			StatusInfo[] array = statusesForLicenseMultiplier;
			foreach (StatusInfo status in array)
			{
				if (workshopStatusService.HasStatus(status))
				{
					num *= licenseMultiplier;
					break;
				}
			}
			return Mathf.RoundToInt(num);
		}

		public bool ContainsLicenseMultiplierStatus()
		{
			return statusesForLicenseMultiplier.Any(workshopStatusService.HasStatus);
		}

		public void RestoreState(object state)
		{
			try
			{
				foreach (ElementsShopItemData elementItem in DataMigrationWizard.Migrate<ElementsShopServiceSaveData>(state, base.gameObject).ElementItems)
				{
					elementItems[elementItem.Element] = elementItem;
				}
			}
			catch (Exception innerException)
			{
				Debug.LogException(new RestoreProgressException(base.gameObject, state, innerException));
			}
		}

		public object CaptureState()
		{
			try
			{
				return new ElementsShopServiceSaveData
				{
					ElementItems = new List<ElementsShopItemData>(elementItems.Values)
				};
			}
			catch (Exception innerException)
			{
				Debug.LogException(new CaptureProgressException(base.gameObject, innerException));
				return null;
			}
		}
	}
}
