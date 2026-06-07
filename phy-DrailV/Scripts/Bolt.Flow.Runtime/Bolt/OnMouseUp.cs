using System;

namespace Bolt
{
	[UnitCategory("Events/Input")]
	public sealed class OnMouseUp : GameObjectEventUnit<EmptyEventArgs>
	{
		public override Type MessageListenerType => typeof(UnityOnMouseUpMessageListener);

		protected override string hookName => "OnMouseUp";
	}
}
