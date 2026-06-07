using System;

namespace Bolt
{
	[UnitCategory("Events/Input")]
	public sealed class OnMouseOver : GameObjectEventUnit<EmptyEventArgs>
	{
		public override Type MessageListenerType => typeof(UnityOnMouseOverMessageListener);

		protected override string hookName => "OnMouseOver";
	}
}
