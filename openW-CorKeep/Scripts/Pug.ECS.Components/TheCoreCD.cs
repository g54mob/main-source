using System.Runtime.InteropServices;
using Unity.Entities;
using Unity.NetCode;

[StructLayout(LayoutKind.Sequential, Size = 1)]
[GhostComponent(PrefabType = GhostPrefabType.All)]
public struct TheCoreCD : IComponentData, IQueryTypeParameter
{
}
