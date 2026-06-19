using System;
using System.Runtime.InteropServices;
using Unity.Entities;

[Serializable]
[StructLayout(LayoutKind.Sequential, Size = 1)]
public struct CustomSceneObjectCD : IComponentData, IQueryTypeParameter
{
}
