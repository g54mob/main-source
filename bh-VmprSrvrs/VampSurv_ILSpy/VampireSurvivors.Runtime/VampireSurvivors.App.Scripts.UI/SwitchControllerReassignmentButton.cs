using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using VampireSurvivors.Framework;

namespace VampireSurvivors.App.Scripts.UI;

public class SwitchControllerReassignmentButton : MonoBehaviour
{
	private Button _button;

	private MultiplayerManager _multiplayerManager;

	private void Construct(MultiplayerManager multiplayerManager)
	{
		_multiplayerManager = multiplayerManager;
	}

	private void Awake()
	{
		Button componentInChildren = GetComponentInChildren<Button>();
		_button = componentInChildren;
		Button button = _button;
		UnityAction call = ShowApplet;
		button.m_OnClick.AddListener(call);
	}

	private void ShowApplet()
	{
	}

	public SwitchControllerReassignmentButton()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
