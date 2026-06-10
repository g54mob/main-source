using System.Collections.Generic;
using System.Linq;
using NSEipix.Base;
using NSEipix.Repository;
using NSEipix.View.UI;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.Sound;
using NSMedieval.State;
using NSMedieval.State.WorkerJobs;
using NSMedieval.StatsSystem;
using NSMedieval.Tutorial;
using NSMedieval.UI.Utils;
using UnityEngine;

namespace NSMedieval.UI
{
	public class WorkerJobManager : WorkerPanelGroup
	{
		private readonly Dictionary<JobType, JobSkillLayoutItemView> workerSkills = new Dictionary<JobType, JobSkillLayoutItemView>();

		[SerializeField]
		private SoundButton allDownButton;

		[SerializeField]
		private SoundButton allUpButton;

		private bool firstRun = true;

		private JobPanelManager jobPanelManager;

		[SerializeField]
		private GameObject jobToggle;

		[SerializeField]
		private Transform toggleParent;

		public override void SetWorker(HumanoidInstance humanoid, WorkerPanelManager panelManager)
		{
			base.SetWorker(humanoid, panelManager);
			jobPanelManager = (JobPanelManager)panelManager;
			OnCopyChange();
			if (firstRun)
			{
				firstRun = false;
				SetupToggles();
			}
			else
			{
				UpdateToggles();
			}
		}

		public void SetJobTogglesInteractable(HashSet<JobType> jobTypes, bool interactable)
		{
			foreach (KeyValuePair<JobType, JobSkillLayoutItemView> workerSkill in workerSkills)
			{
				if (jobTypes != null && jobTypes.Contains(workerSkill.Key))
				{
					workerSkill.Value.PriorityButton.interactable = interactable;
				}
				else
				{
					workerSkill.Value.PriorityButton.interactable = !interactable;
				}
			}
		}

		public RectTransform GetJobToggleRectTransform(JobType jobType)
		{
			return workerSkills[jobType].PriorityButton.GetComponent<RectTransform>();
		}

		protected override void Start()
		{
			base.Start();
			allUpButton.onClick.AddListener(delegate
			{
				OnRowPriorityClick(-1);
			});
			allDownButton.onClick.AddListener(delegate
			{
				OnRowPriorityClick(1);
			});
			MonoSingleton<UIController>.Instance.OnCopyJobSettingsEvent += OnCopyChange;
			MonoSingleton<UIController>.Instance.OnJobNameClickEvent += OnColumnPriorityClick;
			if (TutorialManager.IsTutorialActive)
			{
				allDownButton.gameObject.SetActive(value: false);
				allUpButton.gameObject.SetActive(value: false);
				base.CopyButton.gameObject.SetActive(value: false);
				base.PasteButton.gameObject.SetActive(value: false);
			}
		}

		protected override void CopySettings()
		{
			List<JobPrioritySettings> list = new List<JobPrioritySettings>();
			foreach (JobType key in workerSkills.Keys)
			{
				list.Add(new JobPrioritySettings(key, base.Humanoid.WorkerBehaviour.GetJobPriorityTruncated(key), base.Humanoid.WorkerBehaviour.IsJobActive(key)));
			}
			jobPanelManager.CopiedJobs = list;
		}

		protected override void PasteSettings()
		{
			jobPanelManager.PasteToWorker(base.Humanoid);
			foreach (JobPrioritySettings copiedJob in jobPanelManager.CopiedJobs)
			{
				int jobPriorityTruncated = base.Humanoid.WorkerBehaviour.GetJobPriorityTruncated(copiedJob.GetJobType);
				int num = copiedJob.GetPriority - jobPriorityTruncated;
				workerSkills[copiedJob.GetJobType].SetPriority(JobUtils.GetJobPriorityDisplay(jobPriorityTruncated + num, copiedJob.GetJobActive));
			}
		}

		private void SetupToggles()
		{
			foreach (JobSkillLayoutItemView value in workerSkills.Values)
			{
				value.gameObject.SetActive(value: false);
			}
			for (int i = 0; i < jobPanelManager.Jobs.Count; i++)
			{
				int index = i;
				JobType jobType = jobPanelManager.Jobs[index];
				JobSkillLayoutItemView jobSkill = GetJobSkill(jobType);
				jobSkill.gameObject.name = jobType.ToString();
				jobSkill.PriorityButton.onClick.AddListener(delegate
				{
					MonoSingleton<AudioManager>.Instance.PlaySound("UI_JobPriority", new Dictionary<string, float> { { "Value", -1f } });
					OnPriorityAdd(jobType, -1, silent: false);
				});
				jobSkill.PriorityButton.onRightClick.AddListener(delegate
				{
					MonoSingleton<AudioManager>.Instance.PlaySound("UI_JobPriority", new Dictionary<string, float> { { "Value", 1f } });
					OnPriorityAdd(jobType, 1, silent: false);
				});
				Job byJobType = Repository<JobRepository, Job>.Instance.GetByJobType(jobType);
				if (byJobType.RelatedSkill == SkillType.None)
				{
					jobSkill.SetJobSkillData(byJobType, base.Humanoid);
				}
				else
				{
					jobSkill.SetJobSkillData(base.Humanoid.Skills.Skills[(int)byJobType.RelatedSkill], base.Humanoid, byJobType);
				}
				jobSkill.SetPriority(JobUtils.GetJobPriorityDisplay(base.Humanoid.WorkerBehaviour.GetJobPriorityTruncated(jobType), base.Humanoid.WorkerBehaviour.IsJobActive(jobType)));
			}
		}

		private void UpdateToggles()
		{
			foreach (KeyValuePair<JobType, JobSkillLayoutItemView> workerSkill in workerSkills)
			{
				Job byJobType = Repository<JobRepository, Job>.Instance.GetByJobType(workerSkill.Key);
				JobSkillLayoutItemView value = workerSkill.Value;
				if (byJobType.RelatedSkill == SkillType.None)
				{
					value.SetJobSkillData(byJobType, base.Humanoid);
				}
				else
				{
					value.SetJobSkillData(base.Humanoid.Skills.Skills[(int)byJobType.RelatedSkill], base.Humanoid, byJobType);
				}
				int jobPriorityDisplay = JobUtils.GetJobPriorityDisplay(base.Humanoid.WorkerBehaviour.GetJobPriorityTruncated(workerSkill.Key), base.Humanoid.WorkerBehaviour.IsJobActive(workerSkill.Key));
				value.SetPriority(jobPriorityDisplay);
			}
		}

		private void OnPriorityAdd(JobType jobType, int priority, bool silent)
		{
			int priorityInterpolated = JobUtils.GetPriorityInterpolated(JobUtils.GetJobPriorityTruncated(base.Humanoid.WorkerBehaviour.WorkerGoapAgent.GetJobPriority(jobType)), priority, base.Humanoid.WorkerBehaviour.IsJobActive(jobType));
			bool removeJob = base.Humanoid.WorkerBehaviour.IsJobActive(jobType) && priorityInterpolated == 0;
			base.Humanoid.WorkerBehaviour.ModifyJobPriority(jobType, priorityInterpolated, removeJob);
			workerSkills[jobType].SetPriority(JobUtils.GetJobPriorityDisplay(base.Humanoid.WorkerBehaviour.GetJobPriorityTruncated(jobType), base.Humanoid.WorkerBehaviour.IsJobActive(jobType)));
			BulkButtonsCheck(priority);
		}

		private void OnColumnPriorityClick(JobType jobType, int priority)
		{
			if (base.Humanoid != null && !base.Humanoid.HasDisposed)
			{
				MonoSingleton<AudioManager>.Instance.PlaySound("UI_JobPriority", new Dictionary<string, float> { { "Value", priority } });
				if (!ClampPriority(jobType, priority))
				{
					OnPriorityAdd(jobType, priority, silent: false);
				}
			}
		}

		private void BulkButtonsCheck(int priority)
		{
			int num = 0;
			int num2 = 0;
			foreach (JobType item in workerSkills.Keys.Where((JobType jobType) => ClampPriority(jobType, priority)))
			{
				_ = item;
				num = ((priority > 0) ? (num + 1) : num);
				num2 = ((priority < 0) ? (num2 + 1) : num2);
			}
			allUpButton.interactable = num2 != workerSkills.Count;
			allDownButton.interactable = num != workerSkills.Count;
		}

		private bool ClampPriority(JobType jobType, int priority)
		{
			int jobPriorityTruncated = base.Humanoid.WorkerBehaviour.GetJobPriorityTruncated(jobType);
			bool flag = base.Humanoid.WorkerBehaviour.IsJobActive(jobType);
			int priorityInterpolated = JobUtils.GetPriorityInterpolated(jobPriorityTruncated, priority, flag);
			if (priority < 0 && priorityInterpolated != priority && flag)
			{
				return true;
			}
			if (priority > 0 && priorityInterpolated < 0)
			{
				return true;
			}
			return false;
		}

		private JobSkillLayoutItemView GetJobSkill(JobType jobType)
		{
			workerSkills.TryGetValue(jobType, out var value);
			if (value != null)
			{
				return value;
			}
			value = Object.Instantiate(jobToggle, toggleParent).GetComponent<JobSkillLayoutItemView>();
			workerSkills.Add(jobType, value);
			return value;
		}

		private void OnRowPriorityClick(int priority)
		{
			MonoSingleton<AudioManager>.Instance.PlaySound("UI_JobPriority", new Dictionary<string, float> { { "Value", priority } });
			foreach (JobType item in workerSkills.Keys.Where((JobType jobType) => !ClampPriority(jobType, priority)))
			{
				OnPriorityAdd(item, priority, silent: false);
			}
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			if (MonoSingleton<UIController>.IsInstantiated())
			{
				MonoSingleton<UIController>.Instance.OnCopyJobSettingsEvent -= OnCopyChange;
			}
			if (MonoSingleton<UIController>.IsInstantiated())
			{
				MonoSingleton<UIController>.Instance.OnJobNameClickEvent -= OnColumnPriorityClick;
			}
		}

		private void OnCopyChange()
		{
			SoundButton soundButton = base.PasteButton;
			JobPanelManager obj = jobPanelManager;
			soundButton.interactable = (object)obj != null && obj.CopiedJobs.Count > 0;
		}
	}
}
