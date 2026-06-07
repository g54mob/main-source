using SnapshotShaders.URP;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using VolFx;

public class ScreenFiltersToggle_Handler : MonoBehaviour
{
	[SerializeField]
	private VolumeProfile volumeProfile;

	public const float DESATURATED_AMT = -16f;

	private void Start()
	{
		OptionsManager.Singleton.screenFilters_HasChanged = true;
		OptionsManager.Singleton.screenFilters_ColorDesaturation_HasChanged = true;
	}

	private void Update()
	{
		if (!OptionsManager.Singleton)
		{
			return;
		}
		if (OptionsManager.Singleton.screenFilters_HasChanged)
		{
			try
			{
				if (OptionsManager.Singleton.screenFilters_HasChanged)
				{
					if (OptionsManager.Singleton.screenFilters_Setting == 1)
					{
						if (volumeProfile.TryGet<VhsVol>(out var component))
						{
							component.active = true;
						}
						if (volumeProfile.TryGet<ScanlinesSettings>(out var component2))
						{
							component2.active = true;
						}
					}
					else
					{
						if (volumeProfile.TryGet<VhsVol>(out var component3))
						{
							component3.active = false;
						}
						if (volumeProfile.TryGet<ScanlinesSettings>(out var component4))
						{
							component4.active = false;
						}
					}
					OptionsManager.Singleton.screenFilters_HasChanged = false;
				}
			}
			catch
			{
				Debug.Log("Ran into an error with the screen filters post processing. Ignoring!");
			}
		}
		if (!OptionsManager.Singleton.screenFilters_ColorDesaturation_HasChanged)
		{
			return;
		}
		try
		{
			ColorAdjustments component6;
			if (OptionsManager.Singleton.colorDesaturation_Setting == 1)
			{
				if (volumeProfile.TryGet<ColorAdjustments>(out var component5))
				{
					component5.saturation.value = -16f;
				}
			}
			else if (volumeProfile.TryGet<ColorAdjustments>(out component6))
			{
				component6.saturation.value = 0f;
			}
			OptionsManager.Singleton.screenFilters_ColorDesaturation_HasChanged = false;
		}
		catch
		{
			Debug.Log("Ran into an error with Color Desaturation options, Ignoring!");
		}
	}
}
