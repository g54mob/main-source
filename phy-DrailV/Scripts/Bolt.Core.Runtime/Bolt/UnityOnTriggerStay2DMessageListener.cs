using UnityEngine;

namespace Bolt
{
	[AddComponentMenu("")]
	public sealed class UnityOnTriggerStay2DMessageListener : MessageListener
	{
		private void OnTriggerStay2D(Collider2D other)
		{
			EventBus.Trigger("OnTriggerStay2D", base.gameObject, other);
		}
	}
}
