using NodeCanvas.Framework;

namespace __Project__.Scripts.BT.CustomerHelperTasks.Conditions
{
	public class CanSelfCheckoutUsable : ConditionTask
	{
		public BBParameter<ICustomerHelperControllable> Checkout;

		protected override bool OnCheck()
		{
			return false;
		}
	}
}
