using I2.Loc;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;

[RequireComponent(typeof(EventTrigger))]
public class ImageDropdownOption : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
{
	public delegate void OptionEvent(int index);

	[SerializeField]
	[Tooltip("Background image component of this dropdown option. This is optional.")]
	public Image BackgroundImage;

	[SerializeField]
	[Tooltip("Image component of this dropdown option. This is required.")]
	public Image Image;

	[SerializeField]
	[Tooltip("Text component of this dropdown option. This is optional.")]
	public Text Text;

	[SerializeField]
	[Tooltip("The game object that holds the fuel icon image.")]
	[FormerlySerializedAs("FuelIconObject")]
	private GameObject _fuelIconObject;

	private int _optionIndex;

	[HideInInspector]
	public Tooltip Tooltip;

	public event OptionEvent OnLeftClickEvent;

	public void Initialize(Sprite sprite, Color backgroundColor, string text, int optionIndex, LocalizedString tooltipText)
	{
		Image.sprite = sprite;
		if (BackgroundImage != null)
		{
			BackgroundImage.color = backgroundColor;
		}
		if (text == null)
		{
			_fuelIconObject.SetActive(value: false);
		}
		if (Text != null)
		{
			Text.text = text;
		}
		_optionIndex = optionIndex;
		if (Tooltip == null)
		{
			Tooltip = GetComponent<Tooltip>();
			if (Tooltip == null)
			{
				Tooltip = base.gameObject.AddComponent<Tooltip>();
			}
		}
		Tooltip.LocalizedText = tooltipText;
	}

	public void OnPointerClick(PointerEventData pointerEventData)
	{
		if (pointerEventData.button == PointerEventData.InputButton.Left && this.OnLeftClickEvent != null)
		{
			this.OnLeftClickEvent(_optionIndex);
		}
	}
}
