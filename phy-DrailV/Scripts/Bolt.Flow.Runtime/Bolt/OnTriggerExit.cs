using System;

namespace Bolt
{
	public sealed class OnTriggerExit : TriggerEventUnit
	{
		public override Type MessageListenerType => typeof(UnityOnTriggerExitMessageListener);

		protected override string hookName => "OnTriggerExit";
	}
}
