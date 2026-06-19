using System;
using Unity.Entities;
using UnityEngine.Scripting;

[Serializable]
[Preserve]
[TypeManager.ForcedMemoryOrdering(8843759668018188945uL)]
[TypeManager.OverrideTypeHash(7474316307185981995uL)]
public struct ActiveEquipmentPresetSerializedCD : IComponentData, IQueryTypeParameter
{
	public int Value;
}
