using Motorways.Themes;
using Motorways.UI;
using UnityEngine;
using UnityEngine.UI;

public class ChosenColorButton : MonoBehaviour
{
	[SerializeField]
	private Image _chosenColorImage;

	[SerializeField]
	private Image _selectedIndicator;

	[SerializeField]
	public TouchToggle _touchToggle;

	private ColorGroup _colorGroup;

	private int _index;

	public int Index => _index;

	public bool IsSelected
	{
		set
		{
			_selectedIndicator.gameObject.SetActive(value);
		}
	}

	public Selectable FocusPoint => _touchToggle;

	public void SwapColorGroupWith(ChosenColorButton otherChosenColorButton)
	{
		ColorGroup colorGroup = _colorGroup;
		SetColorGroup(otherChosenColorButton._colorGroup);
		otherChosenColorButton.SetColorGroup(colorGroup);
	}

	public void Initialise(ColorGroup colorGroup)
	{
		SetColorGroup(colorGroup);
		IsSelected = false;
		_index = base.transform.GetSiblingIndex();
	}

	public void SetColorGroup(ColorGroup colorGroup)
	{
		_colorGroup = colorGroup;
		_chosenColorImage.color = _colorGroup.GetColor(ThemeComponentGroupTarget.BuildingBase);
	}
}
