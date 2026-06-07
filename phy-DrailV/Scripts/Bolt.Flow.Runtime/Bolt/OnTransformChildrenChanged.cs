using System;

namespace Bolt
{
	[UnitCategory("Events/Hierarchy")]
	public sealed class OnTransformChildrenChanged : GameObjectEventUnit<EmptyEventArgs>
	{
		public override Type MessageListenerType => typeof(UnityOnTransformChildrenChangedMessageListener);

		protected override string hookName => "OnTransformChildrenChanged";
	}
}
