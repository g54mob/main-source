using NSEipix.Base;
using NSMedieval.Controllers;
using TMPro;
using TwitchIntegration;
using UnityEngine;
using UnityEngine.UI;

namespace NSMedieval.UI
{
	public class TwitchOptionsView : OptionsView
	{
		[SerializeField]
		private SafeTMP_InputField channelNameInputField;

		[SerializeField]
		private ButtonLayoutItemView twitchAuthButton;

		[SerializeField]
		private ButtonLayoutItemView twitchUnauthButton;

		[SerializeField]
		private TMP_Text twitchAuthStatusText;

		[SerializeField]
		private Toggle nameCommandToggle;

		[SerializeField]
		private Toggle appearCommandToggle;

		[SerializeField]
		private Toggle giftCommandToggle;

		[SerializeField]
		private EditableInputGroupLayoutItemView giftCommandCooldown;

		[SerializeField]
		private Toggle strikeCommandToggle;

		[SerializeField]
		private EditableInputGroupLayoutItemView strikeCommandCooldown;

		[SerializeField]
		private Toggle raidCommandToggle;

		[SerializeField]
		private EditableInputGroupLayoutItemView raidCommandMinViewers;

		[SerializeField]
		private Toggle settlersCommandToggle;

		[SerializeField]
		private TMP_Dropdown settlersDropdown;

		[SerializeField]
		private EditableInputGroupLayoutItemView settlersCommandCooldown;

		[SerializeField]
		private ButtonLayoutItemView twitchDropsButton;

		[SerializeField]
		private GameObject nameBlock;

		[SerializeField]
		private GameObject appearBlock;

		[SerializeField]
		private GameObject giftBlock;

		[SerializeField]
		private GameObject strikeBlock;

		[SerializeField]
		private GameObject raidsBlock;

		[SerializeField]
		private GameObject newPeopleBlock;

		[SerializeField]
		private GameObject dropsBlock;

		private void Start()
		{
			channelNameInputField.text = PlayerPrefs.GetString("TwitchAuth__ChannelName");
			channelNameInputField.onValueChanged.AddListener(UpdateAuthVisuals);
			UpdateAuthVisuals();
			twitchAuthButton.Button.onClick.AddListener(OnAuthButtonClicked);
			twitchUnauthButton.Button.onClick.AddListener(OnUnauthButtonClicked);
			twitchAuthButton.gameObject.SetActive(!TwitchManager.IsAuthenticated);
			twitchUnauthButton.gameObject.SetActive(TwitchManager.IsAuthenticated);
			string text = MonoSingleton<LocalizationController>.Instance.GetText(TwitchManager.IsAuthenticated ? "twitch_auth_success" : "twitch_auth_required");
			twitchAuthStatusText.SetText(text);
			nameCommandToggle.SetIsOnWithoutNotify(base.GlobalSettings.TwitchNameCommandEnabled);
			nameCommandToggle.onValueChanged.AddListener(OnNameCommandToggle);
			appearCommandToggle.SetIsOnWithoutNotify(base.GlobalSettings.TwitchAppearCommandEnabled);
			appearCommandToggle.onValueChanged.AddListener(OnAppearCommandToggle);
			giftCommandToggle.SetIsOnWithoutNotify(base.GlobalSettings.TwitchGiftCommandEnabled);
			giftCommandToggle.onValueChanged.AddListener(OnGiftCommandToggle);
			giftCommandCooldown.SetData(base.GlobalSettings.TwitchGiftCommandCooldown.ToString(), SetGiftCooldown, ModifyGiftCooldown);
			strikeCommandToggle.SetIsOnWithoutNotify(base.GlobalSettings.TwitchStrikeCommandEnabled);
			strikeCommandToggle.onValueChanged.AddListener(OnStrikeCommandToggle);
			strikeCommandCooldown.SetData(base.GlobalSettings.TwitchStrikeCommandCooldown.ToString(), SetStrikeCooldown, ModifyStrikeCooldown);
			raidCommandToggle.SetIsOnWithoutNotify(base.GlobalSettings.TwitchRaidCommandEnabled);
			raidCommandToggle.onValueChanged.AddListener(OnRaidCommandToggle);
			raidCommandMinViewers.SetData(base.GlobalSettings.TwitchRaidMinViewers.ToString(), SetRaidMinViewers, ModifyRaidMinViewers);
			settlersCommandToggle.SetIsOnWithoutNotify(base.GlobalSettings.TwitchNewSettlerEnabled);
			settlersCommandToggle.onValueChanged.AddListener(OnNewSettlerCommandToggle);
			settlersCommandCooldown.SetData(base.GlobalSettings.TwitchNewSettlersCooldown.ToString(), SetNewSettlerCooldown, ModifyNewSettlerCooldown);
			twitchDropsButton.Button.onClick.AddListener(OnDropsButtonClicked);
		}

		private void OnDestroy()
		{
			twitchAuthButton.Button.onClick.RemoveAllListeners();
			twitchUnauthButton.Button.onClick.RemoveAllListeners();
			nameCommandToggle.onValueChanged.RemoveAllListeners();
			appearCommandToggle.onValueChanged.RemoveAllListeners();
			giftCommandToggle.onValueChanged.RemoveAllListeners();
			strikeCommandToggle.onValueChanged.RemoveAllListeners();
			raidCommandToggle.onValueChanged.RemoveAllListeners();
			settlersCommandToggle.onValueChanged.RemoveAllListeners();
			twitchDropsButton.Button.onClick.RemoveAllListeners();
		}

		private void UpdateAuthVisuals(string text = "")
		{
			nameBlock.SetActive(TwitchManager.IsAuthenticated);
			appearBlock.SetActive(TwitchManager.IsAuthenticated);
			giftBlock.SetActive(TwitchManager.IsAuthenticated);
			strikeBlock.SetActive(TwitchManager.IsAuthenticated);
			dropsBlock.SetActive(TwitchManager.IsAuthenticated);
			raidsBlock.SetActive(value: false);
			newPeopleBlock.SetActive(value: false);
			if (channelNameInputField.text.Length == 0)
			{
				twitchAuthButton.Button.interactable = false;
			}
			else
			{
				twitchAuthButton.Button.interactable = true;
			}
		}

		private void OnAuthButtonClicked()
		{
			if (channelNameInputField.text.Length != 0)
			{
				TwitchManager.Authenticate(channelNameInputField.text, channelNameInputField.text, delegate(bool isAuthenticated)
				{
					string text = MonoSingleton<LocalizationController>.Instance.GetText(isAuthenticated ? "twitch_auth_success" : "twitch_auth_required");
					twitchAuthStatusText.SetText(text);
					twitchAuthButton.gameObject.SetActive(value: false);
					twitchUnauthButton.gameObject.SetActive(value: true);
					UpdateAuthVisuals();
				});
			}
		}

		private void OnUnauthButtonClicked()
		{
			TwitchManager.Deauth();
			string text = MonoSingleton<LocalizationController>.Instance.GetText("twitch_auth_required");
			twitchAuthStatusText.SetText(text);
			twitchAuthButton.gameObject.SetActive(value: true);
			twitchUnauthButton.gameObject.SetActive(value: false);
			UpdateAuthVisuals();
		}

		private void OnNameCommandToggle(bool value)
		{
			base.GlobalSettings.SetTwitchNameCommandEnabled(value);
		}

		private void OnAppearCommandToggle(bool value)
		{
			base.GlobalSettings.SetTwitchAppearCommandEnabled(value);
		}

		private void OnGiftCommandToggle(bool value)
		{
			base.GlobalSettings.SetTwitchGiftCommandEnabled(value);
		}

		private void SetGiftCooldown(int value)
		{
			giftCommandCooldown.InputField.text = value.ToString();
			base.GlobalSettings.SetTwitchGiftCommandCooldown(value);
		}

		private void ModifyGiftCooldown(int value)
		{
			SetGiftCooldown(base.GlobalSettings.TwitchGiftCommandCooldown + value);
		}

		private void OnStrikeCommandToggle(bool value)
		{
			base.GlobalSettings.SetTwitchStrikeCommandEnabled(value);
		}

		private void SetStrikeCooldown(int value)
		{
			strikeCommandCooldown.InputField.text = value.ToString();
			base.GlobalSettings.SetTwitchStrikeCommandCooldown(value);
		}

		private void ModifyStrikeCooldown(int value)
		{
			SetStrikeCooldown(base.GlobalSettings.TwitchStrikeCommandCooldown + value);
		}

		private void OnRaidCommandToggle(bool value)
		{
			base.GlobalSettings.SetTwitchRaidCommandEnabled(value);
		}

		private void SetRaidMinViewers(int value)
		{
			raidCommandMinViewers.InputField.text = value.ToString();
			base.GlobalSettings.SetTwitchRaidMinViewers(value);
		}

		private void ModifyRaidMinViewers(int value)
		{
			SetRaidMinViewers(base.GlobalSettings.TwitchRaidMinViewers + value);
		}

		private void OnNewSettlerCommandToggle(bool value)
		{
			base.GlobalSettings.SetTwitchNewSettlersEnabled(value);
		}

		private void SetNewSettlerCooldown(int value)
		{
			settlersCommandCooldown.InputField.text = value.ToString();
			base.GlobalSettings.SetTwitchNewSettlersCooldown(value);
		}

		private void ModifyNewSettlerCooldown(int value)
		{
			SetNewSettlerCooldown(base.GlobalSettings.TwitchNewSettlersCooldown + value);
		}

		private void OnDropsButtonClicked()
		{
			MonoSingleton<TwitchController>.Instance.CheckDrops();
		}
	}
}
