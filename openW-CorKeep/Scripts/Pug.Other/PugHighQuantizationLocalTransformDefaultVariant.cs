using Unity.Mathematics;
using Unity.NetCode;
using Unity.Transforms;
using UnityEngine.Scripting;

[Preserve]
[GhostComponentVariation(typeof(LocalTransform), null, false)]
[GhostComponent(PrefabType = GhostPrefabType.All, OwnerSendType = SendToOwnerType.All, SendDataForChildEntity = false)]
public struct PugHighQuantizationLocalTransformDefaultVariant
{
	[GhostField(Composite = true, Quantization = 0, Smoothing = SmoothingAction.InterpolateAndExtrapolate, MaxSmoothingDistance = 3f)]
	public float3 Position;
}
