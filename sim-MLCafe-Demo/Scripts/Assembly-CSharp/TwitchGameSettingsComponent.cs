using System.Linq;
using Game;
using Game.Twitch;
using Lexone.UnityTwitchChat;
using TMPro;
using UnityEngine;

public class TwitchGameSettingsComponent : SettingsComponent
{
	[SerializeField]
	private TwitchSettingsContainer loadedSettings;

	[Header("Direct Refs")]
	[SerializeField]
	private TMP_InputField inputFieldChannelName;

	[SerializeField]
	private ToggleSwitch toggleQueuelineLimitation;

	[SerializeField]
	private GameObject buttonConnect;

	[SerializeField]
	private GameObject buttonDisconnect;

	[SerializeField]
	private TMP_Text labelAlertMsg;

	[SerializeField]
	private GameObject availableRuntimeContent;

	[SerializeField]
	private GameObject lockedRuntimeContent;

	[SerializeField]
	private TwitchSettingsSlot[] twitchSettingSlots;

	private Color alertColor;

	private void Start()
	{
		buttonDisconnect.SetActive(value: false);
		labelAlertMsg.gameObject.SetActive(value: false);
		alertColor = labelAlertMsg.color;
		IRC.Instance.OnConnectionAlert += delegate(IRCReply IRCReply)
		{
			if (!(labelAlertMsg == null))
			{
				labelAlertMsg.gameObject.SetActive(value: true);
				labelAlertMsg.text = IRCReply.ToString();
				labelAlertMsg.color = ((IRCReply == IRCReply.JOINED_CHANNEL) ? Color.green : alertColor);
			}
		};
		IRC.Instance.OnConnected.AddListener(delegate
		{
			if (!(labelAlertMsg == null) && !(buttonConnect == null) && !(buttonDisconnect == null))
			{
				buttonConnect.SetActive(value: false);
				buttonDisconnect.SetActive(value: true);
				labelAlertMsg.gameObject.SetActive(value: false);
			}
		});
		IRC.Instance.OnDisconnect.AddListener(delegate
		{
			if (!(labelAlertMsg == null) && !(buttonConnect == null) && !(buttonDisconnect == null))
			{
				buttonConnect.SetActive(value: true);
				buttonDisconnect.SetActive(value: false);
				labelAlertMsg.gameObject.SetActive(value: false);
			}
		});
		if (GameStateManager.GetCurrentGameState() == GameStateManager.GameState.TitleScreen)
		{
			availableRuntimeContent.SetActive(value: false);
			lockedRuntimeContent.SetActive(value: true);
		}
		else
		{
			availableRuntimeContent.SetActive(value: true);
			lockedRuntimeContent.SetActive(value: false);
		}
	}

	private void OnDestroy()
	{
		if (!(IRC.Instance == null))
		{
			IRC.Instance.OnConnectionAlert -= delegate(IRCReply IRCReply)
			{
				labelAlertMsg.gameObject.SetActive(value: true);
				labelAlertMsg.text = IRCReply.ToString();
				labelAlertMsg.color = ((IRCReply == IRCReply.JOINED_CHANNEL) ? Color.green : alertColor);
			};
			IRC.Instance.OnConnected.RemoveListener(delegate
			{
				buttonConnect.SetActive(value: false);
				buttonDisconnect.SetActive(value: true);
				labelAlertMsg.gameObject.SetActive(value: false);
			});
			IRC.Instance.OnDisconnect.RemoveListener(delegate
			{
				buttonConnect.SetActive(value: true);
				buttonDisconnect.SetActive(value: false);
				labelAlertMsg.gameObject.SetActive(value: false);
			});
		}
	}

	public override void OnConfigLoad(GameSettingsConfig config)
	{
		loadedSettings = config.twitchSettings;
		base.OnConfigLoad(config);
		LoadProperties();
	}

	public override void OnConfigUpdate(GameSettingsConfig config)
	{
		loadedSettings = config.twitchSettings;
		UpdateProperties();
	}

	private void LoadProperties()
	{
		twitchSettingSlots = (from x in twitchSettingSlots.ToList()
			where x != null
			select x).ToArray();
		if (twitchSettingSlots.Length != 0)
		{
			OnLoadQueuelineLimitationToggle(toggleQueuelineLimitation);
			for (int num = 0; num < twitchSettingSlots.Length; num++)
			{
				twitchSettingSlots[num].InitSlot(num, this);
				OnLoadCommandActiveState(num, twitchSettingSlots[num].toggleActiveState);
				OnLoadCommandCooldown(num, twitchSettingSlots[num].sliderCooldown);
			}
			UpdateProperties();
		}
	}

	private void UpdateProperties()
	{
		inputFieldChannelName.text = loadedSettings.channel;
		twitchSettingSlots = (from x in twitchSettingSlots.ToList()
			where x != null
			select x).ToArray();
		for (int num = 0; num < twitchSettingSlots.Length; num++)
		{
			twitchSettingSlots[num].toggleActiveState.SetValueWithoutNotify(loadedSettings.commands[num].active);
			twitchSettingSlots[num].sliderCooldown.SetValueWithoutNotify(loadedSettings.commands[num].cooldown);
		}
	}

	public void OnConnectTwitchChannel()
	{
		labelAlertMsg.gameObject.SetActive(value: false);
		IRC.Instance.channel = inputFieldChannelName.text;
		IRC.Instance.Connect();
	}

	public void OnDisconnectTwitchChannel()
	{
		IRC.Instance.Disconnect();
	}

	public void OnLoadChannelName(TMP_InputField inputfield)
	{
		inputfield.text = loadedSettings.channel;
		TwitchSettings.SetChannelName(loadedSettings.channel);
		GameSettings.SetTwitchSettings(loadedSettings);
	}

	public void OnLoadQueuelineLimitationToggle(ToggleSwitch toggle)
	{
		toggle.Init(loadedSettings.queuelineLimitation);
		TwitchSettings.SetQueueLimitation(loadedSettings.queuelineLimitation);
		GameSettings.SetTwitchSettings(loadedSettings);
	}

	public void OnLoadCommandActiveState(int cmdIndex, ToggleSwitch toggle)
	{
		toggle.Init(loadedSettings.commands[cmdIndex].active);
		TwitchSettings.SetCommandActiveState(cmdIndex, loadedSettings.commands[cmdIndex].active);
		GameSettings.SetTwitchSettings(loadedSettings);
	}

	public void OnLoadCommandCooldown(int cmdIndex, SliderField slider)
	{
		slider.Init(loadedSettings.commands[cmdIndex].cooldown);
		TwitchSettings.SetCommandCooldown(cmdIndex, loadedSettings.commands[cmdIndex].cooldown);
		GameSettings.SetTwitchSettings(loadedSettings);
	}

	public void OnUpdateChannelName(string channelName)
	{
		loadedSettings.channel = channelName;
		GameSettings.UpdateTwitchSettings(loadedSettings);
		TwitchSettings.SetChannelName(channelName);
	}

	public void OnUpdateQueueLimitationToggle(bool value)
	{
		loadedSettings.queuelineLimitation = value;
		GameSettings.UpdateTwitchSettings(loadedSettings);
		TwitchSettings.SetQueueLimitation(value);
	}

	public void OnUpdateCommandActiveState(int cmdIndex, bool value)
	{
		loadedSettings.commands[cmdIndex].active = value;
		GameSettings.UpdateTwitchSettings(loadedSettings);
		TwitchSettings.SetCommandActiveState(cmdIndex, loadedSettings.commands[cmdIndex].active);
	}

	public void OnUpdateCommandCooldown(int cmdIndex, float value)
	{
		loadedSettings.commands[cmdIndex].cooldown = value;
		GameSettings.UpdateTwitchSettings(loadedSettings);
		TwitchSettings.SetCommandCooldown(cmdIndex, loadedSettings.commands[cmdIndex].cooldown);
	}
}
