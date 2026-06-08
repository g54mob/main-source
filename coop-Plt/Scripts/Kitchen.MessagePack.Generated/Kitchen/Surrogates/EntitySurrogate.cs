using MessagePack;
using Unity.Entities;

namespace Kitchen.Surrogates
{
	[MessagePackObject(false)]
	public struct EntitySurrogate
	{
		[Key(0)]
		public int A;

		[Key(1)]
		public int B;

		[IgnoreMember]
		public bool IsNullEntity
		{
			get
			{
				if (A == 0)
				{
					return B == 0;
				}
				return false;
			}
		}

		public static implicit operator Entity(EntitySurrogate v)
		{
			return new Entity
			{
				Index = v.A,
				Version = v.B
			};
		}

		public static implicit operator EntitySurrogate(Entity v)
		{
			return new EntitySurrogate
			{
				A = v.Index,
				B = v.Version
			};
		}
	}
}
