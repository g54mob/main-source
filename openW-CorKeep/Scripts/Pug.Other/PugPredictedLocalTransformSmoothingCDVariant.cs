using System.Runtime.InteropServices;
using Unity.NetCode;
using Unity.Physics.GraphicsIntegration;
using UnityEngine.Scripting;

[StructLayout(LayoutKind.Sequential, Size = 1)]
[Preserve]
[GhostComponentVariation(typeof(PredictedLocalTransformSmoothingCD), null, false)]
[GhostComponent(PrefabType = GhostPrefabType.PredictedClient, OwnerSendType = SendToOwnerType.None, SendDataForChildEntity = false)]
public struct PugPredictedLocalTransformSmoothingCDVariant
{
}
