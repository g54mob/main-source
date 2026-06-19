using System.Runtime.InteropServices;
using Unity.Entities;

[StructLayout(LayoutKind.Sequential, Size = 1)]
public struct IsExtractorTimerTriggerCD : IComponentData, IQueryTypeParameter
{
}
