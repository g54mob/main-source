using KitchenData;
using Unity.Entities;

namespace Kitchen
{
	[InternalBufferCapacity(4)]
	public struct CDecorationScore : IBufferElementData
	{
		public DecorationType Theme;

		public int Value;

		public static implicit operator DecorationType(CDecorationScore s)
		{
			return s.Theme;
		}

		public static implicit operator int(CDecorationScore s)
		{
			return s.Value;
		}
	}
}
