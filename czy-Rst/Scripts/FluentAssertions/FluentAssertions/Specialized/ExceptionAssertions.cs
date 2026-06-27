using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using FluentAssertions.Common;
using FluentAssertions.Equivalency.Steps;
using FluentAssertions.Execution;
using FluentAssertions.Formatting;
using FluentAssertions.Primitives;

namespace FluentAssertions.Specialized
{
	[DebuggerNonUserCode]
	public class ExceptionAssertions<TException> : ReferenceTypeAssertions<IEnumerable<TException>, ExceptionAssertions<TException>> where TException : Exception
	{
		private readonly AssertionChain assertionChain;

		public TException And => SingleSubject;

		public TException Which => And;

		protected override string Identifier => "exception";

		private TException SingleSubject
		{
			get
			{
				if (base.Subject.Count() > 1)
				{
					string text = BuildExceptionsString(base.Subject);
					AssertionEngine.TestFramework.Throw("More than one exception was thrown.  FluentAssertions cannot determine which Exception was meant." + Environment.NewLine + text);
				}
				return base.Subject.Single();
			}
		}

		public ExceptionAssertions(IEnumerable<TException> exceptions, AssertionChain assertionChain)
			: base(exceptions, assertionChain)
		{
			this.assertionChain = assertionChain;
		}

		public virtual ExceptionAssertions<TException> WithMessage(string expectedWildcardPattern, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.BecauseOf(because, becauseArgs).UsingLineBreaks.ForCondition(base.Subject.Any()).FailWith("Expected exception with message {0}{reason}, but no exception was thrown.", expectedWildcardPattern);
			AssertExceptionMessage(base.Subject.Select((TException exc) => exc.Message), expectedWildcardPattern, because, becauseArgs);
			return this;
		}

		public virtual ExceptionAssertions<TInnerException> WithInnerException<TInnerException>([StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs) where TInnerException : Exception
		{
			return new ExceptionAssertions<TInnerException>(AssertInnerExceptions(typeof(TInnerException), because, becauseArgs).Cast<TInnerException>(), assertionChain);
		}

		public ExceptionAssertions<Exception> WithInnerException(Type innerException, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(innerException, "innerException");
			return new ExceptionAssertions<Exception>(AssertInnerExceptions(innerException, because, becauseArgs), assertionChain);
		}

		public virtual ExceptionAssertions<TInnerException> WithInnerExceptionExactly<TInnerException>([StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs) where TInnerException : Exception
		{
			return new ExceptionAssertions<TInnerException>(AssertInnerExceptionExactly(typeof(TInnerException), because, becauseArgs).Cast<TInnerException>(), assertionChain);
		}

		public ExceptionAssertions<Exception> WithInnerExceptionExactly(Type innerException, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(innerException, "innerException");
			return new ExceptionAssertions<Exception>(AssertInnerExceptionExactly(innerException, because, becauseArgs), assertionChain);
		}

		public ExceptionAssertions<TException> Where(Expression<Func<TException, bool>> exceptionExpression, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(exceptionExpression, "exceptionExpression");
			Func<TException, bool> func = exceptionExpression.Compile();
			assertionChain.ForCondition(func(SingleSubject)).BecauseOf(because, becauseArgs).FailWith("Expected exception where {0}{reason}, but the condition was not met by:" + Environment.NewLine + Environment.NewLine + "{1}.", exceptionExpression, base.Subject);
			return this;
		}

		private IEnumerable<Exception> AssertInnerExceptionExactly(Type innerException, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.BecauseOf(because, becauseArgs).ForCondition(base.Subject.Any((TException e) => e.InnerException != null)).FailWith("Expected inner {0}{reason}, but the thrown exception has no inner exception.", innerException);
			Exception[] array = (from e in base.Subject
				select e.InnerException into e
				where e?.GetType() == innerException
				select e).ToArray();
			assertionChain.ForCondition(array.Length != 0).BecauseOf(because, becauseArgs).FailWith("Expected inner {0}{reason}, but found {1}.", innerException, SingleSubject.InnerException);
			return array;
		}

		private IEnumerable<Exception> AssertInnerExceptions(Type innerException, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			assertionChain.BecauseOf(because, becauseArgs).ForCondition(base.Subject.Any((TException e) => e.InnerException != null)).FailWith("Expected inner {0}{reason}, but the thrown exception has no inner exception.", innerException);
			Exception[] array = (from e in base.Subject
				select e.InnerException into e
				where e?.GetType().IsSameOrInherits(innerException) ?? false
				select e).ToArray();
			assertionChain.ForCondition(array.Length != 0).BecauseOf(because, becauseArgs).FailWith("Expected inner {0}{reason}, but found {1}.", innerException, SingleSubject.InnerException);
			return array;
		}

		private static string BuildExceptionsString(IEnumerable<TException> exceptions)
		{
			return string.Join(Environment.NewLine, exceptions.Select((TException exception) => "\t" + Formatter.ToString(exception)));
		}

		private void AssertExceptionMessage(IEnumerable<string> messages, string expectation, [StringSyntax("CompositeFormat")] string because, params object[] becauseArgs)
		{
			AssertionResultSet assertionResultSet = new AssertionResultSet();
			foreach (string message in messages)
			{
				using (AssertionScope assertionScope = new AssertionScope())
				{
					AssertionChain orCreate = AssertionChain.GetOrCreate();
					orCreate.OverrideCallerIdentifier(() => "exception message");
					orCreate.ReuseOnce();
					message.Should().MatchEquivalentOf(expectation, because, becauseArgs);
					assertionResultSet.AddSet(message, assertionScope.Discard());
				}
				if (assertionResultSet.ContainsSuccessfulSet())
				{
					break;
				}
			}
			string[] theFailuresForTheSetWithTheFewestFailures = assertionResultSet.GetTheFailuresForTheSetWithTheFewestFailures();
			foreach (string value in theFailuresForTheSetWithTheFewestFailures)
			{
				assertionChain.FailWith("{0}", value.AsNonFormattable());
			}
		}
	}
}
