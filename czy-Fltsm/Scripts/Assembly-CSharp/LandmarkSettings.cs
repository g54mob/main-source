using System;
using PajamaLlama.Generic;
using UnityEngine;
using UnityEngine.PajamaLlama;

[CreateAssetMenu(menuName = "Flotsam/Settings/Landmark Settings")]
public class LandmarkSettings : ScriptableObject
{
	[Tooltip("Array containing every possible LandmarkFeatures, must be ordered accordingly to the LandmarkFeature enum.")]
	public LandmarkFeatureProperties[] LandmarkFeatureProperties;

	[MinMaxRangeFloat(0.25f, 2f)]
	public RangedFloat MapScaling = new RangedFloat(0.5f, 1.5f);

	public WorldMapLandmarkPolygonVisual LandmarkPolygonVisual;

	[Header("Audio")]
	public AudioClipProperties landmarkCompletedSound;

	[Header("Visuals")]
	public GameObject MapMooringPointPrefab;

	[Header("Bearings")]
	[SerializeField]
	[NamedArrayElement(new string[] { "Type" })]
	private BearingIcon[] _bearingIcons;

	[SerializeField]
	private Sprite _distressSignalBearingIcon;

	public Sprite DistressSignalBearingIcon => _distressSignalBearingIcon;

	public LandmarkFeatureProperties ReturnLandmarkFeatureProperty(LandmarkFeature feature)
	{
		for (int i = 0; i < LandmarkFeatureProperties.Length; i++)
		{
			if (LandmarkFeatureProperties[i].Feature == feature)
			{
				return LandmarkFeatureProperties[i];
			}
		}
		return null;
	}

	public Sprite ReturnBearingIcon(BearingIconType type)
	{
		if (type == BearingIconType.None)
		{
			return null;
		}
		BearingIcon[] bearingIcons = _bearingIcons;
		for (int i = 0; i < bearingIcons.Length; i++)
		{
			BearingIcon bearingIcon = bearingIcons[i];
			if (bearingIcon.Type == type)
			{
				return bearingIcon.Icon;
			}
		}
		Debug.LogException(new Exception($"No BearingIcon has been add to LandmarkSettings for BearingIconType '{type}'"));
		return null;
	}
}
