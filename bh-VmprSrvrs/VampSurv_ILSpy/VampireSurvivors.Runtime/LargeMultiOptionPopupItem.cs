using Cpp2ILInjected;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VampireSurvivors.UI;

public class LargeMultiOptionPopupItem : SelectableUI
{
	public GameObject Tick;

	public Image Image;

	public TextMeshProUGUI Title;

	public TextMeshProUGUI Description;

	public void SetTick(bool b)
	{
		Tick.SetActive(b);
	}

	public LargeMultiOptionPopupItem()
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
