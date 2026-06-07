using System;
using System.Runtime.InteropServices;
using System.Security;
using Microsoft.Win32;

namespace NUnit.Framework.Internal
{
	[SecuritySafeCritical]
	public class OSPlatform
	{
		public enum ProductType
		{
			Unknown = 0,
			WorkStation = 1,
			DomainController = 2,
			Server = 3
		}

		private struct OSVERSIONINFOEX
		{
			public uint dwOSVersionInfoSize;

			public readonly uint dwMajorVersion;

			public readonly uint dwMinorVersion;

			public readonly uint dwBuildNumber;

			public readonly uint dwPlatformId;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
			public readonly string szCSDVersion;

			public readonly short wServicePackMajor;

			public readonly short wServicePackMinor;

			public readonly short wSuiteMask;

			public readonly byte ProductType;

			public readonly byte Reserved;
		}

		private readonly PlatformID _platform;

		private readonly Version _version;

		private readonly ProductType _product;

		private static readonly Lazy<OSPlatform> currentPlatform = new Lazy<OSPlatform>(delegate
		{
			OperatingSystem operatingSystem = Environment.OSVersion;
			if (operatingSystem.Platform == PlatformID.Win32NT && operatingSystem.Version.Major >= 5)
			{
				OSVERSIONINFOEX osvi = default(OSVERSIONINFOEX);
				osvi.dwOSVersionInfoSize = (uint)Marshal.SizeOf((object)osvi);
				GetVersionEx(ref osvi);
				if (operatingSystem.Version.Major == 6 && operatingSystem.Version.Minor >= 2)
				{
					operatingSystem = new OperatingSystem(operatingSystem.Platform, GetWindows81PlusVersion(operatingSystem.Version));
				}
				return new OSPlatform(operatingSystem.Platform, operatingSystem.Version, (ProductType)osvi.ProductType);
			}
			return CheckIfIsMacOSX(operatingSystem.Platform) ? new OSPlatform(PlatformID.MacOSX, operatingSystem.Version) : new OSPlatform(operatingSystem.Platform, operatingSystem.Version);
		});

		public static readonly PlatformID UnixPlatformID_Microsoft = PlatformID.Unix;

		public static readonly PlatformID UnixPlatformID_Mono = (PlatformID)128;

		public static readonly PlatformID XBoxPlatformID = PlatformID.Xbox;

		public static readonly PlatformID MacOSXPlatformID = PlatformID.MacOSX;

		public static OSPlatform CurrentPlatform => currentPlatform.Value;

		public PlatformID Platform => _platform;

		public Version Version => _version;

		public ProductType Product => _product;

		public bool IsWindows => _platform == PlatformID.Win32NT || _platform == PlatformID.Win32Windows || _platform == PlatformID.Win32S || _platform == PlatformID.WinCE;

		public bool IsUnix => _platform == UnixPlatformID_Microsoft || _platform == UnixPlatformID_Mono;

		public bool IsWin32S => _platform == PlatformID.Win32S;

		public bool IsWin32Windows => _platform == PlatformID.Win32Windows;

		public bool IsWin32NT => _platform == PlatformID.Win32NT;

		public bool IsWinCE => _platform == PlatformID.WinCE;

		public bool IsXbox => _platform == XBoxPlatformID;

		public bool IsMacOSX => _platform == MacOSXPlatformID;

		public bool IsWin95 => _platform == PlatformID.Win32Windows && _version.Major == 4 && _version.Minor == 0;

		public bool IsWin98 => _platform == PlatformID.Win32Windows && _version.Major == 4 && _version.Minor == 10;

		public bool IsWinME => _platform == PlatformID.Win32Windows && _version.Major == 4 && _version.Minor == 90;

		public bool IsNT3 => _platform == PlatformID.Win32NT && _version.Major == 3;

		public bool IsNT4 => _platform == PlatformID.Win32NT && _version.Major == 4;

		public bool IsNT5 => _platform == PlatformID.Win32NT && _version.Major == 5;

		public bool IsWin2K => IsNT5 && _version.Minor == 0;

		public bool IsWinXP => IsNT5 && (_version.Minor == 1 || (_version.Minor == 2 && Product == ProductType.WorkStation));

		public bool IsWin2003Server => IsNT5 && _version.Minor == 2 && Product == ProductType.Server;

		public bool IsNT6 => _platform == PlatformID.Win32NT && _version.Major == 6;

		public bool IsNT60 => IsNT6 && _version.Minor == 0;

		public bool IsNT61 => IsNT6 && _version.Minor == 1;

		public bool IsNT62 => IsNT6 && _version.Minor == 2;

		public bool IsNT63 => IsNT6 && _version.Minor == 3;

		public bool IsVista => IsNT60 && Product == ProductType.WorkStation;

		public bool IsWin2008Server => IsWin2008ServerR1 || IsWin2008ServerR2;

		public bool IsWin2008ServerR1 => IsNT60 && Product == ProductType.Server;

		public bool IsWin2008ServerR2 => IsNT61 && Product == ProductType.Server;

		public bool IsWin2012Server => IsWin2012ServerR1 || IsWin2012ServerR2;

		public bool IsWin2012ServerR1 => IsNT62 && Product == ProductType.Server;

		public bool IsWin2012ServerR2 => IsNT63 && Product == ProductType.Server;

		public bool IsWindows7 => IsNT61 && Product == ProductType.WorkStation;

		public bool IsWindows8 => IsNT62 && Product == ProductType.WorkStation;

		public bool IsWindows81 => IsNT63 && Product == ProductType.WorkStation;

		public bool IsWindows10 => _platform == PlatformID.Win32NT && _version.Major == 10 && Product == ProductType.WorkStation;

		public bool IsWindowsServer10 => _platform == PlatformID.Win32NT && _version.Major == 10 && Product == ProductType.Server;

		private static Version GetWindows81PlusVersion(Version version)
		{
			try
			{
				using RegistryKey registryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion");
				if (registryKey != null)
				{
					string s = registryKey.GetValue("CurrentBuildNumber") as string;
					int result = 0;
					int.TryParse(s, out result);
					int? num = registryKey.GetValue("CurrentMajorVersionNumber") as int?;
					int? num2 = registryKey.GetValue("CurrentMinorVersionNumber") as int?;
					if (num.HasValue && num2.HasValue)
					{
						return new Version(num.Value, num2.Value, result);
					}
					string text = registryKey.GetValue("CurrentVersion") as string;
					if (text == "6.3")
					{
						return new Version(6, 3, result);
					}
				}
			}
			catch (Exception)
			{
			}
			return version;
		}

		[DllImport("Kernel32.dll")]
		private static extern bool GetVersionEx(ref OSVERSIONINFOEX osvi);

		public OSPlatform(PlatformID platform, Version version)
		{
			_platform = platform;
			_version = version;
		}

		public OSPlatform(PlatformID platform, Version version, ProductType product)
			: this(platform, version)
		{
			_product = product;
		}

		[DllImport("libc")]
		private static extern int uname(IntPtr buf);

		private static bool CheckIfIsMacOSX(PlatformID platform)
		{
			switch (platform)
			{
			case PlatformID.MacOSX:
				return true;
			default:
				return false;
			case PlatformID.Unix:
			{
				IntPtr intPtr = Marshal.AllocHGlobal(8192);
				bool result = false;
				if (uname(intPtr) == 0)
				{
					string text = Marshal.PtrToStringAnsi(intPtr);
					result = text.Equals("Darwin");
				}
				Marshal.FreeHGlobal(intPtr);
				return result;
			}
			}
		}
	}
}
