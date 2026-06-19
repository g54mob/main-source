using Unity.Entities;

public struct ClientInputForLatestFrameCD : IComponentData, IQueryTypeParameter
{
	public ClientInput clientInput;
}
