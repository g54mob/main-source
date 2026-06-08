using System;
using System.IO;

namespace MLAPI.Serialization
{
	public class BitStream : Stream
	{
		private const int initialCapacity = 16;

		private const float initialGrowthFactor = 2f;

		private byte[] target;

		private float _growthFactor;

		public bool Resizable { get; }

		public float GrowthFactor
		{
			get
			{
				return _growthFactor;
			}
			set
			{
				_growthFactor = ((value <= 1f) ? 1.5f : value);
			}
		}

		public override bool CanRead => true;

		public bool HasDataToRead => Position < Length;

		public override bool CanSeek => true;

		public override bool CanWrite
		{
			get
			{
				if (BitAligned && Position >= target.LongLength)
				{
					return Resizable;
				}
				return true;
			}
		}

		public long Capacity
		{
			get
			{
				return target.LongLength;
			}
			set
			{
				if (value < Length)
				{
					throw new ArgumentOutOfRangeException("New capcity too small!");
				}
				SetCapacity(value);
			}
		}

		public override long Length => Arithmetic.Div8Ceil(BitLength);

		public override long Position
		{
			get
			{
				return (long)(BitPosition >> 3);
			}
			set
			{
				BitPosition = (ulong)(value << 3);
			}
		}

		public ulong BitPosition { get; set; }

		public ulong BitLength { get; private set; }

		public bool BitAligned => (BitPosition & 7) == 0;

		public BitStream(int capacity, float growthFactor)
		{
			target = new byte[capacity];
			GrowthFactor = growthFactor;
			Resizable = true;
		}

		public BitStream(float growthFactor)
			: this(16, growthFactor)
		{
		}

		public BitStream(int capacity)
			: this(capacity, 2f)
		{
		}

		public BitStream()
			: this(16, 2f)
		{
		}

		public BitStream(byte[] target)
		{
			this.target = target;
			Resizable = false;
			BitLength = (ulong)(target.Length << 3);
		}

		internal void SetTarget(byte[] target)
		{
			this.target = target;
			BitLength = (ulong)(target.Length << 3);
			Position = 0L;
		}

		public override void Flush()
		{
		}

		private void Grow(long newContent)
		{
			long num = newContent + Capacity;
			long num2 = num;
			if (num2 < 256)
			{
				num2 = 256L;
			}
			if (num2 < Capacity * 2)
			{
				num2 = Capacity * 2;
			}
			if ((uint)(Capacity * 2) > int.MaxValue)
			{
				num2 = ((num > int.MaxValue) ? num : int.MaxValue);
			}
			SetCapacity(num2);
		}

		private byte ReadByteMisaligned()
		{
			int num = (int)(BitPosition & 7);
			return (byte)((target[(int)Position] >> num) | (target[(int)(BitPosition += 8uL) >> 3] << 8 - num));
		}

		private byte ReadByteAligned()
		{
			return target[Position++];
		}

		internal byte _ReadByte()
		{
			if (!BitAligned)
			{
				return ReadByteMisaligned();
			}
			return ReadByteAligned();
		}

		public override int ReadByte()
		{
			if (!HasDataToRead)
			{
				return -1;
			}
			if (!BitAligned)
			{
				return ReadByteMisaligned();
			}
			return ReadByteAligned();
		}

		public int PeekByte()
		{
			if (!HasDataToRead)
			{
				return -1;
			}
			if (!BitAligned)
			{
				return (byte)((target[(int)Position] >> (int)(BitPosition & 7)) | (target[(int)(BitPosition + 8) >> 3] << 8 - (int)(BitPosition & 7)));
			}
			return target[Position];
		}

		public bool ReadBit()
		{
			return (target[Position] & (1 << (int)(BitPosition++ & 7))) != 0;
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			int num = Math.Min(count, (int)(target.LongLength - Position) - (((BitPosition & 7) != 0L) ? 1 : 0));
			for (int i = 0; i < num; i++)
			{
				buffer[offset + i] = _ReadByte();
			}
			return num;
		}

		public override long Seek(long offset, SeekOrigin origin)
		{
			ulong num = (BitPosition = origin switch
			{
				SeekOrigin.Begin => (ulong)(Math.Max(0L, offset) << 3), 
				SeekOrigin.Current => (offset > 0) ? Math.Min(BitPosition + (ulong)(offset << 3), (ulong)((long)target.Length << 3)) : (((offset ^ long.MinValue) > Position) ? 0 : (BitPosition - (ulong)((offset ^ long.MinValue) << 3))), 
				_ => (ulong)(Math.Max(target.Length - offset, 0L) << 3), 
			});
			return (long)((num >> 3) + ((BitPosition & 1) | ((BitPosition >> 1) & 1) | ((BitPosition >> 2) & 1)));
		}

		private void SetCapacity(long value)
		{
			if (!Resizable)
			{
				throw new NotSupportedException("Can't resize non resizable buffer");
			}
			byte[] dst = new byte[value];
			long num = Math.Min(value, target.LongLength);
			Buffer.BlockCopy(target, 0, dst, 0, (int)num);
			if (value < target.LongLength)
			{
				BitPosition = (ulong)(value << 3);
			}
			target = dst;
		}

		public override void SetLength(long value)
		{
			if (value < 0)
			{
				throw new IndexOutOfRangeException("Cannot set a negative length!");
			}
			if (value > Capacity)
			{
				Grow(value - Capacity);
			}
			BitLength = (ulong)(value << 3);
			BitPosition = Math.Min((ulong)(value << 3), BitPosition);
		}

		public override void Write(byte[] buffer, int offset, int count)
		{
			if (BitAligned)
			{
				if (Position + count >= target.Length)
				{
					Grow(count);
				}
				Buffer.BlockCopy(buffer, offset, target, (int)Position, count);
				Position += count;
			}
			else
			{
				if (Position + count + 1 >= target.Length)
				{
					Grow(count);
				}
				for (int i = 0; i < count; i++)
				{
					_WriteMisaligned(buffer[offset + i]);
				}
			}
			if (BitPosition > BitLength)
			{
				BitLength = BitPosition;
			}
		}

		public override void WriteByte(byte value)
		{
			if (BitAligned)
			{
				if (Position + 1 >= target.Length)
				{
					Grow(1L);
				}
				target[Position] = value;
				Position++;
			}
			else
			{
				if (Position + 1 + 1 >= target.Length)
				{
					Grow(1L);
				}
				_WriteMisaligned(value);
			}
			if (BitPosition > BitLength)
			{
				BitLength = BitPosition;
			}
		}

		private void _WriteMisaligned(byte value)
		{
			int num = (int)(BitPosition & 7);
			int num2 = 8 - num;
			target[Position + 1] = (byte)((target[Position + 1] & (255 << num)) | (value >> num2));
			target[Position] = (byte)((target[Position] & (255 >> num2)) | (value << num));
			BitPosition += 8uL;
		}

		private void _WriteIntByte(int value)
		{
			_WriteByte((byte)value);
		}

		private void _WriteULongByte(ulong byteValue)
		{
			_WriteByte((byte)byteValue);
		}

		private void _WriteByte(byte value)
		{
			if (Arithmetic.Div8Ceil(BitPosition) == target.LongLength)
			{
				Grow(1L);
			}
			if (BitAligned)
			{
				target[Position] = value;
				BitPosition += 8uL;
			}
			else
			{
				_WriteMisaligned(value);
			}
			UpdateLength();
		}

		public void Write(byte[] buffer)
		{
			Write(buffer, 0, buffer.Length);
		}

		public void WriteBit(bool bit)
		{
			if (BitAligned && Position == target.Length)
			{
				Grow(1L);
			}
			int num = (int)(BitPosition & 7);
			long position = Position;
			ulong bitPosition = BitPosition + 1;
			BitPosition = bitPosition;
			target[position] = (byte)(bit ? ((target[position] & ~(1 << num)) | (1 << num)) : (target[position] & ~(1 << num)));
			UpdateLength();
		}

		public void CopyFrom(Stream s, int count = -1)
		{
			if (s is BitStream bitStream)
			{
				Write(bitStream.target, 0, (int)((count < 0) ? bitStream.Length : count));
				return;
			}
			long position = s.Position;
			s.Position = 0L;
			bool flag = count < 0;
			int value;
			while ((flag || count-- > 0) && (value = s.ReadByte()) != -1)
			{
				_WriteIntByte(value);
			}
			UpdateLength();
			s.Position = position;
		}

		public new void CopyTo(Stream stream, int count = -1)
		{
			stream.Write(target, 0, (int)((count < 0) ? Length : count));
		}

		public void CopyUnreadFrom(Stream s, int count = -1)
		{
			long position = s.Position;
			bool flag = count < 0;
			int value;
			while ((flag || count-- > 0) && (value = s.ReadByte()) != -1)
			{
				_WriteIntByte(value);
			}
			UpdateLength();
			s.Position = position;
		}

		public void CopyFrom(BitStream stream, int dataCount, bool copyBits)
		{
			if (!copyBits)
			{
				CopyFrom(stream, dataCount);
				return;
			}
			ulong num = ((dataCount < 0) ? stream.BitLength : ((ulong)dataCount));
			if (stream.BitLength < num)
			{
				throw new IndexOutOfRangeException("Attempted to read more data than is available");
			}
			Write(stream.GetBuffer(), 0, (int)(num >> 3));
			for (int num2 = (int)(num & 7); num2 >= 0; num2--)
			{
				WriteBit(stream.ReadBit());
			}
		}

		private void UpdateLength()
		{
			if (BitPosition > BitLength)
			{
				BitLength = BitPosition;
			}
		}

		public byte[] GetBuffer()
		{
			return target;
		}

		public byte[] ToArray()
		{
			byte[] array = new byte[Length];
			Buffer.BlockCopy(target, 0, array, 0, (int)Length);
			return array;
		}

		public void PadStream()
		{
			while (!BitAligned)
			{
				WriteBit(bit: false);
			}
		}

		public void SkipPadBits()
		{
			while (!BitAligned)
			{
				ReadBit();
			}
		}

		public override string ToString()
		{
			return BitConverter.ToString(target, 0, (int)Length);
		}
	}
}
