using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using FluentAssertions.Common;
using FluentAssertions.Execution;

namespace FluentAssertions.Types
{
	[DebuggerNonUserCode]
	public class MethodInfoSelectorAssertions
	{
		private readonly AssertionChain assertionChain;

		public IEnumerable<MethodInfo> SubjectMethods { get; }

		protected string Context => "method";

		public MethodInfoSelectorAssertions(AssertionChain assertionChain, params MethodInfo[] methods)
		{
			this.assertionChain = assertionChain;
			Guard.ThrowIfArgumentIsNull(methods, "methods");
			SubjectMethods = methods;
		}

		public AndConstraint<MethodInfoSelectorAssertions> BeVirtual([StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			MethodInfo[] allNonVirtualMethodsFromSelection = GetAllNonVirtualMethodsFromSelection();
			string message = "Expected all selected methods to be virtual{reason}, but the following methods are not virtual:" + Environment.NewLine + GetDescriptionsFor(allNonVirtualMethodsFromSelection);
			assertionChain.ForCondition(allNonVirtualMethodsFromSelection.Length == 0).BecauseOf(because, becauseArgs).FailWith(message);
			return new AndConstraint<MethodInfoSelectorAssertions>(this);
		}

		public AndConstraint<MethodInfoSelectorAssertions> NotBeVirtual([StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			MethodInfo[] allVirtualMethodsFromSelection = GetAllVirtualMethodsFromSelection();
			string message = "Expected all selected methods not to be virtual{reason}, but the following methods are virtual:" + Environment.NewLine + GetDescriptionsFor(allVirtualMethodsFromSelection);
			assertionChain.ForCondition(allVirtualMethodsFromSelection.Length == 0).BecauseOf(because, becauseArgs).FailWith(message);
			return new AndConstraint<MethodInfoSelectorAssertions>(this);
		}

		private MethodInfo[] GetAllNonVirtualMethodsFromSelection()
		{
			return SubjectMethods.Where((MethodInfo method) => method.IsNonVirtual()).ToArray();
		}

		private MethodInfo[] GetAllVirtualMethodsFromSelection()
		{
			return SubjectMethods.Where((MethodInfo method) => !method.IsNonVirtual()).ToArray();
		}

		public AndConstraint<MethodInfoSelectorAssertions> BeAsync([StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			MethodInfo[] array = SubjectMethods.Where((MethodInfo method) => !method.IsAsync()).ToArray();
			string message = "Expected all selected methods to be async{reason}, but the following methods are not:" + Environment.NewLine + GetDescriptionsFor(array);
			assertionChain.ForCondition(array.Length == 0).BecauseOf(because, becauseArgs).FailWith(message);
			return new AndConstraint<MethodInfoSelectorAssertions>(this);
		}

		public AndConstraint<MethodInfoSelectorAssertions> NotBeAsync([StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			MethodInfo[] array = SubjectMethods.Where((MethodInfo method) => method.IsAsync()).ToArray();
			string message = "Expected all selected methods not to be async{reason}, but the following methods are:" + Environment.NewLine + GetDescriptionsFor(array);
			assertionChain.ForCondition(array.Length == 0).BecauseOf(because, becauseArgs).FailWith(message);
			return new AndConstraint<MethodInfoSelectorAssertions>(this);
		}

		public AndConstraint<MethodInfoSelectorAssertions> BeDecoratedWith<TAttribute>([StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs) where TAttribute : Attribute
		{
			return BeDecoratedWith((TAttribute _) => true, because, becauseArgs);
		}

		public AndConstraint<MethodInfoSelectorAssertions> BeDecoratedWith<TAttribute>(Expression<Func<TAttribute, bool>> isMatchingAttributePredicate, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs) where TAttribute : Attribute
		{
			Guard.ThrowIfArgumentIsNull(isMatchingAttributePredicate, "isMatchingAttributePredicate");
			MethodInfo[] methodsWithout = GetMethodsWithout(isMatchingAttributePredicate);
			string message = "Expected all selected methods to be decorated with {0}{reason}, but the following methods are not:" + Environment.NewLine + GetDescriptionsFor(methodsWithout);
			assertionChain.ForCondition(methodsWithout.Length == 0).BecauseOf(because, becauseArgs).FailWith(message, typeof(TAttribute));
			return new AndConstraint<MethodInfoSelectorAssertions>(this);
		}

		public AndConstraint<MethodInfoSelectorAssertions> NotBeDecoratedWith<TAttribute>([StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs) where TAttribute : Attribute
		{
			return NotBeDecoratedWith((TAttribute _) => true, because, becauseArgs);
		}

		public AndConstraint<MethodInfoSelectorAssertions> NotBeDecoratedWith<TAttribute>(Expression<Func<TAttribute, bool>> isMatchingAttributePredicate, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs) where TAttribute : Attribute
		{
			Guard.ThrowIfArgumentIsNull(isMatchingAttributePredicate, "isMatchingAttributePredicate");
			MethodInfo[] methodsWith = GetMethodsWith(isMatchingAttributePredicate);
			string message = "Expected all selected methods to not be decorated with {0}{reason}, but the following methods are:" + Environment.NewLine + GetDescriptionsFor(methodsWith);
			assertionChain.ForCondition(methodsWith.Length == 0).BecauseOf(because, becauseArgs).FailWith(message, typeof(TAttribute));
			return new AndConstraint<MethodInfoSelectorAssertions>(this);
		}

		public AndConstraint<MethodInfoSelectorAssertions> Be(CSharpAccessModifier accessModifier, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			MethodInfo[] array = SubjectMethods.Where((MethodInfo pi) => pi.GetCSharpAccessModifier() != accessModifier).ToArray();
			string message = $"Expected all selected methods to be {accessModifier}{{reason}}, but the following methods are not:" + Environment.NewLine + GetDescriptionsFor(array);
			assertionChain.ForCondition(array.Length == 0).BecauseOf(because, becauseArgs).FailWith(message);
			return new AndConstraint<MethodInfoSelectorAssertions>(this);
		}

		public AndConstraint<MethodInfoSelectorAssertions> NotBe(CSharpAccessModifier accessModifier, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			MethodInfo[] array = SubjectMethods.Where((MethodInfo pi) => pi.GetCSharpAccessModifier() == accessModifier).ToArray();
			string message = $"Expected all selected methods to not be {accessModifier}{{reason}}, but the following methods are:" + Environment.NewLine + GetDescriptionsFor(array);
			assertionChain.ForCondition(array.Length == 0).BecauseOf(because, becauseArgs).FailWith(message);
			return new AndConstraint<MethodInfoSelectorAssertions>(this);
		}

		private MethodInfo[] GetMethodsWithout<TAttribute>(Expression<Func<TAttribute, bool>> isMatchingPredicate) where TAttribute : Attribute
		{
			return SubjectMethods.Where((MethodInfo method) => !method.IsDecoratedWith(isMatchingPredicate)).ToArray();
		}

		private MethodInfo[] GetMethodsWith<TAttribute>(Expression<Func<TAttribute, bool>> isMatchingPredicate) where TAttribute : Attribute
		{
			return SubjectMethods.Where((MethodInfo method) => method.IsDecoratedWith(isMatchingPredicate)).ToArray();
		}

		private static string GetDescriptionsFor(IEnumerable<MethodInfo> methods)
		{
			IEnumerable<string> values = methods.Select((MethodInfo method) => MethodInfoAssertions.GetDescriptionFor(method));
			return string.Join(Environment.NewLine, values);
		}

		public override bool Equals(object obj)
		{
			throw new NotSupportedException("Equals is not part of Fluent Assertions. Did you mean Be() instead?");
		}
	}
}
