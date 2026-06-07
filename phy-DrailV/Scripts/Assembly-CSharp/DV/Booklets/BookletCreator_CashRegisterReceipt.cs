using System;
using System.Collections.Generic;
using DV.Booklets.Rendered;
using DV.Localization;
using DV.RenderTextureSystem;
using DV.RenderTextureSystem.BookletRender;
using DV.Utils;
using UnityEngine;

namespace DV.Booklets
{
	public class BookletCreator_CashRegisterReceipt
	{
		public static GameObject Create(List<CashRegisterModule> registerModules, Vector3 position, Quaternion rotation, Transform parent = null)
		{
			List<CashRegisterModule.CashRegisterModuleData> list = new List<CashRegisterModule.CashRegisterModuleData>();
			foreach (CashRegisterModule registerModule in registerModules)
			{
				list.AddRange(registerModule.GetAllNonZeroPurchaseData());
			}
			return Create(list, position, rotation, parent);
		}

		public static GameObject Create(List<CashRegisterModule.CashRegisterModuleData> data, Vector3 position, Quaternion rotation, Transform parent = null)
		{
			GameObject obj = (GameObject)UnityEngine.Object.Instantiate(Resources.Load("ReceiptBooklet", typeof(GameObject)), position, rotation, parent);
			obj.name = "Receipt";
			ReceiptBookletRender component = ((GameObject)UnityEngine.Object.Instantiate(Resources.Load("ReceiptRender", typeof(GameObject)), SingletonBehaviour<DV.RenderTextureSystem.RenderTextureSystem>.Instance.transform.position, Quaternion.identity)).GetComponent<ReceiptBookletRender>();
			obj.GetComponent<RenderedTexturesBase>().RegisterTexturesGeneratedEvent(component);
			component.GenerateTextures(GetCashRegisterReceiptTemplateData(data).ToArray());
			return obj;
		}

		private static List<TemplatePaperData> GetCashRegisterReceiptTemplateData(List<CashRegisterModule.CashRegisterModuleData> data)
		{
			List<TemplatePaperData> list = new List<TemplatePaperData>();
			float num = 0f;
			List<ReceiptTemplatePaperData.ReceiptElementData> list2 = new List<ReceiptTemplatePaperData.ReceiptElementData>();
			foreach (CashRegisterModule.CashRegisterModuleData datum in data)
			{
				string elemName = datum.resourceName + ((datum.car != null) ? (" [" + datum.car.ID + "]") : "");
				string pricePerUnit = "$" + datum.pricePerUnit.ToString("N2", LocalizationAPI.CC);
				float totalPrice = datum.TotalPrice;
				string price = "$" + totalPrice.ToString("N2", LocalizationAPI.CC);
				list2.Add(new ReceiptTemplatePaperData.ReceiptElementData(elemName, datum.unitsToBuy.ToString("N2", LocalizationAPI.CC), pricePerUnit, price, datum.resourceIcon));
				num += totalPrice;
			}
			string totalPrice2 = "$" + num.ToString("N2", LocalizationAPI.CC);
			int num2 = Mathf.CeilToInt((float)list2.Count / 4f);
			int num3 = 1;
			int num4 = num2;
			while (list2.Count > 0)
			{
				int count = Math.Min(list2.Count, 4);
				List<ReceiptTemplatePaperData.ReceiptElementData> range = list2.GetRange(0, count);
				list2.RemoveRange(0, count);
				list.Add(new ReceiptTemplatePaperData(totalPrice2, range, num3.ToString(), num4.ToString()));
				num3++;
			}
			return list;
		}
	}
}
