using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Localization;

namespace CTS
{
	[CreateAssetMenu(menuName = "CTS/Financial/Create New Loaning Settings", fileName = "New Loaning Settings")]
	public class FinancialLoanSO : ScriptableObject
	{
		[SerializeField]
		[Space(10f)]
		[BoxGroup("Bank Loan")]
		public LocalizedString LoanName;

		[SerializeField]
		[BoxGroup("Bank Loan")]
		public Sprite LoanSprite;

		[SerializeField]
		[BoxGroup("Bank Loan")]
		public int LoanIncrementation;

		[SerializeField]
		[BoxGroup("Bank Loan")]
		[MinMaxSlider(1f, 1000000f)]
		public Vector2Int LoanMoneyFromTo;

		[SerializeField]
		[BoxGroup("Bank Loan")]
		public int LoanPrestigeToUnlock;

		[SerializeField]
		[BoxGroup("Bank Loan")]
		[Range(1f, 120f)]
		public int[] LoanBorrowingPeriod;

		[SerializeField]
		[BoxGroup("Bank Loan")]
		public int LoanInterestPercent;
	}
}
