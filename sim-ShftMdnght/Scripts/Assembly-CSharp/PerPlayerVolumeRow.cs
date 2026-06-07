using Dissonance;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PerPlayerVolumeRow : MonoBehaviour
{
	[SerializeField]
	private TMP_Text nameLabel;

	[SerializeField]
	private Slider volumeSlider;

	private VoicePlayerState _player;

	private string _prefKey;

	public string steamName;

	private string dissonanceId;

	public void Init(VoicePlayerState player)
	{
		_player = player;
		if ((bool)nameLabel)
		{
			nameLabel.font = JSONAccess.Instance.languageFonts[PlayerPrefs.GetInt("CurLanguageInt", 0)];
			nameLabel.text = "[PLAYER-NAME]";
		}
		_prefKey = "vc_vol_" + player.Name;
		dissonanceId = player.Name;
		Invoke("InitName", 0.1f);
		float num = PlayerPrefs.GetFloat(_prefKey, 1f);
		if ((bool)volumeSlider)
		{
			volumeSlider.minValue = 0f;
			volumeSlider.maxValue = 1f;
			volumeSlider.SetValueWithoutNotify(num);
			ApplyVolume(num, save: false);
			volumeSlider.onValueChanged.AddListener(OnSliderChanged);
		}
	}

	private void InitName()
	{
		for (int i = 0; i < StoreManager.Instance.dissonanceIds.Count; i++)
		{
			if (!(StoreManager.Instance.dissonanceIds[i] == dissonanceId))
			{
				continue;
			}
			nameLabel.font = JSONAccess.Instance.languageFonts[PlayerPrefs.GetInt("CurLanguageInt", 0)];
			nameLabel.text = StoreManager.Instance.steamIds[i];
			steamName = StoreManager.Instance.steamIds[i];
			string key = steamName + "VOL";
			if (PlayerPrefs.HasKey(key))
			{
				float num = PlayerPrefs.GetFloat(key, 1f);
				if ((bool)volumeSlider)
				{
					volumeSlider.SetValueWithoutNotify(num);
				}
				ApplyVolume(num, save: false);
			}
			break;
		}
	}

	private void OnDestroy()
	{
		if (volumeSlider != null)
		{
			volumeSlider.onValueChanged.RemoveListener(OnSliderChanged);
		}
	}

	private void OnSliderChanged(float v)
	{
		ApplyVolume(v, save: true);
	}

	private void ApplyVolume(float v, bool save)
	{
		float num = Mathf.Clamp01(v);
		if (_player != null)
		{
			_player.Volume = num;
		}
		if (save)
		{
			PlayerPrefs.SetFloat(steamName + "VOL", v);
			PlayerPrefs.SetFloat(_prefKey, num);
			PlayerPrefs.Save();
		}
	}
}
