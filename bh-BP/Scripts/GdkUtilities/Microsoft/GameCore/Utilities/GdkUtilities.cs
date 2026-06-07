using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Microsoft.GameCore.Utilities
{
	public class GdkUtilities
	{
		private static class RegUtil
		{
			[Flags]
			private enum RegSAM : uint
			{
				QUERY_VALUE = 1u,
				WOW64_64KEY = 0x100u,
				QUERY64 = 0x101u
			}

			public const uint HKEY_LOCAL_MACHINE = 2147483650u;

			private const uint FORMAT_MESSAGE_FROM_SYSTEM = 4096u;

			public static string GetRegKey(uint inHive, string inKeyName, string inPropertyName)
			{
				return null;
			}

			[PreserveSig]
			private static extern uint RegCreateKeyEx(uint hKey, string lpSubKey, uint reserved, string lpClass, uint dwOptions, uint samDesired, uint lpSecurityAttributes, out uint phkResult, out uint lpdwDisposition);

			[PreserveSig]
			private static extern uint RegCloseKey(uint hKey);

			[PreserveSig]
			private static extern uint RegQueryValueEx(uint hKey, string lpValueName, uint lpReserved, ref uint lpType, StringBuilder lpData, ref uint lpcbData);

			[PreserveSig]
			private static extern uint FormatMessage(uint dwFlags, uint lpSource, uint dwMessageId, uint dwLanguageId, StringBuilder lpBuffer, uint nSize, uint arguments);

			private static string FormatMessage(uint dwMessageId)
			{
				return null;
			}
		}

		private static string _gdkVersion;

		private static string _xsapiLibPath;

		private static string _xCurlLibPath;

		private static string _httpClientPath;

		private static string _gdkToolsPath;

		private static string _pluginDllPath;

		private static string _rootPluginPath;

		private static string _gameConfigPath;

		public static string XsapiLibName => null;

		public static string XCurlLibName => null;

		public static string HttpClientName => null;

		public static string GdkToolsPath => null;

		public static string GdkVersion => null;

		public static string XsapiLibPath => null;

		public static string XCurlLibPath => null;

		public static string HttpClientPath => null;

		public static string RootPluginPath => null;

		public static string PluginDllPath => null;

		public static string GameConfigPath => null;

		public static void PullGdkDlls()
		{
		}
	}
}
