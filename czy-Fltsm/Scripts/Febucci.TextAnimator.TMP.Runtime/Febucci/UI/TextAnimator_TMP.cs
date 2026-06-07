using System;
using Febucci.UI.Core;
using Febucci.UI.Core.Parsing;
using TMPro;
using UnityEngine;

namespace Febucci.UI
{
	[RequireComponent(typeof(TMP_Text))]
	[AddComponentMenu("Febucci/TextAnimator/Text Animator - Text Mesh Pro")]
	public sealed class TextAnimator_TMP : TAnimCore
	{
		private TMP_Text tmpComponent;

		private TMP_TextInfo textInfo;

		private TMP_InputField attachedInputField;

		private bool autoSize;

		private Rect sourceRect;

		private Color sourceColor;

		private int tmpFirstVisibleCharacter;

		private int tmpMaxVisibleCharacters;

		private bool componentsCached;

		private bool isUI;

		public TMP_Text TMProComponent
		{
			get
			{
				if ((bool)tmpComponent)
				{
					return tmpComponent;
				}
				CacheComponentsOnce();
				return tmpComponent;
			}
		}

		[Obsolete("Please use TMProComponent instead.")]
		public TMP_Text tmproText => TMProComponent;

		private void CacheComponentsOnce()
		{
			if (!componentsCached)
			{
				if (!base.gameObject.TryGetComponent<TMP_Text>(out tmpComponent))
				{
					Debug.LogError("TextAnimator_TMP " + base.name + " requires a TMP_Text component to work.", base.gameObject);
				}
				base.gameObject.TryGetComponent<TMP_InputField>(out attachedInputField);
				componentsCached = true;
				isUI = tmpComponent is TextMeshProUGUI;
			}
		}

		protected override void OnInitialized()
		{
			CacheComponentsOnce();
			tmpComponent.renderMode = TextRenderFlags.DontRender;
		}

		protected override void OnEnable()
		{
			base.OnEnable();
			textInfo = TMProComponent.textInfo;
		}

		protected override TagParserBase[] GetExtraParsers()
		{
			return new TagParserBase[1]
			{
				new TMPTagParser(tmpComponent.richText, '<', '/', '>')
			};
		}

		public override string GetOriginalTextFromSource()
		{
			return TMProComponent.text;
		}

		public override string GetStrippedTextFromSource()
		{
			return tmpComponent.GetParsedText();
		}

		public override void SetTextToSource(string text)
		{
			TMProComponent.renderMode = TextRenderFlags.DontRender;
			if ((bool)attachedInputField)
			{
				attachedInputField.text = text;
			}
			else
			{
				tmpComponent.text = text;
			}
			OnForceMeshUpdate();
			textInfo = tmpComponent.GetTextInfo(tmpComponent.text);
			tmpComponent.renderMode = TextRenderFlags.DontRender;
		}

		protected override bool IsReady()
		{
			if (componentsCached)
			{
				if (isUI)
				{
					return tmpComponent.canvas;
				}
				return true;
			}
			return false;
		}

		protected override int GetCharactersCount()
		{
			return textInfo.characterCount;
		}

		protected override bool HasChangedRenderingSettings()
		{
			if (!tmpComponent.havePropertiesChanged && tmpComponent.enableAutoSizing == autoSize && !(tmpComponent.rectTransform.rect != sourceRect) && !(tmpComponent.color != sourceColor) && tmpComponent.firstVisibleCharacter == tmpFirstVisibleCharacter)
			{
				return tmpComponent.maxVisibleCharacters != tmpMaxVisibleCharacters;
			}
			return true;
		}

		protected override bool HasChangedText(string strippedText)
		{
			if (string.IsNullOrEmpty(tmpComponent.text) && string.IsNullOrEmpty(strippedText))
			{
				return false;
			}
			if (string.IsNullOrEmpty(tmpComponent.text) != string.IsNullOrEmpty(strippedText))
			{
				return true;
			}
			return !tmpComponent.text.Equals(strippedText);
		}

		protected override void CopyMeshFromSource(ref CharacterData[] characters)
		{
			autoSize = tmpComponent.enableAutoSizing;
			sourceRect = tmpComponent.rectTransform.rect;
			sourceColor = tmpComponent.color;
			tmpFirstVisibleCharacter = tmpComponent.firstVisibleCharacter;
			tmpMaxVisibleCharacters = tmpComponent.maxVisibleCharacters;
			for (int i = 0; i < textInfo.characterCount && i < characters.Length; i++)
			{
				TMP_CharacterInfo tMP_CharacterInfo = textInfo.characterInfo[i];
				characters[i].info.isRendered = tMP_CharacterInfo.isVisible;
				characters[i].info.character = tMP_CharacterInfo.character;
				if (tMP_CharacterInfo.isVisible)
				{
					characters[i].info.pointSize = tMP_CharacterInfo.pointSize;
					for (byte b = 0; b < 4; b++)
					{
						characters[i].source.positions[b] = textInfo.meshInfo[tMP_CharacterInfo.materialReferenceIndex].vertices[tMP_CharacterInfo.vertexIndex + b];
					}
					for (byte b2 = 0; b2 < 4; b2++)
					{
						characters[i].source.colors[b2] = textInfo.meshInfo[tMP_CharacterInfo.materialReferenceIndex].colors32[tMP_CharacterInfo.vertexIndex + b2];
					}
				}
			}
		}

		protected override void PasteMeshToSource(CharacterData[] characters)
		{
			for (int i = 0; i < textInfo.characterCount && i < base.CharactersCount; i++)
			{
				TMP_CharacterInfo tMP_CharacterInfo = textInfo.characterInfo[i];
				if (tMP_CharacterInfo.isVisible)
				{
					for (byte b = 0; b < 4; b++)
					{
						textInfo.meshInfo[tMP_CharacterInfo.materialReferenceIndex].vertices[tMP_CharacterInfo.vertexIndex + b] = characters[i].current.positions[b];
					}
					for (byte b2 = 0; b2 < 4; b2++)
					{
						textInfo.meshInfo[tMP_CharacterInfo.materialReferenceIndex].colors32[tMP_CharacterInfo.vertexIndex + b2] = characters[i].current.colors[b2];
					}
				}
			}
			tmpComponent.UpdateVertexData();
		}

		protected override void OnForceMeshUpdate()
		{
			tmpComponent.ForceMeshUpdate(ignoreActiveState: true);
		}

		[Obsolete("This method is Obsolete. Please check through the 'Characters' array instead.")]
		public bool TryGetNextCharacter(out TMP_CharacterInfo result)
		{
			if (base.latestCharacterShown.index < base.CharactersCount - 1)
			{
				result = textInfo.characterInfo[base.latestCharacterShown.index + 1];
				return true;
			}
			result = default(TMP_CharacterInfo);
			return false;
		}
	}
}
