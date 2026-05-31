using System;
using UnityEngine;

[Serializable]
public class LightAdjustment
{
	public enum ModeTurn
	{
		Disabled = 0,
		Enabled = 1
	}

	public float MinSquareDistance;

	public float MaxSquareDistance;

	public ShadowResolution ShadowResolution;

	public ModeTurn ShadownView;

	public ModeTurn LightView;

	public bool ReduceIntensity;

	public float InitialIntensity;
}
