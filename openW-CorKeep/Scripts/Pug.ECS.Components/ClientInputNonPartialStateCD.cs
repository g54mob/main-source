using Unity.Entities;
using Unity.NetCode;

public struct ClientInputNonPartialStateCD : IComponentData, IQueryTypeParameter
{
	[GhostField]
	public bool interactHeldDown;
}
