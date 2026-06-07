using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using MessagePipe.Internal;

namespace MessagePipe
{
	[Preserve]
	public sealed class MessagePipeDiagnosticsInfo
	{
		private static readonly ILookup<string, StackTraceInfo> EmptyLookup = Array.Empty<StackTraceInfo>().ToLookup((StackTraceInfo _) => "", (StackTraceInfo x) => x);

		private int subscribeCount;

		private bool dirty;

		private MessagePipeOptions options;

		private object gate = new object();

		private Dictionary<IHandlerHolderMarker, Dictionary<IDisposable, StackTraceInfo>> capturedStackTraces = new Dictionary<IHandlerHolderMarker, Dictionary<IDisposable, StackTraceInfo>>();

		public int SubscribeCount => subscribeCount;

		internal MessagePipeOptions MessagePipeOptions => options;

		internal bool CheckAndResetDirty()
		{
			bool result = dirty;
			dirty = false;
			return result;
		}

		public StackTraceInfo[] GetCapturedStackTraces(bool ascending = true)
		{
			if (!options.EnableCaptureStackTrace)
			{
				return Array.Empty<StackTraceInfo>();
			}
			lock (gate)
			{
				IEnumerable<StackTraceInfo> source = capturedStackTraces.SelectMany((KeyValuePair<IHandlerHolderMarker, Dictionary<IDisposable, StackTraceInfo>> x) => x.Value.Values);
				source = (ascending ? source.OrderBy((StackTraceInfo x) => x.Id) : source.OrderByDescending((StackTraceInfo x) => x.Id));
				return source.ToArray();
			}
		}

		public ILookup<string, StackTraceInfo> GetGroupedByCaller(bool ascending = true)
		{
			if (!options.EnableCaptureStackTrace)
			{
				return EmptyLookup;
			}
			lock (gate)
			{
				IEnumerable<StackTraceInfo> source = capturedStackTraces.SelectMany((KeyValuePair<IHandlerHolderMarker, Dictionary<IDisposable, StackTraceInfo>> x) => x.Value.Values);
				source = (ascending ? source.OrderBy((StackTraceInfo x) => x.Id) : source.OrderByDescending((StackTraceInfo x) => x.Id));
				return source.ToLookup((StackTraceInfo x) => x.Head);
			}
		}

		[Preserve]
		public MessagePipeDiagnosticsInfo(MessagePipeOptions options)
		{
			this.options = options;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal void IncrementSubscribe(IHandlerHolderMarker handlerHolder, IDisposable subscription)
		{
			Interlocked.Increment(ref subscribeCount);
			if (options.EnableCaptureStackTrace)
			{
				AddStackTrace(handlerHolder, subscription);
			}
			dirty = true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void AddStackTrace(IHandlerHolderMarker handlerHolder, IDisposable subscription)
		{
			lock (gate)
			{
				if (!capturedStackTraces.TryGetValue(handlerHolder, out var value))
				{
					value = new Dictionary<IDisposable, StackTraceInfo>();
					capturedStackTraces[handlerHolder] = value;
				}
				value.Add(subscription, new StackTraceInfo(new StackTrace(fNeedFileInfo: true)));
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal void DecrementSubscribe(IHandlerHolderMarker handlerHolder, IDisposable subscription)
		{
			Interlocked.Decrement(ref subscribeCount);
			if (options.EnableCaptureStackTrace)
			{
				RemoveStackTrace(handlerHolder, subscription);
			}
			dirty = true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void RemoveStackTrace(IHandlerHolderMarker handlerHolder, IDisposable subscription)
		{
			lock (gate)
			{
				if (capturedStackTraces.TryGetValue(handlerHolder, out var value))
				{
					value.Remove(subscription);
				}
			}
		}

		internal void RemoveTargetDiagnostics(IHandlerHolderMarker targetHolder, int removeCount)
		{
			Interlocked.Add(ref subscribeCount, -removeCount);
			if (options.EnableCaptureStackTrace)
			{
				lock (gate)
				{
					capturedStackTraces.Remove(targetHolder);
				}
			}
			dirty = true;
		}
	}
}
