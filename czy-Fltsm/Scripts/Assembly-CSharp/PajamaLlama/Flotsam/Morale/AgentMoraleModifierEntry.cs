using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PajamaLlama.Flotsam.Morale
{
	public class AgentMoraleModifierEntry : MonoBehaviour
	{
		[SerializeField]
		private TMP_Text _amountText;

		[SerializeField]
		private TMP_Text _descriptionText;

		[SerializeField]
		private Image _background;

		[SerializeField]
		private Image _icon;

		[SerializeField]
		private DrifterAttributesEffectTooltip _attributeTooltip;

		[Header("Color")]
		[SerializeField]
		private Color _textPositiveColor = Color.green;

		[SerializeField]
		private Color _textNegativeColor = Color.red;

		[SerializeField]
		private Color _backgroundPositiveColor = Color.green;

		[SerializeField]
		private Color _backgroundNegativeColor = Color.red;

		private MoraleEffect _modifier;

		public void Initialize(MoraleEffect modifier)
		{
			int num = modifier.ReturnModifier();
			bool flag = num > 0;
			string text = (flag ? ("+" + num) : num.ToString());
			_amountText.text = text;
			_amountText.color = (flag ? _textPositiveColor : _textNegativeColor);
			_background.color = (flag ? _backgroundPositiveColor : _backgroundNegativeColor);
			_descriptionText.text = modifier.ReturnDescription();
			_modifier = modifier;
			UpdateModifier();
			base.gameObject.SetActive(value: true);
		}

		private void UpdateModifier()
		{
			_icon.sprite = _modifier.ReturnSprite();
			if (_modifier.TryReturnAttributeEffect(out var effect))
			{
				_attributeTooltip.enabled = true;
				_attributeTooltip.Initialize(effect);
			}
			else
			{
				_attributeTooltip.enabled = false;
			}
		}
	}
}
