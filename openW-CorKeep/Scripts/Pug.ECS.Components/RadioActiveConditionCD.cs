using System.Runtime.InteropServices;
using Unity.Entities;
using Unity.NetCode;

[StructLayout(LayoutKind.Sequential, Size = 1)]
[GhostComponent(SendTypeOptimization = GhostSendType.OnlyPredictedClients)]
[GhostEnabledBit]
public struct RadioActiveConditionCD : IComponentData, IQueryTypeParameter, IEnableableComponent
{
}
