using System.Runtime.InteropServices;
using Unity.Entities;

namespace PugWorldGen
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct UniqueDungeonInitDoneCD : IComponentData, IQueryTypeParameter
	{
	}
}
