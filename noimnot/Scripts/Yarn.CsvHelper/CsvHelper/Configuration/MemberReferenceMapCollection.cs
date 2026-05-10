using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Reflection;

namespace CsvHelper.Configuration
{
	[DebuggerDisplay("Count = {list.Count}")]
	public class MemberReferenceMapCollection : IList<MemberReferenceMap>, ICollection<MemberReferenceMap>, IEnumerable<MemberReferenceMap>, IEnumerable
	{
		private readonly List<MemberReferenceMap> list;

		public virtual int Count => 0;

		public virtual bool IsReadOnly => false;

		public virtual MemberReferenceMap this[int index]
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public virtual IEnumerator<MemberReferenceMap> GetEnumerator()
		{
			return null;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return null;
		}

		public virtual void Add(MemberReferenceMap item)
		{
		}

		public virtual void Clear()
		{
		}

		public virtual bool Contains(MemberReferenceMap item)
		{
			return false;
		}

		public virtual void CopyTo(MemberReferenceMap[] array, int arrayIndex)
		{
		}

		public virtual bool Remove(MemberReferenceMap item)
		{
			return false;
		}

		public virtual int IndexOf(MemberReferenceMap item)
		{
			return 0;
		}

		public virtual void Insert(int index, MemberReferenceMap item)
		{
		}

		public virtual void RemoveAt(int index)
		{
		}

		public virtual MemberReferenceMap Find<T>(Expression<Func<T, object>> expression)
		{
			return null;
		}

		public virtual MemberReferenceMap Find(MemberInfo member)
		{
			return null;
		}
	}
}
