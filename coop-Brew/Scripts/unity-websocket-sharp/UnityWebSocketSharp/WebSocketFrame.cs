using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;

namespace UnityWebSocketSharp
{
	internal class WebSocketFrame : IEnumerable<byte>, IEnumerable
	{
		[CompilerGenerated]
		private sealed class _003CGetEnumerator_003Ed__86 : IEnumerator<byte>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private byte _003C_003E2__current;

			public WebSocketFrame _003C_003E4__this;

			private byte[] _003C_003E7__wrap1;

			private int _003C_003E7__wrap2;

			byte IEnumerator<byte>.Current
			{
				[DebuggerHidden]
				get
				{
					return 0;
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
			public _003CGetEnumerator_003Ed__86(int _003C_003E1__state)
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
		}

		private static readonly int _defaultHeaderLength;

		private static readonly int _defaultMaskingKeyLength;

		private byte[] _extPayloadLength;

		private Fin _fin;

		private Mask _mask;

		private byte[] _maskingKey;

		private Opcode _opcode;

		private PayloadData _payloadData;

		private byte _payloadLength;

		private Rsv _rsv1;

		private Rsv _rsv2;

		private Rsv _rsv3;

		internal ulong ExactPayloadLength => 0uL;

		internal int ExtendedPayloadLengthWidth => 0;

		public byte[] ExtendedPayloadLength => null;

		public Fin Fin => default(Fin);

		public bool IsBinary => false;

		public bool IsClose => false;

		public bool IsCompressed => false;

		public bool IsContinuation => false;

		public bool IsControl => false;

		public bool IsData => false;

		public bool IsFinal => false;

		public bool IsFragment => false;

		public bool IsMasked => false;

		public bool IsPing => false;

		public bool IsPong => false;

		public bool IsText => false;

		public ulong Length => 0uL;

		public Mask Mask => default(Mask);

		public byte[] MaskingKey => null;

		public Opcode Opcode => default(Opcode);

		public PayloadData PayloadData => null;

		public byte PayloadLength => 0;

		public Rsv Rsv1 => default(Rsv);

		public Rsv Rsv2 => default(Rsv);

		public Rsv Rsv3 => default(Rsv);

		static WebSocketFrame()
		{
		}

		private WebSocketFrame()
		{
		}

		internal WebSocketFrame(Fin fin, Opcode opcode, byte[] data, bool compressed, bool mask)
		{
		}

		internal WebSocketFrame(Fin fin, Opcode opcode, PayloadData payloadData, bool compressed, bool mask)
		{
		}

		private static byte[] createMaskingKey()
		{
			return null;
		}

		private static WebSocketFrame processHeader(byte[] header)
		{
			return null;
		}

		private static WebSocketFrame readExtendedPayloadLength(Stream stream, WebSocketFrame frame)
		{
			return null;
		}

		private static void readExtendedPayloadLengthAsync(Stream stream, WebSocketFrame frame, Action<WebSocketFrame> completed, Action<Exception> error)
		{
		}

		private static WebSocketFrame readHeader(Stream stream)
		{
			return null;
		}

		private static void readHeaderAsync(Stream stream, Action<WebSocketFrame> completed, Action<Exception> error)
		{
		}

		private static WebSocketFrame readMaskingKey(Stream stream, WebSocketFrame frame)
		{
			return null;
		}

		private static void readMaskingKeyAsync(Stream stream, WebSocketFrame frame, Action<WebSocketFrame> completed, Action<Exception> error)
		{
		}

		private static WebSocketFrame readPayloadData(Stream stream, WebSocketFrame frame)
		{
			return null;
		}

		private static void readPayloadDataAsync(Stream stream, WebSocketFrame frame, Action<WebSocketFrame> completed, Action<Exception> error)
		{
		}

		private string toDumpString()
		{
			return null;
		}

		private string toString()
		{
			return null;
		}

		internal static WebSocketFrame CreateCloseFrame(PayloadData payloadData, bool mask)
		{
			return null;
		}

		internal static WebSocketFrame CreatePingFrame(bool mask)
		{
			return null;
		}

		internal static WebSocketFrame CreatePingFrame(byte[] data, bool mask)
		{
			return null;
		}

		internal static WebSocketFrame CreatePongFrame(PayloadData payloadData, bool mask)
		{
			return null;
		}

		internal static WebSocketFrame ReadFrame(Stream stream, bool unmask)
		{
			return null;
		}

		internal static void ReadFrameAsync(Stream stream, bool unmask, Action<WebSocketFrame> completed, Action<Exception> error)
		{
		}

		internal string ToString(bool dump)
		{
			return null;
		}

		internal void Unmask()
		{
		}

		[IteratorStateMachine(typeof(_003CGetEnumerator_003Ed__86))]
		public IEnumerator<byte> GetEnumerator()
		{
			return null;
		}

		public byte[] ToArray()
		{
			return null;
		}

		public override string ToString()
		{
			return null;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return null;
		}
	}
}
