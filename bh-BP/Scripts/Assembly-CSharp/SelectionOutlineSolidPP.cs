using System;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

[Serializable]
[PostProcess(typeof(SelectionOutlineSolidPPRenderer), PostProcessEvent.BeforeTransparent, "Custom/Selection outline solid", true)]
public sealed class SelectionOutlineSolidPP : PostProcessEffectSettings
{
	[Range(0f, 0.5f)]
	[Tooltip("Width.")]
	public FloatParameter Width;

	[Tooltip("Outline color")]
	public ColorParameter color;
}
