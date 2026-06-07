using UnityEngine;

namespace Bolt
{
	[AddComponentMenu("")]
	public sealed class UnityOnControllerColliderHitMessageListener : MessageListener
	{
		private void OnControllerColliderHit(ControllerColliderHit hit)
		{
			EventBus.Trigger("OnControllerColliderHit", base.gameObject, hit);
		}
	}
}
