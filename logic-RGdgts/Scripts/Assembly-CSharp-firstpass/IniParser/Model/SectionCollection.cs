using System.Collections;
using System.Collections.Generic;

namespace IniParser.Model
{
	public class SectionCollection : IDeepCloneable<SectionCollection>, IEnumerable<Section>, IEnumerable
	{
		private readonly Dictionary<string, Section> _sections;

		private readonly IEqualityComparer<string> _searchComparer;

		public int Count => 0;

		public PropertyCollection Item => null;

		public SectionCollection()
		{
		}

		public SectionCollection(IEqualityComparer<string> searchComparer)
		{
		}

		public SectionCollection(SectionCollection ori, IEqualityComparer<string> searchComparer)
		{
		}

		public bool Add(string sectionName)
		{
			return false;
		}

		public void Add(Section data)
		{
		}

		public void Clear()
		{
		}

		public bool Contains(string sectionName)
		{
			return false;
		}

		public Section FindByName(string sectionName)
		{
			return null;
		}

		public void Merge(SectionCollection sectionsToMerge)
		{
		}

		public bool Remove(string sectionName)
		{
			return false;
		}

		public IEnumerator<Section> GetEnumerator()
		{
			return null;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return null;
		}

		public SectionCollection DeepClone()
		{
			return null;
		}
	}
}
