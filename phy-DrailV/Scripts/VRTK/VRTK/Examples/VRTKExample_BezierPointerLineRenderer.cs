using UnityEngine;

namespace VRTK.Examples
{
	public class VRTKExample_BezierPointerLineRenderer : VRTKExample_BezierPointerChanger
	{
		public GameObject lineRendererPrefab;

		protected override void StyleRenderer(VRTK_BezierPointerRenderer renderer)
		{
			if (renderer != null)
			{
				ResetRenderer(renderer);
				renderer.gameObject.SetActive(value: false);
				renderer.customTracer = lineRendererPrefab;
				renderer.gameObject.SetActive(value: true);
			}
		}
	}
}
