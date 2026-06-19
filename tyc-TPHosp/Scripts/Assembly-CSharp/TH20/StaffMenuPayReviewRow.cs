using System;
using System.Collections.Generic;
using I2.Loc;
using JetBrains.Annotations;
using TH20.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class StaffMenuPayReviewRow : StaffMenuRowBase
	{
		[Header("Salary")]
		[SerializeField]
		private ButtonAnimator _acceptSalaryButton;

		[SerializeField]
		private Color _salaryTextColour;

		[SerializeField]
		private Color _salaryTextColourModified;

		[SerializeField]
		private Color _salaryTextColourUnhappy;

		[SerializeField]
		private TMP_Text _salaryText;

		[SerializeField]
		private Image _salaryHolder;

		[SerializeField]
		private Sprite _salaryHolderModified;

		[SerializeField]
		private Sprite _acceptButtonActive;

		[Header("Satisfaction")]
		[SerializeField]
		private StaffHappinessIcon _paySatisfactionIcon;

		[SerializeField]
		private TooltipSpawner _paySatisfactionTooltip;

		[SerializeField]
		private Slider _salarySlider;

		[Header("Happiness")]
		[SerializeField]
		private ProgressBarMaskable _happinessProgressBar;

		[SerializeField]
		private TooltipSpawner _happinessTooltip;

		private int _initialSalary;

		private int _maxSalary;

		private int potentialPayRise;

		private DynamicButton _acceptSalaryDynamicButton;

		private Image _acceptSalaryButtonImage;

		public bool CanRevert { get; private set; }

		public bool IsSatisfied { get; private set; }

		public float SalarySliderValue
		{
			get
			{
				if (!(_salarySlider != null))
				{
					return 0f;
				}
				return _salarySlider.value;
			}
			set
			{
				if (_salarySlider != null)
				{
					_salarySlider.value = value;
				}
			}
		}

		public override void Setup(Staff staff, List<JobDescription> jobs, StaffMenu staffMenu)
		{
			base.Setup(staff, jobs, staffMenu);
			if (_happinessTooltip != null)
			{
				_happinessTooltip.SetDataProvider(delegate(Tooltip tooltip)
				{
					tooltip.Text = string.Format(ScriptLocalization.Inspector.Stat_Happiness_CS, StringUtils.FormatPercentageValue((base.Staff.Happiness != null) ? (base.Staff.Happiness.Value() / 100f) : 0f));
				});
			}
			if (base.Staff != null)
			{
				_maxSalary = (int)((float)base.Staff.GetDesiredSalary() * (1f + GameAlgorithms.Config.MaxDesiredSalary));
			}
			if ((bool)_acceptSalaryButton)
			{
				_acceptSalaryButtonImage = _acceptSalaryButton.GetComponent<Image>();
				_acceptSalaryDynamicButton = _acceptSalaryButton.GetComponent<DynamicButton>();
				if ((bool)_acceptSalaryDynamicButton)
				{
					_acceptSalaryDynamicButton.onPrimaryDown.AddListener(GivePayRise);
				}
			}
			if (base.Staff != null && _paySatisfactionTooltip != null)
			{
				_paySatisfactionTooltip.SetDataProvider(delegate(Tooltip tooltip)
				{
					tooltip.Text = GameStringUtils.GetStaffPaySatisfaction(base.Staff, potentialPayRise);
				});
			}
			if (base.Level != null)
			{
				CharacterEvents characterEvents = base.Level.CharacterEvents;
				characterEvents.OnStaffSalaryChanged = (Action<Staff, int>)Delegate.Remove(characterEvents.OnStaffSalaryChanged, new Action<Staff, int>(OnStaffSalaryChanged));
				CharacterEvents characterEvents2 = base.Level.CharacterEvents;
				characterEvents2.OnStaffSalaryChanged = (Action<Staff, int>)Delegate.Combine(characterEvents2.OnStaffSalaryChanged, new Action<Staff, int>(OnStaffSalaryChanged));
			}
		}

		public void SetupPay(int initialSalary, bool canRevert, bool isSatisfied)
		{
			_initialSalary = initialSalary;
			CanRevert = canRevert;
			IsSatisfied = isSatisfied;
		}

		public override void OnDestroy()
		{
			base.OnDestroy();
			if (base.Level != null)
			{
				CharacterEvents characterEvents = base.Level.CharacterEvents;
				characterEvents.OnStaffSalaryChanged = (Action<Staff, int>)Delegate.Remove(characterEvents.OnStaffSalaryChanged, new Action<Staff, int>(OnStaffSalaryChanged));
			}
			if ((bool)_acceptSalaryDynamicButton)
			{
				_acceptSalaryDynamicButton.onPrimaryDown.RemoveListener(GivePayRise);
			}
		}

		public void Revert()
		{
			base.Staff.SetSalary(_initialSalary, silent: true);
			CanRevert = false;
		}

		public static bool IsStaffSatisfied(Staff staff)
		{
			return GameAlgorithms.CalculatePaySatisfactionLevel(staff.GetDesiredSalaryDifference()) switch
			{
				StaffDefinition.Satisfaction.VeryUnhappy => false, 
				StaffDefinition.Satisfaction.Unhappy => false, 
				StaffDefinition.Satisfaction.Satisfied => true, 
				StaffDefinition.Satisfaction.Happy => true, 
				StaffDefinition.Satisfaction.VeryHappy => true, 
				_ => false, 
			};
		}

		public static bool SatisfyPayRequest(Staff staff)
		{
			if (!IsStaffSatisfied(staff))
			{
				staff.SetSalary(Mathf.Max(staff.GetDesiredSalary(), staff.GetSalary()), silent: false);
				return true;
			}
			return false;
		}

		public static void IncreasePay(Staff staff, float percentage)
		{
			int num = (int)((float)staff.GetDesiredSalary() * (1f + GameAlgorithms.Config.MaxDesiredSalary));
			int salary = (int)Mathf.Min((float)staff.GetSalary() * (1f + percentage), num);
			staff.SetSalary(salary, silent: false);
		}

		private void OnStaffSalaryChanged(Staff staff, int salary)
		{
			if (staff == base.Staff)
			{
				_salarySlider.value = 0f;
			}
		}

		private void GivePayRise()
		{
			if (potentialPayRise > 0)
			{
				base.Staff.SetSalary(potentialPayRise, silent: false);
				potentialPayRise = 0;
				_salarySlider.value = 0f;
			}
		}

		public override void Refresh(bool instant = false)
		{
			base.Refresh(instant);
			if (base.Staff != null)
			{
				int salary = base.Staff.GetSalary();
				potentialPayRise = salary + (int)(_salarySlider.normalizedValue * (float)(_maxSalary - salary));
				if (potentialPayRise != salary && _maxSalary > salary)
				{
					_acceptSalaryButton.enabled = true;
					_acceptSalaryButton.CurrentState = ButtonAnimator.State.Selectable;
					_acceptSalaryButtonImage.overrideSprite = _acceptButtonActive;
					_salaryHolder.overrideSprite = _salaryHolderModified;
					StaffDefinition.Satisfaction satisfaction = GameAlgorithms.CalculatePaySatisfactionLevel(base.Staff.GetDesiredSalaryDifference(potentialPayRise));
					_paySatisfactionIcon.UpdateFrom(satisfaction);
					int num = (potentialPayRise - salary) * 100 / salary;
					_salaryText.color = _salaryTextColourModified;
					_salaryText.text = StringUtils.FormatCurrency(potentialPayRise) + $"(+{num}%)";
				}
				else
				{
					_acceptSalaryButton.CurrentState = ButtonAnimator.State.Unselectable;
					_acceptSalaryButton.enabled = false;
					_acceptSalaryButtonImage.overrideSprite = null;
					_salaryHolder.overrideSprite = null;
					StaffDefinition.Satisfaction satisfaction2 = GameAlgorithms.CalculatePaySatisfactionLevel(base.Staff.GetDesiredSalaryDifference());
					_salaryText.color = ((satisfaction2 switch
					{
						StaffDefinition.Satisfaction.VeryUnhappy => false, 
						StaffDefinition.Satisfaction.Unhappy => false, 
						StaffDefinition.Satisfaction.Satisfied => true, 
						StaffDefinition.Satisfaction.Happy => true, 
						StaffDefinition.Satisfaction.VeryHappy => true, 
						_ => false, 
					}) ? _salaryTextColour : _salaryTextColourUnhappy);
					_salaryText.text = StringUtils.FormatCurrency(salary);
					_paySatisfactionIcon.UpdateFrom(satisfaction2);
				}
				float num2 = ((base.Staff.Happiness != null) ? (base.Staff.Happiness.Value() / 100f) : 0f);
				if (instant)
				{
					_happinessProgressBar.Progress = num2;
				}
				else
				{
					_happinessProgressBar.SetProgressSmooth(num2);
				}
			}
		}
	}
}
