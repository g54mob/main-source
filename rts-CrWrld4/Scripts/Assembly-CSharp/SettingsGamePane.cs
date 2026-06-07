using UnityEngine;
using UnityEngine.UI;

public class SettingsGamePane : MonoBehaviour
{
	public Toggle[] optionAALevel;

	public Toggle optionShadows;

	public Toggle optionBloom;

	public Toggle optionAmbientOcclusion;

	public Toggle optionTerrainDetile;

	public Toggle optionHighFPS;

	public Slider commonSoundVolume;

	public void OnEnable()
	{
	}

	private void Start()
	{
	}

	public void OnHighSettingsClicked()
	{
	}

	public void OnLowSettingsClicked()
	{
	}

	private void SetAA()
	{
	}

	public void OnGameLoad()
	{
	}

	public void OnOptionAA(bool val)
	{
	}

	public void OnOptionFPS(bool val)
	{
	}

	public void OnOptionShadows(bool val)
	{
	}

	public void OnOptionBloom(bool val)
	{
	}

	public void OnOptionAmbientOcclusion(bool val)
	{
	}

	public void OnOptionTerrainDetile(bool val)
	{
	}

	public void OnSoundEffectsCommon(float val)
	{
	}
}
