using UnityEngine;

namespace Bolt
{
	[AddComponentMenu("")]
	public sealed class UnityOnMouseDragMessageListener : MessageListener
	{
		private void OnMouseDrag()
		{
			EventBus.Trigger("OnMouseDrag", base.gameObject);
		}
	}
}
