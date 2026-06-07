using System;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

[Serializable]
[PostProcess(typeof(CRTPPSRenderer), PostProcessEvent.AfterStack, "CRT", true)]
public sealed class CRTPPSSettings : PostProcessEffectSettings
{
	[Tooltip("Bleeding range")]
	public FloatParameter _Bleedingrange;

	[Tooltip("Color bleeding")]
	public FloatParameter _Colorbleeding;

	[Tooltip("Lines velocity")]
	public FloatParameter _Linesvelocity;

	[Tooltip("Lines distance")]
	public FloatParameter _Linesdistance;

	[Tooltip("Line pixel size")]
	public FloatParameter _Linepixelsize;

	[Tooltip("Virtual width")]
	public FloatParameter _Virtualwidth;

	[Tooltip("Scanline alpha")]
	public FloatParameter _Scanlinealpha;

	[Tooltip("Grid opacity")]
	public FloatParameter _Gridopacity;
}
