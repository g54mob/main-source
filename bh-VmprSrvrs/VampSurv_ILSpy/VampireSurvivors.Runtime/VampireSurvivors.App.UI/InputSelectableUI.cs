using Cpp2ILInjected;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace VampireSurvivors.App.UI;

public class InputSelectableUI : MonoBehaviour, ISubmitHandler, IEventSystemHandler, IDeselectHandler, ISelectHandler
{
	private TMP_InputField _InputField;

	public bool _HasFocus;

	public void OnSubmit(BaseEventData eventData)
	{
		Debug.Log("[CustomInputSelectableUI] OnSubmit");
	}

	public void OnDeselect(BaseEventData eventData)
	{
		Debug.Log("[CustomInputSelectableUI] OnDeselected");
	}

	public void OnSelect(BaseEventData eventData)
	{
		Debug.Log("[CustomInputSelectableUI] OnSelected");
	}

	public InputSelectableUI()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
