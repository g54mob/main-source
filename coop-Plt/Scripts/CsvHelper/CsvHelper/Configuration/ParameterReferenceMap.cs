using System;
using System.Reflection;

namespace CsvHelper.Configuration
{
	public class ParameterReferenceMap
	{
		private readonly ParameterReferenceMapData data;

		public ParameterReferenceMapData Data => data;

		public ParameterReferenceMap(ParameterInfo parameter, ClassMap mapping)
		{
			if (mapping == null)
			{
				throw new ArgumentNullException("mapping");
			}
			data = new ParameterReferenceMapData(parameter, mapping);
		}

		public ParameterReferenceMap Prefix(string prefix = null)
		{
			if (string.IsNullOrEmpty(prefix))
			{
				prefix = data.Parameter.Name + ".";
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
