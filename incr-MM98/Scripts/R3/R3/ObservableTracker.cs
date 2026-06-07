using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using R3.Internal;

namespace R3
{
	public static class ObservableTracker
	{
		private static int trackingIdCounter = 0;

		public static bool EnableTracking = false;

		public static bool EnableStackTrace = false;

		private static readonly WeakDictionary<TrackableDisposable, TrackingState> tracking = new WeakDictionary<TrackableDisposable, TrackingState>();

		private static List<TrackingState> iterateCache = new List<TrackingState>();

		private static bool dirty;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[DebuggerStepThrough]
		internal static bool TryTrackActiveSubscription(IDisposable subscription, int skipFrame, [NotNullWhen(true)] out TrackableDisposable? trackableDisposable)
		{
			if (!EnableTracking)
			{
				trackableDisposable = null;
				return false;
			}
			return TryTrackActiveSubscriptionCore(subscription, skipFrame, out trackableDisposable);
		}

		[DebuggerStepThrough]
		internal static bool TryTrackActiveSubscriptionCore(IDisposable subscription, int skipFrame, [NotNullWhen(true)] out TrackableDisposable? trackableDisposable)
		{
			dirty = true;
			string stackTrace = "";
			if (EnableStackTrace)
			{
				stackTrace = new StackTrace(skipFrame, fNeedFileInfo: true).ToString();
			}
			IDisposable disposable = UnwrapTrackableDisposable(subscription);
			string formattedType;
			if (EnableStackTrace)
			{
				StringBuilder stringBuilder = new StringBuilder();
				TypeBeautify(disposable.GetType(), stringBuilder);
				formattedType = stringBuilder.ToString();
			}
			else
			{
				formattedType = disposable.GetType().Name;
			}
			int trackingId = Interlocked.Increment(ref trackingIdCounter);
			trackableDisposable = new TrackableDisposable(subscription, trackingId);
			tracking.TryAdd(trackableDisposable, new TrackingState(trackingId, formattedType, DateTime.Now, stackTrace));
			return true;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static void RemoveTracking(TrackableDisposable subscription)
		{
			if (EnableTracking)
			{
				dirty = true;
				tracking.TryRemove(subscription);
			}
		}

		public static bool CheckAndResetDirty()
		{
			bool result = dirty;
			dirty = false;
			return result;
		}

		public static void ForEachActiveTask(Action<TrackingState> action)
		{
			lock (iterateCache)
			{
				int num = tracking.CaptureSnapshot(ref iterateCache, clear: false);
				iterateCache.Sort(0, num, Comparer<TrackingState>.Default);
				try
				{
					for (int i = 0; i < num; i++)
					{
						action(iterateCache[i]);
					}
				}
				finally
				{
					iterateCache.Clear();
				}
			}
		}

		private static void TypeBeautify(Type type, StringBuilder sb)
		{
			if (type.IsNested)
			{
				sb.Append(type.DeclaringType.Name.ToString());
				sb.Append(".");
			}
			if (type.IsGenericType)
			{
				int num = type.Name.IndexOf("`");
				if (num != -1)
				{
					sb.Append(type.Name.Substring(0, num));
				}
				else
				{
					sb.Append(type.Name);
				}
				sb.Append("<");
				bool flag = true;
				Type[] genericArguments = type.GetGenericArguments();
				foreach (Type type2 in genericArguments)
				{
					if (!flag)
					{
						sb.Append(", ");
					}
					flag = false;
					TypeBeautify(type2, sb);
				}
				sb.Append(">");
			}
			else
			{
				sb.Append(type.Name);
			}
		}

		private static IDisposable UnwrapTrackableDisposable(IDisposable disposable)
		{
			while (disposable is TrackableDisposable trackableDisposable)
			{
				disposable = trackableDisposable.Disposable;
			}
			return disposable;
		}
	}
}
