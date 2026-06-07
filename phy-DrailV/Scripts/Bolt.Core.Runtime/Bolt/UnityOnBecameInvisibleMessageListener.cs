using UnityEngine;

namespace Bolt
{
	[AddComponentMenu("")]
	public sealed class UnityOnBecameInvisibleMessageListener : MessageListener
	{
		private void OnBecameInvisible()
		{
			EventBus.Trigger("OnBecameInvisible", base.gameObject);
		}
	}
}
