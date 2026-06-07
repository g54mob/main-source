using System;
using System.Linq;
using System.Text;

namespace Data.Shapes
{
	[Serializable]
	public struct RotationIndependentHash : IEquatable<RotationIndependentHash>
	{
		private static readonly StringBuilder StringBuilder = new StringBuilder();

		public ShapeHashPair[] Rotations;

		private string _cacheString;

		public bool Contains(ShapeHashPair shapeHashPair)
		{
			if (Rotations == null)
			{
				return false;
			}
			ShapeHashPair[] rotations = Rotations;
			for (int i = 0; i < rotations.Length; i++)
			{
				if (rotations[i] == shapeHashPair)
				{
					return true;
				}
			}
			return false;
		}

		public bool ContainsShape(ShapeHashPair shapeHashPair)
		{
			if (Rotations == null)
			{
				return false;
			}
			ShapeHashPair[] rotations = Rotations;
			for (int i = 0; i < rotations.Length; i++)
			{
				if (rotations[i].VoxelHash == shapeHashPair.VoxelHash)
				{
					return true;
				}
			}
			return false;
		}

		public override string ToString()
		{
			if (string.IsNullOrEmpty(_cacheString))
			{
				StringBuilder.Clear();
				for (int i = 0; i < Rotations.Length; i++)
				{
					StringBuilder.Append(Rotations[i]);
					if (i < Rotations.Length - 1)
					{
						StringBuilder.Append(',');
					}
				}
				_cacheString = StringBuilder.ToString();
			}
			return _cacheString;
		}

		public static RotationIndependentHash Parse(string hashString)
		{
			string[] array = hashString.Split(",");
			RotationIndependentHash result = default(RotationIndependentHash);
			ShapeHashPair[] array2 = new ShapeHashPair[array.Length];
			for (int i = 0; i < array.Length; i++)
			{
				string hashString2 = array[i];
				array2[i] = ShapeHashPair.Parse(hashString2);
			}
			Array.Sort(array2);
			result.Rotations = array2.Distinct().ToArray();
			return result;
		}

		public bool Equals(RotationIndependentHash other)
		{
			if (Rotations == null != (other.Rotations == null))
			{
				return false;
			}
			if (Rotations != null && other.Rotations != null)
			{
				if (Rotations.Length != other.Rotations.Length)
				{
					return false;
				}
				for (int i = 0; i < Rotations.Length; i++)
				{
					if (Rotations[i] != other.Rotations[i])
					{
						return false;
					}
				}
			}
			return true;
		}

		public static bool operator ==(RotationIndependentHash a, RotationIndependentHash b)
		{
			return a.Equals(b);
		}

		public static bool operator !=(RotationIndependentHash a, RotationIndependentHash b)
		{
			return !a.Equals(b);
		}

		public bool Equals(ShapeHashPair other)
		{
			if (Rotations == null)
			{
				return false;
			}
			for (int i = 0; i < Rotations.Length; i++)
			{
				if (Rotations[i].Equals(other))
				{
					return true;
				}
			}
			return false;
		}

		public override int GetHashCode()
		{
			HashCode hashCode = default(HashCode);
			for (int i = 0; i < Rotations.Length; i++)
			{
				hashCode.Add(Rotations[i]);
			}
			return hashCode.ToHashCode();
		}

		public static bool operator ==(RotationIndependentHash a, ShapeHashPair b)
		{
			return a.Equals(b);
		}

		public static bool operator !=(RotationIndependentHash a, ShapeHashPair b)
		{
			return !a.Equals(b);
		}
	}
}
