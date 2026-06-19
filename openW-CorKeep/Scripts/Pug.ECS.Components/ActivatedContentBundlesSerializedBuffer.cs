using Unity.Entities;
using UnityEngine.Scripting;

[Preserve]
public struct ActivatedContentBundlesSerializedBuffer : IBufferElementData
{
	public DataBlockAddress ContentBundle;
}
