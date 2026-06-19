using System;
using System.Collections.Generic;
using TMPEffects.CharacterData;
using TMPEffects.Databases;
using TMPEffects.Parameters;
using TMPro;
using UnityEngine;

namespace TMPEffects.TMPAnimations.Animations
{
	internal class SpriteAnimation : ITMPAnimation, ITMPParameterValidator
	{
		private class Data
		{
			public int start;

			public int end;

			public int framerate;

			public string evaluation;

			public int iterations;

			public Dictionary<int, Data2> datas;
		}

		private class Data2
		{
			public int currentFrame;

			public float baseSpriteScale;

			public float targetTime;

			public int finishedIterations;

			public Vector2 uv0_0;

			public Vector2 uv0_1;

			public Vector2 uv0_2;

			public Vector2 uv0_3;

			public Vector3 vert_0;

			public Vector3 vert_1;

			public Vector3 vert_2;

			public Vector3 vert_3;

			public bool init;
		}

		public void Animate(CharData cData, IAnimationContext context)
		{
			if (cData.info.elementType != TMP_TextElementType.Sprite || cData.info.character == '\u0003' || cData.info.character == '…')
			{
				return;
			}
			Data data = context.CustomData as Data;
			Data2 data2;
			if (!data.datas.ContainsKey(cData.info.index))
			{
				data2 = new Data2();
				if (data.framerate < 0)
				{
					data2.currentFrame = data.end;
				}
				else
				{
					data2.currentFrame = data.start;
				}
				if (data.end > cData.info.spriteAsset.spriteCharacterTable.Count)
				{
					data.end = cData.info.spriteAsset.spriteCharacterTable.Count - 1;
				}
				data2.baseSpriteScale = cData.info.spriteAsset.spriteCharacterTable[data.start].scale * cData.info.spriteAsset.spriteCharacterTable[data.start].glyph.scale;
				data2.targetTime = 0f;
				data.datas.Add(cData.info.index, data2);
			}
			else
			{
				data2 = data.datas[cData.info.index];
			}
			if (data.iterations >= 0 && data.iterations <= data2.finishedIterations)
			{
				TMP_SpriteAsset spriteAsset = cData.info.spriteAsset;
				data2.targetTime = 1f / (float)Mathf.Abs(data.framerate) + context.AnimatorContext.PassedTime;
				TMP_SpriteCharacter tMP_SpriteCharacter = cData.info.spriteAsset.spriteCharacterTable[(data.framerate > 0) ? data.end : data.start];
				Vector2 vector = new Vector2(cData.info.origin, cData.info.baseLine);
				float num = cData.info.referenceScale / data2.baseSpriteScale * tMP_SpriteCharacter.scale * tMP_SpriteCharacter.glyph.scale;
				Vector3 vert_ = new Vector3(vector.x + tMP_SpriteCharacter.glyph.metrics.horizontalBearingX * num, vector.y + (tMP_SpriteCharacter.glyph.metrics.horizontalBearingY - tMP_SpriteCharacter.glyph.metrics.height) * num);
				Vector3 vert_2 = new Vector3(vert_.x, vector.y + tMP_SpriteCharacter.glyph.metrics.horizontalBearingY * num);
				Vector3 vert_3 = new Vector3(vector.x + (tMP_SpriteCharacter.glyph.metrics.horizontalBearingX + tMP_SpriteCharacter.glyph.metrics.width) * num, vert_2.y);
				Vector3 vert_4 = new Vector3(vert_3.x, vert_.y);
				data2.vert_0 = vert_;
				data2.vert_1 = vert_2;
				data2.vert_2 = vert_3;
				data2.vert_3 = vert_4;
				Vector2 uv0_ = new Vector2((float)tMP_SpriteCharacter.glyph.glyphRect.x / (float)spriteAsset.spriteSheet.width, (float)tMP_SpriteCharacter.glyph.glyphRect.y / (float)spriteAsset.spriteSheet.height);
				Vector2 uv0_2 = new Vector2(uv0_.x, (float)(tMP_SpriteCharacter.glyph.glyphRect.y + tMP_SpriteCharacter.glyph.glyphRect.height) / (float)spriteAsset.spriteSheet.height);
				Vector2 uv0_3 = new Vector2((float)(tMP_SpriteCharacter.glyph.glyphRect.x + tMP_SpriteCharacter.glyph.glyphRect.width) / (float)spriteAsset.spriteSheet.width, uv0_2.y);
				Vector2 uv0_4 = new Vector2(uv0_3.x, uv0_.y);
				data2.uv0_0 = uv0_;
				data2.uv0_1 = uv0_2;
				data2.uv0_2 = uv0_3;
				data2.uv0_3 = uv0_4;
			}
			else if (context.AnimatorContext.PassedTime >= data2.targetTime)
			{
				TMP_SpriteAsset spriteAsset2 = cData.info.spriteAsset;
				data2.targetTime = 1f / (float)Mathf.Abs(data.framerate) + context.AnimatorContext.PassedTime;
				TMP_SpriteCharacter tMP_SpriteCharacter2;
				switch (data.evaluation)
				{
				case "pingpong":
				case "pp":
					if (data.framerate > 0)
					{
						int num2 = data2.currentFrame % (data.end * 2);
						if (num2 > data.end)
						{
							num2 = data.end - (num2 - data.end);
						}
						tMP_SpriteCharacter2 = spriteAsset2.spriteCharacterTable[num2];
						data2.currentFrame++;
						if (Mathf.Abs(data2.currentFrame) == data.end + (data.end - data.start))
						{
							data2.currentFrame = data.start;
							data2.finishedIterations++;
						}
					}
					else
					{
						int num3 = data2.currentFrame % (data.start * 2);
						if (num3 < data.start)
						{
							num3 = data.start - (num3 - data.start);
						}
						tMP_SpriteCharacter2 = spriteAsset2.spriteCharacterTable[num3];
						data2.currentFrame--;
						if (Mathf.Abs(data2.currentFrame) == data.start - (data.end - data.start))
						{
							data2.currentFrame = data.end;
							data2.finishedIterations++;
						}
					}
					break;
				case "loop":
				case "lp":
					tMP_SpriteCharacter2 = spriteAsset2.spriteCharacterTable[data2.currentFrame];
					if (data.framerate > 0)
					{
						if (data2.currentFrame < data.end)
						{
							data2.currentFrame++;
							break;
						}
						data2.currentFrame = data.start;
						data2.finishedIterations++;
					}
					else if (data2.currentFrame > data.start)
					{
						data2.currentFrame--;
					}
					else
					{
						data2.currentFrame = data.end;
						data2.finishedIterations++;
					}
					break;
				default:
					throw new Exception("Invalid evaluation state");
				}
				Vector2 vector2 = new Vector2(cData.info.origin, cData.info.baseLine);
				float num4 = cData.info.referenceScale / data2.baseSpriteScale * tMP_SpriteCharacter2.scale * tMP_SpriteCharacter2.glyph.scale;
				Vector3 vert_5 = new Vector3(vector2.x + tMP_SpriteCharacter2.glyph.metrics.horizontalBearingX * num4, vector2.y + (tMP_SpriteCharacter2.glyph.metrics.horizontalBearingY - tMP_SpriteCharacter2.glyph.metrics.height) * num4);
				Vector3 vert_6 = new Vector3(vert_5.x, vector2.y + tMP_SpriteCharacter2.glyph.metrics.horizontalBearingY * num4);
				Vector3 vert_7 = new Vector3(vector2.x + (tMP_SpriteCharacter2.glyph.metrics.horizontalBearingX + tMP_SpriteCharacter2.glyph.metrics.width) * num4, vert_6.y);
				Vector3 vert_8 = new Vector3(vert_7.x, vert_5.y);
				data2.vert_0 = vert_5;
				data2.vert_1 = vert_6;
				data2.vert_2 = vert_7;
				data2.vert_3 = vert_8;
				Vector2 uv0_5 = new Vector2((float)tMP_SpriteCharacter2.glyph.glyphRect.x / (float)spriteAsset2.spriteSheet.width, (float)tMP_SpriteCharacter2.glyph.glyphRect.y / (float)spriteAsset2.spriteSheet.height);
				Vector2 uv0_6 = new Vector2(uv0_5.x, (float)(tMP_SpriteCharacter2.glyph.glyphRect.y + tMP_SpriteCharacter2.glyph.glyphRect.height) / (float)spriteAsset2.spriteSheet.height);
				Vector2 uv0_7 = new Vector2((float)(tMP_SpriteCharacter2.glyph.glyphRect.x + tMP_SpriteCharacter2.glyph.glyphRect.width) / (float)spriteAsset2.spriteSheet.width, uv0_6.y);
				Vector2 uv0_8 = new Vector2(uv0_7.x, uv0_5.y);
				data2.uv0_0 = uv0_5;
				data2.uv0_1 = uv0_6;
				data2.uv0_2 = uv0_7;
				data2.uv0_3 = uv0_8;
			}
			cData.mesh.SetPosition(0, data2.vert_0);
			cData.mesh.SetPosition(1, data2.vert_1);
			cData.mesh.SetPosition(2, data2.vert_2);
			cData.mesh.SetPosition(3, data2.vert_3);
			cData.mesh.SetUV0(0, data2.uv0_0);
			cData.mesh.SetUV0(1, data2.uv0_1);
			cData.mesh.SetUV0(2, data2.uv0_2);
			cData.mesh.SetUV0(3, data2.uv0_3);
		}

		public object GetNewCustomData()
		{
			return new Data
			{
				datas = new Dictionary<int, Data2>(),
				start = 0,
				end = 0,
				framerate = 0,
				evaluation = "loop",
				iterations = -1
			};
		}

		public void SetParameters(object customData, IDictionary<string, string> parameters, ITMPKeywordDatabase keywordDatabase)
		{
			Data data = customData as Data;
			string[] array = parameters["anim"].Split(',');
			if (ParameterParsing.StringToInt(array[0], out var result))
			{
				data.start = result;
			}
			if (ParameterParsing.StringToInt(array[1], out result))
			{
				data.end = result;
			}
			if (ParameterParsing.StringToInt(array[2], out result))
			{
				data.framerate = result;
			}
			if (TMPParameterUtility.TryGetIntParameter(out var value, parameters, "iterations", "iter"))
			{
				data.iterations = value;
			}
			if (TMPParameterUtility.TryGetDefinedParameter(out var value2, parameters, "evaluation", "eval"))
			{
				switch (parameters[value2])
				{
				case "pingpong":
				case "pp":
				case "loop":
				case "lp":
					data.evaluation = parameters[value2];
					break;
				}
			}
		}

		public bool ValidateParameters(IDictionary<string, string> parameters, ITMPKeywordDatabase keywordDatabase)
		{
			if (parameters == null)
			{
				return false;
			}
			if (!parameters.ContainsKey("anim"))
			{
				return false;
			}
			if (parameters["anim"].Split(',').Length != 3)
			{
				return false;
			}
			return true;
		}
	}
}
