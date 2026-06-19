using System;
using Unity.Entities;
using UnityEngine.Scripting;

[Serializable]
[Preserve]
[TypeManager.OverrideTypeHash(10013189682066215614uL)]
public struct PlantSerializedCD : IComponentData, IQueryTypeParameter
{
	public int Stage;

	public float GrowTime;
}
