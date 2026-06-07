using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class IconWithLabel : MonoBehaviour
{
	[SerializeField]
	private Image _icon;

	[SerializeField]
	private bool _overrideIcon;

	[SerializeField]
	private TextMeshProUGUI _label;

	public void Initialize(Sprite sprite, string label)
	{
		if (_overrideIcon)
		{
			_icon.overrideSprite = sprite;
		}
		else
		{
			_icon.sprite = sprite;
		}
		_label.text = label;
	}
}
