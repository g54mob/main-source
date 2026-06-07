using UnityEngine;

namespace Bolt
{
	[AddComponentMenu("")]
	public sealed class UnityOnMouseEnterMessageListener : MessageListener
	{
		private void OnMouseEnter()
		{
			EventBus.Trigger("OnMouseEnter", base.gameObject);
		}
	}
}
