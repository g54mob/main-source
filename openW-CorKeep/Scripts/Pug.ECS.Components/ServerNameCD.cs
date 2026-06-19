using System;
using Unity.Collections;
using Unity.Entities;
using UnityEngine.Scripting;

[Obsolete]
[Preserve]
[TypeManager.ForcedMemoryOrdering(11567586029344926883uL)]
public struct ServerNameCD : IComponentData, IQueryTypeParameter
{
	public FixedString64 Value;
}
