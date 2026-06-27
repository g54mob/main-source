using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using FluentAssertions.Common;
using FluentAssertions.Execution;
using FluentAssertions.Primitives;

namespace FluentAssertions.Types
{
	[DebuggerNonUserCode]
	public class TypeAssertions : ReferenceTypeAssertions<Type, TypeAssertions>
	{
		private readonly AssertionChain assertionChain;

		protected override string Identifier => "type";

		public TypeAssertions(Type type, AssertionChain assertionChain)
			: base(type, assertionChain)
		{
			this.assertionChain = assertionChain;
		}

		public AndConstraint<TypeAssertions> Be<TExpected>([StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			return Be(typeof(TExpected), because, becauseArgs);
		}

		public AndConstraint<TypeAssertions> Be(Type expected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.BecauseOf(because, becauseArgs).ForCondition(base.Subject == expected).FailWith(GetFailureMessageIfTypesAreDifferent(base.Subject, expected));
			return new AndConstraint<TypeAssertions>(this);
		}

		public new AndConstraint<TypeAssertions> BeAssignableTo<T>([StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			return BeAssignableTo(typeof(T), because, becauseArgs);
		}

		public new AndConstraint<TypeAssertions> BeAssignableTo(Type type, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(type, "type");
			bool condition = (type.IsGenericTypeDefinition ? base.Subject.IsAssignableToOpenGeneric(type) : type.IsAssignableFrom(base.Subject));
			assertionChain.BecauseOf(because, becauseArgs).ForCondition(condition).FailWith("Expected {context:type} {0} to be assignable to {1}{reason}, but it is not.", base.Subject, type);
			return new AndConstraint<TypeAssertions>(this);
		}

		public new AndConstraint<TypeAssertions> NotBeAssignableTo<T>([StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			return NotBeAssignableTo(typeof(T), because, becauseArgs);
		}

		public new AndConstraint<TypeAssertions> NotBeAssignableTo(Type type, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(type, "type");
			bool flag = (type.IsGenericTypeDefinition ? base.Subject.IsAssignableToOpenGeneric(type) : type.IsAssignableFrom(base.Subject));
			assertionChain.BecauseOf(because, becauseArgs).ForCondition(!flag).FailWith("Expected {context:type} {0} to not be assignable to {1}{reason}, but it is.", base.Subject, type);
			return new AndConstraint<TypeAssertions>(this);
		}

		private static string GetFailureMessageIfTypesAreDifferent(Type actual, Type expected)
		{
			if (actual == expected)
			{
				return string.Empty;
			}
			string text = expected?.FullName ?? "<null>";
			string text2 = actual?.FullName ?? "<null>";
			if (text == text2)
			{
				text = "[" + expected.AssemblyQualifiedName + "]";
				text2 = "[" + actual.AssemblyQualifiedName + "]";
			}
			return "Expected type to be " + text + "{reason}, but found " + text2 + ".";
		}

		public AndConstraint<TypeAssertions> NotBe<TUnexpected>([StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			return NotBe(typeof(TUnexpected), because, becauseArgs);
		}

		public AndConstraint<TypeAssertions> NotBe(Type unexpected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			string text = (((object)unexpected != null) ? ("[" + unexpected.AssemblyQualifiedName + "]") : "<null>");
			assertionChain.BecauseOf(because, becauseArgs).ForCondition(base.Subject != unexpected).FailWith("Expected type not to be " + text + "{reason}, but it is.");
			return new AndConstraint<TypeAssertions>(this);
		}

		public AndWhichConstraint<TypeAssertions, TAttribute> BeDecoratedWith<TAttribute>([StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs) where TAttribute : Attribute
		{
			IEnumerable<TAttribute> matchingAttributes = base.Subject.GetMatchingAttributes<TAttribute>();
			assertionChain.BecauseOf(because, becauseArgs).ForCondition(matchingAttributes.Any()).FailWith("Expected type {0} to be decorated with {1}{reason}, but the attribute was not found.", base.Subject, typeof(TAttribute));
			return new AndWhichConstraint<TypeAssertions, TAttribute>(this, matchingAttributes, assertionChain);
		}

		public AndWhichConstraint<TypeAssertions, TAttribute> BeDecoratedWith<TAttribute>(Expression<Func<TAttribute, bool>> isMatchingAttributePredicate, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs) where TAttribute : Attribute
		{
			Guard.ThrowIfArgumentIsNull(isMatchingAttributePredicate, "isMatchingAttributePredicate");
			BeDecoratedWith<TAttribute>(because, becauseArgs);
			IEnumerable<TAttribute> matchingAttributes = base.Subject.GetMatchingAttributes(isMatchingAttributePredicate);
			assertionChain.BecauseOf(because, becauseArgs).ForCondition(matchingAttributes.Any()).FailWith("Expected type {0} to be decorated with {1} that matches {2}{reason}, but no matching attribute was found.", base.Subject, typeof(TAttribute), isMatchingAttributePredicate);
			return new AndWhichConstraint<TypeAssertions, TAttribute>(this, matchingAttributes, assertionChain);
		}

		public AndWhichConstraint<TypeAssertions, TAttribute> BeDecoratedWithOrInherit<TAttribute>([StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs) where TAttribute : Attribute
		{
			IEnumerable<TAttribute> matchingOrInheritedAttributes = base.Subject.GetMatchingOrInheritedAttributes<TAttribute>();
			assertionChain.BecauseOf(because, becauseArgs).ForCondition(matchingOrInheritedAttributes.Any()).FailWith("Expected type {0} to be decorated with or inherit {1}{reason}, but the attribute was not found.", base.Subject, typeof(TAttribute));
			return new AndWhichConstraint<TypeAssertions, TAttribute>(this, matchingOrInheritedAttributes, assertionChain);
		}

		public AndWhichConstraint<TypeAssertions, TAttribute> BeDecoratedWithOrInherit<TAttribute>(Expression<Func<TAttribute, bool>> isMatchingAttributePredicate, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs) where TAttribute : Attribute
		{
			Guard.ThrowIfArgumentIsNull(isMatchingAttributePredicate, "isMatchingAttributePredicate");
			BeDecoratedWithOrInherit<TAttribute>(because, becauseArgs);
			IEnumerable<TAttribute> matchingOrInheritedAttributes = base.Subject.GetMatchingOrInheritedAttributes(isMatchingAttributePredicate);
			assertionChain.BecauseOf(because, becauseArgs).ForCondition(matchingOrInheritedAttributes.Any()).FailWith("Expected type {0} to be decorated with or inherit {1} that matches {2}{reason}, but no matching attribute was found.", base.Subject, typeof(TAttribute), isMatchingAttributePredicate);
			return new AndWhichConstraint<TypeAssertions, TAttribute>(this, matchingOrInheritedAttributes, assertionChain);
		}

		public AndConstraint<TypeAssertions> NotBeDecoratedWith<TAttribute>([StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs) where TAttribute : Attribute
		{
			assertionChain.BecauseOf(because, becauseArgs).ForCondition(!base.Subject.IsDecoratedWith<TAttribute>()).FailWith("Expected type {0} to not be decorated with {1}{reason}, but the attribute was found.", base.Subject, typeof(TAttribute));
			return new AndConstraint<TypeAssertions>(this);
		}

		public AndConstraint<TypeAssertions> NotBeDecoratedWith<TAttribute>(Expression<Func<TAttribute, bool>> isMatchingAttributePredicate, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs) where TAttribute : Attribute
		{
			Guard.ThrowIfArgumentIsNull(isMatchingAttributePredicate, "isMatchingAttributePredicate");
			assertionChain.BecauseOf(because, becauseArgs).ForCondition(!base.Subject.IsDecoratedWith(isMatchingAttributePredicate)).FailWith("Expected type {0} to not be decorated with {1} that matches {2}{reason}, but a matching attribute was found.", base.Subject, typeof(TAttribute), isMatchingAttributePredicate);
			return new AndConstraint<TypeAssertions>(this);
		}

		public AndConstraint<TypeAssertions> NotBeDecoratedWithOrInherit<TAttribute>([StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs) where TAttribute : Attribute
		{
			assertionChain.BecauseOf(because, becauseArgs).ForCondition(!base.Subject.IsDecoratedWithOrInherit<TAttribute>()).FailWith("Expected type {0} to not be decorated with or inherit {1}{reason}, but the attribute was found.", base.Subject, typeof(TAttribute));
			return new AndConstraint<TypeAssertions>(this);
		}

		public AndConstraint<TypeAssertions> NotBeDecoratedWithOrInherit<TAttribute>(Expression<Func<TAttribute, bool>> isMatchingAttributePredicate, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs) where TAttribute : Attribute
		{
			Guard.ThrowIfArgumentIsNull(isMatchingAttributePredicate, "isMatchingAttributePredicate");
			assertionChain.BecauseOf(because, becauseArgs).ForCondition(!base.Subject.IsDecoratedWithOrInherit(isMatchingAttributePredicate)).FailWith("Expected type {0} to not be decorated with or inherit {1} that matches {2}{reason}, but a matching attribute was found.", base.Subject, typeof(TAttribute), isMatchingAttributePredicate);
			return new AndConstraint<TypeAssertions>(this);
		}

		public AndConstraint<TypeAssertions> Implement(Type interfaceType, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(interfaceType, "interfaceType");
			AssertSubjectImplements(interfaceType, because, becauseArgs);
			return new AndConstraint<TypeAssertions>(this);
		}

		private bool AssertSubjectImplements(Type interfaceType, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			bool containsInterface = interfaceType.IsAssignableFrom(base.Subject) && interfaceType != base.Subject;
			assertionChain.BecauseOf(because, becauseArgs).WithExpectation("Expected type {0} to implement interface {1}{reason}", base.Subject, interfaceType, delegate(AssertionChain chain)
			{
				chain.ForCondition(interfaceType.IsInterface).FailWith(", but {0} is not an interface.", interfaceType).Then.ForCondition(containsInterface).FailWith(", but it does not.");
			});
			return assertionChain.Succeeded;
		}

		public AndConstraint<TypeAssertions> Implement<TInterface>([StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs) where TInterface : class
		{
			return Implement(typeof(TInterface), because, becauseArgs);
		}

		public AndConstraint<TypeAssertions> NotImplement(Type interfaceType, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(interfaceType, "interfaceType");
			bool containsInterface = interfaceType.IsAssignableFrom(base.Subject) && interfaceType != base.Subject;
			assertionChain.BecauseOf(because, becauseArgs).WithExpectation("Expected type {0} to not implement interface {1}{reason}", base.Subject, interfaceType, delegate(AssertionChain chain)
			{
				chain.ForCondition(interfaceType.IsInterface).FailWith(", but {0} is not an interface.", interfaceType).Then.ForCondition(!containsInterface).FailWith(", but it does.", interfaceType);
			});
			return new AndConstraint<TypeAssertions>(this);
		}

		public AndConstraint<TypeAssertions> NotImplement<TInterface>([StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs) where TInterface : class
		{
			return NotImplement(typeof(TInterface), because, becauseArgs);
		}

		public AndConstraint<TypeAssertions> BeDerivedFrom(Type baseType, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(baseType, "baseType");
			bool isDerivedFrom = (baseType.IsGenericTypeDefinition ? base.Subject.IsDerivedFromOpenGeneric(baseType) : base.Subject.IsSubclassOf(baseType));
			assertionChain.BecauseOf(because, becauseArgs).WithExpectation("Expected type {0} to be derived from {1}{reason}", base.Subject, baseType, delegate(AssertionChain chain)
			{
				chain.ForCondition(!baseType.IsInterface).FailWith(", but {0} is an interface.", baseType).Then.ForCondition(isDerivedFrom).FailWith(", but it is not.");
			});
			return new AndConstraint<TypeAssertions>(this);
		}

		public AndConstraint<TypeAssertions> BeDerivedFrom<TBaseClass>([StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs) where TBaseClass : class
		{
			return BeDerivedFrom(typeof(TBaseClass), because, becauseArgs);
		}

		public AndConstraint<TypeAssertions> NotBeDerivedFrom(Type baseType, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(baseType, "baseType");
			bool isDerivedFrom = (baseType.IsGenericTypeDefinition ? base.Subject.IsDerivedFromOpenGeneric(baseType) : base.Subject.IsSubclassOf(baseType));
			assertionChain.BecauseOf(because, becauseArgs).WithExpectation("Expected type {0} not to be derived from {1}{reason}", base.Subject, baseType, delegate(AssertionChain chain)
			{
				chain.ForCondition(!baseType.IsInterface).FailWith(", but {0} is an interface.", baseType).Then.ForCondition(!isDerivedFrom).FailWith(", but it is.");
			});
			return new AndConstraint<TypeAssertions>(this);
		}

		public AndConstraint<TypeAssertions> NotBeDerivedFrom<TBaseClass>([StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs) where TBaseClass : class
		{
			return NotBeDerivedFrom(typeof(TBaseClass), because, becauseArgs);
		}

		public AndConstraint<TypeAssertions> BeSealed([StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.BecauseOf(because, becauseArgs).ForCondition((object)base.Subject != null).FailWith("Expected type to be sealed{reason}, but {context:type} is <null>.");
			if (assertionChain.Succeeded)
			{
				AssertThatSubjectIsClass();
				assertionChain.BecauseOf(because, becauseArgs).ForCondition(base.Subject.IsCSharpSealed()).FailWith("Expected type {0} to be sealed{reason}.", base.Subject);
			}
			return new AndConstraint<TypeAssertions>(this);
		}

		public AndConstraint<TypeAssertions> NotBeSealed([StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.BecauseOf(because, becauseArgs).ForCondition((object)base.Subject != null).FailWith("Expected type not to be sealed{reason}, but {context:type} is <null>.");
			if (assertionChain.Succeeded)
			{
				AssertThatSubjectIsClass();
				assertionChain.BecauseOf(because, becauseArgs).ForCondition(!base.Subject.IsCSharpSealed()).FailWith("Expected type {0} not to be sealed{reason}.", base.Subject);
			}
			return new AndConstraint<TypeAssertions>(this);
		}

		public AndConstraint<TypeAssertions> BeAbstract([StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.BecauseOf(because, becauseArgs).ForCondition((object)base.Subject != null).FailWith("Expected type to be abstract{reason}, but {context:type} is <null>.");
			if (assertionChain.Succeeded)
			{
				AssertThatSubjectIsClass();
				assertionChain.BecauseOf(because, becauseArgs).ForCondition(base.Subject.IsCSharpAbstract()).FailWith("Expected {context:type} {0} to be abstract{reason}.", base.Subject);
			}
			return new AndConstraint<TypeAssertions>(this);
		}

		public AndConstraint<TypeAssertions> NotBeAbstract([StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.BecauseOf(because, becauseArgs).ForCondition((object)base.Subject != null).FailWith("Expected type not to be abstract{reason}, but {context:type} is <null>.");
			if (assertionChain.Succeeded)
			{
				AssertThatSubjectIsClass();
				assertionChain.BecauseOf(because, becauseArgs).ForCondition(!base.Subject.IsCSharpAbstract()).FailWith("Expected type {0} not to be abstract{reason}.", base.Subject);
			}
			return new AndConstraint<TypeAssertions>(this);
		}

		public AndConstraint<TypeAssertions> BeStatic([StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.BecauseOf(because, becauseArgs).ForCondition((object)base.Subject != null).FailWith("Expected type to be static{reason}, but {context:type} is <null>.");
			if (assertionChain.Succeeded)
			{
				AssertThatSubjectIsClass();
				assertionChain.BecauseOf(because, becauseArgs).ForCondition(base.Subject.IsCSharpStatic()).FailWith("Expected type {0} to be static{reason}.", base.Subject);
			}
			return new AndConstraint<TypeAssertions>(this);
		}

		public AndConstraint<TypeAssertions> NotBeStatic([StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.BecauseOf(because, becauseArgs).ForCondition((object)base.Subject != null).FailWith("Expected type not to be static{reason}, but {context:type} is <null>.");
			if (assertionChain.Succeeded)
			{
				AssertThatSubjectIsClass();
				assertionChain.BecauseOf(because, becauseArgs).ForCondition(!base.Subject.IsCSharpStatic()).FailWith("Expected type {0} not to be static{reason}.", base.Subject);
			}
			return new AndConstraint<TypeAssertions>(this);
		}

		public AndWhichConstraint<TypeAssertions, PropertyInfo> HaveProperty(Type propertyType, string name, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(propertyType, "propertyType");
			Guard.ThrowIfArgumentIsNullOrEmpty(name, "name");
			assertionChain.BecauseOf(because, becauseArgs).ForCondition((object)base.Subject != null).FailWith("Cannot determine if a type has a property named " + name + " if the type is <null>.");
			PropertyInfo propertyInfo = null;
			if (assertionChain.Succeeded)
			{
				propertyInfo = base.Subject.FindPropertyByName(name);
				assertionChain.BecauseOf(because, becauseArgs).ForCondition((object)propertyInfo != null).FailWith(delegate
				{
					string text = (assertionChain.HasOverriddenCallerIdentifier ? assertionChain.CallerIdentifier : base.Subject.Name);
					return new FailReason("Expected " + text + " to have a property " + name + " of type " + propertyType.Name + "{reason}, but it does not.");
				})
					.Then.ForCondition(propertyInfo.PropertyType == propertyType).FailWith($"Expected property {propertyInfo.Name} to be of type {propertyType}{{reason}}, but it is not.", propertyInfo);
			}
			return new AndWhichConstraint<TypeAssertions, PropertyInfo>(this, propertyInfo);
		}

		public AndWhichConstraint<TypeAssertions, PropertyInfo> HaveProperty<TProperty>(string name, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			return HaveProperty(typeof(TProperty), name, because, becauseArgs);
		}

		public AndConstraint<TypeAssertions> NotHaveProperty(string name, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNullOrEmpty(name, "name");
			assertionChain.BecauseOf(because, becauseArgs).ForCondition((object)base.Subject != null).FailWith("Cannot determine if a type has an unexpected property named " + name + " if the type is <null>.");
			if (assertionChain.Succeeded)
			{
				PropertyInfo propertyInfo = base.Subject.FindPropertyByName(name);
				assertionChain.BecauseOf(because, becauseArgs).ForCondition((object)propertyInfo == null).FailWith(delegate
				{
					string text = (assertionChain.HasOverriddenCallerIdentifier ? assertionChain.CallerIdentifier : base.Subject.Name);
					return new FailReason("Did not expect " + text + " to have a property " + propertyInfo?.Name + "{reason}, but it does.");
				});
			}
			return new AndConstraint<TypeAssertions>(this);
		}

		public AndConstraint<TypeAssertions> HaveExplicitProperty(Type interfaceType, string name, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(interfaceType, "interfaceType");
			Guard.ThrowIfArgumentIsNullOrEmpty(name, "name");
			assertionChain.BecauseOf(because, becauseArgs).ForCondition((object)base.Subject != null).FailWith($"Expected {{context:type}} to explicitly implement {interfaceType}.{name}{{reason}}" + ", but {context:type} is <null>.");
			if (assertionChain.Succeeded && AssertSubjectImplements(interfaceType, because, becauseArgs))
			{
				bool condition = base.Subject.HasExplicitlyImplementedProperty(interfaceType, name);
				assertionChain.BecauseOf(because, becauseArgs).ForCondition(condition).FailWith($"Expected {base.Subject} to explicitly implement {interfaceType}.{name}{{reason}}, but it does not.");
			}
			return new AndConstraint<TypeAssertions>(this);
		}

		public AndConstraint<TypeAssertions> HaveExplicitProperty<TInterface>(string name, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs) where TInterface : class
		{
			return HaveExplicitProperty(typeof(TInterface), name, because, becauseArgs);
		}

		public AndConstraint<TypeAssertions> NotHaveExplicitProperty(Type interfaceType, string name, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(interfaceType, "interfaceType");
			Guard.ThrowIfArgumentIsNullOrEmpty(name, "name");
			assertionChain.BecauseOf(because, becauseArgs).ForCondition((object)base.Subject != null).FailWith($"Expected {{context:type}} to not explicitly implement {interfaceType}.{name}{{reason}}" + ", but {context:type} is <null>.");
			if (assertionChain.Succeeded && AssertSubjectImplements(interfaceType, because, becauseArgs))
			{
				bool flag = base.Subject.HasExplicitlyImplementedProperty(interfaceType, name);
				assertionChain.BecauseOf(because, becauseArgs).ForCondition(!flag).FailWith($"Expected {base.Subject} to not explicitly implement {interfaceType}.{name}{{reason}}" + ", but it does.");
			}
			return new AndConstraint<TypeAssertions>(this);
		}

		public AndConstraint<TypeAssertions> NotHaveExplicitProperty<TInterface>(string name, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs) where TInterface : class
		{
			return NotHaveExplicitProperty(typeof(TInterface), name, because, becauseArgs);
		}

		public AndConstraint<TypeAssertions> HaveExplicitMethod(Type interfaceType, string name, IEnumerable<Type> parameterTypes, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(interfaceType, "interfaceType");
			Guard.ThrowIfArgumentIsNullOrEmpty(name, "name");
			Guard.ThrowIfArgumentIsNull(parameterTypes, "parameterTypes");
			assertionChain.BecauseOf(because, becauseArgs).ForCondition((object)base.Subject != null).FailWith($"Expected {{context:type}} to explicitly implement {interfaceType}.{name}" + "(" + GetParameterString(parameterTypes) + "){reason}, but {context:type} is <null>.");
			if (assertionChain.Succeeded && AssertSubjectImplements(interfaceType, because, becauseArgs))
			{
				bool condition = base.Subject.HasMethod($"{interfaceType}.{name}", parameterTypes);
				assertionChain.BecauseOf(because, becauseArgs).ForCondition(condition).FailWith($"Expected {base.Subject} to explicitly implement {interfaceType}.{name}" + "(" + GetParameterString(parameterTypes) + "){reason}, but it does not.");
			}
			return new AndConstraint<TypeAssertions>(this);
		}

		public AndConstraint<TypeAssertions> HaveExplicitMethod<TInterface>(string name, IEnumerable<Type> parameterTypes, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs) where TInterface : class
		{
			return HaveExplicitMethod(typeof(TInterface), name, parameterTypes, because, becauseArgs);
		}

		public AndConstraint<TypeAssertions> NotHaveExplicitMethod(Type interfaceType, string name, IEnumerable<Type> parameterTypes, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(interfaceType, "interfaceType");
			Guard.ThrowIfArgumentIsNullOrEmpty(name, "name");
			Guard.ThrowIfArgumentIsNull(parameterTypes, "parameterTypes");
			assertionChain.BecauseOf(because, becauseArgs).ForCondition((object)base.Subject != null).FailWith($"Expected {{context:type}} to not explicitly implement {interfaceType}.{name}" + "(" + GetParameterString(parameterTypes) + "){reason}, but {context:type} is <null>.");
			if (assertionChain.Succeeded && AssertSubjectImplements(interfaceType, because, becauseArgs))
			{
				bool flag = base.Subject.HasMethod($"{interfaceType}.{name}", parameterTypes);
				assertionChain.BecauseOf(because, becauseArgs).ForCondition(!flag).FailWith($"Expected {base.Subject} to not explicitly implement {interfaceType}.{name}" + "(" + GetParameterString(parameterTypes) + "){reason}, but it does.");
			}
			return new AndConstraint<TypeAssertions>(this);
		}

		public AndConstraint<TypeAssertions> NotHaveExplicitMethod<TInterface>(string name, IEnumerable<Type> parameterTypes, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs) where TInterface : class
		{
			return NotHaveExplicitMethod(typeof(TInterface), name, parameterTypes, because, becauseArgs);
		}

		public AndWhichConstraint<TypeAssertions, PropertyInfo> HaveIndexer(Type indexerType, IEnumerable<Type> parameterTypes, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(indexerType, "indexerType");
			Guard.ThrowIfArgumentIsNull(parameterTypes, "parameterTypes");
			string parameterString = GetParameterString(parameterTypes);
			assertionChain.BecauseOf(because, becauseArgs).ForCondition((object)base.Subject != null).FailWith("Expected " + indexerType.Name + " {context:type}[" + parameterString + "] to exist{reason}, but {context:type} is <null>.");
			PropertyInfo propertyInfo = null;
			if (assertionChain.Succeeded)
			{
				propertyInfo = base.Subject.GetIndexerByParameterTypes(parameterTypes);
				assertionChain.BecauseOf(because, becauseArgs).ForCondition((object)propertyInfo != null).FailWith($"Expected {indexerType.Name} {base.Subject}[{parameterString}] to exist{{reason}}" + ", but it does not.")
					.Then.ForCondition(propertyInfo.PropertyType == indexerType).FailWith("Expected {0} to be of type {1}{reason}, but it is not.", propertyInfo, indexerType);
			}
			return new AndWhichConstraint<TypeAssertions, PropertyInfo>(this, propertyInfo, assertionChain, "[" + parameterString + "]");
		}

		public AndConstraint<TypeAssertions> NotHaveIndexer(IEnumerable<Type> parameterTypes, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(parameterTypes, "parameterTypes");
			assertionChain.BecauseOf(because, becauseArgs).ForCondition((object)base.Subject != null).FailWith("Expected indexer {context:type}[" + GetParameterString(parameterTypes) + "] to not exist{reason}, but {context:type} is <null>.");
			if (assertionChain.Succeeded)
			{
				PropertyInfo indexerByParameterTypes = base.Subject.GetIndexerByParameterTypes(parameterTypes);
				assertionChain.BecauseOf(because, becauseArgs).ForCondition((object)indexerByParameterTypes == null).FailWith($"Expected indexer {base.Subject}[{GetParameterString(parameterTypes)}] to not exist{{reason}}" + ", but it does.");
			}
			return new AndConstraint<TypeAssertions>(this);
		}

		public AndWhichConstraint<TypeAssertions, MethodInfo> HaveMethod(string name, IEnumerable<Type> parameterTypes, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNullOrEmpty(name, "name");
			Guard.ThrowIfArgumentIsNull(parameterTypes, "parameterTypes");
			assertionChain.BecauseOf(because, becauseArgs).ForCondition((object)base.Subject != null).FailWith("Expected method {context:type}." + name + "(" + GetParameterString(parameterTypes) + ") to exist{reason}, but {context:type} is <null>.");
			MethodInfo methodInfo = null;
			if (assertionChain.Succeeded)
			{
				methodInfo = base.Subject.GetMethod(name, parameterTypes);
				assertionChain.BecauseOf(because, becauseArgs).ForCondition((object)methodInfo != null).FailWith($"Expected method {base.Subject}.{name}({GetParameterString(parameterTypes)}) to exist{{reason}}" + ", but it does not.");
			}
			return new AndWhichConstraint<TypeAssertions, MethodInfo>(this, methodInfo);
		}

		public AndConstraint<TypeAssertions> NotHaveMethod(string name, IEnumerable<Type> parameterTypes, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNullOrEmpty(name, "name");
			Guard.ThrowIfArgumentIsNull(parameterTypes, "parameterTypes");
			assertionChain.BecauseOf(because, becauseArgs).ForCondition((object)base.Subject != null).FailWith("Expected method {context:type}." + name + "(" + GetParameterString(parameterTypes) + ") to not exist{reason}, but {context:type} is <null>.");
			if (assertionChain.Succeeded)
			{
				MethodInfo method = base.Subject.GetMethod(name, parameterTypes);
				string descriptionFor = MethodInfoAssertions.GetDescriptionFor(method);
				assertionChain.BecauseOf(because, becauseArgs).ForCondition((object)method == null).FailWith("Expected method " + descriptionFor + "(" + GetParameterString(parameterTypes) + ") to not exist{reason}, but it does.");
			}
			return new AndConstraint<TypeAssertions>(this);
		}

		public AndWhichConstraint<TypeAssertions, ConstructorInfo> HaveConstructor(IEnumerable<Type> parameterTypes, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(parameterTypes, "parameterTypes");
			assertionChain.BecauseOf(because, becauseArgs).ForCondition((object)base.Subject != null).FailWith("Expected constructor {context:type}(" + GetParameterString(parameterTypes) + ") to exist{reason}, but {context:type} is <null>.");
			ConstructorInfo constructorInfo = null;
			if (assertionChain.Succeeded)
			{
				constructorInfo = base.Subject.GetConstructor(parameterTypes);
				assertionChain.BecauseOf(because, becauseArgs).ForCondition((object)constructorInfo != null).FailWith($"Expected constructor {base.Subject}({GetParameterString(parameterTypes)}) to exist{{reason}}" + ", but it does not.");
			}
			return new AndWhichConstraint<TypeAssertions, ConstructorInfo>(this, constructorInfo);
		}

		public AndWhichConstraint<TypeAssertions, ConstructorInfo> HaveDefaultConstructor([StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			return HaveConstructor(Array.Empty<Type>(), because, becauseArgs);
		}

		public AndWhichConstraint<TypeAssertions, ConstructorInfo> NotHaveConstructor(IEnumerable<Type> parameterTypes, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(parameterTypes, "parameterTypes");
			assertionChain.BecauseOf(because, becauseArgs).ForCondition((object)base.Subject != null).FailWith("Expected constructor {context:type}(" + GetParameterString(parameterTypes) + ") not to exist{reason}, but {context:type} is <null>.");
			ConstructorInfo constructorInfo = null;
			if (assertionChain.Succeeded)
			{
				constructorInfo = base.Subject.GetConstructor(parameterTypes);
				assertionChain.BecauseOf(because, becauseArgs).ForCondition((object)constructorInfo == null).FailWith($"Expected constructor {base.Subject}({GetParameterString(parameterTypes)}) not to exist{{reason}}" + ", but it does.");
			}
			return new AndWhichConstraint<TypeAssertions, ConstructorInfo>(this, constructorInfo);
		}

		public AndWhichConstraint<TypeAssertions, ConstructorInfo> NotHaveDefaultConstructor([StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			return NotHaveConstructor(Array.Empty<Type>(), because, becauseArgs);
		}

		private static string GetParameterString(IEnumerable<Type> parameterTypes)
		{
			return string.Join(", ", parameterTypes.Select((Type p) => p.FullName));
		}

		public AndConstraint<TypeAssertions> HaveAccessModifier(CSharpAccessModifier accessModifier, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsOutOfRange(accessModifier, "accessModifier");
			assertionChain.BecauseOf(because, becauseArgs).ForCondition((object)base.Subject != null).FailWith($"Expected {{context:type}} to be {accessModifier}{{reason}}, but {{context:type}} is <null>.");
			if (assertionChain.Succeeded)
			{
				CSharpAccessModifier cSharpAccessModifier = base.Subject.GetCSharpAccessModifier();
				assertionChain.ForCondition(accessModifier == cSharpAccessModifier).BecauseOf(because, becauseArgs).ForCondition(accessModifier == cSharpAccessModifier)
					.FailWith($"Expected {{context:type}} {base.Subject.Name} to be {accessModifier}{{reason}}" + $", but it is {cSharpAccessModifier}.");
			}
			return new AndConstraint<TypeAssertions>(this);
		}

		public AndConstraint<TypeAssertions> NotHaveAccessModifier(CSharpAccessModifier accessModifier, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsOutOfRange(accessModifier, "accessModifier");
			assertionChain.BecauseOf(because, becauseArgs).ForCondition((object)base.Subject != null).FailWith($"Expected {{context:type}} not to be {accessModifier}{{reason}}, but {{context:type}} is <null>.");
			if (assertionChain.Succeeded)
			{
				CSharpAccessModifier cSharpAccessModifier = base.Subject.GetCSharpAccessModifier();
				assertionChain.ForCondition(accessModifier != cSharpAccessModifier).BecauseOf(because, becauseArgs).ForCondition(accessModifier != cSharpAccessModifier)
					.FailWith($"Expected {{context:type}} {base.Subject.Name} not to be {accessModifier}{{reason}}, but it is.");
			}
			return new AndConstraint<TypeAssertions>(this);
		}

		public AndWhichConstraint<TypeAssertions, MethodInfo> HaveImplicitConversionOperator<TSource, TTarget>([StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			return HaveImplicitConversionOperator(typeof(TSource), typeof(TTarget), because, becauseArgs);
		}

		public AndWhichConstraint<TypeAssertions, MethodInfo> HaveImplicitConversionOperator(Type sourceType, Type targetType, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(sourceType, "sourceType");
			Guard.ThrowIfArgumentIsNull(targetType, "targetType");
			assertionChain.BecauseOf(because, becauseArgs).ForCondition((object)base.Subject != null).FailWith("Expected public static implicit {0}({1}) to exist{reason}, but {context:type} is <null>.", targetType, sourceType);
			MethodInfo methodInfo = null;
			if (assertionChain.Succeeded)
			{
				methodInfo = base.Subject.GetImplicitConversionOperator(sourceType, targetType);
				assertionChain.BecauseOf(because, becauseArgs).ForCondition((object)methodInfo != null).FailWith("Expected public static implicit {0}({1}) to exist{reason}, but it does not.", targetType, sourceType);
			}
			return new AndWhichConstraint<TypeAssertions, MethodInfo>(this, methodInfo, assertionChain);
		}

		public AndConstraint<TypeAssertions> NotHaveImplicitConversionOperator<TSource, TTarget>([StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			return NotHaveImplicitConversionOperator(typeof(TSource), typeof(TTarget), because, becauseArgs);
		}

		public AndConstraint<TypeAssertions> NotHaveImplicitConversionOperator(Type sourceType, Type targetType, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(sourceType, "sourceType");
			Guard.ThrowIfArgumentIsNull(targetType, "targetType");
			assertionChain.BecauseOf(because, becauseArgs).ForCondition((object)base.Subject != null).FailWith("Expected public static implicit {0}({1}) to not exist{reason}, but {context:type} is <null>.", targetType, sourceType);
			if (assertionChain.Succeeded)
			{
				MethodInfo implicitConversionOperator = base.Subject.GetImplicitConversionOperator(sourceType, targetType);
				assertionChain.BecauseOf(because, becauseArgs).ForCondition((object)implicitConversionOperator == null).FailWith("Expected public static implicit {0}({1}) to not exist{reason}, but it does.", targetType, sourceType);
			}
			return new AndConstraint<TypeAssertions>(this);
		}

		public AndWhichConstraint<TypeAssertions, MethodInfo> HaveExplicitConversionOperator<TSource, TTarget>([StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			return HaveExplicitConversionOperator(typeof(TSource), typeof(TTarget), because, becauseArgs);
		}

		public AndWhichConstraint<TypeAssertions, MethodInfo> HaveExplicitConversionOperator(Type sourceType, Type targetType, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(sourceType, "sourceType");
			Guard.ThrowIfArgumentIsNull(targetType, "targetType");
			assertionChain.BecauseOf(because, becauseArgs).ForCondition((object)base.Subject != null).FailWith("Expected public static explicit {0}({1}) to exist{reason}, but {context:type} is <null>.", targetType, sourceType);
			MethodInfo methodInfo = null;
			if (assertionChain.Succeeded)
			{
				methodInfo = base.Subject.GetExplicitConversionOperator(sourceType, targetType);
				assertionChain.BecauseOf(because, becauseArgs).ForCondition((object)methodInfo != null).FailWith("Expected public static explicit {0}({1}) to exist{reason}, but it does not.", targetType, sourceType);
			}
			return new AndWhichConstraint<TypeAssertions, MethodInfo>(this, methodInfo);
		}

		public AndConstraint<TypeAssertions> NotHaveExplicitConversionOperator<TSource, TTarget>([StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			return NotHaveExplicitConversionOperator(typeof(TSource), typeof(TTarget), because, becauseArgs);
		}

		public AndConstraint<TypeAssertions> NotHaveExplicitConversionOperator(Type sourceType, Type targetType, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(sourceType, "sourceType");
			Guard.ThrowIfArgumentIsNull(targetType, "targetType");
			assertionChain.BecauseOf(because, becauseArgs).ForCondition((object)base.Subject != null).FailWith("Expected public static explicit {0}({1}) to not exist{reason}, but {context:type} is <null>.", targetType, sourceType);
			if (assertionChain.Succeeded)
			{
				MethodInfo explicitConversionOperator = base.Subject.GetExplicitConversionOperator(sourceType, targetType);
				assertionChain.BecauseOf(because, becauseArgs).ForCondition((object)explicitConversionOperator == null).FailWith("Expected public static explicit {0}({1}) to not exist{reason}, but it does.", targetType, sourceType);
			}
			return new AndConstraint<TypeAssertions>(this);
		}

		private void AssertThatSubjectIsClass()
		{
			if (base.Subject.IsInterface || base.Subject.IsValueType || typeof(Delegate).IsAssignableFrom(base.Subject.BaseType))
			{
				throw new InvalidOperationException($"{base.Subject} must be a class.");
			}
		}
	}
}
