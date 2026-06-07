using UnityEngine;

namespace Bolt
{
	[AddComponentMenu("")]
	public sealed class UnityOnJointBreakMessageListener : MessageListener
	{
		private void OnJointBreak(float breakForce)
		{
			EventBus.Trigger("OnJointBreak", base.gameObject, breakForce);
		}
	}
}
