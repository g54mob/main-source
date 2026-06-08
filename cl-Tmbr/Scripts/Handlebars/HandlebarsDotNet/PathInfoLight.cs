using System;
using System.Collections.Generic;
using HandlebarsDotNet.PathStructure;

namespace HandlebarsDotNet
{
	public readonly struct PathInfoLight : IEquatable<PathInfoLight>, IEquatable<PathInfo>
	{
		internal readonly struct PathInfoLightEqualityComparer : IEqualityComparer<PathInfoLight>
		{
			private readonly PathInfo.TrimmedPathEqualityComparer _comparer;

			public PathInfoLightEqualityComparer(bool countParts = true, bool ignoreCase = true)
			{
				_comparer = new PathInfo.TrimmedPathEqualityComparer(countParts, ignoreCase);
			}

			public bool Equals(PathInfoLight x, PathInfoLight y)
			{
				if (x._comparerTag == y._comparerTag)
				{
					return _comparer.Equals(x.PathInfo, y.PathInfo);
				}
				return false;
			}

			public int GetHashCode(PathInfoLight obj)
			{
				return _comparer.GetHashCode(obj.PathInfo);
			}
		}

		private readonly int _comparerTag;

		public readonly PathInfo PathInfo;

		internal static PathInfoLightEqualityComparer PlainPathComparer { get; } = new PathInfoLightEqualityComparer(countParts: false);

		internal static PathInfoLightEqualityComparer PlainPathWithPartsCountComparer { get; } = new PathInfoLightEqualityComparer(true, true);

		public PathInfoLight(PathInfo pathInfo)
		{
			PathInfo = pathInfo;
			_comparerTag = 0;
		}

		private PathInfoLight(PathInfo pathInfo, int comparerTag)
		{
			PathInfo = pathInfo;
			_comparerTag = comparerTag;
		}

		internal PathInfoLight TagComparer()
		{
			return new PathInfoLight(PathInfo, _comparerTag + 1);
		}

		public bool Equals(PathInfoLight other)
		{
			if (_comparerTag == other._comparerTag)
			{
				return object.Equals(PathInfo, other.PathInfo);
			}
			return false;
		}

		public bool Equals(PathInfo other)
		{
			return object.Equals(PathInfo, other);
		}

		public override bool Equals(object obj)
		{
			if (obj is PathInfoLight other)
			{
				return Equals(other);
			}
			return false;
		}

		public override int GetHashCode()
		{
			return (_comparerTag * 397) ^ ((PathInfo != null) ? PathInfo.GetHashCode() : 0);
		}

		public override string ToString()
		{
			return PathInfo.ToString();
		}

		public static implicit operator PathInfoLight(PathInfo pathInfo)
		{
			return new PathInfoLight(pathInfo);
		}

		public static implicit operator PathInfoLight(string path)
		{
			return new PathInfoLight(PathInfoStore.Current?.GetOrAdd(path) ?? PathInfo.Parse(path));
		}

		public static implicit operator PathInfo(PathInfoLight pathInfo)
		{
			return pathInfo.PathInfo;
		}
	}
}
