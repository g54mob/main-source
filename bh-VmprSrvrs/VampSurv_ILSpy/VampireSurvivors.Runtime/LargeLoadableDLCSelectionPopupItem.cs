using Cpp2ILInjected;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VampireSurvivors.UI;

public class LargeLoadableDLCSelectionPopupItem : SelectableUI
{
	private TickBoxUI _Checkbox;

	private TextMeshProUGUI _TitleText;

	private TextMeshProUGUI _Description;

	private DLCOptionDataSet _dlcOptionDataSet;

	public Selectable Selectable => _selectable;

	public void Setup(DLCOptionDataSet dlcOptionDataSet)
	{
		_dlcOptionDataSet = dlcOptionDataSet;
		DLCOptionDataSet dlcOptionDataSet2 = _dlcOptionDataSet;
		_TitleText.text = dlcOptionDataSet2.Title;
		DLCOptionDataSet dlcOptionDataSet3 = _dlcOptionDataSet;
		_Description.text = dlcOptionDataSet3.Info;
		DLCOptionDataSet dlcOptionDataSet4 = _dlcOptionDataSet;
		_Checkbox.InitialSet(dlcOptionDataSet4.Selected);
	}

	public void ToggleSelected()
	{
		DLCOptionDataSet dlcOptionDataSet = _dlcOptionDataSet;
		bool selected = !dlcOptionDataSet.Selected;
		dlcOptionDataSet.Selected = selected;
		DLCOptionDataSet dlcOptionDataSet2 = _dlcOptionDataSet;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18998A2F7]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		bool flag = !dlcOptionDataSet2.Selected;
		string text = "False";
		if (!flag)
		{
			text = "True";
		}
		string message = "ToggleSelected to " + text;
		Debug.Log(message);
		DLCOptionDataSet dlcOptionDataSet3 = _dlcOptionDataSet;
		if (!dlcOptionDataSet3.Selected)
		{
			_Checkbox.SetOff();
		}
		else
		{
			_Checkbox.SetOn();
		}
	}

	public LargeLoadableDLCSelectionPopupItem()
	{
		//IL_0036: Expected I, but got O
		base._ShowSelector = true;
		base._ShouldUpdatePositionWhenForcingDumbFix = true;
		ReselectIfDefaultSelectedOnPage = true;
		nint num = (nint)typeof(Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
