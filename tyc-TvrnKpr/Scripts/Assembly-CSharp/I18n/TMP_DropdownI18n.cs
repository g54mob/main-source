using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine.EventSystems;

namespace I18n
{
	public class TMP_DropdownI18n : TMP_Dropdown
	{
		private int _fontIndex;

		private int _captionFontIndex;

		private int _itemTemplateFontIndex;

		private List<OptionData> _options;

		private bool _dirty;

		public int FontIndex => 0;

		protected override void OnEnable()
		{
		}

		protected override void Start()
		{
		}

		protected override void OnDestroy()
		{
		}

		private void UpdateText()
		{
		}

		private void UpdateFonts()
		{
		}

		private void OnLanguageChanged(object sender, EventArgs e)
		{
		}

		public void SetOptions(List<OptionData> optionsWithKeys)
		{
		}

		public string GetCurrentEnglishText()
		{
			return null;
		}

		public override void OnPointerClick(PointerEventData eventData)
		{
		}

		public override void OnSubmit(BaseEventData eventData)
		{
		}
	}
}
