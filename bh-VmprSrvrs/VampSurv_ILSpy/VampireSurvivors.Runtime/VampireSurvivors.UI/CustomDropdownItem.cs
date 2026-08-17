using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace VampireSurvivors.UI;

public class CustomDropdownItem : MonoBehaviour
{
	private CustomDropDown _dropdown;

	public virtual void Initialize(object option, CustomDropDown dropdown)
	{
		_dropdown = dropdown;
		Button component = GetComponent<Button>();
		UnityAction call = Select;
		component.m_OnClick.AddListener(call);
	}

	private void Select()
	{
		_dropdown.SelectItem(this);
		Debug.Log("Selecting!!!");
	}

	public CustomDropdownItem()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
