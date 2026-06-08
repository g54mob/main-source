using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using HandlebarsDotNet.Pools;

namespace HandlebarsDotNet
{
	internal sealed class EncodedTextWriterWrapper : TextWriter
	{
		[StructLayout(LayoutKind.Sequential, Size = 1)]
		private readonly struct Policy : IInternalObjectPoolPolicy<EncodedTextWriterWrapper>
		{
			public EncodedTextWriterWrapper Create()
			{
				return new EncodedTextWriterWrapper();
			}

			public bool Return(EncodedTextWriterWrapper obj)
			{
				obj.UnderlyingWriter = default(EncodedTextWriter);
				return true;
			}
		}

		private static readonly InternalObjectPool<EncodedTextWriterWrapper, Policy> Pool = new InternalObjectPool<EncodedTextWriterWrapper, Policy>(default(Policy));

		public EncodedTextWriter UnderlyingWriter { get; private set; }

		public override IFormatProvider FormatProvider => UnderlyingWriter.UnderlyingWriter.FormatProvider;

		public override Encoding Encoding => UnderlyingWriter.Encoding;

		public static TextWriter From(in EncodedTextWriter encodedTextWriter)
		{
			EncodedTextWriterWrapper encodedTextWriterWrapper = Pool.Get();
			encodedTextWriterWrapper.UnderlyingWriter = encodedTextWriter;
			return encodedTextWriterWrapper;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Write(string value, bool encode)
		{
			UnderlyingWriter.Write(value, encode);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Write(StringBuilder value, bool encode)
		{
			UnderlyingWriter.Write(value, encode);
		}

		public override void Write(string value)
		{
			UnderlyingWriter.Write(value);
		}

		public override void Write(char value)
		{
			UnderlyingWriter.Write(value);
		}

		public override void Write(int value)
		{
			UnderlyingWriter.Write(value);
		}

		public override void Write(double value)
		{
			UnderlyingWriter.Write(value);
		}

		public override void Write(float value)
		{
			UnderlyingWriter.Write(value);
		}

		public override void Write(decimal value)
		{
			UnderlyingWriter.Write(value);
		}

		public override void Write(bool value)
		{
			UnderlyingWriter.Write(value);
		}

		public override void Write(long value)
		{
			UnderlyingWriter.Write(value);
		}

		public override void Write(ulong value)
		{
			UnderlyingWriter.Write(value);
		}

		public override void Write(uint value)
		{
			UnderlyingWriter.Write(value);
		}

		public override void Write(object value)
		{
			if (value is StringBuilder value2)
			{
				UnderlyingWriter.Write<StringBuilder>(value2);
			}
			else
			{
				UnderlyingWriter.Write(value);
			}
		}

		protected override void Dispose(bool disposing)
		{
			Pool.Return(this);
		}
	}
}
