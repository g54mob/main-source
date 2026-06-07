using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingsSoundPane : MonoBehaviour
{
	public Slider soundEffectsSlider;

	public Slider musicSlider;

	public Slider menuMusicSlider;

	public TextMeshProUGUI soundEffectsVal;

	public TextMeshProUGUI musicVal;

	public TextMeshProUGUI menuMusicVal;

	public Toggle muteToggle;

	public Toggle muteMenuToggle;

	public Toggle muteChatToggle;

	private bool suppress;

	public void OnEnable()
	{
	}

	public void LateUpdate()
	{
	}

	public void OnMuteToggled(bool val)
	{
	}

	public void OnMuteMenuToggled(bool val)
	{
	}

	public void OnMuteChatToggled(bool val)
	{
	}

	public void OnSoundEffectsSliderChanged(float val)
	{
	}

	public void OnMusicSliderChanged(float val)
	{
	}

	public void OnMenuMusicSliderChanged(float val)
	{
	}

	public void OnSoundEffectsSliderEnd(float val)
	{
	}

	public void OnMusicSliderEnd(float val)
	{
	}

	public void OnMenuMusicSliderEnd(float val)
	{
	}
}
