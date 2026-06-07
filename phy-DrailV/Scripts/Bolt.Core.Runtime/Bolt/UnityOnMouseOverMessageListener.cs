using UnityEngine;

namespace Bolt
{
	[AddComponentMenu("")]
	public sealed class UnityOnMouseOverMessageListener : MessageListener
	{
		private void OnMouseOver()
		{
			EventBus.Trigger("OnMouseOver", base.gameObject);
		}
	}
}
