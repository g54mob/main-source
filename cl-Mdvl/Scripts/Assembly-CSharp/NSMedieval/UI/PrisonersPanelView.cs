using System;
using System.Collections.Generic;
using NSEipix;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Controllers;
using NSMedieval.Manager;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.Roles;
using NSMedieval.State;
using NSMedieval.UI.Utils;
using TMPro;
using UnityEngine;

namespace NSMedieval.UI
{
	public class PrisonersPanelView : OverviewPanelView
	{
		private const string WardenRoleKey = "role_warden_name";

		private const string CaptiveLabourerKey = "general_captive_labourer";

		private const string WardenMissingMessage = "cant_make_captive_labourer_warden_missing";

		private const string WardenLevelLimitMessage = "cant_make_captive_labourer_warden_level";

		private const string NotShackledMessage = "cant_make_captive_labourer_shackles";

		[SerializeField]
		private TMP_Text wardenLabel;

		[SerializeField]
		private TMP_Text labourersCapacity;

		[SerializeField]
		private LayoutGroupView jobLabelsGroup;

		private int captiveLabourerCount;

		private int captiveLabourerLimit;

		private readonly List<PrisonersGroup> prisonersPanelGroups = new List<PrisonersGroup>();

		private readonly List<LayoutGroupItemView> jobLabelsGroupItemViews = new List<LayoutGroupItemView>();

		public override void Show()
		{
			base.Show();
			RefreshHumanoidInstances();
			CountCaptiveLabourers();
			RefreshUI();
		}

		private void RefreshHumanoidInstances()
		{
			int num = 0;
			foreach (HumanoidInstance item in MonoSingleton<NPCManager>.Instance.IterateNPCs())
			{
				CaptiveNpcBehaviour captiveNpcBehaviour = item.CaptiveNpcBehaviour;
				if (captiveNpcBehaviour != null && captiveNpcBehaviour.Owner == null)
				{
					PrisonersGroup at = prisonersPanelGroups.GetAt(base.ContentGroup, num);
					at.Show();
					at.SetData(item, OnCaptiveLabourChangedCallback);
					num++;
				}
			}
			prisonersPanelGroups.SetActiveFromIndex(num, active: false);
		}

		private void OnCaptiveLabourChangedCallback()
		{
			CountCaptiveLabourers();
			RefreshUI();
		}

		private void CountCaptiveLabourers()
		{
			captiveLabourerLimit = 0;
			if (!MonoSingleton<RoleManager>.Instance.HasWardenRole(out var humanoidInstance))
			{
				foreach (PrisonersGroup prisonersPanelGroup in prisonersPanelGroups)
				{
					prisonersPanelGroup.SetCaptiveLabourerInteractable(interactable: false, "cant_make_captive_labourer_warden_missing");
					if (prisonersPanelGroup.Humanoid.CaptiveLabourerBehaviour != null)
					{
						prisonersPanelGroup.SetCaptiveLabourerInteractable(interactable: true, string.Empty);
					}
				}
				captiveLabourerCount = 0;
				return;
			}
			captiveLabourerLimit = MonoSingleton<RoleManager>.Instance.GetLabourerLimit(humanoidInstance.WorkerBehaviour.HumanoidRoleOwner.RoleLevel);
			captiveLabourerCount = 0;
			foreach (PrisonersGroup prisonersPanelGroup2 in prisonersPanelGroups)
			{
				prisonersPanelGroup2.SetCaptiveLabourerInteractable(interactable: true, string.Empty);
				if (prisonersPanelGroup2.Humanoid.ActiveBehaviour is CaptiveNpcBehaviour { Shackled: false })
				{
					prisonersPanelGroup2.SetCaptiveLabourerInteractable(interactable: false, "cant_make_captive_labourer_shackles");
					continue;
				}
				prisonersPanelGroup2.SetCaptiveLabourerInteractable(interactable: true, string.Empty);
				if (prisonersPanelGroup2.Humanoid.ActiveBehaviour is CaptiveNpcBehaviour { IsCaptiveLabourer: not false })
				{
					captiveLabourerCount++;
				}
			}
			if (captiveLabourerCount < captiveLabourerLimit)
			{
				return;
			}
			foreach (PrisonersGroup prisonersPanelGroup3 in prisonersPanelGroups)
			{
				if (prisonersPanelGroup3.Humanoid.ActiveBehaviour is CaptiveNpcBehaviour { IsCaptiveLabourer: false })
				{
					prisonersPanelGroup3.SetCaptiveLabourerInteractable(interactable: false, "cant_make_captive_labourer_warden_level");
				}
			}
		}

		private void RefreshUI()
		{
			if (MonoSingleton<RoleManager>.Instance.HasWardenRole(out var humanoidInstance))
			{
				wardenLabel.text = MonoSingleton<LocalizationController>.Instance.GetText("role_warden_name") + ": " + UiUtils.GetWorkerLink(humanoidInstance);
			}
			else
			{
				wardenLabel.text = MonoSingleton<LocalizationController>.Instance.GetText("role_warden_name") + ": " + MonoSingleton<LocalizationController>.Instance.GetText("general_none");
			}
			labourersCapacity.text = string.Format("{0}: {1}/{2}", MonoSingleton<LocalizationController>.Instance.GetText("general_captive_labourer"), captiveLabourerCount, captiveLabourerLimit);
			jobLabelsGroup.GetComponent<CanvasGroup>().alpha = ((captiveLabourerCount > 0) ? 1 : 0);
		}

		protected override void Start()
		{
			base.Start();
			foreach (Job captiveLabourerJob in Repository<JobRepository, Job>.Instance.GetCaptiveLabourerJobs())
			{
				LayoutGroupItemView next = jobLabelsGroupItemViews.GetNext(jobLabelsGroup);
				string text = MonoSingleton<LocalizationController>.Instance.GetText("job_name_" + captiveLabourerJob.GetID().ToLower(), BodyType.Male);
				next.SetText(text);
				next.GetComponent<LocalizedTextTooltipView>().TextKeys[0] = text;
			}
		}

		protected override void SortEntries()
		{
			prisonersPanelGroups.Sort(PrisonerEntrySortComparison);
			int num = 0;
			foreach (PrisonersGroup prisonersPanelGroup in prisonersPanelGroups)
			{
				prisonersPanelGroup.transform.SetSiblingIndex(num++);
			}
		}

		private int PrisonerEntrySortComparison(PrisonersGroup a, PrisonersGroup b)
		{
			int num = 0;
			switch (base.CurrentSortMode)
			{
			case SortMode.Name:
				num = SortByName();
				break;
			case SortMode.Value:
				num = (int)(a.Humanoid.WealthPoints - b.Humanoid.WealthPoints);
				break;
			case SortMode.Faction:
				num = 100 * SortByFaction() + 10 * SortByName();
				break;
			case SortMode.CaptiveLabourer:
				num = (a.CaptiveNpcBehaviour.IsCaptiveLabourer ? 1 : 0) - (b.CaptiveNpcBehaviour.IsCaptiveLabourer ? 1 : 0);
				break;
			case SortMode.ShackleMarked:
				num = 1000 * (a.CaptiveNpcBehaviour.Shackled ? 1 : 0) - (b.CaptiveNpcBehaviour.Shackled ? 1 : 0);
				num += 100 * (a.CaptiveNpcBehaviour.MarkedForUnShackling ? 1 : 0) - (b.CaptiveNpcBehaviour.MarkedForShackling ? 1 : 0);
				num += 10 * (a.CaptiveNpcBehaviour.MarkedForUnShackling ? 1 : 0) - (b.CaptiveNpcBehaviour.MarkedForUnShackling ? 1 : 0);
				break;
			case SortMode.StripMarked:
				num = (a.CaptiveNpcBehaviour.MarkedForStripping ? 1 : 0) - (b.CaptiveNpcBehaviour.MarkedForStripping ? 1 : 0);
				break;
			case SortMode.ReleaseMarked:
				num = 100 * (a.CaptiveNpcBehaviour.MarkedForReleasing ? 1 : 0) - (b.CaptiveNpcBehaviour.MarkedForReleasing ? 1 : 0);
				break;
			case SortMode.RecruitMarked:
				num = 100 * (a.CaptiveNpcBehaviour.MarkedForRecruiting ? 1 : 0) - (b.CaptiveNpcBehaviour.MarkedForRecruiting ? 1 : 0);
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
			if (!SortDirection)
			{
				return -num;
			}
			return num;
			int SortByFaction()
			{
				return string.Compare(a.Humanoid.Faction.NameLocalized, b.Humanoid.Faction.NameLocalized, StringComparison.CurrentCultureIgnoreCase);
			}
			int SortByName()
			{
				return string.Compare(a.Humanoid.Info.FirstName, b.Humanoid.Info.FirstName, StringComparison.CurrentCultureIgnoreCase);
			}
		}
	}
}
