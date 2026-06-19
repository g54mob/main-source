using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20.UI
{
	[UsedImplicitly(ImplicitUseTargetFlags.Members)]
	public class FinanceTabBankStatementPanel : OverviewMenuTabPanel
	{
		[SerializeField]
		private GameObject _transactionPrefab;

		public override void Setup(OverviewMenuTab theTabRoot)
		{
			base.Setup(theTabRoot);
			List<HospitalEvent> events = new List<HospitalEvent>();
			_level.HospitalEventLog.GetEvents(ref events, (HospitalEvent he) => he is IHospitalEventFinance hospitalEventFinance && hospitalEventFinance.GetFinanceValue() != 0 && hospitalEventFinance.ShowOnStatement());
			GetComponent<Table>().RowProvider = new BankStatementRowProvider(events, _transactionPrefab);
		}

		protected override void Update()
		{
			base.Update();
		}
	}
}
