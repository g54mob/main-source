using System;

namespace Bolt
{
	[UnitCategory("Events/GUI")]
	[UnitOrder(22)]
	public sealed class OnSelect : GenericGuiEventUnit
	{
		public override Type MessageListenerType => typeof(UnityOnSelectMessageListener);

		protected override string hookName => "OnSelect";
	}
}
