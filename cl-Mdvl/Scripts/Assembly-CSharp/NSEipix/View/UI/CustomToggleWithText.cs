using NSMedieval.UI.Utils;
using TMPro;
using UnityEngine;

namespace NSEipix.View.UI
{
	public class CustomToggleWithText : CustomToggle
	{
		[SerializeField]
		private TMP_Text textLabel;

		[SerializeField]
		private string textKeyOn;

		[SerializeField]
		private string textKeyOff;

		public override void SetValue(bool isOn)
		{
			base.SetValue(isOn);
			UpdateText();
		}

		public void SetIsOnSilently(bool value)
		{
			SetIsOnWithoutNotify(value);
			UpdateText();
		}

		private void UpdateText()
		{
			textLabel.text = (base.isOn ? textKeyOn.ToLocalized() : textKeyOff.ToLocalized());
		}
	}
}
