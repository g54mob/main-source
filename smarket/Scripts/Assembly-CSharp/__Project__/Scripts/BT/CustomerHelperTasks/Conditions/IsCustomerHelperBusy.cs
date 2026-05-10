using NodeCanvas.Framework;

namespace __Project__.Scripts.BT.CustomerHelperTasks.Conditions
{
	public class IsCustomerHelperBusy : ConditionTask
	{
		public BBParameter<CustomerHelper> helperParam;

		private CustomerHelper Helper => null;

		protected override bool OnCheck()
		{
			return false;
		}
	}
}
