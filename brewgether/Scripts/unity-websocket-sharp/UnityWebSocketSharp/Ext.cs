using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using UnityWebSocketSharp.Net;

namespace UnityWebSocketSharp
{
	internal static class Ext
	{
		[CompilerGenerated]
		private sealed class _003CSplitHeaderValue_003Ed__54 : IEnumerable<string>, IEnumerable, IEnumerator<string>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private string _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			private string value;

			public string _003C_003E3__value;

			private char[] separators;

			public char[] _003C_003E3__separators;

			private int _003Cend_003E5__2;

			private StringBuilder _003Cbuff_003E5__3;

			private bool _003Cescaped_003E5__4;

			private bool _003Cquoted_003E5__5;

			private int _003Ci_003E5__6;

			string IEnumerator<string>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CSplitHeaderValue_003Ed__54(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}

			[DebuggerHidden]
			IEnumerator<string> IEnumerable<string>.GetEnumerator()
			{
				return null;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
			}
		}

		[CompilerGenerated]
		private sealed class _003CTrimEach_003Ed__67 : IEnumerable<string>, IEnumerable, IEnumerator<string>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private string _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			private IEnumerable<string> source;

			public IEnumerable<string> _003C_003E3__source;

			private IEnumerator<string> _003C_003E7__wrap1;

			string IEnumerator<string>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CTrimEach_003Ed__67(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			private void _003C_003Em__Finally1()
			{
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}

			[DebuggerHidden]
			IEnumerator<string> IEnumerable<string>.GetEnumerator()
			{
				return null;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
			}
		}

		private static readonly byte[] _last;

		private static readonly int _maxRetry;

		private const string _tspecials = "()<>@,;:\\\"/[]?={} \t";

		private static byte[] compress(this byte[] data)
		{
			return null;
		}

		private static MemoryStream compress(this Stream stream)
		{
			return null;
		}

		private static byte[] compressToArray(this Stream stream)
		{
			return null;
		}

		private static byte[] decompress(this byte[] data)
		{
			return null;
		}

		private static MemoryStream decompress(this Stream stream)
		{
			return null;
		}

		private static byte[] decompressToArray(this Stream stream)
		{
			return null;
		}

		private static bool isPredefinedScheme(this string value)
		{
			return false;
		}

		internal static byte[] Append(this ushort code, string reason)
		{
			return null;
		}

		internal static byte[] Compress(this byte[] data, CompressionMethod method)
		{
			return null;
		}

		internal static Stream Compress(this Stream stream, CompressionMethod method)
		{
			return null;
		}

		internal static bool Contains(this string value, params char[] anyOf)
		{
			return false;
		}

		internal static bool Contains(this NameValueCollection collection, string name)
		{
			return false;
		}

		internal static bool Contains(this NameValueCollection collection, string name, string value, StringComparison comparisonTypeForValue)
		{
			return false;
		}

		internal static bool Contains<T>(this IEnumerable<T> source, Func<T, bool> condition)
		{
			return false;
		}

		internal static bool ContainsTwice(this string[] values)
		{
			return false;
		}

		internal static T[] Copy<T>(this T[] sourceArray, int length)
		{
			return null;
		}

		internal static T[] Copy<T>(this T[] sourceArray, long length)
		{
			return null;
		}

		internal static void CopyTo(this Stream sourceStream, Stream destinationStream, int bufferLength)
		{
		}

		internal static void CopyToAsync(this Stream sourceStream, Stream destinationStream, int bufferLength, Action completed, Action<Exception> error)
		{
		}

		internal static byte[] Decompress(this byte[] data, CompressionMethod method)
		{
			return null;
		}

		internal static Stream Decompress(this Stream stream, CompressionMethod method)
		{
			return null;
		}

		internal static byte[] DecompressToArray(this Stream stream, CompressionMethod method)
		{
			return null;
		}

		internal static void Emit(this EventHandler eventHandler, object sender, EventArgs e)
		{
		}

		internal static void Emit<TEventArgs>(this EventHandler<TEventArgs> eventHandler, object sender, TEventArgs e) where TEventArgs : EventArgs
		{
		}

		internal static string GetAbsolutePath(this Uri uri)
		{
			return null;
		}

		internal static UnityWebSocketSharp.Net.CookieCollection GetCookies(this NameValueCollection headers, bool response)
		{
			return null;
		}

		internal static string GetDnsSafeHost(this Uri uri, bool bracketIPv6)
		{
			return null;
		}

		internal static string GetErrorMessage(this ushort code)
		{
			return null;
		}

		internal static string GetErrorMessage(this CloseStatusCode code)
		{
			return null;
		}

		internal static string GetName(this string nameAndValue, char separator)
		{
			return null;
		}

		internal static string GetUTF8DecodedString(this byte[] bytes)
		{
			return null;
		}

		internal static byte[] GetUTF8EncodedBytes(this string s)
		{
			return null;
		}

		internal static string GetValue(this string nameAndValue, char separator)
		{
			return null;
		}

		internal static string GetValue(this string nameAndValue, char separator, bool unquote)
		{
			return null;
		}

		internal static bool IsCompressionExtension(this string value, CompressionMethod method)
		{
			return false;
		}

		internal static bool IsEqualTo(this int value, char c, Action<int> beforeComparing)
		{
			return false;
		}

		internal static bool IsHttpMethod(this string value)
		{
			return false;
		}

		internal static bool IsPortNumber(this int value)
		{
			return false;
		}

		internal static bool IsReserved(this CloseStatusCode code)
		{
			return false;
		}

		internal static bool IsReservedStatusCode(this ushort code)
		{
			return false;
		}

		internal static bool IsSupportedOpcode(this byte opcode)
		{
			return false;
		}

		internal static bool IsText(this string value)
		{
			return false;
		}

		internal static bool IsToken(this string value)
		{
			return false;
		}

		internal static bool KeepsAlive(this NameValueCollection headers, Version version)
		{
			return false;
		}

		internal static bool MaybeUri(this string value)
		{
			return false;
		}

		internal static string Quote(this string value)
		{
			return null;
		}

		internal static byte[] ReadBytes(this Stream stream, int length)
		{
			return null;
		}

		internal static byte[] ReadBytes(this Stream stream, long length, int bufferLength)
		{
			return null;
		}

		internal static void ReadBytesAsync(this Stream stream, int length, Action<byte[]> completed, Action<Exception> error)
		{
		}

		internal static void ReadBytesAsync(this Stream stream, long length, int bufferLength, Action<byte[]> completed, Action<Exception> error)
		{
		}

		internal static T[] Reverse<T>(this T[] array)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CSplitHeaderValue_003Ed__54))]
		internal static IEnumerable<string> SplitHeaderValue(this string value, params char[] separators)
		{
			return null;
		}

		internal static byte[] ToByteArray(this Stream stream)
		{
			return null;
		}

		internal static byte[] ToByteArray(this ushort value, ByteOrder order)
		{
			return null;
		}

		internal static byte[] ToByteArray(this ulong value, ByteOrder order)
		{
			return null;
		}

		internal static CompressionMethod ToCompressionMethod(this string value)
		{
			return default(CompressionMethod);
		}

		internal static string ToExtensionString(this CompressionMethod method, params string[] parameters)
		{
			return null;
		}

		internal static int ToInt32(this string numericString)
		{
			return 0;
		}

		internal static IPAddress ToIPAddress(this string value)
		{
			return null;
		}

		internal static List<TSource> ToList<TSource>(this IEnumerable<TSource> source)
		{
			return null;
		}

		internal static string ToString(this IPAddress address, bool bracketIPv6)
		{
			return null;
		}

		internal static ushort ToUInt16(this byte[] source, ByteOrder sourceOrder)
		{
			return 0;
		}

		internal static ulong ToUInt64(this byte[] source, ByteOrder sourceOrder)
		{
			return 0uL;
		}

		internal static Version ToVersion(this string versionString)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CTrimEach_003Ed__67))]
		internal static IEnumerable<string> TrimEach(this IEnumerable<string> source)
		{
			return null;
		}

		internal static string TrimSlashFromEnd(this string value)
		{
			return null;
		}

		internal static string TrimSlashOrBackslashFromEnd(this string value)
		{
			return null;
		}

		internal static bool TryCreateVersion(this string versionString, out Version result)
		{
			result = null;
			return false;
		}

		internal static bool TryCreateWebSocketUri(this string uriString, out Uri result, out string message)
		{
			result = null;
			message = null;
			return false;
		}

		internal static bool TryGetUTF8DecodedString(this byte[] bytes, out string s)
		{
			s = null;
			return false;
		}

		internal static bool TryGetUTF8EncodedBytes(this string s, out byte[] bytes)
		{
			bytes = null;
			return false;
		}

		internal static bool TryOpenRead(this FileInfo fileInfo, out FileStream fileStream)
		{
			fileStream = null;
			return false;
		}

		internal static string Unquote(this string value)
		{
			return null;
		}

		internal static bool Upgrades(this NameValueCollection headers, string protocol)
		{
			return false;
		}

		internal static string UrlDecode(this string value, Encoding encoding)
		{
			return null;
		}

		internal static string UrlEncode(this string value, Encoding encoding)
		{
			return null;
		}

		internal static void WriteBytes(this Stream stream, byte[] bytes, int bufferLength)
		{
		}

		internal static void WriteBytesAsync(this Stream stream, byte[] bytes, int bufferLength, Action completed, Action<Exception> error)
		{
		}

		public static string GetDescription(this UnityWebSocketSharp.Net.HttpStatusCode code)
		{
			return null;
		}

		public static string GetStatusDescription(this int code)
		{
			return null;
		}

		public static bool IsCloseStatusCode(this ushort value)
		{
			return false;
		}

		public static bool IsEnclosedIn(this string value, char c)
		{
			return false;
		}

		public static bool IsHostOrder(this ByteOrder order)
		{
			return false;
		}

		public static bool IsLocal(this IPAddress address)
		{
			return false;
		}

		public static bool IsNullOrEmpty(this string value)
		{
			return false;
		}

		public static T[] SubArray<T>(this T[] array, int startIndex, int length)
		{
			return null;
		}

		public static T[] SubArray<T>(this T[] array, long startIndex, long length)
		{
			return null;
		}

		public static void Times(this int n, Action<int> action)
		{
		}

		public static void Times(this long n, Action<long> action)
		{
		}

		public static byte[] ToHostOrder(this byte[] source, ByteOrder sourceOrder)
		{
			return null;
		}

		public static string ToString<T>(this T[] array, string separator)
		{
			return null;
		}

		public static Uri ToUri(this string value)
		{
			return null;
		}
	}
}
