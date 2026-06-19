using System.Collections.Generic;
using Aggro.Core;
using Aggro.Core.Networking;
using FMODUnity;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ModifierChoiceManagerUI : AggroManagerBase<ModifierChoiceManagerUI>, IInputController
{
	public Image[] undecidedPlayers;

	public Transform container;

	public ModifierChoiceButtonUI choiceButtonA;

	public ModifierChoiceButtonUI choiceButtonB;

	public EaseUI easeUI;

	public StudioEventEmitter voteProgressSfx;

	public EventReference voteSfx;

	public StudioEventEmitter modifierChoiceSnapshot;

	private static List<PlayersManager.PlayerVote> _playerVotes = new List<PlayersManager.PlayerVote>();

	protected override void OnEntityCreated()
	{
	}

	public void SetUpModifiers(ModifierBase modifierA, ModifierBase modifierB)
	{
		if (modifierA.modifierIcon != null)
		{
			choiceButtonA.iconA.sprite = modifierA.modifierIcon;
			choiceButtonA.iconA.gameObject.SetActive(value: true);
		}
		else
		{
			choiceButtonA.iconA.gameObject.SetActive(value: false);
		}
		choiceButtonA.titleText.SetIndex(modifierA.modifierName);
		choiceButtonA.descText.SetIndex(modifierA.modifierDescription);
		choiceButtonA.bonusPayText.text = "+$" + modifierA.hazardPay;
		choiceButtonB.bonusPayText.text = "+$" + modifierB.hazardPay;
		if (modifierB.modifierIcon != null)
		{
			choiceButtonB.iconA.sprite = modifierB.modifierIcon;
			choiceButtonB.iconA.gameObject.SetActive(value: true);
		}
		else
		{
			choiceButtonB.iconA.gameObject.SetActive(value: false);
		}
		choiceButtonB.titleText.SetIndex(modifierB.modifierName);
		choiceButtonB.descText.SetIndex(modifierB.modifierDescription);
		easeUI.EaseIn();
		AggroInputManager.PushController(this);
	}

	public void EndVote()
	{
		easeUI.EaseOut();
		AggroInputManager.RemoveController(this);
	}

	protected override void OnUpdatePresentation()
	{
		if (AggroInputManager.input.ChoiceMenu.ChooseLeft.WasPressedThisFrame())
		{
			AudioManager.PlaySfx(voteSfx);
			NetworkAggroManagerBase<PlayersManager>.instance.RequestVote(choiceButtonA.voteOption);
		}
		if (AggroInputManager.input.ChoiceMenu.ChooseRight.WasPressedThisFrame())
		{
			AudioManager.PlaySfx(voteSfx);
			NetworkAggroManagerBase<PlayersManager>.instance.RequestVote(choiceButtonB.voteOption);
		}
		RefreshVotes();
		voteProgressSfx.SetParameter("confirm-hold-BR", NetworkAggroManagerBase<PlayersManager>.instance.GetNormalizedVoteValue());
	}

	public void RefreshVotes()
	{
		Image[] players = choiceButtonA.players;
		for (int i = 0; i < players.Length; i++)
		{
			players[i].gameObject.SetActive(value: false);
		}
		players = choiceButtonB.players;
		for (int i = 0; i < players.Length; i++)
		{
			players[i].gameObject.SetActive(value: false);
		}
		players = undecidedPlayers;
		for (int i = 0; i < players.Length; i++)
		{
			players[i].gameObject.SetActive(value: false);
		}
		_playerVotes.Clear();
		NetworkAggroManagerBase<PlayersManager>.instance.GetAllPlayerVotes(_playerVotes);
		for (int j = 0; j < _playerVotes.Count; j++)
		{
			bool active = _playerVotes[j].vote == PlayersManager.VoteOption.A;
			bool active2 = _playerVotes[j].vote == PlayersManager.VoteOption.B;
			bool active3 = _playerVotes[j].vote == PlayersManager.VoteOption.None;
			Color playerColor = _playerVotes[j].player.GetObject<PlayerColorManager>().GetPlayerColor(ui: true);
			choiceButtonA.players[j].color = playerColor;
			choiceButtonB.players[j].color = playerColor;
			undecidedPlayers[j].color = playerColor;
			choiceButtonA.players[j].gameObject.SetActive(active);
			choiceButtonB.players[j].gameObject.SetActive(active2);
			undecidedPlayers[j].gameObject.SetActive(active3);
		}
	}

	public void OnInputControlGained()
	{
		if (AggroInputManager.mode == InputMode.KBM)
		{
			AggroInputManager.EnableUIModule();
		}
		if (AggroInputManager.mode == InputMode.Gamepad)
		{
			EventSystem.current.SetSelectedGameObject(null);
		}
		AggroInputManager.input.ChoiceMenu.Enable();
		modifierChoiceSnapshot.Play();
		voteProgressSfx.Play();
	}

	public void OnInputControlLost()
	{
		AggroInputManager.DisableUIModule();
		AggroInputManager.input.ChoiceMenu.Disable();
		modifierChoiceSnapshot.Stop();
		voteProgressSfx.Stop();
	}
}
