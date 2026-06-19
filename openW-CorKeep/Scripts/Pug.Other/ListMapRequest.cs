using System.Runtime.InteropServices;
using Unity.Entities;
using Unity.NetCode;

[StructLayout(LayoutKind.Sequential, Size = 1)]
public struct ListMapRequest : IRpcCommand, IComponentData, IQueryTypeParameter
{
}
