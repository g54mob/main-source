public abstract class ActorEvent : GameEvent
{
	private GameEventType _actorEventType;

	public ActorDescriptor ActorDescriptor { get; private set; }

	public ActorEvent(ActorDescriptor actorDescriptor, GameEventType eventType)
		: base(eventType)
	{
		Initialize(actorDescriptor, eventType);
	}

	public virtual void Initialize(ActorDescriptor actorDescriptor, GameEventType eventType)
	{
		base.EventType = eventType;
		ActorDescriptor = actorDescriptor;
		_actorEventType = ToActorEventType(eventType);
	}

	protected override void DispatchEvent()
	{
		base.DispatchEvent();
		if (base.EventType != _actorEventType)
		{
			base.EventType = _actorEventType;
			base.DispatchEvent();
		}
	}

	private GameEventType ToActorEventType(GameEventType eventType)
	{
		return eventType switch
		{
			GameEventType.AgentRescue => GameEventType.ActorRescue, 
			GameEventType.BirdRescue => GameEventType.ActorRescue, 
			GameEventType.AgentDeath => GameEventType.ActorDeath, 
			GameEventType.BirdRemovedFromCommunity => GameEventType.ActorDeath, 
			_ => eventType, 
		};
	}
}
