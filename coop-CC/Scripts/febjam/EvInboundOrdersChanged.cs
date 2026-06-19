using System.Runtime.InteropServices;
using Aggro.Core;

[StructLayout(LayoutKind.Sequential, Size = 1)]
public struct EvInboundOrdersChanged : IEntityEvent, IEntityTyped
{
}
