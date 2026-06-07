public class AgentEvent : ActorEvent
{
	private static AgentEvent s_instance;

	public Agent Agent { get; protected set; }

	public AgentDescriptor AgentDescriptor { get; private set; }

	public DrifterAttributes.AttributeType Attribute { get; private set; }

	public AssignmentType AssignmentType { get; private set; }

	public ItemProperties ItemProperties { get; protected set; }

	public AgentEvent(GameEventType eventType, Agent agent)
		: base(agent.Descriptor, eventType)
	{
		Agent = agent;
		AgentDescriptor = agent.Descriptor;
	}

	public static void Dispatch(GameEventType eventType, Agent agent)
	{
		GetInstance(eventType, agent).Dispatch();
	}

	public static void Dispatch(GameEventType eventType, AgentDescriptor agentDescriptor)
	{
		GetInstance(eventType, agentDescriptor.Agent, agentDescriptor).Dispatch();
	}

	public static void Dispatch(Agent agent, DrifterAttributes.AttributeType attribute)
	{
		AgentEvent instance = GetInstance(GameEventType.AgentAttributeInfo, agent);
		instance.Attribute = attribute;
		instance.Dispatch();
	}

	public static void Dispatch(Agent agent, AssignmentType assignment)
	{
		AgentEvent instance = GetInstance(GameEventType.AgentAssignmentInfo, agent);
		instance.AssignmentType = assignment;
		instance.Dispatch();
	}

	public static void Dispatch(Agent agent, Assignment assignment)
	{
		AgentEvent instance = GetInstance(GameEventType.AgentAssignmentUpdated, agent);
		instance.AssignmentType = assignment.Type;
		instance.Dispatch();
	}

	public static void Dispatch(Agent agent, ItemProperties itemProperties)
	{
		AgentEvent instance = GetInstance(GameEventType.AgentDietInfo, agent);
		instance.ItemProperties = itemProperties;
		instance.Dispatch();
	}

	private static AgentEvent GetInstance(GameEventType eventType, Agent agent, AgentDescriptor descriptor = null)
	{
		if (s_instance == null)
		{
			s_instance = new AgentEvent(eventType, agent);
		}
		else
		{
			if ((bool)agent)
			{
				s_instance.Initialize(agent.Descriptor, eventType);
			}
			else
			{
				s_instance.Initialize(descriptor, eventType);
			}
			s_instance.Agent = agent;
			s_instance.AgentDescriptor = ((descriptor != null) ? descriptor : ((agent != null) ? agent.Descriptor : null));
			s_instance.Attribute = DrifterAttributes.AttributeType.None;
			s_instance.AssignmentType = AssignmentType.None;
		}
		return s_instance;
	}
}
