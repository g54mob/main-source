using Lexone.UnityTwitchChat;
using R3;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.SmartFormat.PersistentVariables;

[RequireComponent(typeof(Lexone.UnityTwitchChat.IRC))]
public class TwitchIntegration : MonoBehaviour
{
	[SerializeField]
	private LocalizedString localizedUsername;

	[SerializeField]
	private LocalizedString localizedMessage;

	private Lexone.UnityTwitchChat.IRC _irc;

	private bool _isConnected;

	private string _currentChannel;

	private void Awake()
	{
		_irc = GetComponent<Lexone.UnityTwitchChat.IRC>();
		_irc.OnChatMessage += HandleChatMessage;
	}

	private void Start()
	{
		ReactiveSettings.TwitchEnabled.CombineLatest(ReactiveSettings.TwitchChannel, (bool x, string channel) => x && !string.IsNullOrEmpty(channel)).Prepend(ReactiveSettings.TwitchEnabled.Value).DistinctUntilChanged()
			.Subscribe(HandleTwitchSettings)
			.AddTo(this);
	}

	private void HandleTwitchSettings(bool value)
	{
		if (value)
		{
			Connect();
		}
		else
		{
			Disconnect();
		}
	}

	private void Connect()
	{
		if (_isConnected)
		{
			Join(ReactiveSettings.TwitchChannel.Value);
			return;
		}
		_irc.Connect();
		_isConnected = true;
		Join(ReactiveSettings.TwitchChannel.Value);
		UI.Registry.footer.irc.ToggleTab(IRCChannel.Twitch, state: true);
	}

	private void Disconnect()
	{
		UI.Registry.footer.irc.ToggleTab(IRCChannel.Twitch, state: false);
		if (_isConnected)
		{
			Leave();
			_irc.Disconnect();
			_isConnected = false;
		}
	}

	private void Join(string channel)
	{
		if (_isConnected && !(channel == _currentChannel))
		{
			Leave();
			_currentChannel = channel;
			_irc.JoinChannel(_currentChannel);
		}
	}

	private void Leave()
	{
		if (_isConnected && !string.IsNullOrEmpty(_currentChannel))
		{
			_irc.LeaveChannel(_currentChannel);
			Database.Commands.IRC.ClearChannel(IRCChannel.Twitch);
			_currentChannel = null;
		}
	}

	private void HandleChatMessage(Chatter chatter)
	{
		LocalizedString localizedString = localizedUsername.Duplicate();
		localizedString["username"] = new StringVariable
		{
			Value = chatter.login
		};
		LocalizedString localizedString2 = localizedMessage.Duplicate();
		localizedString2["message"] = new StringVariable
		{
			Value = chatter.message
		};
		Database.Commands.IRC.Print(IRCChannel.Twitch, localizedString, localizedString2, chatter.GetNameColor());
	}
}
