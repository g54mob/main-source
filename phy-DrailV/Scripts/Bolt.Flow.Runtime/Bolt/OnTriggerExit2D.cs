using System;

namespace Bolt
{
	public sealed class OnTriggerExit2D : TriggerEvent2DUnit
	{
		public override Type MessageListenerType => typeof(UnityOnTriggerExit2DMessageListener);

		protected override string hookName => "OnTriggerExit2D";
	}
}
