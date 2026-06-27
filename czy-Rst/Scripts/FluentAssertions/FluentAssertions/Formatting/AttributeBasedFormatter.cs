using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using FluentAssertions.Common;
using FluentAssertions.Configuration;

namespace FluentAssertions.Formatting
{
	public class AttributeBasedFormatter : IValueFormatter
	{
		private Dictionary<Type, MethodInfo> formatters;

		private ValueFormatterDetectionMode detectionMode;

		private static bool IsScanningEnabled => AssertionConfiguration.Current.Formatting.ValueFormatterDetectionMode == ValueFormatterDetectionMode.Scan;

		private Dictionary<Type, MethodInfo> Formatters
		{
			get
			{
				HandleValueFormatterDetectionModeChanges();
				return formatters ?? (formatters = FindCustomFormatters());
			}
		}

		public bool CanHandle(object value)
		{
			if (IsScanningEnabled && value != null)
			{
				return (object)GetFormatter(value) != null;
			}
			return false;
		}

		public void Format(object value, FormattedObjectGraph formattedGraph, FormattingContext context, FormatChild formatChild)
		{
			MethodInfo formatter = GetFormatter(value);
			object[] parameters = new object[2] { value, formattedGraph };
			formatter.Invoke(null, parameters);
		}

		private MethodInfo GetFormatter(object value)
		{
			Type type = value.GetType();
			do
			{
				if (Formatters.TryGetValue(type, out var value2))
				{
					return value2;
				}
				type = type.BaseType;
			}
			while ((object)type != null);
			return null;
		}

		private void HandleValueFormatterDetectionModeChanges()
		{
			ValueFormatterDetectionMode valueFormatterDetectionMode = AssertionEngine.Configuration.Formatting.ValueFormatterDetectionMode;
			if (detectionMode != valueFormatterDetectionMode)
			{
				detectionMode = valueFormatterDetectionMode;
				formatters = null;
			}
		}

		private static Dictionary<Type, MethodInfo> FindCustomFormatters()
		{
			return (from type in TypeReflector.GetAllTypesFromAppDomain(Applicable)
				where (object)type != null
				from method in type.GetMethods(BindingFlags.Static | BindingFlags.Public)
				where method.IsStatic
				where method.ReturnType == typeof(void)
				where method.IsDecoratedWithOrInherit<ValueFormatterAttribute>()
				let methodParameters = method.GetParameters()
				where methodParameters.Length == 2
				select new
				{
					Type = methodParameters[0].ParameterType,
					Method = method
				} into formatter
				group formatter by formatter.Type into formatterGroup
				select formatterGroup.First()).ToDictionary(f => f.Type, f => f.Method);
		}

		private static bool Applicable(Assembly assembly)
		{
			GlobalFormattingOptions formatting = AssertionEngine.Configuration.Formatting;
			return formatting.ValueFormatterDetectionMode switch
			{
				ValueFormatterDetectionMode.Specific => assembly.FullName.Split(new char[1] { ',' })[0].Equals(formatting.ValueFormatterAssembly, StringComparison.OrdinalIgnoreCase), 
				ValueFormatterDetectionMode.Scan => true, 
				_ => false, 
			};
		}
	}
}
