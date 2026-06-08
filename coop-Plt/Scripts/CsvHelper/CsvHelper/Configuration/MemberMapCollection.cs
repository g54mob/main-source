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
	public class MemberMapCollection : IList<MemberMap>, ICollection<MemberMap>, IEnumerable<MemberMap>, IEnumerable
	{
		private readonly List<MemberMap> list = new List<MemberMap>();

		private readonly IComparer<MemberMap> comparer;

		public virtual int Count => list.Count;

		public virtual bool IsReadOnly => false;

		public virtual MemberMap this[int index]
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

		public MemberMapCollection()
			: this(new MemberMapComparer())
		{
		}

		public MemberMapCollection(IComparer<MemberMap> comparer)
		{
			this.comparer = comparer;
		}

		public virtual IEnumerator<MemberMap> GetEnumerator()
		{
			return list.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public virtual void Add(MemberMap item)
		{
			list.Add(item);
			list.Sort(comparer);
		}

		public virtual void AddRange(ICollection<MemberMap> collection)
		{
			list.AddRange(collection);
			list.Sort(comparer);
		}

		public virtual void Clear()
		{
			list.Clear();
		}

		public virtual bool Contains(MemberMap item)
		{
			return list.Contains(item);
		}

		public virtual void CopyTo(MemberMap[] array, int arrayIndex)
		{
			list.CopyTo(array, arrayIndex);
		}

		public virtual bool Remove(MemberMap item)
		{
			return list.Remove(item);
		}

		public virtual int IndexOf(MemberMap item)
		{
			return list.IndexOf(item);
		}

		public virtual void Insert(int index, MemberMap item)
		{
			list.Insert(index, item);
		}

		public virtual void RemoveAt(int index)
		{
			list.RemoveAt(index);
		}

		public virtual MemberMap Find<T>(Expression<Func<T, object>> expression)
		{
			MemberInfo member = ReflectionHelper.GetMember(expression);
			return Find(member);
		}

		public virtual MemberMap Find(MemberInfo member)
		{
			return list.SingleOrDefault((MemberMap m) => m.Data.Member == member || (m.Data.Member != null && m.Data.Member.Name == member.Name && (m.Data.Member.DeclaringType.IsAssignableFrom(member.DeclaringType) || member.DeclaringType.IsAssignableFrom(m.Data.Member.DeclaringType))));
		}

		public virtual void AddMembers(ClassMap mapping)
		{
			AddRange(mapping.MemberMaps);
			foreach (MemberReferenceMap referenceMap in mapping.ReferenceMaps)
			{
				AddMembers(referenceMap.Data.Mapping);
			}
		}
	}
}
