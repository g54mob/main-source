using IniParser.Configuration;
using IniParser.Model;

namespace IniParser
{
	public class IniData : IDeepCloneable<IniData>
	{
		private IniParserConfiguration _configuration;

		protected IniScheme _scheme;

		public bool CreateSectionsIfTheyDontExist { get; set; }

		public IniParserConfiguration Configuration
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public IniScheme Scheme
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public PropertyCollection Global { get; protected set; }

		public PropertyCollection Item => null;

		public SectionCollection Sections { get; set; }

		public IniData()
		{
		}

		public IniData(IniScheme scheme)
		{
		}

		public IniData(IniData ori)
		{
		}

		public void Clear()
		{
		}

		public void ClearAllComments()
		{
		}

		public void Merge(IniData toMergeIniData)
		{
		}

		public IniData DeepClone()
		{
			return null;
		}
	}
}
