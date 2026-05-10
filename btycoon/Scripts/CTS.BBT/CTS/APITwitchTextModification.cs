using System.Collections.Generic;
using NaughtyAttributes;
using TMPro;
using UnityEngine;

namespace CTS
{
	public class APITwitchTextModification : MonoBehaviour
	{
		[SerializeField]
		private List<GameObject> _textList = new List<GameObject>();

		[SerializeField]
		private List<GameObject> _titleList = new List<GameObject>();

		[SerializeField]
		private TMP_FontAsset _fontForTitle;

		[SerializeField]
		private TMP_FontAsset _fontFortText;

		[Button(null, EButtonEnableMode.Always)]
		public void ModificationText()
		{
			foreach (GameObject text in _textList)
			{
				TMP_Text component = text.GetComponent<TMP_Text>();
				TMP_InputField component2 = text.GetComponent<TMP_InputField>();
				if (component2 != null)
				{
					component2.placeholder.GetComponent<TMP_Text>().font = _fontFortText;
					component2.textComponent.font = _fontFortText;
				}
				if (component != null)
				{
					component.font = _fontFortText;
				}
			}
			foreach (GameObject title in _titleList)
			{
				TMP_Text component3 = title.GetComponent<TMP_Text>();
				if (component3 != null)
				{
					component3.font = _fontForTitle;
				}
			}
		}
	}
}
