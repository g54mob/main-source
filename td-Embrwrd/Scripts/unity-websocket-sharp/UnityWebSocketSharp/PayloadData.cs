using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace UnityWebSocketSharp
{
	internal class PayloadData : IEnumerable<byte>, IEnumerable
	{
		[CompilerGenerated]
		private sealed class _003CGetEnumerator_003Ed__25 : IEnumerator<byte>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private byte _003C_003E2__current;

			public PayloadData _003C_003E4__this;

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
			public _003CGetEnumerator_003Ed__25(int _003C_003E1__state)
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

		private byte[] _data;

		private long _extDataLength;

		private long _length;

		public static readonly PayloadData Empty;

		public static readonly ulong MaxLength;

		internal ushort Code => 0;

		internal long ExtensionDataLength
		{
			get
			{
				return 0L;
			}
			set
			{
			}
		}

		internal bool HasReservedCode => false;

		internal string Reason => null;

		public byte[] ApplicationData => null;

		public byte[] ExtensionData => null;

		public ulong Length => 0uL;

		static PayloadData()
		{
		}

		internal PayloadData(byte[] data)
		{
		}

		internal PayloadData(byte[] data, long length)
		{
		}

		internal PayloadData(ushort code, string reason)
		{
		}

		internal void Mask(byte[] key)
		{
		}

		[IteratorStateMachine(typeof(_003CGetEnumerator_003Ed__25))]
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
