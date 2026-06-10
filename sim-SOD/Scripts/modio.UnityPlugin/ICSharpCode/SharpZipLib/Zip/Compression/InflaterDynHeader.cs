using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using ICSharpCode.SharpZipLib.Zip.Compression.Streams;

namespace ICSharpCode.SharpZipLib.Zip.Compression
{
	internal class InflaterDynHeader
	{
		[CompilerGenerated]
		private sealed class _003CCreateStateMachine_003Ed__7 : IEnumerable<bool>, IEnumerable, IEnumerator<bool>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private bool _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			public InflaterDynHeader _003C_003E4__this;

			private int _003CdataCodeCount_003E5__2;

			private InflaterHuffmanTree _003CmetaCodeTree_003E5__3;

			private int _003Cindex_003E5__4;

			private int _003Ci_003E5__5;

			private byte _003CcodeLength_003E5__6;

			bool IEnumerator<bool>.Current
			{
				[DebuggerHidden]
				get
				{
					return false;
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
			public _003CCreateStateMachine_003Ed__7(int _003C_003E1__state)
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

			[DebuggerHidden]
			IEnumerator<bool> IEnumerable<bool>.GetEnumerator()
			{
				return null;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
			}
		}

		private const int LITLEN_MAX = 286;

		private const int DIST_MAX = 30;

		private const int CODELEN_MAX = 316;

		private const int META_MAX = 19;

		private static readonly int[] MetaCodeLengthIndex;

		private readonly StreamManipulator input;

		private readonly IEnumerator<bool> state;

		private readonly IEnumerable<bool> stateMachine;

		private byte[] codeLengths;

		private InflaterHuffmanTree litLenTree;

		private InflaterHuffmanTree distTree;

		private int litLenCodeCount;

		private int distanceCodeCount;

		private int metaCodeCount;

		public InflaterHuffmanTree LiteralLengthTree => null;

		public InflaterHuffmanTree DistanceTree => null;

		public bool AttemptRead()
		{
			return false;
		}

		public InflaterDynHeader(StreamManipulator input)
		{
		}

		[IteratorStateMachine(typeof(_003CCreateStateMachine_003Ed__7))]
		private IEnumerable<bool> CreateStateMachine()
		{
			return null;
		}
	}
}
