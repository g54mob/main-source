using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

[Serializable]
[PostProcess(typeof(ZoneDetectorRender), PostProcessEvent.BeforeStack, "DV/Zone Detector", true)]
public sealed class ZoneDetector : PostProcessEffectSettings
{
	public enum ZoneType
	{
		Underwater = 0,
		Tunnel = 1,
		Indoors = 2,
		Depot = 3
	}

	private static Dictionary<ZoneType, float> zoneValues = new Dictionary<ZoneType, float>();

	[Tooltip("Underwater")]
	[Range(0f, 1f)]
	public FloatParameter underwater = new FloatParameter
	{
		value = 0f
	};

	[Tooltip("Tunnel")]
	[Range(0f, 1f)]
	public FloatParameter tunnel = new FloatParameter
	{
		value = 0f
	};

	[Range(0f, 1f)]
	[Tooltip("Indoors")]
	public FloatParameter indoors = new FloatParameter
	{
		value = 0f
	};

	[Tooltip("Depot")]
	[Range(0f, 1f)]
	public FloatParameter depot = new FloatParameter
	{
		value = 0f
	};

	public static event Action<float, ZoneType> ActiveCameraValueUpdated;

	public static void SetValue(float value, ZoneType type)
	{
		zoneValues[type] = value;
		ZoneDetector.ActiveCameraValueUpdated?.Invoke(value, type);
	}

	public static bool GetValue(ZoneType type, out float value)
	{
		return zoneValues.TryGetValue(type, out value);
	}
}
