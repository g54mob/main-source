using System;
using System.Diagnostics;
using System.Reflection;
using CsvHelper.TypeConversion;

namespace CsvHelper.Configuration
{
	[DebuggerDisplay("Member = {Data.Member}, Names = {string.Join(\",\", Data.Names)}, Index = {Data.Index}, Ignore = {Data.Ignore}, Member = {Data.Member}, TypeConverter = {Data.TypeConverter}")]
	public abstract class MemberMap
	{
		public virtual MemberMapData Data { get; protected set; }

		public virtual MapTypeConverterOption TypeConverterOption { get; protected set; }

		public static MemberMap CreateGeneric(Type classType, MemberInfo member)
		{
			return null;
		}

		public virtual MemberMap Name(params string[] names)
		{
			return null;
		}

		public virtual MemberMap NameIndex(int index)
		{
			return null;
		}

		public virtual MemberMap Index(int index, int indexEnd = -1)
		{
			return null;
		}

		public virtual MemberMap Ignore()
		{
			return null;
		}

		public virtual MemberMap Ignore(bool ignore)
		{
			return null;
		}

		public virtual MemberMap Default(object defaultValue)
		{
			return null;
		}

		public virtual MemberMap Default(string defaultValue)
		{
			return null;
		}

		public virtual MemberMap Constant(object constantValue)
		{
			return null;
		}

		public virtual MemberMap TypeConverter(ITypeConverter typeConverter)
		{
			return null;
		}

		public virtual MemberMap TypeConverter<TConverter>() where TConverter : ITypeConverter
		{
			return null;
		}

		public virtual MemberMap Validate(Func<string, bool> validateExpression)
		{
			return null;
		}
	}
	public class MemberMap<TClass, TMember> : MemberMap
	{
		public MemberMap(MemberInfo member)
		{
		}

		public new virtual MemberMap<TClass, TMember> Name(params string[] names)
		{
			return null;
		}

		public new virtual MemberMap<TClass, TMember> NameIndex(int index)
		{
			return null;
		}

		public new virtual MemberMap<TClass, TMember> Index(int index, int indexEnd = -1)
		{
			return null;
		}

		public new virtual MemberMap<TClass, TMember> Ignore()
		{
			return null;
		}

		public new virtual MemberMap<TClass, TMember> Ignore(bool ignore)
		{
			return null;
		}

		public virtual MemberMap<TClass, TMember> Default(TMember defaultValue)
		{
			return null;
		}

		public new virtual MemberMap<TClass, TMember> Default(string defaultValue)
		{
			return null;
		}

		public virtual MemberMap<TClass, TMember> Constant(TMember constantValue)
		{
			return null;
		}

		public new virtual MemberMap<TClass, TMember> TypeConverter(ITypeConverter typeConverter)
		{
			return null;
		}

		public new virtual MemberMap<TClass, TMember> TypeConverter<TConverter>() where TConverter : ITypeConverter
		{
			return null;
		}

		public virtual MemberMap<TClass, TMember> ConvertUsing(Func<IReaderRow, TMember> convertExpression)
		{
			return null;
		}

		public virtual MemberMap<TClass, TMember> ConvertUsing(Func<TClass, string> convertExpression)
		{
			return null;
		}

		public virtual MemberMap<TClass, TMember> Optional()
		{
			return null;
		}

		public new virtual MemberMap<TClass, TMember> Validate(Func<string, bool> validateExpression)
		{
			return null;
		}
	}
}
