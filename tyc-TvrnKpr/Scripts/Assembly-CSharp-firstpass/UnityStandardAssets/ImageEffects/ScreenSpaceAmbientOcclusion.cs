using UnityEngine;

namespace UnityStandardAssets.ImageEffects
{
	[ExecuteInEditMode]
	[RequireComponent(typeof(Camera))]
	[AddComponentMenu("Image Effects/Rendering/Screen Space Ambient Occlusion")]
	public class ScreenSpaceAmbientOcclusion : MonoBehaviour
	{
		public enum SSAOSamples
		{
			Low = 0,
			Medium = 1,
			High = 2
		}

		public float m_Radius;

		public SSAOSamples m_SampleCount;

		public float m_OcclusionIntensity;

		public int m_Blur;

		public int m_Downsampling;

		public float m_OcclusionAttenuation;

		public float m_MinZ;

		public Shader m_SSAOShader;

		private Material m_SSAOMaterial;

		public Texture2D m_RandomTexture;

		private bool m_Supported;

		private static Material CreateMaterial(Shader shader)
		{
			return null;
		}

		private static void DestroyMaterial(Material mat)
		{
		}

		private void OnDisable()
		{
		}

		private void Start()
		{
		}

		private void OnEnable()
		{
		}

		private void CreateMaterials()
		{
		}

		[ImageEffectOpaque]
		private void OnRenderImage(RenderTexture source, RenderTexture destination)
		{
		}
	}
}
