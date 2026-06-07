using System;

namespace Bolt
{
	public sealed class OnTriggerStay : TriggerEventUnit
	{
		public override Type MessageListenerType => typeof(UnityOnTriggerStayMessageListener);

		protected override string hookName => "OnTriggerStay";
	}
}
