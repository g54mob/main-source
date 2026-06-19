using System;
using UnityEngine.Rendering.PostProcessing;

namespace TH20
{
	[Serializable]
	[PostProcess(typeof(BlurDitheredRenderer), PostProcessEvent.BeforeTransparent, "Custom/Blur Dithered", true)]
	public sealed class BlurDitheredSettings : PostProcessEffectSettings
	{
	}
}
