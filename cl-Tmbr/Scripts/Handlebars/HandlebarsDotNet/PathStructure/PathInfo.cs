using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using HandlebarsDotNet.Collections;
using HandlebarsDotNet.Extensions;
using HandlebarsDotNet.Polyfills;
using HandlebarsDotNet.Pools;
using HandlebarsDotNet.Runtime;
using HandlebarsDotNet.StringUtils;

namespace HandlebarsDotNet.PathStructure
{
	public sealed class PathInfo : IEquatable<PathInfo>
	{
		internal readonly struct TrimmedPathEqualityComparer : IEqualityComparer<PathInfo>
		{
			private readonly bool _countParts;

			private readonly bool _ignoreCase;

			private readonly StringComparison _stringComparison;

			public TrimmedPathEqualityComparer(bool countParts = true, bool ignoreCase = true)
			{
				_ignoreCase = ignoreCase;
				_countParts = countParts;
				_stringComparison = (ignoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal);
			}

			public bool Equals(PathInfo x, PathInfo y)
			{
				if (x == y)
				{
					return true;
				}
				if (x == null)
				{
					return false;
				}
				if (y == null)
				{
					return false;
				}
				if (!_countParts || x.Segments.Length == y.Segments.Length)
				{
					return string.Equals(x.TrimmedPath, y.TrimmedPath, _stringComparison);
				}
				return false;
			}

			public int GetHashCode(PathInfo obj)
			{
				if (!_ignoreCase)
				{
					return obj._trimmedHashCode;
				}
				return obj._trimmedInvariantHashCode;
			}
		}

		internal readonly bool IsValidHelperLiteral;

		internal readonly bool HasValue;

		internal readonly bool IsThis;

		internal readonly bool IsPureThis;

		internal readonly bool IsInversion;

		internal readonly bool IsBlockHelper;

		internal readonly bool IsBlockClose;

		private readonly int _hashCode;

		private readonly int _trimmedHashCode;

		private readonly int _trimmedInvariantHashCode;

		public static readonly PathInfo Empty = new PathInfo(PathType.Empty, "null", isValidHelperLiteral: false, ArrayEx.Empty<PathSegment>());

		public readonly bool IsVariable;

		public readonly PathSegment[] Segments;

		public readonly string Path;

		public readonly string TrimmedPath;

		private PathInfo(PathType pathType, string path, bool isValidHelperLiteral, PathSegment[] segments)
		{
			IsValidHelperLiteral = isValidHelperLiteral;
			HasValue = pathType != PathType.Empty;
			Path = path;
			_hashCode = (Path.GetHashCode() * 397) ^ HasValue.GetHashCode();
			if (!HasValue)
			{
				return;
			}
			IsVariable = pathType == PathType.Variable;
			IsInversion = pathType == PathType.Inversion;
			IsBlockHelper = pathType == PathType.BlockHelper;
			IsBlockClose = pathType == PathType.BlockClose;
			PathSegment[] source = segments.Where((PathSegment o) => !o.IsParent && o.IsNotEmpty).ToArray();
			IsThis = string.Equals(path, "this", StringComparison.OrdinalIgnoreCase) || path == "." || source.Any((PathSegment o) => o.IsThis);
			IsPureThis = string.Equals(path, "this", StringComparison.OrdinalIgnoreCase) || path == ".";
			Segments = segments;
			DisposableContainer<StringBuilder, InternalObjectPool<StringBuilder, StringBuilderPool.StringBuilderPooledObjectPolicy>> disposableContainer = StringBuilderPool.Shared.Use();
			try
			{
				StringBuilder value = disposableContainer.Value;
				int num = Segments.Length - 1;
				for (int num2 = 0; num2 <= num; num2++)
				{
					PathSegment pathSegment = Segments[num2];
					int num3 = pathSegment.PathChain.Length - 1;
					ChainSegment[] pathChain = pathSegment.PathChain;
					for (int num4 = 0; num4 <= num3; num4++)
					{
						value.Append(pathChain[num4].TrimmedValue);
						if (num4 != num3)
						{
							value.Append('.');
						}
					}
					if (num2 != num)
					{
						value.Append('/');
					}
				}
				TrimmedPath = value.ToString();
				_trimmedHashCode = TrimmedPath.GetHashCode();
				_trimmedInvariantHashCode = TrimmedPath.ToLowerInvariant().GetHashCode();
			}
			finally
			{
				((IDisposable)disposableContainer/*cast due to .constrained prefix*/).Dispose();
			}
		}

		public bool Equals(PathInfo other)
		{
			if (other == null)
			{
				return false;
			}
			if (this == other)
			{
				return true;
			}
			if (HasValue == other.HasValue)
			{
				return string.Equals(Path, other.Path, StringComparison.Ordinal);
			}
			return false;
		}

		public override bool Equals(object obj)
		{
			if (obj == null)
			{
				return false;
			}
			if (this == obj)
			{
				return true;
			}
			if (obj is PathInfo other)
			{
				return Equals(other);
			}
			return false;
		}

		public override int GetHashCode()
		{
			return _hashCode;
		}

		public override string ToString()
		{
			return Path;
		}

		public static implicit operator string(PathInfo pathInfo)
		{
			return pathInfo.Path;
		}

		public static implicit operator PathInfo(string path)
		{
			return PathInfoStore.Current?.GetOrAdd(path) ?? Parse(path);
		}

		public static PathInfo Parse(string path)
		{
			if (path == "null")
			{
				return Empty;
			}
			PathType pathType = GetPathType(path);
			Substring substring = new Substring(path);
			bool flag = true;
			bool flag2 = pathType == PathType.Variable;
			bool flag3 = pathType == PathType.Inversion;
			bool flag4 = pathType == PathType.BlockHelper;
			int start;
			if (flag2 || flag4 || flag3)
			{
				flag = flag4 || flag3;
				start = 1;
				substring = new Substring(in substring, in start);
			}
			List<PathSegment> list = new List<PathSegment>();
			ExtendedEnumerator<Substring, Substring.SplitEnumerator> extendedEnumerator = ExtendedEnumerator<Substring>.Create(Substring.Split(in substring, '/', StringSplitOptions.None));
			DisposableContainer<StringBuilder, InternalObjectPool<StringBuilder, StringBuilderPool.StringBuilderPooledObjectPolicy>> disposableContainer = StringBuilderPool.Shared.Use();
			try
			{
				StringBuilder value = disposableContainer.Value;
				bool flag5 = false;
				while (extendedEnumerator.MoveNext())
				{
					Substring substring2 = extendedEnumerator.Current.Value;
					if (value.Length != 0)
					{
						value.Append('/');
						value.Append(in substring2);
						if (Substring.LastIndexOf(in substring2, ']', out var index) && !Substring.LastIndexOf(in substring2, '[', index, out start))
						{
							flag5 = false;
							ChainSegment[] pathChain = GetPathChain(value.ToString());
							if (pathChain.Length > 1)
							{
								flag = false;
							}
							list.Add(new PathSegment(substring2, pathChain));
							value.Length = 0;
							continue;
						}
					}
					if (Substring.LastIndexOf(in substring2, '[', out var index2) && !Substring.LastIndexOf(in substring2, ']', index2, out start))
					{
						if (!flag5)
						{
							value.Append(in substring2);
						}
						flag5 = true;
						continue;
					}
					start = substring2.Length;
					switch (start)
					{
					case 2:
						if (substring2[0] == '.' && substring2[1] == '.')
						{
							flag = false;
							list.Add(new PathSegment(substring2, ArrayEx.Empty<ChainSegment>()));
							continue;
						}
						break;
					case 1:
						if (substring2[0] == '.')
						{
							flag = false;
							list.Add(new PathSegment(substring2, ArrayEx.Empty<ChainSegment>()));
							continue;
						}
						break;
					}
					ChainSegment[] pathChain2 = GetPathChain(substring2);
					if (pathChain2.Length > 1 && pathType != PathType.BlockHelper)
					{
						flag = false;
					}
					if (!flag5)
					{
						list.Add(new PathSegment(substring2, pathChain2));
					}
				}
				if (flag && list.Count > 1)
				{
					flag = false;
				}
				return new PathInfo(pathType, path, flag, list.ToArray());
			}
			finally
			{
				((IDisposable)disposableContainer/*cast due to .constrained prefix*/).Dispose();
			}
		}

		private static ChainSegment[] GetPathChain(Substring segmentString)
		{
			bool flag = false;
			ExtendedEnumerator<Substring, Substring.SplitEnumerator> extendedEnumerator = ExtendedEnumerator<Substring>.Create(Substring.Split(in segmentString, '.', StringSplitOptions.RemoveEmptyEntries));
			if (!extendedEnumerator.Any && segmentString == ".")
			{
				return new ChainSegment[1] { ChainSegment.This };
			}
			List<ChainSegment> list = new List<ChainSegment>();
			while (extendedEnumerator.MoveNext())
			{
				Substring substring = extendedEnumerator.Current.Value;
				if (flag)
				{
					if (Substring.EndsWith(in substring, ']'))
					{
						flag = false;
					}
					list[list.Count - 1] = ChainSegment.Create($"{list[list.Count - 1]}.{substring.ToString()}");
					continue;
				}
				if (Substring.StartsWith(in substring, '['))
				{
					flag = true;
				}
				if (Substring.EndsWith(in substring, ']'))
				{
					flag = false;
				}
				list.Add(ChainSegment.Create(substring.ToString()));
			}
			return list.ToArray();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static PathType GetPathType(string path)
		{
			return path[0] switch
			{
				'@' => PathType.Variable, 
				'^' => PathType.Inversion, 
				'#' => PathType.BlockHelper, 
				'/' => PathType.BlockClose, 
				_ => PathType.None, 
			};
		}
	}
}
