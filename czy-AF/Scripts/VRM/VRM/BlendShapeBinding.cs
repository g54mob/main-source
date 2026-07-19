using System;

namespace VRM
{
	[Serializable]
	public struct BlendShapeBinding : IEquatable<BlendShapeBinding>
	{
		public string RelativePath;

		public int Index;

		public float Weight;

		public override string ToString()
		{
			return $"{RelativePath}[{Index}]=>{Weight}";
		}

		public bool Equals(BlendShapeBinding other)
		{
			if (string.Equals(RelativePath, other.RelativePath) && Index == other.Index)
			{
				return Weight.Equals(other.Weight);
			}
			return false;
		}

		public override bool Equals(object obj)
		{
			if (obj == null)
			{
				return false;
			}
			if (obj is BlendShapeBinding)
			{
				return Equals((BlendShapeBinding)obj);
			}
			return false;
		}

		public override int GetHashCode()
		{
			return (((((RelativePath != null) ? RelativePath.GetHashCode() : 0) * 397) ^ Index) * 397) ^ Weight.GetHashCode();
		}
	}
}
