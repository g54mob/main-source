using System;
using System.Collections.Generic;
using FoxyVoxel.Logging;
using NSEipix;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Manager;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.Research;
using NSMedieval.Roles;
using NSMedieval.State;
using NSMedieval.StatsSystem;
using NSMedieval.Tutorial;
using NSMedieval.UI.Utils;
using TMPro;
using TwitchIntegration;
using UnityEngine;
using UnityEngine.UI;

namespace NSMedieval.UI
{
	public class WorkerBioExtraPanel : SelectionExtraPanelBase
	{
		[SerializeField]
		private TMP_InputField workerName;

		[SerializeField]
		private ButtonLayoutItemView twitchNameButton;

		[SerializeField]
		private ButtonLayoutItemView roleButton;

		[SerializeField]
		private List<FillBarLayoutItemView> infos;

		[SerializeField]
		private List<AlignmentLayoutItemView> alignments;

		[SerializeField]
		private FillBarLayoutItemView workerPerksTitle;

		[SerializeField]
		private JobPreferencesPanelView jobPreferencesPanelView;

		[SerializeField]
		private LayoutGroupView workerPerkGroup;

		[SerializeField]
		private PseudonymTooltipView pseudonymTooltipView;

		[NonSerialized]
		private readonly List<LayoutGroupItemView> workerPerks = new List<LayoutGroupItemView>();

		[NonSerialized]
		private HumanoidInstance currentHumanoid;

		private LayoutElement layoutElement;

		private void Awake()
		{
			Log.Trace("Awake", "C:\\GIT\\dev\\Assets\\Scripts\\UI\\View\\Selection\\WorkerBioExtraPanel.cs");
			layoutElement = GetComponent<LayoutElement>();
		}

		private void Start()
		{
			Log.Trace("Start", "C:\\GIT\\dev\\Assets\\Scripts\\UI\\View\\Selection\\WorkerBioExtraPanel.cs");
			workerName.onDeselect.AddListener(delegate(string value)
			{
				OnWorkerNameDeselect(value);
			});
			workerName.onValueChanged.AddListener(delegate(string value)
			{
				OnWorkerNameValueChange(value, inputLocked: true);
			});
			workerName.onEndEdit.AddListener(delegate(string value)
			{
				OnWorkerNameValueChange(value, inputLocked: false);
			});
			workerName.onEndEdit.AddListener(delegate(string value)
			{
				OnWorkerNameEndEdit(value);
			});
			roleButton.Button.AddCleanListener(OnRoleButtonClicked);
			if (TutorialManager.IsTutorialActive)
			{
				roleButton.Button.interactable = false;
			}
		}

		private void OnRoleButtonClicked()
		{
			MonoSingleton<RoleManager>.Instance.ShowView(base.Humanoid);
		}

		private void OnEnable()
		{
			if (base.Humanoid != null && !base.Humanoid.HasDisposed)
			{
				CreateWorkerName();
				MonoSingleton<RoleManager>.Instance.RoleChangedEvent += OnRoleOwnerChanged;
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
		}

		private void OnDisable()
		{
			if (base.Humanoid != null && !base.Humanoid.HasDisposed)
			{
				if (MonoSingleton<RoleManager>.IsInstantiated())
				{
					MonoSingleton<RoleManager>.Instance.RoleChangedEvent -= OnRoleOwnerChanged;
				}
				if (TwitchManager.IsInitialized)
				{
					twitchNameButton.Button.RemoveAllListeners();
				}
			}
		}

		protected override void SetupTabPanel()
		{
			Log.Trace("SetupTabPanel", "C:\\GIT\\dev\\Assets\\Scripts\\UI\\View\\Selection\\WorkerBioExtraPanel.cs");
			if (base.Humanoid != null && !base.Humanoid.HasDisposed)
			{
				MonoSingleton<TaskController>.Instance.WaitForNextFrameUnscaled().Then(delegate
				{
					layoutElement.enabled = false;
				}).Then(delegate
				{
					layoutElement.enabled = true;
				});
				CreateWorkerName();
				CreatePerks();
				CreateJobPreferences();
			}
		}

		protected override void UpdateTabPanel()
		{
			if (base.Humanoid != null && !base.Humanoid.HasDisposed)
			{
				UpdateRole();
				CreateInfos();
				CreateBackground();
				CreateAlignments();
			}
		}

		private void OnRoleOwnerChanged(Role role, HumanoidInstance humanoidInstance)
		{
			UpdateRole();
			CreateJobPreferences();
			MonoSingleton<WorkerController>.Instance.WorkerNameChanged(base.Humanoid);
		}

		private void UpdateRole()
		{
			roleButton.SetButtonData(base.Humanoid.ActiveBehaviour.HumanoidRoleOwner.AssignedRole ? HumanoidRoleUtils.GetRoleNameWithIconAndLevel(base.Humanoid.ActiveBehaviour.HumanoidRoleOwner.RoleInstance) : base.Localize.GetText("general_none"));
			if (roleButton.TooltipNew is HumanoidRoleButtonTooltipView humanoidRoleButtonTooltipView)
			{
				humanoidRoleButtonTooltipView.SetTooltipData(base.Humanoid);
			}
			if (TutorialManager.IsTutorialActive)
			{
				return;
			}
			if (base.Humanoid?.WorkerBehaviour != null && base.Humanoid.WorkerBehaviour.IsBanished)
			{
				roleButton.Button.interactable = false;
				return;
			}
			int hoursLeft = 0;
			if (base.Humanoid.WorkerBehaviour?.HumanoidRoleOwner != null && !base.Humanoid.WorkerBehaviour.HumanoidRoleOwner.InsInCooldown(out hoursLeft) && !base.Humanoid.IsAtEvent())
			{
				roleButton.Button.interactable = true;
			}
			else
			{
				roleButton.Button.interactable = false;
			}
		}

		private void CreateBackground()
		{
			if (pseudonymTooltipView != null)
			{
				pseudonymTooltipView.SetOwner(null);
			}
			if (base.Humanoid != null && !base.Humanoid.HasDisposed)
			{
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
		}

		private void CreateWorkerName()
		{
			workerName.text = base.Humanoid.Info.GetDefaultDisplayName();
		}

		private void OnWorkerNameDeselect(string value)
		{
			CreateBackground();
			string text = value.Trim();
			if (string.CompareOrdinal(base.Humanoid.Info.FirstName, text) != 0)
			{
				base.Humanoid.Info.SetFirstName(text);
				MonoSingleton<WorkerController>.Instance.WorkerNameChanged(base.Humanoid);
			}
		}

		private void CreateInfos()
		{
			infos[2].SetDataText(base.Localize.GetText("menu_character_age") + " <color=#ffeca8>" + base.Humanoid.Info.GetBirthdayString() + "</color>");
			infos[3].SetDataText(string.Format("{0} <color=#ffeca8>{1} {2}</color>", base.Localize.GetText("menu_character_weight"), (int)base.Humanoid.Info.GetWeight(), base.Localize.GetText("general_kg")));
			infos[4].SetDataText(string.Format("{0} <color=#ffeca8>{1} {2}</color>", base.Localize.GetText("menu_character_hight"), (int)base.Humanoid.Info.Height, base.Localize.GetText("general_cm")));
		}

		private void CreateAlignments()
		{
			float normalizedPercentage = base.Humanoid.Stats.GetStat(StatType.ReligiousAlignment).GetNormalizedPercentage();
			alignments[1].SetAlignmentData(StatType.ReligiousAlignment, normalizedPercentage, base.Humanoid);
		}

		private void CreateJobPreferences()
		{
			jobPreferencesPanelView.UpdateData(base.Humanoid);
		}

		private void CreatePerks()
		{
			if (currentHumanoid == base.Humanoid)
			{
				return;
			}
			currentHumanoid = base.Humanoid;
			workerPerksTitle.SetDataText(base.Localize.GetText("menu_perks"));
			workerPerks.SetAllActive(active: false);
			foreach (Perk perk in base.Humanoid.Perks)
			{
				LayoutGroupItemView next = workerPerks.GetNext(workerPerkGroup);
				next.SetImageHumanoid(perk.IconPath, perk.Name, base.Humanoid);
				if (next.TooltipNew is PerkTooltipView perkTooltipView)
				{
					perkTooltipView.Init(perk.GetID(), base.Humanoid);
				}
			}
		}

		private void OnWorkerNameEndEdit(string nameEntered)
		{
			string text = nameEntered.Trim();
			if (string.CompareOrdinal(base.Humanoid.Info.FirstName, text) != 0)
			{
				base.Humanoid.Info.SetFirstName(text);
				MonoSingleton<WorkerController>.Instance.WorkerNameChanged(base.Humanoid);
			}
		}

		private void OnWorkerNameValueChange(string nameEntered, bool inputLocked)
		{
			if (!(!workerName.isFocused && inputLocked))
			{
				if (nameEntered.StartsWith(" "))
				{
					workerName.text = nameEntered.TrimStart();
				}
				MonoSingleton<InputManager>.Instance.SetInputEnabled(!inputLocked);
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
			MonoSingleton<WorkerController>.Instance.WorkerNameChanged(base.Humanoid);
		}
	}
}
