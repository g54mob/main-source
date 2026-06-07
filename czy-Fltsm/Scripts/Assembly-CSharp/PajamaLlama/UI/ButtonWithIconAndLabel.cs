using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PajamaLlama.UI
{
	public class ButtonWithIconAndLabel : CustomButton
	{
		[SerializeField]
		private TextMeshProUGUI _label;

		[SerializeField]
		private Image _icon;

		[SerializeField]
		private Image _iconDisabled;

		public void Initialize(LocalizedString label, Sprite icon = null, Sprite iconDisabled = null)
		{
			_label.text = label;
			_icon.overrideSprite = icon;
			_iconDisabled.overrideSprite = iconDisabled;
		}
	}
}
