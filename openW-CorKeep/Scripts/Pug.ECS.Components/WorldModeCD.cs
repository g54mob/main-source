using System;
using Unity.Entities;
using UnityEngine.Scripting;

[Obsolete]
[Preserve]
[TypeManager.ForcedMemoryOrdering(5090207281740970978uL)]
public struct WorldModeCD : IComponentData, IQueryTypeParameter
{
	public WorldMode Value;
}
