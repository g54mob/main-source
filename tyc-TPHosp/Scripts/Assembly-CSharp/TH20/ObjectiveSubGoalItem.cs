using JetBrains.Annotations;
using TH20.UI;
using TMPro;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class ObjectiveSubGoalItem : MonoBehaviour
	{
		[SerializeField]
		private TMP_Text _goalText;

		[SerializeField]
		private TMP_Text _progressText;

		[SerializeField]
		private ProgressBarMaskable _progressBar;

		[SerializeField]
		private TooltipSpawner _tooltipSpawner;

		[SerializeField]
		private DynamicButton _vaccineButton;

		[SerializeField]
		private CanvasGroup _canvasGroup;

		private Level _level;

		public void Setup(Level level)
		{
			_level = level;
		}

		public void UpdateFrom(ObjectiveSubGoal objectiveSubGoal)
		{
			UpdateLocalizedElementsFrom(objectiveSubGoal);
			if (_progressBar != null)
			{
				if (!objectiveSubGoal.Completed())
				{
					_progressBar.SetProgressSmooth(objectiveSubGoal.PercentComplete());
				}
				else
				{
					_progressBar.Progress = 1f;
				}
			}
			if (!(_vaccineButton != null))
			{
				return;
			}
			if (objectiveSubGoal is SubGoalEpidemic)
			{
				_canvasGroup.interactable = true;
				_vaccineButton.gameObject.SetActive(value: true);
				_vaccineButton.onPrimaryDown.AddListener(delegate
				{
					if (_level != null && !_level.CursorManager.IsModeActive<CursorVaccinate>())
					{
						_level.CursorManager.PushMode(new CursorVaccinate(_level.CursorManager, _level));
					}
				});
			}
			else
			{
				_vaccineButton.gameObject.SetActive(value: false);
			}
		}

		public void UpdateLocalizedElementsFrom(ObjectiveSubGoal objectiveSubGoal)
		{
			if (_goalText != null)
			{
				string text = objectiveSubGoal.Definition.GoalText(objectiveSubGoal.GetOwnerObjective());
				_goalText.text = text;
				GameObjectUtils.SetActive(_goalText.gameObject, text != null);
			}
			if (_progressText != null)
			{
				_progressText.text = objectiveSubGoal.ProgressText();
			}
			if (!(_tooltipSpawner != null))
			{
				return;
			}
			_tooltipSpawner.SetDataProvider(delegate(Tooltip tooltip)
			{
				if (objectiveSubGoal.Definition.AdviceText.Term != null)
				{
					tooltip.Text = objectiveSubGoal.Definition.AdviceText.Translation;
					GameObjectUtils.SetActive(tooltip.gameObject, isActive: true);
				}
				else
				{
					GameObjectUtils.SetActive(tooltip.gameObject, isActive: false);
				}
			});
		}
	}
}
