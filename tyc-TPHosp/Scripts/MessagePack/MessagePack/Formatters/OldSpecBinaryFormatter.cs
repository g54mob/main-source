using System;

namespace MessagePack.Formatters
{
	public sealed class OldSpecBinaryFormatter : IMessagePackFormatter<byte[]>, IMessagePackFormatter
	{
		public static readonly OldSpecBinaryFormatter Instance = new OldSpecBinaryFormatter();

		public int Serialize(ref byte[] bytes, int offset, byte[] value, IFormatterResolver formatterResolver)
		{
			if (value == null)
			{
				return MessagePackBinary.WriteNil(ref bytes, offset);
			}
			int num = value.Length;
			if (num <= 31)
			{
				MessagePackBinary.EnsureCapacity(ref bytes, offset, num + 1);
				bytes[offset] = (byte)(0xA0 | num);
				Buffer.BlockCopy(value, 0, bytes, offset + 1, num);
				return num + 1;
			}
			if (num <= 65535)
			{
				MessagePackBinary.EnsureCapacity(ref bytes, offset, num + 3);
				bytes[offset] = 218;
				bytes[offset + 1] = (byte)(num >> 8);
				bytes[offset + 2] = (byte)num;
				Buffer.BlockCopy(value, 0, bytes, offset + 3, num);
				return num + 3;
			}
			MessagePackBinary.EnsureCapacity(ref bytes, offset, num + 5);
			bytes[offset] = 219;
			bytes[offset + 1] = (byte)(num >> 24);
			bytes[offset + 2] = (byte)(num >> 16);
			bytes[offset + 3] = (byte)(num >> 8);
			bytes[offset + 4] = (byte)num;
			Buffer.BlockCopy(value, 0, bytes, offset + 5, num);
			return num + 5;
		}

		public byte[] Deserialize(byte[] bytes, int offset, IFormatterResolver formatterResolver, out int readSize)
		{
			switch (MessagePackBinary.GetMessagePackType(bytes, offset))
			{
			case MessagePackType.Nil:
				readSize = 1;
				return null;
			case MessagePackType.Binary:
				return MessagePackBinary.ReadBytes(bytes, offset, out readSize);
			case MessagePackType.String:
			{
				byte b = bytes[offset];
				if (160 <= b && b <= 191)
				{
					int num = bytes[offset] & 0x1F;
					readSize = num + 1;
					byte[] array = new byte[num];
					Buffer.BlockCopy(bytes, offset + 1, array, 0, array.Length);
					return array;
				}
				switch (b)
				{
				case 217:
				{
					int num4 = bytes[offset + 1];
					readSize = num4 + 2;
					byte[] array4 = new byte[num4];
					Buffer.BlockCopy(bytes, offset + 2, array4, 0, array4.Length);
					return array4;
				}
				case 218:
				{
					int num3 = (bytes[offset + 1] << 8) + bytes[offset + 2];
					readSize = num3 + 3;
					byte[] array3 = new byte[num3];
					Buffer.BlockCopy(bytes, offset + 3, array3, 0, array3.Length);
					return array3;
				}
				case 219:
				{
					int num2 = (bytes[offset + 1] << 24) | (bytes[offset + 2] << 16) | (bytes[offset + 3] << 8) | bytes[offset + 4];
					readSize = num2 + 5;
					byte[] array2 = new byte[num2];
					Buffer.BlockCopy(bytes, offset + 5, array2, 0, array2.Length);
					return array2;
				}
				}
				break;
			}
			}
			throw new InvalidOperationException($"code is invalid. code:{bytes[offset]} format:{MessagePackCode.ToFormatName(bytes[offset])}");
		}
	}
}
