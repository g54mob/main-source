using System;
using System.Collections.Generic;
using DV.Localization;
using DV.Shops;
using DV.ThingTypes;
using DV.Utils;
using LocoSim.Definitions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DV.RenderTextureSystem.BookletRender
{
	public class VehicleCatalogPageTemplatePaper : TemplatePaper
	{
		[Serializable]
		public class LicenseData
		{
			public Image icon;

			public Image lockIcon;

			public TextMeshProUGUI price;
		}

		[Serializable]
		public class IconPriceData
		{
			public Image icon;

			public TextMeshProUGUI price;
		}

		public TrainCarLivery carLivery;

		public TextMeshProUGUI price;

		public LicenseData[] licenses;

		public TextMeshProUGUI massEmpty;

		public TextMeshProUGUI massFull;

		[Header("Set only on ones that use this")]
		public IconPriceData garage;

		public IconPriceData summon;

		public override void FillInData()
		{
			LicenseData[] array = licenses;
			foreach (LicenseData obj in array)
			{
				obj.icon.gameObject.SetActive(value: false);
				obj.lockIcon.gameObject.SetActive(value: false);
				obj.price.gameObject.SetActive(value: false);
			}
			if (garage.icon != null && garage.price != null)
			{
				garage.icon.gameObject.SetActive(value: false);
				garage.price.gameObject.SetActive(value: false);
			}
			if (summon.icon != null && summon.price != null)
			{
				summon.icon.gameObject.SetActive(value: false);
				summon.price.gameObject.SetActive(value: false);
			}
			if (massEmpty != null)
			{
				massEmpty.text = (carLivery.parentType.mass * 0.001f).ToString("#,0.#", LocalizationAPI.CC) + "t";
			}
			if (massFull != null)
			{
				IDefaultMassProvider[] componentsInChildren = carLivery.prefab.GetComponentsInChildren<IDefaultMassProvider>();
				float num = carLivery.parentType.mass;
				IDefaultMassProvider[] array2 = componentsInChildren;
				foreach (IDefaultMassProvider defaultMassProvider in array2)
				{
					num += defaultMassProvider.DefaultMassValue();
				}
				if (componentsInChildren.Length != 0)
				{
					massFull.text = (num * 0.001f).ToString("#,0.#", LocalizationAPI.CC) + "t";
				}
				else
				{
					massFull.transform.parent.gameObject.SetActive(value: false);
				}
			}
			if (carLivery.requiredLicense != null)
			{
				List<GeneralLicenseType_v2> list = new List<GeneralLicenseType_v2>();
				List<JobLicenseType_v2> list2 = new List<JobLicenseType_v2>();
				Stack<JobLicenseType_v2> stack = new Stack<JobLicenseType_v2>();
				Stack<GeneralLicenseType_v2> stack2 = new Stack<GeneralLicenseType_v2>();
				stack2.Push(carLivery.requiredLicense);
				while (stack2.Count > 0 || stack.Count > 0)
				{
					GeneralLicenseType_v2 generalLicenseType_v = ((stack2.Count > 0) ? stack2.Pop() : null);
					if (generalLicenseType_v != null)
					{
						list.Add(generalLicenseType_v);
						if (generalLicenseType_v.requiredGeneralLicense != null)
						{
							stack2.Push(generalLicenseType_v.requiredGeneralLicense);
						}
						if (generalLicenseType_v.requiredJobLicense != null)
						{
							stack.Push(generalLicenseType_v.requiredJobLicense);
						}
					}
					JobLicenseType_v2 jobLicenseType_v = ((stack.Count > 0) ? stack.Pop() : null);
					if (jobLicenseType_v != null)
					{
						list2.Add(jobLicenseType_v);
						if (jobLicenseType_v.requiredGeneralLicense != null)
						{
							stack2.Push(jobLicenseType_v.requiredGeneralLicense);
						}
						if (jobLicenseType_v.requiredJobLicense != null)
						{
							stack.Push(jobLicenseType_v.requiredJobLicense);
						}
					}
				}
				list.Reverse();
				list2.Reverse();
				if (list2.Count + list.Count <= licenses.Length)
				{
					int num2 = 0;
					foreach (JobLicenseType_v2 item in list2)
					{
						licenses[num2].icon.sprite = item.icon;
						licenses[num2].icon.gameObject.SetActive(value: true);
						if (item.price > 0f)
						{
							licenses[num2].lockIcon.gameObject.SetActive(value: true);
							licenses[num2].price.text = "$" + item.price.ToString("N0", LocalizationAPI.CC);
							licenses[num2].price.gameObject.SetActive(value: true);
						}
						num2++;
					}
					foreach (GeneralLicenseType_v2 item2 in list)
					{
						licenses[num2].icon.sprite = item2.icon;
						licenses[num2].icon.gameObject.SetActive(value: true);
						if (item2.price > 0f)
						{
							licenses[num2].lockIcon.gameObject.SetActive(value: true);
							licenses[num2].price.text = "$" + item2.price.ToString("N0", LocalizationAPI.CC);
							licenses[num2].price.gameObject.SetActive(value: true);
						}
						num2++;
					}
				}
				else
				{
					Debug.LogError("Not all licenses will be displayed on VC for car: " + carLivery.id);
				}
			}
			if (price != null)
			{
				TrainCarType_v2 parentType = carLivery.parentType;
				float num3 = parentType.damage.bodyPrice + parentType.damage.wheelsPrice + parentType.damage.electricalPowertrainPrice + parentType.damage.mechanicalPowertrainPrice;
				price.text = "$" + num3.ToString("N0", LocalizationAPI.CC);
			}
			if (!Globals.G.Types.CarLiveryToGarageRequirement.TryGetValue(carLivery, out var value))
			{
				return;
			}
			if (garage.icon != null && garage.price != null && SingletonBehaviour<GlobalShopController>.Instance != null)
			{
				foreach (ShopItemData shopItemsDatum in SingletonBehaviour<GlobalShopController>.Instance.shopItemsData)
				{
					if (shopItemsDatum.item.TryGetComponent<GaragePadlockKey>(out var component) && component.garage == value)
					{
						garage.icon.gameObject.SetActive(value: true);
						garage.price.text = "$" + shopItemsDatum.basePrice.ToString("N0", LocalizationAPI.CC);
						garage.price.gameObject.SetActive(value: true);
						break;
					}
				}
			}
			if (summon.icon != null && summon.price != null)
			{
				summon.icon.gameObject.SetActive(value: true);
				summon.price.text = "$" + value.summonPrice.ToString("N0", LocalizationAPI.CC);
				summon.price.gameObject.SetActive(value: true);
			}
		}

		public override void CleanUp()
		{
		}
	}
}
