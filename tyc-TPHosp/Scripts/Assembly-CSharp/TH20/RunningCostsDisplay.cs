using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	public class RunningCostsDisplay : MonoBehaviour
	{
		[SerializeField]
		private TMP_Text _text;

		[SerializeField]
		private Animator _animator;

		[SerializeField]
		private TooltipSpawner _tooltipSpawner;

		[SerializeField]
		private LocalisedString _tooltipBody;

		[SerializeField]
		private LocalisedString _tooltipBodyVibe;

		[SerializeField]
		private LocalisedString _tooltipTitleVibe;

		[SerializeField]
		private Image _runningCostsImage;

		[SerializeField]
		public Image _logoHolistix;

		[SerializeField]
		public Image _logoVibe;

		private ChallengeBudget _budgetChallenge;

		private float _currentBudgetPercent;

		private int _currentColourMapping;

		public void Initialise(ChallengeBudget challenge)
		{
			_budgetChallenge = challenge;
			if (_budgetChallenge != null)
			{
				_budgetChallenge.OnBudgetUpdated.AddListener(OnBudgetUpdated);
				if (_logoVibe != null)
				{
					GameObjectUtils.SetActive(_logoVibe.gameObject, _budgetChallenge.ShouldUseVibeIcon());
				}
				if (_logoHolistix != null)
				{
					GameObjectUtils.SetActive(_logoHolistix.gameObject, !_budgetChallenge.ShouldUseVibeIcon());
				}
			}
			_currentBudgetPercent = 0f;
			if (_tooltipSpawner != null)
			{
				_tooltipSpawner.SetDataProvider(TooltipDataProvider);
			}
			_currentColourMapping = -1;
			OnBudgetUpdated();
		}

		private void OnBudgetUpdated()
		{
			if (!(_text != null))
			{
				return;
			}
			_text.text = StringUtils.FormatPercentageValue(_budgetChallenge.BudgetPercent);
			if (_currentBudgetPercent > _budgetChallenge.BudgetPercent)
			{
				if (_animator != null)
				{
					_animator.ResetTrigger("Negative");
					_animator.ResetTrigger("Positive");
					_animator.SetTrigger("Negative");
				}
			}
			else if (_animator != null)
			{
				_animator.ResetTrigger("Negative");
				_animator.ResetTrigger("Positive");
				_animator.SetTrigger("Positive");
			}
			_currentBudgetPercent = _budgetChallenge.BudgetPercent;
			if (!(_runningCostsImage != null))
			{
				return;
			}
			ColourPercentMapping[] colourPercentMappings = _budgetChallenge.ColourPercentMappings;
			for (int i = 0; i < colourPercentMappings.Length; i++)
			{
				if (_currentBudgetPercent * 100f <= colourPercentMappings[i].upToPercent)
				{
					if (i != _currentColourMapping)
					{
						_runningCostsImage.color = colourPercentMappings[i].Colour;
						_currentColourMapping = i;
					}
					break;
				}
			}
		}

		private void TooltipDataProvider(Tooltip tooltip)
		{
			string text = (_budgetChallenge.ShouldUseVibeIcon() ? _tooltipBodyVibe.Translation : _tooltipBody.Translation);
			text = text.Replace("{[LOWER]}", StringUtils.FormatPercentageValue(_budgetChallenge.MinBudgetPercent * 0.01f));
			text = text.Replace("{[UPPER]}", StringUtils.FormatPercentageValue(_budgetChallenge.MaxBudgetPercent * 0.01f));
			tooltip.Text = text;
			TooltipReputation tooltipReputation = tooltip as TooltipReputation;
			if (_budgetChallenge.ShouldUseVibeIcon() && tooltipReputation != null)
			{
				tooltipReputation.ReputationDescription.text = _tooltipTitleVibe.Translation;
			}
		}

		private void Start()
		{
		}

		private void Update()
		{
		}

		private void OnDestroy()
		{
			if (_budgetChallenge != null)
			{
				_budgetChallenge.OnBudgetUpdated.RemoveListener(OnBudgetUpdated);
			}
		}
	}
}
