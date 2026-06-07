using R3;
using RetroShadersPro.URP;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

[RequireComponent(typeof(Volume))]
public class VolumeController : MonoBehaviour
{
	private Volume _volume;

	private CRTSettings _crt;

	private ColorAdjustments _brightness;

	private void Awake()
	{
		_volume = GetComponent<Volume>();
		if (_volume.profile.TryGet<CRTSettings>(out _crt))
		{
			ReactiveSettings.CRTEffect.Subscribe(_crt, delegate(bool x, CRTSettings crt)
			{
				crt.enabled.value = x;
			}).AddTo(this);
		}
		else
		{
			Debug.LogWarning("[VolumeController] CRTSettings not found in Volume Profile '" + _volume.profile.name + "'.");
		}
		if (_volume.profile.TryGet<ColorAdjustments>(out _brightness))
		{
			ReactiveSettings.Brightness.Subscribe(_brightness, delegate(int x, ColorAdjustments brightness)
			{
				brightness.postExposure.value = MapBrightness(x);
			}).AddTo(this);
		}
		else
		{
			Debug.LogWarning("[VolumeController] ColorAdjustments not found in Volume Profile '" + _volume.profile.name + "'.");
		}
	}

	private static float MapBrightness(int value)
	{
		return value switch
		{
			0 => -0.5f, 
			1 => -0.25f, 
			_ => 0f, 
		};
	}
}
