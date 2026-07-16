using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DropdownField : MonoBehaviour
{
	[Header("Dropdown Editor Properties")]
	[SerializeField]
	private TMP_Dropdown dropdownProperty;

	[SerializeField]
	private Image imgDropdownMainbody;

	[SerializeField]
	private Image imgDropdownCollapseBody;

	[SerializeField]
	private Image imgDropdownViewportBody;

	[SerializeField]
	private Image imgDropdownItembody;

	[SerializeField]
	private Image imgDropdownItemCheckmark;

	[SerializeField]
	private VerticalLayoutGroup verticalLayoutGroup;

	[SerializeField]
	private float width = 150f;

	[SerializeField]
	private float dropdownHeight = 40f;

	[SerializeField]
	private float dropdownContentHeight = 150f;

	[SerializeField]
	private float dropdownItemHeight = 20f;

	[Header("Text Property")]
	[SerializeField]
	private bool useLabelDropdown;

	[SerializeField]
	private TMP_Text labelDropdown;

	[SerializeField]
	private TMP_Text labelDropdownValue;

	[SerializeField]
	private TMP_Text labelDropdownOption;

	[SerializeField]
	private bool useLabelDropdownContentFitter = true;

	[SerializeField]
	private float fixedLabelDropdownWidth = 150f;

	[SerializeField]
	private string title;

	[SerializeField]
	private Color colorLabelDropdown = Color.white;

	[SerializeField]
	private Color colorLabelDropdownValue = Color.white;

	[SerializeField]
	private Color colorLabelDropdownOption = Color.white;

	[SerializeField]
	private TMP_FontAsset fontAsset;

	[SerializeField]
	private float fontScale = 16f;

	[SerializeField]
	private TextAlignmentOptions textAlignmentOptions;

	[Header("Scrollbar")]
	[SerializeField]
	private Image imgScrollbar;

	[SerializeField]
	private Image imgScrollbarHandle;

	[SerializeField]
	private Color scollbarColor = Color.white;

	[SerializeField]
	private Color scollbarHandleColor = Color.white;

	[SerializeField]
	private Sprite scollbarHandleIcon;

	[SerializeField]
	private float scollbarHandleScale = 10f;

	[Header("Dropdown Item")]
	[SerializeField]
	private Sprite checkmarkIcon;

	[SerializeField]
	private Color checkmarkColor = Color.white;

	[SerializeField]
	private float checkmarkSize = 10f;

	[Header("Dropdown Section")]
	[SerializeField]
	private Color fillColor = Color.white;

	[SerializeField]
	private Color backGroundColor = Color.gray;

	[SerializeField]
	private Sprite panelSprite;

	[SerializeField]
	private float pixelsPerUnit = 50f;

	[SerializeField]
	private bool reverseOptions;

	[SerializeField]
	private int startOption;

	[SerializeField]
	private UnityEvent<int> OnDropdownValueChanged = new UnityEvent<int>();

	[SerializeField]
	private bool previewEditor = true;

	private void Awake()
	{
		previewEditor = false;
		verticalLayoutGroup.reverseArrangement = reverseOptions;
	}

	public string GetTitle()
	{
		return title;
	}

	public void Init(int value, List<string> options)
	{
		dropdownProperty.ClearOptions();
		dropdownProperty.AddOptions(options);
		dropdownProperty.SetValueWithoutNotify(value);
	}

	public int GetDropdownOptionsCount()
	{
		return dropdownProperty.options.Count;
	}

	public void OnValueChange(int dropdownValue)
	{
		OnDropdownValueChanged.Invoke(dropdownValue);
	}

	public void SetValueWithoutNotify(int dropdownValue)
	{
		dropdownProperty.SetValueWithoutNotify(dropdownValue);
	}

	private bool IsReversed()
	{
		return reverseOptions;
	}

	private int ReverseValue(int value, bool fromForward = true)
	{
		int num = dropdownProperty.options.Count - 1;
		int num2 = 0;
		if (fromForward)
		{
			return num - value;
		}
		return Mathf.Abs(value - num);
	}
}
