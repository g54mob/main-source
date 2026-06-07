using System;
using SINetworking;
using UnityEngine;
using UnityEngine.UI;

public class ChatChannelButton : MonoBehaviour
{
	public RawImage Avatar;

	public Image Self;

	public Image Border;

	public Button Button;

	public Text Label;

	public Text Time;

	public Text PingLabel;

	public Color ActiveColor;

	private bool _active;

	private bool _pinged;

	[NonSerialized]
	public NetworkPlayer Player;

	public GameObject UnreadBadge;

	public Text UnreadText;

	private int _unreadCount;

	[NonSerialized]
	private bool _avatarInit;

	public void SetUnread(int amount)
	{
		_unreadCount = amount;
		if (_unreadCount > 0)
		{
			UnreadText.text = _unreadCount.ToString();
			UnreadBadge.SetActive(true);
		}
		else
		{
			UnreadBadge.SetActive(false);
		}
	}

	public void SetUnread(bool reset)
	{
		SetUnread((!reset) ? (_unreadCount + 1) : 0);
	}

	public void Init(NetworkPlayer player)
	{
		Player = player;
		if (player == null)
		{
			Label.text = "PublicChannel".Loc();
			Time.gameObject.SetActive(false);
			Avatar.gameObject.SetActive(false);
			Self.color = Color.white;
		}
		else
		{
			Label.text = player.Name;
			UpdateAvatar();
		}
	}

	public void Ping()
	{
		if (!_active)
		{
			_pinged = true;
		}
	}

	public void SetActive(bool active)
	{
		_active = active;
		if (active)
		{
			_pinged = false;
		}
	}

	private void UpdateAvatar()
	{
		Texture2D tex;
		if (!_avatarInit && Player != null && Player.TryGetAvatar(out tex))
		{
			_avatarInit = true;
			if (tex != null)
			{
				Avatar.gameObject.SetActive(true);
				Avatar.texture = tex;
			}
			else
			{
				Avatar.gameObject.SetActive(false);
			}
		}
	}

	public void Update()
	{
		PingLabel.text = ((Player != null && Player.Ping.HasValue) ? (Player.Ping.Value / 1000f).SecondsToTime(false) : "");
		UpdateAvatar();
		Border.color = (_active ? ActiveColor : Color.white);
		if (_pinged)
		{
			Border.color = Utilities.Blink(Self.color, Color.red, 1f);
		}
		if (Player != null)
		{
			Time.text = Player.GetGameStatus(true);
			Color themeColor = HUD.GetThemeColor(Player.ID - 1);
			if (Self.color != themeColor)
			{
				Self.color = themeColor;
			}
		}
	}
}
