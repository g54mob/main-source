using System.Diagnostics;
using System.Reflection;

namespace CsvHelper.Configuration
{
	[DebuggerDisplay("Prefix = {Prefix}, Parameter = {Parameter}")]
	public class ParameterReferenceMapData
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

		public virtual ParameterInfo Parameter { get; private set; }

		public ClassMap Mapping { get; private set; }

		public ParameterReferenceMapData(ParameterInfo parameter, ClassMap mapping)
		{
		}
	}
}
