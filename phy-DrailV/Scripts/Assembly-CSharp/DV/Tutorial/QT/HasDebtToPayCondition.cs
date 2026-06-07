using DV.Localization;
using DV.ServicePenalty;
using DV.Utils;

namespace DV.Tutorial.QT
{
	public class HasDebtToPayCondition : AQuickTutorialCondition
	{
		private string locoID;

		public HasDebtToPayCondition(string locoID)
		{
			this.locoID = locoID;
		}

		public override string Check()
		{
			for (int i = 0; i < SingletonBehaviour<CareerManagerDebtController>.Instance.NumberOfNonZeroPricedDebts; i++)
			{
				DisplayableDebt ithNonZeroDebt = SingletonBehaviour<CareerManagerDebtController>.Instance.GetIthNonZeroDebt(i);
				if (ithNonZeroDebt != null && ithNonZeroDebt.IsPayable && ithNonZeroDebt.ID == locoID)
				{
					return "";
				}
			}
			return LocalizationAPI.L("tutorial/debt/no_debt", locoID);
		}
	}
}
