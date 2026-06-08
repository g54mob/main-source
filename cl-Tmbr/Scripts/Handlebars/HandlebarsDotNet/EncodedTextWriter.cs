using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using HandlebarsDotNet.IO;
using HandlebarsDotNet.StringUtils;

namespace HandlebarsDotNet
{
	public readonly struct EncodedTextWriter : IDisposable
	{
		private static class Throw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static void CannotResolveFormatter(Type type)
			{
				throw new HandlebarsRuntimeException($"Cannot resolve formatter for type `{type}`");
			}
		}

		private readonly IFormatterProvider _formatterProvider;

		private readonly TextEncoderWrapper _encoder;

		internal readonly TextWriter UnderlyingWriter;

		public bool SuppressEncoding
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return !_encoder.Enabled;
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				_encoder.Enabled = !value;
			}
		}

		public Encoding Encoding
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return UnderlyingWriter.Encoding;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public EncodedTextWriter(TextWriter writer, ITextEncoder encoder, IFormatterProvider formatterProvider, bool suppressEncoding = false)
		{
			UnderlyingWriter = writer;
			_formatterProvider = formatterProvider;
			_encoder = ((encoder != null) ? TextEncoderWrapper.Create(encoder) : TextEncoderWrapper.Null);
			SuppressEncoding = suppressEncoding;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public TextWriter CreateWrapper()
		{
			return EncodedTextWriterWrapper.From(in this);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Write(string value, bool encode)
		{
			if (encode && !SuppressEncoding)
			{
				_encoder.Encode(value, UnderlyingWriter);
			}
			else
			{
				UnderlyingWriter.Write(value);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Write(StringBuilder value, bool encode = true)
		{
			if (encode && !SuppressEncoding)
			{
				_encoder.Encode(value, UnderlyingWriter);
				return;
			}
			for (int i = 0; i < value.Length; i++)
			{
				UnderlyingWriter.Write(value[i]);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Write(Substring value, bool encode = true)
		{
			if (encode && !SuppressEncoding)
			{
				_encoder.Encode(value.GetEnumerator(), UnderlyingWriter);
				return;
			}
			for (int i = 0; i < value.Length; i++)
			{
				UnderlyingWriter.Write(value[in i]);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Write<T>(T value, bool encode) where T : IEnumerator<char>
		{
			if (encode && !SuppressEncoding)
			{
				_encoder.Encode(value, UnderlyingWriter);
				return;
			}
			while (value.MoveNext())
			{
				UnderlyingWriter.Write(value.Current);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Write(string value)
		{
			Write(value, encode: true);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Write(string format, params object[] arguments)
		{
			Write(string.Format(format, arguments), encode: true);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Write(char value)
		{
			Write(value.SequenceOfOne(), encode: true);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Write(object value)
		{
			this.Write<object>(value);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Write<T>(T value)
		{
			if (value == null)
			{
				return;
			}
			if (!(value is string text))
			{
				if (!(value is StringBuilder stringBuilder))
				{
					if (value is Substring substring)
					{
						if (substring.Length != 0)
						{
							Substring value2 = substring;
							Write(value2);
						}
					}
					else
					{
						WriteFormatted(value);
					}
				}
				else if (stringBuilder.Length != 0)
				{
					StringBuilder value3 = stringBuilder;
					Write(value3);
				}
			}
			else if (!string.IsNullOrEmpty(text))
			{
				string value4 = text;
				Write(value4, encode: true);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void WriteFormatted<T>(T value)
		{
			Type type = typeof(T);
			if (type.IsClass)
			{
				type = value.GetType();
			}
			if (!_formatterProvider.TryCreateFormatter(type, out var formatter))
			{
				Throw.CannotResolveFormatter(type);
			}
			formatter.Format(value, in this);
		}

		public void Dispose()
		{
			_encoder.Dispose();
		}

		public override string ToString()
		{
			return UnderlyingWriter.ToString();
		}
	}
}
