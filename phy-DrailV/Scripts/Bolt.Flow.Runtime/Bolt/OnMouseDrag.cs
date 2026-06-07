using System;

namespace Bolt
{
	[UnitCategory("Events/Input")]
	public sealed class OnMouseDrag : GameObjectEventUnit<EmptyEventArgs>
	{
		public override Type MessageListenerType => typeof(UnityOnMouseDragMessageListener);

		protected override string hookName => "OnMouseDrag";
	}
}
