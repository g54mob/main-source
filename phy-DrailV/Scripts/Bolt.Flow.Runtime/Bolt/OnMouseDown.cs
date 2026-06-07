using System;

namespace Bolt
{
	[UnitCategory("Events/Input")]
	public sealed class OnMouseDown : GameObjectEventUnit<EmptyEventArgs>
	{
		protected override string hookName => "OnMouseDown";

		public override Type MessageListenerType => typeof(UnityOnMouseDownMessageListener);
	}
}
