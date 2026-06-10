using System;
using UnityEngine.Rendering.PostProcessing;

[Serializable]
[PostProcess(typeof(PostProcessHighlightRenderer), PostProcessEvent.BeforeTransparent, "Harryh___h/Highlight", true)]
public sealed class PostProcessHighlight : PostProcessEffectSettings
{
	public FloatParameter scale = new FloatParameter
	{
		value = 100f
	};

	public FloatParameter shine = new FloatParameter
	{
		value = 0.4f
	};

	public FloatParameter shadow = new FloatParameter
	{
		value = 0.1f
	};

	public IntParameter rotations = new IntParameter
	{
		value = 30
	};

	public FloatParameter depthThreshold = new FloatParameter
	{
		value = 0.1f
	};
}
