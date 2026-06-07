using System;

namespace Bolt
{
	[UnitCategory("Events/Input")]
	public sealed class OnMouseEnter : GameObjectEventUnit<EmptyEventArgs>
	{
		public override Type MessageListenerType => typeof(UnityOnMouseEnterMessageListener);

		protected override string hookName => "OnMouseEnter";
	}
}
