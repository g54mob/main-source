using System.Runtime.InteropServices;
using Unity.Entities;

namespace ContainedMiniSim.Components
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct TerrariumTagCD : IComponentData, IQueryTypeParameter
	{
	}
}
