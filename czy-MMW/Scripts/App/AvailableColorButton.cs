using Motorways.Themes;
using Motorways.UI;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class AvailableColorButton : MonoBehaviour
{
	[SerializeField]
	private Image _availableColorImage;

	[FormerlySerializedAs("_isChosenIndicator")]
	[SerializeField]
	private Image _chosenIndicator;

	[SerializeField]
	private Image _selectedIndicator;

	[FormerlySerializedAs("_touchToggle")]
	public TouchToggle TouchToggle;

	private ColorGroup _colorGroup;

	private int _index;

	public int Index => _index;

	public bool IsSelected
	{
		get
		{
			return _selectedIndicator.gameObject.activeSelf;
		}
		set
		{
			_selectedIndicator.gameObject.SetActive(value);
		}
	}

	public bool IsChosen
	{
		get
		{
			return _chosenIndicator.gameObject.activeSelf;
		}
		set
		{
			_chosenIndicator.gameObject.SetActive(value);
		}
	}

	public ColorGroup ColorGroup => _colorGroup;

	public void Initialise(ColorGroup colorGroup)
	{
		_colorGroup = colorGroup;
		_availableColorImage.color = _colorGroup.GetColor(ThemeComponentGroupTarget.BuildingBase);
		_index = base.transform.GetSiblingIndex();
	}
}
