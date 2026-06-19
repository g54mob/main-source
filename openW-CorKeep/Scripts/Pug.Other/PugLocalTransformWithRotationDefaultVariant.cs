using Unity.Mathematics;
using Unity.NetCode;
using Unity.Transforms;
using UnityEngine.Scripting;

[Preserve]
[GhostComponentVariation(typeof(LocalTransform), null, false)]
[GhostComponent(PrefabType = GhostPrefabType.All, OwnerSendType = SendToOwnerType.All, SendDataForChildEntity = false)]
public struct PugLocalTransformWithRotationDefaultVariant
{
	[GhostField(Composite = true, Quantization = 1000, Smoothing = SmoothingAction.InterpolateAndExtrapolate, MaxSmoothingDistance = 3f)]
	public float3 Position;

	[GhostField(Quantization = 1000, Smoothing = SmoothingAction.InterpolateAndExtrapolate)]
	public quaternion Rotation;
}
