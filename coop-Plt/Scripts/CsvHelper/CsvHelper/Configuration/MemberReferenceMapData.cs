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
				return prefix;
			}
			set
			{
				prefix = value;
				foreach (MemberMap memberMap in Mapping.MemberMaps)
				{
					memberMap.Data.Names.Prefix = value;
				}
			}
		}

		public virtual MemberInfo Member { get; private set; }

		public ClassMap Mapping { get; private set; }

		public MemberReferenceMapData(MemberInfo member, ClassMap mapping)
		{
			Member = member;
			Mapping = mapping;
		}
	}
}
