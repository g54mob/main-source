using UnityEngine;
using UnityEngine.Events;

namespace HeathenEngineering.Events
{
	[AddComponentMenu("System Core/Events/Bool Game Event Listener")]
	public class BoolGameEventListener : GameEventListener<bool>
	{
		public BoolGameEvent Event;

		public UnityBoolDataEvent Responce;

		public UnityBoolEvent UnityEvent;

		public override IGameEvent<bool> m_event => Event;

		public override UnityDataEvent<bool> m_responce => Responce;

		public override UnityEvent<bool> m_unityEvent => UnityEvent;
	}
}
