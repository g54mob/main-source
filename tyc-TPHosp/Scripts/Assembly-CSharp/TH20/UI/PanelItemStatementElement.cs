using JetBrains.Annotations;
using TMPro;
using UnityEngine;

namespace TH20.UI
{
	[UsedImplicitly(ImplicitUseTargetFlags.Members)]
	public class PanelItemStatementElement : PanelItem
	{
		[SerializeField]
		private TMP_Text _date;

		[SerializeField]
		private TMP_Text _transaction;

		[SerializeField]
		private TMP_Text _charge;

		public void SetData(HospitalEvent hospitalEvent)
		{
			if (hospitalEvent == null)
			{
				_date.text = string.Empty;
				_transaction.text = string.Empty;
				_charge.text = string.Empty;
			}
			else
			{
				_date.text = hospitalEvent.GetDateString();
				_transaction.text = hospitalEvent.GetDescription();
				_charge.text = StringUtils.FormatCurrency(((IHospitalEventFinance)hospitalEvent).GetFinanceValue());
			}
		}
	}
}
