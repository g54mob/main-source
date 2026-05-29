using NodeCanvas.Framework;

namespace __Project__.Scripts.BT.CustomerHelperTasks.Conditions
{
	public class IsCustomerHelperHelping : ConditionTask
	{
		public BBParameter<bool> isHelpingParam;

		protected override bool OnCheck()
		{
			return false;
		}
	}
}
