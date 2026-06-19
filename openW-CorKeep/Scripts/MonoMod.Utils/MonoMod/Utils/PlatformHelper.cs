using System;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;

namespace MonoMod.Utils
{
	public static class PlatformHelper
	{
		private static Platform _current = Platform.Unknown;

		private static bool _currentLocked = false;

		private static string _librarySuffix;

		public static Platform Current
		{
			get
			{
				if (!_currentLocked)
				{
					if (_current == Platform.Unknown)
					{
						DeterminePlatform();
					}
					_currentLocked = true;
				}
				return _current;
			}
			set
			{
				if (_currentLocked)
				{
					throw new InvalidOperationException("Cannot set the value of PlatformHelper.Current once it has been accessed.");
				}
				_current = value;
			}
		}

		public static string LibrarySuffix
		{
			get
			{
				if (_librarySuffix == null)
				{
					_librarySuffix = (Is(Platform.MacOS) ? "dylib" : (Is(Platform.Unix) ? "so" : "dll"));
				}
				return _librarySuffix;
			}
		}

		private static void DeterminePlatform()
		{
			_current = Platform.Unknown;
			string environmentVariable = Environment.GetEnvironmentVariable("windir");
			if (!string.IsNullOrEmpty(environmentVariable) && MultiTargetShims.IndexOf(environmentVariable, ':', StringComparison.Ordinal) == 1 && environmentVariable[0] != '/' && environmentVariable[0] != '\\' && Directory.Exists(environmentVariable))
			{
				_current = Platform.Windows;
			}
			else if (Directory.Exists("/etc/selinux"))
			{
				_current = Platform.Linux;
			}
			else if (File.Exists("/proc/sys/kernel/ostype"))
			{
				if (File.ReadAllText("/proc/sys/kernel/ostype").StartsWith("Linux", StringComparison.OrdinalIgnoreCase))
				{
					_current = Platform.Linux;
				}
				else
				{
					_current = Platform.Unix;
				}
			}
			else if (File.Exists("/System/Library/CoreServices/SystemVersion.plist"))
			{
				_current = Platform.MacOS;
			}
			if (_current != Platform.Unknown)
			{
				if (Is(Platform.Linux) && Directory.Exists("/data") && File.Exists("/system/build.prop"))
				{
					_current = Platform.Android;
				}
				else if (Is(Platform.Unix) && Directory.Exists("/Applications") && Directory.Exists("/System") && Directory.Exists("/User") && !Directory.Exists("/Users"))
				{
					_current = Platform.iOS;
				}
				else if (Is(Platform.Windows) && CheckWine())
				{
					_current |= Platform.Wine;
				}
			}
			MethodInfo methodInfo = typeof(Environment).GetProperty("Is64BitOperatingSystem")?.GetGetMethod();
			if (methodInfo != null)
			{
				_current |= (Platform)(((bool)methodInfo.Invoke(null, new object[0])) ? 2 : 0);
			}
			else
			{
				_current |= (Platform)((IntPtr.Size >= 8) ? 2 : 0);
			}
			if (RuntimeInformation.ProcessArchitecture.HasFlag(Architecture.Arm) || RuntimeInformation.OSArchitecture.HasFlag(Architecture.Arm))
			{
				_current |= Platform.ARM;
			}
		}

		public static bool Is(Platform platform)
		{
			return (Current & platform) == platform;
		}

		private static bool CheckWine()
		{
			string environmentVariable = Environment.GetEnvironmentVariable("MONOMOD_WINE");
			if (environmentVariable == "1")
			{
				return true;
			}
			if (environmentVariable == "0")
			{
				return false;
			}
			environmentVariable = Environment.GetEnvironmentVariable("XL_WINEONLINUX")?.ToLower(CultureInfo.InvariantCulture);
			if (environmentVariable == "true")
			{
				return true;
			}
			if (environmentVariable == "false")
			{
				return false;
			}
			IntPtr moduleHandle = GetModuleHandle("ntdll.dll");
			if (moduleHandle != IntPtr.Zero && GetProcAddress(moduleHandle, "wine_get_version") != IntPtr.Zero)
			{
				return true;
			}
			return false;
		}

		[DllImport("kernel32", SetLastError = true)]
		private static extern IntPtr GetModuleHandle(string lpModuleName);

		[DllImport("kernel32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
		private static extern IntPtr GetProcAddress(IntPtr hModule, string procName);
	}
}
