using UnityEngine;

namespace GPUInstancerPro
{
	[RequireComponent(typeof(Light))]
	[DefaultExecutionOrder(-1000)]
	[ExecuteInEditMode]
	public class GPUISRPLightSetting : MonoBehaviour
	{
		[Header("URP")]
		public float uRPIntensity = 1f;

		[Header("HDRP")]
		public float hDRPIntensity = 100000f;

		[Range(0f, 3f)]
		public int hDRPShadowResolutionLevel = 2;

		private void OnEnable()
		{
			if (GPUIRuntimeSettings.Instance.RenderPipeline == GPUIRenderPipeline.URP)
			{
				GetComponent<Light>().intensity = uRPIntensity;
			}
		}
	}
}
