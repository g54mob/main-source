using System.Collections.Generic;
using DV.Logic.Job;
using DV.ServicePenalty;
using DV.ThingTypes;
using UnityEngine;

namespace DV.Booklets
{
	public class BookletCreator
	{
		public static JobBooklet CreateJobBooklet(Job job, Vector3 position, Quaternion rotation, Transform parent = null, bool addToWorldStorage = false)
		{
			return BookletCreator_Job.Create(job, position, rotation, parent, addToWorldStorage);
		}

		public static JobOverview CreateJobOverview(Job job, Vector3 position, Quaternion rotation, Transform parent = null)
		{
			return BookletCreator_JobOverview.Create(job, position, rotation, parent);
		}

		public static JobExpiredReport CreateJobExpiredReport(Job job, Vector3 position, Quaternion rotation, Transform parent = null)
		{
			return BookletCreator_JobExpiredReport.Create(job, position, rotation, parent);
		}

		public static JobReport CreateJobReport(Job job, DisplayableDebt debt, Vector3 position, Quaternion rotation, Transform parent = null)
		{
			return BookletCreator_JobReport.Create(job, debt, position, rotation, parent);
		}

		public static JobMissingLicenseReport CreateMissingLicenseReport(Job job, bool isJobLicenseMissing, Vector3 position, Quaternion rotation, Transform parent = null)
		{
			return BookletCreator_JobMissingLicense.Create(job, isJobLicenseMissing, position, rotation, parent);
		}

		public static GameObject CreateLicense(JobLicenseType_v2 license, Vector3 position, Quaternion rotation, Transform parent = null)
		{
			return BookletCreator_Licenses.CreateLicense(license, position, rotation, parent);
		}

		public static GameObject CreateLicense(GeneralLicenseType_v2 license, Vector3 position, Quaternion rotation, Transform parent = null)
		{
			return BookletCreator_Licenses.CreateLicense(license, position, rotation, parent);
		}

		public static GameObject CreateLicenseInfo(JobLicenseType_v2 license, Vector3 position, Quaternion rotation, Transform parent = null)
		{
			return BookletCreator_Licenses.CreateLicenseInfo(license, position, rotation, parent);
		}

		public static GameObject CreateLicenseInfo(GeneralLicenseType_v2 license, Vector3 position, Quaternion rotation, Transform parent = null)
		{
			return BookletCreator_Licenses.CreateLicenseInfo(license, position, rotation, parent);
		}

		public static GameObject CreateTutorialWarningReport(Vector3 position, Quaternion rotation, Transform parent = null)
		{
			return BookletCreator_Debt.CreateTutorialWarningReport(position, rotation, parent);
		}

		public static GameObject CreateDebtWarningReport(Vector3 position, Quaternion rotation, Transform parent = null)
		{
			return BookletCreator_Debt.CreateDebtWarningReport(position, rotation, parent);
		}

		public static FeesReport CreateDebtBooklet(DisplayableDebt debt, Vector3 position, Quaternion rotation, Transform parent = null)
		{
			return BookletCreator_Debt.Create(debt, position, rotation, parent);
		}

		public static GameObject CreateCashRegisterReceipt(List<CashRegisterModule> registerModules, Vector3 position, Quaternion rotation, Transform parent = null)
		{
			return BookletCreator_CashRegisterReceipt.Create(registerModules, position, rotation, parent);
		}

		public static GameObject CreateStaticBooklet(string prefabName, Vector3 position, Quaternion rotation, Transform parent = null)
		{
			return BookletCreator_StaticRenderBooklet.Create(prefabName, position, rotation, parent);
		}
	}
}
