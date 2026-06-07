public class ResearchOutlet
{
	public ResearchConnection connection;

	public ResearchNode outboundNode;

	public ResearchOutlet(ResearchNode next, ResearchConnection c)
	{
		connection = c;
		outboundNode = next;
	}
}
