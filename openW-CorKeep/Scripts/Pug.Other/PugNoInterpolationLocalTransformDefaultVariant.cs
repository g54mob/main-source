using Unity.Mathematics;
using Unity.NetCode;
using Unity.Transforms;
using UnityEngine.Scripting;

[Preserve]
[GhostComponentVariation(typeof(LocalTransform), null, false)]
[GhostComponent(PrefabType = GhostPrefabType.All, OwnerSendType = SendToOwnerType.All, SendDataForChildEntity = false)]
public struct PugNoInterpolationLocalTransformDefaultVariant
{
	[GhostField(Composite = true, Quantization = 1000, Smoothing = SmoothingAction.Clamp)]
	public float3 Position;
}
