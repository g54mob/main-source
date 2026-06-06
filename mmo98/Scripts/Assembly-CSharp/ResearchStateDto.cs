using System.Collections.Generic;
using MessagePack;

[MessagePackObject(false)]
public class ResearchStateDto
{
	[Key(0)]
	public HashSet<ResearchNode> Unlocked = new HashSet<ResearchNode>();

	[Key(1)]
	public int DataNodes;
}
