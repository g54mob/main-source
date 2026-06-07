using UnityEngine;

namespace Bolt
{
	[AddComponentMenu("")]
	public sealed class UnityOnMouseUpMessageListener : MessageListener
	{
		private void OnMouseUp()
		{
			EventBus.Trigger("OnMouseUp", base.gameObject);
		}
	}
}
