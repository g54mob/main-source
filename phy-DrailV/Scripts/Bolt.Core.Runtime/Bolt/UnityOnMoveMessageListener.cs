using UnityEngine;
using UnityEngine.EventSystems;

namespace Bolt
{
	[AddComponentMenu("")]
	public sealed class UnityOnMoveMessageListener : MessageListener, IMoveHandler, IEventSystemHandler
	{
		public void OnMove(AxisEventData eventData)
		{
			EventBus.Trigger("OnMove", base.gameObject, eventData);
		}
	}
}
