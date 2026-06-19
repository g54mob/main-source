using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using Sentry.Extensibility;
using Sentry.Internal;
using Sentry.Internal.Extensions;

namespace Sentry
{
	public class Scope : IEventLike, IHasTags, IHasExtra
	{
		private readonly object _lastEventIdSync = new object();

		private SentryId _lastEventId;

		private readonly object _evaluationSync = new object();

		private volatile bool _hasEvaluated;

		private readonly Lazy<ConcurrentBag<ISentryEventExceptionProcessor>> _lazyExceptionProcessors = new Lazy<ConcurrentBag<ISentryEventExceptionProcessor>>(LazyThreadSafetyMode.PublicationOnly);

		private readonly Lazy<ConcurrentBag<ISentryEventProcessor>> _lazyEventProcessors = new Lazy<ConcurrentBag<ISentryEventProcessor>>(LazyThreadSafetyMode.PublicationOnly);

		private readonly Lazy<ConcurrentBag<ISentryTransactionProcessor>> _lazyTransactionProcessors = new Lazy<ConcurrentBag<ISentryTransactionProcessor>>(LazyThreadSafetyMode.PublicationOnly);

		private SentryRequest? _request;

		private readonly SentryContexts _contexts = new SentryContexts();

		private SentryUser? _user;

		private string? _fallbackTransactionName;

		private ITransactionTracer? _transaction;

		private ConcurrentQueue<Breadcrumb> _breadcrumbs = new ConcurrentQueue<Breadcrumb>();

		private readonly ConcurrentDictionary<string, object?> _extra = new ConcurrentDictionary<string, object>();

		private readonly ConcurrentDictionary<string, string> _tags = new ConcurrentDictionary<string, string>();

		private ConcurrentBag<SentryAttachment> _attachments = new ConcurrentBag<SentryAttachment>();

		private ISpan? _span;

		internal SentryOptions Options { get; }

		internal bool Locked { get; set; }

		internal SentryId LastEventId
		{
			get
			{
				lock (_lastEventIdSync)
				{
					return _lastEventId;
				}
			}
			set
			{
				lock (_lastEventIdSync)
				{
					_lastEventId = value;
				}
			}
		}

		internal bool HasEvaluated => _hasEvaluated;

		internal ConcurrentBag<ISentryEventExceptionProcessor> ExceptionProcessors => _lazyExceptionProcessors.Value;

		internal ConcurrentBag<ISentryEventProcessor> EventProcessors => _lazyEventProcessors.Value;

		internal ConcurrentBag<ISentryTransactionProcessor> TransactionProcessors => _lazyTransactionProcessors.Value;

		public SentryLevel? Level { get; set; }

		public SentryRequest Request
		{
			get
			{
				return _request ?? (_request = new SentryRequest());
			}
			set
			{
				_request = value;
			}
		}

		public SentryContexts Contexts
		{
			get
			{
				return _contexts;
			}
			set
			{
				_contexts.ReplaceWith(value);
			}
		}

		internal Action<SentryUser?> UserChanged => delegate(SentryUser? user)
		{
			if (Options.EnableScopeSync)
			{
				Options.ScopeObserver?.SetUser(user);
			}
		};

		public SentryUser User
		{
			get
			{
				SentryUser sentryUser = _user;
				if (sentryUser == null)
				{
					SentryUser obj = new SentryUser
					{
						PropertyChanged = UserChanged
					};
					SentryUser sentryUser2 = obj;
					_user = obj;
					sentryUser = sentryUser2;
				}
				return sentryUser;
			}
			set
			{
				if (_user != value)
				{
					_user = value;
					if (_user != null)
					{
						_user.PropertyChanged = UserChanged;
					}
					UserChanged(_user);
				}
			}
		}

		public string? Release { get; set; }

		public string? Distribution { get; set; }

		public string? Environment { get; set; }

		public string? TransactionName
		{
			get
			{
				return Transaction?.Name ?? _fallbackTransactionName;
			}
			set
			{
				_fallbackTransactionName = value;
				ITransactionTracer transaction = Transaction;
				if (transaction != null)
				{
					transaction.Name = ((!string.IsNullOrWhiteSpace(value)) ? value : string.Empty);
				}
			}
		}

		public ITransactionTracer? Transaction
		{
			get
			{
				return _transaction;
			}
			set
			{
				_transaction = value;
			}
		}

		internal SentryPropagationContext PropagationContext { get; set; }

		internal SessionUpdate? SessionUpdate { get; set; }

		public SdkVersion Sdk { get; } = new SdkVersion();

		public IReadOnlyList<string> Fingerprint { get; set; } = Array.Empty<string>();

		public IReadOnlyCollection<Breadcrumb> Breadcrumbs => _breadcrumbs;

		public IReadOnlyDictionary<string, object?> Extra => _extra;

		public IReadOnlyDictionary<string, string> Tags => _tags;

		public IReadOnlyCollection<SentryAttachment> Attachments => _attachments;

		public ISpan? Span
		{
			get
			{
				if (_span?.IsFinished ?? true)
				{
					return Transaction?.GetLastActiveSpan() ?? Transaction;
				}
				return _span;
			}
			set
			{
				_span = value;
			}
		}

		internal event EventHandler<Scope>? OnEvaluating;

		public Scope(SentryOptions? options)
			: this(options, null)
		{
		}

		internal Scope(SentryOptions? options, SentryPropagationContext? propagationContext)
		{
			Options = options ?? new SentryOptions();
			PropagationContext = new SentryPropagationContext(propagationContext);
		}

		internal Scope()
			: this(new SentryOptions())
		{
		}

		public void AddBreadcrumb(Breadcrumb breadcrumb)
		{
			AddBreadcrumb(breadcrumb, new SentryHint());
		}

		public void AddBreadcrumb(Breadcrumb breadcrumb, SentryHint hint)
		{
			Func<Breadcrumb, SentryHint, Breadcrumb> beforeBreadcrumbInternal = Options.BeforeBreadcrumbInternal;
			if (beforeBreadcrumbInternal != null)
			{
				hint.AddAttachmentsFromScope(this);
				Breadcrumb breadcrumb2 = beforeBreadcrumbInternal(breadcrumb, hint);
				if (breadcrumb2 == null)
				{
					return;
				}
				breadcrumb = breadcrumb2;
			}
			if (Options.MaxBreadcrumbs > 0)
			{
				if (Breadcrumbs.Count - Options.MaxBreadcrumbs + 1 > 0)
				{
					_breadcrumbs.TryDequeue(out Breadcrumb _);
				}
				_breadcrumbs.Enqueue(breadcrumb);
				if (Options.EnableScopeSync)
				{
					Options.ScopeObserver?.AddBreadcrumb(breadcrumb);
				}
			}
		}

		public void SetExtra(string key, object? value)
		{
			_extra[key] = value;
			if (Options.EnableScopeSync)
			{
				Options.ScopeObserver?.SetExtra(key, value);
			}
		}

		public void SetTag(string key, string value)
		{
			if (!Options.TagFilters.Any((SubstringOrRegexPattern x) => x.IsMatch(key)))
			{
				_tags[key] = value;
				if (Options.EnableScopeSync)
				{
					Options.ScopeObserver?.SetTag(key, value);
				}
			}
		}

		public void UnsetTag(string key)
		{
			_tags.TryRemove(key, out string _);
			if (Options.EnableScopeSync)
			{
				Options.ScopeObserver?.UnsetTag(key);
			}
		}

		public void AddAttachment(SentryAttachment attachment)
		{
			_attachments.Add(attachment);
		}

		public void Clear()
		{
			Level = null;
			Request = new SentryRequest();
			Contexts.Clear();
			User = new SentryUser();
			Release = null;
			Distribution = null;
			Environment = null;
			TransactionName = null;
			Transaction = null;
			Fingerprint = Array.Empty<string>();
			ClearBreadcrumbs();
			_extra.Clear();
			_tags.Clear();
			ClearAttachments();
			PropagationContext = new SentryPropagationContext();
		}

		public void ClearAttachments()
		{
			Interlocked.Exchange(ref _attachments, new ConcurrentBag<SentryAttachment>());
		}

		public void ClearBreadcrumbs()
		{
			Interlocked.Exchange(ref _breadcrumbs, new ConcurrentQueue<Breadcrumb>());
		}

		public void Apply(IEventLike other)
		{
			if (other.IsNull())
			{
				return;
			}
			if (!other.Fingerprint.Any() && Fingerprint.Any())
			{
				other.Fingerprint = Fingerprint;
			}
			foreach (Breadcrumb breadcrumb in Breadcrumbs)
			{
				other.AddBreadcrumb(breadcrumb);
			}
			string key;
			foreach (KeyValuePair<string, object> item in Extra)
			{
				PolyfillExtensions.Deconstruct(item, out key, out var value);
				string key2 = key;
				object value2 = value;
				if (!other.Extra.ContainsKey(key2))
				{
					other.SetExtra(key2, value2);
				}
			}
			foreach (KeyValuePair<string, string> tag in Tags)
			{
				PolyfillExtensions.Deconstruct(tag, out key, out var value3);
				string key3 = key;
				string value4 = value3;
				if (!other.Tags.ContainsKey(key3))
				{
					other.SetTag(key3, value4);
				}
			}
			Contexts.CopyTo(other.Contexts);
			Request.CopyTo(other.Request);
			User.CopyTo(other.User);
			IEventLike eventLike = other;
			if (eventLike.Release == null)
			{
				string value3 = (eventLike.Release = Release);
			}
			eventLike = other;
			if (eventLike.Distribution == null)
			{
				string value3 = (eventLike.Distribution = Distribution);
			}
			eventLike = other;
			if (eventLike.Environment == null)
			{
				string value3 = (eventLike.Environment = Environment);
			}
			eventLike = other;
			if (eventLike.TransactionName == null)
			{
				string value3 = (eventLike.TransactionName = TransactionName);
			}
			eventLike = other;
			if (!eventLike.Level.HasValue)
			{
				SentryLevel? sentryLevel = (eventLike.Level = Level);
			}
			if (Sdk.Name != null && Sdk.Version != null)
			{
				other.Sdk.Name = Sdk.Name;
				other.Sdk.Version = Sdk.Version;
			}
			foreach (SentryPackage internalPackage in Sdk.InternalPackages)
			{
				other.Sdk.AddPackage(internalPackage);
			}
		}

		public void Apply(Scope other)
		{
			if (other.IsNull())
			{
				return;
			}
			Apply((IEventLike)other);
			Scope scope = other;
			if (scope.Transaction == null)
			{
				ITransactionTracer transactionTracer = (scope.Transaction = Transaction);
			}
			scope = other;
			if (scope.SessionUpdate == null)
			{
				SessionUpdate sessionUpdate = (scope.SessionUpdate = SessionUpdate);
			}
			foreach (SentryAttachment attachment in Attachments)
			{
				other.AddAttachment(attachment);
			}
		}

		public void Apply(object state)
		{
			Options.SentryScopeStateProcessor.Apply(this, state);
		}

		public Scope Clone()
		{
			Scope scope = new Scope(Options, PropagationContext)
			{
				OnEvaluating = this.OnEvaluating
			};
			Apply(scope);
			foreach (ISentryEventProcessor eventProcessor in EventProcessors)
			{
				scope.EventProcessors.Add(eventProcessor);
			}
			foreach (ISentryTransactionProcessor transactionProcessor in TransactionProcessors)
			{
				scope.TransactionProcessors.Add(transactionProcessor);
			}
			foreach (ISentryEventExceptionProcessor exceptionProcessor in ExceptionProcessors)
			{
				scope.ExceptionProcessors.Add(exceptionProcessor);
			}
			return scope;
		}

		internal void Evaluate()
		{
			if (_hasEvaluated)
			{
				return;
			}
			lock (_evaluationSync)
			{
				if (_hasEvaluated)
				{
					return;
				}
				try
				{
					this.OnEvaluating?.Invoke(this, this);
				}
				catch (Exception exception)
				{
					Options.DiagnosticLogger?.LogError(exception, "Failed invoking event handler.");
				}
				finally
				{
					_hasEvaluated = true;
				}
			}
		}

		public IEnumerable<ISentryEventProcessor> GetAllEventProcessors()
		{
			foreach (ISentryEventProcessor allEventProcessor in Options.GetAllEventProcessors())
			{
				yield return allEventProcessor;
			}
			foreach (ISentryEventProcessor eventProcessor in EventProcessors)
			{
				yield return eventProcessor;
			}
		}

		public IEnumerable<ISentryTransactionProcessor> GetAllTransactionProcessors()
		{
			foreach (ISentryTransactionProcessor allTransactionProcessor in Options.GetAllTransactionProcessors())
			{
				yield return allTransactionProcessor;
			}
			foreach (ISentryTransactionProcessor transactionProcessor in TransactionProcessors)
			{
				yield return transactionProcessor;
			}
		}

		public IEnumerable<ISentryEventExceptionProcessor> GetAllExceptionProcessors()
		{
			foreach (ISentryEventExceptionProcessor allExceptionProcessor in Options.GetAllExceptionProcessors())
			{
				yield return allExceptionProcessor;
			}
			foreach (ISentryEventExceptionProcessor exceptionProcessor in ExceptionProcessors)
			{
				yield return exceptionProcessor;
			}
		}

		public void AddExceptionProcessor(ISentryEventExceptionProcessor processor)
		{
			ExceptionProcessors.Add(processor);
		}

		public void AddExceptionProcessors(IEnumerable<ISentryEventExceptionProcessor> processors)
		{
			foreach (ISentryEventExceptionProcessor processor in processors)
			{
				ExceptionProcessors.Add(processor);
			}
		}

		public void AddEventProcessor(ISentryEventProcessor processor)
		{
			EventProcessors.Add(processor);
		}

		public void AddEventProcessor(Func<SentryEvent, SentryEvent> processor)
		{
			AddEventProcessor(new DelegateEventProcessor(processor));
		}

		public void AddEventProcessors(IEnumerable<ISentryEventProcessor> processors)
		{
			foreach (ISentryEventProcessor processor in processors)
			{
				EventProcessors.Add(processor);
			}
		}

		public void AddTransactionProcessor(ISentryTransactionProcessor processor)
		{
			TransactionProcessors.Add(processor);
		}

		public void AddTransactionProcessor(Func<SentryTransaction, SentryTransaction?> processor)
		{
			AddTransactionProcessor(new DelegateTransactionProcessor(processor));
		}

		public void AddTransactionProcessors(IEnumerable<ISentryTransactionProcessor> processors)
		{
			foreach (ISentryTransactionProcessor processor in processors)
			{
				TransactionProcessors.Add(processor);
			}
		}

		public void AddAttachment(Stream stream, string fileName, AttachmentType type = AttachmentType.Default, string? contentType = null)
		{
			if (!stream.TryGetLength().HasValue)
			{
				Options.LogWarning("Cannot evaluate the size of attachment '{0}' because the stream is not seekable.", fileName);
			}
			else
			{
				AddAttachment(new SentryAttachment(type, new StreamAttachmentContent(stream), fileName, contentType));
			}
		}

		public void AddAttachment(byte[] data, string fileName, AttachmentType type = AttachmentType.Default, string? contentType = null)
		{
			AddAttachment(new SentryAttachment(type, new ByteAttachmentContent(data), fileName, contentType));
		}

		public void AddAttachment(string filePath, AttachmentType type = AttachmentType.Default, string? contentType = null)
		{
			AddAttachment(new SentryAttachment(type, new FileAttachmentContent(filePath, Options.UseAsyncFileIO), Path.GetFileName(filePath), contentType));
		}

		internal void ResetTransaction(ITransactionTracer? expectedCurrentTransaction)
		{
			Interlocked.CompareExchange(ref _transaction, null, expectedCurrentTransaction);
		}
	}
}
