using Unity.Entities;

public struct PlacementIndicationVisualStateCD : IComponentData, IQueryTypeParameter
{
	public bool isEquipmentOnCooldown;

	public bool hasManaForDefaultUsage;
}
