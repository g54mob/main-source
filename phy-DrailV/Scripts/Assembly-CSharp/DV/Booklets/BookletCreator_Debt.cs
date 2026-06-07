using System;
using System.Collections.Generic;
using DV.Booklets.Rendered;
using DV.Localization;
using DV.RenderTextureSystem;
using DV.RenderTextureSystem.BookletRender;
using DV.ServicePenalty;
using DV.ThingTypes;
using DV.ThingTypes.TransitionHelpers;
using DV.Utils;
using UnityEngine;

namespace DV.Booklets
{
	public class BookletCreator_Debt
	{
		public const string NO_DAMAGE_FEES_RENDER_PREFAB = "FeesNoDamageRender";

		public static FeesReport Create(DisplayableDebt debt, Vector3 position, Quaternion rotation, Transform parent = null)
		{
			return Create(new Debt_data(debt), position, rotation, parent);
		}

		public static FeesReport Create(Debt_data debt, Vector3 position, Quaternion rotation, Transform parent = null)
		{
			if (debt == null)
			{
				Debug.LogError("Given debt reference is null! FeesReport booklet can't be created");
				return null;
			}
			string iD = debt.ID;
			GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(Resources.Load("FeesReport", typeof(GameObject)), position, rotation, parent);
			gameObject.name = "FeesReport[" + iD + "]";
			FeesReport component = gameObject.GetComponent<FeesReport>();
			component.feeId = iD;
			string renderPrefabNameForDebtType = GetRenderPrefabNameForDebtType(debt.debtType);
			if (renderPrefabNameForDebtType == string.Empty)
			{
				Debug.LogError("Can't create booklet textures!");
				return component;
			}
			FeesBookletRender component2 = ((GameObject)UnityEngine.Object.Instantiate(Resources.Load(renderPrefabNameForDebtType, typeof(GameObject)), SingletonBehaviour<DV.RenderTextureSystem.RenderTextureSystem>.Instance.transform.position, Quaternion.identity)).GetComponent<FeesBookletRender>();
			gameObject.GetComponent<RenderedTexturesBase>().RegisterTexturesGeneratedEvent(component2);
			component2.GenerateTextures(GetDebtBookletTemplateData(debt).ToArray());
			return component;
		}

		public static string GetRenderPrefabNameForDebtType(DebtType debtType)
		{
			switch (debtType)
			{
			case DebtType.ExistingJob:
			case DebtType.StagedJob:
				return "FeesJobRender";
			case DebtType.ExistingLoco:
			case DebtType.StagedLoco:
				return "FeesLocoRender";
			case DebtType.ExistingOther:
			case DebtType.StagedOther:
				return "FeesOtherRender";
			case DebtType.ExistingOwnedCar:
			case DebtType.StagedOwnedCar:
				return "OwnedCarStateRender";
			default:
				Debug.LogError(string.Format("Unexpected {0}: {1}!", "DebtType", debtType));
				return string.Empty;
			}
		}

		public static GameObject CreateDebtWarningReport(Vector3 position, Quaternion rotation, Transform parent = null)
		{
			GameObject obj = (GameObject)UnityEngine.Object.Instantiate(Resources.Load("DebtWarningReport", typeof(GameObject)), position, rotation, parent);
			obj.name = "DebtWarning";
			return obj;
		}

		public static List<TemplatePaperData> GetDebtBookletTemplateData(Debt_data debt, int startingPageNumber = 1, int startingTotalPages = 0)
		{
			List<TemplatePaperData> list = new List<TemplatePaperData>();
			string feeSum = ((debt.sumOfDebts1 > 0f) ? ("-$" + debt.sumOfDebts1.ToString("N2", LocalizationAPI.CC)) : "/");
			string feeSum2 = ((debt.sumOfDebts2 > 0f) ? ("-$" + debt.sumOfDebts2.ToString("N2", LocalizationAPI.CC)) : "/");
			string feeSum3 = ((debt.environmentDamageTotalPrice > 0f) ? ("-$" + debt.environmentDamageTotalPrice.ToString("N2", LocalizationAPI.CC)) : "/");
			string totalPrice = ((debt.totalPrice > 0f) ? "-$" : "$") + debt.totalPrice.ToString("N2", LocalizationAPI.CC);
			string feeToleranceInfoText = (debt.IsOwnedCarDebt ? "" : (debt.countsInFeeTolerance ? LocalizationAPI.L("job/fee_counts") : LocalizationAPI.L("job/fee_will_count")));
			List<FeesListTemplatePaperData.FeeListElement> list2 = new List<FeesListTemplatePaperData.FeeListElement>();
			List<FeesListTemplatePaperData.FeeListElement> list3 = new List<FeesListTemplatePaperData.FeeListElement>();
			CarDebtData[] debtData = debt.debtData;
			foreach (CarDebtData carDebtData in debtData)
			{
				List<PrintDebtComponentDetails> carDebtPrintDetails = carDebtData.GetCarDebtPrintDetails(debt.isTaxable, !debt.isStaged, debt.EnvironmentDamageTypes);
				if (carDebtPrintDetails == null)
				{
					continue;
				}
				foreach (PrintDebtComponentDetails item6 in carDebtPrintDetails)
				{
					ResourceType_v2 resourceType_v = item6.type.ToV2();
					bool canBeDamaged = resourceType_v.canBeDamaged;
					string feeType = (canBeDamaged ? LocalizationAPI.L("job/fee_type_damage") : LocalizationAPI.L("job/fee_type_resource"));
					string debtTitle = GetDebtTitle(carDebtData, resourceType_v);
					string text = (debt.IsJobDebt ? item6.beforeSnapshotAmount : item6.totalAmount).ToString("N1", LocalizationAPI.CC);
					if (canBeDamaged)
					{
						text += "%";
					}
					string text2 = string.Empty;
					if (debt.IsJobDebt)
					{
						text2 = item6.afterSnapshotAmount.ToString("N1", LocalizationAPI.CC);
						if (canBeDamaged)
						{
							text2 += "%";
						}
					}
					else if (debt.isTaxable)
					{
						text2 = "x" + 2f.ToString(LocalizationAPI.CC);
					}
					string pricePerUnit = "$" + item6.pricePerUnit.ToString("N2", LocalizationAPI.CC);
					string totalElementPrice = "$" + item6.totalPrice.ToString("N2", LocalizationAPI.CC);
					FeesListTemplatePaperData.FeeListElement item = new FeesListTemplatePaperData.FeeListElement(feeType, carDebtData.id, debtTitle, carDebtData.carType, carDebtData.loadedCargoType, item6.type, text, text2, pricePerUnit, totalElementPrice);
					if (item6.type == ResourceType.Car_DMG)
					{
						list2.Add(item);
					}
					else
					{
						list3.Add(item);
					}
				}
			}
			List<FeesListTemplatePaperData.FeeListElement> list4 = list2;
			list4.AddRange(list3);
			int num = Mathf.CeilToInt((float)list4.Count / 4f);
			int num2 = startingPageNumber;
			int num3 = startingTotalPages;
			bool flag = !debt.IsOwnedCarDebt;
			int num4 = (flag ? 1 : 0);
			num3 += 1 + num + num4;
			(string summaryAssessmentText, bool showYouAreInsuredText) feeSummaryAssessment = GetFeeSummaryAssessment(debt.totalPriceOfDamageableResources, debt.IsJobOrOther, debt.IsOwnedCarDebt);
			string item2 = feeSummaryAssessment.summaryAssessmentText;
			bool item3 = feeSummaryAssessment.showYouAreInsuredText;
			TrainCarLivery summaryIconCarLivery = ((debt.IsLocoDebt || debt.IsOwnedCarDebt) ? debt.debtData[0].carType.ToV2() : null);
			string feeTypeTitle = ((debt.IsLocoDebt || debt.IsOwnedCarDebt) ? LocalizationAPI.L(debt.debtData[0].carType.ToV2().parentType.localizationKey) : string.Empty);
			FeesSummaryTemplatePaperData item4 = new FeesSummaryTemplatePaperData(debt.ID, feeTypeTitle, summaryIconCarLivery, feeSum, feeSum2, feeSum3, item2, item3, totalPrice, feeToleranceInfoText, num2.ToString(), num3.ToString());
			list.Add(item4);
			num2++;
			while (list4.Count > 0)
			{
				int count = Math.Min(list4.Count, 4);
				List<FeesListTemplatePaperData.FeeListElement> range = list4.GetRange(0, count);
				list4.RemoveRange(0, count);
				FeesListTemplatePaperData item5 = new FeesListTemplatePaperData(debt.ID, feeTypeTitle, range, num2.ToString(), num3.ToString());
				list.Add(item5);
				num2++;
			}
			if (flag)
			{
				list.Add(GetEnvironmentTemplatePaperData(debt.ID, feeTypeTitle, debt.environmentDamageTotalPrice, debt.IsLocoDebt, num2, num3));
				num2++;
			}
			return list;
		}

		public static GameObject CreateTutorialWarningReport(Vector3 position, Quaternion rotation, Transform parent = null)
		{
			GameObject obj = (GameObject)UnityEngine.Object.Instantiate(Resources.Load("TutorialWarningReport", typeof(GameObject)), position, rotation, parent);
			obj.name = "TutorialWarning";
			return obj;
		}

		public static List<TemplatePaperData> GetNoFeesDebtBookletTemplateData(string debtId, int startingPageNumber = 1, int startingTotalPages = 0)
		{
			List<TemplatePaperData> list = new List<TemplatePaperData>();
			int num = startingPageNumber;
			int num2 = startingTotalPages;
			num2 += 2;
			string text = "/";
			string jOB_CARS_SUMMARY_ASSESSMENT_NO_DAMAGE = C.JOB_CARS_SUMMARY_ASSESSMENT_NO_DAMAGE;
			bool showYouAreInsuredText = false;
			FeesSummaryTemplatePaperData item = new FeesSummaryTemplatePaperData(debtId, string.Empty, null, text, text, text, jOB_CARS_SUMMARY_ASSESSMENT_NO_DAMAGE, showYouAreInsuredText, text, string.Empty, num.ToString(), num2.ToString());
			list.Add(item);
			num++;
			list.Add(GetEnvironmentTemplatePaperData(debtId, string.Empty, 0f, isLoco: false, num, num2));
			num++;
			return list;
		}

		private static FeesEnvironmentTemplatePaperData GetEnvironmentTemplatePaperData(string debtId, string feeTypeTitle, float environmentDamageTotalPrice, bool isLoco, int pageNum, int totalPages)
		{
			int damageLevel = GetEnvironmentDamageLevelFromPrice(environmentDamageTotalPrice);
			bool num = environmentDamageTotalPrice > 0f;
			string text = (isLoco ? LocalizationAPI.L("job/fee_emissions") : LocalizationAPI.L("job/fee_env_damage_2"));
			string text2 = (isLoco ? LocalizationAPI.L("job/fee_no_emissions") : LocalizationAPI.L("job/fee_no_env_damage"));
			string descriptionText = (num ? text : text2);
			string price = (num ? ("$" + environmentDamageTotalPrice.ToString("N2", LocalizationAPI.CC)) : string.Empty);
			return new FeesEnvironmentTemplatePaperData(debtId, feeTypeTitle, descriptionText, damageLevel, price, pageNum.ToString(), totalPages.ToString());
			int GetEnvironmentDamageLevelFromPrice(float environmentDamagePrice)
			{
				if (environmentDamagePrice < 1000f)
				{
					return 0;
				}
				if (environmentDamagePrice < 5000f)
				{
					return 1;
				}
				if (environmentDamagePrice < 10000f)
				{
					return 2;
				}
				if (environmentDamagePrice < 50000f)
				{
					return 3;
				}
				return 4;
			}
		}

		private static string GetDebtTitle(CarDebtData carDebtData, ResourceType_v2 type)
		{
			if (type.v1 == ResourceType.Cargo_DMG)
			{
				return "<b>" + LocalizationAPI.L(carDebtData.loadedCargoType.ToV2().localizationKeyFull) + "</b>";
			}
			if (type.canBeDamaged)
			{
				return LocalizationAPI.L(carDebtData.carType.ToV2().localizationKey) + "\n<b>" + LocalizationAPI.L(type.localizationKeyFull) + "</b>";
			}
			return "<b>" + LocalizationAPI.L(type.localizationKeyFull) + "</b>";
		}

		private static (string summaryAssessmentText, bool showYouAreInsuredText) GetFeeSummaryAssessment(float totalDamageableResourcesPrice, bool isJobOrOther, bool isOwnedVehicle)
		{
			if (!isJobOrOther)
			{
				if (totalDamageableResourcesPrice <= 5000f)
				{
					return (summaryAssessmentText: C.LOCO_SUMMARY_ASSESSMENT_LEVEL_1, showYouAreInsuredText: false);
				}
				if (totalDamageableResourcesPrice <= 10000f)
				{
					return (summaryAssessmentText: C.LOCO_SUMMARY_ASSESSMENT_LEVEL_2, showYouAreInsuredText: false);
				}
				if (totalDamageableResourcesPrice <= 30000f)
				{
					return (summaryAssessmentText: C.LOCO_SUMMARY_ASSESSMENT_LEVEL_3, showYouAreInsuredText: !isOwnedVehicle);
				}
				if (totalDamageableResourcesPrice <= 60000f)
				{
					return (summaryAssessmentText: C.LOCO_SUMMARY_ASSESSMENT_LEVEL_4, showYouAreInsuredText: !isOwnedVehicle);
				}
				return (summaryAssessmentText: C.LOCO_SUMMARY_ASSESSMENT_LEVEL_5, showYouAreInsuredText: !isOwnedVehicle);
			}
			if (totalDamageableResourcesPrice <= 0f)
			{
				return (summaryAssessmentText: C.JOB_CARS_SUMMARY_ASSESSMENT_NO_DAMAGE, showYouAreInsuredText: false);
			}
			if (totalDamageableResourcesPrice <= 10000f)
			{
				return (summaryAssessmentText: C.JOB_CARS_SUMMARY_ASSESSMENT_LEVEL_1, showYouAreInsuredText: false);
			}
			if (totalDamageableResourcesPrice <= 30000f)
			{
				return (summaryAssessmentText: C.JOB_CARS_SUMMARY_ASSESSMENT_LEVEL_2, showYouAreInsuredText: true);
			}
			if (totalDamageableResourcesPrice <= 50000f)
			{
				return (summaryAssessmentText: C.JOB_CARS_SUMMARY_ASSESSMENT_LEVEL_3, showYouAreInsuredText: true);
			}
			if (totalDamageableResourcesPrice <= 100000f)
			{
				return (summaryAssessmentText: C.JOB_CARS_SUMMARY_ASSESSMENT_LEVEL_4, showYouAreInsuredText: true);
			}
			return (summaryAssessmentText: C.JOB_CARS_SUMMARY_ASSESSMENT_LEVEL_5, showYouAreInsuredText: true);
		}
	}
}
