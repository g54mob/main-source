using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPEffects.CharacterData;
using TMPEffects.Tags;

namespace TMPEffects.Components.Animator
{
	public readonly struct SegmentData : ITMPSegmentData
	{
		[CompilerGenerated]
		private sealed class _003Cget_CharInfo_003Ed__15 : IEnumerable<CharData.Info>, IEnumerable, IEnumerator<CharData.Info>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private CharData.Info _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			public SegmentData _003C_003E4__this;

			public SegmentData _003C_003E3___003C_003E4__this;

			private int _003Ci_003E5__2;

			CharData.Info IEnumerator<CharData.Info>.Current
			{
				[DebuggerHidden]
				get
				{
					return default(CharData.Info);
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
			public _003Cget_CharInfo_003Ed__15(int _003C_003E1__state)
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
			IEnumerator<CharData.Info> IEnumerable<CharData.Info>.GetEnumerator()
			{
				return null;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
			}
		}

		public readonly int effectiveLength;

		public readonly int firstVisibleIndex;

		public readonly int lastVisibleIndex;

		public readonly int firstAnimationIndex;

		public readonly int lastAnimationIndex;

		private readonly IList<CharData> charDatas;

		public int StartIndex { get; }

		public int Length { get; }

		public int EndIndex { get; }

		public IEnumerable<CharData.Info> CharInfo
		{
			[IteratorStateMachine(typeof(_003Cget_CharInfo_003Ed__15))]
			get
			{
				return null;
			}
		}

		public CharData.Info GetCharInfo(int segmentIndex)
		{
			return default(CharData.Info);
		}

		public int IndexToSegmentIndex(int index)
		{
			return 0;
		}

		public int SegmentIndexOf(CharData cData)
		{
			return 0;
		}

		public SegmentData(TMPEffectTagIndices indices, IList<CharData> cData, Predicate<char> animates)
		{
			StartIndex = 0;
			Length = 0;
			EndIndex = 0;
			effectiveLength = 0;
			firstVisibleIndex = 0;
			lastVisibleIndex = 0;
			firstAnimationIndex = 0;
			lastAnimationIndex = 0;
			charDatas = null;
		}
	}
}
