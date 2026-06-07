using UnityEngine;

namespace RetroShadersPro.URP
{
	public enum PostProcessRenderPassEvent
	{
		[InspectorName("Before URP Post Processing")]
		BeforeURPPostProcessing = 0,
		[InspectorName("After URP Post Processing")]
		AfterURPPostProcessing = 1
	}
}
