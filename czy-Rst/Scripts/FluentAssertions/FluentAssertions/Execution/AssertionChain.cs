using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Threading;
using FluentAssertions.Common;

namespace FluentAssertions.Execution
{
	public sealed class AssertionChain
	{
		private readonly Func<AssertionScope> getCurrentScope;

		private readonly ContextDataDictionary contextData = new ContextDataDictionary();

		private readonly SubjectIdentificationBuilder identifierBuilder;

		private string fallbackIdentifier = "object";

		private Func<string> reason;

		private bool? succeeded;

		private Func<string> expectation;

		private static readonly AsyncLocal<AssertionChain> Instance = new AsyncLocal<AssertionChain>();

		internal bool PreviousAssertionSucceeded { get; private set; } = true;

		public bool HasOverriddenCallerIdentifier => identifierBuilder.HasOverriddenIdentifier;

		public string CallerIdentifier => identifierBuilder.Build();

		public bool Succeeded
		{
			get
			{
				bool flag = PreviousAssertionSucceeded;
				if (flag)
				{
					bool flag2 = ((succeeded ?? true) ? true : false);
					flag = flag2;
				}
				return flag;
			}
		}

		public AssertionChain UsingLineBreaks
		{
			get
			{
				getCurrentScope().FormattingOptions.UseLineBreaks = true;
				return this;
			}
		}

		public void ReuseOnce()
		{
			Instance.Value = this;
		}

		public static AssertionChain GetOrCreate()
		{
			if (Instance.Value != null)
			{
				AssertionChain value = Instance.Value;
				Instance.Value = null;
				return value;
			}
			return new AssertionChain(() => AssertionScope.Current, () => FluentAssertions.CallerIdentifier.DetermineCallerIdentities());
		}

		private AssertionChain(Func<AssertionScope> getCurrentScope, Func<string[]> getCallerIdentifiers)
		{
			this.getCurrentScope = getCurrentScope;
			identifierBuilder = new SubjectIdentificationBuilder(getCallerIdentifiers, () => getCurrentScope().Name());
		}

		public AssertionChain BecauseOf(Reason reason)
		{
			return BecauseOf(reason.FormattedMessage, reason.Arguments);
		}

		public AssertionChain BecauseOf([StringSyntax("CompositeFormat")] string because, params object[] becauseArgs)
		{
			reason = delegate
			{
				try
				{
					string text = because ?? string.Empty;
					object[] array = becauseArgs;
					return (array != null && array.Length != 0) ? string.Format(CultureInfo.InvariantCulture, text, becauseArgs) : text;
				}
				catch (FormatException ex)
				{
					return "**WARNING** because message '" + because + "' could not be formatted with string.Format" + Environment.NewLine + ex.StackTrace;
				}
			};
			return this;
		}

		public AssertionChain ForCondition(bool condition)
		{
			if (PreviousAssertionSucceeded)
			{
				succeeded = condition;
			}
			return this;
		}

		public AssertionChain ForConstraint(OccurrenceConstraint constraint, int actualOccurrences)
		{
			if (PreviousAssertionSucceeded)
			{
				constraint.RegisterContextData(delegate(string key, object value)
				{
					contextData.Add(new ContextDataDictionary.DataItem(key, value, reportable: false, requiresFormatting: false));
				});
				succeeded = constraint.Assert(actualOccurrences);
			}
			return this;
		}

		public Continuation WithExpectation(string message, object arg1, Action<AssertionChain> chain)
		{
			return WithExpectation(message, chain, arg1);
		}

		public Continuation WithExpectation(string message, object arg1, object arg2, Action<AssertionChain> chain)
		{
			return WithExpectation(message, chain, arg1, arg2);
		}

		public Continuation WithExpectation(string message, Action<AssertionChain> chain)
		{
			return WithExpectation(message, chain, Array.Empty<object>());
		}

		private Continuation WithExpectation(string message, Action<AssertionChain> chain, params object[] args)
		{
			if (PreviousAssertionSucceeded)
			{
				expectation = () => new FailureMessageFormatter(getCurrentScope().FormattingOptions).WithReason(reason?.Invoke() ?? string.Empty).WithContext(contextData).WithIdentifier(CallerIdentifier)
					.WithFallbackIdentifier(fallbackIdentifier)
					.Format(message, args);
				chain(this);
				expectation = null;
			}
			return new Continuation(this);
		}

		public AssertionChain WithDefaultIdentifier(string identifier)
		{
			fallbackIdentifier = identifier;
			return this;
		}

		public GivenSelector<T> Given<T>(Func<T> selector)
		{
			return new GivenSelector<T>(selector, this);
		}

		internal Continuation FailWithPreFormatted(string formattedFailReason)
		{
			return FailWith(() => formattedFailReason);
		}

		public Continuation FailWith(string message)
		{
			return FailWith(() => new FailReason(message));
		}

		public Continuation FailWith(string message, params object[] args)
		{
			return FailWith(() => new FailReason(message, args));
		}

		public Continuation FailWith(string message, params Func<object>[] argProviders)
		{
			return FailWith(() => new FailReason(message, argProviders.Select((Func<object> a) => a()).ToArray()));
		}

		public Continuation FailWith(Func<FailReason> getFailureReason)
		{
			return FailWith(delegate
			{
				FailureMessageFormatter failureMessageFormatter = new FailureMessageFormatter(getCurrentScope().FormattingOptions).WithReason(reason?.Invoke() ?? string.Empty).WithContext(contextData).WithIdentifier(CallerIdentifier)
					.WithFallbackIdentifier(fallbackIdentifier);
				FailReason failReason = getFailureReason();
				return failureMessageFormatter.Format(failReason.Message, failReason.Args);
			});
		}

		private Continuation FailWith(Func<string> getFailureReason)
		{
			if (PreviousAssertionSucceeded)
			{
				PreviousAssertionSucceeded = succeeded ?? false;
				if ((!succeeded) ?? true)
				{
					string text = getFailureReason();
					if (expectation != null)
					{
						text = expectation() + text;
					}
					getCurrentScope().AddPreFormattedFailure(text.Capitalize().RemoveTrailingWhitespaceFromLines());
				}
			}
			succeeded = null;
			return new Continuation(this);
		}

		public void OverrideCallerIdentifier(Func<string> getCallerIdentifier)
		{
			identifierBuilder.OverrideSubjectIdentifier(getCallerIdentifier);
		}

		public AssertionChain WithCallerPostfix(string postfix)
		{
			identifierBuilder.UsePostfix(postfix);
			return this;
		}

		internal void AdvanceToNextIdentifier()
		{
			identifierBuilder.AdvanceToNextSubject();
		}

		public void AddReportable(string key, string value)
		{
			getCurrentScope().AddReportable(key, value);
		}

		public void AddReportable(string key, Func<string> getValue)
		{
			getCurrentScope().AddReportable(key, getValue);
		}

		public AssertionChain WithReportable(string name, Func<string> content)
		{
			getCurrentScope().AddReportable(name, content);
			return this;
		}

		internal void AddPreFormattedFailure(string failure)
		{
			getCurrentScope().AddPreFormattedFailure(failure);
		}
	}
}
