using System;
using System.Collections.Generic;
using Unity.Entities;

namespace Kitchen
{
	public struct SystemReference : IEquatable<SystemReference>
	{
		private static readonly Dictionary<Type, int> HashCodeCache = new Dictionary<Type, int>();

		private int Hash;

		private static int GetHash(Type t)
		{
			if (!HashCodeCache.TryGetValue(t, out var value))
			{
				value = t.Name.GetHashCode();
				HashCodeCache[t] = value;
			}
			return value;
		}

		private SystemReference(GenericSystemBase sys)
		{
			Hash = GetHash(sys.GetType());
		}

		public static string GetName(int hash)
		{
			foreach (KeyValuePair<Type, int> item in HashCodeCache)
			{
				if (item.Value == hash)
				{
					return item.Key.Name;
				}
			}
			return "";
		}

		public static implicit operator SystemReference(int hash)
		{
			return new SystemReference
			{
				Hash = hash
			};
		}

		public static implicit operator SystemReference(ComponentSystemBase system)
		{
			return new SystemReference
			{
				Hash = GetHash(system.GetType())
			};
		}

		public static implicit operator SystemReference(Type system)
		{
			return new SystemReference
			{
				Hash = GetHash(system)
			};
		}

		public static implicit operator int(SystemReference reference)
		{
			return reference.Hash;
		}

		public bool Equals(SystemReference other)
		{
			return Hash == other.Hash;
		}

		public override bool Equals(object obj)
		{
			if (obj is SystemReference other)
			{
				return Equals(other);
			}
			return false;
		}

		public override int GetHashCode()
		{
			return Hash;
		}
	}
}
