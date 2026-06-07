using VampireSurvivors.UI;

namespace VampireSurvivors
{
	public class AgeGatePanel : BaseAccountPagePanel
	{
		private LabeledButtonUI _confirmButton;

		private DateOfBirthField _dob;

		private int _day;

		private int _month;

		private int _year;

		private bool _madeChange;

		public AgeGatePanel(AccountPage accountPage)
			: base(null)
		{
		}

		public override void Build()
		{
		}

		private void DisableButton()
		{
		}

		private void EnableButton()
		{
		}

		private void OnAllFieldsFilled()
		{
		}

		private void OnDaySet(int i)
		{
		}

		private void OnMonthSet(int i)
		{
		}

		private void OnYearSet(int i)
		{
		}

		private bool CheckAllSet()
		{
			return false;
		}

		private void OnConfirmPressed()
		{
		}
	}
}
