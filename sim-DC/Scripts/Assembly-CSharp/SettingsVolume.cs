using UnityEngine;
using UnityEngine.UI;

public class SettingsVolume : MonoBehaviour
{
	[SerializeField]
	private bool isMainMenu;

	[SerializeField]
	private Slider sliderMaster;

	[SerializeField]
	private Slider sliderMusic;

	[SerializeField]
	private Slider sliderMusicMainMenu;

	[SerializeField]
	private Slider sliderEffects;

	[SerializeField]
	private Slider sliderRacks;

	private void Start()
	{
	}

	public void MasterVolume(float volume)
	{
	}

	public void MusicVolume(float volume)
	{
	}

	public void EffectVolume(float volume)
	{
	}

	public void RacksVolume(float volume)
	{
	}

	private void LoadSettings()
	{
	}
}
