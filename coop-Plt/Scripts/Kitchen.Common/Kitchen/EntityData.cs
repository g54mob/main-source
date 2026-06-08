using Unity.Entities;

namespace Kitchen
{
	public struct EntityData<T1, T2, T3> where T1 : struct, IComponentData where T2 : struct, IComponentData where T3 : struct, IComponentData
	{
		public Entity Entity;

		public T1 Value1;

		public T2 Value2;

		public T3 Value3;
	}
}
