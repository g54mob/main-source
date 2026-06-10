using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ComputerOSMultiSelectElement : ComputerOSUIComponent
{
	public ComputerOSMultiSelect multiSelect;

	public RectTransform rect;

	public TextMeshProUGUI elementText;

	public TextMeshProUGUI elementText2;

	public ComputerOSMultiSelect.OSMultiOption option;

	public Image backgroundImage;

	public Image iconImage;

	public Color backgroundColourNormal;

	public Color backgroundColourSelected;

	public bool selected;

	public void Setup(ComputerOSMultiSelect.OSMultiOption newOpt, ComputerOSMultiSelect newMulti)
	{
	}

	public override void OnLeftClick()
	{
	}
}
