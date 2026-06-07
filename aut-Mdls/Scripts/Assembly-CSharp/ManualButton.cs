using DG.Tweening;
using Data.Variables;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ManualButton : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	[SerializeField]
	private Toggle _toggle;

	[SerializeField]
	private TextMeshProUGUI _text;

	[SerializeField]
	private CanvasGroup _hover;

	private ManualButtonLoader _manualButtonLoader;

	private ManualPageSO _linkedPage;

	private Color _normalColor;

	private Color _selectedColor;

	private BoolVariableSO _requiredUnlockCondition;

	private void Awake()
	{
		LocalizationUtility.OnLanguageUpdate += OnLanguageUpdate;
	}

	private void OnDestroy()
	{
		LocalizationUtility.OnLanguageUpdate -= OnLanguageUpdate;
		_hover.alpha = 0f;
		_toggle.onValueChanged.RemoveListener(OnButtonClicked);
		if (_requiredUnlockCondition != null)
		{
			_requiredUnlockCondition.ValueChanged -= HandleRequiredUnlockConditionChanged;
		}
	}

	public void Setup(ManualPageSO linkedPage, ToggleGroup group, ManualButtonLoader manualButtonLoader, BoolVariableSO requiredUnlockCondition)
	{
		_manualButtonLoader = manualButtonLoader;
		_linkedPage = linkedPage;
		if (requiredUnlockCondition != null)
		{
			_requiredUnlockCondition = requiredUnlockCondition;
			requiredUnlockCondition.ValueChanged += HandleRequiredUnlockConditionChanged;
			HandleRequiredUnlockConditionChanged(requiredUnlockCondition.Value);
		}
		SetupToggle(group);
		SetText(_linkedPage.PageNameLoca);
	}

	private void HandleRequiredUnlockConditionChanged(bool unlocked)
	{
		base.gameObject.SetActive(unlocked);
	}

	private void OnLanguageUpdate()
	{
		SetText(_linkedPage.PageNameLoca);
	}

	private void SetupToggle(ToggleGroup toggleGroup)
	{
		_toggle.group = toggleGroup;
		ColorBlock colors = _toggle.colors;
		_normalColor = colors.normalColor;
		_selectedColor = colors.selectedColor;
		_toggle.onValueChanged.AddListener(OnButtonClicked);
		UpdateToggleColor(_normalColor, _selectedColor);
	}

	public void SetText(string localizationKey)
	{
		_text.SetText(LocalizationUtility.GetLocalizedText(localizationKey));
	}

	private void UpdateToggleColor(Color normalColor, Color selectedColor)
	{
		ColorBlock colors = _toggle.colors;
		colors.normalColor = (_toggle.isOn ? selectedColor : normalColor);
		_toggle.colors = colors;
	}

	private void OnButtonClicked(bool value)
	{
		if (value)
		{
			ShowHover(value: false);
		}
		_manualButtonLoader.OnManualButtonClicked(_toggle, value, _linkedPage);
		UpdateToggleColor(_normalColor, _selectedColor);
	}

	private void OnDisable()
	{
		_hover.DOKill();
		_hover.alpha = 0f;
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		ShowHover(value: true);
	}

	public void OnPointerExit(PointerEventData eventData = null)
	{
		ShowHover(value: false);
	}

	private void ShowHover(bool value)
	{
		_hover.DOKill();
		_hover.DOFade(value ? 1f : 0f, 0.2f);
	}
}
