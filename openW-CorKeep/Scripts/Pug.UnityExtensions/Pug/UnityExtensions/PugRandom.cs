using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.NetCode;
using UnityEngine;

namespace Pug.UnityExtensions
{
	public static class PugRandom
	{
		public struct HaltonSequenceGenerator2D
		{
			private const int BASE_X = 2;

			private const int BASE_Y = 3;

			private int _nextIndex;

			public HaltonSequenceGenerator2D(int startIndex = 0)
			{
				_nextIndex = startIndex;
			}

			public void FastForward(int steps)
			{
				_nextIndex += steps;
			}

			public float2 Next()
			{
				float2 result = new float2(Halton(2, _nextIndex), Halton(3, _nextIndex));
				_nextIndex++;
				return result;
			}

			private static float Halton(int basePrime, int index)
			{
				float num = 0f;
				float num2 = 1f;
				while (index > 0)
				{
					num2 /= (float)basePrime;
					num += num2 * (float)(index % basePrime);
					index /= basePrime;
				}
				return num;
			}
		}

		public static uint GetSeed()
		{
			return (uint)(UnityEngine.Random.Range(1, int.MaxValue) * ((UnityEngine.Random.value > 0.5f) ? 1 : (-1)));
		}

		public static uint GetSeedFromVector(Vector3 vector)
		{
			return GetSeedFromVector(new Vector2(vector.x, vector.z));
		}

		public static uint GetSeedFromVector(Vector2 vector)
		{
			uint num = ((uint)vector.x << 16) | ((uint)vector.y & 0xFFFF);
			if (num != uint.MaxValue)
			{
				return num;
			}
			return 0u;
		}

		public static uint GetSeedFromVector(Vector2Int vector)
		{
			uint num = (uint)((vector.x << 16) | (vector.y & 0xFFFF));
			if (num != uint.MaxValue)
			{
				return num;
			}
			return 0u;
		}

		public static uint GetSeedFromVector(int2 vector)
		{
			uint num = (uint)((vector.x << 16) | (vector.y & 0xFFFF));
			if (num != uint.MaxValue)
			{
				return num;
			}
			return 0u;
		}

		public static string GenerateWorldSeed()
		{
			return ((long)(GetRng().NextDouble() * 899999999999.0) + 100000000000L).ToString();
		}

		public static Unity.Mathematics.Random GetRng()
		{
			return new Unity.Mathematics.Random(GetSeed());
		}

		public static Unity.Mathematics.Random GetRng(uint seed)
		{
			return new Unity.Mathematics.Random(seed);
		}

		public static Unity.Mathematics.Random GetRngFromWorldPosition(Vector3 worldPosition, uint seed = 0u)
		{
			return Unity.Mathematics.Random.CreateFromIndex(GetSeedFromVector(worldPosition) + seed);
		}

		public static Unity.Mathematics.Random GetRngFromInt2(int2 worldPosition, uint seed = 0u)
		{
			return Unity.Mathematics.Random.CreateFromIndex(GetSeedFromVector(worldPosition) + seed);
		}

		public static float GetRandomValueFromWorldPosition(Vector3 worldPosition)
		{
			return Unity.Mathematics.Random.CreateFromIndex(GetSeedFromVector(worldPosition)).NextFloat();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Unity.Mathematics.Random GetRngFromEntity(uint seed, Entity entity)
		{
			return Unity.Mathematics.Random.CreateFromIndex(seed ^ (uint)entity.Index ^ (uint)entity.Version);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Unity.Mathematics.Random GetRngFromEntity(uint seed, NetworkTick networkTick, GhostInstance ghostInstance)
		{
			return Unity.Mathematics.Random.CreateFromIndex(seed ^ networkTick.TickIndexForValidTick ^ (uint)ghostInstance.ghostId);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Unity.Mathematics.Random InheritRngFromEntity(ref Unity.Mathematics.Random parentRng)
		{
			return Unity.Mathematics.Random.CreateFromIndex(parentRng.NextUInt());
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Unity.Mathematics.Random GetRngFromEntity(uint seed, NetworkTick networkTick, Entity entity)
		{
			return Unity.Mathematics.Random.CreateFromIndex(seed ^ networkTick.TickIndexForValidTick ^ (uint)entity.Index ^ (uint)entity.Version);
		}

		public static Unity.Entities.Hash128 GenerateGuid()
		{
			byte[] array = Guid.NewGuid().ToByteArray();
			int x = (array[0] << 24) | (array[1] << 16) | (array[2] << 8) | array[3];
			uint y = (uint)((array[4] << 24) | (array[5] << 16) | (array[6] << 8) | array[7]);
			uint z = (uint)((array[8] << 24) | (array[9] << 16) | (array[10] << 8) | array[11]);
			uint w = (uint)((array[12] << 24) | (array[13] << 16) | (array[14] << 8) | array[15]);
			return new Unity.Entities.Hash128((uint)x, y, z, w);
		}

		public static Unity.Entities.Hash128 GenerateGuid(Unity.Mathematics.Random rng)
		{
			uint x = rng.NextUInt();
			uint num = rng.NextUInt();
			uint num2 = rng.NextUInt();
			uint w = rng.NextUInt();
			num2 &= 0xFFFFFFBFu;
			num2 |= 0x80;
			num &= 0xFF0FFFFFu;
			num |= 0x400000;
			return new Unity.Entities.Hash128(x, num, num2, w);
		}

		public static void ShuffleListKindOfRandomly<T>(List<T> list)
		{
			int count = list.Count;
			while (count-- > 1)
			{
				int index = UnityEngine.Random.Range(0, count);
				T value = list[index];
				list[index] = list[count];
				list[count] = value;
			}
		}

		public static void ShuffleListKindOfRandomly<T>(ref NativeArray<T> list, ref Unity.Mathematics.Random rng) where T : unmanaged
		{
			int length = list.Length;
			while (length-- > 1)
			{
				int index = rng.NextInt(length);
				T value = list[index];
				list[index] = list[length];
				list[length] = value;
			}
		}

		public static void ShuffleListKindOfRandomly<T>(NativeList<T> list, ref Unity.Mathematics.Random rng) where T : unmanaged
		{
			int length = list.Length;
			while (length-- > 1)
			{
				int num = rng.NextInt(length);
				int index = num;
				int index2 = length;
				T val = list[length];
				T val2 = list[num];
				T val3 = (list[index] = val);
				val3 = (list[index2] = val2);
			}
		}

		public static void ShuffleListKindOfRandomly<T>(NativeArray<T> list, ref Unity.Mathematics.Random rng) where T : unmanaged
		{
			int length = list.Length;
			while (length-- > 1)
			{
				int num = rng.NextInt(length);
				int index = num;
				int index2 = length;
				T val = list[length];
				T val2 = list[num];
				T val3 = (list[index] = val);
				val3 = (list[index2] = val2);
			}
		}

		public static float2 UniformDiskSample(ref Unity.Mathematics.Random rng, float innerRadius = 0f, float outerRadius = 1f, float angle1 = 0f, float angle2 = MathF.PI * 2f)
		{
			float num = ((math.abs(innerRadius - outerRadius) < float.Epsilon) ? outerRadius : (math.sqrt(rng.NextFloat(innerRadius / outerRadius, 1f)) * outerRadius));
			float x = ((math.abs(angle1 - angle2) < float.Epsilon) ? angle1 : rng.NextFloat(angle1, angle2));
			return num * new float2(math.cos(x), math.sin(x));
		}

		public static Vector2 GenerateUniformVector2(float min, float max)
		{
			return new Vector2(UnityEngine.Random.Range(min, max), UnityEngine.Random.Range(min, max));
		}

		public static Vector3 GenerateUniformVector3(float min, float max)
		{
			return new Vector3(UnityEngine.Random.Range(min, max), UnityEngine.Random.Range(min, max), UnityEngine.Random.Range(min, max));
		}

		public static float GenerateUniform(float min, float max)
		{
			return UnityEngine.Random.Range(min, max);
		}

		public static int GenerateUniform(int min, int max)
		{
			return UnityEngine.Random.Range(min, max);
		}

		public static int GenerateUniformAndSkip(int min, int max, int skip)
		{
			int num = UnityEngine.Random.Range(min, max);
			if (num == skip)
			{
				int num2 = 3;
				while (num2-- > 0)
				{
					num = UnityEngine.Random.Range(min, max);
					if (num != skip)
					{
						return num;
					}
				}
				int num3 = UnityEngine.Random.Range(0, 1);
				if (num3 == 0)
				{
					if (num3 + 1 > max - 1)
					{
						return min;
					}
					return max - 1;
				}
				if (num3 - 1 < min)
				{
					return max - 1;
				}
				return min;
			}
			return num;
		}

		public static float GenerateNormal(float min, float max, int maxSamples = 4, bool clamp = true)
		{
			float num5;
			do
			{
				int num = 8;
				float num2;
				float num4;
				do
				{
					num2 = 2f * UnityEngine.Random.Range(0f, 1f) - 1f;
					float num3 = 2f * UnityEngine.Random.Range(0f, 1f) - 1f;
					num4 = num2 * num2 + num3 * num3;
				}
				while ((double)num4 >= 1.0 && --num > 0);
				num5 = num2 * Mathf.Sqrt(-2f * Mathf.Log(num4) / num4);
				num5 = num5 * max - min;
			}
			while (clamp && (num5 < min || num5 > max) && --maxSamples > 0);
			if (!clamp)
			{
				return num5;
			}
			return Mathf.Clamp(num5, min, max);
		}

		public static int GetRandomIndexFromWeightedValues(List<float> weights)
		{
			float num = 0f;
			List<float> list = new List<float>();
			foreach (float weight in weights)
			{
				num += weight;
				list.Add(num);
			}
			float value = UnityEngine.Random.value;
			for (int i = 0; i < list.Count; i++)
			{
				if (list[i] / num > value)
				{
					return i;
				}
			}
			return list.Count;
		}

		public static int Range(int min, int max, int seed)
		{
			UnityEngine.Random.State state = UnityEngine.Random.state;
			UnityEngine.Random.InitState(seed);
			int result = UnityEngine.Random.Range(min, max);
			UnityEngine.Random.state = state;
			return result;
		}

		public static float Range(float min, float max, int seed)
		{
			UnityEngine.Random.State state = UnityEngine.Random.state;
			UnityEngine.Random.InitState(seed);
			float result = UnityEngine.Random.Range(min, max);
			UnityEngine.Random.state = state;
			return result;
		}

		public static int GenerateRandomExtraItems(float chance, ref Unity.Mathematics.Random rng)
		{
			int num = (int)Mathf.Floor(chance);
			float num2 = chance - (float)num;
			return num + ((rng.NextFloat() <= num2) ? 1 : 0);
		}

		public static Color Color(int seed)
		{
			UnityEngine.Random.State state = UnityEngine.Random.state;
			UnityEngine.Random.InitState(seed);
			Color result = new Color(UnityEngine.Random.value, UnityEngine.Random.value, UnityEngine.Random.value, 1f);
			UnityEngine.Random.state = state;
			return result;
		}

		public static Color ColorHSV(int seed)
		{
			UnityEngine.Random.State state = UnityEngine.Random.state;
			UnityEngine.Random.InitState(seed);
			Color result = UnityEngine.Random.ColorHSV();
			UnityEngine.Random.state = state;
			return result;
		}
	}
}
