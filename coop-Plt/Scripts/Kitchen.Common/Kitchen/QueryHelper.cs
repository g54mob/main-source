using System;
using Unity.Entities;

namespace Kitchen
{
	public class QueryHelper : IEquatable<QueryHelper>
	{
		private ComponentType[] AllTypes;

		private ComponentType[] AnyTypes;

		private ComponentType[] NoneTypes;

		public bool Equals(QueryHelper other)
		{
			if ((object)other == null)
			{
				return false;
			}
			if ((object)this == other)
			{
				return true;
			}
			if (object.Equals(AllTypes, other.AllTypes) && object.Equals(AnyTypes, other.AnyTypes))
			{
				return object.Equals(NoneTypes, other.NoneTypes);
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
			if (obj.GetType() != GetType())
			{
				return false;
			}
			return Equals((QueryHelper)obj);
		}

		public override int GetHashCode()
		{
			return (((((AllTypes != null) ? AllTypes.GetHashCode() : 0) * 397) ^ ((AnyTypes != null) ? AnyTypes.GetHashCode() : 0)) * 397) ^ ((NoneTypes != null) ? NoneTypes.GetHashCode() : 0);
		}

		public static bool operator ==(QueryHelper left, QueryHelper right)
		{
			return object.Equals(left, right);
		}

		public static bool operator !=(QueryHelper left, QueryHelper right)
		{
			return !object.Equals(left, right);
		}

		public static implicit operator EntityQueryDesc(QueryHelper q)
		{
			return q.Build();
		}

		public EntityQueryDesc Build()
		{
			return new EntityQueryDesc
			{
				All = (AllTypes ?? new ComponentType[0]),
				Any = (AnyTypes ?? new ComponentType[0]),
				None = (NoneTypes ?? new ComponentType[0])
			};
		}

		public QueryHelper All(params ComponentType[] arr)
		{
			AllTypes = arr;
			return this;
		}

		public QueryHelper Any(params ComponentType[] arr)
		{
			AnyTypes = arr;
			return this;
		}

		public QueryHelper None(params ComponentType[] arr)
		{
			NoneTypes = arr;
			return this;
		}
	}
}
