using System;
using System.Diagnostics;
using System.Reflection;

namespace CsvHelper.Configuration
{
	[DebuggerDisplay("Member = {Data.Member}, Prefix = {Data.Prefix}")]
	public class MemberReferenceMap
	{
		private readonly MemberReferenceMapData data;

		public MemberReferenceMapData Data => data;

		public MemberReferenceMap(MemberInfo member, ClassMap mapping)
		{
			if (mapping == null)
			{
				throw new ArgumentNullException("mapping");
			}
			data = new MemberReferenceMapData(member, mapping);
		}

		public MemberReferenceMap Prefix(string prefix = null)
		{
			if (string.IsNullOrEmpty(prefix))
			{
				prefix = data.Member.Name + ".";
			}
			data.Prefix = prefix;
			return this;
		}

		internal int GetMaxIndex()
		{
			return data.Mapping.GetMaxIndex();
		}
	}
}
