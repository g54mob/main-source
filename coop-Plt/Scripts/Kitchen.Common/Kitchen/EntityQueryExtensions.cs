using System;
using Unity.Collections;
using Unity.Entities;

namespace Kitchen
{
	public static class EntityQueryExtensions
	{
		public static Entity First(this EntityQuery eq)
		{
			NativeArray<Entity> nativeArray = eq.ToEntityArray(Allocator.Temp);
			Entity result = nativeArray[0];
			nativeArray.Dispose();
			return result;
		}

		public static T First<T>(this EntityQuery eq) where T : struct, IComponentData
		{
			NativeArray<T> nativeArray = eq.ToComponentDataArray<T>(Allocator.Temp);
			T result = nativeArray[0];
			nativeArray.Dispose();
			return result;
		}

		public static T FirstMatching<T>(this EntityQuery eq, Func<T, bool> condition) where T : struct, IComponentData
		{
			NativeArray<T> nativeArray = eq.ToComponentDataArray<T>(Allocator.Temp);
			T result = default(T);
			for (int i = 0; i < nativeArray.Length; i++)
			{
				if (condition(nativeArray[i]))
				{
					result = nativeArray[i];
					break;
				}
			}
			nativeArray.Dispose();
			return result;
		}

		public static Entity FirstMatchingEntity<T>(this EntityQuery eq, Func<T, bool> condition) where T : struct, IComponentData
		{
			using NativeArray<T> nativeArray = eq.ToComponentDataArray<T>(Allocator.Temp);
			using NativeArray<Entity> nativeArray2 = eq.ToEntityArray(Allocator.Temp);
			for (int i = 0; i < nativeArray.Length; i++)
			{
				if (condition(nativeArray[i]))
				{
					return nativeArray2[i];
				}
			}
			return default(Entity);
		}
	}
}
