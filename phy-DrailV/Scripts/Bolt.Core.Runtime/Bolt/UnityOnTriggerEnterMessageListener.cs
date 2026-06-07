using UnityEngine;

namespace Bolt
{
	[AddComponentMenu("")]
	public sealed class UnityOnTriggerEnterMessageListener : MessageListener
	{
		private void OnTriggerEnter(Collider other)
		{
			EventBus.Trigger("OnTriggerEnter", base.gameObject, other);
		}
	}
}
