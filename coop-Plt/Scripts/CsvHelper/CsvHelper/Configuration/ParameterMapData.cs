using System.Diagnostics;
using System.Reflection;
using CsvHelper.TypeConversion;

namespace CsvHelper.Configuration
{
	[DebuggerDisplay("Index = {Index}, Names = {string.Join(\", \", Names)}, Parameter = {Parameter}")]
	public class ParameterMapData
	{
		public virtual ParameterInfo Parameter { get; private set; }

		public virtual MemberNameCollection Names { get; } = new MemberNameCollection();

		public virtual int NameIndex { get; set; }

		public virtual bool IsNameSet { get; set; }

		public virtual int Index { get; set; } = -1;

		public virtual bool IsIndexSet { get; set; }

		public virtual ITypeConverter TypeConverter { get; set; }

		public virtual TypeConverterOptions TypeConverterOptions { get; set; } = new TypeConverterOptions();

		public virtual bool Ignore { get; set; }

		public virtual object Default { get; set; }

		public virtual bool IsDefaultSet { get; set; }

		public virtual object Constant { get; set; }

		public virtual bool IsConstantSet { get; set; }

		public virtual bool IsOptional { get; set; }

		public ParameterMapData(ParameterInfo parameter)
		{
			Parameter = parameter;
		}
	}
}
