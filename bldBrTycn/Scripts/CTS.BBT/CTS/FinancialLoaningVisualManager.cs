using CTS.Core;
using UnityEngine;

namespace CTS
{
	public class FinancialLoaningVisualManager : MonoBehaviour
	{
		[SerializeField]
		private GameObject _loanContentAnchor;

		[SerializeField]
		private FinancialLoaningContract _loanPrefab;

		private FinancialLoaningContract _tmpLoan;

		private void OnEnable()
		{
			FinancialLoaningManager.OnLoanManagerInitialized += SetupLoans;
		}

		private void OnDestroy()
		{
			FinancialLoaningManager.OnLoanManagerInitialized -= SetupLoans;
		}

		private void SetupLoans()
		{
			foreach (FinancialLoanSO item in MonoSingleton<FinancialLoaningManager>.Instance.FinancialLoanSO)
			{
				_tmpLoan = Object.Instantiate(_loanPrefab, _loanContentAnchor.transform);
				MonoSingleton<FinancialLoaningManager>.Instance.NewLoanInstantiated(_tmpLoan);
				_tmpLoan.Setup(item);
			}
		}
	}
}
