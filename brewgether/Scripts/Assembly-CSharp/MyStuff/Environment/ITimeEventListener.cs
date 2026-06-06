namespace MyStuff.Environment
{
	public interface ITimeEventListener
	{
		void OnTimeEventTriggered(TimeEventContext context);

		string GetEventTagFilter();
	}
}
