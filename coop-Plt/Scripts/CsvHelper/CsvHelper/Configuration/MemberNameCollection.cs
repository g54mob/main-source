using System.Collections;
using System.Collections.Generic;

namespace CsvHelper.Configuration
{
	public class MemberNameCollection : IEnumerable<string>, IEnumerable
	{
		private readonly List<string> names = new List<string>();

		public string this[int index]
		{
			get
			{
				return Prefix + names[index];
			}
			set
			{
				names[index] = value;
			}
		}

		public string Prefix { get; set; }

		public List<string> Names => names;

		public int Count => names.Count;

		public void Add(string name)
		{
			names.Add(name);
		}

		public void Clear()
		{
			names.Clear();
		}

		public void AddRange(IEnumerable<string> names)
		{
			this.names.AddRange(names);
		}

		public IEnumerator<string> GetEnumerator()
		{
			for (int i = 0; i < names.Count; i++)
			{
				yield return this[i];
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return names.GetEnumerator();
		}
	}
}
