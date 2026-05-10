using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Google.Protobuf
{
	[DebuggerDisplay("Length = {Length}")]
	[DebuggerTypeProxy(typeof(ByteStringDebugView))]
	public sealed class ByteString : IEnumerable<byte>, IEnumerable, IEquatable<ByteString>
	{
		private sealed class ByteStringDebugView
		{
			private readonly ByteString data;

			[DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
			public byte[] Items => null;

			public ByteStringDebugView(ByteString data)
			{
			}
		}

		private static readonly ByteString empty;

		private readonly ReadOnlyMemory<byte> bytes;

		public static ByteString Empty => null;

		public int Length => 0;

		public bool IsEmpty => false;

		public ReadOnlySpan<byte> Span => default(ReadOnlySpan<byte>);

		public ReadOnlyMemory<byte> Memory => default(ReadOnlyMemory<byte>);

		public byte this[int index] => 0;

		internal static ByteString AttachBytes(ReadOnlyMemory<byte> bytes)
		{
			return null;
		}

		internal static ByteString AttachBytes(byte[] bytes)
		{
			return null;
		}

		private ByteString(ReadOnlyMemory<byte> bytes)
		{
		}

		public byte[] ToByteArray()
		{
			return null;
		}

		public string ToBase64()
		{
			return null;
		}

		public static ByteString FromBase64(string bytes)
		{
			return null;
		}

		public static ByteString FromStream(Stream stream)
		{
			return null;
		}

		public static Task<ByteString> FromStreamAsync(Stream stream, CancellationToken cancellationToken = default(CancellationToken))
		{
			return null;
		}

		public static ByteString CopyFrom(params byte[] bytes)
		{
			return null;
		}

		public static ByteString CopyFrom(byte[] bytes, int offset, int count)
		{
			return null;
		}

		public static ByteString CopyFrom(ReadOnlySpan<byte> bytes)
		{
			return null;
		}

		public static ByteString CopyFrom(string text, Encoding encoding)
		{
			return null;
		}

		public static ByteString CopyFromUtf8(string text)
		{
			return null;
		}

		public string ToString(Encoding encoding)
		{
			return null;
		}

		public string ToStringUtf8()
		{
			return null;
		}

		public IEnumerator<byte> GetEnumerator()
		{
			return null;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return null;
		}

		public CodedInputStream CreateCodedInput()
		{
			return null;
		}

		public static bool operator ==(ByteString lhs, ByteString rhs)
		{
			return false;
		}

		public static bool operator !=(ByteString lhs, ByteString rhs)
		{
			return false;
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public bool Equals(ByteString other)
		{
			return false;
		}

		public void CopyTo(byte[] array, int position)
		{
		}

		public void WriteTo(Stream outputStream)
		{
		}
	}
}
