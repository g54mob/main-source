using I2.Loc;
using JetBrains.Annotations;
using TH20.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class CareersMenuRow : MonoBehaviour
	{
		[SerializeField]
		private TMP_Text _description;

		[SerializeField]
		private TMP_Text _progressText;

		[SerializeField]
		private ProgressBarMaskable _progressBar;

		[SerializeField]
		private GameObject _progressBarContainer;

		[SerializeField]
		private Button _collectButton;

		[SerializeField]
		private TooltipSpawner _tooltipSpawner;

		private MetagameObjective Objective;

		private MetagameMap _metagameMap;

		private CareersMenu _owner;

		private void OnEnable()
		{
			_collectButton.onClick.AddListener(OnCollectRewardPressed);
		}

		private void OnDisable()
		{
			_collectButton.onClick.RemoveListener(OnCollectRewardPressed);
		}

		public void Setup(MetagameObjective objective, CareersMenu owner, MetagameMap metagameMap)
		{
			Objective = objective;
			_owner = owner;
			_metagameMap = metagameMap;
			ObjectiveSubGoal objectiveSubGoal = objective.SubGoals[0];
			_description.text = objectiveSubGoal.Definition.GoalText(objective);
			_progressText.text = objectiveSubGoal.ProgressText();
			_progressBar.Progress = objectiveSubGoal.PercentComplete();
			if (Objective.CompletionResult == TH20.Objective.CompletionType.Successful)
			{
				GameObjectUtils.SetActive(_progressBarContainer, isActive: false);
				GameObjectUtils.SetActive(_collectButton.gameObject, !Objective.IsRewardCollected);
			}
			else
			{
				GameObjectUtils.SetActive(_progressBarContainer, isActive: true);
				GameObjectUtils.SetActive(_collectButton.gameObject, isActive: false);
			}
			LocalizationManager.OnLocalizeEvent += OnLocalize;
			_tooltipSpawner.SetDataProvider(delegate(Tooltip tooltip)
			{
				tooltip.Text = ScriptLocalization.Notification.Challenge_ChallengeText_CS.Replace("{[REWARDS]}", GetRewardsText());
			});
		}

		private void OnDestroy()
		{
			LocalizationManager.OnLocalizeEvent -= OnLocalize;
		}

		private void OnLocalize()
		{
			if (Objective != null && Objective.SubGoals != null && Objective.SubGoals.Count >= 1)
			{
				ObjectiveSubGoal objectiveSubGoal = Objective.SubGoals[0];
				if (objectiveSubGoal != null && objectiveSubGoal.Definition != null)
				{
					_description.text = objectiveSubGoal.Definition.GoalText(Objective);
				}
			}
		}

		private string GetRewardsText()
		{
			return Objective.Definition.GetRewardsString(Objective, Objective.Definition.CompletionRewards);
		}

		private void OnCollectRewardPressed()
		{
			if (Objective.State == TH20.Objective.ObjectiveState.Finished && !Objective.IsRewardCollected)
			{
				Objective.GiveRewards(Objective.CompletionResult);
				AdvisorMenu advisorMenu = _metagameMap.HUD.FindMenu<AdvisorMenu>();
				if (advisorMenu != null)
				{
					AdvisorMessageDefinition definition = new AdvisorMessageDefinition
					{
						Duration = 10f,
						UserCanDismiss = true,
						Message = ScriptLocalization.Advisor.CareerGoalRewards_CS.Replace("{[REWARD]}", GetRewardsText())
					};
					advisorMenu.ShowAdvisorMessage(definition);
				}
				_owner.Refresh();
			}
		}
	}
}
