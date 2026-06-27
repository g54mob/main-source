using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using FluentAssertions.Common;
using FluentAssertions.Execution;

namespace FluentAssertions.Types
{
	[DebuggerNonUserCode]
	public class TypeSelectorAssertions
	{
		private readonly AssertionChain assertionChain;

		public IEnumerable<Type> Subject { get; }

		public TypeSelectorAssertions(AssertionChain assertionChain, params Type[] types)
		{
			this.assertionChain = assertionChain;
			Guard.ThrowIfArgumentIsNull(types, "types");
			Guard.ThrowIfArgumentContainsNull(types, "types");
			Subject = types;
		}

		public AndConstraint<TypeSelectorAssertions> BeDecoratedWith<TAttribute>([StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs) where TAttribute : Attribute
		{
			Type[] array = Subject.Where((Type type) => !type.IsDecoratedWith<TAttribute>()).ToArray();
			assertionChain.ForCondition(array.Length == 0).BecauseOf(because, becauseArgs).FailWith("Expected all types to be decorated with {0}{reason}, but the attribute was not found on the following types:" + Environment.NewLine + "{1}.", typeof(TAttribute), GetDescriptionsFor(array));
			return new AndConstraint<TypeSelectorAssertions>(this);
		}

		public AndConstraint<TypeSelectorAssertions> BeDecoratedWith<TAttribute>(Expression<Func<TAttribute, bool>> isMatchingAttributePredicate, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs) where TAttribute : Attribute
		{
			Guard.ThrowIfArgumentIsNull(isMatchingAttributePredicate, "isMatchingAttributePredicate");
			Type[] array = Subject.Where((Type type) => !type.IsDecoratedWith(isMatchingAttributePredicate)).ToArray();
			assertionChain.ForCondition(array.Length == 0).BecauseOf(because, becauseArgs).FailWith("Expected all types to be decorated with {0} that matches {1}{reason}, but no matching attribute was found on the following types:" + Environment.NewLine + "{2}.", typeof(TAttribute), isMatchingAttributePredicate, GetDescriptionsFor(array));
			return new AndConstraint<TypeSelectorAssertions>(this);
		}

		public AndConstraint<TypeSelectorAssertions> BeDecoratedWithOrInherit<TAttribute>([StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs) where TAttribute : Attribute
		{
			Type[] array = Subject.Where((Type type) => !type.IsDecoratedWithOrInherit<TAttribute>()).ToArray();
			assertionChain.ForCondition(array.Length == 0).BecauseOf(because, becauseArgs).FailWith("Expected all types to be decorated with or inherit {0}{reason}, but the attribute was not found on the following types:" + Environment.NewLine + "{1}.", typeof(TAttribute), GetDescriptionsFor(array));
			return new AndConstraint<TypeSelectorAssertions>(this);
		}

		public AndConstraint<TypeSelectorAssertions> BeDecoratedWithOrInherit<TAttribute>(Expression<Func<TAttribute, bool>> isMatchingAttributePredicate, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs) where TAttribute : Attribute
		{
			Guard.ThrowIfArgumentIsNull(isMatchingAttributePredicate, "isMatchingAttributePredicate");
			Type[] array = Subject.Where((Type type) => !type.IsDecoratedWithOrInherit(isMatchingAttributePredicate)).ToArray();
			assertionChain.ForCondition(array.Length == 0).BecauseOf(because, becauseArgs).FailWith("Expected all types to be decorated with or inherit {0} that matches {1}{reason}, but no matching attribute was found on the following types:" + Environment.NewLine + "{2}.", typeof(TAttribute), isMatchingAttributePredicate, GetDescriptionsFor(array));
			return new AndConstraint<TypeSelectorAssertions>(this);
		}

		public AndConstraint<TypeSelectorAssertions> NotBeDecoratedWith<TAttribute>([StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs) where TAttribute : Attribute
		{
			Type[] array = Subject.Where((Type type) => type.IsDecoratedWith<TAttribute>()).ToArray();
			assertionChain.ForCondition(array.Length == 0).BecauseOf(because, becauseArgs).FailWith("Expected all types to not be decorated with {0}{reason}, but the attribute was found on the following types:" + Environment.NewLine + "{1}.", typeof(TAttribute), GetDescriptionsFor(array));
			return new AndConstraint<TypeSelectorAssertions>(this);
		}

		public AndConstraint<TypeSelectorAssertions> NotBeDecoratedWith<TAttribute>(Expression<Func<TAttribute, bool>> isMatchingAttributePredicate, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs) where TAttribute : Attribute
		{
			Guard.ThrowIfArgumentIsNull(isMatchingAttributePredicate, "isMatchingAttributePredicate");
			Type[] array = Subject.Where((Type type) => type.IsDecoratedWith(isMatchingAttributePredicate)).ToArray();
			assertionChain.ForCondition(array.Length == 0).BecauseOf(because, becauseArgs).FailWith("Expected all types to not be decorated with {0} that matches {1}{reason}, but a matching attribute was found on the following types:" + Environment.NewLine + "{2}.", typeof(TAttribute), isMatchingAttributePredicate, GetDescriptionsFor(array));
			return new AndConstraint<TypeSelectorAssertions>(this);
		}

		public AndConstraint<TypeSelectorAssertions> NotBeDecoratedWithOrInherit<TAttribute>([StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs) where TAttribute : Attribute
		{
			Type[] array = Subject.Where((Type type) => type.IsDecoratedWithOrInherit<TAttribute>()).ToArray();
			assertionChain.ForCondition(array.Length == 0).BecauseOf(because, becauseArgs).FailWith("Expected all types to not be decorated with or inherit {0}{reason}, but the attribute was found on the following types:" + Environment.NewLine + "{1}.", typeof(TAttribute), GetDescriptionsFor(array));
			return new AndConstraint<TypeSelectorAssertions>(this);
		}

		public AndConstraint<TypeSelectorAssertions> NotBeDecoratedWithOrInherit<TAttribute>(Expression<Func<TAttribute, bool>> isMatchingAttributePredicate, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs) where TAttribute : Attribute
		{
			Guard.ThrowIfArgumentIsNull(isMatchingAttributePredicate, "isMatchingAttributePredicate");
			Type[] array = Subject.Where((Type type) => type.IsDecoratedWithOrInherit(isMatchingAttributePredicate)).ToArray();
			assertionChain.ForCondition(array.Length == 0).BecauseOf(because, becauseArgs).FailWith("Expected all types to not be decorated with or inherit {0} that matches {1}{reason}, but a matching attribute was found on the following types:" + Environment.NewLine + "{2}.", typeof(TAttribute), isMatchingAttributePredicate, GetDescriptionsFor(array));
			return new AndConstraint<TypeSelectorAssertions>(this);
		}

		public AndConstraint<TypeSelectorAssertions> BeSealed([StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Type[] array = Subject.Where((Type type) => !type.IsCSharpSealed()).ToArray();
			assertionChain.ForCondition(array.Length == 0).BecauseOf(because, becauseArgs).FailWith("Expected all types to be sealed{reason}, but the following types are not:" + Environment.NewLine + "{0}.", GetDescriptionsFor(array));
			return new AndConstraint<TypeSelectorAssertions>(this);
		}

		public AndConstraint<TypeSelectorAssertions> NotBeSealed([StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Type[] array = Subject.Where((Type type) => type.IsCSharpSealed()).ToArray();
			assertionChain.ForCondition(array.Length == 0).BecauseOf(because, becauseArgs).FailWith("Expected all types not to be sealed{reason}, but the following types are:" + Environment.NewLine + "{0}.", GetDescriptionsFor(array));
			return new AndConstraint<TypeSelectorAssertions>(this);
		}

		public AndConstraint<TypeSelectorAssertions> BeInNamespace(string @namespace, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Type[] array = Subject.Where((Type t) => t.Namespace != @namespace).ToArray();
			assertionChain.ForCondition(array.Length == 0).BecauseOf(because, becauseArgs).FailWith("Expected all types to be in namespace {0}{reason}, but the following types are in a different namespace:" + Environment.NewLine + "{1}.", @namespace, GetDescriptionsFor(array));
			return new AndConstraint<TypeSelectorAssertions>(this);
		}

		public AndConstraint<TypeSelectorAssertions> NotBeInNamespace(string @namespace, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Type[] array = Subject.Where((Type t) => t.Namespace == @namespace).ToArray();
			assertionChain.ForCondition(array.Length == 0).BecauseOf(because, becauseArgs).FailWith("Expected no types to be in namespace {0}{reason}, but the following types are in the namespace:" + Environment.NewLine + "{1}.", @namespace, GetDescriptionsFor(array));
			return new AndConstraint<TypeSelectorAssertions>(this);
		}

		public AndConstraint<TypeSelectorAssertions> BeUnderNamespace(string @namespace, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Type[] array = Subject.Where((Type t) => !t.IsUnderNamespace(@namespace)).ToArray();
			assertionChain.ForCondition(array.Length == 0).BecauseOf(because, becauseArgs).FailWith("Expected the namespaces of all types to start with {0}{reason}, but the namespaces of the following types do not start with it:" + Environment.NewLine + "{1}.", @namespace, GetDescriptionsFor(array));
			return new AndConstraint<TypeSelectorAssertions>(this);
		}

		public AndConstraint<TypeSelectorAssertions> NotBeUnderNamespace(string @namespace, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Type[] array = Subject.Where((Type t) => t.IsUnderNamespace(@namespace)).ToArray();
			assertionChain.ForCondition(array.Length == 0).BecauseOf(because, becauseArgs).FailWith("Expected the namespaces of all types to not start with {0}{reason}, but the namespaces of the following types start with it:" + Environment.NewLine + "{1}.", @namespace, GetDescriptionsFor(array));
			return new AndConstraint<TypeSelectorAssertions>(this);
		}

		private static string GetDescriptionsFor(IEnumerable<Type> types)
		{
			IEnumerable<string> values = types.Select((Type type) => GetDescriptionFor(type));
			return string.Join(Environment.NewLine, values);
		}

		private static string GetDescriptionFor(Type type)
		{
			return type.ToString();
		}

		public override bool Equals(object obj)
		{
			throw new NotSupportedException("Equals is not part of Fluent Assertions. Did you mean BeInNamespace() or BeDecoratedWith() instead?");
		}
	}
}
