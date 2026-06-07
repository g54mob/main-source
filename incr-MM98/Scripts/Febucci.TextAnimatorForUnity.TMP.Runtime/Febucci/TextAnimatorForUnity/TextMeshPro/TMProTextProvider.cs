using Febucci.TextAnimatorCore.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Febucci.TextAnimatorForUnity.TextMeshPro
{
	internal class TMProTextProvider : ITextGenerator
	{
		private TMP_TextInfo textInfo;

		private readonly TMP_InputField attachedInputField;

		private readonly TMP_Text tmpComponent;

		private bool autoSize;

		private Rect sourceRect;

		private Color sourceColor;

		private int tmpFirstVisibleCharacter;

		private int tmpMaxVisibleCharacters;

		private int lastFirstChar;

		private int lastMinChar;

		public TMProTextProvider(TMP_Text tmpComponent, TMP_InputField attachedInputField)
		{
			this.tmpComponent = tmpComponent;
			this.attachedInputField = attachedInputField;
			textInfo = tmpComponent.textInfo;
			tmpComponent.renderMode = TextRenderFlags.DontRender;
		}

		public string GetFullText()
		{
			return tmpComponent.text;
		}

		public string GetStrippedTextWithoutAnyTags(string textWithoutTAnimTags)
		{
			return tmpComponent.GetParsedText();
		}

		public void SetTextToSource(string text)
		{
			tmpComponent.renderMode = TextRenderFlags.DontRender;
			if ((bool)attachedInputField)
			{
				attachedInputField.text = text;
			}
			else
			{
				tmpComponent.text = text;
			}
			switch (tmpComponent.overflowMode)
			{
			default:
				LayoutRebuilder.ForceRebuildLayoutImmediate(tmpComponent.rectTransform);
				break;
			case TextOverflowModes.Overflow:
			case TextOverflowModes.Masking:
			case TextOverflowModes.ScrollRect:
				break;
			}
			ForceMeshUpdate();
			textInfo = tmpComponent.GetTextInfo(tmpComponent.text);
			tmpComponent.renderMode = TextRenderFlags.DontRender;
		}

		public int GetCharactersCount()
		{
			return textInfo.characterCount;
		}

		public bool HasChangedMeshRenderingSettings()
		{
			if (!tmpComponent.havePropertiesChanged && tmpComponent.enableAutoSizing == autoSize && !(tmpComponent.rectTransform.rect != sourceRect) && !(tmpComponent.color != sourceColor) && tmpComponent.firstVisibleCharacter == tmpFirstVisibleCharacter)
			{
				return tmpComponent.maxVisibleCharacters != tmpMaxVisibleCharacters;
			}
			return true;
		}

		public void CopyMeshFromSource(ref CharacterData[] characters, int charactersCount)
		{
			autoSize = tmpComponent.enableAutoSizing;
			sourceRect = tmpComponent.rectTransform.rect;
			sourceColor = tmpComponent.color;
			tmpFirstVisibleCharacter = tmpComponent.firstVisibleCharacter;
			tmpMaxVisibleCharacters = tmpComponent.maxVisibleCharacters;
			for (int i = 0; i < textInfo.characterCount && i < characters.Length; i++)
			{
				TMP_CharacterInfo tMP_CharacterInfo = textInfo.characterInfo[i];
				ref CharacterData reference = ref characters[i];
				reference.info.isRendered = tMP_CharacterInfo.isVisible;
				reference.info.character = tMP_CharacterInfo.character;
				if (tMP_CharacterInfo.isVisible)
				{
					TMP_MeshInfo tMP_MeshInfo = textInfo.meshInfo[tMP_CharacterInfo.materialReferenceIndex];
					reference.info.pointSize = tMP_CharacterInfo.pointSize;
					Color32 color = tMP_MeshInfo.colors32[tMP_CharacterInfo.vertexIndex];
					for (int j = 0; j < 4; j++)
					{
						reference.source.positions[j] = tMP_MeshInfo.vertices[tMP_CharacterInfo.vertexIndex + j];
						reference.source.colors[j] = color;
					}
				}
			}
		}

		public int GetRenderedCharactersCountInsidePage(int charactersCount)
		{
			if (tmpComponent.overflowMode == TextOverflowModes.Overflow)
			{
				return charactersCount;
			}
			return tmpComponent.firstOverflowCharacterIndex;
		}

		public int GetFirstCharacterIndexInsidePage()
		{
			if (tmpComponent.pageToDisplay <= 1)
			{
				return 0;
			}
			return tmpComponent.textInfo.pageInfo[tmpComponent.pageToDisplay - 1].firstCharacterIndex;
		}

		public void PasteMeshToSource(CharacterData[] characters, int charactersCount)
		{
			for (int i = 0; i < textInfo.characterCount && i < charactersCount; i++)
			{
				TMP_CharacterInfo tMP_CharacterInfo = textInfo.characterInfo[i];
				if (tMP_CharacterInfo.isVisible)
				{
					CharacterData characterData = characters[i];
					ref TMP_MeshInfo reference = ref textInfo.meshInfo[tMP_CharacterInfo.materialReferenceIndex];
					int vertexIndex = tMP_CharacterInfo.vertexIndex;
					for (int j = 0; j < 4; j++)
					{
						ref Vector3 reference2 = ref reference.vertices[vertexIndex + j];
						reference2.x = characterData.current.positions[j].X;
						reference2.y = characterData.current.positions[j].Y;
						reference2.z = characterData.current.positions[j].Z;
						ref Color32 reference3 = ref reference.colors32[vertexIndex + j];
						reference3.r = characterData.current.colors[j].R;
						reference3.g = characterData.current.colors[j].G;
						reference3.b = characterData.current.colors[j].B;
						reference3.a = characterData.current.colors[j].A;
					}
				}
			}
			tmpComponent.UpdateVertexData();
		}

		public void ForceMeshUpdate()
		{
			tmpComponent.ForceMeshUpdate(ignoreActiveState: true);
		}
	}
}
