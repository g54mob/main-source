using NodeCanvas.Framework;

namespace __Project__.Scripts.BT.CustomerHelperTasks.Conditions
{
	public class HelperControllableCheckType : ConditionTask
	{
		public enum Types
		{
			SelfCheckout = 0,
			Scale = 1
		}

		public BBParameter<ICustomerHelperControllable> Target;

		public Types Type;

		protected override string info => null;

		protected override bool OnCheck()
		{
			return false;
		}
	}
}
