using Unity.Entities;

namespace Kitchen
{
	public struct CPartOfTableSet : IComponentData
	{
		public Entity TableSet;

		public static implicit operator Entity(CPartOfTableSet x)
		{
			return x.TableSet;
		}

		public static implicit operator CPartOfTableSet(Entity x)
		{
			return new CPartOfTableSet
			{
				TableSet = x
			};
		}
	}
}
