using System.Runtime.InteropServices;
using Unity.Entities;

namespace Kitchen
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct CGroupArrive : IGroupStatus, IComponentData
	{
	}
}
