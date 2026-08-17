using Cpp2ILInjected;
using Rewired;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using VampireSurvivors.Framework;

namespace VampireSurvivors.UI;

public class AdvancedUIButtonEvents : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler, ISelectHandler, IDeselectHandler
{
	private MultiplayerManager Multiplayer;

	private Rewired.Player Player;

	private bool _Selected;

	private bool _Pressed;

	public UnityEvent OnPressed;

	public UnityEvent OnUnpressed;

	public bool isPressed => _Pressed;

	public void OnPointerDown(PointerEventData eventData)
	{
		Debug.Log("OnButtonDown");
		_Pressed = true;
		OnPressed.Invoke();
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		Debug.Log("OnButtonUp");
		_Pressed = false;
		OnUnpressed.Invoke();
	}

	public void OnSelect(BaseEventData eventData)
	{
		Debug.Log("OnSelect");
		_Selected = true;
	}

	public void OnDeselect(BaseEventData eventData)
	{
		Debug.Log("OnDeselect");
		_Selected = false;
	}

	private void Construct(MultiplayerManager _mult)
	{
		Multiplayer = _mult;
	}

	private void Update()
	{
		if (!_Selected)
		{
			return;
		}
		int playerCount = Multiplayer.GetPlayerCount();
		MultiplayerManager multiplayer;
		if (playerCount > 1)
		{
			multiplayer = Multiplayer;
		}
		else
		{
			bool isOnlineMultiplayer = Multiplayer.IsOnlineMultiplayer;
			multiplayer = Multiplayer;
			if (!isOnlineMultiplayer)
			{
				int playerCount2 = Multiplayer.GetPlayerCount();
				if (playerCount2 != 1)
				{
					ReInput.PlayerHelper players = ReInput.players;
					Rewired.Player systemPlayer = players.SystemPlayer;
					Player = systemPlayer;
				}
				else
				{
					Rewired.Player rewiredPlayerOne = Multiplayer.GetRewiredPlayerOne();
					Player = rewiredPlayerOne;
				}
				goto IL_005f;
			}
		}
		Rewired.Player selectedPlayer = multiplayer.GetSelectedPlayer();
		Player = selectedPlayer;
		goto IL_005f;
		IL_005f:
		if (Player.GetButtonDown(5) && !Player.GetButtonUp(5))
		{
			Debug.Log("OnRewiredButtonDown");
			_Pressed = true;
			OnPressed.Invoke();
		}
		if (Player.GetButtonUp(5) && !Player.GetButtonDown(5))
		{
			Debug.Log("OnRewiredButtonUp");
			_Pressed = false;
			OnUnpressed.Invoke();
		}
	}

	public AdvancedUIButtonEvents()
	{
		//IL_0015: Expected I, but got O
		nint num = (nint)typeof(Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
