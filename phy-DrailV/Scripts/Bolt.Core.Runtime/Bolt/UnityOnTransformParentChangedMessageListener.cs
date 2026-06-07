using UnityEngine;

namespace Bolt
{
	[AddComponentMenu("")]
	public sealed class UnityOnTransformParentChangedMessageListener : MessageListener
	{
		private void OnTransformParentChanged()
		{
			EventBus.Trigger("OnTransformParentChanged", base.gameObject);
		}
	}
}
