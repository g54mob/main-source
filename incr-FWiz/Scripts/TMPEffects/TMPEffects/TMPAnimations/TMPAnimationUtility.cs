using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPEffects.CharacterData;
using TMPEffects.Components.Animator;
using TMPEffects.Parameters;
using TMPro;
using UnityEngine;

namespace TMPEffects.TMPAnimations
{
	public static class TMPAnimationUtility
	{
		private struct TextSegment : ITMPSegmentData
		{
			[CompilerGenerated]
			private sealed class _003Cget_CharInfo_003Ed__8 : IEnumerable<CharData.Info>, IEnumerable, IEnumerator<CharData.Info>, IEnumerator, IDisposable
			{
				private int _003C_003E1__state;

				private CharData.Info _003C_003E2__current;

				private int _003C_003El__initialThreadId;

				public TextSegment _003C_003E4__this;

				public TextSegment _003C_003E3___003C_003E4__this;

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
				public _003Cget_CharInfo_003Ed__8(int _003C_003E1__state)
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

			private readonly IList<CharData> charDatas;

			public int StartIndex => 0;

			public int Length { get; }

			public int EndIndex => 0;

			public IEnumerable<CharData.Info> CharInfo
			{
				[IteratorStateMachine(typeof(_003Cget_CharInfo_003Ed__8))]
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

			public TextSegment(int len, IList<CharData> cData)
			{
				Length = 0;
				charDatas = null;
			}
		}

		[Serializable]
		public enum TMPWrapMode
		{
			Clamp = 0,
			Loop = 1,
			PingPong = 2
		}

		public static float ScaleTextMesh(TMP_Text text, float value)
		{
			return 0f;
		}

		public static float ScaleTextMesh(IAnimatorDataProvider ctx, float value)
		{
			return 0f;
		}

		public static float ScaleTextMesh(IAnimationContext ctx, float value)
		{
			return 0f;
		}

		public static float ScaleTextMesh(bool isTMProUGUI, float value)
		{
			return 0f;
		}

		public static Vector3 ScaleVector(Vector3 vector, CharData cData, IAnimationContext context)
		{
			return default(Vector3);
		}

		public static Vector3 ScaleVector(Vector3 vector, CharData cData, IAnimatorDataProvider context)
		{
			return default(Vector3);
		}

		public static Vector3 ScaleVector(Vector3 vector, bool isTMProUGUI, bool scaleAnimations, bool scaleUniformly, float pointSize, float fontSize)
		{
			return default(Vector3);
		}

		public static Vector3 IgnoreScaling(Vector3 vector, CharData cData, IAnimationContext context)
		{
			return default(Vector3);
		}

		public static Vector3 IgnoreScaling(Vector3 vector, CharData cData, IAnimatorDataProvider context)
		{
			return default(Vector3);
		}

		public static Vector3 IgnoreScaling(Vector3 vector, bool isTMProUGUI, bool scaleAnimations, bool scaleUniformly, float pointSize, float fontSize)
		{
			return default(Vector3);
		}

		public static Vector3 InverseScaleVector(Vector3 vector, CharData cData, IAnimationContext context)
		{
			return default(Vector3);
		}

		public static Vector3 InverseScaleVector(Vector3 vector, CharData cData, IAnimatorDataProvider context)
		{
			return default(Vector3);
		}

		public static Vector2 AnchorToPosition(Vector2 anchor, CharData cData)
		{
			return default(Vector2);
		}

		public static Vector3 GetRawVertex(int index, Vector3 position, CharData cData, IAnimationContext ctx)
		{
			return default(Vector3);
		}

		public static Vector3 GetRawVertex(int index, Vector3 position, CharData cData, IAnimatorDataProvider ctx)
		{
			return default(Vector3);
		}

		public static Vector3 GetRawPosition(Vector3 position, CharData cData, IAnimationContext ctx)
		{
			return default(Vector3);
		}

		public static Vector3 GetRawPosition(Vector3 position, CharData cData, IAnimatorDataProvider ctx)
		{
			return default(Vector3);
		}

		public static Vector3 GetRawPivot(Vector3 position, CharData cData, IAnimationContext ctx)
		{
			return default(Vector3);
		}

		public static Vector3 GetRawPivot(Vector3 position, CharData cData, IAnimatorDataProvider ctx)
		{
			return default(Vector3);
		}

		public static Vector3 GetRawDelta(Vector3 delta, CharData cData, IAnimationContext ctx)
		{
			return default(Vector3);
		}

		public static Vector3 GetRawDelta(Vector3 delta, CharData cData, IAnimatorDataProvider ctx)
		{
			return default(Vector3);
		}

		internal static Vector3 GetRawPosition(Vector3 position, Vector3 referencePosition, CharData cData, IAnimatorDataProvider ctx)
		{
			return default(Vector3);
		}

		public static void SetVertexRaw(int index, Vector3 position, CharData cData, IAnimationContext ctx)
		{
		}

		public static void SetVertexRaw(int index, Vector3 position, CharData cData, IAnimatorDataProvider ctx)
		{
		}

		public static void SetPositionRaw(Vector3 position, CharData cData, IAnimationContext ctx)
		{
		}

		public static void SetPositionRaw(Vector3 position, CharData cData, IAnimatorDataProvider ctx)
		{
		}

		public static Vector3 NormalizeEulerAngles(Vector3 eulerAngles)
		{
			return default(Vector3);
		}

		public static Vector3 ClosestPointOnLine(Vector3 lineStart, Vector3 lineEnd, Vector3 point)
		{
			return default(Vector3);
		}

		public static ITMPSegmentData GetMockedSegment(int len, IList<CharData> cData)
		{
			return null;
		}

		public static float GetOffset(CharData cData, IAnimationContext context, ITMPOffsetProvider provider, bool ignoreScaling = false, bool ignoreSegmentLenght = false)
		{
			return 0f;
		}

		public static float GetOffset(CharData cData, IAnimatorDataProvider context, ITMPOffsetProvider provider, bool ignoreScaling = false, bool ignoreSegmentLenght = false)
		{
			return 0f;
		}

		public static void GetMinMaxOffset(out float min, out float max, TMPParameterTypes.OffsetType type, ITMPSegmentData segmentData, IAnimatorDataProvider animatorData, bool ignoreAnimatorScaling = false)
		{
			min = default(float);
			max = default(float);
		}

		public static float GetOffset(TMPParameterTypes.OffsetType type, CharData cData, ITMPSegmentData segmentData, IAnimatorDataProvider animatorData, bool ignoreAnimatorScaling = false)
		{
			return 0f;
		}

		public static void SetToCharacter(TMP_Character newCharacter, TMP_Character originalCharacter, CharData cData, IAnimationContext context)
		{
		}

		public static float GetValue(AnimationCurve curve, WrapMode wrapMode, float time)
		{
			return 0f;
		}

		public static float GetValue(AnimationCurve curve, TMPWrapMode wrapMode, float time)
		{
			return 0f;
		}

		internal static TMPWrapMode ToTMPWrapMode(this WrapMode wrapMode)
		{
			return default(TMPWrapMode);
		}

		public static WrapMode ToWrapMode(this TMPWrapMode wrapMode)
		{
			return default(WrapMode);
		}
	}
}
