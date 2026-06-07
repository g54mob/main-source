using System;
using UnityEngine.Rendering.PostProcessing;

namespace DV.Highlighting
{
	[Serializable]
	[PostProcess(typeof(HighlightEffectRenderer), PostProcessEvent.BeforeTransparent, "DV/Highlight", true)]
	public sealed class HighlightEffect : PostProcessEffectSettings
	{
	}
}
