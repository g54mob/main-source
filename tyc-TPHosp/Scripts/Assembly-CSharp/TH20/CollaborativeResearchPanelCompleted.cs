using System;
using System.Collections.Generic;
using FullInspector;
using I2.Loc;
using TH20.UI;
using TMPro;
using UnityEngine;

namespace TH20
{
	public class CollaborativeResearchPanelCompleted : CollaborativeResearchPanel
	{
		public Action<Guid?> OnCollectRewardPressed;

		[SerializeField]
		private TMP_Text _letterMainBodyText;

		[SerializeField]
		private TMP_Text _letterHeaderText;

		[SerializeField]
		private TMP_Text _letterFooterText;

		[SerializeField]
		private PlayerAvatar _leaderAvatar;

		[SerializeField]
		private TMP_Text _projectNameText;

		[SerializeField]
		private TMP_Text _projectLeaderText;

		[SerializeField]
		private PlayerAvatar _playerAvatar;

		[SerializeField]
		private TMP_Text _projectContributionText;

		[SerializeField]
		private TMP_Text _projectRewardText;

		[SerializeField]
		private GameObject _projectNewProjectGameObject;

		[SerializeField]
		private TMP_Text _projectNewProjectText;

		[SerializeField]
		private DynamicButton _button;

		[SerializeField]
		private ObjectiveRewardItem[] _projectRewardItems;

		protected override void OnEnable()
		{
			_button.onPrimaryDown.AddListener(OnButtonPressed);
		}

		protected override void OnDisable()
		{
			_button.onPrimaryDown.AddListener(OnButtonPressed);
		}

		public override void Show()
		{
			base.Show();
			CollaborativeProject project = Portfolio.GetProject(ProjectId.Value);
			CollaborativeProjectDefinition collaborativeProjectDefinition = project.LocalPlayerData?.Definition;
			Dictionary<int, uint> dictionary = project.LocalPlayerData?.ResearchData?.CompletedNodeTimestamps;
			int num = 0;
			List<RoomItemDefinition> list = new List<RoomItemDefinition>();
			IRewardMetagame[] completionRewards = collaborativeProjectDefinition.CompletionRewards;
			if (completionRewards != null)
			{
				IRewardMetagame[] array = completionRewards;
				foreach (IRewardMetagame rewardMetagame in array)
				{
					if (rewardMetagame is RewardSilver)
					{
						num += ((RewardSilver)rewardMetagame).Amount;
					}
					if (rewardMetagame is RewardRoomItemMetagame)
					{
						list.Add(((RewardRoomItemMetagame)rewardMetagame).Definition.Instance);
					}
				}
			}
			OnlinePlayerInfo playerInfo = OnlineManager.GetPlayerInfo(project.LeaderOnlinePlayerID);
			_letterHeaderText.text = collaborativeProjectDefinition.VictoryLetterHeader.Translation;
			_letterMainBodyText.text = collaborativeProjectDefinition.VictoryLetterText.Translation;
			_letterFooterText.text = collaborativeProjectDefinition.VictoryLetterFooter.Translation;
			_projectNameText.text = collaborativeProjectDefinition.Name.Translation;
			_projectLeaderText.text = ((playerInfo != null) ? playerInfo.DisplayName : ScriptLocalization.Misc.Unknown_CS);
			_leaderAvatar.PlayerID = project.LeaderOnlinePlayerID;
			_projectContributionText.text = string.Format(ScriptLocalization.Collaborative_GUI.YourContribution_Data_CS, dictionary.Count);
			_playerAvatar.PlayerID = OnlineManager.GetLocalPlayerID();
			GameObjectUtils.SetActive(_projectRewardText.gameObject, list.Count > 0);
			List<CollaborativeProjectDefinition> unlockedProjectDefinition = GetUnlockedProjectDefinition(collaborativeProjectDefinition);
			int num2 = unlockedProjectDefinition?.Count ?? 0;
			GameObjectUtils.SetActive(_projectNewProjectGameObject, num2 > 0);
			if (unlockedProjectDefinition != null && num2 > 0)
			{
				_projectNewProjectText.text = unlockedProjectDefinition[0].Name.Translation;
			}
			RefreshProjectRewardItems(collaborativeProjectDefinition);
		}

		public override void OnGetLatestCompleted()
		{
		}

		private void OnButtonPressed()
		{
			OnCollectRewardPressed.InvokeSafe(ProjectId);
		}

		private List<CollaborativeProjectDefinition> GetUnlockedProjectDefinition(CollaborativeProjectDefinition completedDefinition)
		{
			List<CollaborativeProjectDefinition> list = new List<CollaborativeProjectDefinition>();
			foreach (SharedInstance<CollaborativeProjectDefinition> project in Portfolio.CollaborativeProjectList.Projects)
			{
				if (project.IsNull())
				{
					continue;
				}
				bool flag = false;
				bool flag2 = true;
				foreach (SharedInstance<CollaborativeProjectDefinition> projectPrerequisite in project.Instance.ProjectPrerequisites)
				{
					if (!projectPrerequisite.IsNull())
					{
						if (Portfolio.PortfolioDataController != null && !Portfolio.PortfolioDataController.IsProjectTypeCompleted(projectPrerequisite.Instance))
						{
							flag2 = false;
						}
						if (completedDefinition == projectPrerequisite.Instance)
						{
							flag = true;
						}
					}
				}
				if (flag2 && flag)
				{
					list.Add(project.Instance);
				}
			}
			return list;
		}

		private void RefreshProjectRewardItems(CollaborativeProjectDefinition definition)
		{
			for (int i = 0; i < _projectRewardItems.Length; i++)
			{
				if (i >= definition.CompletionRewards.Length)
				{
					GameObjectUtils.SetActive(_projectRewardItems[i].gameObject, isActive: false);
					continue;
				}
				_projectRewardItems[i].Setup(definition.CompletionRewards[i]);
				GameObjectUtils.SetActive(_projectRewardItems[i].gameObject, isActive: true);
			}
		}
	}
}
