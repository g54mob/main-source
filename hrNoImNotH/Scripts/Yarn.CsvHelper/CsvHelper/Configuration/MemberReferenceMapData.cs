using System.Reflection;

namespace CsvHelper.Configuration
{
	public class MemberReferenceMapData
	{
		private string prefix;

		public virtual string Prefix
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public virtual MemberInfo Member { get; private set; }

		public ClassMap Mapping { get; private set; }

		public MemberReferenceMapData(MemberInfo member, ClassMap mapping)
		{
		}
	}
}
