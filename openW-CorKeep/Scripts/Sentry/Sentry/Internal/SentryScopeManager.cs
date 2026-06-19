using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sentry.Extensibility;
using Sentry.Internal.ScopeStack;

namespace Sentry.Internal
{
	internal sealed class SentryScopeManager : IInternalScopeManager, ISentryScopeManager, IDisposable
	{
		private sealed class ScopeSnapshot : IDisposable
		{
			private readonly SentryOptions _options;

			private readonly KeyValuePair<Scope, ISentryClient>[] _snapshot;

			private readonly SentryScopeManager _scopeManager;

			public ScopeSnapshot(SentryOptions options, KeyValuePair<Scope, ISentryClient>[] snapshot, SentryScopeManager scopeManager)
			{
				_options = options;
				_snapshot = snapshot;
				_scopeManager = scopeManager;
			}

			public void Dispose()
			{
				_options.LogDebug("Disposing scope.");
				Scope key = _snapshot[^1].Key;
				KeyValuePair<Scope, ISentryClient>[] scopeAndClientStack = _scopeManager.ScopeAndClientStack;
				for (int num = scopeAndClientStack.Length - 1; num >= 0; num--)
				{
					if (scopeAndClientStack[num].Key == key)
					{
						_scopeManager.ScopeAndClientStack = _snapshot;
						break;
					}
				}
			}
		}

		private readonly SentryOptions _options;

		public IScopeStackContainer ScopeStackContainer { get; }

		private KeyValuePair<Scope, ISentryClient>[] ScopeAndClientStack
		{
			get
			{
				IScopeStackContainer scopeStackContainer = ScopeStackContainer;
				return scopeStackContainer.Stack ?? (scopeStackContainer.Stack = NewStack());
			}
			set
			{
				ScopeStackContainer.Stack = value;
			}
		}

		private Func<KeyValuePair<Scope, ISentryClient>[]> NewStack { get; }

		private bool IsGlobalMode => ScopeStackContainer is GlobalScopeStackContainer;

		public SentryScopeManager(SentryOptions options, ISentryClient rootClient)
		{
			IScopeStackContainer scopeStackContainer = options.ScopeStackContainer;
			if (scopeStackContainer == null)
			{
				if (!options.IsGlobalModeEnabled)
				{
					IScopeStackContainer scopeStackContainer2 = new AsyncLocalScopeStackContainer();
					scopeStackContainer = scopeStackContainer2;
				}
				else
				{
					IScopeStackContainer scopeStackContainer2 = new GlobalScopeStackContainer();
					scopeStackContainer = scopeStackContainer2;
				}
			}
			ScopeStackContainer = scopeStackContainer;
			_options = options;
			NewStack = () => new KeyValuePair<Scope, ISentryClient>[1]
			{
				new KeyValuePair<Scope, ISentryClient>(new Scope(options), rootClient)
			};
		}

		public KeyValuePair<Scope, ISentryClient> GetCurrent()
		{
			return ScopeAndClientStack[^1];
		}

		public void ConfigureScope(Action<Scope>? configureScope)
		{
			var (obj, _) = GetCurrent();
			configureScope?.Invoke(obj);
		}

		public Task ConfigureScopeAsync(Func<Scope, Task>? configureScope)
		{
			var (arg, _) = GetCurrent();
			return configureScope?.Invoke(arg) ?? Task.CompletedTask;
		}

		public IDisposable PushScope()
		{
			return PushScope<object>(null);
		}

		public IDisposable PushScope<TState>(TState? state)
		{
			if (IsGlobalMode)
			{
				_options.LogWarning("Push scope called in global mode, returning.");
				return DisabledHub.Instance;
			}
			KeyValuePair<Scope, ISentryClient>[] scopeAndClientStack = ScopeAndClientStack;
			KeyValuePair<Scope, ISentryClient> keyValuePair = scopeAndClientStack[^1];
			if (keyValuePair.Key.Locked)
			{
				_options.LogDebug("Locked scope. No new scope pushed.");
				if (state != null)
				{
					keyValuePair.Key.Apply(state);
				}
				return DisabledHub.Instance;
			}
			Scope scope = keyValuePair.Key.Clone();
			if (state != null)
			{
				scope.Apply(state);
			}
			ScopeSnapshot result = new ScopeSnapshot(_options, scopeAndClientStack, this);
			_options.LogDebug("New scope pushed.");
			KeyValuePair<Scope, ISentryClient>[] array = new KeyValuePair<Scope, ISentryClient>[scopeAndClientStack.Length + 1];
			Array.Copy(scopeAndClientStack, array, scopeAndClientStack.Length);
			array[^1] = new KeyValuePair<Scope, ISentryClient>(scope, keyValuePair.Value);
			ScopeAndClientStack = array;
			return result;
		}

		public void RestoreScope(Scope savedScope)
		{
			if (IsGlobalMode)
			{
				_options.LogWarning("RestoreScope called in global mode, returning.");
				return;
			}
			KeyValuePair<Scope, ISentryClient>[] scopeAndClientStack = ScopeAndClientStack;
			var (_, value) = scopeAndClientStack[^1];
			_options.LogDebug("Scope restored");
			KeyValuePair<Scope, ISentryClient>[] array = new KeyValuePair<Scope, ISentryClient>[scopeAndClientStack.Length + 1];
			Array.Copy(scopeAndClientStack, array, scopeAndClientStack.Length);
			array[^1] = new KeyValuePair<Scope, ISentryClient>(savedScope, value);
			ScopeAndClientStack = array;
		}

		public void BindClient(ISentryClient? client)
		{
			_options.LogDebug("Binding a new client to the current scope.");
			KeyValuePair<Scope, ISentryClient>[] scopeAndClientStack = ScopeAndClientStack;
			KeyValuePair<Scope, ISentryClient> keyValuePair = scopeAndClientStack[^1];
			KeyValuePair<Scope, ISentryClient>[] array = new KeyValuePair<Scope, ISentryClient>[scopeAndClientStack.Length];
			Array.Copy(scopeAndClientStack, array, scopeAndClientStack.Length);
			array[^1] = new KeyValuePair<Scope, ISentryClient>(keyValuePair.Key, client ?? DisabledHub.Instance);
			ScopeAndClientStack = array;
		}

		public void Dispose()
		{
			_options.LogDebug("Disposing SentryScopeManager.");
			ScopeStackContainer.Stack = null;
		}
	}
}
