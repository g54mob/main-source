using System.Reflection;

namespace CsvHelper.Configuration
{
	public class ParameterReferenceMap
	{
		private readonly ParameterReferenceMapData data;

		public ParameterReferenceMapData Data => null;

		public ParameterReferenceMap(ParameterInfo parameter, ClassMap mapping)
		{
		}

		public ParameterReferenceMap Prefix(string prefix = null)
		{
			return null;
		}

		internal int GetMaxIndex()
		{
			return 0;
		}
	}
}
