using Unity.Entities;
using Unity.NetCode;
using UnityEngine.Scripting;

[Preserve]
public struct ActivatedContentBundlesBuffer : IBufferElementData
{
	[GhostField]
	public DataBlockAddress ContentBundle;
}
