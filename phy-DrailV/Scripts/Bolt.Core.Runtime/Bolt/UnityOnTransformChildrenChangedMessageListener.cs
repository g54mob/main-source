using UnityEngine;

namespace Bolt
{
	[AddComponentMenu("")]
	public sealed class UnityOnTransformChildrenChangedMessageListener : MessageListener
	{
		private void OnTransformChildrenChanged()
		{
			EventBus.Trigger("OnTransformChildrenChanged", base.gameObject);
		}
	}
}
