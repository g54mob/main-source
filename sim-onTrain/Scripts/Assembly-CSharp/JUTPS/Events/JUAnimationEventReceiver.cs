using UnityEngine;

namespace JUTPS.Events
{
	[AddComponentMenu("JU TPS/Third Person System/Additionals/JU Animation Event Receiver")]
	public class JUAnimationEventReceiver : MonoBehaviour
	{
		public JUAnimationEvent[] JUAnimationEvents;

		public void CallEvent(string EventName)
		{
			JUAnimationEvent[] jUAnimationEvents = JUAnimationEvents;
			foreach (JUAnimationEvent jUAnimationEvent in jUAnimationEvents)
			{
				if (jUAnimationEvent.EventName == EventName)
				{
					jUAnimationEvent.Event.Invoke();
					return;
				}
			}
			Debug.LogError("There is no animation event in the named list of '" + EventName + "'");
		}
	}
}
