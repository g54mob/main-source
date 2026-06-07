using UnityEngine;

namespace AmazingAssets.AdvancedDissolve
{
	[ExecuteAlways]
	[RequireComponent(typeof(Light))]
	public class AdvancedDissolveSpotLightToConeSmooth : MonoBehaviour
	{
		public AdvancedDissolveGeometricCutoutController geometricCutoutController;

		public AdvancedDissolveKeywords.CutoutGeometricCount countID;

		public float radiusOffset;

		private Light spotLight;

		private void Start()
		{
		}

		private void Update()
		{
		}
	}
}
