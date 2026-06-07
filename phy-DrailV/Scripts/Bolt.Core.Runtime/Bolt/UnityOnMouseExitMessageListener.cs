using UnityEngine;

namespace Bolt
{
	[AddComponentMenu("")]
	public sealed class UnityOnMouseExitMessageListener : MessageListener
	{
		private void OnMouseExit()
		{
			EventBus.Trigger("OnMouseExit", base.gameObject);
		}
	}
}
