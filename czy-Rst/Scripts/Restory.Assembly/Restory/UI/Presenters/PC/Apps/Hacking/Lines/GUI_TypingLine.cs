using Restory.ObjectPools;
using TMPro;
using UnityEngine;

namespace Restory.UI.Presenters.PC.Apps.Hacking.Lines
{
	public class GUI_TypingLine : MonoBehaviour, ICleanableComponent
	{
		[SerializeField]
		private TMP_Text lineText;

		[SerializeField]
		private Transform caretContainer;

		[SerializeField]
		private Vector2 caretOffset;

		private int lineLength;

		private int caretPosition;

		public void Init(string text, Transform typingCaret)
		{
			lineText.text = text;
			lineLength = text.Length;
			caretContainer.localPosition = Vector2.zero;
			typingCaret.transform.SetParent(caretContainer);
			typingCaret.transform.localPosition = caretOffset;
			SkipCaretPosition();
		}

		public void PerformTyping(int symbolsPerKeyDown, out bool isLineComplete)
		{
			AdvanceVisibleCharacterCount(symbolsPerKeyDown);
			lineText.maxVisibleCharacters = caretPosition;
			isLineComplete = caretPosition >= lineLength;
			SyncTypingCaretTransform();
		}

		private void SkipCaretPosition()
		{
			caretPosition = 0;
			lineText.maxVisibleCharacters = 0;
			SyncTypingCaretTransform();
		}

		private void AdvanceVisibleCharacterCount(int symbolsPerKeyDown)
		{
			int num = caretPosition + symbolsPerKeyDown;
			for (int i = caretPosition; i < lineLength; i++)
			{
				caretPosition = i + 1;
				if (caretPosition >= num)
				{
					return;
				}
			}
			caretPosition = lineLength;
		}

		private void SyncTypingCaretTransform()
		{
			lineText.ForceMeshUpdate();
			TMP_TextInfo textInfo = lineText.textInfo;
			Vector3 caretLocalPosition = GetCaretLocalPosition(textInfo);
			caretContainer.localPosition = new Vector2(caretLocalPosition.x, 0f) + caretOffset;
		}

		private Vector3 GetCaretLocalPosition(TMP_TextInfo textInfo)
		{
			if (caretPosition <= 0)
			{
				return textInfo.characterInfo[0].bottomLeft;
			}
			int num = caretPosition - 1;
			if (num >= textInfo.characterCount)
			{
				num = textInfo.characterCount - 1;
			}
			return textInfo.characterInfo[num].bottomRight;
		}

		public void Clean()
		{
			lineText.text = string.Empty;
			lineLength = 0;
			SkipCaretPosition();
		}
	}
}
