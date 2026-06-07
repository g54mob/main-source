using UnityEngine;

namespace Bolt
{
	[AddComponentMenu("")]
	public sealed class UnityOnMouseDownMessageListener : MessageListener
	{
		private void OnMouseDown()
		{
			EventBus.Trigger("OnMouseDown", base.gameObject);
		}
	}
}
