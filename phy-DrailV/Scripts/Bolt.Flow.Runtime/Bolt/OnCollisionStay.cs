using System;

namespace Bolt
{
	public sealed class OnCollisionStay : CollisionEventUnit
	{
		public override Type MessageListenerType => typeof(UnityOnCollisionStayMessageListener);

		protected override string hookName => "OnCollisionStay";
	}
}
