using UnityEngine;
using UnityEngine.Events;

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

		public LightProbeGroup lightProbeGroup;

		public Vector3 probeVolumeSize = new Vector3(50f, 50f, 50f);

		public UnityEvent onAPVEnabled;

		public UnityEvent onAPVDisabled;

		private void OnEnable()
		{
			if (GPUIRuntimeSettings.Instance.RenderPipeline == GPUIRenderPipeline.URP)
			{
				GetComponent<Light>().intensity = uRPIntensity;
				HandleAPV();
			}
			else
			{
				HandleAPV();
			}
		}

		private void HandleAPV()
		{
			if (lightProbeGroup != null)
			{
				if (GPUIRuntimeSettings.IsAdaptiveProbeVolumesEnabled())
				{
					onAPVEnabled?.Invoke();
				}
				else
				{
					onAPVDisabled?.Invoke();
				}
			}
		}
	}
}
