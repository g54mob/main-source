using Unity.Entities;

public struct AutoPickUpItemCD : IComponentData, IQueryTypeParameter
{
	public float pickupDistance;
}
