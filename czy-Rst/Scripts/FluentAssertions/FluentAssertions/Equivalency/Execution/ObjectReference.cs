using System;
using System.Linq;
using System.Runtime.CompilerServices;
using FluentAssertions.Common;

namespace FluentAssertions.Equivalency.Execution
{
	internal class ObjectReference
	{
		private readonly object @object;

		private readonly string path;

		private readonly bool? compareByMembers;

		private string[] pathElements;

		public bool CompareByMembers
		{
			get
			{
				bool? flag = compareByMembers;
				if (!flag.HasValue)
				{
					object obj = @object;
					if (obj == null)
					{
						return false;
					}
					return !obj.GetType().OverridesEquals();
				}
				return flag == true;
			}
		}

		public ObjectReference(object @object, string path, bool? compareByMembers = null)
		{
			this.@object = @object;
			this.path = path;
			this.compareByMembers = compareByMembers;
		}

		public override bool Equals(object obj)
		{
			if (obj is ObjectReference objectReference && @object == objectReference.@object)
			{
				return IsParentOrChildOf(objectReference);
			}
			return false;
		}

		private string[] GetPathElements()
		{
			return pathElements ?? (pathElements = SystemExtensions.Split(SystemExtensions.Replace(path.ToUpperInvariant(), "][", "].[", StringComparison.Ordinal), '.', StringSplitOptions.RemoveEmptyEntries));
		}

		private bool IsParentOrChildOf(ObjectReference other)
		{
			string[] array = GetPathElements();
			string[] array2 = other.GetPathElements();
			int num = Math.Min(array.Length, array2.Length);
			if (Math.Max(array.Length, array2.Length) - num > 0)
			{
				return array2.Take(num).SequenceEqual(array.Take(num));
			}
			return false;
		}

		public override int GetHashCode()
		{
			return RuntimeHelpers.GetHashCode(@object);
		}

		public override string ToString()
		{
			return FormattableString.Invariant($"{{\"{path}\", {@object}}}");
		}
	}
}
