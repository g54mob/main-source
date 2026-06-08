using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Text;
using Amazon.Runtime.Internal.Util;

namespace Amazon.Runtime.Internal.Settings
{
	public static class UserCrypto
	{
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		private struct DATA_BLOB
		{
			public int cbData;

			public IntPtr pbData;
		}

		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		private struct CRYPTPROTECT_PROMPTSTRUCT
		{
			public int cbSize;

			public CryptProtectPromptFlags dwPromptFlags;

			public IntPtr hwndApp;

			public string szPrompt;
		}

		[Flags]
		private enum CryptProtectPromptFlags
		{
			CRYPTPROTECT_PROMPT_ON_UNPROTECT = 1,
			CRYPTPROTECT_PROMPT_ON_PROTECT = 2
		}

		[Flags]
		private enum CryptProtectFlags
		{
			CRYPTPROTECT_UI_FORBIDDEN = 1,
			CRYPTPROTECT_LOCAL_MACHINE = 4,
			CRYPTPROTECT_CRED_SYNC = 8,
			CRYPTPROTECT_AUDIT = 0x10,
			CRYPTPROTECT_NO_RECOVERY = 0x20,
			CRYPTPROTECT_VERIFY_PROTECTION = 0x40
		}

		private static bool? _isUserCryptAvailable;

		public static bool IsUserCryptAvailable
		{
			get
			{
				if (!_isUserCryptAvailable.HasValue)
				{
					try
					{
						Encrypt("test");
						_isUserCryptAvailable = true;
					}
					catch (Exception ex)
					{
						Logger.GetLogger(typeof(UserCrypto)).InfoFormat("UserCrypto is not supported.  This may be due to use of a non-Windows operating system or Windows Nano Server, or the current user account may not have its profile loaded. {0}", ex.Message);
						_isUserCryptAvailable = false;
					}
				}
				return _isUserCryptAvailable.Value;
			}
		}

		public static string Decrypt(string encrypted)
		{
			List<byte> list = new List<byte>();
			for (int i = 0; i < encrypted.Length; i += 2)
			{
				byte item = Convert.ToByte(encrypted.Substring(i, 2), 16);
				list.Add(item);
			}
			CryptProtectFlags dwFlags = CryptProtectFlags.CRYPTPROTECT_UI_FORBIDDEN;
			DATA_BLOB pDataIn = ConvertData(list.ToArray());
			DATA_BLOB pDataOut = default(DATA_BLOB);
			DATA_BLOB pOptionalEntropy = default(DATA_BLOB);
			try
			{
				CRYPTPROTECT_PROMPTSTRUCT pPromptStruct = default(CRYPTPROTECT_PROMPTSTRUCT);
				if (!CryptUnprotectData(ref pDataIn, "psw", ref pOptionalEntropy, IntPtr.Zero, ref pPromptStruct, dwFlags, ref pDataOut))
				{
					throw new AmazonClientException("CryptProtectData failed. Error Code: " + Marshal.GetLastWin32Error());
				}
				byte[] array = new byte[pDataOut.cbData];
				Marshal.Copy(pDataOut.pbData, array, 0, array.Length);
				return Encoding.Unicode.GetString(array);
			}
			finally
			{
				if (pDataIn.pbData != IntPtr.Zero)
				{
					Marshal.FreeHGlobal(pDataIn.pbData);
				}
				if (pDataOut.pbData != IntPtr.Zero)
				{
					Marshal.FreeHGlobal(pDataOut.pbData);
				}
			}
		}

		public static string Encrypt(string unencrypted)
		{
			CryptProtectFlags dwFlags = CryptProtectFlags.CRYPTPROTECT_UI_FORBIDDEN;
			DATA_BLOB pDataIn = ConvertData(Encoding.Unicode.GetBytes(unencrypted));
			DATA_BLOB pDataOut = default(DATA_BLOB);
			DATA_BLOB pOptionalEntropy = default(DATA_BLOB);
			try
			{
				CRYPTPROTECT_PROMPTSTRUCT pPromptStruct = default(CRYPTPROTECT_PROMPTSTRUCT);
				if (!CryptProtectData(ref pDataIn, "psw", ref pOptionalEntropy, IntPtr.Zero, ref pPromptStruct, dwFlags, ref pDataOut))
				{
					throw new AmazonClientException("CryptProtectData failed. Error Code: " + Marshal.GetLastWin32Error());
				}
				byte[] array = new byte[pDataOut.cbData];
				Marshal.Copy(pDataOut.pbData, array, 0, array.Length);
				StringBuilder stringBuilder = new StringBuilder();
				for (int i = 0; i <= array.Length - 1; i++)
				{
					stringBuilder.Append(Convert.ToString(array[i], 16).PadLeft(2, '0').ToUpper(CultureInfo.InvariantCulture));
				}
				return stringBuilder.ToString().ToUpper(CultureInfo.InvariantCulture);
			}
			finally
			{
				if (pDataIn.pbData != IntPtr.Zero)
				{
					Marshal.FreeHGlobal(pDataIn.pbData);
				}
				if (pDataOut.pbData != IntPtr.Zero)
				{
					Marshal.FreeHGlobal(pDataOut.pbData);
				}
			}
		}

		private static DATA_BLOB ConvertData(byte[] data)
		{
			DATA_BLOB result = new DATA_BLOB
			{
				pbData = Marshal.AllocHGlobal(data.Length),
				cbData = data.Length
			};
			Marshal.Copy(data, 0, result.pbData, data.Length);
			return result;
		}

		[DllImport("Crypt32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool CryptProtectData(ref DATA_BLOB pDataIn, string szDataDescr, ref DATA_BLOB pOptionalEntropy, IntPtr pvReserved, ref CRYPTPROTECT_PROMPTSTRUCT pPromptStruct, CryptProtectFlags dwFlags, ref DATA_BLOB pDataOut);

		[DllImport("Crypt32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool CryptUnprotectData(ref DATA_BLOB pDataIn, string szDataDescr, ref DATA_BLOB pOptionalEntropy, IntPtr pvReserved, ref CRYPTPROTECT_PROMPTSTRUCT pPromptStruct, CryptProtectFlags dwFlags, ref DATA_BLOB pDataOut);
	}
}
