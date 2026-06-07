using System;
using UnityEngine;

[Serializable]
public class BuildingMatSet
{
	public Texture2D Tex;

	public Material DefaultMat;

	public Material OutlineMaskMat;

	public Material OverlayOutlineMaskMat;

	[NonSerialized]
	public Material[] Mats;

	public void InitRuntime(Material overlayMat)
	{
	}
}
