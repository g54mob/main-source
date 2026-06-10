using System;
using System.Collections.Generic;
using FoxyVoxel.Logging;
using NSEipix.Base;
using NSEipix.Repository;
using NSEipix.View.UI;
using NSMedieval.Controllers;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.State;
using NSMedieval.State.WorkerJobs;
using NSMedieval.UI.Utils;
using TMPro;
using UnityEngine;

namespace NSMedieval.UI
{
	public class JobPanelManager : WorkerPanelManager
	{
		[SerializeField]
		private Transform jobNameParent;

		[SerializeField]
		private GameObject jobNamePrefab;

		[SerializeField]
		private float elementBaseWidth;

		[SerializeField]
		private float variableElementWidth;

		private List<JobPrioritySettings> copiedJobs = new List<JobPrioritySettings>();

		public List<JobPrioritySettings> CopiedJobs
		{
			get
			{
				return copiedJobs;
			}
			set
			{
				copiedJobs = value;
				if (MonoSingleton<UIController>.IsInstantiated())
				{
					MonoSingleton<UIController>.Instance.OnCopyJobSettings();
				}
			}
		}

		public List<JobType> Jobs { get; } = new List<JobType>();

		public void ClearCopiedSettings()
		{
			copiedJobs.Clear();
			MonoSingleton<UIController>.Instance.OnCopyJobSettings();
		}

		public override void PasteToWorker(HumanoidInstance worker)
		{
			if (CopiedJobs == null || CopiedJobs.Count == 0)
			{
				return;
			}
			foreach (JobPrioritySettings copiedJob in CopiedJobs)
			{
				int jobPriorityTruncated = worker.WorkerBehaviour.GetJobPriorityTruncated(copiedJob.GetJobType);
				int valueToAdd = copiedJob.GetPriority - jobPriorityTruncated;
				worker.WorkerBehaviour.ModifyJobPriority(copiedJob.GetJobType, valueToAdd, !copiedJob.GetJobActive);
			}
		}

		protected override void OnHelpClick()
		{
			MonoSingleton<UIController>.Instance.ShowAlmanacEntry("Gameplaytipsjobs");
		}

		protected override void Awake()
		{
			base.Awake();
			foreach (Job job in Repository<JobRepository, Job>.Instance.GetWorkerJobs())
			{
				Jobs.Add(job.JobType);
				SoundButton component = UnityEngine.Object.Instantiate(jobNamePrefab, jobNameParent).GetComponent<SoundButton>();
				component.onClick.AddListener(delegate
				{
					Log.Debug("Job Button Clicked", "C:\\GIT\\dev\\Assets\\Scripts\\UI\\Managers\\JobPanelManager.cs");
					if (MonoSingleton<UIController>.IsInstantiated())
					{
						MonoSingleton<UIController>.Instance.JobNameClick(job.JobType, -1);
					}
				});
				component.onRightClick.AddListener(delegate
				{
					Log.Debug("Job Button Right Clicked", "C:\\GIT\\dev\\Assets\\Scripts\\UI\\Managers\\JobPanelManager.cs");
					if (MonoSingleton<UIController>.IsInstantiated())
					{
						MonoSingleton<UIController>.Instance.JobNameClick(job.JobType, 1);
					}
				});
				string text = MonoSingleton<LocalizationController>.Instance.GetText(LocKeyUtils.GetName(job.LocKeys), BodyType.Male);
				component.GetComponentInChildren<TextMeshProUGUI>().SetText(text);
				LocalizedTextTooltipView component2 = component.GetComponent<LocalizedTextTooltipView>();
				component2.TextKeys[0] = text;
				component2.TextKeys[1] = "job_title_priorities_column";
			}
		}

		protected override void Start()
		{
			base.Start();
			SetPreferredWidth(elementBaseWidth + variableElementWidth * (float)Jobs.Count);
		}

		protected override void OnEnable()
		{
			base.OnEnable();
			ClearCopiedSettings();
			UIController instance = MonoSingleton<UIController>.Instance;
			instance.OnHoverJobToggleEvent = (UIController.JobToggleWorldPosition)Delegate.Combine(instance.OnHoverJobToggleEvent, new UIController.JobToggleWorldPosition(base.OnHoverToggle));
		}

		protected override void OnDisable()
		{
			base.OnDisable();
			if (MonoSingleton<UIController>.IsInstantiated())
			{
				UIController instance = MonoSingleton<UIController>.Instance;
				instance.OnHoverJobToggleEvent = (UIController.JobToggleWorldPosition)Delegate.Remove(instance.OnHoverJobToggleEvent, new UIController.JobToggleWorldPosition(base.OnHoverToggle));
			}
		}
	}
}
