using UnityEngine;

namespace Assets.Code.Events.Session_Events
{
	public class SessionEventBehaviour : MonoBehaviour
	{
		[SerializeField]
		private SessionEventType _sessionEventType;

		public void Dispatch()
		{
			GameEventDispatcher.Dispatch(_sessionEventType);
		}
	}
}
