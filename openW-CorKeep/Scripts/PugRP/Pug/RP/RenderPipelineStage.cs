using System;

namespace Pug.RP
{
	[Serializable]
	public enum RenderPipelineStage
	{
		None = -2,
		BeforeLightUpdate = -1,
		BeforeEverything = 0,
		BeforeGeometry = 1,
		BeforeGBuffer = 2,
		AfterGBuffer = 3,
		BeforeDeferredLighting = 4,
		AfterDeferredLighting = 5,
		BeforeForwardOpaque = 6,
		AfterForwardOpaque = 7,
		BeforeForwardTransparent = 8,
		AfterForwardTransparent = 9,
		AfterGeometry = 10,
		BeforePostProcessing = 11,
		AfterPostProcessing = 12,
		AfterEverything = 13
	}
}
