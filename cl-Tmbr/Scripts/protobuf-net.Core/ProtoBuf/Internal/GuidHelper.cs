using System;
using System.Buffers;
using System.Buffers.Text;
using System.Text;

namespace ProtoBuf.Internal
{
	internal static class GuidHelper
	{
		internal const int WRITE_BYTES_LENGTH = 16;

		internal const int WRITE_STRING_LENGTH = 36;

		internal const int MAX_LENGTH = 40;

		internal unsafe static Guid Read(ref ProtoReader.State state)
		{
			byte* ptr = stackalloc byte[40];
			Span<byte> span = state.ReadBytes(new Span<byte>(ptr, 40));
			char standardFormat;
			switch (span.Length)
			{
			case 0:
				return Guid.Empty;
			case 16:
			{
				int num = 32;
				for (int num2 = 15; num2 >= 0; num2--)
				{
					byte b = ptr[num2];
					ptr[--num] = ToHex(b & 0xF);
					ptr[--num] = ToHex((b >> 4) & 0xF);
				}
				span = new Span<byte>(ptr, 32);
				standardFormat = 'N';
				break;
			}
			case 32:
				standardFormat = 'N';
				break;
			case 36:
				standardFormat = 'D';
				break;
			default:
				ThrowHelper.Format($"Unexpected Guid length: {span.Length}");
				return default(Guid);
			}
			if (!Utf8Parser.TryParse((ReadOnlySpan<byte>)span, out Guid value, out int bytesConsumed, standardFormat) || bytesConsumed != span.Length)
			{
				ThrowHelper.Format("Failed to read Guid: '" + Encoding.UTF8.GetString(ptr, span.Length) + "'");
			}
			return value;
			static byte ToHex(int index)
			{
				return (byte)"0123456789abcdef"[index];
			}
		}

		internal static void Write(ref ProtoWriter.State state, in Guid value, bool asBytes)
		{
			if (value.Equals(Guid.Empty))
			{
				state.WriteBytes(default(ReadOnlyMemory<byte>));
				return;
			}
			byte[] array = ArrayPool<byte>.Shared.Rent(40);
			try
			{
				if (!Utf8Formatter.TryFormat(value, array, out var bytesWritten, asBytes ? 'N' : 'D'))
				{
					ThrowHelper.Format($"Failed to write Guid: '{value}'");
				}
				if (asBytes)
				{
					int num = 0;
					for (int i = 0; i < 16; i++)
					{
						array[i] = (byte)((FromHex(array[num++]) << 4) | FromHex(array[num++]));
					}
					bytesWritten = 16;
				}
				state.WriteBytes(new ReadOnlyMemory<byte>(array, 0, bytesWritten));
			}
			finally
			{
				ArrayPool<byte>.Shared.Return(array);
			}
			static int FromHex(int num2)
			{
				if (num2 >= 48 && num2 <= 57)
				{
					return num2 - 48;
				}
				if (num2 >= 97 && num2 <= 102)
				{
					return 10 + num2 - 97;
				}
				if (num2 >= 65 && num2 <= 70)
				{
					return 10 + num2 - 65;
				}
				Throw(num2);
				return 0;
			}
			static void Throw(int num2)
			{
				ThrowHelper.ThrowArgumentOutOfRangeException("value", $"Unexpected hex character: '{(char)num2}'");
			}
		}
	}
}
