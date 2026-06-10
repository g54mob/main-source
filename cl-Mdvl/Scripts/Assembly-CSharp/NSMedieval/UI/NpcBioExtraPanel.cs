using System;
using System.Collections.Generic;
using NSEipix;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.State;
using NSMedieval.StatsSystem;
using NSMedieval.UI.Utils;
using NSMedieval.View;
using TMPro;
using TwitchIntegration;
using UnityEngine;
using UnityEngine.UI;

namespace NSMedieval.UI
{
	public class NpcBioExtraPanel : SelectionExtraPanelBase
	{
		[SerializeField]
		private TMP_Text nameLabel;

		[SerializeField]
		private ButtonLayoutItemView twitchNameButton;

		[SerializeField]
		private List<FillBarLayoutItemView> infos;

		[SerializeField]
		private FillBarLayoutItemView factionInfo;

		[SerializeField]
		private List<AlignmentLayoutItemView> alignments;

		[SerializeField]
		private FillBarLayoutItemView perksTitle;

		[SerializeField]
		private PseudonymTooltipView pseudonymTooltipView;

		[SerializeField]
		private JobPreferencesPanelView jobPreferencesPanelView;

		[SerializeField]
		private LayoutGroupView perksGroup;

		[SerializeField]
		private FillBarLayoutItemView workerPerksTitle;

		[NonSerialized]
		private readonly List<LayoutGroupItemView> perks = new List<LayoutGroupItemView>();

		[NonSerialized]
		private readonly List<string> tooltipLines = new List<string>();

		[NonSerialized]
		private HumanoidInstance currentHumanoid;

		private void OnEnable()
		{
			CreateEnemyName();
			if (TwitchManager.IsInitialized && TwitchManager.IsAuthenticated && MonoSingleton<GlobalSaveController>.Instance.GlobalSettings.TwitchNameCommandEnabled)
			{
				twitchNameButton.gameObject.SetActive(value: true);
				twitchNameButton.Button.AddCleanListener(OnTwitchNameButtonClick);
			}
			else
			{
				twitchNameButton.gameObject.SetActive(value: false);
			}
		}

		private void OnDisable()
		{
			currentHumanoid = null;
			if (TwitchManager.IsInitialized)
			{
				twitchNameButton.Button.RemoveAllListeners();
			}
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			currentHumanoid = null;
			perks.Clear();
		}

		protected override void SetupTabPanel()
		{
			if (base.Humanoid != null && !base.Humanoid.HasDisposed)
			{
				CreateEnemyName();
				CreatePerks();
				CreateJobPreferences();
				UpdateTabPanel();
			}
		}

		protected override void UpdateTabPanel()
		{
			if (base.Humanoid != null && !base.Humanoid.HasDisposed)
			{
				CreateBackground();
				CreateAlignments();
				CreateInfos();
				CreateFactionInfos();
				LayoutRebuilder.MarkLayoutForRebuild(GetComponent<RectTransform>());
			}
		}

		private void CreateBackground()
		{
			if (pseudonymTooltipView != null)
			{
				pseudonymTooltipView.SetOwner(null);
			}
			if (pseudonymTooltipView != null)
			{
				pseudonymTooltipView.SetOwner(base.Humanoid);
			}
			string backgroundNameMerged = HumanoidUtils.GetBackgroundNameMerged(base.Humanoid);
			infos[0].SetDataText(base.Localize.GetText("menu_background") + " <style=AltColor> " + backgroundNameMerged, base.Humanoid.Info.BackgroundId, base.Humanoid);
			bool flag = !base.Humanoid.Info.PseudonymId.Equals(string.Empty);
			infos[1].gameObject.SetActive(flag);
			if (flag)
			{
				infos[1].SetDataText(base.Localize.GetText("menu_pseudonym") + " <style=AltColor>" + HumanoidUtils.GetPseudonymLocalized(base.Humanoid), base.Humanoid.Info.PseudonymId, base.Humanoid);
			}
		}

		private void CreateEnemyName()
		{
			if (base.Humanoid != null)
			{
				string text = base.Humanoid.Info.GetFullName();
				if (base.Humanoid.ActiveBehaviour.HumanoidRoleOwner.AssignedRole)
				{
					text = text + " (" + HumanoidRoleUtils.GetRoleNameWithIconAndLevel(base.Humanoid.ActiveBehaviour.HumanoidRoleOwner.RoleInstance) + ")";
				}
				nameLabel.text = text;
			}
		}

		private void CreateAlignments()
		{
			float normalizedPercentage = base.Humanoid.Stats.GetStat(StatType.ReligiousAlignment).GetNormalizedPercentage();
			alignments[1].SetAlignmentData(StatType.ReligiousAlignment, normalizedPercentage, base.Humanoid);
		}

		private void CreatePerks()
		{
			if (currentHumanoid == base.Humanoid)
			{
				return;
			}
			currentHumanoid = base.Humanoid;
			workerPerksTitle.SetDataText(base.Localize.GetText("menu_perks"));
			perks.SetAllActive(active: false);
			foreach (Perk perk in base.Humanoid.Perks)
			{
				LayoutGroupItemView next = perks.GetNext(perksGroup);
				next.SetImageHumanoid(perk.IconPath, perk.Name, base.Humanoid);
				if (next.TooltipNew is PerkTooltipView perkTooltipView)
				{
					perkTooltipView.Init(perk.GetID(), base.Humanoid);
				}
			}
		}

		private void CreateJobPreferences()
		{
			jobPreferencesPanelView.UpdateData(base.Humanoid);
		}

		private void CreateInfos()
		{
			infos[2].SetDataText(base.Localize.GetText("menu_character_age") + " <color=#ffeca8>" + base.Humanoid.Info.GetBirthdayString() + "</color>");
			infos[4].SetDataText(string.Format("{0} <color=#ffeca8>{1} {2}</color>", base.Localize.GetText("menu_character_weight"), (int)base.Humanoid.Info.GetWeight(), base.Localize.GetText("general_kg")));
			infos[3].SetDataText(string.Format("{0} <color=#ffeca8>{1} {2}</color>", base.Localize.GetText("menu_character_hight"), (int)base.Humanoid.Info.Height, base.Localize.GetText("general_cm")));
			CaptiveNpcBehaviour captiveNpcBehaviour = base.Humanoid.CaptiveNpcBehaviour;
			if (captiveNpcBehaviour != null)
			{
				infos[5].SetDataText(string.Format("{0} <color=#ffeca8>{1}%</color>", base.Localize.GetText("recruit_amount"), captiveNpcBehaviour.GetRecruitedPercentage()));
				tooltipLines.Clear();
				PrisonerBehaviour behaviour = base.Humanoid.GetBehaviour<PrisonerBehaviour>();
				if (behaviour != null)
				{
					tooltipLines.Add(string.Format("{0}: <color=#ffeca8>{1}{2}</color>", base.Localize.GetText("recruit_next_attempt"), behaviour.RecruitAttemptCooldownHoursLeft, base.Localize.GetText("general_hour_short")));
					tooltipLines.Add(base.Localize.GetText("recruit_try_info") + ": <color=#ffeca8>" + base.Localize.GetText(behaviour.GetLastAttemptSuccessful() ? "general_successful" : "general_failed") + "</color>");
					infos[5].SetTooltipLines(tooltipLines);
				}
				if (!infos[5].isActiveAndEnabled)
				{
					infos[5].Show();
				}
			}
			else if (infos[5].isActiveAndEnabled)
			{
				infos[5].Hide();
			}
		}

		private void CreateFactionInfos()
		{
			if (base.Humanoid.Faction == null)
			{
				factionInfo.SetDataText(string.Empty);
			}
			else
			{
				factionInfo.SetDataText(NpcUtils.GetLocalizedFactionLink(base.Humanoid) + " (" + base.Humanoid.Faction.GetFriendlinessTextColored() + ")");
			}
		}

		private void OnTwitchNameButtonClick()
		{
			MonoSingleton<TwitchController>.Instance.ClearUsedTwitchName(base.Humanoid);
			string text = MonoSingleton<TwitchController>.Instance.GetTwitchName();
			if (text == string.Empty)
			{
				text = Repository<NameRepository, Names>.Instance.GetFirstName(base.Humanoid.Info.BodyType);
			}
			base.Humanoid.Info.SetFirstName(text);
			base.Humanoid.GetAgentView<NPCView>()?.HandleUpdateName();
		}
	}
}
