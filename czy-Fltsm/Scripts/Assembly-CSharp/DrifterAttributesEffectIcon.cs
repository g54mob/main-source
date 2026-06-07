using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DrifterAttributesEffectIcon : MonoBehaviour
{
	[SerializeField]
	private TextMeshProUGUI _name;

	[SerializeField]
	private Image _image;

	[SerializeField]
	private DrifterAttributesEffectTooltip _tooltip;

	private DrifterAttributesEffect _effect;

	public void Initialize(DrifterAttributesEffect effect)
	{
		_effect = effect;
		base.gameObject.SetActive(value: true);
		_name.text = effect.Name;
		_image.sprite = effect.IconProperties.Sprite;
		_tooltip.Initialize(effect);
	}
}
