using System;
using System.Runtime.CompilerServices;

namespace Aggro.Core
{
	public struct EntityContext : IEquatable<EntityContext>
	{
		public readonly int id;

		public static readonly EntityContext defaultContext = new EntityContext(1);

		public static readonly EntityContext invalid = new EntityContext(0);

		public static readonly EntityContext allContexts = new EntityContext(-1);

		private const int DEFAULT_CONTEXT_ID = 1;

		private const int INVALID_CONTEXT_ID = 0;

		private const int ALL_CONTEXT_ID = -1;

		public bool isValid
		{
			get
			{
				if (id != -1)
				{
					return id > 0;
				}
				return false;
			}
		}

		public bool isAllContexts => id == -1;

		public bool isDefaultContext => id == 1;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal EntityContext(int id)
		{
			this.id = id;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal int GetIndex()
		{
			return id - 1;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(EntityContext other)
		{
			return id == other.id;
		}

		public override bool Equals(object obj)
		{
			if (obj is EntityContext other)
			{
				return Equals(other);
			}
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override int GetHashCode()
		{
			return id;
		}

		public override string ToString()
		{
			return $"Id: {id}";
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator ==(EntityContext e1, EntityContext e2)
		{
			return e1.Equals(e2);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator !=(EntityContext e1, EntityContext e2)
		{
			return !(e1 == e2);
		}
	}
}
