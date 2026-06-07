using System;
using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LobbyItemUI : MonoBehaviour
{
	[Header("Text Elements")]
	[Tooltip("Lobby adı: {OwnerName}'s Factory")]
	public TextMeshProUGUI lobbyNameText;

	[Tooltip("Oyuncu sayısı: X/4")]
	public TextMeshProUGUI playerCountText;

	[Tooltip("Lobby tipi: Public/Friends Only/Private")]
	public TextMeshProUGUI lobbyTypeText;

	[Header("Icons")]
	[Tooltip("Public lobby ikonu")]
	public GameObject publicIcon;

	[Tooltip("Friends Only lobby ikonu")]
	public GameObject friendsOnlyIcon;

	[Tooltip("Private lobby ikonu")]
	public GameObject privateIcon;

	[Tooltip("Version uyumsuzluğu ikonu")]
	public GameObject versionMismatchIcon;

	[Header("Button")]
	public Button joinButton;

	private LobbyInfo lobbyInfo;

	private Action<LobbyInfo> onClickCallback;

	private bool isFull;

	private bool isPrivate;

	private bool isVersionMismatch;

	private void Start()
	{
		SetupButtonListeners();
	}

	private void SetupButtonListeners()
	{
		if (joinButton != null)
		{
			joinButton.onClick.AddListener(OnJoinClicked);
		}
	}

	public void Setup(LobbyInfo info, Action<LobbyInfo> onClick)
	{
		lobbyInfo = info;
		onClickCallback = onClick;
		UpdateUI();
	}

	private void UpdateUI()
	{
		if (lobbyNameText != null)
		{
			lobbyNameText.text = lobbyInfo.GetDisplayName();
		}
		if (playerCountText != null)
		{
			playerCountText.text = lobbyInfo.GetPlayerCountText();
		}
		isVersionMismatch = lobbyInfo.version != Application.version;
		if (lobbyTypeText != null)
		{
			if (isVersionMismatch)
			{
				lobbyTypeText.text = LocalizationManager.GetTranslation("Version_Mismatch");
			}
			else
			{
				lobbyTypeText.text = lobbyInfo.GetLobbyTypeDisplayText();
			}
		}
		UpdateTypeIcons();
		isFull = lobbyInfo.playerCount >= lobbyInfo.maxPlayers;
		isPrivate = lobbyInfo.isPrivate;
	}

	private void UpdateTypeIcons()
	{
		if (publicIcon != null)
		{
			publicIcon.SetActive(value: false);
		}
		if (friendsOnlyIcon != null)
		{
			friendsOnlyIcon.SetActive(value: false);
		}
		if (privateIcon != null)
		{
			privateIcon.SetActive(value: false);
		}
		if (versionMismatchIcon != null)
		{
			versionMismatchIcon.SetActive(value: false);
		}
		if (lobbyInfo.version != Application.version)
		{
			if (versionMismatchIcon != null)
			{
				versionMismatchIcon.SetActive(value: true);
			}
		}
		else if (lobbyInfo.isPrivate)
		{
			if (privateIcon != null)
			{
				privateIcon.SetActive(value: true);
			}
		}
		else if (publicIcon != null)
		{
			publicIcon.SetActive(value: true);
		}
	}

	private void OnJoinClicked()
	{
		if (isFull)
		{
			Debug.Log("[LobbyItemUI] Lobby dolu, katılınamaz.");
			return;
		}
		if (isPrivate)
		{
			Debug.Log("[LobbyItemUI] Lobby private, server browser'dan katılınamaz.");
			return;
		}
		if (isVersionMismatch)
		{
			Debug.Log("[LobbyItemUI] Version uyumsuzluğu. Lobby: " + lobbyInfo.version + ", Bizim: " + Application.version);
			return;
		}
		Debug.Log("[LobbyItemUI] Lobby'e katılınıyor: " + lobbyInfo.GetDisplayName());
		onClickCallback?.Invoke(lobbyInfo);
	}

	public LobbyInfo GetLobbyInfo()
	{
		return lobbyInfo;
	}

	public bool IsFull()
	{
		return isFull;
	}
}
