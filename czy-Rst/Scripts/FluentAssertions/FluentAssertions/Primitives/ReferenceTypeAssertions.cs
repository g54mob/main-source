using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using FluentAssertions.Common;
using FluentAssertions.Execution;

namespace FluentAssertions.Primitives
{
	[DebuggerNonUserCode]
	public abstract class ReferenceTypeAssertions<TSubject, TAssertions> where TAssertions : ReferenceTypeAssertions<TSubject, TAssertions>
	{
		public TSubject Subject { get; }

		protected abstract string Identifier { get; }

		public AssertionChain CurrentAssertionChain { get; }

		protected ReferenceTypeAssertions(TSubject subject, AssertionChain assertionChain)
		{
			CurrentAssertionChain = assertionChain;
			Subject = subject;
		}

		public AndConstraint<TAssertions> BeNull([StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			CurrentAssertionChain.ForCondition(Subject == null).BecauseOf(because, becauseArgs).WithDefaultIdentifier(Identifier)
				.FailWith("Expected {context} to be <null>{reason}, but found {0}.", Subject);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> NotBeNull([StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			CurrentAssertionChain.ForCondition(Subject != null).BecauseOf(because, becauseArgs).WithDefaultIdentifier(Identifier)
				.FailWith("Expected {context} not to be <null>{reason}.");
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> BeSameAs(TSubject expected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			CurrentAssertionChain.ForCondition((object)Subject == (object)expected).BecauseOf(because, becauseArgs).WithDefaultIdentifier(Identifier)
				.FailWith("Expected {context} to refer to {0}{reason}, but found {1}.", expected, Subject);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> NotBeSameAs(TSubject unexpected, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			CurrentAssertionChain.ForCondition((object)Subject != (object)unexpected).BecauseOf(because, becauseArgs).WithDefaultIdentifier(Identifier)
				.FailWith("Did not expect {context} to refer to {0}{reason}.", unexpected);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndWhichConstraint<TAssertions, T> BeOfType<T>([StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			BeOfType(typeof(T), because, becauseArgs);
			TSubject subject = Subject;
			T subject2 = ((subject is T val) ? val : default(T));
			return new AndWhichConstraint<TAssertions, T>((TAssertions)this, subject2);
		}

		public AndConstraint<TAssertions> BeOfType(Type expectedType, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(expectedType, "expectedType");
			CurrentAssertionChain.ForCondition(Subject != null).BecauseOf(because, becauseArgs).WithDefaultIdentifier("type")
				.FailWith("Expected {context} to be {0}{reason}, but found <null>.", expectedType);
			if (CurrentAssertionChain.Succeeded)
			{
				Type type = Subject.GetType();
				if (expectedType.IsGenericTypeDefinition && type.IsGenericType)
				{
					type.GetGenericTypeDefinition().Should().Be(expectedType, because, becauseArgs);
				}
				else
				{
					type.Should().Be(expectedType, because, becauseArgs);
				}
			}
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> NotBeOfType<T>([StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			NotBeOfType(typeof(T), because, becauseArgs);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> NotBeOfType(Type unexpectedType, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(unexpectedType, "unexpectedType");
			CurrentAssertionChain.ForCondition(Subject != null).BecauseOf(because, becauseArgs).WithDefaultIdentifier("type")
				.FailWith("Expected {context} not to be {0}{reason}, but found <null>.", unexpectedType);
			if (CurrentAssertionChain.Succeeded)
			{
				Type type = Subject.GetType();
				if (unexpectedType.IsGenericTypeDefinition && type.IsGenericType)
				{
					type.GetGenericTypeDefinition().Should().NotBe(unexpectedType, because, becauseArgs);
				}
				else
				{
					type.Should().NotBe(unexpectedType, because, becauseArgs);
				}
			}
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndWhichConstraint<TAssertions, T> BeAssignableTo<T>([StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			CurrentAssertionChain.ForCondition(Subject != null).BecauseOf(because, becauseArgs).WithDefaultIdentifier("type")
				.FailWith("Expected {context} to be assignable to {0}{reason}, but found <null>.", typeof(T));
			if (CurrentAssertionChain.Succeeded)
			{
				CurrentAssertionChain.ForCondition(Subject is T).BecauseOf(because, becauseArgs).WithDefaultIdentifier(Identifier)
					.FailWith("Expected {context} to be assignable to {0}{reason}, but {1} is not.", typeof(T), Subject.GetType());
			}
			TSubject subject = Subject;
			T subject2 = ((subject is T val) ? val : default(T));
			return new AndWhichConstraint<TAssertions, T>((TAssertions)this, subject2);
		}

		public AndConstraint<TAssertions> BeAssignableTo(Type type, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(type, "type");
			CurrentAssertionChain.ForCondition(Subject != null).BecauseOf(because, becauseArgs).WithDefaultIdentifier("type")
				.FailWith("Expected {context} to be assignable to {0}{reason}, but found <null>.", type);
			if (CurrentAssertionChain.Succeeded)
			{
				bool condition = (type.IsGenericTypeDefinition ? Subject.GetType().IsAssignableToOpenGeneric(type) : type.IsAssignableFrom(Subject.GetType()));
				CurrentAssertionChain.ForCondition(condition).BecauseOf(because, becauseArgs).WithDefaultIdentifier(Identifier)
					.FailWith("Expected {context} to be assignable to {0}{reason}, but {1} is not.", type, Subject.GetType());
			}
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> NotBeAssignableTo<T>([StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			return NotBeAssignableTo(typeof(T), because, becauseArgs);
		}

		public AndConstraint<TAssertions> NotBeAssignableTo(Type type, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(type, "type");
			CurrentAssertionChain.ForCondition(Subject != null).BecauseOf(because, becauseArgs).WithDefaultIdentifier("type")
				.FailWith("Expected {context} to not be assignable to {0}{reason}, but found <null>.", type);
			if (CurrentAssertionChain.Succeeded)
			{
				bool flag = (type.IsGenericTypeDefinition ? Subject.GetType().IsAssignableToOpenGeneric(type) : type.IsAssignableFrom(Subject.GetType()));
				CurrentAssertionChain.ForCondition(!flag).BecauseOf(because, becauseArgs).WithDefaultIdentifier(Identifier)
					.FailWith("Expected {context} to not be assignable to {0}{reason}, but {1} is.", type, Subject.GetType());
			}
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> Match(Expression<Func<TSubject, bool>> predicate, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			return this.Match<TSubject>(predicate, because, becauseArgs);
		}

		public AndConstraint<TAssertions> Match<T>(Expression<Func<T, bool>> predicate, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs) where T : TSubject
		{
			Guard.ThrowIfArgumentIsNull(predicate, "predicate", "Cannot match an object against a <null> predicate.");
			CurrentAssertionChain.ForCondition(predicate.Compile()((T)(object)Subject)).BecauseOf(because, becauseArgs).WithDefaultIdentifier(Identifier)
				.FailWith("Expected {context:object} to match {1}{reason}, but found {0}.", Subject, predicate);
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public AndConstraint<TAssertions> Satisfy<T>(Action<T> assertion) where T : TSubject
		{
			Guard.ThrowIfArgumentIsNull(assertion, "assertion", "Cannot verify an object against a <null> inspector.");
			AssertionChain assertionChain = CurrentAssertionChain.ForCondition(Subject != null).WithDefaultIdentifier(Identifier).FailWith("Expected {context:object} to be assignable to {0}{reason}, but found <null>.", typeof(T))
				.Then.ForCondition(Subject is T).WithDefaultIdentifier(Identifier);
			object[] obj = new object[2]
			{
				typeof(T),
				null
			};
			TSubject subject = Subject;
			obj[1] = ((subject != null) ? subject.GetType() : null);
			assertionChain.FailWith("Expected {context:object} to be assignable to {0}{reason}, but {1} is not.", obj);
			if (CurrentAssertionChain.Succeeded)
			{
				string[] array;
				using (AssertionScope assertionScope = new AssertionScope())
				{
					assertion((T)(object)Subject);
					array = assertionScope.Discard();
				}
				if (array.Length != 0)
				{
					string failureMessage = Environment.NewLine + string.Join(Environment.NewLine, array.Select((string x) => x.IndentLines()));
					CurrentAssertionChain.WithDefaultIdentifier(Identifier).WithExpectation("Expected {context:object} to match inspector, but the inspector was not satisfied:", Subject, delegate(AssertionChain chain)
					{
						chain.FailWithPreFormatted(failureMessage);
					});
				}
			}
			return new AndConstraint<TAssertions>((TAssertions)this);
		}

		public override bool Equals(object obj)
		{
			throw new NotSupportedException("Equals is not part of Fluent Assertions. Did you mean BeSameAs() instead?");
		}
	}
}
