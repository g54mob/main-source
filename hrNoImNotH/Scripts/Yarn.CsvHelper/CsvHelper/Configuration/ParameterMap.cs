using System.Diagnostics;
using System.Reflection;

namespace CsvHelper.Configuration
{
	[DebuggerDisplay("Data = {Data}")]
	public class ParameterMap
	{
		public virtual ParameterMapData Data { get; protected set; }

		public virtual ClassMap ConstructorTypeMap { get; set; }

		public virtual ParameterReferenceMap ReferenceMap { get; set; }

		public ParameterMap(ParameterInfo parameter)
		{
		}

		internal int GetMaxIndex()
		{
			return 0;
		}
	}
}
