using Unity.Entities;

namespace Kitchen
{
	public struct CInterfaceOf : IComponentData
	{
		public Entity Entity;

		public static implicit operator Entity(CInterfaceOf h)
		{
			return h.Entity;
		}

		public static implicit operator CInterfaceOf(Entity h)
		{
			return new CInterfaceOf
			{
				Entity = h
			};
		}
	}
}
