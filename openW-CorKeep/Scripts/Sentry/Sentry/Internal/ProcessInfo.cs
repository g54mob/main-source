using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Sentry.Extensibility;

namespace Sentry.Internal
{
	internal class ProcessInfo
	{
		internal static ProcessInfo? Instance;

		private volatile Task _preciseAppStartupTask = Task.CompletedTask;

		private int? _id;

		internal DateTimeOffset? StartupTime { get; private set; }

		internal DateTimeOffset? BootTime { get; }

		internal Task PreciseAppStartupTask
		{
			get
			{
				return _preciseAppStartupTask;
			}
			private set
			{
				_preciseAppStartupTask = value;
			}
		}

		public int? GetId(SentryOptions options)
		{
			return _id ?? (_id = GetCurrentProcessId(options));
		}

		private int? GetCurrentProcessId(SentryOptions options)
		{
			try
			{
				return Process.GetCurrentProcess().Id;
			}
			catch (Exception exception)
			{
				options.LogError(exception, "Error getting current process Id");
				return null;
			}
		}

		internal ProcessInfo(SentryOptions options, Func<DateTimeOffset>? findPreciseStartupTime = null)
		{
			ProcessInfo processInfo = this;
			if (options.DetectStartupTime == StartupTimeDetectionMode.None)
			{
				options.LogDebug("Not detecting startup time due to option: {0}", options.DetectStartupTime);
				return;
			}
			DateTimeOffset utcNow = DateTimeOffset.UtcNow;
			StartupTime = utcNow;
			long? arg = 0L;
			try
			{
				arg = Stopwatch.GetTimestamp();
				BootTime = utcNow.AddTicks(-arg.Value / (Stopwatch.Frequency / 10000000));
			}
			catch (Exception exception)
			{
				options.LogError(exception, "Failed to find BootTime: Now {0}, GetTimestamp {1}, Frequency {2}, TicksPerSecond: {3}", utcNow, arg, Stopwatch.Frequency, 10000000L);
			}
			if (options.DetectStartupTime != StartupTimeDetectionMode.Best)
			{
				return;
			}
			Func<DateTimeOffset> preciseStartupTimeFunc = findPreciseStartupTime ?? new Func<DateTimeOffset>(GetStartupTime);
			PreciseAppStartupTask = Task.Run(delegate
			{
				try
				{
					processInfo.StartupTime = preciseStartupTimeFunc();
				}
				catch (Exception exception2)
				{
					options.LogError(exception2, "Failure getting precise App startup time.");
				}
			}).ContinueWith((Task _) => processInfo.PreciseAppStartupTask = Task.CompletedTask);
		}

		private static DateTimeOffset GetStartupTime()
		{
			using Process process = Process.GetCurrentProcess();
			return process.StartTime.ToUniversalTime();
		}

		public bool? ApplicationIsActivated(SentryOptions options)
		{
			try
			{
				if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
				{
					IntPtr foregroundWindow = GetForegroundWindow();
					if (foregroundWindow == IntPtr.Zero)
					{
						return false;
					}
					int? num = Instance?.GetId(options);
					GetWindowThreadProcessId(foregroundWindow, out var processId);
					return processId == num;
				}
			}
			catch (Exception exception)
			{
				options.LogError(exception, "Error getting foreground window state.");
			}
			return null;
		}

		[DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
		private static extern IntPtr GetForegroundWindow();

		[DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true, SetLastError = true)]
		private static extern int GetWindowThreadProcessId(IntPtr handle, out int processId);
	}
}
