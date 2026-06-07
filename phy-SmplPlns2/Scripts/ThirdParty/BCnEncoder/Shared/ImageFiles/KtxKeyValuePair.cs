using System;
using System.IO;
using System.Text;

namespace BCnEncoder.Shared.ImageFiles
{
	public class KtxKeyValuePair
	{
		public string Key { get; }

		public byte[] Value { get; }

		public KtxKeyValuePair(string key, byte[] value)
		{
			Key = key;
			Value = value;
		}

		public uint GetSizeWithPadding()
		{
			uint num = (uint)(Encoding.UTF8.GetByteCount(Key) + 1 + Value.Length);
			int num2 = (int)(3 - (num + 3) % 4);
			return (uint)(num + num2);
		}

		public static KtxKeyValuePair ReadKeyValuePair(BinaryReader br, out int bytesRead)
		{
			uint num = br.ReadUInt32();
			Span<byte> buffer = stackalloc byte[(int)num];
			br.Read(buffer);
			int i;
			for (i = 0; i < num && buffer[i] != 0; i++)
			{
				if (i >= num)
				{
					throw new InvalidDataException();
				}
			}
			int num2 = i;
			string key = Encoding.UTF8.GetString(buffer.Slice(0, num2));
			int num3 = (int)(num - num2 - 1);
			Span<byte> span = buffer.Slice(i + 1, num3);
			byte[] array = new byte[num3];
			span.CopyTo(array);
			int num4 = (int)(3 - (num + 3) % 4);
			br.SkipPadding(num4);
			bytesRead = (int)(num + num4 + 4);
			return new KtxKeyValuePair(key, array);
		}

		public static uint WriteKeyValuePair(BinaryWriter bw, KtxKeyValuePair pair)
		{
			Span<byte> span = stackalloc byte[Encoding.UTF8.GetByteCount(pair.Key)];
			Span<byte> span2 = pair.Value;
			uint num = (uint)(span.Length + 1 + span2.Length);
			int num2 = (int)(3 - (num + 3) % 4);
			bw.Write(num);
			bw.Write(span);
			bw.Write((byte)0);
			bw.Write(span2);
			return (uint)(num + num2);
		}
	}
}
