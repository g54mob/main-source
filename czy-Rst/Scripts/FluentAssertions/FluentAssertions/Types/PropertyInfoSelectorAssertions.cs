using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using FluentAssertions.Common;
using FluentAssertions.Execution;
using FluentAssertions.Formatting;

namespace FluentAssertions.Types
{
	[DebuggerNonUserCode]
	public class PropertyInfoSelectorAssertions
	{
		private readonly AssertionChain assertionChain;

		public IEnumerable<PropertyInfo> SubjectProperties { get; }

		protected string Context => "property info";

		public PropertyInfoSelectorAssertions(AssertionChain assertionChain, params PropertyInfo[] properties)
		{
			this.assertionChain = assertionChain;
			Guard.ThrowIfArgumentIsNull(properties, "properties");
			SubjectProperties = properties;
		}

		public AndConstraint<PropertyInfoSelectorAssertions> BeVirtual([StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			PropertyInfo[] allNonVirtualPropertiesFromSelection = GetAllNonVirtualPropertiesFromSelection();
			assertionChain.ForCondition(allNonVirtualPropertiesFromSelection.Length == 0).BecauseOf(because, becauseArgs).FailWith("Expected all selected properties to be virtual{reason}, but the following properties are not virtual:" + Environment.NewLine + GetDescriptionsFor(allNonVirtualPropertiesFromSelection));
			return new AndConstraint<PropertyInfoSelectorAssertions>(this);
		}

		public AndConstraint<PropertyInfoSelectorAssertions> NotBeVirtual([StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			PropertyInfo[] allVirtualPropertiesFromSelection = GetAllVirtualPropertiesFromSelection();
			assertionChain.ForCondition(allVirtualPropertiesFromSelection.Length == 0).BecauseOf(because, becauseArgs).FailWith("Expected all selected properties not to be virtual{reason}, but the following properties are virtual:" + Environment.NewLine + GetDescriptionsFor(allVirtualPropertiesFromSelection));
			return new AndConstraint<PropertyInfoSelectorAssertions>(this);
		}

		public AndConstraint<PropertyInfoSelectorAssertions> BeWritable([StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			PropertyInfo[] allReadOnlyPropertiesFromSelection = GetAllReadOnlyPropertiesFromSelection();
			assertionChain.ForCondition(allReadOnlyPropertiesFromSelection.Length == 0).BecauseOf(because, becauseArgs).FailWith("Expected all selected properties to have a setter{reason}, but the following properties do not:" + Environment.NewLine + GetDescriptionsFor(allReadOnlyPropertiesFromSelection));
			return new AndConstraint<PropertyInfoSelectorAssertions>(this);
		}

		public AndConstraint<PropertyInfoSelectorAssertions> NotBeWritable([StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			PropertyInfo[] allWritablePropertiesFromSelection = GetAllWritablePropertiesFromSelection();
			assertionChain.ForCondition(allWritablePropertiesFromSelection.Length == 0).BecauseOf(because, becauseArgs).FailWith("Expected selected properties to not have a setter{reason}, but the following properties do:" + Environment.NewLine + GetDescriptionsFor(allWritablePropertiesFromSelection));
			return new AndConstraint<PropertyInfoSelectorAssertions>(this);
		}

		private PropertyInfo[] GetAllReadOnlyPropertiesFromSelection()
		{
			return SubjectProperties.Where((PropertyInfo property) => !property.CanWrite).ToArray();
		}

		private PropertyInfo[] GetAllWritablePropertiesFromSelection()
		{
			return SubjectProperties.Where((PropertyInfo property) => property.CanWrite).ToArray();
		}

		private PropertyInfo[] GetAllNonVirtualPropertiesFromSelection()
		{
			return SubjectProperties.Where((PropertyInfo property) => !property.IsVirtual()).ToArray();
		}

		private PropertyInfo[] GetAllVirtualPropertiesFromSelection()
		{
			return SubjectProperties.Where((PropertyInfo property) => property.IsVirtual()).ToArray();
		}

		public AndConstraint<PropertyInfoSelectorAssertions> BeDecoratedWith<TAttribute>([StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs) where TAttribute : Attribute
		{
			PropertyInfo[] propertiesWithout = GetPropertiesWithout<TAttribute>();
			assertionChain.ForCondition(propertiesWithout.Length == 0).BecauseOf(because, becauseArgs).FailWith("Expected all selected properties to be decorated with {0}{reason}, but the following properties are not:" + Environment.NewLine + GetDescriptionsFor(propertiesWithout), typeof(TAttribute));
			return new AndConstraint<PropertyInfoSelectorAssertions>(this);
		}

		public AndConstraint<PropertyInfoSelectorAssertions> NotBeDecoratedWith<TAttribute>([StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs) where TAttribute : Attribute
		{
			PropertyInfo[] propertiesWith = GetPropertiesWith<TAttribute>();
			assertionChain.ForCondition(propertiesWith.Length == 0).BecauseOf(because, becauseArgs).FailWith("Expected all selected properties not to be decorated with {0}{reason}, but the following properties are:" + Environment.NewLine + GetDescriptionsFor(propertiesWith), typeof(TAttribute));
			return new AndConstraint<PropertyInfoSelectorAssertions>(this);
		}

		private PropertyInfo[] GetPropertiesWithout<TAttribute>() where TAttribute : Attribute
		{
			return SubjectProperties.Where((PropertyInfo property) => !property.IsDecoratedWith<TAttribute>()).ToArray();
		}

		private PropertyInfo[] GetPropertiesWith<TAttribute>() where TAttribute : Attribute
		{
			return SubjectProperties.Where((PropertyInfo property) => property.IsDecoratedWith<TAttribute>()).ToArray();
		}

		private static string GetDescriptionsFor(IEnumerable<PropertyInfo> properties)
		{
			IEnumerable<string> values = properties.Select((PropertyInfo property) => Formatter.ToString(property));
			return string.Join(Environment.NewLine, values);
		}

		public override bool Equals(object obj)
		{
			throw new NotSupportedException("Equals is not part of Fluent Assertions. Did you mean Be() instead?");
		}
	}
}
