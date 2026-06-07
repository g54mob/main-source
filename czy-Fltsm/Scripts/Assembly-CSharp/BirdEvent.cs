public class BirdEvent : ActorEvent
{
	public Bird Bird;

	public BirdEvent(GameEventType eventType, Bird bird)
		: base(bird.Descriptor, eventType)
	{
		Bird = bird;
	}
}
