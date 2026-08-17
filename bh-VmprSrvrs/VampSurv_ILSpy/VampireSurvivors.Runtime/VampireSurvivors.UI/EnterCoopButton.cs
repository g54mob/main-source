using Cpp2ILInjected;
using I2.Loc;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using VampireSurvivors.Framework;

namespace VampireSurvivors.UI;

public class EnterCoopButton : MonoBehaviour
{
	public Button _button;

	private MultiplayerManager _multiplayerManager;

	private Localize _titleLocalize;

	private GameObject _partymodeIcons;

	private void Construct(MultiplayerManager multiplayerManager)
	{
		_multiplayerManager = multiplayerManager;
	}

	private void Awake()
	{
		Button componentInChildren = GetComponentInChildren<Button>();
		_button = componentInChildren;
		Button button = _button;
		UnityAction call = EnterCoop;
		button.m_OnClick.AddListener(call);
	}

	public void SetPartyActive()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A3157]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		_titleLocalize.Term = "partyLang/{co-op&partymode}";
		if ((object)_partymodeIcons != null)
		{
			_partymodeIcons.SetActive(value: true);
		}
	}

	private void EnterCoop()
	{
		if (_multiplayerManager != null)
		{
			MultiplayerManager multiplayerManager = _multiplayerManager;
			multiplayerManager.AllowPlayerJoining = true;
			MultiplayerManager multiplayerManager2 = _multiplayerManager;
			multiplayerManager2.AllowPlayerRemoval = true;
		}
		GameObject gameObject = _button.gameObject;
		gameObject.SetActive(value: false);
	}

	public void ShowButton()
	{
		if (_multiplayerManager != null)
		{
			MultiplayerManager multiplayerManager = _multiplayerManager;
			multiplayerManager.AllowPlayerJoining = false;
			MultiplayerManager multiplayerManager2 = _multiplayerManager;
			multiplayerManager2.AllowPlayerRemoval = false;
		}
		GameObject gameObject = _button.gameObject;
		gameObject.SetActive(value: true);
	}

	public EnterCoopButton()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
