using System;

namespace Bolt
{
	[UnitCategory("Events/Input")]
	public sealed class OnMouseUpAsButton : GameObjectEventUnit<EmptyEventArgs>
	{
		public override Type MessageListenerType => typeof(UnityOnMouseUpAsButtonMessageListener);

		protected override string hookName => "OnMouseUpAsButton";
	}
}
