using System.Collections.Generic;

namespace IniParser.Model
{
	public class Section : IDeepCloneable<Section>
	{
		private List<string> _comments;

		private string _name;

		private readonly IEqualityComparer<string> _searchComparer;

		public string Name
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public List<string> Comments
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public PropertyCollection Properties { get; set; }

		public Section(string sectionName)
		{
		}

		public Section(string sectionName, IEqualityComparer<string> searchComparer)
		{
		}

		public Section(Section ori, IEqualityComparer<string> searchComparer = null)
		{
		}

		public void Clear()
		{
		}

		public void ClearComments()
		{
		}

		public void ClearProperties()
		{
		}

		public void Merge(Section toMergeSection)
		{
		}

		public Section DeepClone()
		{
			return null;
		}
	}
}
