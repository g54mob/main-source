using System;
using System.Collections.Generic;
using HandlebarsDotNet.StringUtils;

namespace HandlebarsDotNet.PathStructure
{
	public readonly struct PathSegment : IEquatable<PathSegment>, IEquatable<string>
	{
		private static readonly Substring ThisSubstring = "this";

		private readonly int _hashCode;

		internal readonly bool IsParent;

		internal readonly bool IsThis;

		public readonly ChainSegment[] PathChain;

		public readonly bool IsNotEmpty;

		internal PathSegment(Substring segment, ChainSegment[] chain)
		{
			this = default(PathSegment);
			IsNotEmpty = segment.Length != 0;
			IsParent = IsNotEmpty && segment == "..";
			IsThis = IsNotEmpty && !IsParent && (segment == "." || Substring.EqualsIgnoreCase(in segment, in ThisSubstring));
			PathChain = chain;
			_hashCode = GetHashCodeImpl();
		}

		public bool Equals(PathSegment other)
		{
			if (IsNotEmpty != other.IsNotEmpty || other.PathChain.Length != PathChain.Length || IsThis != other.IsThis || IsParent != other.IsParent)
			{
				return false;
			}
			for (int i = 0; i < PathChain.Length; i++)
			{
				if (!PathChain[i].Equals(other.PathChain[i]))
				{
					return false;
				}
			}
			return true;
		}

		public bool Equals(string other)
		{
			return string.Equals(other, ToString(), StringComparison.OrdinalIgnoreCase);
		}

		public override bool Equals(object obj)
		{
			if (obj is PathSegment other)
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
			return string.Join(".", (IEnumerable<ChainSegment>)PathChain);
		}

		private int GetHashCodeImpl()
		{
			int hashCode = IsNotEmpty.GetHashCode();
			hashCode = (hashCode * 397) ^ IsThis.GetHashCode();
			hashCode = (hashCode * 397) ^ IsParent.GetHashCode();
			for (int i = 0; i < PathChain.Length; i++)
			{
				hashCode = (hashCode * 397) ^ PathChain[i].GetHashCode();
			}
			return hashCode;
		}
	}
}
