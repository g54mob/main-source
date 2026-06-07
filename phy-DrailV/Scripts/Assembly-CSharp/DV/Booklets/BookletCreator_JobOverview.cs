using System.Collections.Generic;
using System.Linq;
using DV.Booklets.Rendered;
using DV.Localization;
using DV.Logic.Job;
using DV.RenderTextureSystem;
using DV.RenderTextureSystem.BookletRender;
using DV.ThingTypes;
using DV.Utils;
using UnityEngine;

namespace DV.Booklets
{
	public class BookletCreator_JobOverview
	{
		public static JobOverview Create(Job job, Vector3 position, Quaternion rotation, Transform parent = null)
		{
			JobOverview jobOverview = Create(new Job_data(job), position, rotation, parent).gameObject.AddComponent<JobOverview>();
			jobOverview.job = job;
			return jobOverview;
		}

		public static RenderedTexturesBase Create(Job_data job, Vector3 position, Quaternion rotation, Transform parent = null)
		{
			GameObject obj = (GameObject)Object.Instantiate(Resources.Load("JobOverview", typeof(GameObject)), position, rotation, parent);
			obj.name = "JobOverview[" + job.ID + "]";
			JobOverviewRender component = ((GameObject)Object.Instantiate(Resources.Load("JobOverviewRender", typeof(GameObject)), SingletonBehaviour<DV.RenderTextureSystem.RenderTextureSystem>.Instance.transform.position, Quaternion.identity)).GetComponent<JobOverviewRender>();
			RenderedTexturesBase component2 = obj.GetComponent<RenderedTexturesBase>();
			component2.RegisterTexturesGeneratedEvent(component);
			component.GenerateTextures(GetJobOverviewTemplateData(job).ToArray());
			return component2;
		}

		public static List<TemplatePaperData> GetJobOverviewTemplateData(Job_data job)
		{
			switch (job.type)
			{
			case JobType.Transport:
				return GetJobOverviewTemplatePaperData(JobDataExtractor.ExtractTransportJobData(job));
			case JobType.ShuntingLoad:
				return GetJobOverviewTemplatePaperData(JobDataExtractor.ExtractShuntingLoadJobData(job));
			case JobType.ShuntingUnload:
				return GetJobOverviewTemplatePaperData(JobDataExtractor.ExtractShuntingUnloadJobData(job));
			case JobType.EmptyHaul:
				return GetJobOverviewTemplatePaperData(JobDataExtractor.ExtractEmptyHaulJobData(job));
			default:
				Debug.LogError("Unsupported format of job, couldn't extract TemplatePaperData from Job" + job.ID + "!");
				return null;
			}
		}

		public static List<TemplatePaperData> GetJobOverviewTemplatePaperData(TransportJobData data)
		{
			string jobId = data.job.ID.ToString();
			JobLicenses requiredLicenses = data.job.requiredLicenses;
			List<CargoType> list = data.transportedCargoPerCar.Distinct().ToList();
			List<CargoType> transportedCargoPerCar = data.transportedCargoPerCar;
			StationInfo chainOriginStationInfo = data.job.chainOriginStationInfo;
			StationInfo chainDestinationStationInfo = data.job.chainDestinationStationInfo;
			string timeBonus = ((data.job.timeLimit > 0f) ? (Mathf.FloorToInt(data.job.timeLimit / 60f) + " min") : C.NO_BONUS_TIME_LIMIT_STR);
			string payment = data.job.basePayment.ToString("N0", LocalizationAPI.CC);
			FrontPageTemplatePaperData item = new FrontPageTemplatePaperData(LocalizationAPI.L("job/haul_job_type_name"), trainLength: C.GetCarsTotalLength(data.transportingCars).ToString("N2", LocalizationAPI.CC) + " m", trainMass: (C.GetCarsTotalMass(data.transportingCars, transportedCargoPerCar) * 0.001f).ToString("N2", LocalizationAPI.CC) + " t", jobDescription: C.GetJobDescription(data.job, list), trainValue: "$" + (C.GetTrainValue(data.transportingCars, transportedCargoPerCar) / 1000000f).ToString("N2", LocalizationAPI.CC) + "m", jobSubtype: "", jobId: jobId, jobTypeColor: C.HAUL_JOB_TYPE_COLOR, requiredLicenses: requiredLicenses, distinctCargoTypes: list, cargoTypePerCar: transportedCargoPerCar, singleStationName: "", singleStationType: "", singleStationBgColor: TemplatePaperData.NOT_USED_COLOR, startStationName: LocalizationAPI.L(chainOriginStationInfo.LocalizationKey), startStationType: chainOriginStationInfo.Type, startStationBgColor: chainOriginStationInfo.StationColor, endStationName: LocalizationAPI.L(chainDestinationStationInfo.LocalizationKey), endStationType: chainDestinationStationInfo.Type, endStationBgColor: chainDestinationStationInfo.StationColor, cars: data.transportingCars, timeBonus: timeBonus, payment: payment, pageNumber: "", totalPages: "");
			return new List<TemplatePaperData> { item };
		}

		private static List<TemplatePaperData> GetJobOverviewTemplatePaperData(ShuntingLoadJobData data)
		{
			string jobId = data.job.ID.ToString();
			JobLicenses requiredLicenses = data.job.requiredLicenses;
			List<CargoType> list = data.loadingCargoTypePerCar.Distinct().ToList();
			List<CargoType> loadingCargoTypePerCar = data.loadingCargoTypePerCar;
			StationInfo chainOriginStationInfo = data.job.chainOriginStationInfo;
			StationInfo chainDestinationStationInfo = data.job.chainDestinationStationInfo;
			string timeBonus = ((data.job.timeLimit > 0f) ? (Mathf.FloorToInt(data.job.timeLimit / 60f) + " min") : C.NO_BONUS_TIME_LIMIT_STR);
			string payment = data.job.basePayment.ToString("N0", LocalizationAPI.CC);
			FrontPageTemplatePaperData item = new FrontPageTemplatePaperData(LocalizationAPI.L("job/shunting_job_type_name"), trainLength: C.GetCarsTotalLength(data.allCarsToLoad).ToString("N2", LocalizationAPI.CC) + " m", trainMass: (C.GetCarsTotalMass(data.allCarsToLoad, loadingCargoTypePerCar) * 0.001f).ToString("N2", LocalizationAPI.CC) + " t", jobDescription: C.GetShuntingPickUpsText(data.startingTracksData.Count) + " - " + C.GetJobDescription(data.job, list), trainValue: "$" + (C.GetTrainValue(data.allCarsToLoad, loadingCargoTypePerCar) / 1000000f).ToString("N2", LocalizationAPI.CC) + "m", jobSubtype: "", jobId: jobId, jobTypeColor: C.SHUNTING_LOAD_JOB_TYPE_COLOR, requiredLicenses: requiredLicenses, distinctCargoTypes: list, cargoTypePerCar: loadingCargoTypePerCar, singleStationName: "", singleStationType: "", singleStationBgColor: TemplatePaperData.NOT_USED_COLOR, startStationName: LocalizationAPI.L(chainOriginStationInfo.LocalizationKey), startStationType: chainOriginStationInfo.Type, startStationBgColor: chainOriginStationInfo.StationColor, endStationName: LocalizationAPI.L(chainDestinationStationInfo.LocalizationKey), endStationType: chainDestinationStationInfo.Type, endStationBgColor: chainDestinationStationInfo.StationColor, cars: data.allCarsToLoad, timeBonus: timeBonus, payment: payment, pageNumber: "", totalPages: "");
			return new List<TemplatePaperData> { item };
		}

		private static List<TemplatePaperData> GetJobOverviewTemplatePaperData(ShuntingUnloadJobData data)
		{
			string jobId = data.job.ID.ToString();
			JobLicenses requiredLicenses = data.job.requiredLicenses;
			List<CargoType> list = data.unloadingCargoTypePerCar.Distinct().ToList();
			List<CargoType> unloadingCargoTypePerCar = data.unloadingCargoTypePerCar;
			StationInfo chainOriginStationInfo = data.job.chainOriginStationInfo;
			StationInfo chainDestinationStationInfo = data.job.chainDestinationStationInfo;
			string timeBonus = ((data.job.timeLimit > 0f) ? (Mathf.FloorToInt(data.job.timeLimit / 60f) + " min") : C.NO_BONUS_TIME_LIMIT_STR);
			string payment = data.job.basePayment.ToString("N0", LocalizationAPI.CC);
			FrontPageTemplatePaperData item = new FrontPageTemplatePaperData(LocalizationAPI.L("job/shunting_job_type_name"), trainLength: C.GetCarsTotalLength(data.allCarsToUnload).ToString("N2", LocalizationAPI.CC) + " m", trainMass: (C.GetCarsTotalMass(data.allCarsToUnload, unloadingCargoTypePerCar) * 0.001f).ToString("N2", LocalizationAPI.CC) + " t", jobDescription: C.GetShuntingDropOffsText(data.destinationTracksData.Count) + " - " + C.GetJobDescription(data.job, list), trainValue: "$" + (C.GetTrainValue(data.allCarsToUnload, unloadingCargoTypePerCar) / 1000000f).ToString("N2", LocalizationAPI.CC) + "m", jobSubtype: "", jobId: jobId, jobTypeColor: C.SHUNTING_UNLOAD_JOB_TYPE_COLOR, requiredLicenses: requiredLicenses, distinctCargoTypes: list, cargoTypePerCar: unloadingCargoTypePerCar, singleStationName: "", singleStationType: "", singleStationBgColor: TemplatePaperData.NOT_USED_COLOR, startStationName: LocalizationAPI.L(chainOriginStationInfo.LocalizationKey), startStationType: chainOriginStationInfo.Type, startStationBgColor: chainOriginStationInfo.StationColor, endStationName: LocalizationAPI.L(chainDestinationStationInfo.LocalizationKey), endStationType: chainDestinationStationInfo.Type, endStationBgColor: chainDestinationStationInfo.StationColor, cars: data.allCarsToUnload, timeBonus: timeBonus, payment: payment, pageNumber: "", totalPages: "");
			return new List<TemplatePaperData> { item };
		}

		private static List<TemplatePaperData> GetJobOverviewTemplatePaperData(EmptyHaulJobData data)
		{
			string jobId = data.job.ID.ToString();
			JobLicenses requiredLicenses = data.job.requiredLicenses;
			StationInfo chainOriginStationInfo = data.job.chainOriginStationInfo;
			StationInfo chainDestinationStationInfo = data.job.chainDestinationStationInfo;
			string timeBonus = ((data.job.timeLimit > 0f) ? (Mathf.FloorToInt(data.job.timeLimit / 60f) + " min") : C.NO_BONUS_TIME_LIMIT_STR);
			string payment = data.job.basePayment.ToString("N0", LocalizationAPI.CC);
			FrontPageTemplatePaperData item = new FrontPageTemplatePaperData(LocalizationAPI.L("job/empty_haul_job_type_name"), trainLength: C.GetCarsTotalLength(data.transportingCars).ToString("N2", LocalizationAPI.CC) + " m", trainMass: (C.GetCarsTotalMass(data.transportingCars) * 0.001f).ToString("N2", LocalizationAPI.CC) + " t", jobDescription: C.GetJobDescription(data.job), trainValue: "$" + (C.GetTrainValue(data.transportingCars, null) / 1000000f).ToString("N2", LocalizationAPI.CC) + "m", jobSubtype: "", jobId: jobId, jobTypeColor: C.EMPTY_HAUL_JOB_TYPE_COLOR, requiredLicenses: requiredLicenses, distinctCargoTypes: null, cargoTypePerCar: null, singleStationName: "", singleStationType: "", singleStationBgColor: TemplatePaperData.NOT_USED_COLOR, startStationName: LocalizationAPI.L(chainOriginStationInfo.LocalizationKey), startStationType: chainOriginStationInfo.Type, startStationBgColor: chainOriginStationInfo.StationColor, endStationName: LocalizationAPI.L(chainDestinationStationInfo.LocalizationKey), endStationType: chainDestinationStationInfo.Type, endStationBgColor: chainDestinationStationInfo.StationColor, cars: data.transportingCars, timeBonus: timeBonus, payment: payment, pageNumber: "", totalPages: "");
			return new List<TemplatePaperData> { item };
		}
	}
}
