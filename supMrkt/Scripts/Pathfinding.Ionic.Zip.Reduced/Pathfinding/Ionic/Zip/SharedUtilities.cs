using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace Pathfinding.Ionic.Zip
{
	internal static class SharedUtilities
	{
		private static Regex doubleDotRegex1;

		private static Encoding ibm437;

		private static Encoding utf8;

		public static long GetFileLength(string fileName)
		{
			return 0L;
		}

		[Conditional("NETCF")]
		public static void Workaround_Ladybug318918(Stream s)
		{
		}

		private static string SimplifyFwdSlashPath(string path)
		{
			return null;
		}

		public static string NormalizePathForUseInZipFile(string pathName)
		{
			return null;
		}

		internal static byte[] StringToByteArray(string value, Encoding encoding)
		{
			return null;
		}

		internal static byte[] StringToByteArray(string value)
		{
			return null;
		}

		internal static string Utf8StringFromBuffer(byte[] buf)
		{
			return null;
		}

		internal static string StringFromBuffer(byte[] buf, Encoding encoding)
		{
			return null;
		}

		internal static int ReadSignature(Stream s)
		{
			return 0;
		}

		internal static int ReadEntrySignature(Stream s)
		{
			return 0;
		}

		internal static int ReadInt(Stream s)
		{
			return 0;
		}

		private static int _ReadFourBytes(Stream s, string message)
		{
			return 0;
		}

		internal static long FindSignature(Stream stream, int SignatureToFind)
		{
			return 0L;
		}

		internal static DateTime AdjustTime_Reverse(DateTime time)
		{
			return default(DateTime);
		}

		internal static DateTime PackedToDateTime(int packedDateTime)
		{
			return default(DateTime);
		}

		internal static int DateTimeToPacked(DateTime time)
		{
			return 0;
		}

		public static void CreateAndOpenUniqueTempFile(string dir, out Stream fs, out string filename)
		{
			fs = null;
			filename = null;
		}

		public static string InternalGetTempFileName()
		{
			return null;
		}

		internal static string GenerateRandomStringImpl(int length, int delta)
		{
			return null;
		}

		internal static int ReadWithRetry(Stream s, byte[] buffer, int offset, int count, string FileName)
		{
			return 0;
		}

		private static uint _HRForException(Exception ex1)
		{
			return 0u;
		}
	}
}
