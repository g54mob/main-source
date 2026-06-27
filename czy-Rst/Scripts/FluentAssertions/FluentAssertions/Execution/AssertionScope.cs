using System;
using System.Linq;
using System.Text;
using System.Threading;
using FluentAssertions.Common;
using FluentAssertions.Formatting;

namespace FluentAssertions.Execution
{
	public sealed class AssertionScope : IDisposable
	{
		private sealed class DeferredReportable
		{
			private readonly Lazy<string> lazyValue;

			public DeferredReportable(Func<string> valueFunc)
			{
				lazyValue = new Lazy<string>(valueFunc);
				base._002Ector();
			}

			public override string ToString()
			{
				return lazyValue.Value;
			}
		}

		private readonly IAssertionStrategy assertionStrategy;

		private static readonly AsyncLocal<AssertionScope> CurrentScope = new AsyncLocal<AssertionScope>();

		private readonly Func<string> callerIdentityProvider = () => CallerIdentifier.DetermineCallerIdentity();

		private readonly ContextDataDictionary reportableData = new ContextDataDictionary();

		private readonly StringBuilder tracing = new StringBuilder();

		private AssertionScope parent;

		public Func<string> Name { get; }

		public static AssertionScope Current
		{
			get
			{
				return CurrentScope.Value ?? new AssertionScope(() => (string)null, new DefaultAssertionStrategy());
			}
			private set
			{
				CurrentScope.Value = value;
			}
		}

		public FormattingOptions FormattingOptions { get; } = AssertionConfiguration.Current.Formatting.Clone();

		public AssertionScope()
			: this(() => (string)null, new CollectingAssertionStrategy())
		{
		}

		public AssertionScope(string name)
			: this(() => name, new CollectingAssertionStrategy())
		{
		}

		public AssertionScope(IAssertionStrategy assertionStrategy)
			: this(() => (string)null, assertionStrategy)
		{
		}

		public AssertionScope(Func<string> name)
			: this(name, new CollectingAssertionStrategy())
		{
		}

		private AssertionScope(Func<string> name, IAssertionStrategy assertionStrategy)
		{
			AssertionScope assertionScope = this;
			parent = CurrentScope.Value;
			CurrentScope.Value = this;
			this.assertionStrategy = assertionStrategy ?? throw new ArgumentNullException("assertionStrategy");
			if (parent != null)
			{
				Name = delegate
				{
					string text = assertionScope.parent.Name();
					if (text.IsNullOrEmpty())
					{
						return name();
					}
					return name().IsNullOrEmpty() ? text : (text + "/" + name());
				};
				callerIdentityProvider = parent.callerIdentityProvider;
				FormattingOptions = parent.FormattingOptions.Clone();
			}
			else
			{
				Name = name;
			}
		}

		public void AddPreFormattedFailure(string formattedFailureMessage)
		{
			assertionStrategy.HandleFailure(formattedFailureMessage);
		}

		internal void AddReportable(string key, string value)
		{
			reportableData.Add(new ContextDataDictionary.DataItem(key, value, reportable: true, requiresFormatting: false));
		}

		internal void AddReportable(string key, Func<string> valueFunc)
		{
			reportableData.Add(new ContextDataDictionary.DataItem(key, new DeferredReportable(valueFunc), reportable: true, requiresFormatting: false));
		}

		public void AppendTracing(string tracingBlock)
		{
			tracing.Append(tracingBlock);
		}

		public string[] Discard()
		{
			return assertionStrategy.DiscardFailures().ToArray();
		}

		public bool HasFailures()
		{
			return assertionStrategy.FailureMessages.Any();
		}

		public void Dispose()
		{
			CurrentScope.Value = parent;
			if (parent != null)
			{
				foreach (string failureMessage in assertionStrategy.FailureMessages)
				{
					parent.assertionStrategy.HandleFailure(failureMessage);
				}
				parent.reportableData.Add(reportableData);
				parent.AppendTracing(tracing.ToString());
				parent = null;
			}
			else
			{
				if (tracing.Length > 0)
				{
					reportableData.Add(new ContextDataDictionary.DataItem("trace", tracing.ToString(), reportable: true, requiresFormatting: false));
				}
				assertionStrategy.ThrowIfAny(reportableData.GetReportable());
			}
		}
	}
}
