using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Gh.Tk.UI.Dialogs.FinanceLog
{
	public class FinanceLogDialog3DUIView : BaseTavernLogDialog3DUIView
	{
		[SerializeField]
		private Button3DUIView _closeButton;

		[SerializeField]
		private Button3DUIView _financeGhostButton;

		[SerializeField]
		private Button3DUIView _ledgerButton;

		[SerializeField]
		private Button3DUIView _loansButton;

		[Header("Prefabs")]
		[SerializeField]
		private GameObject _dayLogPrefab;

		[SerializeField]
		private TextMeshPro _incomeHeader;

		[SerializeField]
		private TextMeshPro _expenseHeader;

		private static PrefabObjectPool _dayLogPool;

		private List<DayLog3DUIView> _dayLogs;

		[SerializeField]
		private GameObject _loanOfferCardPrefab;

		[SerializeField]
		private GameObject _loansPage;

		[SerializeField]
		private Container3DUIView _loanOffersContainer;

		[SerializeField]
		private GameObject _ledgerPage;

		protected override void Awake()
		{
		}

		private void Start()
		{
		}

		protected override void OpenInternal(ShowHideAnimationSpeed speed)
		{
		}

		private void Clear()
		{
		}

		private void UpdateLogs()
		{
		}

		private void CloseAllPages()
		{
		}

		private void PopulateLoans()
		{
		}

		public void OpenLoansPage()
		{
		}

		public void OpenLedgerPage(bool forceRefresh = false)
		{
		}

		public override bool IsBackable()
		{
			return false;
		}

		public override void Back()
		{
		}
	}
}
