using System;
using System.Collections;
using System.Collections.Generic;

namespace Google.Protobuf
{
	public sealed class ExtensionRegistry : ICollection<Extension>, IEnumerable<Extension>, IEnumerable, IDeepCloneable<ExtensionRegistry>
	{
		internal sealed class ExtensionComparer : IEqualityComparer<Extension>
		{
			internal static ExtensionComparer Instance;

			public bool Equals(Extension a, Extension b)
			{
				return false;
			}

			public int GetHashCode(Extension a)
			{
				return 0;
			}
		}

		private readonly IDictionary<ObjectIntPair<Type>, Extension> extensions;

		public int Count => 0;

		bool ICollection<Extension>.IsReadOnly => false;

		public ExtensionRegistry()
		{
		}

		private ExtensionRegistry(IDictionary<ObjectIntPair<Type>, Extension> collection)
		{
		}

		internal bool ContainsInputField(uint lastTag, Type target, out Extension extension)
		{
			extension = null;
			return false;
		}

		public void Add(Extension extension)
		{
		}

		public void AddRange(IEnumerable<Extension> extensions)
		{
		}

		public void Clear()
		{
		}

		public bool Contains(Extension item)
		{
			return false;
		}

		void ICollection<Extension>.CopyTo(Extension[] array, int arrayIndex)
		{
		}

		public IEnumerator<Extension> GetEnumerator()
		{
			return null;
		}

		public bool Remove(Extension item)
		{
			return false;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return null;
		}

		public ExtensionRegistry Clone()
		{
			return null;
		}
	}
}
