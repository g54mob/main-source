using System.Collections.Generic;
using System.Linq;
using DV.Booklets.Rendered;
using DV.Localization;
using DV.Logic.Job;
using DV.RenderTextureSystem;
using DV.RenderTextureSystem.BookletRender;
using DV.ThingTypes;
using DV.ThingTypes.TransitionHelpers;
using DV.Utils;
using UnityEngine;

namespace DV.Booklets
{
	public class BookletCreator_JobMissingLicense
	{
		public static JobMissingLicenseReport Create(Job job, bool isJobLicenseMissing, Vector3 position, Quaternion rotation, Transform parent = null)
		{
			return Create(new Job_data(job), isJobLicenseMissing, position, rotation, parent);
		}

		public static JobMissingLicenseReport Create(Job_data job, bool isJobLicenseMissing, Vector3 position, Quaternion rotation, Transform parent = null)
		{
			GameObject obj = (GameObject)Object.Instantiate(Resources.Load("JobMissingLicenseReport", typeof(GameObject)), position, rotation, parent);
			obj.name = "MissingLicenseReport[" + job.ID + "]";
			JobMissingLicenseReport component = obj.GetComponent<JobMissingLicenseReport>();
			component.jobId = job.ID;
			MissingLicenseRender component2 = ((GameObject)Object.Instantiate(Resources.Load(isJobLicenseMissing ? "JobMissingLicenseRender" : "JobNeedConcurrentLicenseRender", typeof(GameObject)), SingletonBehaviour<DV.RenderTextureSystem.RenderTextureSystem>.Instance.transform.position, Quaternion.identity)).GetComponent<MissingLicenseRender>();
			obj.GetComponent<RenderedTexturesBase>().RegisterTexturesGeneratedEvent(component2);
			component2.GenerateTextures(GetMissingLicenseTemplateData(job, isJobLicenseMissing).ToArray());
			return component;
		}

		private static List<TemplatePaperData> GetMissingLicenseTemplateData(Job_data job, bool isJobLicenseMissing)
		{
			string jobType = "";
			string jobId = job.ID;
			Color jobColor = Color.white;
			switch (job.type)
			{
			case JobType.Transport:
				jobType = C.HAUL_JOB_TYPE_NAME;
				jobColor = C.HAUL_JOB_TYPE_COLOR;
				break;
			case JobType.ShuntingLoad:
				jobType = C.SHUNTING_JOB_TYPE_NAME;
				jobColor = C.SHUNTING_LOAD_JOB_TYPE_COLOR;
				break;
			case JobType.ShuntingUnload:
				jobType = C.SHUNTING_JOB_TYPE_NAME;
				jobColor = C.SHUNTING_UNLOAD_JOB_TYPE_COLOR;
				break;
			case JobType.EmptyHaul:
				jobType = C.EMPTY_HAUL_JOB_TYPE_NAME;
				jobColor = C.EMPTY_HAUL_JOB_TYPE_COLOR;
				break;
			default:
				Debug.LogError("Unsupported format of job, couldn't extract TemplatePaperData from Job[" + jobId + "]!");
				return null;
			}
			if (!isJobLicenseMissing)
			{
				return GetConcurrentJobsMissingLicenseTemplateData();
			}
			return GetJobMissingLicenseTemplateData();
			List<TemplatePaperData> GetConcurrentJobsMissingLicenseTemplateData()
			{
				bool isAcquired = false;
				GeneralLicenseType_v2 generalLicenseType_v = SingletonBehaviour<LicenseManager>.Instance.GetMissingConcurrentJobsLicense();
				if (generalLicenseType_v == null)
				{
					Debug.LogError("Printing missing concurrent license, but license is not missing. Something is wrong");
					generalLicenseType_v = GeneralLicenseType.ConcurrentJobs2.ToV2();
					isAcquired = true;
				}
				List<MissingLicensesPageTemplatePaperData.LicensePrintData> licensesData = new List<MissingLicensesPageTemplatePaperData.LicensePrintData>
				{
					new MissingLicensesPageTemplatePaperData.LicensePrintData(LocalizationAPI.L(generalLicenseType_v.localizationKey), generalLicenseType_v.icon, isAcquired)
				};
				MissingLicensesPageTemplatePaperData item = new MissingLicensesPageTemplatePaperData(jobType, "", jobId, jobColor, licensesData);
				return new List<TemplatePaperData> { item };
			}
			List<TemplatePaperData> GetJobMissingLicenseTemplateData()
			{
				List<MissingLicensesPageTemplatePaperData.LicensePrintData> list = new List<MissingLicensesPageTemplatePaperData.LicensePrintData>();
				JobLicenses requiredLicenses = job.requiredLicenses;
				LicenseManager instance = SingletonBehaviour<LicenseManager>.Instance;
				HashSet<JobLicenseType_v2> missingLicensesForJob = instance.GetMissingLicensesForJob(JobLicenseType_v2.ToV2List(requiredLicenses));
				HashSet<JobLicenseType_v2> acquiredLicensesForJob = instance.GetAcquiredLicensesForJob(JobLicenseType_v2.ToV2List(requiredLicenses));
				foreach (JobLicenseType_v2 item2 in Globals.G.Types.jobLicenses.Where((JobLicenseType_v2 l) => l.v1 != JobLicenses.Basic))
				{
					bool flag = acquiredLicensesForJob.Contains(item2);
					bool flag2 = missingLicensesForJob.Contains(item2);
					if (flag || flag2)
					{
						list.Add(new MissingLicensesPageTemplatePaperData.LicensePrintData(LocalizationAPI.L(item2.localizationKey), item2.icon, flag));
					}
				}
				MissingLicensesPageTemplatePaperData item = new MissingLicensesPageTemplatePaperData(jobType, "", jobId, jobColor, list);
				return new List<TemplatePaperData> { item };
			}
		}
	}
}
