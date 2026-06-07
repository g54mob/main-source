using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuSettingsAudio : MonoBehaviour
{
	[Header("Music Volume")]
	public TMP_Text viewMusicVolume;

	public Scrollbar viewScrollbarMusicVolume;

	[Header("Effects Volume")]
	public TMP_Text viewEffectsVolume;

	public Scrollbar viewScrollbarEffectsVolume;

	private void Start()
	{
	}

	public void SetNextMusicVolume(float value)
	{
	}

	public void SetNextMusicVolumeAction(float value, bool increment = true)
	{
	}

	public void ChangedScrollbarMusicVolume(float value)
	{
	}

	public void SetNextEffectsVolume(float value)
	{
	}

	public void SetNextEffectsVolumeAction(float value, bool increment = true)
	{
	}

	public void ChangedScrollbarEffectsVolume(float value)
	{
	}

	public void SetDeflaut()
	{
	}

	public void LoadSettings()
	{
	}

	public static int AddValue(int now, int value, bool increment)
	{
		return 0;
	}

	public static float AddValue(float now, float value, bool increment)
	{
		return 0f;
	}
}
