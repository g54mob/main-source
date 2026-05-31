using NodeCanvas.Framework;

namespace __Project__.Scripts.BT.CustomerHelperTasks.Actions
{
	public class SetCustomerHelperBusy : ActionTask
	{
		public BBParameter<CustomerHelper> customerHelper;

		private CustomerHelper Helper => null;

		protected override void OnExecute()
		{
		}
	}
}
