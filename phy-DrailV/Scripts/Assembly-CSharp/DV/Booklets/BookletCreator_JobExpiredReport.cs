using System.Collections.Generic;
using DV.Booklets.Rendered;
using DV.Logic.Job;
using DV.RenderTextureSystem;
using DV.RenderTextureSystem.BookletRender;
using DV.ThingTypes;
using DV.Utils;
using UnityEngine;

namespace DV.Booklets
{
	public class BookletCreator_JobExpiredReport
	{
		public static JobExpiredReport Create(Job job, Vector3 position, Quaternion rotation, Transform parent = null)
		{
			return Create((job == null) ? null : new Job_data(job), position, rotation, parent);
		}

		public static JobExpiredReport Create(Job_data job, Vector3 position, Quaternion rotation, Transform parent = null)
		{
			if (job == null)
			{
				Debug.LogError("Given job reference is null! JobExpired booklet won't display job data");
			}
			string text = job?.ID ?? "";
			GameObject obj = (GameObject)Object.Instantiate(Resources.Load("JobExpiredReport", typeof(GameObject)), position, rotation, parent);
			obj.name = "JobExpiredReport[" + text + "]";
			JobExpiredReport component = obj.GetComponent<JobExpiredReport>();
			component.jobId = text;
			JobExpiredRender component2 = ((GameObject)Object.Instantiate(Resources.Load("JobExpiredRender", typeof(GameObject)), SingletonBehaviour<DV.RenderTextureSystem.RenderTextureSystem>.Instance.transform.position, Quaternion.identity)).GetComponent<JobExpiredRender>();
			obj.GetComponent<RenderedTexturesBase>().RegisterTexturesGeneratedEvent(component2);
			component2.GenerateTextures(GetJobExpiredTemplateData(job).ToArray());
			return component;
		}

		private static List<TemplatePaperData> GetJobExpiredTemplateData(Job_data job)
		{
			string text = job?.ID ?? "";
			string jobType = "";
			Color jobTypeColor = Color.white;
			if (job != null)
			{
				switch (job.type)
				{
				case JobType.Transport:
					jobType = C.HAUL_JOB_TYPE_NAME;
					jobTypeColor = C.HAUL_JOB_TYPE_COLOR;
					break;
				case JobType.ShuntingLoad:
					jobType = C.SHUNTING_JOB_TYPE_NAME;
					jobTypeColor = C.SHUNTING_LOAD_JOB_TYPE_COLOR;
					break;
				case JobType.ShuntingUnload:
					jobType = C.SHUNTING_JOB_TYPE_NAME;
					jobTypeColor = C.SHUNTING_UNLOAD_JOB_TYPE_COLOR;
					break;
				case JobType.EmptyHaul:
					jobType = C.EMPTY_HAUL_JOB_TYPE_NAME;
					jobTypeColor = C.EMPTY_HAUL_JOB_TYPE_COLOR;
					break;
				default:
					Debug.LogError("Unsupported format of job, couldn't extract TemplatePaperData from Job[" + text + "]!");
					return null;
				}
			}
			return new List<TemplatePaperData>
			{
				new JobExpiredTemplatePaperData(jobType, "", text, jobTypeColor)
			};
		}
	}
}
