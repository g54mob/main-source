using System;
using Newtonsoft.Json;
using UnityEngine;

namespace Data.Shapes
{
	[Serializable]
	[JsonConverter(typeof(ShapeHashPairConverter))]
	public struct ShapeHashPair : IEquatable<ShapeHashPair>, IComparable<ShapeHashPair>
	{
		public Hash128 VoxelHash;

		public Hash128 ColorHash;

		private string _cacheString;

		public bool IsValid => VoxelHash.isValid;

		public override string ToString()
		{
			if (string.IsNullOrEmpty(_cacheString))
			{
				_cacheString = $"{VoxelHash}-{ColorHash}";
			}
			return _cacheString;
		}

		public static ShapeHashPair Parse(string hashString)
		{
			string[] array = ((!hashString.Contains("-")) ? new string[2]
			{
				hashString.Substring(0, hashString.Length / 2),
				hashString.Substring(hashString.Length / 2)
			} : hashString.Split('-'));
			return new ShapeHashPair
			{
				VoxelHash = Hash128.Parse(array[0]),
				ColorHash = Hash128.Parse(array[1])
			};
		}

		public bool Equals(ShapeHashPair other)
		{
			if (VoxelHash == other.VoxelHash)
			{
				return ColorHash == other.ColorHash;
			}
			return false;
		}

		public static bool operator ==(ShapeHashPair a, ShapeHashPair b)
		{
			return a.Equals(b);
		}

		public static bool operator !=(ShapeHashPair a, ShapeHashPair b)
		{
			return !(a == b);
		}

		public int CompareTo(ShapeHashPair other)
		{
			return string.Compare(ToString(), other.ToString(), StringComparison.Ordinal);
		}

		public override bool Equals(object obj)
		{
			return base.Equals(obj);
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(VoxelHash.GetHashCode(), ColorHash.GetHashCode());
		}
	}
}
