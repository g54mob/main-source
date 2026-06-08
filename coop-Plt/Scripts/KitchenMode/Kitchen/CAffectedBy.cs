using System.Runtime.InteropServices;
using Unity.Entities;

namespace Kitchen
{
	[InternalBufferCapacity(4)]
	public struct CAffectedBy : IBufferElementData
	{
		[StructLayout(LayoutKind.Sequential, Size = 1)]
		public struct Marker : IComponentData
		{
		}

		public Entity Entity;

		public static implicit operator Entity(CAffectedBy a)
		{
			return a.Entity;
		}

		public static implicit operator CAffectedBy(Entity a)
		{
			return new CAffectedBy
			{
				Entity = a
			};
		}
	}
}
