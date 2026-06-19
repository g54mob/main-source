using System.Collections;
using Aggro.Core;
using Aggro.Core.Networking;
using FMODUnity;
using Mirror;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameMenuUI : AggroManagerBase<GameMenuUI>, IInputController
{
	public Button inviteFriendsButton;

	public Transform container;

	public SettingsUI settings;

	public GameObject optionButton;

	public Button giveUpButton;

	public GameObject[] disableOnClose;

	private GameObject _prevSelectedGameObject;

	public Animator anim;

	private bool _animating;

	private Coroutine _disableCoroutine;

	public EventReference openSfx;

	public EventReference closeSfx;

	private const float PAUSE_SPEED = 10f;

	protected override void OnEntityCreated()
	{
		container.gameObject.SetActive(value: false);
	}

	protected override void OnEntityDestroyed()
	{
		Time.timeScale = 1f;
	}

	public void OnInviteFriends()
	{
		Aggro.Core.Platform.OpenInviteList();
	}

	public void GiveUpAndReturn()
	{
		if (NetworkServer.active)
		{
			Time.timeScale = 1f;
			AggroInputManager.RemoveController(this);
			GameManager.Next(GameNextType.ServerLobby);
		}
	}

	public void OnQuitToTitle()
	{
		Time.timeScale = 1f;
		AggroInputManager.RemoveController(this);
		GameManager.Next(GameNextType.QuitTitle);
	}

	public void OpenOptions()
	{
		_prevSelectedGameObject = optionButton;
		settings.OpenSettings();
	}

	public void Close()
	{
		if (AggroInputManager.IsControllerInStack(this))
		{
			settings.CloseSettings();
			if (_disableCoroutine != null)
			{
				StopCoroutine(_disableCoroutine);
				_animating = false;
			}
			_disableCoroutine = StartCoroutine(DisableContainerRoutine());
			GameObject[] array = disableOnClose;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].SetActive(value: false);
			}
			AggroInputManager.RemoveController(this);
			Time.timeScale = 1f;
		}
	}

	public void OnInputControlGained()
	{
		AggroInputManager.EnableUIModule();
		container.gameObject.SetActive(value: true);
		AudioManager.PlaySfx(openSfx);
		if (_disableCoroutine != null)
		{
			_animating = false;
			StopCoroutine(_disableCoroutine);
		}
		AggroInputManager.input.GameMenu.Enable();
		if (AggroInputManager.mode == InputMode.Gamepad)
		{
			if (_prevSelectedGameObject != null)
			{
				EventSystem.current.SetSelectedGameObject(_prevSelectedGameObject);
				_prevSelectedGameObject = null;
			}
			else
			{
				EventSystem.current.SetSelectedGameObject(inviteFriendsButton.gameObject);
			}
		}
	}

	public void OnInputControlLost()
	{
		AudioManager.PlaySfx(closeSfx);
		AggroInputManager.input.OptionsMenu.Disable();
		AggroInputManager.input.GameMenu.Disable();
	}

	protected override void OnUpdatePresentation()
	{
		bool interactable = GameUtil.isLobby && !AggroNetworkManager.isSinglePlayer && Aggro.Core.Platform.IsOnline() && Aggro.Core.Platform.HasPlatformInvite() && NetworkAggroManagerBase<PlayersManager>.instance.playerCount < 4;
		inviteFriendsButton.interactable = interactable;
		bool interactable2 = NetworkServer.active && GameUtil.isRun && !GameUtil.isTutorial;
		giveUpButton.interactable = interactable2;
		if (AggroInputManager.HasControl(this))
		{
			if (GameUtil.isRun && AggroNetworkManager.isSinglePlayer)
			{
				Time.timeScale = math.max(Time.timeScale - Time.unscaledDeltaTime * 10f, 0f);
			}
			if (AggroInputManager.input.GameMenu.BackOut.WasPressedThisFrame() && !_animating)
			{
				if (_disableCoroutine != null)
				{
					StopCoroutine(_disableCoroutine);
					_animating = false;
				}
				_disableCoroutine = StartCoroutine(DisableContainerRoutine());
				GameObject[] array = disableOnClose;
				for (int i = 0; i < array.Length; i++)
				{
					array[i].SetActive(value: false);
				}
				AggroInputManager.RemoveController(this);
				Time.timeScale = 1f;
			}
		}
		else if (!AggroInputManager.IsControllerInStack(this) && !_animating && (AggroInputManager.input.Game.OpenGameMenu.WasPressedThisFrame() || AggroInputManager.input.Lobby.OpenGameMenu.WasPressedThisFrame() || AggroInputManager.input.ChoiceMenu.OpenGameMenu.WasPressedThisFrame()))
		{
			_prevSelectedGameObject = null;
			AggroInputManager.PushController(this);
		}
	}

	private IEnumerator DisableContainerRoutine()
	{
		_animating = true;
		anim.SetTrigger("Out");
		yield return new WaitForSeconds(0.5f);
		container.gameObject.SetActive(value: false);
		_animating = false;
	}
}
