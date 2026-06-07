using UnityEngine.Events;

namespace M4.Session
{
	public class UserEvent
	{
		public class UserEventDispatcher : UnityEvent<IUser, UserEventType>
		{
		}

		private static UserEventDispatcher dispatcher;

		public static UserEventDispatcher Dispatcher
		{
			get
			{
				if (dispatcher == null)
				{
					dispatcher = new UserEventDispatcher();
				}
				return dispatcher;
			}
		}

		public static void Dispatch(IUser user, UserEventType user_event_type)
		{
			if (dispatcher != null)
			{
				dispatcher.Invoke(user, user_event_type);
			}
		}

		public static void Dispose()
		{
			if (dispatcher != null)
			{
				dispatcher.RemoveAllListeners();
			}
		}
	}
}
