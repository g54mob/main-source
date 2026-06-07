using System;

namespace Bolt
{
	public sealed class OnTriggerStay2D : TriggerEvent2DUnit
	{
		public override Type MessageListenerType => typeof(UnityOnTriggerStay2DMessageListener);

		protected override string hookName => "OnTriggerStay2D";
	}
}
