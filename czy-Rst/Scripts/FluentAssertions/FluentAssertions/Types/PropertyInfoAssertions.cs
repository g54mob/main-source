using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using FluentAssertions.Common;
using FluentAssertions.Execution;
using FluentAssertions.Formatting;

namespace FluentAssertions.Types
{
	[DebuggerNonUserCode]
	public class PropertyInfoAssertions : MemberInfoAssertions<PropertyInfo, PropertyInfoAssertions>
	{
		private readonly AssertionChain assertionChain;

		private protected override string SubjectDescription => Formatter.ToString(base.Subject);

		protected override string Identifier => "property";

		public PropertyInfoAssertions(PropertyInfo propertyInfo, AssertionChain assertionChain)
			: base(propertyInfo, assertionChain)
		{
			this.assertionChain = assertionChain;
		}

		public AndConstraint<PropertyInfoAssertions> BeVirtual([StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.BecauseOf(because, becauseArgs).ForCondition((object)base.Subject != null).FailWith("Expected property to be virtual{reason}, but {context:property} is <null>.")
				.Then.ForCondition(base.Subject.IsVirtual()).BecauseOf(because, becauseArgs).FailWith(delegate
			{
				string text = (assertionChain.HasOverriddenCallerIdentifier ? assertionChain.CallerIdentifier : ("property " + base.Subject.ToFormattedString()));
				return new FailReason("Expected " + text + " to be virtual{reason}, but it is not.");
			});
			return new AndConstraint<PropertyInfoAssertions>(this);
		}

		public AndConstraint<PropertyInfoAssertions> NotBeVirtual([StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.BecauseOf(because, becauseArgs).ForCondition((object)base.Subject != null).FailWith("Expected property not to be virtual{reason}, but {context:property} is <null>.")
				.Then.ForCondition(!base.Subject.IsVirtual()).BecauseOf(because, becauseArgs).FailWith(delegate
			{
				string text = (assertionChain.HasOverriddenCallerIdentifier ? assertionChain.CallerIdentifier : ("property " + base.Subject.ToFormattedString()));
				return new FailReason("Expected property " + text + " not to be virtual{reason}, but it is.");
			});
			return new AndConstraint<PropertyInfoAssertions>(this);
		}

		public AndConstraint<PropertyInfoAssertions> BeWritable([StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.BecauseOf(because, becauseArgs).ForCondition((object)base.Subject != null).FailWith("Expected property to have a setter{reason}, but {context:property} is <null>.")
				.Then.ForCondition(base.Subject.CanWrite).BecauseOf(because, becauseArgs).FailWith(delegate
			{
				string text = (assertionChain.HasOverriddenCallerIdentifier ? assertionChain.CallerIdentifier : ("property " + base.Subject.ToFormattedString()));
				return new FailReason("Expected " + text + " to have a setter{reason}.");
			});
			return new AndConstraint<PropertyInfoAssertions>(this);
		}

		public AndConstraint<PropertyInfoAssertions> BeWritable(CSharpAccessModifier accessModifier, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsOutOfRange(accessModifier, "accessModifier");
			string subjectDescription = (assertionChain.HasOverriddenCallerIdentifier ? assertionChain.CallerIdentifier : ("property " + base.Subject.ToFormattedString()));
			assertionChain.BecauseOf(because, becauseArgs).ForCondition((object)base.Subject != null).FailWith($"Expected {{context:project}} to be {accessModifier}{{reason}}, but it is <null>.")
				.Then.ForCondition(base.Subject.CanWrite).BecauseOf(because, becauseArgs).FailWith("Expected " + subjectDescription + " to have a setter{reason}.");
			if (assertionChain.Succeeded)
			{
				assertionChain.OverrideCallerIdentifier(() => "setter of " + subjectDescription);
				assertionChain.ReuseOnce();
				base.Subject.GetSetMethod(nonPublic: true).Should().HaveAccessModifier(accessModifier, because, becauseArgs);
			}
			return new AndConstraint<PropertyInfoAssertions>(this);
		}

		public AndConstraint<PropertyInfoAssertions> NotBeWritable([StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.BecauseOf(because, becauseArgs).ForCondition((object)base.Subject != null).FailWith("Expected {context:property} not to have a setter{reason}, but it is <null>.")
				.Then.ForCondition(!base.Subject.CanWrite).BecauseOf(because, becauseArgs).FailWith(delegate
			{
				string text = (assertionChain.HasOverriddenCallerIdentifier ? assertionChain.CallerIdentifier : ("property " + base.Subject.ToFormattedString()));
				return new FailReason("Did not expect " + text + " to have a setter{reason}.");
			});
			return new AndConstraint<PropertyInfoAssertions>(this);
		}

		public AndConstraint<PropertyInfoAssertions> BeReadable([StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.BecauseOf(because, becauseArgs).ForCondition((object)base.Subject != null).FailWith("Expected property to have a getter{reason}, but {context:property} is <null>.")
				.Then.ForCondition(base.Subject.CanRead).BecauseOf(because, becauseArgs).FailWith(delegate
			{
				string text = (assertionChain.HasOverriddenCallerIdentifier ? assertionChain.CallerIdentifier : ("property " + base.Subject.ToFormattedString()));
				return new FailReason("Expected property " + text + " to have a getter{reason}, but it does not.");
			});
			return new AndConstraint<PropertyInfoAssertions>(this);
		}

		public AndConstraint<PropertyInfoAssertions> BeReadable(CSharpAccessModifier accessModifier, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsOutOfRange(accessModifier, "accessModifier");
			string subjectDescription = (assertionChain.HasOverriddenCallerIdentifier ? assertionChain.CallerIdentifier : ("property " + base.Subject.ToFormattedString()));
			assertionChain.BecauseOf(because, becauseArgs).ForCondition((object)base.Subject != null).FailWith($"Expected {{context:property}} to be {accessModifier}{{reason}}, but it is <null>.")
				.Then.ForCondition(base.Subject.CanRead).BecauseOf(because, becauseArgs).FailWith("Expected " + subjectDescription + " to have a getter{reason}, but it does not.");
			if (assertionChain.Succeeded)
			{
				assertionChain.OverrideCallerIdentifier(() => "getter of " + subjectDescription);
				assertionChain.ReuseOnce();
				base.Subject.GetGetMethod(nonPublic: true).Should().HaveAccessModifier(accessModifier, because, becauseArgs);
			}
			return new AndConstraint<PropertyInfoAssertions>(this);
		}

		public AndConstraint<PropertyInfoAssertions> NotBeReadable([StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.BecauseOf(because, becauseArgs).ForCondition((object)base.Subject != null).FailWith("Expected property not to have a getter{reason}, but {context:property} is <null>.")
				.Then.ForCondition(!base.Subject.CanRead).BecauseOf(because, becauseArgs).FailWith(delegate
			{
				string text = (assertionChain.HasOverriddenCallerIdentifier ? assertionChain.CallerIdentifier : ("property " + base.Subject.ToFormattedString()));
				return new FailReason("Did not expect " + text + " to have a getter{reason}.");
			});
			return new AndConstraint<PropertyInfoAssertions>(this);
		}

		public AndConstraint<PropertyInfoAssertions> Return(Type propertyType, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(propertyType, "propertyType");
			assertionChain.BecauseOf(because, becauseArgs).ForCondition((object)base.Subject != null).FailWith("Expected type of property to be {0}{reason}, but {context:property} is <null>.", propertyType)
				.Then.ForCondition(base.Subject.PropertyType == propertyType).BecauseOf(because, becauseArgs).FailWith("Expected type of property {2} to be {0}{reason}, but it is {1}.", propertyType, base.Subject.PropertyType, base.Subject);
			return new AndConstraint<PropertyInfoAssertions>(this);
		}

		public AndConstraint<PropertyInfoAssertions> Return<TReturn>([StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			return Return(typeof(TReturn), because, becauseArgs);
		}

		public AndConstraint<PropertyInfoAssertions> NotReturn(Type propertyType, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(propertyType, "propertyType");
			assertionChain.BecauseOf(because, becauseArgs).ForCondition((object)base.Subject != null).FailWith("Expected type of property not to be {0}{reason}, but {context:property} is <null>.", propertyType)
				.Then.ForCondition(base.Subject.PropertyType != propertyType).BecauseOf(because, becauseArgs).FailWith("Expected type of property {1} not to be {0}{reason}, but it is.", propertyType, base.Subject);
			return new AndConstraint<PropertyInfoAssertions>(this);
		}

		public AndConstraint<PropertyInfoAssertions> NotReturn<TReturn>([StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			return NotReturn(typeof(TReturn), because, becauseArgs);
		}
	}
}
