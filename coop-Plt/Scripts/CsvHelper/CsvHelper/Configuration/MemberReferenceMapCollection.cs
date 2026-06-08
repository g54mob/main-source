using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace CsvHelper.Configuration
{
	[DebuggerDisplay("Count = {list.Count}")]
	public class MemberReferenceMapCollection : IList<MemberReferenceMap>, ICollection<MemberReferenceMap>, IEnumerable<MemberReferenceMap>, IEnumerable
	{
		private readonly List<MemberReferenceMap> list = new List<MemberReferenceMap>();

		public virtual int Count => list.Count;

		public virtual bool IsReadOnly => false;

		public virtual MemberReferenceMap this[int index]
		{
			get
			{
				return list[index];
			}
			set
			{
				list[index] = value;
			}
		}

		public virtual IEnumerator<MemberReferenceMap> GetEnumerator()
		{
			return list.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public virtual void Add(MemberReferenceMap item)
		{
			list.Add(item);
		}

		public virtual void Clear()
		{
			list.Clear();
		}

		public virtual bool Contains(MemberReferenceMap item)
		{
			return list.Contains(item);
		}

		public virtual void CopyTo(MemberReferenceMap[] array, int arrayIndex)
		{
			list.CopyTo(array, arrayIndex);
		}

		public virtual bool Remove(MemberReferenceMap item)
		{
			return list.Remove(item);
		}

		public virtual int IndexOf(MemberReferenceMap item)
		{
			return list.IndexOf(item);
		}

		public virtual void Insert(int index, MemberReferenceMap item)
		{
			list.Insert(index, item);
		}

		public virtual void RemoveAt(int index)
		{
			list.RemoveAt(index);
		}

		public virtual MemberReferenceMap Find<T>(Expression<Func<T, object>> expression)
		{
			MemberInfo member = ReflectionHelper.GetMember(expression);
			return Find(member);
		}

		public virtual MemberReferenceMap Find(MemberInfo member)
		{
			return list.SingleOrDefault((MemberReferenceMap m) => m.Data.Member == member || (m.Data.Member.Name == member.Name && (m.Data.Member.DeclaringType.IsAssignableFrom(member.DeclaringType) || member.DeclaringType.IsAssignableFrom(m.Data.Member.DeclaringType))));
		}
	}
}
