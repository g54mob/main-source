using UnityEngine;

namespace Bolt
{
	[AddComponentMenu("")]
	public sealed class UnityOnCollisionEnter2DMessageListener : MessageListener
	{
		private void OnCollisionEnter2D(Collision2D collision)
		{
			EventBus.Trigger("OnCollisionEnter2D", base.gameObject, collision);
		}
	}
}
