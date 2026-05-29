using CTS.BBT.AI;

public static class AgentExtension
{
	public static string DebugName(this Agent customer)
	{
		return $"{customer.agentFirstName} [{customer.GetInstanceID()}]";
	}

	public static string FullName(this Agent agent)
	{
		return agent.agentFirstName + " " + agent.agentName;
	}
}
