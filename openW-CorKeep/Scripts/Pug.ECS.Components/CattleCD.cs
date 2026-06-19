using System.Runtime.InteropServices;
using Unity.Entities;
using Unity.NetCode;

[StructLayout(LayoutKind.Sequential, Size = 1)]
[GhostComponent]
public struct CattleCD : IComponentData, IQueryTypeParameter
{
}
