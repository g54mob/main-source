using System.Runtime.InteropServices;
using Unity.Entities;

namespace PugFlora
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct BlocksFlora : IComponentData, IQueryTypeParameter
	{
	}
}
