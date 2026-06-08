using System;
using System.Diagnostics;
using System.Reflection;
using CsvHelper.TypeConversion;

namespace CsvHelper.Configuration
{
	[DebuggerDisplay("Data = {Data}")]
	public class ParameterMap
	{
		public virtual ParameterMapData Data { get; protected set; }

		public virtual ParameterMapTypeConverterOption TypeConverterOption { get; protected set; }

		public virtual ClassMap ConstructorTypeMap { get; set; }

		public virtual ParameterReferenceMap ReferenceMap { get; set; }

		public ParameterMap(ParameterInfo parameter)
		{
			TypeConverterOption = new ParameterMapTypeConverterOption(this);
			Data = new ParameterMapData(parameter);
		}

		public virtual ParameterMap Name(params string[] names)
		{
			if (names == null || names.Length == 0)
			{
				throw new ArgumentNullException("names");
			}
			Data.Names.Clear();
			Data.Names.AddRange(names);
			Data.IsNameSet = true;
			return this;
		}

		public virtual ParameterMap NameIndex(int index)
		{
			Data.NameIndex = index;
			return this;
		}

		public virtual ParameterMap Index(int index)
		{
			Data.Index = index;
			Data.IsIndexSet = true;
			return this;
		}

		public virtual ParameterMap Ignore()
		{
			Data.Ignore = true;
			return this;
		}

		public virtual ParameterMap Ignore(bool ignore)
		{
			Data.Ignore = ignore;
			return this;
		}

		public virtual ParameterMap Default(object defaultValue)
		{
			if (defaultValue == null && Data.Parameter.ParameterType.IsValueType)
			{
				throw new ArgumentException("Parameter of type '" + Data.Parameter.ParameterType.FullName + "' can't have a default value of null.");
			}
			if (defaultValue != null && defaultValue.GetType() != Data.Parameter.ParameterType)
			{
				throw new ArgumentException("Default of type '" + defaultValue.GetType().FullName + "' does not match parameter of type '" + Data.Parameter.ParameterType.FullName + "'.");
			}
			Data.Default = defaultValue;
			Data.IsDefaultSet = true;
			return this;
		}

		public virtual ParameterMap Constant(object constantValue)
		{
			if (constantValue == null && Data.Parameter.ParameterType.IsValueType)
			{
				throw new ArgumentException("Parameter of type '" + Data.Parameter.ParameterType.FullName + "' can't have a constant value of null.");
			}
			if (constantValue != null && constantValue.GetType() != Data.Parameter.ParameterType)
			{
				throw new ArgumentException("Constant of type '" + constantValue.GetType().FullName + "' does not match parameter of type '" + Data.Parameter.ParameterType.FullName + "'.");
			}
			Data.Constant = constantValue;
			Data.IsConstantSet = true;
			return this;
		}

		public virtual ParameterMap Optional()
		{
			Data.IsOptional = true;
			return this;
		}

		public virtual ParameterMap TypeConverter(ITypeConverter typeConverter)
		{
			Data.TypeConverter = typeConverter;
			return this;
		}

		public virtual ParameterMap TypeConverter<TConverter>() where TConverter : ITypeConverter
		{
			TypeConverter(ObjectResolver.Current.Resolve<TConverter>(new object[0]));
			return this;
		}

		internal int GetMaxIndex()
		{
			return ReferenceMap?.GetMaxIndex() ?? Data.Index;
		}
	}
}
