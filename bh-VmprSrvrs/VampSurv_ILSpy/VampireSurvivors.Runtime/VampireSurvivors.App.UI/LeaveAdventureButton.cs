using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using VampireSurvivors.App.Scripts.Framework.Adventures;

namespace VampireSurvivors.App.UI;

public class LeaveAdventureButton : MonoBehaviour
{
	private Button _button;

	private AdventureManager _adventureManager;

	private void Construct(AdventureManager adventureManager)
	{
		_adventureManager = adventureManager;
	}

	private void Awake()
	{
		Button component = GetComponent<Button>();
		_button = component;
		Button button = _button;
		UnityAction call = LeaveAdventure;
		button.m_OnClick.AddListener(call);
	}

	private void LeaveAdventure()
	{
		if (AdventureManager._003CIsInAdventureMode_003Ek__BackingField)
		{
			_adventureManager.ExitAdventureMode();
		}
	}

	public LeaveAdventureButton()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
