using JetBrains.Annotations;
using TMPro;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class TooltipBalance : Tooltip
	{
		public TMP_Text RevenueText;

		public TMP_Text ExpensesText;

		public TMP_Text NetIncomeText;

		public TMP_Text SilverText;
	}
}
