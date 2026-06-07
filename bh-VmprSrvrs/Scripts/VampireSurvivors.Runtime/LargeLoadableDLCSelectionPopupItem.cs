using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VampireSurvivors.UI;

public class LargeLoadableDLCSelectionPopupItem : SelectableUI
{
	[SerializeField]
	private TickBoxUI _Checkbox;

	[SerializeField]
	private TextMeshProUGUI _TitleText;

	[SerializeField]
	private TextMeshProUGUI _Description;

	private DLCOptionDataSet _dlcOptionDataSet;

	public Selectable Selectable => null;

	public void Setup(DLCOptionDataSet dlcOptionDataSet)
	{
	}

	public void ToggleSelected()
	{
	}
}
