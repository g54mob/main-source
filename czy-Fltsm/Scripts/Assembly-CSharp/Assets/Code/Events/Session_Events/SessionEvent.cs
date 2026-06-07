namespace Assets.Code.Events.Session_Events
{
	public class SessionEvent : EventBase<SessionEventType>
	{
		public SessionEvent(SessionEventType eventType)
			: base(eventType)
		{
		}

		protected override void DispatchEvent()
		{
			GameEventDispatcher.Dispatch(this);
		}
	}
}
