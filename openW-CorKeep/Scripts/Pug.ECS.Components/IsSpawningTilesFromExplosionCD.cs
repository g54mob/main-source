using System.Runtime.InteropServices;
using Unity.Entities;
using Unity.NetCode;

[StructLayout(LayoutKind.Sequential, Size = 1)]
[GhostEnabledBit]
public struct IsSpawningTilesFromExplosionCD : IComponentData, IQueryTypeParameter, IEnableableComponent
{
}
