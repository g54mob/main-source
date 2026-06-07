using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Presentation.UI.ButtonHelpers
{
	public class TextLinkHelper : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
	{
		[SerializeField]
		private TextMeshProUGUI _text;

		public Action<string> OnClick;

		private void Awake()
		{
			if (_text == null)
			{
				_text = GetComponent<TextMeshProUGUI>();
			}
		}

		public void OnPointerClick(PointerEventData eventData)
		{
			if (!(_text == null))
			{
				int num = TMP_TextUtilities.FindIntersectingLink(_text, Input.mousePosition, null);
				if (num >= 0 && num < _text.textInfo.linkInfo.Length)
				{
					string linkID = _text.textInfo.linkInfo[num].GetLinkID();
					OnClick?.Invoke(linkID);
				}
			}
		}
	}
}
