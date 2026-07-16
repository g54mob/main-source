using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Toggle))]
public class ToggleSpriteSwitcher : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	[Header("Normal Sprites")]
	[SerializeField]
	private Sprite _onSprite;

	[SerializeField]
	private Sprite _offSprite;

	[Header("Hover Sprites")]
	[SerializeField]
	private Sprite _onHoverSprite;

	[SerializeField]
	private Sprite _offHoverSprite;

	[SerializeField]
	private Image _targetImage;

	private Toggle _toggle;

	private bool _isHovering;

	private void Awake()
	{
		_toggle = GetComponent<Toggle>();
		_toggle.onValueChanged.AddListener(UpdateVisuals);
		UpdateVisuals(_toggle.isOn);
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		_isHovering = true;
		UpdateVisuals(_toggle.isOn);
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		_isHovering = false;
		UpdateVisuals(_toggle.isOn);
	}

	private void UpdateVisuals(bool isOn)
	{
		if (_isHovering)
		{
			_targetImage.sprite = (isOn ? _onHoverSprite : _offHoverSprite);
		}
		else
		{
			_targetImage.sprite = (isOn ? _onSprite : _offSprite);
		}
	}
}
