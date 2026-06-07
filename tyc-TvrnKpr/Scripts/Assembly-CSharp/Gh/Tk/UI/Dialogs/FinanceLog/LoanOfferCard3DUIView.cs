using UnityEngine;

namespace Gh.Tk.UI.Dialogs.FinanceLog
{
	public class LoanOfferCard3DUIView : MonoBehaviour
	{
		private Animator _animator;

		private static readonly int _animatorKey;

		[Header("Paper Backer Containers")]
		[SerializeField]
		private Transform[] _paperBackerContainers;

		[Header("Locked State")]
		[SerializeField]
		private TextBlock3DUIView _notAvailableValue;

		[SerializeField]
		private Stars3DUIView _stars3DUIView;

		[Header("Offer State")]
		[SerializeField]
		private TextBlock3DUIView _amountValue;

		[SerializeField]
		private TextBlock3DUIView _interestValue;

		[SerializeField]
		private TextBlock3DUIView _lengthValue;

		[SerializeField]
		private TextBlock3DUIView _costPerDayValue;

		[SerializeField]
		private TextBlock3DUIView _totalCostValue;

		[SerializeField]
		private TextBlock3DUIView _expiryLabel;

		[SerializeField]
		private Button3DUIView _offerButton;

		[Header("Paying back state")]
		[SerializeField]
		private TextBlock3DUIView _paybackAmountRemainingValue;

		[SerializeField]
		private TextBlock3DUIView _paybackDaysRemainingValue;

		[SerializeField]
		private TextBlock3DUIView _paybackDayCostValue;

		[SerializeField]
		private TextBlock3DUIView _paybackInterestValue;

		[SerializeField]
		private TextBlock3DUIView _paybackPayInFullValue;

		[SerializeField]
		private Button3DUIView _paybackButton;

		private Loan _loan;

		private bool _ignoreButtonStateChanges;

		public void SetData(Loan loan)
		{
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private void UpdateButtonStates()
		{
		}

		private void Awake()
		{
		}

		private void Start()
		{
		}

		private void PaybackButtonClicked()
		{
		}

		private int GetTargetLoanCardState()
		{
			return 0;
		}

		private void OfferButtonClicked()
		{
		}

		private void UpdateCard()
		{
		}

		private string GetDaysLabel(int days)
		{
			return null;
		}
	}
}
