using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class AUIGameSettingItem : Selectable
{
	[SerializeField]
	protected GameSettingData settingData;

	[SerializeField]
	protected new Animator animator;

	[SerializeField]
	private TMP_Text text_Name;

	[SerializeField]
	protected TMP_Text text_ExtraDescription;

	[SerializeField]
	private Image image_SelectedEffect;

	[Header("Debug: 目前數值")]
	[SerializeField]
	protected int curValue;

	private bool isTooltipOn;

	protected bool isSelected;

	public GameSettingData SettingData => null;

	protected override void Awake()
	{
	}

	protected override void OnEnable()
	{
	}

	protected override void OnDisable()
	{
	}

	private void OnLanguageChanged()
	{
	}

	private void GetValueFromSettingData()
	{
	}

	protected virtual void ApplySetting()
	{
	}

	protected virtual void ResetToDefault()
	{
	}

	protected abstract void UpdateDisplay();

	public override void OnPointerEnter(PointerEventData eventData)
	{
	}

	public override void OnPointerExit(PointerEventData eventData)
	{
	}

	public override void OnSelect(BaseEventData eventData)
	{
	}

	public override void OnDeselect(BaseEventData eventData)
	{
	}
}
