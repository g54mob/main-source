using System;
using UnityEngine;

[Serializable]
public class LiquidInfo
{
	public LiquidType liquidType;

	public PhysicMaterial liquidMaterial;

	public Color liquidColor;

	public Material puddleMat;

	[HideInInspector]
	public Color puddleColor;

	[HideInInspector]
	public Color emissionColor;

	public void InitColors()
	{
		if (!(puddleMat == null))
		{
			puddleColor = puddleMat.color;
			emissionColor = puddleMat.GetColor("_EmissionColor");
		}
	}
}
