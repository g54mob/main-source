using System.Collections.Generic;
using I2.Loc;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(EventTrigger))]
public class ImageDropdown : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
{
	public delegate void DropdownEvent(int index);

	[Header("Selected")]
	[SerializeField]
	[Tooltip("Image component of this dropdown.")]
	public Image Image;

	[SerializeField]
	[Tooltip("Background image component of this dropdown.")]
	public Image BackgroundImage;

	[SerializeField]
	[Tooltip("Text component of this dropdown.")]
	public Text Text;

	[Header("Options")]
	[SerializeField]
	[Tooltip("Parent transform for all the options.")]
	private Transform _optionsParent;

	[SerializeField]
	[Tooltip("Prefab for an option.")]
	private ImageDropdownOption _optionPrefab;

	private List<ImageDropdownOption> _options = new List<ImageDropdownOption>();

	private bool _wasToggledThisFrame;

	private Tooltip _tooltip;

	public event DropdownEvent OnOptionSelectEvent;

	private void Awake()
	{
		_tooltip = GetComponent<Tooltip>();
		if (_tooltip == null)
		{
			_tooltip = base.gameObject.AddComponent<Tooltip>();
		}
	}

	private void Update()
	{
		if (Input.GetMouseButtonUp(0))
		{
			CloseOptions();
		}
		_wasToggledThisFrame = false;
	}

	private void OnDestroy()
	{
		ClearOptions();
	}

	public void OnPointerClick(PointerEventData pointerEventData)
	{
		if (pointerEventData.button == PointerEventData.InputButton.Left)
		{
			OpenOptions();
		}
	}

	private void OpenOptions()
	{
		if (!_wasToggledThisFrame && !_optionsParent.gameObject.activeSelf)
		{
			_optionsParent.gameObject.SetActive(value: true);
			_wasToggledThisFrame = true;
		}
	}

	private void CloseOptions()
	{
		if (!_wasToggledThisFrame && _optionsParent.gameObject.activeSelf)
		{
			_optionsParent.gameObject.SetActive(value: false);
			_wasToggledThisFrame = false;
		}
	}

	public void ClearOptions()
	{
		for (int i = 0; i < _options.Count; i++)
		{
			_options[i].OnLeftClickEvent -= SelectOption;
			Object.Destroy(_options[i].gameObject);
		}
		_options.Clear();
		_optionsParent.gameObject.SetActive(value: false);
	}

	public void AddOption(Sprite sprite, Color backgroundColor, string text, int optionIndex, LocalizedString tooltipText)
	{
		ImageDropdownOption imageDropdownOption = Object.Instantiate(_optionPrefab, _optionsParent);
		imageDropdownOption.Initialize(sprite, backgroundColor, text, optionIndex, tooltipText);
		_options.Add(imageDropdownOption);
		imageDropdownOption.OnLeftClickEvent += SelectOption;
	}

	public void SelectOption(int optionIndex)
	{
		ImageDropdownOption imageDropdownOption = _options[optionIndex];
		Image.sprite = imageDropdownOption.Image.sprite;
		if (BackgroundImage != null)
		{
			BackgroundImage.color = imageDropdownOption.BackgroundImage.color;
		}
		if (Text != null && imageDropdownOption.Text != null)
		{
			Text.text = imageDropdownOption.Text.text;
		}
		if (this.OnOptionSelectEvent != null)
		{
			this.OnOptionSelectEvent(optionIndex);
		}
		_tooltip.LocalizedText = imageDropdownOption.Tooltip.LocalizedText;
		_optionsParent.gameObject.SetActive(value: false);
	}
}
