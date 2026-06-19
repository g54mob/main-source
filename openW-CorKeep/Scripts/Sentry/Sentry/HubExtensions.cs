using System;
using System.Collections.Generic;
using System.ComponentModel;
using Sentry.Extensibility;
using Sentry.Infrastructure;
using Sentry.Internal;
using Sentry.Internal.Extensions;

namespace Sentry
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static class HubExtensions
	{
		private sealed class LockedScope : IDisposable
		{
			private readonly IDisposable _scope;

			public LockedScope(IHub hub)
			{
				_scope = hub.PushScope();
				hub.LockScope();
			}

			public void Dispose()
			{
				_scope.Dispose();
			}
		}

		public static ITransactionTracer StartTransaction(this IHub hub, ITransactionContext context)
		{
			return hub.StartTransaction(context, new Dictionary<string, object>());
		}

		public static ITransactionTracer StartTransaction(this IHub hub, string name, string operation)
		{
			return hub.StartTransaction(new TransactionContext(name, operation));
		}

		public static ITransactionTracer StartTransaction(this IHub hub, string name, string operation, string? description)
		{
			ITransactionTracer transactionTracer = hub.StartTransaction(name, operation);
			transactionTracer.Description = description;
			return transactionTracer;
		}

		public static ITransactionTracer StartTransaction(this IHub hub, string name, string operation, SentryTraceHeader traceHeader)
		{
			return hub.StartTransaction(new TransactionContext(name, operation, traceHeader));
		}

		public static void AddBreadcrumb(this IHub hub, string message, string? category = null, string? type = null, IDictionary<string, string>? data = null, BreadcrumbLevel level = BreadcrumbLevel.Info)
		{
			if (!hub.IsNull())
			{
				hub.AddBreadcrumb(null, message, category, type, (data != null) ? new Dictionary<string, string>(data) : null, level);
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static void AddBreadcrumb(this IHub hub, ISystemClock? clock, string message, string? category = null, string? type = null, IDictionary<string, string>? data = null, BreadcrumbLevel level = BreadcrumbLevel.Info)
		{
			if (!hub.IsNull())
			{
				Breadcrumb breadcrumb = new Breadcrumb((clock ?? SystemClock.Clock).GetUtcNow(), message, type, (data != null) ? new Dictionary<string, string>(data) : null, category, level);
				hub.AddBreadcrumb(breadcrumb);
			}
		}

		public static void AddBreadcrumb(this IHub hub, Breadcrumb breadcrumb, SentryHint? hint = null)
		{
			if (!hub.IsNull())
			{
				hub.ConfigureScope(delegate(Scope s)
				{
					s.AddBreadcrumb(breadcrumb, hint ?? new SentryHint());
				});
			}
		}

		public static IDisposable PushAndLockScope(this IHub hub)
		{
			return new LockedScope(hub);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static void LockScope(this IHub hub)
		{
			hub.ConfigureScope(delegate(Scope c)
			{
				c.Locked = true;
			});
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public static void UnlockScope(this IHub hub)
		{
			hub.ConfigureScope(delegate(Scope c)
			{
				c.Locked = false;
			});
		}

		internal static SentryId CaptureExceptionInternal(this IHub hub, Exception ex)
		{
			return hub.CaptureEvent(new SentryEvent(ex));
		}

		public static SentryId CaptureException(this IHub hub, Exception ex, Action<Scope> configureScope)
		{
			return hub.CaptureEvent(new SentryEvent(ex), configureScope);
		}

		public static SentryId CaptureMessage(this IHub hub, string message, Action<Scope> configureScope, SentryLevel level = SentryLevel.Info)
		{
			if (string.IsNullOrWhiteSpace(message))
			{
				return default(SentryId);
			}
			SentryEvent evt = new SentryEvent
			{
				Message = message,
				Level = level
			};
			return hub.CaptureEvent(evt, configureScope);
		}

		internal static ITransactionTracer StartTransaction(this IHub hub, ITransactionContext context, IReadOnlyDictionary<string, object?> customSamplingContext, DynamicSamplingContext? dynamicSamplingContext)
		{
			if (!(hub is Hub hub2))
			{
				if (hub is HubAdapter hubAdapter)
				{
					return hubAdapter.StartTransaction(context, customSamplingContext, dynamicSamplingContext);
				}
				return hub.StartTransaction(context, customSamplingContext);
			}
			return hub2.StartTransaction(context, customSamplingContext, dynamicSamplingContext);
		}

		internal static ITransactionTracer? GetTransaction(this IHub hub)
		{
			ITransactionTracer transaction = null;
			hub.ConfigureScope(delegate(Scope scope)
			{
				transaction = scope.Transaction;
			});
			return transaction;
		}

		internal static ITransactionTracer? GetTransactionIfSampled(this IHub hub)
		{
			ITransactionTracer transaction = hub.GetTransaction();
			if (transaction == null || transaction.IsSampled != true)
			{
				return null;
			}
			return transaction;
		}
	}
}
