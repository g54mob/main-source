using System;

namespace Bolt
{
	[UnitCategory("Events/Input")]
	public sealed class OnMouseExit : GameObjectEventUnit<EmptyEventArgs>
	{
		public override Type MessageListenerType => typeof(UnityOnMouseExitMessageListener);

		protected override string hookName => "OnMouseExit";
	}
}
