using UnityEngine;

namespace Bolt
{
	[AddComponentMenu("")]
	public sealed class UnityOnBecameVisibleMessageListener : MessageListener
	{
		private void OnBecameVisible()
		{
			EventBus.Trigger("OnBecameVisible", base.gameObject);
		}
	}
}
