using System;

namespace Bolt
{
	public sealed class OnCollisionEnter2D : CollisionEvent2DUnit
	{
		public override Type MessageListenerType => typeof(UnityOnCollisionEnter2DMessageListener);

		protected override string hookName => "OnCollisionEnter2D";
	}
}
