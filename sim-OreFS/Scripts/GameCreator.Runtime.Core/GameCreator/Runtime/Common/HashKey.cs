using System;
using Unity.Collections;
using Unity.Mathematics;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	internal readonly struct HashKey : IEquatable<HashKey>
	{
		[NonSerialized]
		[ReadOnly]
		private readonly int m_Dimension;

		[NonSerialized]
		[ReadOnly]
		private readonly int3 m_Position;

		[NonSerialized]
		[ReadOnly]
		private readonly int m_HashCode;

		public HashKey(int dimension, int3 position)
		{
			m_Dimension = dimension;
			m_Position = position;
			m_HashCode = HashCode.Combine(dimension, position);
		}

		public bool Equals(HashKey other)
		{
			if (m_Position.x == other.m_Position.x && m_Position.y == other.m_Position.y && m_Position.z == other.m_Position.z)
			{
				return m_Dimension == other.m_Dimension;
			}
			return false;
		}

		public override int GetHashCode()
		{
			return m_HashCode;
		}

		public static int3 Hash(int dimension, int3 position)
		{
			return new int3((int)math.floor((float)position.x / (float)dimension), (int)math.floor((float)position.y / (float)dimension), (int)math.floor((float)position.z / (float)dimension));
		}

		public static int3 Hash(int clusterSize, Vector3 position)
		{
			return new int3((int)Math.Floor(position.x / (float)clusterSize), (int)Math.Floor(position.y / (float)clusterSize), (int)Math.Floor(position.z / (float)clusterSize));
		}
	}
}
