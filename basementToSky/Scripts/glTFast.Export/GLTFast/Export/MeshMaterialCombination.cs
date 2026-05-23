using System;

namespace GLTFast.Export
{
	internal readonly struct MeshMaterialCombination
	{
		private readonly int m_MeshId;

		private readonly int[] m_MaterialIds;

		public MeshMaterialCombination(int meshId, int[] materialIds)
		{
			m_MeshId = meshId;
			m_MaterialIds = materialIds;
		}

		public override bool Equals(object obj)
		{
			if (obj == null || GetType() != obj.GetType())
			{
				return false;
			}
			return Equals((MeshMaterialCombination)obj);
		}

		private bool Equals(MeshMaterialCombination other)
		{
			if (m_MeshId == other.m_MeshId)
			{
				return Equals(m_MaterialIds, other.m_MaterialIds);
			}
			return false;
		}

		private static bool Equals(int[] a, int[] b)
		{
			if (a == null && b == null)
			{
				return true;
			}
			if ((a == null) ^ (b == null))
			{
				return false;
			}
			if (a.Length != b.Length)
			{
				return false;
			}
			for (int i = 0; i < a.Length; i++)
			{
				if (a[i] != b[i])
				{
					return false;
				}
			}
			return true;
		}

		public override int GetHashCode()
		{
			HashCode hashCode = default(HashCode);
			hashCode.Add(m_MeshId);
			if (m_MaterialIds != null)
			{
				int[] materialIds = m_MaterialIds;
				foreach (int value in materialIds)
				{
					hashCode.Add(value);
				}
			}
			return hashCode.ToHashCode();
		}
	}
}
