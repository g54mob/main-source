using System;
using Heathen.SteamworksIntegration;
using Steamworks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerListItemUI : MonoBehaviour
{
	[Header("UI References")]
	[Tooltip("Oyuncu adı text'i")]
	public TextMeshProUGUI playerNameText;

	[Tooltip("Oyuncu avatar'ı (opsiyonel)")]
	public RawImage playerAvatar;

	[Tooltip("Kick butonu - Sadece host'ta ve kendisi hariç gösterilir")]
	public Button kickButton;

	public CanvasGroup kickCanvas;

	[Header("State")]
	[SerializeField]
	private GamePlayer gamePlayer;

	[SerializeField]
	private bool canKick;

	private Action<GamePlayer> onKickClicked;

	public GamePlayer Player => gamePlayer;

	public void Initialize(GamePlayer player, bool showKickButton, Action<GamePlayer> kickCallback)
	{
		this.gamePlayer = player;
		canKick = showKickButton;
		onKickClicked = kickCallback;
		if (playerNameText != null)
		{
			playerNameText.text = player.playerName;
		}
		if (playerAvatar != null && player.playerSteamId != 0L)
		{
			LoadAvatar(player.playerSteamId);
		}
		T_Bag t_Bag = ((GameManager.Instance != null) ? GameManager.Instance.localBag : null);
		GamePlayer gamePlayer = ((t_Bag != null) ? t_Bag.gamePlayer : null);
		if ((this.gamePlayer.ownerConnectionId == 0 || gamePlayer == null || !gamePlayer.isServer) && kickButton != null)
		{
			kickButton.onClick.RemoveAllListeners();
			kickCanvas.alpha = 0f;
		}
		else if (kickButton != null)
		{
			kickCanvas.alpha = 1f;
			kickButton.onClick.RemoveAllListeners();
			kickButton.onClick.AddListener(OnKickButtonClicked);
		}
		else
		{
			kickCanvas.alpha = 0f;
		}
	}

	private void LoadAvatar(ulong steamId)
	{
		if (playerAvatar == null)
		{
			return;
		}
		((UserData)new CSteamID(steamId)).LoadAvatar(delegate(Texture2D texture)
		{
			if (texture != null && playerAvatar != null)
			{
				playerAvatar.texture = texture;
			}
		});
	}

	private void OnKickButtonClicked()
	{
		Debug.Log("[PlayerListItemUI] Kick butonuna tıklandı canKick : canKick");
		if (canKick && !(gamePlayer == null))
		{
			Debug.Log("[PlayerListItemUI] Kick butonuna tıklandı: " + gamePlayer.playerName);
			onKickClicked?.Invoke(gamePlayer);
		}
	}

	private void OnDestroy()
	{
		if (kickButton != null)
		{
			kickButton.onClick.RemoveAllListeners();
		}
	}
}
