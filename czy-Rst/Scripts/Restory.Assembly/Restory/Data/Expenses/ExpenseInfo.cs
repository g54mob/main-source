using Restory.Data.Base;
using UnityEngine;

namespace Restory.Data.Expenses
{
	[CreateAssetMenu(fileName = "ExpenseInfo - Name", menuName = "Restory/Money/ExpenseInfo")]
	public class ExpenseInfo : RestoryEntityInfoBase
	{
		[SerializeField]
		private string nameLocalizationKey;

		[SerializeField]
		private int orderInGUI;

		public string NameLocalizationKey => nameLocalizationKey;

		public int OrderInGUI => orderInGUI;
	}
}
