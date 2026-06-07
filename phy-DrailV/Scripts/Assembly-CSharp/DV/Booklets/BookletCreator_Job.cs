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
	public class BookletCreator_Job
	{
		public static JobBooklet Create(Job job, Vector3 position, Quaternion rotation, Transform parent = null, bool addToWorldStorage = false)
		{
			JobBooklet component = Create(new Job_data(job), position, rotation, parent).GetComponent<JobBooklet>();
			component.AssignJob(job);
			if (addToWorldStorage)
			{
				SingletonBehaviour<StorageController>.Instance.AddItemToWorldStorageAfterOneFrame(component.gameObject);
			}
			return component;
		}

		public static RenderedTexturesBase Create(Job_data job, Vector3 position, Quaternion rotation, Transform parent = null)
		{
			return Render((GameObject)Object.Instantiate(Resources.Load("JobBooklet", typeof(GameObject)), position, rotation, parent), job);
		}

		public static RenderedTexturesBase Render(GameObject existingJobBookletGameObject, Job_data job)
		{
			JobBookletRender component = ((GameObject)Object.Instantiate(Resources.Load("JobBookletRender", typeof(GameObject)), SingletonBehaviour<DV.RenderTextureSystem.RenderTextureSystem>.Instance.transform.position, Quaternion.identity)).GetComponent<JobBookletRender>();
			RenderedTexturesBase component2 = existingJobBookletGameObject.GetComponent<RenderedTexturesBase>();
			component2.RegisterTexturesGeneratedEvent(component);
			component.GenerateTextures(GetBookletTemplateData(job).ToArray());
			return component2;
		}

		private static List<TemplatePaperData> GetBookletTemplateData(Job_data job)
		{
			List<TemplatePaperData> result;
			switch (job.type)
			{
			case JobType.Transport:
				result = InitializeTransportJobBooklet(JobDataExtractor.ExtractTransportJobData(job));
				break;
			case JobType.ShuntingLoad:
				result = InitializeShuntingLoadJobBooklet(JobDataExtractor.ExtractShuntingLoadJobData(job));
				break;
			case JobType.ShuntingUnload:
				result = InitializeShuntingUnloadJobBooklet(JobDataExtractor.ExtractShuntingUnloadJobData(job));
				break;
			case JobType.EmptyHaul:
				result = InitializeEmptyHaulJobBooklet(JobDataExtractor.ExtractEmptyHaulJobData(job));
				break;
			case JobType.ComplexTransport:
				result = null;
				Debug.LogError("Unsupported format of job, couldn't extract templatePaperData from Job" + job.ID + "!");
				break;
			case JobType.Custom:
				result = null;
				Debug.LogError("Unsupported format of job, couldn't extract templatePaperData from Job" + job.ID + "!");
				break;
			default:
				result = null;
				Debug.LogError("Unsupported format of job, couldn't extract templatePaperData from Job" + job.ID + "!");
				break;
			}
			return result;
		}

		private static List<TemplatePaperData> InitializeTransportJobBooklet(TransportJobData data)
		{
			List<TemplatePaperData> list = new List<TemplatePaperData>();
			string text = data.job.ID.ToString();
			JobLicenses requiredLicenses = data.job.requiredLicenses;
			List<CargoType> list2 = data.transportedCargoPerCar.Distinct().ToList();
			List<CargoType> transportedCargoPerCar = data.transportedCargoPerCar;
			StationInfo chainOriginStationInfo = data.job.chainOriginStationInfo;
			StationInfo chainDestinationStationInfo = data.job.chainDestinationStationInfo;
			string trackPartOnly = data.startingTrack.TrackPartOnly;
			string trackPartOnly2 = data.destinationTrack.TrackPartOnly;
			string timeBonus = ((data.job.timeLimit > 0f) ? (Mathf.FloorToInt(data.job.timeLimit / 60f) + " min") : C.NO_BONUS_TIME_LIMIT_STR);
			string payment = data.job.basePayment.ToString("N0", LocalizationAPI.CC);
			string jobType = LocalizationAPI.L("job/haul_job_cover_page");
			int num = 1;
			int totalPages = 6;
			CoverPageTemplatePaperData item = new CoverPageTemplatePaperData(text, jobType, num.ToString(), totalPages.ToString());
			list.Add(item);
			num++;
			FrontPageTemplatePaperData item2 = new FrontPageTemplatePaperData(trainLength: C.GetCarsTotalLength(data.transportingCars).ToString("N2", LocalizationAPI.CC) + " m", trainMass: (C.GetCarsTotalMass(data.transportingCars, transportedCargoPerCar) * 0.001f).ToString("N2", LocalizationAPI.CC) + " t", jobDescription: C.GetJobDescription(data.job, list2), trainValue: "$" + (C.GetTrainValue(data.transportingCars, transportedCargoPerCar) / 1000000f).ToString("N2", LocalizationAPI.CC) + "m", jobType: LocalizationAPI.L("job/haul_job_type_name"), jobSubtype: "", jobId: text, jobTypeColor: C.HAUL_JOB_TYPE_COLOR, requiredLicenses: requiredLicenses, distinctCargoTypes: list2, cargoTypePerCar: transportedCargoPerCar, singleStationName: "", singleStationType: "", singleStationBgColor: TemplatePaperData.NOT_USED_COLOR, startStationName: LocalizationAPI.L(chainOriginStationInfo.LocalizationKey), startStationType: chainOriginStationInfo.Type, startStationBgColor: chainOriginStationInfo.StationColor, endStationName: LocalizationAPI.L(chainDestinationStationInfo.LocalizationKey), endStationType: chainDestinationStationInfo.Type, endStationBgColor: chainDestinationStationInfo.StationColor, cars: data.transportingCars, timeBonus: timeBonus, payment: payment, pageNumber: num.ToString(), totalPages: totalPages.ToString());
			list.Add(item2);
			num++;
			int num2 = 1;
			TaskTemplatePaperData item3 = CreateCoupleTaskPaperData(num2, chainOriginStationInfo.YardID, chainOriginStationInfo.StationColor, trackPartOnly, data.transportingCars, transportedCargoPerCar, num, totalPages);
			list.Add(item3);
			num++;
			num2++;
			TaskTemplatePaperData item4 = new TaskTemplatePaperData(taskType: LocalizationAPI.L("job/task_type_haul"), taskDescription: LocalizationAPI.L("job/task_desc_haul"), stepNum: num2.ToString(), yardId: "", yardColor: TemplatePaperData.NOT_USED_COLOR, trackId: "", trackColor: TemplatePaperData.NOT_USED_COLOR, stationName: LocalizationAPI.L(chainDestinationStationInfo.LocalizationKey), stationType: chainDestinationStationInfo.Type, stationColor: chainDestinationStationInfo.StationColor, cars: data.transportingCars, cargoTypePerCar: transportedCargoPerCar, pageNumber: num.ToString(), totalPages: totalPages.ToString());
			list.Add(item4);
			num++;
			num2++;
			TaskTemplatePaperData item5 = CreateUncoupleTaskPaperData(num2, chainDestinationStationInfo.YardID, chainDestinationStationInfo.StationColor, trackPartOnly2, data.transportingCars, transportedCargoPerCar, num, totalPages);
			list.Add(item5);
			num++;
			num2++;
			list.Add(CreateValidateJobTaskPaperData(num2, num, totalPages));
			return list;
		}

		private static List<TemplatePaperData> InitializeShuntingLoadJobBooklet(ShuntingLoadJobData data)
		{
			List<TemplatePaperData> list = new List<TemplatePaperData>();
			string text = data.job.ID.ToString();
			JobLicenses requiredLicenses = data.job.requiredLicenses;
			List<CargoType> list2 = data.loadingCargoTypePerCar.Distinct().ToList();
			List<CargoType> loadingCargoTypePerCar = data.loadingCargoTypePerCar;
			StationInfo chainOriginStationInfo = data.job.chainOriginStationInfo;
			StationInfo chainDestinationStationInfo = data.job.chainDestinationStationInfo;
			string timeBonus = ((data.job.timeLimit > 0f) ? (Mathf.FloorToInt(data.job.timeLimit / 60f) + " min") : C.NO_BONUS_TIME_LIMIT_STR);
			string payment = data.job.basePayment.ToString("N0", LocalizationAPI.CC);
			string jobType = LocalizationAPI.L("job/shunting_job_cover_page");
			int count = data.startingTracksData.Count;
			int totalPages = 2 + count + 3;
			int num = 1;
			CoverPageTemplatePaperData item = new CoverPageTemplatePaperData(text, jobType, num.ToString(), totalPages.ToString());
			list.Add(item);
			num++;
			string trainLength = C.GetCarsTotalLength(data.allCarsToLoad).ToString("N2", LocalizationAPI.CC) + " m";
			string trainMass = (C.GetCarsTotalMass(data.allCarsToLoad, loadingCargoTypePerCar) * 0.001f).ToString("N2", LocalizationAPI.CC) + " t";
			string jobDescription = C.GetShuntingPickUpsText(count) + " - " + C.GetJobDescription(data.job, list2);
			string trainValue = "$" + (C.GetTrainValue(data.allCarsToLoad, loadingCargoTypePerCar) / 1000000f).ToString("N2", LocalizationAPI.CC) + "m";
			FrontPageTemplatePaperData item2 = new FrontPageTemplatePaperData(LocalizationAPI.L("job/shunting_job_type_name"), "", text, C.SHUNTING_LOAD_JOB_TYPE_COLOR, jobDescription, requiredLicenses, list2, loadingCargoTypePerCar, "", "", TemplatePaperData.NOT_USED_COLOR, LocalizationAPI.L(chainOriginStationInfo.LocalizationKey), chainOriginStationInfo.Type, chainOriginStationInfo.StationColor, LocalizationAPI.L(chainDestinationStationInfo.LocalizationKey), chainDestinationStationInfo.Type, chainDestinationStationInfo.StationColor, data.allCarsToLoad, trainLength, trainMass, trainValue, timeBonus, payment, num.ToString(), totalPages.ToString());
			list.Add(item2);
			num++;
			int num2 = 1;
			for (int i = 0; i < data.startingTracksData.Count; i++)
			{
				string trackPartOnly = data.startingTracksData[i].track.TrackPartOnly;
				TaskTemplatePaperData item3 = CreateCoupleTaskPaperData(num2, chainOriginStationInfo.YardID, chainOriginStationInfo.StationColor, trackPartOnly, data.startingTracksData[i].cars, null, num, totalPages);
				list.Add(item3);
				num++;
			}
			num2++;
			string trackPartOnly2 = data.loadMachineTrack.TrackPartOnly;
			string taskType = LocalizationAPI.L("job/task_type_load");
			string taskDescription = LocalizationAPI.L("job/task_desc_load");
			TaskTemplatePaperData item4 = new TaskTemplatePaperData(num2.ToString(), taskType, taskDescription, chainOriginStationInfo.YardID, chainOriginStationInfo.StationColor, trackPartOnly2, C.TRACK_COLOR, "", "", TemplatePaperData.NOT_USED_COLOR, data.allCarsToLoad, null, num.ToString(), totalPages.ToString());
			list.Add(item4);
			num++;
			num2++;
			string trackPartOnly3 = data.destinationTrack.TrackPartOnly;
			TaskTemplatePaperData item5 = CreateUncoupleTaskPaperData(num2, chainOriginStationInfo.YardID, chainOriginStationInfo.StationColor, trackPartOnly3, data.allCarsToLoad, loadingCargoTypePerCar, num, totalPages);
			list.Add(item5);
			num++;
			num2++;
			list.Add(CreateValidateJobTaskPaperData(num2, num, totalPages));
			return list;
		}

		private static List<TemplatePaperData> InitializeShuntingUnloadJobBooklet(ShuntingUnloadJobData data)
		{
			List<TemplatePaperData> list = new List<TemplatePaperData>();
			string text = data.job.ID.ToString();
			JobLicenses requiredLicenses = data.job.requiredLicenses;
			List<CargoType> list2 = data.unloadingCargoTypePerCar.Distinct().ToList();
			List<CargoType> unloadingCargoTypePerCar = data.unloadingCargoTypePerCar;
			StationInfo chainOriginStationInfo = data.job.chainOriginStationInfo;
			StationInfo chainDestinationStationInfo = data.job.chainDestinationStationInfo;
			string timeBonus = ((data.job.timeLimit > 0f) ? (Mathf.FloorToInt(data.job.timeLimit / 60f) + " min") : C.NO_BONUS_TIME_LIMIT_STR);
			string payment = data.job.basePayment.ToString("N0", LocalizationAPI.CC);
			string jobType = LocalizationAPI.L("job/shunting_job_cover_page");
			int count = data.destinationTracksData.Count;
			int totalPages = 4 + count + 1;
			int num = 1;
			CoverPageTemplatePaperData item = new CoverPageTemplatePaperData(text, jobType, num.ToString(), totalPages.ToString());
			list.Add(item);
			num++;
			string trainLength = C.GetCarsTotalLength(data.allCarsToUnload).ToString("N2", LocalizationAPI.CC) + " m";
			string trainMass = (C.GetCarsTotalMass(data.allCarsToUnload, unloadingCargoTypePerCar) * 0.001f).ToString("N2", LocalizationAPI.CC) + " t";
			string jobDescription = C.GetShuntingDropOffsText(count) + " - " + C.GetJobDescription(data.job, list2);
			string trainValue = "$" + (C.GetTrainValue(data.allCarsToUnload, unloadingCargoTypePerCar) / 1000000f).ToString("N2", LocalizationAPI.CC) + "m";
			FrontPageTemplatePaperData item2 = new FrontPageTemplatePaperData(LocalizationAPI.L("job/shunting_job_type_name"), "", text, C.SHUNTING_UNLOAD_JOB_TYPE_COLOR, jobDescription, requiredLicenses, list2, unloadingCargoTypePerCar, "", "", TemplatePaperData.NOT_USED_COLOR, LocalizationAPI.L(chainOriginStationInfo.LocalizationKey), chainOriginStationInfo.Type, chainOriginStationInfo.StationColor, LocalizationAPI.L(chainDestinationStationInfo.LocalizationKey), chainDestinationStationInfo.Type, chainDestinationStationInfo.StationColor, data.allCarsToUnload, trainLength, trainMass, trainValue, timeBonus, payment, num.ToString(), totalPages.ToString());
			list.Add(item2);
			num++;
			int num2 = 1;
			string trackPartOnly = data.startingTrack.TrackPartOnly;
			TaskTemplatePaperData item3 = CreateCoupleTaskPaperData(num2, chainDestinationStationInfo.YardID, chainDestinationStationInfo.StationColor, trackPartOnly, data.allCarsToUnload, unloadingCargoTypePerCar, num, totalPages);
			list.Add(item3);
			num++;
			num2++;
			string trackPartOnly2 = data.unloadMachineTrack.TrackPartOnly;
			string taskType = LocalizationAPI.L("job/task_type_unload");
			string taskDescription = LocalizationAPI.L("job/task_desc_unload");
			TaskTemplatePaperData item4 = new TaskTemplatePaperData(num2.ToString(), taskType, taskDescription, chainDestinationStationInfo.YardID, chainDestinationStationInfo.StationColor, trackPartOnly2, C.TRACK_COLOR, "", "", TemplatePaperData.NOT_USED_COLOR, data.allCarsToUnload, unloadingCargoTypePerCar, num.ToString(), totalPages.ToString());
			list.Add(item4);
			num++;
			num2++;
			for (int i = 0; i < data.destinationTracksData.Count; i++)
			{
				string trackPartOnly3 = data.destinationTracksData[i].track.TrackPartOnly;
				TaskTemplatePaperData item5 = CreateUncoupleTaskPaperData(num2, chainDestinationStationInfo.YardID, chainDestinationStationInfo.StationColor, trackPartOnly3, data.destinationTracksData[i].cars, null, num, totalPages);
				list.Add(item5);
				num++;
			}
			num2++;
			list.Add(CreateValidateJobTaskPaperData(num2, num, totalPages));
			return list;
		}

		private static List<TemplatePaperData> InitializeEmptyHaulJobBooklet(EmptyHaulJobData data)
		{
			List<TemplatePaperData> list = new List<TemplatePaperData>();
			string text = data.job.ID.ToString();
			JobLicenses requiredLicenses = data.job.requiredLicenses;
			StationInfo chainOriginStationInfo = data.job.chainOriginStationInfo;
			StationInfo chainDestinationStationInfo = data.job.chainDestinationStationInfo;
			string timeBonus = ((data.job.timeLimit > 0f) ? (Mathf.FloorToInt(data.job.timeLimit / 60f) + " min") : C.NO_BONUS_TIME_LIMIT_STR);
			string payment = data.job.basePayment.ToString("N0", LocalizationAPI.CC);
			string jobType = LocalizationAPI.L("job/empty_haul_job_cover_page");
			int num = 1;
			int totalPages = 6;
			CoverPageTemplatePaperData item = new CoverPageTemplatePaperData(text, jobType, num.ToString(), totalPages.ToString());
			list.Add(item);
			num++;
			FrontPageTemplatePaperData item2 = new FrontPageTemplatePaperData(trainLength: C.GetCarsTotalLength(data.transportingCars).ToString("N2", LocalizationAPI.CC) + " m", trainMass: (C.GetCarsTotalMass(data.transportingCars) * 0.001f).ToString("N2", LocalizationAPI.CC) + " t", jobDescription: C.GetJobDescription(data.job), trainValue: "$" + (C.GetTrainValue(data.transportingCars, null) / 1000000f).ToString("N2", LocalizationAPI.CC) + "m", jobType: LocalizationAPI.L("job/empty_haul_job_type_name"), jobSubtype: "", jobId: text, jobTypeColor: C.EMPTY_HAUL_JOB_TYPE_COLOR, requiredLicenses: requiredLicenses, distinctCargoTypes: null, cargoTypePerCar: null, singleStationName: "", singleStationType: "", singleStationBgColor: TemplatePaperData.NOT_USED_COLOR, startStationName: LocalizationAPI.L(chainOriginStationInfo.LocalizationKey), startStationType: chainOriginStationInfo.Type, startStationBgColor: chainOriginStationInfo.StationColor, endStationName: LocalizationAPI.L(chainDestinationStationInfo.LocalizationKey), endStationType: chainDestinationStationInfo.Type, endStationBgColor: chainDestinationStationInfo.StationColor, cars: data.transportingCars, timeBonus: timeBonus, payment: payment, pageNumber: num.ToString(), totalPages: totalPages.ToString());
			list.Add(item2);
			num++;
			int num2 = 1;
			TaskTemplatePaperData item3 = CreateCoupleTaskPaperData(trackId: data.startingTrack.TrackPartOnly, step: num2, yardID: chainOriginStationInfo.YardID, yardColor: chainOriginStationInfo.StationColor, cars: data.transportingCars, cargoTypePerCar: null, pageNum: num, totalPages: totalPages);
			list.Add(item3);
			num++;
			num2++;
			TaskTemplatePaperData item4 = new TaskTemplatePaperData(taskType: LocalizationAPI.L("job/task_type_haul"), taskDescription: LocalizationAPI.L("job/task_desc_haul"), stepNum: num2.ToString(), yardId: "", yardColor: TemplatePaperData.NOT_USED_COLOR, trackId: "", trackColor: TemplatePaperData.NOT_USED_COLOR, stationName: LocalizationAPI.L(chainDestinationStationInfo.LocalizationKey), stationType: chainDestinationStationInfo.Type, stationColor: chainDestinationStationInfo.StationColor, cars: data.transportingCars, cargoTypePerCar: null, pageNumber: num.ToString(), totalPages: totalPages.ToString());
			list.Add(item4);
			num++;
			num2++;
			TaskTemplatePaperData item5 = CreateUncoupleTaskPaperData(trackId: data.destinationTrack.TrackPartOnly, step: num2, yardID: chainDestinationStationInfo.YardID, yardColor: chainDestinationStationInfo.StationColor, cars: data.transportingCars, cargoTypePerCar: null, pageNum: num, totalPages: totalPages);
			list.Add(item5);
			num++;
			num2++;
			list.Add(CreateValidateJobTaskPaperData(num2, num, totalPages));
			return list;
		}

		private static ValidateJobTaskTemplatePaperData CreateValidateJobTaskPaperData(int step, int pageNum, int totalPages)
		{
			return new ValidateJobTaskTemplatePaperData(step.ToString(), pageNum.ToString(), totalPages.ToString());
		}

		private static TaskTemplatePaperData CreateCoupleTaskPaperData(int step, string yardID, Color yardColor, string trackId, List<Car_data> cars, List<CargoType> cargoTypePerCar, int pageNum, int totalPages)
		{
			string taskType = LocalizationAPI.L("job/task_type_couple");
			string taskDescription = LocalizationAPI.L("job/task_desc_couple");
			return new TaskTemplatePaperData(step.ToString(), taskType, taskDescription, yardID, yardColor, trackId, C.TRACK_COLOR, "", "", TemplatePaperData.NOT_USED_COLOR, cars, cargoTypePerCar, pageNum.ToString(), totalPages.ToString());
		}

		private static TaskTemplatePaperData CreateUncoupleTaskPaperData(int step, string yardID, Color yardColor, string trackId, List<Car_data> cars, List<CargoType> cargoTypePerCar, int pageNum, int totalPages)
		{
			string taskType = LocalizationAPI.L("job/task_type_uncouple");
			string taskDescription = LocalizationAPI.L("job/task_desc_uncouple");
			return new TaskTemplatePaperData(step.ToString(), taskType, taskDescription, yardID, yardColor, trackId, C.TRACK_COLOR, "", "", TemplatePaperData.NOT_USED_COLOR, cars, cargoTypePerCar, pageNum.ToString(), totalPages.ToString());
		}
	}
}
