using UnityEngine;

namespace Linework.Common.Utils
{
	public enum InjectionPoint
	{
		[InspectorName("Before Post Processing")]
		BeforeRenderingPostProcessing = 550,
		[InspectorName("After Post Processing")]
		AfterRenderingPostProcessing = 600,
		[InspectorName("Before Transparents")]
		BeforeRenderingTransparents = 450
	}
}
