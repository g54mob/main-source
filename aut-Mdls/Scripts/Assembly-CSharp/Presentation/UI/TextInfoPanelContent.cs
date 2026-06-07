using Events.UI;
using NaughtyAttributes;
using TMPro;
using UnityEngine;

namespace Presentation.UI
{
	public class TextInfoPanelContent : InfoPanelContent
	{
		[SerializeField]
		[LocaKey]
		private string _textLocaKey;

		[SerializeField]
		private bool _enableWrapping = true;

		[SerializeField]
		private bool _localizeText = true;

		[SerializeField]
		private bool _onlyShowWhenTextOverflows;

		[SerializeField]
		[ShowIf("_onlyShowWhenTextOverflows")]
		private TextMeshProUGUI _textReference;

		private string _replacementText1;

		private string _replacementText2;

		private string _replacementText3;

		private void OnEnable()
		{
			LocalizationUtility.OnLanguageUpdate += CheckOverflow;
			CheckOverflow();
		}

		protected override void OnDisable()
		{
			LocalizationUtility.OnLanguageUpdate -= CheckOverflow;
			base.OnDisable();
		}

		public void UpdateContent(string textLocaKey, string replacementText1 = "", string replacementText2 = "", string replacementText3 = "")
		{
			_textLocaKey = textLocaKey;
			_replacementText1 = replacementText1;
			_replacementText2 = replacementText2;
			_replacementText3 = replacementText3;
			CheckOverflow();
		}

		protected override InfoPanelDto GetInfoPanelDto()
		{
			return new TextInfoPanelDto(_textLocaKey, _enableWrapping, _localizeText, _replacementText1, _replacementText2, _replacementText3);
		}

		private void CheckOverflow()
		{
			if (_onlyShowWhenTextOverflows && _textReference != null)
			{
				base.enabled = _textReference.isTextOverflowing || _textReference.preferredWidth > _textReference.rectTransform.rect.width;
			}
		}
	}
}
