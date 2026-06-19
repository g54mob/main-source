using System.Collections.Generic;

public class PipeGroup : BuildingBehaviour
{
	public List<Pipe> Pipes;

	private void Start()
	{
	}

	public bool Has(Pipe pipe)
	{
		return false;
	}

	public List<PipeConnection> GetConnectionsToGroup(PipeGroup group)
	{
		return null;
	}
}
