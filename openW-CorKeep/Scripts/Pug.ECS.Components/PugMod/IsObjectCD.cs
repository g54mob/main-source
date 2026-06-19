using System.Runtime.InteropServices;
using Unity.Entities;

namespace PugMod
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct IsObjectCD : IComponentData, IQueryTypeParameter
	{
	}
}
