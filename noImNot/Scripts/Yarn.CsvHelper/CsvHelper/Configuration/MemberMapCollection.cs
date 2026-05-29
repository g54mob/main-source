using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Reflection;

namespace CsvHelper.Configuration
{
	[DebuggerDisplay("Count = {list.Count}")]
	public class MemberMapCollection : IList<MemberMap>, ICollection<MemberMap>, IEnumerable<MemberMap>, IEnumerable
	{
		private readonly List<MemberMap> list;

		private readonly IComparer<MemberMap> comparer;

		public virtual int Count => 0;

		public virtual bool IsReadOnly => false;

		public virtual MemberMap this[int index]
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public MemberMapCollection()
		{
		}

		public MemberMapCollection(IComparer<MemberMap> comparer)
		{
		}

		public virtual IEnumerator<MemberMap> GetEnumerator()
		{
			return null;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return null;
		}

		public virtual void Add(MemberMap item)
		{
		}

		public virtual void AddRange(ICollection<MemberMap> collection)
		{
		}

		public virtual void Clear()
		{
		}

		public virtual bool Contains(MemberMap item)
		{
			return false;
		}

		public virtual void CopyTo(MemberMap[] array, int arrayIndex)
		{
		}

		public virtual bool Remove(MemberMap item)
		{
			return false;
		}

		public virtual int IndexOf(MemberMap item)
		{
			return 0;
		}

		public virtual void Insert(int index, MemberMap item)
		{
		}

		public virtual void RemoveAt(int index)
		{
		}

		public virtual MemberMap Find<T>(Expression<Func<T, object>> expression)
		{
			return null;
		}

		public virtual MemberMap Find(MemberInfo member)
		{
			return null;
		}

		public virtual void AddMembers(ClassMap mapping)
		{
		}
	}
}
