using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using HandlebarsDotNet.Pools;

namespace HandlebarsDotNet
{
	internal class TextEncoderWrapper : ITextEncoder, IDisposable
	{
		[StructLayout(LayoutKind.Sequential, Size = 1)]
		private struct Policy : IInternalObjectPoolPolicy<TextEncoderWrapper>
		{
			public TextEncoderWrapper Create()
			{
				return new TextEncoderWrapper();
			}

			public bool Return(TextEncoderWrapper item)
			{
				item._enabled = true;
				item._underlyingEncoder = null;
				return true;
			}
		}

		private static readonly InternalObjectPool<TextEncoderWrapper, Policy> Pool = new InternalObjectPool<TextEncoderWrapper, Policy>(default(Policy));

		private ITextEncoder _underlyingEncoder;

		private bool _enabled;

		public static TextEncoderWrapper Null { get; } = new TextEncoderWrapper();

		public bool Enabled
		{
			get
			{
				if (_enabled)
				{
					return _underlyingEncoder != null;
				}
				return false;
			}
			set
			{
				_enabled = value;
			}
		}

		public static TextEncoderWrapper Create(ITextEncoder encoder)
		{
			TextEncoderWrapper textEncoderWrapper = Pool.Get();
			textEncoderWrapper._underlyingEncoder = encoder;
			textEncoderWrapper.Enabled = encoder != null;
			return textEncoderWrapper;
		}

		private TextEncoderWrapper()
		{
		}

		public void Encode(StringBuilder text, TextWriter target)
		{
			if (Enabled)
			{
				_underlyingEncoder.Encode(text, target);
			}
		}

		public void Encode(string text, TextWriter target)
		{
			if (Enabled)
			{
				_underlyingEncoder.Encode(text, target);
			}
		}

		public void Encode<T>(T text, TextWriter target) where T : IEnumerator<char>
		{
			if (Enabled)
			{
				_underlyingEncoder.Encode(text, target);
			}
		}

		public void Dispose()
		{
			if (this != Null)
			{
				Pool.Return(this);
			}
		}
	}
}
