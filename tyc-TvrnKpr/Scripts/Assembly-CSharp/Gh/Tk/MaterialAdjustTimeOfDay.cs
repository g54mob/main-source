using UnityEngine;

namespace Gh.Tk
{
	[RequireComponent(typeof(MeshRenderer))]
	public class MaterialAdjustTimeOfDay : MonoBehaviour
	{
		private Material[] _materials;

		public string matPropertyToAdjust;

		public AnimationCurve dayTimeCurve;

		public AnimationCurve sunlightCurve;

		public bool useMetallic;

		public AnimationCurve metallicCurve;

		public bool useSmoothness;

		public AnimationCurve smoothnessCurve;

		public bool useDiffuse;

		[ColorUsage(true, true)]
		public Color diffuseColorZero;

		[ColorUsage(true, true)]
		public Color diffuseColorOne;

		public bool useEmission;

		public Color emissionColor;

		public bool useAmbient;

		public float ambientMixPercentage;

		public Color preBlendWithAmbient;

		public float preBlendPercentage;

		public bool useGradient;

		public Gradient diffuseGradient;

		public bool useHDRGradient;

		[GradientUsage(true, ColorSpace.Linear)]
		public Gradient hdrGradient;

		private void Start()
		{
		}

		private void OnDestroy()
		{
		}

		public void UpdateMaterial(float dayF)
		{
		}
	}
}
