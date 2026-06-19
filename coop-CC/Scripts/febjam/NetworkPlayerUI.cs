using Aggro.Core;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NetworkPlayerUI : MonoBehaviour
{
	public TextMeshProUGUI playerName;

	public Slider volumeSlider;

	public TextMeshProUGUI ping;

	public Image pingImage;

	public Image buttonIcon;

	[Space]
	public Color goodPingColor;

	public Color mediumPingColor;

	public Color badPingColor;

	[Min(0f)]
	public int mediumPingThreshold = 100;

	[Min(0f)]
	public int badPingThreshold = 200;

	private int _prevPing = -1;

	private ulong _platformId;

	public string voiceName { get; private set; }

	public void Sync(NetworkPlayerManager.PlayerStats stats)
	{
		voiceName = stats.voiceName;
		_platformId = stats.platformId;
		playerName.text = stats.playerName;
		playerName.color = GlobalScriptableObject<CosmeticGlobalData>.instance.colors[stats.colorIndex].color;
		if (AggroManagerBase<VoiceManager>.instance.HasPlayer(stats.voiceName) && !AggroManagerBase<VoiceManager>.instance.isVoiceCommsRestricted)
		{
			volumeSlider.interactable = true;
			volumeSlider.SetValueWithoutNotify(AggroManagerBase<VoiceManager>.instance.GetVolume(stats.voiceName));
		}
		else
		{
			volumeSlider.interactable = false;
			volumeSlider.SetValueWithoutNotify(0f);
		}
		if (_prevPing != stats.ping)
		{
			_prevPing = stats.ping;
			ping.text = "Ping: " + stats.ping;
			if (stats.ping < mediumPingThreshold)
			{
				ping.color = goodPingColor;
				pingImage.color = goodPingColor;
			}
			else if (stats.ping < badPingThreshold)
			{
				ping.color = mediumPingColor;
				pingImage.color = mediumPingColor;
			}
			else
			{
				ping.color = badPingColor;
				pingImage.color = badPingColor;
			}
		}
	}

	public void OnSliderVolumeChanged(float value)
	{
		if (AggroManagerBase<VoiceManager>.instance.HasPlayer(voiceName))
		{
			AggroManagerBase<VoiceManager>.instance.SetVolume(voiceName, value);
		}
	}

	public void OnSliderUpdateSelected()
	{
		if (AggroInputManager.input.GameMenu.OpenProfile.WasPressedThisFrame())
		{
			Platform.ShowProfile(_platformId);
		}
	}

	public void OnClick()
	{
		Platform.ShowProfile(_platformId);
	}

	public Selectable GetSelectable()
	{
		return volumeSlider;
	}

	public bool IsSelectable()
	{
		return volumeSlider.interactable;
	}

	public void OnSelectedPlayer()
	{
		buttonIcon.gameObject.SetActive(value: true);
	}

	public void OnDeselectedPlayer()
	{
		buttonIcon.gameObject.SetActive(value: false);
	}
}
