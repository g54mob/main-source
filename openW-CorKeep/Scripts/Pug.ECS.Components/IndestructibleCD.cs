using System.Runtime.InteropServices;
using Unity.Entities;
using Unity.NetCode;

[StructLayout(LayoutKind.Sequential, Size = 1)]
[GhostEnabledBit]
public struct IndestructibleCD : IComponentData, IQueryTypeParameter, IEnableableComponent
{
}
