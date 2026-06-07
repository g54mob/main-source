using System;

namespace Bolt
{
	public sealed class OnTriggerEnter : TriggerEventUnit
	{
		public override Type MessageListenerType => typeof(UnityOnTriggerEnterMessageListener);

		protected override string hookName => "OnTriggerEnter";
	}
}
