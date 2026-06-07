using System;
using System.Collections.Generic;
using SINetworking;
using Steamworks;
using UnityEngine;
using UnityEngine.UI;

public class ChatWindow : MonoBehaviour
{
	public class Message
	{
		public bool Self;

		public string Sender;

		public byte SenderID;

		public string Content;

		public NetworkTrade Trade;

		public DateTime Sent;

		public Message(bool self, string sender, byte senderID, string content, NetworkTrade trade)
		{
			Self = self;
			Sender = sender;
			SenderID = senderID;
			Content = content;
			Trade = trade;
			Sent = DateTime.Now;
		}
	}

	public static ChatWindow Instance;

	private static List<Message> PublicMessages = new List<Message>();

	private static Dictionary<string, List<Message>> PrivateMessages = new Dictionary<string, List<Message>>();

	[NonSerialized]
	private Dictionary<string, ChatChannelButton> _channelButtons = new Dictionary<string, ChatChannelButton>();

	public RectTransform ChannelPanel;

	public ChatChannelButton ChannelButtonPrefab;

	public GameObject CompanyButton;

	public GameObject ProfileButton;

	public GameObject InviteButton;

	public NetworkStatWindow StatWindowPrefab;

	public InputField MessageField;

	public GUIComplexList MessageList;

	public Button SendButton;

	public Button DetailButton;

	public Button KickButton;

	public GUIWindow Window;

	public Text PlayerLabel;

	public Text CompanyLabel;

	public RawImage PlayerAvatar;

	public RawImage CompanyLogo;

	[NonSerialized]
	public MainBottomButton MainButton;

	[NonSerialized]
	private string _currentTarget;

	[NonSerialized]
	private ChatChannelButton _publicButton;

	[NonSerialized]
	public ButtonCounter Counter;

	[NonSerialized]
	private int _msgCount;

	private bool _initialized;

	private static Color GetColor(bool fromSelf)
	{
		return fromSelf ? new Color32(200, 50, 50, byte.MaxValue) : new Color32(50, 50, 200, byte.MaxValue);
	}

	public void ShowDetails()
	{
		if (_currentTarget != null)
		{
			NetworkPlayer player = NetworkManager.GetPlayer(_currentTarget);
			if (player != null)
			{
				NetworkStatWindow networkStatWindow = UnityEngine.Object.Instantiate(StatWindowPrefab);
				networkStatWindow.transform.SetParent(WindowManager.Instance.Canvas.transform, false);
				networkStatWindow.Init(player);
			}
		}
	}

	public static void ForceInit(NetworkPlayer player)
	{
		ChatChannelButton value;
		if (Instance != null && Instance._channelButtons.TryGetValue(player.ActualUniqueID, out value))
		{
			value.Init(player);
		}
	}

	public static void AddMessageToChannel(List<Message> messages, Message message)
	{
		if (messages.Count > 0 && message.Trade == null)
		{
			Message message2 = messages.Last();
			if (message2.Trade == null && message2.SenderID == message.SenderID)
			{
				message2.Content = message2.Content + "\n" + message.Content;
				message2.Sent = DateTime.Now;
			}
			else
			{
				messages.Add(message);
			}
		}
		else
		{
			messages.Add(message);
		}
	}

	public static void ReceiveMessage(NetworkPlayer from, bool fromSelf, bool isPublic, string message, NetworkTrade trade)
	{
		float? sticky = null;
		if (Instance != null && Instance.MessageList.Scroll.value < 1f && Instance.MessageList.Scroll.size < 1f)
		{
			sticky = Instance.MessageList.GetActualScrollValue();
		}
		if (isPublic)
		{
			AddMessageToChannel(PublicMessages, new Message(fromSelf, from.Name, from.ID, message, null));
			if (Instance != null)
			{
				ChatChannelButton publicButton = Instance._publicButton;
				if ((object)publicButton != null)
				{
					publicButton.SetUnread(false);
				}
				if (!fromSelf)
				{
					Instance.Ping(null);
				}
			}
		}
		else
		{
			NetworkPlayer networkPlayer = (fromSelf ? NetworkManager.Self : from);
			List<Message> value;
			if (!PrivateMessages.TryGetValue(from.UniqueID, out value))
			{
				List<Message> list = (PrivateMessages[from.UniqueID] = new List<Message>());
				value = list;
			}
			AddMessageToChannel(value, new Message(fromSelf, networkPlayer.Name, networkPlayer.ID, message, trade));
			if (Instance != null)
			{
				ChatChannelButton value2;
				if (Instance._channelButtons.TryGetValue(from.UniqueID, out value2))
				{
					value2.SetUnread(false);
				}
				if (!fromSelf)
				{
					Instance.Ping(from.UniqueID);
				}
			}
		}
		if (Instance != null && Instance.Window.Shown && !Instance.Window.IsCollapsed && (from.UniqueID == Instance._currentTarget || (Instance._currentTarget == null && isPublic)))
		{
			Instance.LoadMessages(Instance._currentTarget, sticky);
		}
	}

	public void Ping(string id)
	{
		bool flag = Window.Shown && !Window.IsCollapsed;
		if (!flag || _currentTarget != id)
		{
			UISoundFX.PlaySFX("MultiplayerMessage");
			if (!flag)
			{
				_msgCount++;
			}
			ButtonCounter counter = Counter;
			if ((object)counter != null)
			{
				counter.SetNumber(_msgCount);
			}
		}
		SetMainButtonPulse(true, id);
		ChatChannelButton value;
		if (id == null)
		{
			ChatChannelButton publicButton = _publicButton;
			if ((object)publicButton != null)
			{
				publicButton.Ping();
			}
		}
		else if (_channelButtons.TryGetValue(id, out value))
		{
			value.Ping();
		}
	}

	private void Awake()
	{
		Instance = this;
	}

	private void Init()
	{
		if (!_initialized)
		{
			_initialized = true;
			_publicButton = CreateChannelButton(null);
			LoadMessages(null);
		}
	}

	private void Start()
	{
		Init();
	}

	public void InitPings()
	{
		if (PublicMessages.Count > 0)
		{
			Ping(null);
		}
		foreach (KeyValuePair<string, List<Message>> privateMessage in PrivateMessages)
		{
			if (privateMessage.Value.Count > 0)
			{
				Ping(privateMessage.Key);
			}
		}
	}

	private void Update()
	{
		bool flag = NetworkLayer.Active is SteamLayer && NetworkManager.IsConnected && NetworkManager.Instance.Players.Count < 4;
		if (flag != InviteButton.activeSelf)
		{
			InviteButton.SetActive(flag);
		}
		foreach (NetworkPlayer player in NetworkManager.Instance.Players)
		{
			if (!player.Self && player.UniqueID != null)
			{
				ChatChannelButton value;
				if (!_channelButtons.TryGetValue(player.UniqueID, out value))
				{
					ChatChannelButton chatChannelButton = CreateChannelButton(player);
					_channelButtons[player.UniqueID] = chatChannelButton;
					List<Message> value2;
					chatChannelButton.SetUnread(PrivateMessages.TryGetValue(player.UniqueID, out value2) ? value2.Count : 0);
				}
				else if (value.Player != player)
				{
					value.Init(player);
				}
			}
		}
		List<string> list = null;
		foreach (KeyValuePair<string, ChatChannelButton> channelButton in _channelButtons)
		{
			if (!PrivateMessages.ContainsKey(channelButton.Key) && NetworkManager.GetPlayer(channelButton.Key) == null)
			{
				if (list == null)
				{
					list = new List<string>();
				}
				list.Add(channelButton.Key);
			}
		}
		if (list == null)
		{
			return;
		}
		foreach (string item in list)
		{
			UnityEngine.Object.Destroy(_channelButtons[item].gameObject);
			_channelButtons.Remove(item);
		}
	}

	public void TestSend()
	{
		if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
		{
			SendMessage();
		}
	}

	public void Show(bool force)
	{
		Init();
		if (force)
		{
			if (!Window.Shown)
			{
				Window.Show();
				LoadMessages(_currentTarget);
			}
		}
		else if (Window.ToggleReturn())
		{
			LoadMessages(_currentTarget);
		}
		_msgCount = 0;
		Counter.SetNumber(_msgCount);
		SetMainButtonPulse(false);
	}

	public ChatChannelButton CreateChannelButton(NetworkPlayer pl)
	{
		ChatChannelButton chatChannelButton = UnityEngine.Object.Instantiate(ChannelButtonPrefab);
		chatChannelButton.Init(pl);
		chatChannelButton.Button.onClick.AddListener(delegate
		{
			ChatWindow chatWindow = this;
			NetworkPlayer networkPlayer = pl;
			chatWindow.LoadMessages((networkPlayer != null) ? networkPlayer.UniqueID : null);
		});
		chatChannelButton.transform.SetParent(ChannelPanel, false);
		return chatChannelButton;
	}

	public void SendMessage()
	{
		string text = MessageField.text.TrimEnd();
		MessageField.text = "";
		if (!string.IsNullOrWhiteSpace(text))
		{
			if (_currentTarget == null)
			{
				NetworkMessaging.SendPlayerMessage(text, true, 0u, NetworkMessaging.MessageTarget.Everyone, 0);
			}
			else
			{
				NetworkPlayer player = NetworkManager.GetPlayer(_currentTarget);
				if (player != null && player.Connected)
				{
					NetworkMessaging.SendPlayerMessage(text, false, 0u, NetworkMessaging.MessageTarget.Specifically, player.ID);
					ReceiveMessage(player, true, false, text, null);
				}
			}
		}
		MessageField.ActivateInputField();
	}

	public void SetMainButtonPulse(bool pulse, string id = null)
	{
		if (MainButton != null)
		{
			MainButton.Pulse = pulse && !Window.Shown;
		}
	}

	public void OpenProfile()
	{
		NetworkPlayer player = NetworkManager.GetPlayer(_currentTarget);
		ulong result;
		if (player != null && player.ReconnectionData != null && ulong.TryParse(player.ReconnectionData, out result))
		{
			SteamFriends.ActivateGameOverlayToUser("steamid", new CSteamID(result));
		}
	}

	public void OpenCompany()
	{
		NetworkPlayer player = NetworkManager.GetPlayer(_currentTarget);
		Company company = ((player != null) ? player.GetPlayerCompany() : null);
		if (company != null)
		{
			HUD.Instance.companyWindow.ShowCompanyDetails(company);
		}
	}

	public void OnCollapse(bool collapse)
	{
		if (!collapse)
		{
			LoadMessages(_currentTarget);
		}
	}

	public void LoadMessages(string player, float? sticky = null)
	{
		if (!Window.IsCollapsed)
		{
			_msgCount = 0;
			Counter.SetNumber(_msgCount);
		}
		DetailButton.gameObject.SetActive(player != null && Example.NetworkDetails);
		SetMainButtonPulse(false);
		_channelButtons.Values.ForEachEnum(delegate(ChatChannelButton x)
		{
			x.SetActive(false);
		});
		_publicButton.SetActive(false);
		if (player == null)
		{
			PlayerLabel.text = "PublicChannel".Loc();
			CompanyLabel.text = "";
			PlayerAvatar.gameObject.SetActive(false);
			CompanyLogo.uvRect = Rect.zero;
			SendButton.interactable = true;
			_publicButton.SetActive(true);
			_publicButton.SetUnread(true);
			CompanyButton.SetActive(false);
			ProfileButton.SetActive(false);
			KickButton.gameObject.SetActive(false);
		}
		else
		{
			ChatChannelButton value;
			if (!_channelButtons.TryGetValue(player, out value))
			{
				Debug.Log("Trying to load messages from player with no channel button: " + player);
				LoadMessages(null);
				return;
			}
			NetworkPlayer player2 = NetworkManager.GetPlayer(player);
			if (player2 != null)
			{
				KickButton.gameObject.SetActive(NetworkManager.IsHost && player2.Connected);
				PlayerLabel.text = player2.Name;
				ProfileButton.SetActive(NetworkLayer.Active is SteamLayer);
				Texture2D tex;
				if (player2.TryGetAvatar(out tex) && tex != null)
				{
					PlayerAvatar.gameObject.SetActive(true);
					PlayerAvatar.texture = tex;
				}
				else
				{
					PlayerAvatar.gameObject.SetActive(false);
				}
				Company playerCompany = MarketSimulation.Active.GetPlayerCompany(player2.ID);
				if (playerCompany != null)
				{
					CompanyLabel.text = playerCompany.Name;
					CompanyLogo.uvRect = LogoController.Instance.GetLogoRect(playerCompany);
					CompanyButton.SetActive(true);
				}
				else
				{
					CompanyLabel.text = "";
					CompanyLogo.uvRect = Rect.zero;
					CompanyButton.SetActive(false);
				}
			}
			else
			{
				KickButton.gameObject.SetActive(false);
				PlayerLabel.text = "Offline".Loc();
				CompanyLabel.text = "";
				PlayerAvatar.gameObject.SetActive(false);
				CompanyLogo.uvRect = Rect.zero;
				CompanyButton.SetActive(false);
				ProfileButton.SetActive(false);
			}
			SendButton.interactable = player2 != null && player2.Connected;
			value.SetActive(true);
			value.SetUnread(true);
		}
		bool flag = _currentTarget == player;
		_currentTarget = player;
		List<Message> list = ((player == null) ? PublicMessages : PrivateMessages.GetOrNull(player));
		if (list != null)
		{
			MessageList.Init(list);
			if (sticky.HasValue)
			{
				MessageList.ScrollTo(sticky.Value);
			}
			else
			{
				MessageList.Scroll.value = 1f;
			}
		}
		else
		{
			MessageList.Init(Array.Empty<object>());
		}
	}

	public void KickPlayer()
	{
		if (_currentTarget == null)
		{
			return;
		}
		NetworkPlayer pl = NetworkManager.GetPlayer(_currentTarget);
		if (pl != null)
		{
			WindowManager.Instance.ShowMessageBox("KickPlayerConfirm".Loc(pl.Name), true, DialogWindow.DialogType.Question, new KeyValuePair<string, Action>("Yes", delegate
			{
				NetworkManager.Instance.KickPlayer(pl, false);
			}), new KeyValuePair<string, Action>("BanPlayer", delegate
			{
				NetworkManager.Instance.KickPlayer(pl, true);
			}), new KeyValuePair<string, Action>("No", delegate
			{
			}));
		}
	}

	private void OnDestroy()
	{
		if (Instance == this)
		{
			Instance = null;
		}
		ClearAllMessages();
	}

	public static void ClearAllMessages()
	{
		PublicMessages.Clear();
		PrivateMessages.Clear();
	}

	public void InviteToGame()
	{
		if (NetworkManager.Instance.Players.Count >= 4)
		{
			return;
		}
		List<ValueTuple<string, CSteamID>> invitables = SteamLayer.GetInvitables();
		WindowManager.Instance.MultiWindow.Show("NetworkInvite", invitables.Select((ValueTuple<string, CSteamID> x) => x.Item1), delegate(int x)
		{
			if (NetworkLayer.Active.CurrentLobby != null)
			{
				CSteamID item = invitables[x].Item2;
				GameSettings.Instance.SteamInvitedToGame.Add(item.m_SteamID);
				SteamMatchmaking.InviteUserToLobby((CSteamID)NetworkLayer.Active.CurrentLobby.ConnectionObject, item);
			}
		}, false);
	}
}
