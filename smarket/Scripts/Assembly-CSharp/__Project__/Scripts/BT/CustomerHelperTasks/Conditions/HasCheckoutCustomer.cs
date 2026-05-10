using NodeCanvas.Framework;

namespace __Project__.Scripts.BT.CustomerHelperTasks.Conditions
{
	public class HasCheckoutCustomer : ConditionTask
	{
		public BBParameter<ICustomerHelperControllable> checkoutParam;

		protected override bool OnCheck()
		{
			return false;
		}
	}
}
