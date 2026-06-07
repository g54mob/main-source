using UnityEngine;

namespace Bolt
{
	[AddComponentMenu("")]
	public sealed class UnityOnCollisionExitMessageListener : MessageListener
	{
		private void OnCollisionExit(Collision collision)
		{
			EventBus.Trigger("OnCollisionExit", base.gameObject, collision);
		}
	}
}
