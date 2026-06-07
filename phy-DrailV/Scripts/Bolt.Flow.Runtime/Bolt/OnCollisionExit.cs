using System;

namespace Bolt
{
	public sealed class OnCollisionExit : CollisionEventUnit
	{
		public override Type MessageListenerType => typeof(UnityOnCollisionExitMessageListener);

		protected override string hookName => "OnCollisionExit";
	}
}
