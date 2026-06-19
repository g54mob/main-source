using Unity.Entities;
using Unity.NetCode;

[GhostComponent(PrefabType = GhostPrefabType.Client)]
public struct InteractableObjectReferenceCD : IComponentData, IQueryTypeParameter
{
	public UnityObjectRef<InteractableObject> Value;
}
