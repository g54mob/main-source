using System;
using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSEipix.Repository;
using NSEipix.View.UI;
using NSMedieval.Controllers;
using NSMedieval.Manager;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.Sound;
using NSMedieval.State;
using NSMedieval.State.WorkerJobs;
using NSMedieval.StatsSystem;
using NSMedieval.UI.Utils;
using NSMedieval.View;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace NSMedieval.UI
{
	public class PrisonersGroup : LayoutGroupItemView
	{
		private const int PriorityUp = -1;

		private const int PriorityDown = 1;

		[SerializeField]
		private SoundButton selectTargetButton;

		[SerializeField]
		private Image prisonerIcon;

		[SerializeField]
		private TMP_Text prisonerName;

		[SerializeField]
		private TMP_Text prisonerFaction;

		[SerializeField]
		private TMP_Text prisonerValue;

		[SerializeField]
		private CustomToggle shackleToggle;

		[SerializeField]
		private Image shackleIcon;

		[SerializeField]
		private CustomToggle stripToggle;

		[SerializeField]
		private CustomToggle releaseToggle;

		[SerializeField]
		private CustomToggle recruitToggle;

		[SerializeField]
		private CustomToggle labourToggle;

		[SerializeField]
		private LayoutGroupView jobLayoutGroup;

		[SerializeField]
		private WorkerSkillsTooltipViewNew prisonerTooltip;

		[NonSerialized]
		private List<JobSkillLayoutItemView> jobSkillLayoutItemViews;

		[NonSerialized]
		private Action onCaptiveLabourerChanged;

		[field: NonSerialized]
		public HumanoidInstance Humanoid { get; private set; }

		public CaptiveNpcBehaviour CaptiveNpcBehaviour => Humanoid.CaptiveNpcBehaviour;

		private void Start()
		{
			selectTargetButton.AddCleanListener(OnSelectTargetClick);
			labourToggle.onValueChanged.AddListener(OnCaptiveLabourerToggle);
			shackleToggle.onValueChanged.AddListener(OnShackleToggle);
			stripToggle.onValueChanged.AddListener(OnStripToggle);
			releaseToggle.onValueChanged.AddListener(OnReleaseToggle);
			recruitToggle.onValueChanged.AddListener(OnRecruitToggle);
			recruitToggle.onNonInteractableClick.AddListener(delegate
			{
				MonoSingleton<BlackBarMessageController>.Instance.ShowBlackBarMessage(MonoSingleton<LocalizationController>.Instance.GetText("cant_make_recruit_captive_labourer"));
			});
		}

		protected override void OnDestroy()
		{
			Humanoid = null;
			base.OnDestroy();
		}

		public void SetData(HumanoidInstance prisonerInstance, Action captiveLabourerChangedCallback)
		{
			Humanoid = prisonerInstance;
			onCaptiveLabourerChanged = captiveLabourerChangedCallback;
			prisonerTooltip?.SetOwner(Humanoid);
			UpdateData();
		}

		private void UpdateData()
		{
			prisonerIcon.sprite = Humanoid.GetSprite();
			prisonerName.text = Humanoid.Info.GetFullName();
			prisonerFaction.text = Humanoid.Faction.NameLocalized;
			prisonerValue.text = $"{Humanoid.WealthPoints:F1}";
			shackleToggle.SetIsOnWithoutNotify(IsShackleCheckboxOn());
			shackleIcon.gameObject.SetActive(CaptiveNpcBehaviour.Shackled);
			stripToggle.SetIsOnWithoutNotify(CaptiveNpcBehaviour.MarkedForStripping);
			releaseToggle.SetIsOnWithoutNotify(CaptiveNpcBehaviour.MarkedForReleasing);
			recruitToggle.SetIsOnWithoutNotify(CaptiveNpcBehaviour.MarkedForRecruiting);
			labourToggle.SetIsOnWithoutNotify(CaptiveNpcBehaviour.IsCaptiveLabourer);
			UpdateJobToggles();
			Refresh();
		}

		private void UpdateJobToggles()
		{
			if (jobSkillLayoutItemViews == null)
			{
				InitJobToggles();
			}
			if (Humanoid.CaptiveLabourerBehaviour == null || !labourToggle.isOn)
			{
				return;
			}
			int num = 0;
			foreach (Job captiveLabourerJob in Repository<JobRepository, Job>.Instance.GetCaptiveLabourerJobs())
			{
				JobType jobType = captiveLabourerJob.JobType;
				JobSkillLayoutItemView at = jobSkillLayoutItemViews.GetAt(jobLayoutGroup, num);
				num++;
				if (captiveLabourerJob.RelatedSkill == SkillType.None)
				{
					at.SetJobSkillData(captiveLabourerJob, Humanoid);
				}
				else
				{
					at.SetJobSkillData(Humanoid.Skills.Skills[(int)captiveLabourerJob.RelatedSkill], Humanoid, captiveLabourerJob);
				}
				int jobPriorityDisplay = JobUtils.GetJobPriorityDisplay(Humanoid.CaptiveLabourerBehaviour.GetJobPriorityTruncated(jobType), Humanoid.CaptiveLabourerBehaviour.IsJobActive(jobType));
				at.SetPriority(jobPriorityDisplay);
				bool isEnabled;
				FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(17, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\Managers\\PrisonersGroup.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral(" Job: ");
					messageBuilder.AppendFormatted(jobType);
					messageBuilder.AppendLiteral(" Priority: ");
					messageBuilder.AppendFormatted(jobPriorityDisplay);
				}
				Log.Debug(messageBuilder);
			}
			jobSkillLayoutItemViews.SetActiveFromIndex(num, active: false);
		}

		private void Refresh()
		{
			recruitToggle.interactable = !CaptiveNpcBehaviour.IsCaptiveLabourer;
			recruitToggle.SetIsOnWithoutNotify(CaptiveNpcBehaviour.MarkedForRecruiting);
			SetCaptiveLabourerInteractable(CaptiveNpcBehaviour.Shackled, "cant_make_captive_labourer_shackles");
			jobLayoutGroup.GetComponent<CanvasGroup>().alpha = (CaptiveNpcBehaviour.IsCaptiveLabourer ? 1 : 0);
			jobLayoutGroup.GetComponent<CanvasGroup>().interactable = CaptiveNpcBehaviour.IsCaptiveLabourer;
		}

		private void InitJobToggles()
		{
			jobSkillLayoutItemViews = new List<JobSkillLayoutItemView>();
			int num = 0;
			foreach (Job captiveLabourerJob in Repository<JobRepository, Job>.Instance.GetCaptiveLabourerJobs())
			{
				JobType jobType = captiveLabourerJob.JobType;
				JobSkillLayoutItemView at = jobSkillLayoutItemViews.GetAt(jobLayoutGroup, num);
				at.PriorityButton.onClick.AddListener(delegate
				{
					OnPriorityAdd(jobType, -1, silent: false);
				});
				at.PriorityButton.onRightClick.AddListener(delegate
				{
					OnPriorityAdd(jobType, 1, silent: false);
				});
				num++;
			}
			jobSkillLayoutItemViews.SetActiveFromIndex(0, active: false);
			bool isEnabled;
			FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(46, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\Managers\\PrisonersGroup.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("InitJobToggles done. ");
				messageBuilder.AppendFormatted(num);
				messageBuilder.AppendLiteral(" job toggles initialized.");
			}
			Log.Debug(messageBuilder);
		}

		private void OnPriorityAdd(JobType jobType, int priority, bool silent)
		{
			if (Humanoid.CaptiveLabourerBehaviour != null)
			{
				MonoSingleton<AudioManager>.Instance.PlaySound("UI_JobPriority", new Dictionary<string, float> { { "Value", priority } });
				int priorityInterpolated = JobUtils.GetPriorityInterpolated(JobUtils.GetJobPriorityTruncated(Humanoid.CaptiveLabourerBehaviour.PrisonerAgent.GetJobPriority(jobType)), priority, Humanoid.CaptiveLabourerBehaviour.IsJobActive(jobType));
				bool removeJob = Humanoid.CaptiveLabourerBehaviour.IsJobActive(jobType) && priorityInterpolated == 0;
				Humanoid.CaptiveLabourerBehaviour.ModifyJobPriority(jobType, priorityInterpolated, removeJob);
				jobSkillLayoutItemViews.FirstOrDefault((JobSkillLayoutItemView jkw) => jkw.HasJob(jobType))?.SetPriority(JobUtils.GetJobPriorityDisplay(Humanoid.CaptiveLabourerBehaviour.GetJobPriorityTruncated(jobType), Humanoid.CaptiveLabourerBehaviour.IsJobActive(jobType)));
			}
		}

		private void OnCaptiveLabourerToggle(bool isOn)
		{
			if (isOn)
			{
				OnRecruitToggle(isOn: false);
			}
			CaptiveNpcBehaviour.SetCaptiveLabour(isOn);
			jobLayoutGroup.GetComponent<CanvasGroup>().alpha = (isOn ? 1 : 0);
			UpdateJobToggles();
			Refresh();
			onCaptiveLabourerChanged?.Invoke();
		}

		public void SetCaptiveLabourerInteractable(bool interactable, string bbtMessage)
		{
			labourToggle.onNonInteractableClick.RemoveAllListeners();
			labourToggle.interactable = interactable;
			if (!interactable && !string.IsNullOrEmpty(bbtMessage))
			{
				labourToggle.onNonInteractableClick.AddListener(delegate
				{
					MonoSingleton<BlackBarMessageController>.Instance.ShowBlackBarMessage(MonoSingleton<LocalizationController>.Instance.GetText(bbtMessage));
				});
			}
		}

		private void OnShackleToggle(bool isOn)
		{
			if (isOn)
			{
				CaptiveNpcBehaviour.MarkForUnShackling(mark: false);
				if (!CaptiveNpcBehaviour.Shackled)
				{
					CaptiveNpcBehaviour.MarkForShackling(mark: true);
					if (!MonoSingleton<ResourcePileManager>.Instance.ResourcePileWithProtoIdExists("shackles"))
					{
						string text = MonoSingleton<LocalizationController>.Instance.GetText("equipment_name_shackles");
						MonoSingleton<BlackBarMessageController>.Instance.ShowBlackBarMessage(MonoSingleton<LocalizationController>.Instance.GetText("no_item_available").Replace("<item_name>", text));
					}
				}
			}
			else
			{
				CaptiveNpcBehaviour.MarkForShackling(mark: false);
				if (CaptiveNpcBehaviour.Shackled)
				{
					CaptiveNpcBehaviour.MarkForUnShackling(mark: true);
				}
			}
		}

		private bool IsShackleCheckboxOn()
		{
			if (CaptiveNpcBehaviour.Shackled)
			{
				return !CaptiveNpcBehaviour.MarkedForUnShackling;
			}
			return CaptiveNpcBehaviour.MarkedForShackling;
		}

		private void OnStripToggle(bool isOn)
		{
			CaptiveNpcBehaviour.MarkForStripping(isOn);
		}

		private void OnReleaseToggle(bool isOn)
		{
			CaptiveNpcBehaviour.MarkForReleasing(isOn);
		}

		private void OnRecruitToggle(bool isOn)
		{
			bool isEnabled;
			FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(17, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\Managers\\PrisonersGroup.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("OnRecruitToggle: ");
				messageBuilder.AppendFormatted(isOn);
			}
			Log.Debug(messageBuilder);
			Humanoid.PrisonerBehaviour.MarkForRecruiting(isOn);
		}

		private void OnSelectTargetClick()
		{
			MonoSingleton<UIPanelManager>.Instance.CloseAllOpened();
			MonoSingleton<RtsCamera>.Instance.JumpToAndFollow(Humanoid.GetTransform());
			HumanoidView agentView = Humanoid.GetAgentView<HumanoidView>();
			if (!(agentView == null))
			{
				MonoSingleton<SelectableObjectManager>.Instance.SelectObject(agentView);
			}
		}
	}
}
