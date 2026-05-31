using System.Linq.Expressions;
using System.Reflection;
using CsvHelper.TypeConversion;

namespace CsvHelper.Configuration
{
	public class MemberMapData
	{
		public virtual MemberInfo Member { get; private set; }

		public virtual MemberNameCollection Names { get; }

		public virtual int NameIndex { get; set; }

		public virtual bool IsNameSet { get; set; }

		public virtual int Index { get; set; }

		public virtual int IndexEnd { get; set; }

		public virtual bool IsIndexSet { get; set; }

		public virtual ITypeConverter TypeConverter { get; set; }

		public virtual TypeConverterOptions TypeConverterOptions { get; set; }

		public virtual bool Ignore { get; set; }

		public virtual object Default { get; set; }

		public virtual bool IsDefaultSet { get; set; }

		public virtual object Constant { get; set; }

		public virtual bool IsConstantSet { get; set; }

		public virtual Expression ReadingConvertExpression { get; set; }

		public virtual Expression WritingConvertExpression { get; set; }

		public virtual Expression ValidateExpression { get; set; }

		public virtual bool IsOptional { get; set; }

		public MemberMapData(MemberInfo member)
		{
		}
	}
}
