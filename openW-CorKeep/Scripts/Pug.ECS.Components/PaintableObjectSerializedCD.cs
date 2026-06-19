using System;
using Unity.Entities;
using UnityEngine.Scripting;

[Serializable]
[Preserve]
[TypeManager.ForcedMemoryOrdering(2406913203039094111uL)]
[TypeManager.OverrideTypeHash(1301047133137499053uL)]
public struct PaintableObjectSerializedCD : IComponentData, IQueryTypeParameter
{
	public int Value;
}
