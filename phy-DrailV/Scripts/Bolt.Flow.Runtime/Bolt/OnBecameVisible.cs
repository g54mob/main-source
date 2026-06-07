using System;

namespace Bolt
{
	[UnitCategory("Events/Rendering")]
	public sealed class OnBecameVisible : GameObjectEventUnit<EmptyEventArgs>
	{
		public override Type MessageListenerType => typeof(UnityOnBecameVisibleMessageListener);

		protected override string hookName => "OnBecameVisible";
	}
}
