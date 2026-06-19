using System;
using System.Collections.Generic;
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
			private readonly IList<CharData> charDatas;

			public int StartIndex => 0;

			public int Length { get; }

			public int EndIndex => StartIndex + Length;

			public IEnumerable<CharData.Info> CharInfo
			{
				get
				{
					for (int i = StartIndex; i < EndIndex; i++)
					{
						yield return charDatas[i].info;
					}
				}
			}

			public CharData.Info GetCharInfo(int segmentIndex)
			{
				if (segmentIndex > Length)
				{
					throw new ArgumentOutOfRangeException("segmentIndex");
				}
				return charDatas[segmentIndex + StartIndex].info;
			}

			public int IndexToSegmentIndex(int index)
			{
				return index;
			}

			public int SegmentIndexOf(CharData cData)
			{
				return cData.info.index;
			}

			public TextSegment(int len, IList<CharData> cData)
			{
				Length = len;
				charDatas = cData;
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
			return ScaleTextMesh(text.canvas != null, value);
		}

		public static float ScaleTextMesh(IAnimatorDataProvider ctx, float value)
		{
			return ScaleTextMesh(ctx.Animator.TextComponent.canvas != null, value);
		}

		public static float ScaleTextMesh(IAnimationContext ctx, float value)
		{
			return ScaleTextMesh(ctx.AnimatorContext.Animator.TextComponent.canvas != null, value);
		}

		public static float ScaleTextMesh(bool isTMProUGUI, float value)
		{
			if (!isTMProUGUI)
			{
				return value * 10f;
			}
			return value;
		}

		public static Vector3 ScaleVector(Vector3 vector, CharData cData, IAnimationContext context)
		{
			return ScaleVector(vector, context.AnimatorContext.Animator.TextComponent.canvas != null, context.AnimatorContext.ScaleAnimations, context.AnimatorContext.ScaleUniformly, cData.info.pointSize, context.AnimatorContext.Animator.TextComponent.fontSize);
		}

		public static Vector3 ScaleVector(Vector3 vector, CharData cData, IAnimatorDataProvider context)
		{
			return ScaleVector(vector, context.Animator.TextComponent.canvas != null, context.ScaleAnimations, context.ScaleUniformly, cData.info.pointSize, context.Animator.TextComponent.fontSize);
		}

		public static Vector3 ScaleVector(Vector3 vector, bool isTMProUGUI, bool scaleAnimations, bool scaleUniformly, float pointSize, float fontSize)
		{
			vector /= ScaleTextMesh(isTMProUGUI, 1f);
			if (!scaleAnimations)
			{
				return vector;
			}
			if (!scaleUniformly)
			{
				return vector * (pointSize / 36f);
			}
			return vector * (fontSize / 36f);
		}

		public static Vector3 IgnoreScaling(Vector3 vector, CharData cData, IAnimationContext context)
		{
			return IgnoreScaling(vector, context.AnimatorContext.Animator.TextComponent.canvas != null, context.AnimatorContext.ScaleAnimations, context.AnimatorContext.ScaleUniformly, cData.info.pointSize, context.AnimatorContext.Animator.TextComponent.fontSize);
		}

		public static Vector3 IgnoreScaling(Vector3 vector, CharData cData, IAnimatorDataProvider context)
		{
			return IgnoreScaling(vector, context.Animator.TextComponent.canvas != null, context.ScaleAnimations, context.ScaleUniformly, cData.info.pointSize, context.Animator.TextComponent.fontSize);
		}

		public static Vector3 IgnoreScaling(Vector3 vector, bool isTMProUGUI, bool scaleAnimations, bool scaleUniformly, float pointSize, float fontSize)
		{
			vector *= ScaleTextMesh(isTMProUGUI, 1f);
			if (!scaleAnimations)
			{
				return vector;
			}
			if (!scaleUniformly)
			{
				return vector / (pointSize / 36f);
			}
			return vector / (fontSize / 36f);
		}

		public static Vector3 InverseScaleVector(Vector3 vector, CharData cData, IAnimationContext context)
		{
			return IgnoreScaling(vector, cData, context.AnimatorContext);
		}

		public static Vector3 InverseScaleVector(Vector3 vector, CharData cData, IAnimatorDataProvider context)
		{
			return IgnoreScaling(vector, cData, context);
		}

		public static Vector2 AnchorToPosition(Vector2 anchor, CharData cData)
		{
			if (anchor == Vector2.zero)
			{
				return cData.InitialPosition;
			}
			Vector2 vector = cData.InitialPosition;
			Vector2 vector2 = (cData.InitialMesh.TL_Position - cData.InitialMesh.BL_Position) / 2f;
			Vector2 vector3 = (cData.InitialMesh.BR_Position - cData.InitialMesh.BL_Position) / 2f;
			Vector2 vector4 = default(Vector2);
			vector4.x = (cData.mesh.initial.BL_Position - cData.mesh.initial.BR_Position).magnitude / 2f;
			vector4.y = (cData.mesh.initial.BL_Position - cData.mesh.initial.TL_Position).magnitude / 2f;
			return vector + vector3 * anchor.x + vector2 * anchor.y;
		}

		public static Vector3 GetRawVertex(int index, Vector3 position, CharData cData, IAnimationContext ctx)
		{
			return GetRawVertex(index, position, cData, ctx.AnimatorContext);
		}

		public static Vector3 GetRawVertex(int index, Vector3 position, CharData cData, IAnimatorDataProvider ctx)
		{
			return GetRawPosition(position, cData.InitialMesh.GetPosition(index), cData, ctx);
		}

		public static Vector3 GetRawPosition(Vector3 position, CharData cData, IAnimationContext ctx)
		{
			return GetRawPosition(position, cData, ctx.AnimatorContext);
		}

		public static Vector3 GetRawPosition(Vector3 position, CharData cData, IAnimatorDataProvider ctx)
		{
			return GetRawPosition(position, cData.InitialPosition, cData, ctx);
		}

		public static Vector3 GetRawPivot(Vector3 position, CharData cData, IAnimationContext ctx)
		{
			return GetRawPivot(position, cData, ctx.AnimatorContext);
		}

		public static Vector3 GetRawPivot(Vector3 position, CharData cData, IAnimatorDataProvider ctx)
		{
			return GetRawPosition(position, cData.InitialPosition, cData, ctx);
		}

		public static Vector3 GetRawDelta(Vector3 delta, CharData cData, IAnimationContext ctx)
		{
			return GetRawDelta(delta, cData, ctx.AnimatorContext);
		}

		public static Vector3 GetRawDelta(Vector3 delta, CharData cData, IAnimatorDataProvider ctx)
		{
			return IgnoreScaling(delta, cData, ctx);
		}

		internal static Vector3 GetRawPosition(Vector3 position, Vector3 referencePosition, CharData cData, IAnimatorDataProvider ctx)
		{
			return IgnoreScaling(position - referencePosition, cData, ctx) + referencePosition;
		}

		public static void SetVertexRaw(int index, Vector3 position, CharData cData, IAnimationContext ctx)
		{
			SetVertexRaw(index, position, cData, ctx.AnimatorContext);
		}

		public static void SetVertexRaw(int index, Vector3 position, CharData cData, IAnimatorDataProvider ctx)
		{
			Vector3 position2 = cData.InitialMesh.GetPosition(index);
			cData.mesh.SetPosition(index, GetRawPosition(position, position2, cData, ctx));
		}

		public static void SetPositionRaw(Vector3 position, CharData cData, IAnimationContext ctx)
		{
			SetPositionRaw(position, cData, ctx.AnimatorContext);
		}

		public static void SetPositionRaw(Vector3 position, CharData cData, IAnimatorDataProvider ctx)
		{
			Vector3 initialPosition = cData.InitialPosition;
			cData.SetPosition(GetRawPosition(position, initialPosition, cData, ctx));
		}

		public static Vector3 NormalizeEulerAngles(Vector3 eulerAngles)
		{
			if (eulerAngles.x > 180f)
			{
				eulerAngles.x -= 360f;
			}
			if (eulerAngles.y > 180f)
			{
				eulerAngles.y -= 360f;
			}
			if (eulerAngles.z > 180f)
			{
				eulerAngles.z -= 360f;
			}
			return eulerAngles;
		}

		public static Vector3 ClosestPointOnLine(Vector3 lineStart, Vector3 lineEnd, Vector3 point)
		{
			Vector3 rhs = point - lineStart;
			Vector3 normalized = (lineEnd - lineStart).normalized;
			float num = Vector3.Distance(lineStart, lineEnd);
			float num2 = Vector3.Dot(normalized, rhs);
			if (num2 <= 0f)
			{
				return lineStart;
			}
			if (num2 >= num)
			{
				return lineEnd;
			}
			Vector3 vector = normalized * num2;
			return lineStart + vector;
		}

		public static ITMPSegmentData GetMockedSegment(int len, IList<CharData> cData)
		{
			return new TextSegment(len, cData);
		}

		public static float GetOffset(CharData cData, IAnimationContext context, ITMPOffsetProvider provider, bool ignoreScaling = false, bool ignoreSegmentLenght = false)
		{
			float num = provider.GetOffset(cData, context.SegmentData, context.AnimatorContext, ignoreScaling);
			if (!ignoreSegmentLenght)
			{
				num /= ((context.SegmentData.Length == 0) ? 0.001f : ((float)context.SegmentData.Length));
			}
			return num;
		}

		public static float GetOffset(CharData cData, IAnimatorDataProvider context, ITMPOffsetProvider provider, bool ignoreScaling = false, bool ignoreSegmentLenght = false)
		{
			ITMPSegmentData mockedSegment = GetMockedSegment(context.Animator.TextComponent.GetParsedText().Length, context.Animator.CharData);
			float num = provider.GetOffset(cData, mockedSegment, context, ignoreScaling);
			if (!ignoreSegmentLenght)
			{
				num /= ((mockedSegment.Length == 0) ? 0.001f : ((float)mockedSegment.Length));
			}
			return num;
		}

		public static void GetMinMaxOffset(out float min, out float max, TMPParameterTypes.OffsetType type, ITMPSegmentData segmentData, IAnimatorDataProvider animatorData, bool ignoreAnimatorScaling = false)
		{
			bool scaleUniformly = animatorData.ScaleUniformly;
			switch (type)
			{
			case TMPParameterTypes.OffsetType.SegmentIndex:
				min = 0f;
				max = segmentData.Length - 1;
				break;
			case TMPParameterTypes.OffsetType.Index:
				min = segmentData.StartIndex;
				max = segmentData.StartIndex + segmentData.Length - 1;
				break;
			case TMPParameterTypes.OffsetType.XPos:
				min = float.MaxValue;
				max = float.MinValue;
				if (scaleUniformly)
				{
					foreach (CharData.Info item in segmentData.CharInfo)
					{
						float x2 = item.InitialPosition.x;
						min = Mathf.Min(min, x2);
						max = Mathf.Max(max, x2);
					}
					min = ScalePos(animatorData.Animator.TextComponent.fontSize, min);
					max = ScalePos(animatorData.Animator.TextComponent.fontSize, max);
					break;
				}
				{
					foreach (CharData.Info item2 in segmentData.CharInfo)
					{
						float b5 = ScalePos(item2.pointSize, item2.InitialPosition.x);
						min = Mathf.Min(min, b5);
						max = Mathf.Max(max, b5);
					}
					break;
				}
			case TMPParameterTypes.OffsetType.YPos:
				min = float.MaxValue;
				max = float.MinValue;
				if (scaleUniformly)
				{
					foreach (CharData.Info item3 in segmentData.CharInfo)
					{
						float y2 = item3.InitialPosition.y;
						min = Mathf.Min(min, y2);
						max = Mathf.Max(max, y2);
					}
					min = ScalePos(animatorData.Animator.TextComponent.fontSize, min);
					max = ScalePos(animatorData.Animator.TextComponent.fontSize, max);
					break;
				}
				{
					foreach (CharData.Info item4 in segmentData.CharInfo)
					{
						float b3 = ScalePos(item4.pointSize, item4.InitialPosition.y);
						min = Mathf.Min(min, b3);
						max = Mathf.Max(max, b3);
					}
					break;
				}
			case TMPParameterTypes.OffsetType.Line:
				min = 2.1474836E+09f;
				max = 0f;
				{
					foreach (CharData.Info item5 in segmentData.CharInfo)
					{
						int lineNumber = item5.lineNumber;
						min = Math.Min(min, lineNumber);
						max = Math.Max(max, lineNumber);
					}
					break;
				}
			case TMPParameterTypes.OffsetType.Baseline:
				min = float.MaxValue;
				max = float.MinValue;
				{
					foreach (CharData.Info item6 in segmentData.CharInfo)
					{
						float baseLine = item6.baseLine;
						min = Math.Min(min, baseLine);
						max = Math.Max(max, baseLine);
					}
					break;
				}
			case TMPParameterTypes.OffsetType.Word:
				min = 2.1474836E+09f;
				max = -2.1474836E+09f;
				{
					foreach (CharData.Info item7 in segmentData.CharInfo)
					{
						int wordNumber = item7.wordNumber;
						min = Math.Min(min, wordNumber);
						max = Math.Max(max, wordNumber);
					}
					break;
				}
			case TMPParameterTypes.OffsetType.WorldXPos:
				min = float.MaxValue;
				max = float.MinValue;
				if (scaleUniformly)
				{
					foreach (CharData.Info item8 in segmentData.CharInfo)
					{
						float x = animatorData.Animator.transform.TransformPoint(item8.InitialPosition).x;
						min = Mathf.Min(min, x);
						max = Mathf.Max(max, x);
					}
					min = ScalePos(animatorData.Animator.TextComponent.fontSize, min);
					max = ScalePos(animatorData.Animator.TextComponent.fontSize, max);
					break;
				}
				{
					foreach (CharData.Info item9 in segmentData.CharInfo)
					{
						float b4 = ScalePos(item9.pointSize, animatorData.Animator.transform.TransformPoint(item9.InitialPosition).x);
						min = Mathf.Min(min, b4);
						max = Mathf.Max(max, b4);
					}
					break;
				}
			case TMPParameterTypes.OffsetType.WorldYPos:
				min = float.MaxValue;
				max = float.MinValue;
				if (scaleUniformly)
				{
					foreach (CharData.Info item10 in segmentData.CharInfo)
					{
						float y = animatorData.Animator.transform.TransformPoint(item10.InitialPosition).y;
						min = Mathf.Min(min, y);
						max = Mathf.Max(max, y);
					}
					min = ScalePos(animatorData.Animator.TextComponent.fontSize, min);
					max = ScalePos(animatorData.Animator.TextComponent.fontSize, max);
					break;
				}
				{
					foreach (CharData.Info item11 in segmentData.CharInfo)
					{
						float b2 = ScalePos(item11.pointSize, animatorData.Animator.transform.TransformPoint(item11.InitialPosition).y);
						min = Mathf.Min(min, b2);
						max = Mathf.Max(max, b2);
					}
					break;
				}
			case TMPParameterTypes.OffsetType.WorldZPos:
				min = float.MaxValue;
				max = float.MinValue;
				if (scaleUniformly)
				{
					foreach (CharData.Info item12 in segmentData.CharInfo)
					{
						float z = animatorData.Animator.transform.TransformPoint(item12.InitialPosition).z;
						min = Mathf.Min(min, z);
						max = Mathf.Max(max, z);
					}
					min = ScalePos(animatorData.Animator.TextComponent.fontSize, min);
					max = ScalePos(animatorData.Animator.TextComponent.fontSize, max);
					break;
				}
				{
					foreach (CharData.Info item13 in segmentData.CharInfo)
					{
						float b = ScalePos(item13.pointSize, animatorData.Animator.transform.TransformPoint(item13.InitialPosition).z);
						min = Mathf.Min(min, b);
						max = Mathf.Max(max, b);
					}
					break;
				}
			default:
				throw new NotImplementedException("NOT IMPLEMENTED");
			}
			float ScalePos(float pointSize, float pos)
			{
				if (ignoreAnimatorScaling)
				{
					return pos;
				}
				pos = ScaleTextMesh(animatorData.Animator.TextComponent, pos);
				if (!animatorData.ScaleAnimations)
				{
					return pos / 10f;
				}
				if (pointSize != 0f)
				{
					pos /= pointSize / 36f;
				}
				return pos / 10f;
			}
		}

		public static float GetOffset(TMPParameterTypes.OffsetType type, CharData cData, ITMPSegmentData segmentData, IAnimatorDataProvider animatorData, bool ignoreAnimatorScaling = false)
		{
			return type switch
			{
				TMPParameterTypes.OffsetType.SegmentIndex => segmentData.SegmentIndexOf(cData), 
				TMPParameterTypes.OffsetType.Index => cData.info.index, 
				TMPParameterTypes.OffsetType.Line => cData.info.lineNumber, 
				TMPParameterTypes.OffsetType.Baseline => cData.info.baseLine, 
				TMPParameterTypes.OffsetType.Word => cData.info.wordNumber, 
				TMPParameterTypes.OffsetType.WorldXPos => ScalePos(animatorData.Animator.transform.TransformPoint(cData.InitialPosition).x), 
				TMPParameterTypes.OffsetType.WorldYPos => ScalePos(animatorData.Animator.transform.TransformPoint(cData.InitialPosition).y), 
				TMPParameterTypes.OffsetType.WorldZPos => ScalePos(animatorData.Animator.transform.TransformPoint(cData.InitialPosition).z), 
				TMPParameterTypes.OffsetType.XPos => ScalePos(cData.InitialPosition.x), 
				TMPParameterTypes.OffsetType.YPos => ScalePos(cData.InitialPosition.y), 
				_ => throw new NotImplementedException("type"), 
			};
			float ScalePos(float pos)
			{
				if (ignoreAnimatorScaling)
				{
					return pos;
				}
				pos = ScaleTextMesh(animatorData.Animator.TextComponent, pos);
				if (!animatorData.ScaleAnimations)
				{
					return pos / 10f;
				}
				if (animatorData.ScaleUniformly)
				{
					if (animatorData.Animator.TextComponent.fontSize != 0f)
					{
						pos /= animatorData.Animator.TextComponent.fontSize / 36f;
					}
					return pos / 10f;
				}
				if (cData.info.pointSize != 0f)
				{
					pos /= cData.info.pointSize / 36f;
				}
				return pos / 10f;
			}
		}

		public static void SetToCharacter(TMP_Character newCharacter, TMP_Character originalCharacter, CharData cData, IAnimationContext context)
		{
			float num = originalCharacter.scale * originalCharacter.glyph.scale;
			new Vector2(cData.info.origin, cData.info.baseLine);
			float num2 = cData.info.referenceScale / num * newCharacter.scale * newCharacter.glyph.scale;
			float num3 = newCharacter.glyph.metrics.horizontalBearingX - originalCharacter.glyph.metrics.horizontalBearingX;
			float num4 = newCharacter.glyph.metrics.horizontalBearingY - originalCharacter.glyph.metrics.horizontalBearingY;
			float num5 = newCharacter.glyph.metrics.height - originalCharacter.glyph.metrics.height;
			float num6 = newCharacter.glyph.metrics.width - originalCharacter.glyph.metrics.width;
			Vector3 position = new Vector3(cData.InitialMesh.BL_Position.x + num3 * num2, cData.InitialMesh.BL_Position.y + (num4 - num5) * num2);
			Vector3 position2 = new Vector3(position.x, cData.InitialMesh.TL_Position.y + num4 * num2);
			Vector3 position3 = new Vector3(cData.InitialMesh.TR_Position.x + (num3 + num6) * num2, position2.y);
			Vector3 position4 = new Vector3(position3.x, position.y);
			TMP_FontAsset fontAsset = cData.info.fontAsset;
			Rect rect = new Rect(newCharacter.glyph.glyphRect.x - originalCharacter.glyph.glyphRect.x, newCharacter.glyph.glyphRect.y - originalCharacter.glyph.glyphRect.y, newCharacter.glyph.glyphRect.width - originalCharacter.glyph.glyphRect.width, newCharacter.glyph.glyphRect.height - originalCharacter.glyph.glyphRect.height);
			Vector2 value = new Vector2(cData.InitialMesh.BL_UV0.x + rect.x / (float)fontAsset.atlasWidth, cData.InitialMesh.BL_UV0.y + rect.y / (float)fontAsset.atlasHeight);
			Vector2 value2 = new Vector2(value.x, cData.InitialMesh.TL_UV0.y + (rect.y + rect.height) / (float)fontAsset.atlasHeight);
			Vector2 value3 = new Vector2(cData.InitialMesh.TR_UV0.x + (rect.x + rect.width) / (float)fontAsset.atlasWidth, value2.y);
			Vector2 value4 = new Vector2(value3.x, value.y);
			context.AnimatorContext.Modifiers.MeshModifiers.BL_Delta = Vector3.zero;
			context.AnimatorContext.Modifiers.MeshModifiers.TL_Delta = Vector3.zero;
			context.AnimatorContext.Modifiers.MeshModifiers.TR_Delta = Vector3.zero;
			context.AnimatorContext.Modifiers.MeshModifiers.BR_Delta = Vector3.zero;
			SetVertexRaw(0, position, cData, context);
			SetVertexRaw(1, position2, cData, context);
			SetVertexRaw(2, position3, cData, context);
			SetVertexRaw(3, position4, cData, context);
			cData.mesh.SetUV0(0, value);
			cData.mesh.SetUV0(1, value2);
			cData.mesh.SetUV0(2, value3);
			cData.mesh.SetUV0(3, value4);
		}

		public static float GetValue(AnimationCurve curve, WrapMode wrapMode, float time)
		{
			return GetValue(curve, wrapMode.ToTMPWrapMode(), time);
		}

		public static float GetValue(AnimationCurve curve, TMPWrapMode wrapMode, float time)
		{
			switch (wrapMode)
			{
			case TMPWrapMode.Loop:
			{
				float time2 = Mathf.Repeat(time, 1f);
				return curve.Evaluate(time2);
			}
			case TMPWrapMode.PingPong:
			{
				float time2 = Mathf.PingPong(time, 1f);
				return curve.Evaluate(time2);
			}
			case TMPWrapMode.Clamp:
				return curve.Evaluate(time);
			default:
				throw new ArgumentException("TMPWrapMode " + wrapMode.ToString() + " not supported");
			}
		}

		internal static TMPWrapMode ToTMPWrapMode(this WrapMode wrapMode)
		{
			return wrapMode switch
			{
				WrapMode.PingPong => TMPWrapMode.PingPong, 
				WrapMode.Once => TMPWrapMode.Clamp, 
				WrapMode.Loop => TMPWrapMode.Loop, 
				_ => throw new NotSupportedException("WrapMode " + wrapMode.ToString() + " can not be converted to TMPWrapMode"), 
			};
		}

		public static WrapMode ToWrapMode(this TMPWrapMode wrapMode)
		{
			return wrapMode switch
			{
				TMPWrapMode.PingPong => WrapMode.PingPong, 
				TMPWrapMode.Clamp => WrapMode.Once, 
				TMPWrapMode.Loop => WrapMode.Loop, 
				_ => throw new NotSupportedException("TMPWrapMode " + wrapMode.ToString() + " can not be converted to WrapMode"), 
			};
		}
	}
}
