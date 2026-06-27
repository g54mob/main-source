using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions.Equivalency;

namespace FluentAssertions.Common
{
	internal class MemberPath
	{
		private readonly string dottedPath;

		private readonly Type reflectedType;

		private readonly Type declaringType;

		private string[] segments;

		private static readonly MemberPathSegmentEqualityComparer MemberPathSegmentEqualityComparer = new MemberPathSegmentEqualityComparer();

		private string[] Segments => segments ?? (segments = SystemExtensions.Replace(dottedPath, "[]", "[*]", StringComparison.Ordinal).Split(new char[3] { '.', '[', ']' }, StringSplitOptions.RemoveEmptyEntries));

		public string MemberName => Segments[^1];

		public MemberPath(IMember member, string parentPath)
			: this(member.ReflectedType, member.DeclaringType, parentPath.Combine(member.Expectation.Name))
		{
		}

		public MemberPath(Type reflectedType, Type declaringType, string dottedPath)
			: this(dottedPath)
		{
			this.reflectedType = reflectedType;
			this.declaringType = declaringType;
		}

		public MemberPath(string dottedPath)
		{
			Guard.ThrowIfArgumentIsNull(dottedPath, "dottedPath", "A member path cannot be null");
			this.dottedPath = dottedPath;
		}

		public bool IsParentOrChildOf(MemberPath candidate)
		{
			if (!IsParentOf(candidate))
			{
				return IsChildOf(candidate);
			}
			return true;
		}

		public bool IsSameAs(MemberPath candidate)
		{
			if (!(declaringType == candidate.declaringType))
			{
				Type type = declaringType;
				if ((object)type == null || !type.IsAssignableFrom(candidate.reflectedType))
				{
					return false;
				}
			}
			return candidate.Segments.SequenceEqual(Segments, MemberPathSegmentEqualityComparer);
		}

		private bool IsParentOf(MemberPath candidate)
		{
			string[] array = candidate.Segments;
			if (array.Length > Segments.Length)
			{
				return array.Take(Segments.Length).SequenceEqual(Segments, MemberPathSegmentEqualityComparer);
			}
			return false;
		}

		private bool IsChildOf(MemberPath candidate)
		{
			string[] array = candidate.Segments;
			if (array.Length < Segments.Length)
			{
				return array.SequenceEqual(Segments.Take(array.Length), MemberPathSegmentEqualityComparer);
			}
			return false;
		}

		public MemberPath AsParentCollectionOf(MemberPath nextPath)
		{
			string text = dottedPath.Combine(nextPath.dottedPath, "[]");
			return new MemberPath(nextPath.reflectedType, nextPath.declaringType, text);
		}

		public bool IsEquivalentTo(string path)
		{
			return path.WithoutSpecificCollectionIndices() == dottedPath.WithoutSpecificCollectionIndices();
		}

		public bool HasSameParentAs(MemberPath path)
		{
			if (Segments.Length == path.Segments.Length)
			{
				return GetParentSegments().SequenceEqual(path.GetParentSegments(), MemberPathSegmentEqualityComparer);
			}
			return false;
		}

		private IEnumerable<string> GetParentSegments()
		{
			return Segments.Take(Segments.Length - 1);
		}

		public bool GetContainsSpecificCollectionIndex()
		{
			return dottedPath.ContainsSpecificCollectionIndex();
		}

		public MemberPath WithCollectionAsRoot()
		{
			return new MemberPath(reflectedType, declaringType, "[]." + dottedPath);
		}

		public override string ToString()
		{
			return dottedPath;
		}
	}
}
