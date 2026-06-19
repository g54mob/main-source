using System;
using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	[Serializable]
	public class InboxStaffPromotionContentsData
	{
		[SerializeField]
		private TMP_Text _messageText;

		[SerializeField]
		private TMP_Text _promotionText;

		[SerializeField]
		private TMP_Text _payRiseText;

		[SerializeField]
		private Slider _paySlider;

		[SerializeField]
		private StaffHappinessIcon _paySatisfactionIcon;

		private NotificationStaffPromotion _message;

		private int _currentSalary;

		private int _desiredSalary;

		public void Setup(NotificationStaffPromotion message)
		{
			_message = message;
			_messageText.text = message.GetMessageText().Replace("\\n", "\n");
			Staff staff = message.Staff;
			int num = staff.Rank + 1;
			if (num >= 5)
			{
				num = 4;
			}
			StaffRank staffRank = staff.Definition._rank[num];
			string translation = staff.RankDefinition.GetTitleLocalised(staff.Gender).Translation;
			string translation2 = staffRank.GetTitleLocalised(staff.Gender).Translation;
			string benefitsText = StaffRank.GetBenefitsText(staff.RankDefinition, staffRank);
			_promotionText.text = LocalisedString.Replace(ScriptLocalization.Notification.StaffPromotion_Benefits_CS, new SubPair[3]
			{
				new SubPair("{[RANK]}", translation),
				new SubPair("{[NEXTRANK]}", translation2),
				new SubPair("{[BENEFITS]}", benefitsText)
			});
			_currentSalary = staff.GetSalary();
			_desiredSalary = GameAlgorithms.CalculateDesiredSalary(staff.Definition, num, 0f, staff.Qualifications, staff.Traits, staff.SalaryPremiumMultiplier);
			_desiredSalary = Mathf.Max(_desiredSalary, _currentSalary);
			int num2 = (int)((float)_desiredSalary * (1f + GameAlgorithms.Config.MaxDesiredSalary));
			_paySlider.minValue = _currentSalary;
			_paySlider.maxValue = num2;
			_paySlider.value = _desiredSalary;
			_paySlider.onValueChanged.AddListener(PaySliderChanged);
			PaySliderChanged(_desiredSalary);
		}

		private void PaySliderChanged(float value)
		{
			int num = (int)value;
			_message.NewSalary = num;
			_payRiseText.text = LocalisedString.Replace(ScriptLocalization.Notification.StaffPromotion_PayRise_CS, new SubPair[2]
			{
				new SubPair("{[SALARY]}", StringUtils.FormatCurrency(_currentSalary)),
				new SubPair("{[NEWSALARY]}", StringUtils.FormatCurrency(num))
			});
			float percentDifference = (float)(num - _desiredSalary) / (float)_desiredSalary;
			_paySatisfactionIcon.UpdateFrom(GameAlgorithms.CalculatePaySatisfactionLevel(percentDifference));
		}
	}
}
