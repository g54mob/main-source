using System;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Entities;

namespace Kitchen
{
	public static class EntityLookup
	{
		public static EntityLookup<T, NullType, NullType> Create<T>(EntityQuery query) where T : struct, IComponentData
		{
			return new EntityLookup<T, NullType, NullType>(query);
		}

		public static EntityLookup<TA, TB, NullType> Create<TA, TB>(EntityQuery query) where TA : struct, IComponentData where TB : struct, IComponentData
		{
			return new EntityLookup<TA, TB, NullType>(query);
		}

		public static EntityLookup<TA, TB, TC> Create<TA, TB, TC>(EntityQuery query) where TA : struct, IComponentData where TB : struct, IComponentData where TC : struct, IComponentData
		{
			return new EntityLookup<TA, TB, TC>(query);
		}
	}
	public struct EntityLookup<T1, T2, T3> : IDisposable where T1 : struct, IComponentData where T2 : struct, IComponentData where T3 : struct, IComponentData
	{
		public EntityQuery Query;

		public NativeArray<Entity> EntityArray;

		public NativeArray<T1> T1Array;

		public NativeArray<T2> T2Array;

		public NativeArray<T3> T3Array;

		public bool HasT2 => typeof(T2) != typeof(NullType);

		public bool HasT3 => typeof(T3) != typeof(NullType);

		public EntityLookup(EntityQuery query)
		{
			Query = query;
			EntityArray = default(NativeArray<Entity>);
			T1Array = default(NativeArray<T1>);
			T2Array = default(NativeArray<T2>);
			T3Array = default(NativeArray<T3>);
		}

		public void Build()
		{
			EntityArray = Query.ToEntityArray(Allocator.Temp);
			T1Array = Query.ToComponentDataArray<T1>(Allocator.Temp);
			if (HasT2)
			{
				T2Array = Query.ToComponentDataArray<T2>(Allocator.Temp);
			}
			if (HasT3)
			{
				T3Array = Query.ToComponentDataArray<T3>(Allocator.Temp);
			}
		}

		public IEnumerable<EntityData<T1, T2, T3>> Iterate()
		{
			if (EntityArray == default(NativeArray<Entity>))
			{
				Build();
			}
			for (int i = 0; i < EntityArray.Length; i++)
			{
				yield return GetInternal(i);
			}
		}

		public EntityData<T1, T2, T3> Get(int i)
		{
			if (EntityArray == default(NativeArray<Entity>))
			{
				Build();
			}
			if (i < 0 || i >= EntityArray.Length)
			{
				return default(EntityData<T1, T2, T3>);
			}
			return GetInternal(i);
		}

		private EntityData<T1, T2, T3> GetInternal(int i)
		{
			return new EntityData<T1, T2, T3>
			{
				Entity = EntityArray[i],
				Value1 = T1Array[i],
				Value2 = (HasT2 ? T2Array[i] : default(T2)),
				Value3 = (HasT3 ? T3Array[i] : default(T3))
			};
		}

		public void Dispose()
		{
			if (EntityArray != default(NativeArray<Entity>))
			{
				EntityArray.Dispose();
			}
			if (T1Array != default(NativeArray<T1>))
			{
				T1Array.Dispose();
			}
			if (T2Array != default(NativeArray<T2>))
			{
				T2Array.Dispose();
			}
			if (T3Array != default(NativeArray<T3>))
			{
				T3Array.Dispose();
			}
		}
	}
}
