namespace M4.Session
{
	public interface IUserEventHandler
	{
		void OnUserEvent(IUser user, UserEventType evt);
	}
}
