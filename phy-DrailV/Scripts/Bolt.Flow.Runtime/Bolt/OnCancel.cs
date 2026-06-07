using System;

namespace Bolt
{
	[UnitCategory("Events/GUI")]
	[UnitOrder(25)]
	public sealed class OnCancel : GenericGuiEventUnit
	{
		public override Type MessageListenerType => typeof(UnityOnCancelMessageListener);

		protected override string hookName => "OnCancel";
	}
}
