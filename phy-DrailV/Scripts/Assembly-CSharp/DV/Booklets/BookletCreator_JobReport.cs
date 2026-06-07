using System;
using System.Collections.Generic;
using System.Linq;
using DV.Localization;
using DV.Logic.Job;
using DV.RenderTextureSystem;
using DV.RenderTextureSystem.BookletRender;
using DV.ServicePenalty;
using DV.ThingTypes;
using DV.ThingTypes.TransitionHelpers;
using DV.Utils;
using UnityEngine;

namespace DV.Booklets
{
	public class BookletCreator_JobReport
	{
		public static JobReport Create(Job job, DisplayableDebt debt, Vector3 position, Quaternion rotation, Transform parent = null)
		{
			Debt_data debt2 = ((debt == null) ? null : new Debt_data(debt));
			return Create(new Job_data(job), debt2, position, rotation, parent);
		}

		public static JobReport Create(Job_data job, Debt_data debt, Vector3 position, Quaternion rotation, Transform parent = null)
		{
			GameObject obj = (GameObject)UnityEngine.Object.Instantiate(Resources.Load("JobReport", typeof(GameObject)), position, rotation, parent);
			obj.name = "JobReport[" + job.ID + "]";
			JobReport component = obj.GetComponent<JobReport>();
			component.jobID = job.ID;
			int numberOfAdditionalPages = debt?.GetNumberOfPagesForDebt(filterOutUnchangedDebts: true, C.ENVIRONMENT_DAMAGE_TYPES_CARGO) ?? 2;
			List<TemplatePaperData> reportTemplateData = GetReportTemplateData(job, numberOfAdditionalPages);
			JobReportRender component2 = ((GameObject)UnityEngine.Object.Instantiate(Resources.Load("JobReportRender", typeof(GameObject)), SingletonBehaviour<DV.RenderTextureSystem.RenderTextureSystem>.Instance.transform.position, Quaternion.identity)).GetComponent<JobReportRender>();
			component.RegisterTexturesGeneratedEvent(component2);
			component2.GenerateTextures(reportTemplateData.ToArray());
			int count = reportTemplateData.Count;
			if (debt != null && debt.totalPrice > 0f)
			{
				string renderPrefabNameForDebtType = BookletCreator_Debt.GetRenderPrefabNameForDebtType(debt.debtType);
				if (renderPrefabNameForDebtType != string.Empty)
				{
					FeesBookletRender component3 = ((GameObject)UnityEngine.Object.Instantiate(Resources.Load(renderPrefabNameForDebtType, typeof(GameObject)), SingletonBehaviour<DV.RenderTextureSystem.RenderTextureSystem>.Instance.transform.position, Quaternion.identity)).GetComponent<FeesBookletRender>();
					component.RegisterTexturesGeneratedEvent(component3);
					List<TemplatePaperData> debtBookletTemplateData = BookletCreator_Debt.GetDebtBookletTemplateData(debt, count + 1, count);
					component3.GenerateTextures(debtBookletTemplateData.ToArray());
				}
				else
				{
					Debug.LogError("No fees report will be added to job report!");
				}
			}
			else
			{
				FeesNoDamageBookletRender component4 = ((GameObject)UnityEngine.Object.Instantiate(Resources.Load("FeesNoDamageRender", typeof(GameObject)), SingletonBehaviour<DV.RenderTextureSystem.RenderTextureSystem>.Instance.transform.position, Quaternion.identity)).GetComponent<FeesNoDamageBookletRender>();
				component.RegisterTexturesGeneratedEvent(component4);
				List<TemplatePaperData> noFeesDebtBookletTemplateData = BookletCreator_Debt.GetNoFeesDebtBookletTemplateData(job.ID, count + 1, count);
				component4.GenerateTextures(noFeesDebtBookletTemplateData.ToArray());
			}
			return component;
		}

		private static List<TemplatePaperData> GetReportTemplateData(Job_data data, int numberOfAdditionalPages = 0)
		{
			List<TemplatePaperData> list = new List<TemplatePaperData>();
			bool flag = data.state == JobState.Completed;
			string jobState = (flag ? LocalizationAPI.L("job/complete") : LocalizationAPI.L("job/in_progress"));
			Color jobStateBgColor = (flag ? C.JOB_REPORT_COMPLETE_COLOR : C.JOB_REPORT_IN_PROGRESS_COLOR);
			string elapsedTime = (flag ? Mathf.FloorToInt(data.completionTime / 60f) : Mathf.FloorToInt(data.timeOnJob / 60f)) + " min";
			string bonusTime = ((data.timeLimit > 0f) ? (Mathf.FloorToInt(data.timeLimit / 60f) + " min") : C.NO_BONUS_TIME_LIMIT_STR);
			string expirationTime = "";
			string totalPaymentText = (flag ? LocalizationAPI.L("job/fee_total") : LocalizationAPI.L("job/potential_total"));
			Task_data[] tasksData = data.tasksData;
			bool showWarning = true;
			List<JobReportTasksTemplatePaperData.JobReportEntry> list2 = ExtractTaskInfo(tasksData, ref showWarning);
			string description = LocalizationAPI.L("job/validate_job");
			string timestamp = (flag ? TimeSpan.FromSeconds(data.completionTime).ToString("hh\\:mm\\:ss") : "");
			JobReportTasksTemplatePaperData.EntryState state = (flag ? JobReportTasksTemplatePaperData.EntryState.COMPLETED : JobReportTasksTemplatePaperData.EntryState.IN_PROGRESS);
			list2.Add(new JobReportTasksTemplatePaperData.JobReportEntry(description, timestamp, state));
			int num = list2.Count - 5;
			int num2 = ((num > 0) ? Mathf.CeilToInt((float)num / 9f) : 0);
			int num3 = 1;
			int num4 = numberOfAdditionalPages;
			num4 += 1 + num2 + 1;
			int count = Math.Min(list2.Count, 5);
			List<JobReportTasksTemplatePaperData.JobReportEntry> range = list2.GetRange(0, count);
			list2.RemoveRange(0, count);
			JobReportOverviewTemplatePaperData item = new JobReportOverviewTemplatePaperData(data.ID, jobState, jobStateBgColor, flag, elapsedTime, bonusTime, expirationTime, "$" + data.basePayment.ToString("N0", LocalizationAPI.CC), range, num3.ToString(), num4.ToString());
			list.Add(item);
			num3++;
			while (list2.Count > 0)
			{
				int count2 = Math.Min(list2.Count, 9);
				List<JobReportTasksTemplatePaperData.JobReportEntry> range2 = list2.GetRange(0, count2);
				list2.RemoveRange(0, count2);
				JobReportTasksTemplatePaperData item2 = new JobReportTasksTemplatePaperData(range2, num3.ToString(), num4.ToString());
				list.Add(item2);
				num3++;
			}
			string expirationPenalty = "/";
			JobReportPaymentTemplatePaperData item3 = new JobReportPaymentTemplatePaperData("+$" + data.basePayment.ToString("N0", LocalizationAPI.CC), "+$" + data.bonusPayment.ToString("N0", LocalizationAPI.CC), expirationPenalty, ((data.totalPayment >= 0f) ? "+$" : "-$") + data.totalPayment.ToString("N0", LocalizationAPI.CC), totalPaymentText, num3.ToString(), num4.ToString());
			list.Add(item3);
			num3++;
			return list;
		}

		private static List<JobReportTasksTemplatePaperData.JobReportEntry> ExtractTaskInfo(Task_data[] tasksData, ref bool showWarning)
		{
			List<JobReportTasksTemplatePaperData.JobReportEntry> list = new List<JobReportTasksTemplatePaperData.JobReportEntry>();
			string empty = string.Empty;
			foreach (Task_data task_data in tasksData)
			{
				switch (task_data.type)
				{
				case TaskType.Transport:
				{
					bool num3 = task_data.state == TaskState.Done;
					bool flag4 = false;
					if (!num3 & showWarning)
					{
						bool num4 = task_data.cars.Any((Car_data car) => car.derailed);
						bool flag5 = task_data.cars.Any((Car_data car) => car.isOnDestinationTrack);
						bool flag6 = task_data.cars.All((Car_data car) => car.isOnDestinationTrack);
						if (num4)
						{
							list.Add(new JobReportTasksTemplatePaperData.JobReportEntry(LocalizationAPI.L("job/report_derailed"), empty, JobReportTasksTemplatePaperData.EntryState.WARNING));
							showWarning = false;
							flag4 = true;
						}
						else if (flag5 && !flag6)
						{
							list.Add(new JobReportTasksTemplatePaperData.JobReportEntry(LocalizationAPI.L("job/report_missing"), empty, JobReportTasksTemplatePaperData.EntryState.WARNING));
							showWarning = false;
							flag4 = true;
						}
						else if (flag6)
						{
							if (task_data.couplingRequiredAndNotDone)
							{
								list.Add(new JobReportTasksTemplatePaperData.JobReportEntry(LocalizationAPI.L("job/report_not_coupled"), empty, JobReportTasksTemplatePaperData.EntryState.WARNING));
								showWarning = false;
								flag4 = true;
							}
							else if (task_data.anyHandbrakeRequiredAndNotDone)
							{
								list.Add(new JobReportTasksTemplatePaperData.JobReportEntry(LocalizationAPI.L("job/report_apply_handbrake"), empty, JobReportTasksTemplatePaperData.EntryState.WARNING));
								showWarning = false;
								flag4 = true;
							}
						}
					}
					string text2 = LocalizationAPI.L("job/report_move_cars", task_data.startTrackID.FullDisplayID, task_data.destinationTrackID.FullDisplayID);
					string timestamp2 = (num3 ? TimeSpan.FromSeconds(task_data.taskFinishTime - task_data.taskStartTime).ToString("hh\\:mm\\:ss") : "");
					JobReportTasksTemplatePaperData.EntryState state2 = (num3 ? JobReportTasksTemplatePaperData.EntryState.COMPLETED : JobReportTasksTemplatePaperData.EntryState.IN_PROGRESS);
					if (flag4)
					{
						text2 += LocalizationAPI.L("job/report_see_warnings");
						state2 = JobReportTasksTemplatePaperData.EntryState.IN_PROGRESS_WITH_X_MARK;
					}
					JobReportTasksTemplatePaperData.JobReportEntry item2 = new JobReportTasksTemplatePaperData.JobReportEntry(text2, timestamp2, state2);
					if (flag4)
					{
						list.Insert(list.Count - 1, item2);
					}
					else
					{
						list.Add(item2);
					}
					break;
				}
				case TaskType.Warehouse:
				{
					bool num = task_data.state == TaskState.Done;
					bool flag = false;
					if (!num & showWarning)
					{
						bool num2 = task_data.cars.Any((Car_data car) => car.derailed);
						bool flag2 = task_data.cars.Any((Car_data car) => !car.isOnDestinationTrack);
						bool flag3 = task_data.cars.Any((Car_data car) => car.isOnDestinationTrack);
						if (num2)
						{
							list.Add(new JobReportTasksTemplatePaperData.JobReportEntry(LocalizationAPI.L("job/report_derailed"), empty, JobReportTasksTemplatePaperData.EntryState.WARNING));
							showWarning = false;
							flag = true;
						}
						else if (flag2 && flag3)
						{
							list.Add(new JobReportTasksTemplatePaperData.JobReportEntry(LocalizationAPI.L("job/report_missing"), empty, JobReportTasksTemplatePaperData.EntryState.WARNING));
							showWarning = false;
							flag = true;
						}
					}
					string text = LocalizationAPI.L(firstParamValue: LocalizationAPI.L(task_data.cargoTypePerCar[0].ToV2().localizationKeyShort), translationKey: (task_data.warehouseTaskType == WarehouseTaskType.Loading) ? "job/report_load_cars" : "job/report_unload_cars", secondParamValue: task_data.destinationTrackID.FullDisplayID);
					string timestamp = ((task_data.state == TaskState.Done) ? TimeSpan.FromSeconds(task_data.taskFinishTime - task_data.taskStartTime).ToString("hh\\:mm\\:ss") : "");
					JobReportTasksTemplatePaperData.EntryState state = (num ? JobReportTasksTemplatePaperData.EntryState.COMPLETED : JobReportTasksTemplatePaperData.EntryState.IN_PROGRESS);
					if (flag)
					{
						text += LocalizationAPI.L("job/report_see_warnings");
						state = JobReportTasksTemplatePaperData.EntryState.IN_PROGRESS_WITH_X_MARK;
					}
					JobReportTasksTemplatePaperData.JobReportEntry item = new JobReportTasksTemplatePaperData.JobReportEntry(text, timestamp, state);
					if (flag)
					{
						list.Insert(list.Count - 1, item);
					}
					else
					{
						list.Add(item);
					}
					break;
				}
				case TaskType.Sequential:
				case TaskType.Parallel:
				{
					List<JobReportTasksTemplatePaperData.JobReportEntry> collection = ExtractTaskInfo(task_data.nestedTasks, ref showWarning);
					list.AddRange(collection);
					break;
				}
				}
			}
			return list;
		}
	}
}
