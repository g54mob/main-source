using System.Diagnostics;
using System.Reflection;
using CsvHelper.TypeConversion;

namespace CsvHelper.Configuration
{
	[DebuggerDisplay("Index = {Index}, Name = {Name}, Parameter = {Parameter}")]
	public class ParameterMapData
	{
		public virtual ParameterInfo Parameter { get; private set; }

		public virtual ITypeConverter TypeConverter { get; set; }

		public virtual TypeConverterOptions TypeConverterOptions { get; set; }

		public virtual int Index { get; set; }

		public virtual string Name { get; set; }

		public ParameterMapData(ParameterInfo parameter)
		{
		}
	}
}
