using UnityEngine;

namespace Bolt
{
	[AddComponentMenu("")]
	public sealed class UnityOnTriggerExitMessageListener : MessageListener
	{
		private void OnTriggerExit(Collider other)
		{
			EventBus.Trigger("OnTriggerExit", base.gameObject, other);
		}
	}
}
