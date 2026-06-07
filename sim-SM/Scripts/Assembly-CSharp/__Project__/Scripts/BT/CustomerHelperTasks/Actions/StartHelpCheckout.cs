using NodeCanvas.Framework;

namespace __Project__.Scripts.BT.CustomerHelperTasks.Actions
{
	public class StartHelpCheckout : ActionTask
	{
		public BBParameter<CustomerHelper> helperParam;

		public BBParameter<ICustomerHelperControllable> scParam;

		private CustomerHelper Helper => null;

		private SelfCheckout SelfCheckout { get; set; }

		protected override void OnExecute()
		{
		}
	}
}
