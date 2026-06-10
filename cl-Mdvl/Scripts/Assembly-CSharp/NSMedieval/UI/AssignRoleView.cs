using System;
using System.Collections.Generic;
using NSEipix;
using NSEipix.Base;
using NSEipix.Repository;
using NSEipix.View.UI;
using NSMedieval.Repository;
using NSMedieval.Roles;
using NSMedieval.State;
using NSMedieval.UI.Utils;
using TMPro;
using UnityEngine;

namespace NSMedieval.UI
{
	public class AssignRoleView : PopupView
	{
		[SerializeField]
		private GameObject content;

		[SerializeField]
		private TMP_Text title;

		[SerializeField]
		private TMP_Text info;

		[SerializeField]
		private SoundButton[] closeButtons;

		[SerializeField]
		private LayoutGroupView contentParent;

		[NonSerialized]
		private readonly List<RoleLayoutItemView> roleLayoutItemViews = new List<RoleLayoutItemView>();

		[NonSerialized]
		private HumanoidInstance humanoidInstance;

		public void SetDataAndShow(HumanoidInstance humanoidInstance)
		{
			this.humanoidInstance = humanoidInstance;
			title.SetText(this.humanoidInstance.Info.GetFullName());
			info.SetText("assign_role_info".ToLocalized(humanoidInstance.GetInfo().BodyType));
			Show();
			Refresh();
		}

		private void Refresh()
		{
			int num = 0;
			foreach (Role allItem in Repository<RoleRepository, Role>.Instance.GetAllItems())
			{
				RoleLayoutItemView at = roleLayoutItemViews.GetAt(contentParent, num);
				at.SetData(allItem, humanoidInstance, OnLevelUp, OnRetract);
				if (humanoidInstance.WorkerBehaviour.HumanoidRoleOwner.HasRole(allItem))
				{
					at.transform.SetAsFirstSibling();
				}
				num++;
			}
			roleLayoutItemViews.SetActiveFromIndex(num, active: false);
		}

		private void OnLevelUp(Role role)
		{
			List<KeyValuePair<string, Action>> buttonActions = new List<KeyValuePair<string, Action>>
			{
				new KeyValuePair<string, Action>("general_yes", Action),
				new KeyValuePair<string, Action>("general_no", delegate
				{
				})
			};
			string promptText = HumanoidRoleUtils.ParseRoleText(UiUtils.Localize.GetText("role_level_up_prompt_info", humanoidInstance), humanoidInstance, role, nextLevel: true);
			MonoSingleton<UIController>.Instance.ShowPrompt(new PromptPanelData(promptText, buttonActions));
			void Action()
			{
				humanoidInstance.WorkerBehaviour.HumanoidRoleOwner.LevelUpRole(role);
				GlobalSaveController.CurrentVillageData.RolesSaveData.SetAnyRoleAssigned();
				string messageText = UiUtils.Localize.GetText("role_level_up_info").Replace("<name>", humanoidInstance.GetFullName()).Replace("<role>", HumanoidRoleUtils.GetRoleNameWithIconAndLevel(role, humanoidInstance));
				MonoSingleton<BlackBarMessageController>.Instance.ShowClickableBlackBarMessage(messageText, humanoidInstance.GetPosition());
				Hide();
			}
		}

		private void OnRetract(Role role)
		{
			List<KeyValuePair<string, Action>> buttonActions = new List<KeyValuePair<string, Action>>
			{
				new KeyValuePair<string, Action>("general_yes", Action),
				new KeyValuePair<string, Action>("general_no", delegate
				{
				})
			};
			MonoSingleton<UIController>.Instance.ShowPrompt(new PromptPanelData("role_retract_prompt_info".ToLocalized(humanoidInstance.GetInfo().BodyType), buttonActions));
			void Action()
			{
				humanoidInstance.WorkerBehaviour.HumanoidRoleOwner.RetractRole();
				string messageText = UiUtils.Localize.GetText("role_retract_info").Replace("<name>", humanoidInstance.GetFullName()).Replace("<role>", HumanoidRoleUtils.GetRoleNameWithIconAndLevel(role, humanoidInstance));
				MonoSingleton<BlackBarMessageController>.Instance.ShowClickableBlackBarMessage(messageText, humanoidInstance.GetPosition());
				Hide();
			}
		}

		private void Awake()
		{
			MainView = content;
			SoundButton[] array = closeButtons;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].onClick.AddListener(OnClose);
			}
		}

		private void OnClose()
		{
			Hide();
			humanoidInstance = null;
		}
	}
}
