using System;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;

namespace MagicaCloth2
{
	public static class NativeMultiHashMapExtensions
	{
		[BurstCompile]
		private struct SetParallelMultiHashMapJob<TKey, TValue> : IJob where TKey : struct, IEquatable<TKey> where TValue : struct
		{
			public NativeParallelMultiHashMap<TKey, TValue> map;

			[ReadOnly]
			public NativeArray<TKey> keyArray;

			[ReadOnly]
			public NativeArray<TValue> valueArray;

			public void Execute()
			{
			}
		}

		public static bool MC2Contains<TKey, TValue>(this ref NativeParallelMultiHashMap<TKey, TValue> map, TKey key, TValue value) where TKey : struct, IEquatable<TKey> where TValue : struct, IEquatable<TValue>
		{
			return false;
		}

		public static void MC2UniqueAdd<TKey, TValue>(this ref NativeParallelMultiHashMap<TKey, TValue> map, TKey key, TValue value) where TKey : struct, IEquatable<TKey> where TValue : struct, IEquatable<TValue>
		{
		}

		public static bool MC2RemoveValue<TKey, TValue>(this ref NativeParallelMultiHashMap<TKey, TValue> map, TKey key, TValue value) where TKey : struct, IEquatable<TKey> where TValue : struct, IEquatable<TValue>
		{
			return false;
		}

		public static FixedList512Bytes<TValue> MC2ToFixedList512Bytes<TKey, TValue>(this ref NativeParallelMultiHashMap<TKey, TValue> map, TKey key) where TKey : struct, IEquatable<TKey> where TValue : struct, IEquatable<TValue>
		{
			return default(FixedList512Bytes<TValue>);
		}

		public static FixedList128Bytes<TValue> MC2ToFixedList128Bytes<TKey, TValue>(this ref NativeParallelMultiHashMap<TKey, TValue> map, TKey key) where TKey : struct, IEquatable<TKey> where TValue : struct, IEquatable<TValue>
		{
			return default(FixedList128Bytes<TValue>);
		}

		public static (TKey[], TValue[]) MC2Serialize<TKey, TValue>(this ref NativeParallelMultiHashMap<TKey, TValue> map) where TKey : struct, IEquatable<TKey> where TValue : struct
		{
			return default((TKey[], TValue[]));
		}

		public static NativeParallelMultiHashMap<int2, ushort> MC2Deserialize(int2[] keyArray, ushort[] valueArray)
		{
			return default(NativeParallelMultiHashMap<int2, ushort>);
		}

		public static void MC2DisposeSafe<TKey, TValue>(this ref NativeParallelMultiHashMap<TKey, TValue> map) where TKey : struct, IEquatable<TKey> where TValue : struct, IEquatable<TValue>
		{
		}
	}
}
