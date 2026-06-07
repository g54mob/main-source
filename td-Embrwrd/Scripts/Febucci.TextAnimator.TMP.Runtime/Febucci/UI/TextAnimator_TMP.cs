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

		public TMP_Text TMProComponent => null;

		[Obsolete("Please use TMProComponent instead.")]
		public TMP_Text tmproText => null;

		private void CacheComponentsOnce()
		{
		}

		protected override void OnInitialized()
		{
		}

		protected override TagParserBase[] GetExtraParsers()
		{
			return null;
		}

		public override string GetOriginalTextFromSource()
		{
			return null;
		}

		public override string GetStrippedTextFromSource()
		{
			return null;
		}

		public override void SetTextToSource(string text)
		{
		}

		protected override int GetCharactersCount()
		{
			return 0;
		}

		protected override bool HasChangedRenderingSettings()
		{
			return false;
		}

		protected override bool HasChangedText(string strippedText)
		{
			return false;
		}

		protected override void CopyMeshFromSource(ref CharacterData[] characters)
		{
		}

		protected override void PasteMeshToSource(CharacterData[] characters)
		{
		}

		protected override void OnForceMeshUpdate()
		{
		}

		[Obsolete("This method is Obsolete. Please check through the 'Characters' array instead.")]
		public bool TryGetNextCharacter(out TMP_CharacterInfo result)
		{
			result = default(TMP_CharacterInfo);
			return false;
		}
	}
}
