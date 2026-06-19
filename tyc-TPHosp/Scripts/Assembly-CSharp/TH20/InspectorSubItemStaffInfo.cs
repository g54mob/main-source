using System;
using I2.Loc;
using JetBrains.Annotations;
using TH20.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class InspectorSubItemStaffInfo : InspectorSubItem
	{
		[SerializeField]
		private TMP_Text _staffRoleText;

		[SerializeField]
		private StarIcons _stars;

		[SerializeField]
		private TooltipSpawner _starRatingTooltip;

		[SerializeField]
		private QualificationIcons _qualifications;

		[SerializeField]
		private TMP_Text _salaryText;

		[SerializeField]
		private Slider _payRiseSlider;

		[SerializeField]
		private Color _payRiseColourTint;

		[SerializeField]
		private TooltipSpawner _paySatisfactionTooltip;

		[SerializeField]
		private StaffHappinessIcon _happinessIcon;

		[SerializeField]
		private ButtonAnimator _payRiseConfirmButtonAnimator;

		[SerializeField]
		private TMP_Text _activityText;

		[SerializeField]
		private Image _activitySprite;

		[SerializeField]
		private TMP_Text _statusEffectText;

		[SerializeField]
		private TooltipSpawner _statusEffectTooltip;

		[SerializeField]
		private TMP_Text _traitsText;

		[SerializeField]
		private TooltipSpawner _traitsTooltip;

		[SerializeField]
		private ProgressBarMaskable _progressBarHappiness;

		[SerializeField]
		private TooltipSpawner _happinessTooltip;

		[SerializeField]
		private ProgressBarMaskable _progressBarEnergy;

		[SerializeField]
		private TooltipSpawner _energyTooltip;

		private Staff _staff;

		public void Setup(Staff staff)
		{
			_staff = staff;
			if (_staff.ModifiersComponent != null)
			{
				_statusEffectTooltip.SetDataProvider(delegate(Tooltip tooltip)
				{
					tooltip.Text = _staff.ModifiersComponent.GetTooltipText(_staff.Gender);
				});
			}
			_traitsTooltip.SetDataProvider(delegate(Tooltip tooltip)
			{
				tooltip.Text = _staff.Traits.GetTooltipText(_staff.Gender);
			});
			_happinessTooltip.SetDataProvider(SetHappinessTooltip);
			_energyTooltip.SetDataProvider(SetEnergyTooltip);
			_paySatisfactionTooltip.SetDataProvider(delegate(Tooltip tooltip)
			{
				tooltip.Text = GameStringUtils.GetStaffPaySatisfaction(_staff, _staff.GetSalary());
			});
			_starRatingTooltip.SetDataProvider(delegate(Tooltip tooltip)
			{
				tooltip.Text = GameStringUtils.GetStaffRankTooltip(_staff);
			});
			CharacterEvents characterEvents = _staff.Level.CharacterEvents;
			characterEvents.OnStaffSalaryChanged = (Action<Staff, int>)Delegate.Remove(characterEvents.OnStaffSalaryChanged, new Action<Staff, int>(OnStaffSalaryChanged));
			CharacterEvents characterEvents2 = _staff.Level.CharacterEvents;
			characterEvents2.OnStaffSalaryChanged = (Action<Staff, int>)Delegate.Combine(characterEvents2.OnStaffSalaryChanged, new Action<Staff, int>(OnStaffSalaryChanged));
			ResetPayRiseSlider();
		}

		private void OnStaffSalaryChanged(Staff staff, int salary)
		{
			if (staff == _staff)
			{
				ResetPayRiseSlider();
			}
		}

		private void Start()
		{
			_payRiseConfirmButtonAnimator.Button.onPrimaryDown.AddListener(OnPayRiseConfirm);
		}

		public void OnDestroy()
		{
			if (_staff != null)
			{
				CharacterEvents characterEvents = _staff.Level.CharacterEvents;
				characterEvents.OnStaffSalaryChanged = (Action<Staff, int>)Delegate.Remove(characterEvents.OnStaffSalaryChanged, new Action<Staff, int>(OnStaffSalaryChanged));
			}
			_payRiseConfirmButtonAnimator.Button.onPrimaryDown.RemoveListener(OnPayRiseConfirm);
		}

		private void Update()
		{
			if (_staff != null)
			{
				if (_staff.RankDefinition != null)
				{
					_staffRoleText.text = _staff.RankDefinition.GetTitleLocalised(_staff.Gender).Translation;
					_stars.SetLevel(_staff.Rank, _staff.IsReadyForPromotion, _staff.XP.Value() / _staff.RankDefinition.MaximumXP);
				}
				_activityText.text = _staff.GetStatusText();
				_activitySprite.sprite = _staff.GetStatusSprite();
				_qualifications.UpdateFrom(_staff.Qualifications, _staff.MaxQualifications, _staff.Level.CharacterManager.StaffMembers);
				if (_staff.ModifiersComponent != null)
				{
					_statusEffectText.text = _staff.ModifiersComponent.GetHUDString(_staff.Gender);
				}
				if (_staff.Traits != null)
				{
					_traitsText.text = _staff.Traits.GetShortName(_staff.Gender);
				}
				if (_progressBarHappiness != null)
				{
					_progressBarHappiness.Progress = ((_staff.Happiness != null) ? (_staff.Happiness.Value() / 100f) : 0f);
				}
				if (_staff.Energy != null)
				{
					_progressBarEnergy.Progress = _staff.Energy.Value() / 100f;
				}
				if (_payRiseSlider.maxValue > _payRiseSlider.minValue && !_staff.HasBeenFired() && !_staff.HasResigned())
				{
					_payRiseSlider.enabled = true;
					int num = (int)_payRiseSlider.value;
					_salaryText.text = $"{StringUtils.FormatCurrencyWithoutSymbol(num)} {ScriptLocalization.Inspector_Staff.PerAnnum_CS}";
					_happinessIcon.UpdateFrom(GameAlgorithms.CalculatePaySatisfactionLevel(_staff.GetDesiredSalaryDifference(num)));
					bool flag = _payRiseSlider.normalizedValue > 0f;
					_salaryText.color = (flag ? _payRiseColourTint : Color.white);
					_payRiseConfirmButtonAnimator.CurrentState = ((!flag) ? ButtonAnimator.State.Unselectable : ButtonAnimator.State.Selectable);
				}
				else
				{
					_payRiseSlider.enabled = false;
					_payRiseSlider.normalizedValue = 0f;
					_salaryText.text = $"{StringUtils.FormatCurrencyWithoutSymbol(_staff.GetSalary())} {ScriptLocalization.Inspector_Staff.PerAnnum_CS}";
					_salaryText.color = Color.white;
					_happinessIcon.UpdateFrom(GameAlgorithms.CalculatePaySatisfactionLevel(_staff.GetDesiredSalaryDifference(_staff.GetSalary())));
					_payRiseConfirmButtonAnimator.CurrentState = ButtonAnimator.State.Unselectable;
				}
			}
		}

		private void OnPayRiseConfirm()
		{
			_staff.SetSalary((int)_payRiseSlider.value, silent: false);
			ResetPayRiseSlider();
		}

		private void ResetPayRiseSlider()
		{
			int salary = _staff.GetSalary();
			int num = (int)((float)_staff.GetDesiredSalary() * (1f + GameAlgorithms.Config.MaxDesiredSalary));
			_payRiseSlider.minValue = salary;
			_payRiseSlider.maxValue = num;
			_payRiseSlider.normalizedValue = 0f;
		}

		private void SetHappinessTooltip(Tooltip tooltip)
		{
			if (_staff != null && _staff.Happiness != null)
			{
				tooltip.Text = string.Format(ScriptLocalization.Inspector.Stat_Happiness_CS, StringUtils.FormatPercentageValue(_staff.Happiness.Value() / 100f));
			}
		}

		private void SetEnergyTooltip(Tooltip tooltip)
		{
			if (_staff != null && _staff.Energy != null)
			{
				tooltip.Text = string.Format(ScriptLocalization.Inspector.Stat_Energy_CS, StringUtils.FormatPercentageValue(_staff.Energy.Value() / 100f));
			}
		}

		private void SetPaySatisfcationTooltip(Tooltip tooltip)
		{
			if (_staff != null)
			{
				switch (GameAlgorithms.CalculatePaySatisfactionLevel(_staff.GetDesiredSalaryDifference(_staff.GetSalary())))
				{
				case StaffDefinition.Satisfaction.VeryUnhappy:
					tooltip.Text = ScriptLocalization.Staff.Pay_VeryUnhappy_CS;
					break;
				case StaffDefinition.Satisfaction.Unhappy:
					tooltip.Text = ScriptLocalization.Staff.Pay_Unhappy_CS;
					break;
				case StaffDefinition.Satisfaction.Satisfied:
					tooltip.Text = ScriptLocalization.Staff.Pay_Satisfied_CS;
					break;
				case StaffDefinition.Satisfaction.Happy:
					tooltip.Text = ScriptLocalization.Staff.Pay_Happy_CS;
					break;
				case StaffDefinition.Satisfaction.VeryHappy:
					tooltip.Text = ScriptLocalization.Staff.Pay_VeryHappy_CS;
					break;
				}
			}
		}
	}
}
