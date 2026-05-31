using System.Diagnostics;
using System.Reflection;

namespace CsvHelper.Configuration
{
	[DebuggerDisplay("Member = {Data.Member}, Prefix = {Data.Prefix}")]
	public class MemberReferenceMap
	{
		private readonly MemberReferenceMapData data;

		public MemberReferenceMapData Data => null;

		public MemberReferenceMap(MemberInfo member, ClassMap mapping)
		{
		}

		public MemberReferenceMap Prefix(string prefix = null)
		{
			return null;
		}

		internal int GetMaxIndex()
		{
			return 0;
		}
	}
}
