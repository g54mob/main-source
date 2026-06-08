using System.Runtime.InteropServices;
using Unity.Entities;

namespace Kitchen
{
	public struct SNewsList : IBufferElementData
	{
		[StructLayout(LayoutKind.Sequential, Size = 1)]
		public struct Marker : IComponentData
		{
		}

		public Entity Item;
	}
}
