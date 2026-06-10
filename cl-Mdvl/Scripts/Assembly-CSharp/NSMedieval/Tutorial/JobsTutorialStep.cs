using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSMedieval.Manager;
using NSMedieval.State;
using NSMedieval.State.WorkerJobs;
using NSMedieval.UI;
using UnityEngine;

namespace NSMedieval.Tutorial
{
	public class JobsTutorialStep : TutorialStep
	{
		private const string JobsButtonName = "WorkerJobsButton";

		private const string JobsPanelName = "JobPanelManager";

		private const int ResearcherId = -4;

		private const int NonResearcherId = -14;

		private const int ResearcherPriority = 4;

		private Dictionary<int, WorkerJobManager> jobManagers = new Dictionary<int, WorkerJobManager>();

		private JobPanelManager jobPanelManager;

		public JobsTutorialStep(string name, string info)
			: base(name, info)
		{
			Tasks = new List<TutorialStepTask>
			{
				new TutorialStepTask("tut_open_jobs"),
				new TutorialStepTask("tut_set_research_job_priority_1", () => GetResearcher()),
				new TutorialStepTask("tut_set_research_job_priority_2", () => GetNonResearcher())
			};
		}

		private object[] GetResearcher()
		{
			string text = MonoSingleton<WorkerManager>.Instance.AllWorkers.Keys.FirstOrDefault((HumanoidInstance hi) => hi.UniqueId == -4)?.Info.FirstName;
			return new object[1] { text };
		}

		private object[] GetNonResearcher()
		{
			string text = MonoSingleton<WorkerManager>.Instance.AllWorkers.Keys.FirstOrDefault((HumanoidInstance hi) => hi.UniqueId == -14)?.Info.FirstName;
			return new object[1] { text };
		}

		public override void BeginStep()
		{
			base.BeginStep();
			MonoSingleton<UIShowManager>.Instance.ShowWorkersGroup();
			MonoSingleton<UIShowManager>.Instance.ShowTopLeftButtons();
			MonoSingleton<UIController>.Instance.LeftPanelView.SetTopLeftButtonsInteractable(new HashSet<string> { "WorkerJobsButton" }, interactable: true);
			MonoSingleton<TutorialStepManager>.Instance.TutorialInputManager.AllowJobsControls(allow: true);
			MonoSingleton<TutorialViewManager>.Instance.ShowHighlightRect(MonoSingleton<UIController>.Instance.LeftPanelView.GetButtonRect("WorkerJobsButton"));
			MonoSingleton<SceneUIManager>.Instance.PanelToggleEvent += OnPanelToggle;
		}

		protected override void CompleteStep()
		{
			base.CompleteStep();
			MonoSingleton<WorkerController>.Instance.JobPriorityChangedEvent -= OnJobPriorityChanged;
			MonoSingleton<SceneUIManager>.Instance.PanelToggleEvent -= OnPanelToggle;
			jobPanelManager.Hide();
			MonoSingleton<UIController>.Instance.LeftPanelView.SetTopLeftButtonsInteractable(new HashSet<string>(), interactable: true);
			MonoSingleton<TutorialStepManager>.Instance.TutorialInputManager.AllowJobsControls(allow: false);
			MonoSingleton<TutorialViewManager>.Instance.HideHighlightRect();
			foreach (KeyValuePair<int, WorkerJobManager> jobManager in jobManagers)
			{
				jobManager.Value.SetJobTogglesInteractable(new HashSet<JobType>(), interactable: true);
			}
		}

		private void OnPanelToggle(string panelName, bool isOpen)
		{
			if (!(panelName != "JobPanelManager"))
			{
				Log.Trace("Jobs Panel JobPanelManager toggled", "C:\\GIT\\dev\\Assets\\Scripts\\Tutorial\\JobsTutorialStep.cs");
				if (isOpen)
				{
					MonoSingleton<TaskController>.Instance.WaitFor(0.2f).Then(OnPanelOpen);
				}
				else
				{
					OnPanelClose();
				}
			}
		}

		private void OnPanelOpen()
		{
			if (this.jobPanelManager == null)
			{
				PanelBase panelBase = MonoSingleton<SceneUIManager>.Instance.FindPanel("JobPanelManager");
				if (panelBase == null || !(panelBase is JobPanelManager jobPanelManager))
				{
					Log.Error("Jobs Panel JobPanelManager not open", "C:\\GIT\\dev\\Assets\\Scripts\\Tutorial\\JobsTutorialStep.cs");
					return;
				}
				this.jobPanelManager = jobPanelManager;
				Transform transform = jobPanelManager.GetContentGameObject().transform;
				bool isEnabled;
				if (transform == null)
				{
					FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(33, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Tutorial\\JobsTutorialStep.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Could not find content transform ");
						messageBuilder.AppendFormatted(jobPanelManager.GetContentGameObject().name);
					}
					Log.Trace(messageBuilder);
					return;
				}
				WorkerJobManager[] componentsInChildren = transform.GetComponentsInChildren<WorkerJobManager>();
				foreach (WorkerJobManager workerJobManager in componentsInChildren)
				{
					if (workerJobManager.Humanoid == null)
					{
						Log.Error("Humanoid is null, probably JobPanel is not initialized correctly.", "C:\\GIT\\dev\\Assets\\Scripts\\Tutorial\\JobsTutorialStep.cs");
						return;
					}
					FVLogDebugInterpolationHandler messageBuilder2 = new FVLogDebugInterpolationHandler(13, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Tutorial\\JobsTutorialStep.cs");
					if (isEnabled)
					{
						messageBuilder2.AppendLiteral("Job Manager: ");
						messageBuilder2.AppendFormatted(workerJobManager.Humanoid.UniqueId);
					}
					Log.Debug(messageBuilder2);
					jobManagers[workerJobManager.Humanoid.UniqueId] = workerJobManager;
				}
				MonoSingleton<WorkerController>.Instance.JobPriorityChangedEvent += OnJobPriorityChanged;
				CompleteTask(0);
			}
			MonoSingleton<TaskController>.Instance.WaitForUnscaled(0.3f).Then(delegate
			{
				if (!Tasks[1].IsComplete)
				{
					OnSecondTaskStart();
				}
				else if (!Tasks[2].IsComplete)
				{
					OnThirdTaskStart();
				}
			});
		}

		private void OnPanelClose()
		{
			MonoSingleton<TutorialViewManager>.Instance.HideHighlightRect();
		}

		private void OnJobPriorityChanged(HumanoidInstance humanoidInstance, JobType jobType, int priority)
		{
			FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(4, 5, out var isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Tutorial\\JobsTutorialStep.cs");
			if (isEnabled)
			{
				messageBuilder.AppendFormatted(priority);
				messageBuilder.AppendLiteral(" ");
				messageBuilder.AppendFormatted(jobType);
				messageBuilder.AppendLiteral(" ");
				messageBuilder.AppendFormatted(humanoidInstance.UniqueId);
				messageBuilder.AppendLiteral(" ");
				messageBuilder.AppendFormatted(humanoidInstance.Info.FirstName);
				messageBuilder.AppendLiteral(" ");
				messageBuilder.AppendFormatted(humanoidInstance.Info.LastName);
			}
			Log.Trace(messageBuilder);
			if (jobType != JobType.Research)
			{
				return;
			}
			if (humanoidInstance.UniqueId == -4 && !Tasks[1].IsComplete)
			{
				if (priority == 4)
				{
					CompleteTask(1);
					OnThirdTaskStart();
				}
				return;
			}
			if (humanoidInstance.UniqueId == -14 && !Tasks[2].IsComplete)
			{
				if (!humanoidInstance.WorkerBehaviour.IsJobActive(JobType.Research))
				{
					CompleteTask(2);
					MonoSingleton<TutorialViewManager>.Instance.HideHighlightRect();
				}
				return;
			}
			messageBuilder = new FVLogTraceInterpolationHandler(29, 4, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Tutorial\\JobsTutorialStep.cs");
			if (isEnabled)
			{
				messageBuilder.AppendFormatted(humanoidInstance.Info.FirstName);
				messageBuilder.AppendLiteral("(");
				messageBuilder.AppendFormatted(humanoidInstance.UniqueId);
				messageBuilder.AppendLiteral(") Job priority changed to ");
				messageBuilder.AppendFormatted(jobType);
				messageBuilder.AppendLiteral(": ");
				messageBuilder.AppendFormatted(priority);
			}
			Log.Trace(messageBuilder);
		}

		private void OnSecondTaskStart()
		{
			FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(19, 1, out var isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Tutorial\\JobsTutorialStep.cs");
			if (isEnabled)
			{
				messageBuilder.AppendFormatted(jobManagers.Count);
				messageBuilder.AppendLiteral(" Worker JobManagers");
			}
			Log.Trace(messageBuilder);
			foreach (KeyValuePair<int, WorkerJobManager> pair in jobManagers)
			{
				messageBuilder = new FVLogTraceInterpolationHandler(32, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Tutorial\\JobsTutorialStep.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("OnSecondTaskStart: Job Manager: ");
					messageBuilder.AppendFormatted(pair.Key);
				}
				Log.Trace(messageBuilder);
				if (pair.Key == -4)
				{
					pair.Value.SetJobTogglesInteractable(new HashSet<JobType> { JobType.Research }, interactable: true);
					MonoSingleton<TaskController>.Instance.WaitForNextFrame().Then(delegate
					{
						MonoSingleton<TutorialViewManager>.Instance.ShowHighlightRect(pair.Value.GetJobToggleRectTransform(JobType.Research));
					});
				}
				else
				{
					pair.Value.SetJobTogglesInteractable(new HashSet<JobType>(), interactable: true);
				}
			}
		}

		private void OnThirdTaskStart()
		{
			foreach (KeyValuePair<int, WorkerJobManager> pair in jobManagers)
			{
				bool isEnabled;
				FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(31, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Tutorial\\JobsTutorialStep.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("OnThirdTaskStart: Job Manager: ");
					messageBuilder.AppendFormatted(pair.Key);
				}
				Log.Trace(messageBuilder);
				if (pair.Key == -14)
				{
					pair.Value.SetJobTogglesInteractable(new HashSet<JobType> { JobType.Research }, interactable: true);
					MonoSingleton<TaskController>.Instance.WaitForNextFrameUnscaled().Then(delegate
					{
						MonoSingleton<TutorialViewManager>.Instance.ShowHighlightRect(pair.Value.GetJobToggleRectTransform(JobType.Research));
					});
				}
				else
				{
					pair.Value.SetJobTogglesInteractable(new HashSet<JobType>(), interactable: true);
				}
			}
		}
	}
}
