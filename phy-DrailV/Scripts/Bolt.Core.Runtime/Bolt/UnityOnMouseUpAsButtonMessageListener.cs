using UnityEngine;

namespace Bolt
{
	[AddComponentMenu("")]
	public sealed class UnityOnMouseUpAsButtonMessageListener : MessageListener
	{
		private void OnMouseUpAsButton()
		{
			EventBus.Trigger("OnMouseUpAsButton", base.gameObject);
		}
	}
}
